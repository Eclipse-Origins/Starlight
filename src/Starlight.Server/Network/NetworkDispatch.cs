using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Network
{
    public class NetworkDispatch : AbstractNetworkDispatch<RequestContext>
    {
        private readonly Configuration configuration;

        public NetworkDispatch(Configuration configuration) {
            this.configuration = configuration;
        }

        protected override RequestContext BuildRequestContext() {
            return new RequestContext(configuration);
        }
    }
}
