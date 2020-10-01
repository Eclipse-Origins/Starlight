using Myra.Graphics2D.UI;
using Starlight.Client.Screens.Core;
using Starlight.Client.UI;
using Starlight.Models;
using Starlight.Packets;
using System;
using System.Linq;

namespace Starlight.Client.Screens
{
    public class CharacterSelectScreen : AbstractScreen<CharacterSelectScreen.Controls>
    {
        public class Controls
        {

            public Grid EmptySlotPanel { get; set; }
            public TextButton NewCharacterButton { get; set; }

            public Grid CharacterDetailsPanel { get; set; }
            public Label UsernameLabel { get; set; }
            public TextButton DeleteCharacterButton { get; set; }
            public TextButton UseCharacterButton { get; set; }
        }

        int slot;
        MenuCharacterDetails[] characterDetails;

        public CharacterSelectScreen(ScreenContext screenContext) : base(screenContext)
        {
        }

        protected override void OnLayout(StarlightGrid rootUI)
        {
            UI.NewCharacterButton.Click += NewCharacterButton_Click;

            UI.DeleteCharacterButton.Click += DeleteCharacterButton_Click;
        }

        private void DeleteCharacterButton_Click(object sender, EventArgs e)
        {
            Context.NetworkClient.SendPacket(new DeleteCharacterPacket(slot));
        }

        private void NewCharacterButton_Click(object sender, EventArgs e)
        {
            var screen = Context.ScreenContainer.PushScreen<CharacterCreationScreen>();

            screen.SetSlot(slot);
        }

        private void HideAllPanels()
        {
            UI.EmptySlotPanel.Visible = false;
            UI.CharacterDetailsPanel.Visible = false;
        }

        public void SetCharacterDetails(MenuCharacterDetails[] characterDetails)
        {
            this.characterDetails = characterDetails;

            SetCharacterSlot(0);
        }

        private void SetCharacterSlot(int slot)
        {
            this.slot = slot;

            var character = characterDetails.Where(x => x.Slot == slot).FirstOrDefault();
            if (character == null)
            {
                SetEmptySlot();
            }
            else
            {
                SetCharacterDetails(character);
            }
        }

        private void SetEmptySlot()
        {
            HideAllPanels();
            UI.EmptySlotPanel.Visible = true;
        }

        private void SetCharacterDetails(MenuCharacterDetails menuCharacterDetails)
        {
            HideAllPanels();
            UI.CharacterDetailsPanel.Visible = true;

            UI.UsernameLabel.Text = menuCharacterDetails.Name;
        }
    }
}
