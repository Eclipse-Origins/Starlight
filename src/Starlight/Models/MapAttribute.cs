using Starlight.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class MapAttribute : CoreDataModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MapAttributeType Type { get; set; }
    }
}
