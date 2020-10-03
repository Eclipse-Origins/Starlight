using Starlight.Client.Handlers.Core;
using Starlight.Client.Network;
using Starlight.Client.Screens;
using Starlight.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Handlers
{
    public class CharacterSelectedPacketHandler : AbstractPacketHandler<CharacterSelectedPacket>
    {
        public override void HandlePacket(RequestContext requestContext, CharacterSelectedPacket packet) {
            requestContext.ScreenContainer.ChangeScreen<GameScreen>();
        }
    }
}
