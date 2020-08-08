using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Network
{
    public interface IPacketHandler<TRequestContext>
    {
        void HandleGenericPacket(TRequestContext requestContext, object packet);
    }
}
