using Microsoft.EntityFrameworkCore;
using Starlight.Packets;
using Starlight.Server.Handlers.Core;
using Starlight.Server.Network;
using Starlight.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starlight.Server.Handlers
{
    public class UseCharacterPacketHandler : AbstractPacketHandler<UseCharacterPacket>
    {
        public override void HandlePacket(RequestContext requestContext, UseCharacterPacket packet) {
            var user = requestContext.DbContext.Users.Include(x => x.Characters)
                                               .Where(x => x.Id == requestContext.User.Id)
                                               .FirstOrDefault();
            if (user == null) {
                requestContext.Server.SendPacket(requestContext.ConnectionId, new DeleteCharacterResultPacket(false, TranslationManager.Instance.Translate("UseCharacter.AccountNotFound")));
                return;
            }

            var character = user.Characters.Where(x => x.Slot == packet.Slot).FirstOrDefault();
            if (character == null) {
                requestContext.Server.SendPacket(requestContext.ConnectionId, new DeleteCharacterResultPacket(false, TranslationManager.Instance.Translate("UseCharacter.SlotEmpty")));
                return;
            }

            requestContext.Server.SendPacket(requestContext.ConnectionId, new CharacterSelectedPacket(character));
        }
    }
}
