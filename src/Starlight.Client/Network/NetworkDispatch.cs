using Starlight.Client.Screens.Core;
using Starlight.Network;

namespace Starlight.Client.Network
{
    public class NetworkDispatch : AbstractNetworkDispatch<RequestContext>
    {
        private readonly StarlightClient networkClient;
        private readonly ScreenContainer screenContainer;

        public NetworkDispatch(StarlightClient networkClient, ScreenContainer screenContainer) : base(typeof(NetworkDispatch).Assembly)
        {
            this.networkClient = networkClient;
            this.screenContainer = screenContainer;
        }

        protected override RequestContext BuildRequestContext(int connectionId)
        {
            return new RequestContext(connectionId, networkClient, screenContainer);
        }
    }
}
