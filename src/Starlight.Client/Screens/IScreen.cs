using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starlight.Client.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

using MyraUI = Myra.Graphics2D.UI;

namespace Starlight.Client.Screens
{
    public interface IScreen
    {
        MyraUI.Grid RootUI { get; }

        void PrepareResources(GraphicsDevice graphicsDevice);

        void Layout();
        void Update(GameTime gameTime);
        void RenderBackgroundFrame(RenderContext renderContext);
        void RenderForegroundFrame(RenderContext renderContext);
    }
}
