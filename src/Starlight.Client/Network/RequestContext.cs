using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Network
{
    public class RequestContext : IDisposable
    {
        public int ConnectionId { get; }
        public StarlightClient NetworkClient { get; }

        public RequestContext(int connectionId, StarlightClient networkClient) {
            this.ConnectionId = connectionId;
            this.NetworkClient = networkClient;
        }

        public void Dispose() {
        }
    }
}
