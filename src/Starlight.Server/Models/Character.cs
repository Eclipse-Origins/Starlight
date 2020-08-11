using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Models
{
    public class Character : AbstractModel
    {
        public int Slot { get; set; }
        public string Name { get; set; }
    }
}
