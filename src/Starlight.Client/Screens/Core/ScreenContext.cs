using Starlight.Client.Resources;
using Starlight.Client.Screens.Core;
using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens.Core
{
    public class ScreenContext
    {
        public StarlightGame Game { get; }
        public ScreenContainer ScreenContainer { get; }
        public ResourceLocator ResourceLocator { get; }
        public ResourceCache ResourceCache { get; }
        public StarlightClient NetworkClient { get; }

        public ScreenContext(StarlightGame game, ScreenContainer screenContainer,ResourceCache resourceCache, ResourceLocator resourceLocator, StarlightClient networkClient) {
            this.Game = game;
            this.ScreenContainer = screenContainer;
            this.ResourceCache = resourceCache;
            this.ResourceLocator = resourceLocator;
            this.NetworkClient = networkClient;
        }
    }
}
