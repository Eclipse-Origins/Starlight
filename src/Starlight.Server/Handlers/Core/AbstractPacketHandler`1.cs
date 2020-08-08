using Starlight.Network;
using Starlight.Server.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Handlers.Core
{
    public abstract class AbstractPacketHandler<TPacket> : AbstractPacketHandler<RequestContext, TPacket>
    {
    }
}
