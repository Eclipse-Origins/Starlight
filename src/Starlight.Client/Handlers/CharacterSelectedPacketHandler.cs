using Starlight.Client.Handlers.Core;
using Starlight.Client.Network;
using Starlight.Client.Screens;
using Starlight.Client.State;
using Starlight.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Handlers
{
    public class CharacterSelectedPacketHandler : AbstractPacketHandler<CharacterSelectedPacket>
    {
        public override void HandlePacket(RequestContext requestContext, CharacterSelectedPacket packet) {
            Player.Instance.Character = packet.Character;

            requestContext.ScreenContainer.ChangeScreen<GameScreen>();
        }
    }
}
