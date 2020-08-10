using Starlight.Client.Resources;
using Starlight.Client.Screens.Core;
using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Screens
{
    public class ScreenContext
    {
        public ScreenContainer ScreenContainer { get; }
        public ResourceLocator ResourceLocator { get; }
        public StarlightClient NetworkClient { get; }

        public ScreenContext(ScreenContainer screenContainer, ResourceLocator resourceLocator, StarlightClient networkClient) {
            this.ScreenContainer = screenContainer;
            this.ResourceLocator = resourceLocator;
            this.NetworkClient = networkClient;
        }
    }
}
