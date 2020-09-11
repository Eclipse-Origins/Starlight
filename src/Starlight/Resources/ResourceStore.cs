using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Starlight.Resources
{
    public class ResourceStore
    {
        static ResourceStore instance;
        public static ResourceStore Instance {
            get {
                if (instance == null) {
                    instance = new ResourceStore();
                }

                return instance;
            }
        }

        public string ResourceDirectory { get; }
        public string TilesetsDirectory { get; }

        public ResourceStore() {
            this.ResourceDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Content");
            this.TilesetsDirectory = Path.Combine(ResourceDirectory, "Tilesets");
        }
    }
}
