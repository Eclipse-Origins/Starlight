using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Network
{
    public class NetworkDispatch : AbstractNetworkDispatch<RequestContext>
    {
        protected override RequestContext BuildRequestContext() {
            return new RequestContext();
        }
    }
}
