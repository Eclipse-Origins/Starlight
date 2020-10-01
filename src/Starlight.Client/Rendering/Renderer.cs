using Microsoft.Xna.Framework.Graphics;

namespace Starlight.Client.Rendering
{
    public class Renderer
    {
        public GraphicsDevice GraphicsDevice { get; }

        public Renderer(GraphicsDevice graphicsDevice)
        {
            this.GraphicsDevice = graphicsDevice;
        }
    }
}
