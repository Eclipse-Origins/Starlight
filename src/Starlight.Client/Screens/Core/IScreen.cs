using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starlight.Client.Rendering;
using Starlight.Client.State;
using Starlight.Client.UI;
using System;
using System.Collections.Generic;
using System.Text;

using MyraUI = Myra.Graphics2D.UI;

namespace Starlight.Client.Screens.Core
{
    public interface IScreen
    {
        StarlightGrid RootUI { get; }

        void PrepareResources(GraphicsDevice graphicsDevice);

        void Layout();
        void Update(GameUpdateState state);
        void RenderBackgroundFrame(IRenderContext renderContext);
        void RenderForegroundFrame(IRenderContext renderContext);
    }
}
