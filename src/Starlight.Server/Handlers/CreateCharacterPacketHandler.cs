using Starlight.Packets;
using Starlight.Server.Handlers.Core;
using Starlight.Server.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Handlers
{
    public class CreateCharacterPacketHandler : AbstractPacketHandler<CreateCharacterPacket>
    {
        public override void HandlePacket(RequestContext requestContext, CreateCharacterPacket packet) {
        }
    }
}
