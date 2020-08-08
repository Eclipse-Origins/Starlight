using Microsoft.EntityFrameworkCore;
using Starlight.Network;
using Starlight.Server.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Network
{
    public class NetworkDispatch : AbstractNetworkDispatch<RequestContext>
    {
        private readonly Configuration configuration;
        private readonly StarlightServer server;

        public NetworkDispatch(Configuration configuration, StarlightServer server) : base(typeof(NetworkDispatch).Assembly) {
            this.configuration = configuration;
            this.server = server;
        }

        protected override RequestContext BuildRequestContext(int connectionId) {
            return new RequestContext(connectionId, configuration, server);
        }
    }
}
