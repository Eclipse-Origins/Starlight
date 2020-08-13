using DarkUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Starlight.Editors
{
    public partial class MapEditorForm : StarlightForm
    {
        public MapEditorForm(StarlightContext context) : base(context) {
            InitializeComponent();
        }
    }
}
