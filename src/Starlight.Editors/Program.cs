using System;
using System.IO;
using System.Windows.Forms;

namespace Starlight.Editors
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
