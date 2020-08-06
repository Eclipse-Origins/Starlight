using Starlight.Client.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public class ScreenContext
    {
        public StarlightGame Game { get; }
        public ResourceLocator ResourceLocator { get; }

        public ScreenContext(StarlightGame game, ResourceLocator resourceLocator) {
            this.Game = game;
            this.ResourceLocator = resourceLocator;
        }

        public void ChangeScreen<TScreen>() where TScreen : IScreen {
            Game.ChangeScreen<TScreen>();
        }
    }
}
