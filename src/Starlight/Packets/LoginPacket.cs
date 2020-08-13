using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class LoginPacket : AbstractPacket
    {
        public ClientType ClientType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginPacket(ClientType clientType, string username, string password) {
            this.ClientType = clientType;
            this.Username = username;
            this.Password = password;
        }
    }
}
