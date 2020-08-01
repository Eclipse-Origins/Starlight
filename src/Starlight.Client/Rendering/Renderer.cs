using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Rendering
{
    public class Renderer
    {
        public GraphicsDevice GraphicsDevice { get; }

        public Renderer(GraphicsDevice graphicsDevice) {
            this.GraphicsDevice = graphicsDevice;
        }
    }
}
