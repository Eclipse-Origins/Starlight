using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CommandLine.DragonFruit;

namespace Starlight.Editors
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// <param name="debug">To turn debugging on or off</param>
        /// <param name="server">IP address of server</param>
        /// <param name="port">Portnumber of server</param>
        /// <param name="language">Language being used</param>
        [STAThread]
        static void Main(bool debug = false, string server = null, int port = 1338, string language = "en-us") {
#if DEBUG
            debug = true;
            server = "localhost";
#endif
            if (debug) {
                Log.Logger = (ILogger)new LoggerConfiguration()
                .WriteTo.File("editors.log")
                .CreateLogger();
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var starlightContext = new StarlightContext(Directory.GetCurrentDirectory());

            starlightContext.LoadContent(language);
            starlightContext.Connect(server,port);

            starlightContext.FormContainer.ChangeForm<LoginForm>();

            Application.Run();
        }
    }
}
