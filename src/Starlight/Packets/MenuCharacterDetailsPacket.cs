using Starlight.Models;
using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets
{
    public class MenuCharacterDetailsPacket : AbstractPacket
    {
        public MenuCharacterDetails[] Characters { get; set; }

        public MenuCharacterDetailsPacket(MenuCharacterDetails[] characters) {
            this.Characters = characters;
        }
    }
}
