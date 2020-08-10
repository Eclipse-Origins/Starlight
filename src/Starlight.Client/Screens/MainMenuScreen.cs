using Microsoft.Xna.Framework;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using Starlight.Client.Rendering;
using Starlight.Client.Screens.Core;
using Starlight.Client.UI;
using Starlight.Packets;
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
            public TextBox LoginUsernameTextBox { get; set; }
            public TextBox LoginPasswordTextBox { get; set; }
            public TextButton LoginButton { get; set; }

            public Grid RegisterPanel { get; set; }
            public TextBox RegisterUsernameTextBox { get; set; }
            public TextBox RegisterPasswordTextBox { get; set; }
            public TextBox RegisterConfirmPasswordTextBox { get; set; }
            public TextButton RegisterButton { get; set; }
        }

        public MainMenuScreen(ScreenContext screenContext) : base(screenContext) {
        }

        protected override void OnLayout(StarlightGrid rootUI) {
            base.OnLayout(rootUI);

            this.UI.LoginCommandButton.Click += LoginCommandButton_Click;
            this.UI.RegisterCommandButton.Click += RegisterCommandButton_Click;

            this.UI.LoginButton.Click += LoginButton_Click;
            this.UI.RegisterButton.Click += RegisterButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e) {
            var username = UI.LoginUsernameTextBox.Text;
            var password = UI.LoginPasswordTextBox.Text;

            ScreenContext.NetworkClient.SendPacket(new LoginPacket(username, password));
        }

        private void RegisterButton_Click(object sender, EventArgs e) {
            var username = UI.RegisterUsernameTextBox.Text;
            var password = UI.RegisterPasswordTextBox.Text;
            var confirmPassword = UI.RegisterConfirmPasswordTextBox.Text;

            ScreenContext.NetworkClient.SendPacket(new RegisterPacket(username, password));
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

        public void AnnounceRegistration(bool succeeded, string message) {
            this.UI.RegisterUsernameTextBox.Text = string.Empty;
            this.UI.RegisterPasswordTextBox.Text = string.Empty;
            this.UI.RegisterConfirmPasswordTextBox.Text = string.Empty;

            if (succeeded) {
                HidePanels();
                this.UI.LoginPanel.Visible = true;
            }
        }
    }
}
