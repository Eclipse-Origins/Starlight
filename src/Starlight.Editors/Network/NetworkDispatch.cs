using Serilog;
using Starlight.Network;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Starlight.Editors.Network
{
    public class NetworkDispatch : AbstractNetworkDispatch<RequestContext>
    {
        private readonly StarlightClient starlightClient;
        private readonly FormContainer formContainer;

        public NetworkDispatch(StarlightClient starlightClient, FormContainer formContainer) : base(typeof(NetworkDispatch).Assembly) {
            this.starlightClient = starlightClient;
            this.formContainer = formContainer;

            Task.Run(ProcessNetworkMessages);
        }

        protected override RequestContext BuildRequestContext(int connectionId) {
            return new RequestContext(connectionId, starlightClient, formContainer);
        }

        public void ProcessNetworkMessages() {
            while (true) {
                while (starlightClient.Client.GetNextMessage(out var networkMessage)) {
                    switch (networkMessage.eventType) {
                        case Telepathy.EventType.Connected:
                            Log.Debug("Connected");
                            break;
                        case Telepathy.EventType.Data:
                            this.HandleData(networkMessage.connectionId, networkMessage.data);
                            break;
                        case Telepathy.EventType.Disconnected:
                            Log.Debug("Disconnected");
                            break;
                    }
                }

                Thread.Sleep(1);
            }
        }
    }
}
