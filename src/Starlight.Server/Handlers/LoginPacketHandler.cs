using Starlight.Packets;
using Starlight.Server.Handlers.Core;
using Starlight.Server.Network;
using Starlight.Server.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starlight.Server.Handlers
{
    public class LoginPacketHandler : AbstractPacketHandler<LoginPacket>
    {
        public override void HandlePacket(RequestContext requestContext, LoginPacket packet) {
            var user = requestContext.DbContext.Users.Where(x => x.Username.ToLower() == packet.Username.ToLower()).FirstOrDefault();
            if (user == null) {
                requestContext.Server.SendPacket(requestContext.ConnectionId, new LoginResultPacket(false, "Invalid username or password."));
                return;
            }

            var passwordHasher = new PasswordHasher();
            if (!passwordHasher.VerifyPassword(user.PasswordHash, user.PasswordSalt, packet.Password)) {
                requestContext.Server.SendPacket(requestContext.ConnectionId, new LoginResultPacket(false, "Invalid username or password."));
                return;
            }

            requestContext.Server.SendPacket(requestContext.ConnectionId, new LoginResultPacket(true, string.Empty));
        }
    }
}
