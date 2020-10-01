using Starlight.Client.Handlers.Core;
using Starlight.Client.Network;
using Starlight.Client.Screens;
using Starlight.Packets;

namespace Starlight.Client.Handlers
{
    public class MenuCharacterDetailsPacketHandler : AbstractPacketHandler<MenuCharacterDetailsPacket>
    {
        public override void HandlePacket(RequestContext requestContext, MenuCharacterDetailsPacket packet)
        {
            if (requestContext.ScreenContainer.Screen is CharacterSelectScreen characterSelectScreen)
            {
                characterSelectScreen.SetCharacterDetails(packet.Characters);
            }
        }
    }
}
