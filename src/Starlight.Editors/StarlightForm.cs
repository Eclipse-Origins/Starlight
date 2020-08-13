using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Editors
{
    public class StarlightForm : DarkForm
    {
        public StarlightContext Context { get; }

        public StarlightForm() {
        }

        public StarlightForm(StarlightContext context) {
            this.Context = context;
        }
    }
}
