using Microsoft.Xna.Framework;
using Myra;
using Starlight.Client.Rendering;
using Starlight.Client.Screens.Core;
using Starlight.Client.State;
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

            renderContext.SpriteBatch.FillRectangle(0, 0, Context.Game.GraphicsDevice.Viewport.Width, Context.Game.GraphicsDevice.Viewport.Height, Color.Black);

            var sprite = Player.Instance.Character.Sprite;

            var spriteTexture = Context.ResourceCache.LoadTexture2D(Context.ResourceLocator.LocateAssetPath("Sprites", $"{sprite}.png"));

            renderContext.SpriteBatch.Draw(spriteTexture, new Vector2(0, 0), Color.White);
        }
    }
}
