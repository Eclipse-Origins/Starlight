using Serilog;
using Starlight.Client.Rendering;
using System;
using System.IO;
using System.CommandLine.DragonFruit;
using Microsoft.Xna.Framework;

namespace Starlight.Client
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="debug">To turn debugging on or off</param>
        /// <param name="server">IP address of server</param>
        /// <param name="port">Portnumber of server</param>
        /// <param name="language">Language being used</param>
        static void Main(bool debug = false, string server = null, int port = 1338, string language = "en-us") {
#if DEBUG
            debug = true;
            server = "localhost";
#endif
            if (debug) {
                Log.Logger = (ILogger)new LoggerConfiguration()
                .WriteTo.File("client.log")
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();
                Debugging.UIDebugging = true;
            }
            var workingDirectory = Directory.GetCurrentDirectory();

            using (var game = new StarlightGame(workingDirectory)) {
                game.Language = language;
                game.Connect(server, port);
                game.Run();
            }
        }
    }
}
