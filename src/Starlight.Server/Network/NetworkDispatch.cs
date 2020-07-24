using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Network
{
    public class NetworkDispatch
    {
        private readonly Configuration configuration;

        public NetworkDispatch(Configuration configuration) {
            this.configuration = configuration;
        }

        private RequestContext BuildRequestContext() {
            return new RequestContext(configuration);
        }

        public void HandleData(int connectionId, byte[] data) {
            using (var requestContext = BuildRequestContext()) {

            }
        }
    }
}
