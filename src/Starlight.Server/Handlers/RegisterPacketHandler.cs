using Serilog;
using Starlight.Models;
using Starlight.Packets;
using Starlight.Server.Data;
using Starlight.Server.Handlers.Core;
using Starlight.Server.Network;
using Starlight.Server.Security;
using Starlight.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Starlight.Server.Handlers
{
    public class RegisterPacketHandler : AbstractPacketHandler<RegisterPacket>
    {
        public override void HandlePacket(RequestContext requestContext, RegisterPacket packet) {
            if (!DenyList.Instance.Sanitize(packet.Username.Trim()).Equals(packet.Username.Trim())) {
                Log.Warning("[" + requestContext.ConnectionId + "] Hack attempt! Sanitized username!");
            }
            packet.Username = DenyList.Instance.Sanitize(packet.Username.Trim());
            Log.Information("[" + requestContext.ConnectionId + "] Creating user " + packet.Username);

            if (DenyList.Instance.CheckDenied(packet.Username)) {
                Log.Error("[" + requestContext.ConnectionId + "] " + TranslationManager.Instance.Translate("Register.AccountBanned"));
                requestContext.Server.SendPacket(requestContext.ConnectionId, new RegistrationResultPacket(false, TranslationManager.Instance.Translate("Register.AccountBanned")));
                return;
            }

            var user = requestContext.DbContext.Users.Where(x => x.Username.ToLower() == packet.Username.ToLower()).FirstOrDefault();
            if (user != null) {
                Log.Error("[" + requestContext.ConnectionId + "] "+ TranslationManager.Instance.Translate("Register.AccountExists"));
                requestContext.Server.SendPacket(requestContext.ConnectionId, new RegistrationResultPacket(false, TranslationManager.Instance.Translate("Register.AccountExists")));
                return;
            }

            CreateUser(requestContext.DbContext, packet.Username, packet.Password);
 
            requestContext.Server.SendPacket(requestContext.ConnectionId, new RegistrationResultPacket(true, TranslationManager.Instance.Translate("Register.AccountCreated")));
        }

        private User CreateUser(ApplicationDbContext dbContext, string username, string password) {
            var passwordHasher = new PasswordHasher();

            var hashedPassword = passwordHasher.HashPassword(password);

            var user = new User();
            user.Username = username;
            user.PasswordHash = hashedPassword.PasswordHash;
            user.PasswordSalt = hashedPassword.Salt;

            dbContext.Users.Add(user);

            return user;
        }
    }
}
