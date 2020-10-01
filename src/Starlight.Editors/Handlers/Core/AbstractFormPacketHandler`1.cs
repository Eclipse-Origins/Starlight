using Starlight.Editors.Network;
using System;

namespace Starlight.Editors.Handlers.Core
{
    public abstract class AbstractFormPacketHandler<TPacket> : AbstractPacketHandler<TPacket>
    {
        public override void HandlePacket(RequestContext requestContext, TPacket packet)
        {
            if (requestContext.FormContainer.PrimaryForm.InvokeRequired)
            {
                requestContext.FormContainer.PrimaryForm.Invoke(new Action<RequestContext, TPacket>(HandlePacket), requestContext, packet);
                return;
            }

            HandleFormPacket(requestContext, packet);
        }

        protected abstract void HandleFormPacket(RequestContext requestContext, TPacket packet);
    }
}
