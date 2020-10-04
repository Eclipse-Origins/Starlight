using Starlight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class Character : CoreDataModel
    {
        public int Slot { get; set; }
        public string Name { get; set; }

        public int Sprite { get; set; }
    }
}
