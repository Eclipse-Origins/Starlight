using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class RegistrationResultPacket : AbstractResultPacket
    {
        public RegistrationResultPacket(bool succeeded, string message) : base(succeeded, message) {
        }
    }
}
