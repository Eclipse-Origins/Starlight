using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Network
{
    public interface IPacketHandler<TRequestContext, TPacket> : IPacketHandler<TRequestContext>
    {
        void HandlePacket(TRequestContext requestContext, TPacket packet);
    }
}
