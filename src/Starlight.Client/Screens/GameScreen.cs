using Microsoft.Xna.Framework;
using Myra;
using Starlight.Client.Rendering;
using Starlight.Client.Screens.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public class GameScreen : AbstractScreen<GameScreen.Controls>
    {
        public class Controls
        {
        }

        public GameScreen(ScreenContext screenContext) : base(screenContext) {
        }

        protected override void OnRenderBackgroundFrame(RenderContext renderContext) {
            base.OnRenderBackgroundFrame(renderContext);

            renderContext.SpriteBatch.FillRectangle(0, 0, 100, 100, Color.Red);
        }
    }
}
