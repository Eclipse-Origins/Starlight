using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class UseCharacterPacket : AbstractPacket
    {
        public int Slot { get; set; }

        public UseCharacterPacket(int slot) {
            this.Slot = slot;
        }
    }
}
