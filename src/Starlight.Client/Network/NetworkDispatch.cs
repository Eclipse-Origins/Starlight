using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Network
{
    public class NetworkDispatch : AbstractNetworkDispatch<RequestContext>
    {
        private readonly StarlightClient networkClient;

        public NetworkDispatch(StarlightClient networkClient) : base(typeof(NetworkDispatch).Assembly) {
            this.networkClient = networkClient;
        }

        protected override RequestContext BuildRequestContext(int connectionId) {
            return new RequestContext(connectionId, networkClient);
        }
    }
}
