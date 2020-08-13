using DarkUI.Forms;
using Starlight.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Starlight.Editors
{
    public partial class LoginForm : StarlightForm
    {
        public LoginForm(StarlightContext starlightContext) : base(starlightContext) {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e) {
            Context.NetworkClient.SendPacket(new LoginPacket(ClientType.Editor, usernameTextBox.Text, passwordTextBox.Text));
        }
    }
}
