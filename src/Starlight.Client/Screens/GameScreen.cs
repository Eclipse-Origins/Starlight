using Microsoft.Xna.Framework;
using Myra;
using Serilog;
using Starlight.Client.Rendering;
using Starlight.Client.Screens.Core;
using Starlight.Client.State;
using Starlight.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            if (character.State.MotionDirection == Direction.None) {
                var activeDirection = Direction.None;
                if (state.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down)) {
                    activeDirection |= Direction.Bottom;
                }
                if (state.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up)) {
                    activeDirection |= Direction.Top;
                }
                if (state.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right)) {
                    activeDirection |= Direction.Right;
                }
                if (state.KeyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left)) {
                    activeDirection |= Direction.Left;
                }

                if (activeDirection != Direction.None) {
                    character.Direction = activeDirection;
                    character.State.MotionDirection = activeDirection;
                }
            } else {
                if (character.State.MotionDirection.HasFlag(Direction.Top)) {
                    character.State.Offset = new System.Numerics.Vector2(character.State.Offset.X, character.State.Offset.Y - 2);
                }
                if (character.State.MotionDirection.HasFlag(Direction.Bottom)) {
                    character.State.Offset = new System.Numerics.Vector2(character.State.Offset.X, character.State.Offset.Y + 2);
                }
                if (character.State.MotionDirection.HasFlag(Direction.Right)) {
                    character.State.Offset = new System.Numerics.Vector2(character.State.Offset.X + 2, character.State.Offset.Y);
                }
                if (character.State.MotionDirection.HasFlag(Direction.Left)) {
                    character.State.Offset = new System.Numerics.Vector2(character.State.Offset.X - 2, character.State.Offset.Y);
                }

                if (Math.Abs(character.State.Offset.X) >= Constants.TileSize || Math.Abs(character.State.Offset.Y) >= Constants.TileSize) {
                    if (character.State.MotionDirection.HasFlag(Direction.Top)) {
                        character.Y -= 1;
                    }
                    if (character.State.MotionDirection.HasFlag(Direction.Bottom)) {
                        character.Y += 1;
                    }
                    if (character.State.MotionDirection.HasFlag(Direction.Right)) {
                        character.X += 1;
                    }
                    if (character.State.MotionDirection.HasFlag(Direction.Left)) {
                        character.X -= 1;
                    }

                    character.State.Offset = System.Numerics.Vector2.Zero;
                    character.State.MotionDirection = Direction.None;
                }
            }
        }

        protected override void OnRenderBackgroundFrame(IRenderContext renderContext) {
            base.OnRenderBackgroundFrame(renderContext);

            renderContext.SpriteBatch.FillRectangle(0, 0, Context.Game.GraphicsDevice.Viewport.Width, Context.Game.GraphicsDevice.Viewport.Height, Color.Black);

            var character = Player.Instance.Character;

            var spriteTexture = Context.ResourceCache.LoadTexture2D(Context.ResourceLocator.LocateAssetPath("Sprites", $"{character.Sprite}.png"));

            renderContext.RenderSpriteAnimation(spriteTexture, character.State, character.Direction, new Vector2(32, 48), new Vector2((character.X * Constants.TileSize) + character.State.Offset.X, (character.Y * Constants.TileSize) + character.State.Offset.Y));
        }
    }
}
