using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Network
{
    public abstract class AbstractNetworkDispatch<TRequestContext> where TRequestContext : IDisposable
    {
        protected abstract TRequestContext BuildRequestContext();

        public void HandleData(int connectionId, byte[] data) {
            using (var requestContext = BuildRequestContext()) {

            }
        }
    }
}
