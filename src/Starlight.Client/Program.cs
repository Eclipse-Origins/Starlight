using SDL2;
using System;
using System.IO;
using static SDL2.SDL;
using static SDL2.SDL_image;

namespace Starlight.Client
{
    class Program
    {
        private static int ImageFlags = (int)(IMG_InitFlags.IMG_INIT_PNG | IMG_InitFlags.IMG_INIT_JPG);

        static void Main(string[] args) {
            if (SDL_Init(SDL_INIT_VIDEO) < 0) {
                throw new Exception($"SDL could not initialize! SDL_Error: {SDL_GetError()}");
            }

            var result = IMG_Init((IMG_InitFlags)ImageFlags);
            if ((result & ImageFlags) != ImageFlags) {
                throw new Exception(SDL_GetError());
            }

            var window = SDL_CreateWindow("Test", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 1024, 768, SDL_WindowFlags.SDL_WINDOW_SHOWN);
            if (window == IntPtr.Zero) {
                throw new Exception($"Window could not be created! SDL_Error: {SDL_GetError()}");
            }

            var renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

            var workingDirectory = Directory.GetCurrentDirectory();

            var surfacePtr = IMG_Load(Path.Combine(workingDirectory, "Assets", "graphics", "items", "1.png"));
            var surface = surfacePtr.AsStruct<SDL_Surface>();

            var image = SDL_CreateTextureFromSurface(renderer, surfacePtr);

            var isRunning = true;
            while (isRunning) {
                while (SDL_PollEvent(out var e) != 0) {
                    switch (e.type) {
                        case SDL_EventType.SDL_QUIT:
                            isRunning = false;
                            break;
                    }
                }

                SDL_SetRenderDrawColor(renderer, 0, 0, 0, 0);
                SDL_RenderClear(renderer);

                var rectangle = new SDL_Rect()
                {
                    x = 10,
                    y = 10,
                    w = 100,
                    h = 100
                };

                SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);
                SDL_RenderFillRect(renderer, ref rectangle);

                var srcRect = new SDL_Rect()
                {
                    x = 0,
                    y = 0,
                    w = surface.w,
                    h = surface.h
                };

                var dstRect = new SDL_Rect()
                {
                    x = 200,
                    y = 200,
                    w = surface.w,
                    h = surface.h
                };

                SDL_RenderCopy(renderer, image, ref srcRect, ref dstRect);

                SDL_RenderPresent(renderer);
            }

            IMG_Quit();
            SDL_Quit();
        }
    }
}
