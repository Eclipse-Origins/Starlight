using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starlight.Client.Rendering;
using Starlight.Client.UI;

namespace Starlight.Client.Screens.Core
{
    public interface IScreen
    {
        StarlightGrid RootUI { get; }

        void PrepareResources(GraphicsDevice graphicsDevice);

        void Layout();
        void Update(GameTime gameTime);
        void RenderBackgroundFrame(RenderContext renderContext);
        void RenderForegroundFrame(RenderContext renderContext);
    }
}
