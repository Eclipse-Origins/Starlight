using Microsoft.EntityFrameworkCore;
using Starlight.Models;
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
    public class DeleteCharacterPacketHandler : AbstractPacketHandler<DeleteCharacterPacket>
    {
        public override void HandlePacket(RequestContext requestContext, DeleteCharacterPacket packet) {
            var user = requestContext.DbContext.Users.Include(x => x.Characters)
                                                     .Where(x => x.Id == requestContext.User.Id)
                                                     .FirstOrDefault();
            if (user == null) {
                requestContext.Server.SendPacket(requestContext.ConnectionId, new DeleteCharacterResultPacket(false, TranslationManager.Instance.Translate("DeleteCharacter.AccountNotFound")));
                return;
            }

            var character = user.Characters.Where(x => x.Slot == packet.Slot).FirstOrDefault();
            if (character == null) {
                requestContext.Server.SendPacket(requestContext.ConnectionId, new DeleteCharacterResultPacket(false, TranslationManager.Instance.Translate("DeleteCharacter.SlotEmpty")));
                return;
            }

            user.Characters.Remove(character);

            requestContext.DbContext.Users.Update(user);

            var characters = user.Characters.Select(x => new MenuCharacterDetails()
            {
                Id = x.Id,
                Slot = x.Slot, 
                Name = x.Name
            }).ToArray();

            requestContext.Server.SendPacket(requestContext.ConnectionId, new LoginResultPacket(true, string.Empty));
            requestContext.Server.SendPacket(requestContext.ConnectionId, new MenuCharacterDetailsPacket(characters));
        }
    }
}
