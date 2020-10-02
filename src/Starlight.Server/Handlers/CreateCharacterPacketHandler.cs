using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Serilog;
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
    public class CreateCharacterPacketHandler : AbstractPacketHandler<CreateCharacterPacket>
    {
        public override void HandlePacket(RequestContext requestContext, CreateCharacterPacket packet) {
            var user = requestContext.DbContext.Users.Include(x => x.Characters)
                                                     .Where(x => x.Id == requestContext.User.Id)
                                                     .FirstOrDefault();
            Log.Information("[" + requestContext.ConnectionId + "] Creating character " + packet.Name);

            if (user == null) {
                Log.Error("[" + requestContext.ConnectionId + "] " + TranslationManager.Instance.Translate("CreateCharacter.AccountNotFound"));
                requestContext.Server.SendPacket(requestContext.ConnectionId, new CreateCharacterResultPacket(false, TranslationManager.Instance.Translate("CreateCharacter.AccountNotFound")));
                return;
            }

            if (user.Characters.Where(x => x.Slot == packet.Slot).Any()) {
                Log.Error("[" + requestContext.ConnectionId + "] " + TranslationManager.Instance.Translate("CreateCharacter.SlotNotEmpty"));
                requestContext.Server.SendPacket(requestContext.ConnectionId, new CreateCharacterResultPacket(false, TranslationManager.Instance.Translate("CreateCharacter.SlotNotEmpty")));
                return;
            }

            // TODO: Whitelist allowed characters

            if (requestContext.DbContext.Characters.Where(x => x.Name.ToLower() == packet.Name.ToLower()).Any()) {
                Log.Error("[" + requestContext.ConnectionId + "] " + TranslationManager.Instance.Translate("CreateCharacter.CharacterNameTaken"));
                requestContext.Server.SendPacket(requestContext.ConnectionId, new CreateCharacterResultPacket(false, TranslationManager.Instance.Translate("CreateCharacter.CharacterNameTaken")));
                return;
            }

            var character = new Character()
            {
                Slot = packet.Slot,
                Name = packet.Name
            };
            
            user.Characters.Add(character);

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
