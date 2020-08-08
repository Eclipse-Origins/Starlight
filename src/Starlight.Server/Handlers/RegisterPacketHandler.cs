using Starlight.Packets;
using Starlight.Server.Data;
using Starlight.Server.Handlers.Core;
using Starlight.Server.Models;
using Starlight.Server.Network;
using Starlight.Server.Security;
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
            // TODO: Whitelist allowed characters

            packet.Username = packet.Username.Trim();

            var user = requestContext.DbContext.Users.Where(x => x.Username.ToLower() == packet.Username.ToLower()).FirstOrDefault();
            if (user != null) {
                requestContext.Server.SendPacket(requestContext.ConnectionId, new RegistrationResultPacket(false, "Account already exists."));
                return;
            }

            CreateUser(requestContext.DbContext, packet.Username, packet.Password);

            requestContext.Server.SendPacket(requestContext.ConnectionId, new RegistrationResultPacket(true, "Account has been created."));
        }

        private User CreateUser(ApplicationDbContext dbContext, string username, string password) {
            var passwordHasher = new PasswordHasher();

            var hashedPassword = passwordHasher.HashPassword(password);

            var user = new User();
            user.Username = username;
            user.PasswordHash = hashedPassword.PasswordHash;
            user.PasswordSalt = hashedPassword.Salt;

            dbContext.Users.Add(user);

            dbContext.SaveChanges();

            return user;
        }
    }
}
