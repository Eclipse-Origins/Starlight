using DarkUI.Forms;
using Starlight.Editors.Handlers.Core;
using Starlight.Editors.Network;
using Starlight.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Editors.Handlers
{
    public class LoginResultPacketHandler : AbstractFormPacketHandler<LoginResultPacket>
    {
        protected override void HandleFormPacket(RequestContext requestContext, LoginResultPacket packet) {
            if (packet.Succeeded) {
                requestContext.FormContainer.ChangeForm<MapEditorForm>();
            } else {
                DarkMessageBox.ShowInformation("Invalid login.", packet.Message);
            }
        }
    }
}
