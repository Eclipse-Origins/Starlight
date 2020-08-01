using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starlight.Client.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public interface IScreen
    {
        void PrepareResources(GraphicsDevice graphicsDevice);

        void Update(GameTime gameTime);
        void RenderUIFrame(RenderContext renderContext);
        void RenderFrame(RenderContext renderContext);
    }
}
