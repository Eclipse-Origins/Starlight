using Starlight.Packets;
using Starlight.Server.Handlers.Core;
using Starlight.Server.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Handlers
{
    public class RegisterPacketHandler : AbstractPacketHandler<RegisterPacket>
    {
        public override void HandlePacket(RequestContext requestContext, RegisterPacket packet) {
            requestContext.Server.SendPacket(requestContext.ConnectionId, new RegistrationResultPacket(true));
        }
    }
}
