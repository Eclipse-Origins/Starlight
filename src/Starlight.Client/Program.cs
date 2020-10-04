using Serilog;
using Starlight.Client.Rendering;
using System;
using System.IO;

namespace Starlight.Client
{
    class Program
    {

        static void Main(string[] args) {
            Log.Logger = (ILogger)new LoggerConfiguration()
            .WriteTo.File("client.log")
#if DEBUG
            .WriteTo.Console()
            .MinimumLevel.Debug()
#endif
            .CreateLogger();
            var workingDirectory = Directory.GetCurrentDirectory();

            using (var game = new StarlightGame(workingDirectory)) {
                game.Connect();

                game.Run();
            }
        }
    }
}
