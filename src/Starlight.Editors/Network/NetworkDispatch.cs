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

        public NetworkDispatch(StarlightClient starlightClient) : base(typeof(NetworkDispatch).Assembly) {
            this.starlightClient = starlightClient;

            Task.Run(ProcessNetworkMessages);
        }

        protected override RequestContext BuildRequestContext(int connectionId) {
            return new RequestContext(connectionId, starlightClient);
        }

        public void ProcessNetworkMessages() {
            while (true) {
                while (starlightClient.Client.GetNextMessage(out var networkMessage)) {
                    switch (networkMessage.eventType) {
                        case Telepathy.EventType.Connected:
                            Console.WriteLine("Connected");
                            break;
                        case Telepathy.EventType.Data:
                            this.HandleData(networkMessage.connectionId, networkMessage.data);
                            break;
                        case Telepathy.EventType.Disconnected:
                            Console.WriteLine("Disconnected");
                            break;
                    }
                }

                Thread.Sleep(1);
            }
        }
    }
}
