using Starlight.Packets;
using System;

namespace Starlight.Editors
{
    public partial class LoginForm : StarlightForm
    {
        public LoginForm(StarlightContext starlightContext) : base(starlightContext)
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Context.NetworkClient.SendPacket(new LoginPacket(ClientType.Editor, usernameTextBox.Text, passwordTextBox.Text));
        }
    }
}
