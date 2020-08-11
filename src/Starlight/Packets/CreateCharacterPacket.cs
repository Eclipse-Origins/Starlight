using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class CreateCharacterPacket : AbstractPacket
    {
        public int Slot { get; set; }
        public string Name { get; set; }

        public CreateCharacterPacket(int slot, string name) {
            this.Slot = slot;
            this.Name = name;
        }
    }
}
