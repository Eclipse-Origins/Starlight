using Starlight.Editors.Handlers.Core;
using Starlight.Editors.Network;
using Starlight.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Editors.Handlers
{
    public class LoginResultPacketHandler : AbstractPacketHandler<LoginResultPacket>
    {
        public override void HandlePacket(RequestContext requestContext, LoginResultPacket packet) {
        }
    }
}
