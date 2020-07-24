using SDL2;
using Starlight.Client.Rendering;
using System;
using System.IO;

using static SDL2.SDL;
using static SDL2.SDL_image;

namespace Starlight.Client
{
    class Program
    {

        static void Main(string[] args) {
            var workingDirectory = Directory.GetCurrentDirectory();

            var game = new StarlightGame(workingDirectory);

            game.Connect();

            game.Run();
        }
    }
}
