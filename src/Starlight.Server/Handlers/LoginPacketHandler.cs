using Microsoft.EntityFrameworkCore;
using Serilog;
using Starlight.Models;
using Starlight.Packets;
using Starlight.Server.Handlers.Core;
using Starlight.Server.Network;
using Starlight.Server.Security;
using Starlight.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starlight.Server.Handlers
{
    public class LoginPacketHandler : AbstractPacketHandler<LoginPacket>
    {
        public override void HandlePacket(RequestContext requestContext, LoginPacket packet) {

            if (!DenyList.Instance.Sanitize(packet.Username.Trim()).Equals(packet.Username.Trim())) {
                Log.Warning("[" + requestContext.ConnectionId + "] Hack attempt! Sanitized username!");
            }

            packet.Username = DenyList.Instance.Sanitize(packet.Username.Trim());
            var user = requestContext.DbContext.Users.Include(x => x.Characters)
                                                     .Where(x => x.Username.ToLower() == packet.Username.ToLower()).FirstOrDefault();
            Log.Information("[" + requestContext.ConnectionId + "] Login as user " + packet.Username);

            if (user == null) {
                Log.Error("[" + requestContext.ConnectionId + "] "+ TranslationManager.Instance.Translate("Login.InvalidUsernamePassword"));
                requestContext.Server.SendPacket(requestContext.ConnectionId, new LoginResultPacket(false, TranslationManager.Instance.Translate("Login.InvalidUsernamePassword")));
                return;
            }

            var passwordHasher = new PasswordHasher();
            if (!passwordHasher.VerifyPassword(user.PasswordHash, user.PasswordSalt, packet.Password)) {
                Log.Error("[" + requestContext.ConnectionId + "] " + TranslationManager.Instance.Translate("Login.InvalidUsernamePassword"));
                requestContext.Server.SendPacket(requestContext.ConnectionId, new LoginResultPacket(false, TranslationManager.Instance.Translate("Login.InvalidUsernamePassword")));
                return;
            }

            requestContext.ConnectedUserManager.AddUser(requestContext.ConnectionId, new RequestUser(user.Id, packet.ClientType));

            var characters = user.Characters.Select(x => new MenuCharacterDetails()
            {
                Id = x.Id,
                Slot = x.Slot,
                Name = x.Name
            }).ToArray(); 

            requestContext.Server.SendPacket(requestContext.ConnectionId, new LoginResultPacket(true, string.Empty));
            requestContext.Server.SendPacket(requestContext.ConnectionId, new MenuCharacterDetailsPacket(characters));
        }
    }
}
