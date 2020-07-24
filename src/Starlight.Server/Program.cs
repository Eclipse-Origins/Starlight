using Starlight.Server.Network;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Starlight.Server
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Starlight Server");

            var configuration = LoadConfiguration();

            var networkDispatch = new NetworkDispatch(configuration);

            // create and start the server
            Telepathy.Server server = new Telepathy.Server();
            server.Start(configuration.Port);

            var isRunning = true;
            while (isRunning) {

                // Update loop
                Telepathy.Message msg;
                while (server.GetNextMessage(out msg)) {
                    switch (msg.eventType) {
                        case Telepathy.EventType.Connected:
                            Console.WriteLine(msg.connectionId + " Connected");
                            break;
                        case Telepathy.EventType.Data:
                            networkDispatch.HandleData(msg.connectionId, msg.data);
                            break;
                        case Telepathy.EventType.Disconnected:
                            Console.WriteLine(msg.connectionId + " Disconnected");
                            break;
                    }
                }

            }
        }

        private static Configuration LoadConfiguration() {
#if DEBUG
            var configPath = "config.development.json";
#endif

            return Configuration.Read(configPath);
        }

    }
}
