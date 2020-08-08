using Starlight.Client.Resources;
using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public class ScreenContext
    {
        public StarlightGame Game { get; }
        public ResourceLocator ResourceLocator { get; }
        public StarlightClient NetworkClient { get; }

        public ScreenContext(StarlightGame game, ResourceLocator resourceLocator, StarlightClient networkClient) {
            this.Game = game;
            this.ResourceLocator = resourceLocator;
            this.NetworkClient = networkClient;
        }

        public void ChangeScreen<TScreen>() where TScreen : IScreen {
            Game.ChangeScreen<TScreen>();
        }


    }
}
