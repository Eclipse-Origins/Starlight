using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class DeleteCharacterResultPacket : AbstractResultPacket
    {
        public DeleteCharacterResultPacket(bool succeeded, string message) : base(succeeded, message) {
        }
    }
}
