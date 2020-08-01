using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Rendering
{
    public class RenderContext
    {
        public GraphicsDevice GraphicsDevice { get; }
        public SpriteBatch SpriteBatch { get; }

        public RenderContext(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch) {
            this.GraphicsDevice = graphicsDevice;
            this.SpriteBatch = spriteBatch;
        }
    }
}
