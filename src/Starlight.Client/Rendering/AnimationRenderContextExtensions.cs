using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Starlight.Models;
using Starlight.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Rendering
{
    public static class AnimationRenderContextExtensions
    {
        public static void RenderSpriteAnimation(this IRenderContext renderContext, Texture2D texture, IAnimationState animationState, Direction direction, Vector2 frameSize, Vector2 destination) {
            var animationRow = 0;
            switch (direction) {
                case Direction.Bottom:
                    animationRow = 0;
                    break;
                case Direction.Left:
                    animationRow = 1;
                    break;
                case Direction.Right:
                    animationRow = 2;
                    break;
                case Direction.Top:
                    animationRow = 3;
                    break;
            }

            renderContext.RenderAnimation(texture, animationState, animationRow, frameSize, destination);
        }

        public static void RenderAnimation(this IRenderContext renderContext, Texture2D texture, IAnimationState animationState, int animationRow, Vector2 frameSize, Vector2 destination) {
            var sourceRectangle = new Rectangle(animationState.Frame * (int)frameSize.X, animationRow * (int)frameSize.Y, (int)frameSize.X, (int)frameSize.Y);

            renderContext.SpriteBatch.Draw(texture, new Rectangle((int)destination.X, (int)destination.Y, sourceRectangle.Width, sourceRectangle.Height), sourceRectangle, Color.White);
        }
    }
}
