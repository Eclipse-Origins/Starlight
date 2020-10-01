using Starlight.Network;
using Starlight.Server.Network;

namespace Starlight.Server.Handlers.Core
{
    public abstract class AbstractPacketHandler<TPacket> : AbstractPacketHandler<RequestContext, TPacket>
    {
    }
}
