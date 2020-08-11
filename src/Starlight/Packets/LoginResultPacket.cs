using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class LoginResultPacket : AbstractResultPacket
    {
        public LoginResultPacket(bool succeeded, string message) : base(succeeded, message) {
        }
    }
}
