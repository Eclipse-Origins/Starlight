using Starlight.Models;
using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class CharacterSelectedPacket : AbstractPacket
    {
        public Character Character { get; set; }

        public CharacterSelectedPacket(Character character) {
            this.Character = character;
        }
    }
}
