using Starlight.Editors.Network;
using Starlight.Network;

namespace Starlight.Editors.Handlers.Core
{
    public abstract class AbstractPacketHandler<TPacket> : AbstractPacketHandler<RequestContext, TPacket>
    {
    }
}
