using Starlight.Network;
using Starlight.Server.Network;
using Starlight.Translations;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using System.Reflection;

namespace Starlight.Server
{
    class Program
    {
        static void Main(string[] args) {
            try {
                var configuration = LoadConfiguration();
                if (configuration.LogFile == null) {
                    configuration.LogFile = "server.log";
                };
                Log.Logger = (ILogger)new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(path: configuration.LogFile, rollingInterval: RollingInterval.Day)
#if DEBUG
                .MinimumLevel.Debug()
#endif
                .CreateLogger();
                if (configuration.ConnectionString == null || configuration.Port == 0) {
                    throw new IOException("No valid configuration found!");
                }
                Log.Debug("Configuration loaded: \r\n" + configuration.ToString());
                Log.Information("Starlight Server " + Assembly.GetEntryAssembly().GetName().Version.ToString());

                TranslationManager.Instance.ImportFromDocument(Path.Combine(Directory.GetCurrentDirectory(), "Content", "Languages", "en-us.json"));
                Setup.RunSetup(configuration);

                // create and start the server
                var server = new StarlightServer(new Telepathy.Server());
                server.Server.Start(configuration.Port);

                var networkDispatch = new NetworkDispatch(configuration, server);
                networkDispatch.ResolveHandlers();
                Log.Debug("Server is running...");
                var isRunning = true;
                while (isRunning) {
                    isRunning = server.Server.Active;
                    while (server.Server.GetNextMessage(out var msg)) {
                        switch (msg.eventType) {
                            case Telepathy.EventType.Connected:
                                Log.Information("[" + msg.connectionId + "] Connected from " + server.Server.GetClientAddress(msg.connectionId));
                                break;
                            case Telepathy.EventType.Data:
                                networkDispatch.HandleData(msg.connectionId, msg.data);
                                break;
                            case Telepathy.EventType.Disconnected:
                                Log.Information("[" + msg.connectionId + "] Disconnected");
                                break;
                        }
                    }
                    Thread.Sleep(1);
                }
                server.Server.Stop();
            }
            catch (Exception e) {
                Log.Fatal(e, "Error found in Main Loop");
            }
            Log.Information("Stopping server...");
            Log.CloseAndFlush();
        }

        private static Configuration LoadConfiguration() {
#if DEBUG
            var configPath = "config.development.json";
#else
            var configPath = "config.json";
#endif
            try {
                return Configuration.Read(configPath); 
            }
            catch (IOException e)
            {
                return new Configuration();
            }
        }

    }
}
