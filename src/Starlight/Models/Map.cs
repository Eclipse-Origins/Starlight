using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class Map : CoreDataModel
    {
        public List<MapLayer> Layers { get; set; }
        public List<MapAttribute> Attributes { get; set; }
    }
}
