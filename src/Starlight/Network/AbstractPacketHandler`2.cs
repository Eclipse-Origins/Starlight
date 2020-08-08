using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Network
{
    public abstract class AbstractPacketHandler<TRequestContext, TPacket> : IPacketHandler<TRequestContext, TPacket>
    {
        public void HandleGenericPacket(TRequestContext requestContext, object packet) {
            this.HandlePacket(requestContext, (TPacket)packet);
        }

        public abstract void HandlePacket(TRequestContext requestContext, TPacket packet);
    }
}
