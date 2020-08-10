using Starlight.Client.Handlers.Core;
using Starlight.Client.Network;
using Starlight.Client.Screens;
using Starlight.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Client.Handlers
{
    public class LoginResultPacketHandler : AbstractPacketHandler<LoginResultPacket>
    {
        public override void HandlePacket(RequestContext requestContext, LoginResultPacket packet) {
            if (packet.Succeeded) {
                requestContext.ScreenContainer.ChangeScreen<CharacterSelectScreen>();
            }
        }
    }
}
