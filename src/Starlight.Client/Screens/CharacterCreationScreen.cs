using Myra.Graphics2D.UI;
using Starlight.Client.Screens.Core;
using Starlight.Client.UI;
using Starlight.Packets;
using System;

namespace Starlight.Client.Screens
{
    public class CharacterCreationScreen : AbstractScreen<CharacterCreationScreen.Controls>
    {
        public class Controls
        {
            public TextBox CharacterNameTextBox { get; set; }

            public TextButton CancelButton { get; set; }
            public TextButton CreateCharacterButton { get; set; }
        }

        int slot;

        public CharacterCreationScreen(ScreenContext screenContext) : base(screenContext)
        {
        }

        protected override void OnLayout(StarlightGrid rootUI)
        {
            UI.CancelButton.Click += CancelButton_Click;
            UI.CreateCharacterButton.Click += CreateCharacterButton_Click;
        }

        public void SetSlot(int slot)
        {
            this.slot = slot;
        }

        private void CreateCharacterButton_Click(object sender, EventArgs e)
        {
            var name = UI.CharacterNameTextBox.Text;

            Context.NetworkClient.SendPacket(new CreateCharacterPacket(slot, name));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Context.ScreenContainer.PopScreen();
        }
    }
}
