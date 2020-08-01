using Starlight.Client.Rendering;
using System;
using System.IO;

namespace Starlight.Client
{
    class Program
    {

        static void Main(string[] args) {
            var workingDirectory = Directory.GetCurrentDirectory();

            using (var game = new StarlightGame(workingDirectory)) {
                game.Connect();

                game.Run();
            }
        }
    }
}
