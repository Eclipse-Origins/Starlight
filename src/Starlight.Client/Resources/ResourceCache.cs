using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Resources
{
    public class ResourceCache
    {
        static ResourceCache instance;
        public static ResourceCache Instance {
            get {
                if (instance == null) {
                    instance = new ResourceCache();
                }

                return instance;
            }
        }

        GraphicsDevice graphicsDevice;

        Dictionary<string, Texture2D> textures;

        public ResourceCache() {
            this.textures = new Dictionary<string, Texture2D>();
        }

        public void UpdateGraphcisDevice(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;

            // Reset all resources once the graphics device changes
            this.textures.Clear();
        }

        public Texture2D LoadTexture2D(string path) {
            if (!this.textures.TryGetValue(path, out var texture)) {
                texture = Texture2D.FromFile(graphicsDevice, path);

                this.textures.Add(path, texture);
            }

            return texture;
        }
    }
}
