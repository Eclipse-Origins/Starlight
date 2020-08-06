using Microsoft.Xna.Framework;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using Starlight.Client.Rendering;
using Starlight.Client.UI;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Starlight.Client.Screens
{
    public class MainMenuScreen : AbstractScreen<MainMenuScreen.Controls>
    {
        public class Controls
        {
            public TextButton LoginCommandButton { get; set; }
            public TextButton RegisterCommandButton { get; set; }

            public Grid LoginPanel { get; set; }
            public Grid RegisterPanel { get; set; }
        }

        public MainMenuScreen(ScreenContext screenContext) : base(screenContext) {
        }

        protected override void OnLayout(StarlightGrid rootUI) {
            base.OnLayout(rootUI);

            this.UI.LoginCommandButton.Click += LoginCommandButton_Click;
            this.UI.RegisterCommandButton.Click += RegisterCommandButton_Click;
        }

        private void RegisterCommandButton_Click(object sender, EventArgs e) {
            HidePanels();
            this.UI.RegisterPanel.Visible = true;
        }

        private void LoginCommandButton_Click(object sender, EventArgs e) {
            HidePanels();
            this.UI.LoginPanel.Visible = true;
        }

        private void HidePanels() {
            this.UI.LoginPanel.Visible = false;
            this.UI.RegisterPanel.Visible = false;
        }
    }
}
