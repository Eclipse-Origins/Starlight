using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class MenuCharacterDetails : CoreModel
    {
        public int Id { get; set; }
        public int Slot { get; set; }
        public string Name { get; set; }
    }
}
