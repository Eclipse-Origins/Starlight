using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class DeleteCharacterPacket : AbstractPacket
    {
        public int Slot { get; set; }

        public DeleteCharacterPacket(int slot) {
            this.Slot = slot;
        }
    }
}
