using Starlight.Client.Screens.Core;
using Starlight.Network;
using System;

namespace Starlight.Client.Network
{
    public class RequestContext : IDisposable
    {
        public int ConnectionId { get; }
        public StarlightClient NetworkClient { get; }
        public ScreenContainer ScreenContainer { get; }

        public RequestContext(int connectionId, StarlightClient networkClient, ScreenContainer screenContainer)
        {
            this.ConnectionId = connectionId;
            this.NetworkClient = networkClient;
            this.ScreenContainer = screenContainer;
        }

        public void Dispose()
        {
        }
    }
}
