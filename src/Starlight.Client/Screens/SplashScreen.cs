using Starlight.Client.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

using static SDL2.SDL;

namespace Starlight.Client.Screens
{
    public class SplashScreen : AbstractScreen
    {
        Surface surface;

        public SplashScreen(ScreenContext screenContext) : base(screenContext) {
        }

        public override void PrepareResources(Renderer renderer) {
            base.PrepareResources(renderer);

            surface = Surface.Load(renderer, ScreenContext.ResourceLocator.LocateAssetPath("graphics", "items", "1.png"));
        }

        public override void RenderFrame(RenderContext renderContext) {
            base.RenderFrame(renderContext);

            var rectangle = new SDL_Rect()
            {
                x = 10,
                y = 10,
                w = 100,
                h = 100
            };

            SDL_SetRenderDrawColor(renderContext.Renderer.Handle, 255, 0, 0, 255);
            SDL_RenderFillRect(renderContext.Renderer.Handle, ref rectangle);

            var srcRect = new SDL_Rect()
            {
                x = 0,
                y = 0,
                w = surface.Width,
                h = surface.Height
            };

            var dstRect = new SDL_Rect()
            {
                x = 200,
                y = 200,
                w = surface.Width,
                h = surface.Height
            };

            SDL_RenderCopy(renderContext.Renderer.Handle, surface.TextureHandle, ref srcRect, ref dstRect);
        }
    }
}
