using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static SDL2.SDL;
using static SDL2.SDL_image;

namespace Starlight.Client.Rendering
{
    public class Surface
    {
        public IntPtr SurfaceHandle { get; }
        public IntPtr TextureHandle { get; }

        public int Width { get; }
        public int Height { get; }

        public Surface(IntPtr surfaceHandle, IntPtr textureHandle) {
            this.SurfaceHandle = surfaceHandle;
            this.TextureHandle = textureHandle;

            var surface = surfaceHandle.AsStruct<SDL_Surface>();

            this.Width = surface.w;
            this.Height = surface.h;
        }

        public static Surface Load(Renderer renderer, string filePath) {
            var surfaceHandle = IMG_Load(filePath);
            var textureHandle = SDL_CreateTextureFromSurface(renderer.Handle, surfaceHandle);

            return new Surface(surfaceHandle, textureHandle);
        }
    }
}
