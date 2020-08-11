using Myra.Graphics2D.UI;
using Starlight.Client.Screens.Core;
using Starlight.Client.UI;
using Starlight.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public class CharacterSelectScreen : AbstractScreen<CharacterSelectScreen.Controls>
    {
        public class Controls
        {
            public Label UsernameLabel { get; set; }

            public Grid EmptySlotPanel { get; set; }
            public TextButton NewCharacterButton { get; set; }

            public Grid CharacterDetailsPanel { get; set; }
        }

        int slot;
        MenuCharacterDetails[] characterDetails;

        public CharacterSelectScreen(ScreenContext screenContext) : base(screenContext) {
        }

        protected override void OnLayout(StarlightGrid rootUI) {
            UI.NewCharacterButton.Click += NewCharacterButton_Click;
        }

        private void NewCharacterButton_Click(object sender, EventArgs e) {
            var screen = Context.ScreenContainer.PushScreen<CharacterCreationScreen>();

            screen.SetSlot(slot);
        }

        private void HideAllPanels() {
            UI.EmptySlotPanel.Visible = false;
            UI.CharacterDetailsPanel.Visible = false;
        }

        public void SetCharacterDetails(MenuCharacterDetails[] characterDetails) {
            this.characterDetails = characterDetails;

            SetCharacterSlot(0);
        }

        private void SetCharacterSlot(int slot) {
            if (characterDetails.Length <= slot) {
                SetEmptySlot(slot);
            }
        }

        private void SetEmptySlot(int slot) {
            this.slot = slot;

            HideAllPanels();
            UI.EmptySlotPanel.Visible = true;
        }
    }
}
