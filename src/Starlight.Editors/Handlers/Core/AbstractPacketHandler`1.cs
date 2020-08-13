using Starlight.Editors.Network;
using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Editors.Handlers.Core
{
    public abstract class AbstractPacketHandler<TPacket> : AbstractPacketHandler<RequestContext, TPacket>
    {
    }
}
