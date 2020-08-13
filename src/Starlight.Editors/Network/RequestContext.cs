using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Editors.Network
{
    public class RequestContext : IDisposable
    {
        public int ConnectionId { get; }
        public StarlightClient NetworkClient { get; }
        public FormContainer FormContainer { get; }

        public RequestContext(int connectionId, StarlightClient networkClient, FormContainer formContainer) {
            this.ConnectionId = connectionId;
            this.NetworkClient = networkClient;
            this.FormContainer = formContainer;
        }

        public void Dispose() {
        }
    }
}
