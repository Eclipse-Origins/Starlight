using Starlight.Client.Resources;
using Starlight.Network;

namespace Starlight.Client.Screens.Core
{
    public class ScreenContext
    {
        public ScreenContainer ScreenContainer { get; }
        public ResourceLocator ResourceLocator { get; }
        public StarlightClient NetworkClient { get; }

        public ScreenContext(ScreenContainer screenContainer, ResourceLocator resourceLocator, StarlightClient networkClient)
        {
            this.ScreenContainer = screenContainer;
            this.ResourceLocator = resourceLocator;
            this.NetworkClient = networkClient;
        }
    }
}
