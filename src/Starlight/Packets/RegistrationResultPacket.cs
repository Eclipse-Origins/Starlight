using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class RegistrationResultPacket : AbstractPacket
    {
        public bool Succeeded { get; set; }

        public RegistrationResultPacket(bool succeeded) {
            this.Succeeded = succeeded;
        }
    }
}
