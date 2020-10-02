using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starlight.Editors
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Log.Logger = (ILogger)new LoggerConfiguration()
                .WriteTo.File("editors.log")
#if DEBUG
                .WriteTo.Debug()
                .MinimumLevel.Debug()
#endif
                .CreateLogger();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var starlightContext = new StarlightContext(Directory.GetCurrentDirectory());

            starlightContext.LoadContent();
            starlightContext.Connect();

            starlightContext.FormContainer.ChangeForm<LoginForm>();

            Application.Run();
        }
    }
}
