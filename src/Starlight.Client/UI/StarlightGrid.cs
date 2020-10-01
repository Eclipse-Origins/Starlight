using Myra.Graphics2D.UI;

namespace Starlight.Client.UI
{
    public class StarlightGrid : Grid
    {
        public StarlightGrid()
        {
            this.ShowGridLines = Debugging.UIDebugging;
        }
    }
}
