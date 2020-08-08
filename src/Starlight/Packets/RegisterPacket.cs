using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class RegisterPacket : AbstractPacket
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public RegisterPacket(string username, string password) {
            this.Username = username;
            this.Password = password;
        }
    }
}
