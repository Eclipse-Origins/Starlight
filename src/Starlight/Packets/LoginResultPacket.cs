using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class LoginResultPacket : AbstractPacket
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public LoginResultPacket(bool succeeded, string message) {
            this.Succeeded = succeeded;
            this.Message = message;
        }
    }
}
