using Starlight.Client.Network;
using Starlight.Network;

namespace Starlight.Client.Handlers.Core
{
    public abstract class AbstractPacketHandler<TPacket> : AbstractPacketHandler<RequestContext, TPacket>
    {
    }
}
