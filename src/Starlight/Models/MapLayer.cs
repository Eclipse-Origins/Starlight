using Starlight.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class MapLayer : CoreDataModel
    {
        public string Name { get; set; }

        public List<MapTile> Tiles { get; set; }
    }
}
