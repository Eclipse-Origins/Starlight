using Starlight.Network;
using Starlight.Server.Network;
using Starlight.Translations;
using System;
using System.IO;
using System.Threading;

namespace Starlight.Server
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Starlight Server");
#if DEBUG
            //hardcoded debug variables
            var configPath = "config.development.json";
#else
            if (args.Length == 0)
            {
                Console.WriteLine("No configuration file found!");
                return 2;
            }
            var configPath = args[0];
#endif

            var configuration = LoadConfiguration(configPath);

            TranslationManager.Instance.ImportFromDocument(Path.Combine(Directory.GetCurrentDirectory(), "Content", "Languages", "en-us.json"));

            // create and start the server
            var server = new StarlightServer(new Telepathy.Server());
            server.Server.Start(configuration.Port);

            var networkDispatch = new NetworkDispatch(configuration, server);
            networkDispatch.ResolveHandlers();

            var isRunning = true;
            while (isRunning)
            {
                while (server.Server.GetNextMessage(out var msg))
                {
                    var logstamp = DateTime.Now.ToString() + " [" + msg.connectionId + "] ";
                    switch (msg.eventType)
                    {
                        case Telepathy.EventType.Connected:
                            Console.WriteLine(logstamp + "New connection from " + server.Server.GetClientAddress(msg.connectionId));
                            break;
                        case Telepathy.EventType.Data:
                            networkDispatch.HandleData(msg.connectionId, msg.data);
                            break;
                        case Telepathy.EventType.Disconnected:
                            Console.WriteLine(logstamp + " Disconnected");
                            break;
                    }
                }

                Thread.Sleep(1);
            }
            return 0;
        }

        private static Configuration LoadConfiguration(String configPath)
        {
            return Configuration.Read(configPath);
        }

    }
}
