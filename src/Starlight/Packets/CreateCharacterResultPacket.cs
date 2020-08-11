using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class CreateCharacterResultPacket : AbstractResultPacket
    {
        public CreateCharacterResultPacket(bool succeeded, string message) : base(succeeded, message) {
        }
    }
}
