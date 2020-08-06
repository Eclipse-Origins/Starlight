using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.UI
{
    public class StarlightGrid : Grid
    {
        public StarlightGrid() {
            this.ShowGridLines = Debugging.UIDebugging;
        }
    }
}
