using SDL2;
using System;

using static SDL2.SDL;

namespace Starlight.Client
{
    class Program
    {
        static void Main(string[] args) {
            if (SDL_Init(SDL_INIT_VIDEO) < 0) {
                throw new Exception($"SDL could not initialize! SDL_Error: {SDL_GetError()}");
            }

            var window = SDL_CreateWindow("Test", SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, 1024, 768, SDL_WindowFlags.SDL_WINDOW_SHOWN);
            if (window == IntPtr.Zero) {
                throw new Exception($"Window could not be created! SDL_Error: {SDL_GetError()}");
            }

            var renderer = SDL_CreateRenderer(window, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

            while (true) {
                while (SDL_PollEvent(out var e) != 0) {
                    switch (e.type) {
                        case SDL_EventType.SDL_QUIT:
                            Environment.Exit(0);
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

                SDL_RenderPresent(renderer);
            }
        }
    }
}
