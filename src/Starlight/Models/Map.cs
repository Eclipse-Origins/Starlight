using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Models
{
    public class Map : CoreDataModel
    {
        public List<MapLayer> Layers { get; set; }
        public List<MapAttribute> Attributes { get; set; }

        public static Map Create() {
            var map = new Map();

            map.Layers = new List<MapLayer>()
            {
                new MapLayer() { Name = "Ground" },
                new MapLayer() { Name = "Mask" },
                new MapLayer() { Name = "Mask 2" },
                new MapLayer() { Name = "Fringe" },
                new MapLayer() { Name = "Fringe 2" }
            };

            return map;
        }
    }
}
