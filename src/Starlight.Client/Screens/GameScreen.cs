using Microsoft.Xna.Framework;
using Myra;
using Starlight.Client.Rendering;
using Starlight.Client.Screens.Core;
using Starlight.Client.State;
using Starlight.Models;
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

        public override void Update(GameUpdateState state) {
            base.Update(state);

            var character = Player.Instance.Character;

            if (state.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down)) {
                character.State.Offset = new System.Numerics.Vector2(character.State.Offset.X, character.State.Offset.Y + 2);
            }
            if (state.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up)) {
                character.State.Offset = new System.Numerics.Vector2(character.State.Offset.X, character.State.Offset.Y - 2);
            }
            if (state.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right)) {
                character.State.Offset = new System.Numerics.Vector2(character.State.Offset.X + 2, character.State.Offset.Y);
            }
            if (state.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)) {
                character.State.Offset = new System.Numerics.Vector2(character.State.Offset.X - 2, character.State.Offset.Y);
            }
        }

        protected override void OnRenderBackgroundFrame(IRenderContext renderContext) {
            base.OnRenderBackgroundFrame(renderContext);

            renderContext.SpriteBatch.FillRectangle(0, 0, Context.Game.GraphicsDevice.Viewport.Width, Context.Game.GraphicsDevice.Viewport.Height, Color.Black);

            var character = Player.Instance.Character;

            var spriteTexture = Context.ResourceCache.LoadTexture2D(Context.ResourceLocator.LocateAssetPath("Sprites", $"{character.Sprite}.png"));

            renderContext.RenderSpriteAnimation(spriteTexture, character.State, character.Direction, new Vector2(32, 48), new Vector2(character.X + character.State.Offset.X, character.Y + character.State.Offset.Y));
        }
    }
}
