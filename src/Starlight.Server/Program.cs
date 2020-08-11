using Starlight.Network;
using Starlight.Server.Network;
using Starlight.Translations;
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

            TranslationManager.Instance.ImportFromDocument(Path.Combine(Directory.GetCurrentDirectory(), "Content", "Languages", "en-us.json"));

            // create and start the server
            var server = new StarlightServer(new Telepathy.Server());
            server.Server.Start(configuration.Port);

            var networkDispatch = new NetworkDispatch(configuration, server);
            networkDispatch.ResolveHandlers();

            var isRunning = true;
            while (isRunning) {
                while (server.Server.GetNextMessage(out var msg)) {
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
