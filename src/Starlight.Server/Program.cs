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
using Starlight.Server.GameLogic;
using Starlight.Server.Data;
using System.Linq;
using System.CommandLine.DragonFruit;

namespace Starlight.Server
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="debug">To turn debugging on or off</param>
        /// <param name="config">Location of the configuration file</param>
        static void Main(bool debug = false, string config = "config.json") {
            var server = new StarlightServer(new Telepathy.Server());
#if DEBUG
            debug = true;
            config = "config.development.json";
#endif
            try {
                var configuration = LoadConfiguration(config);
                if (configuration.LogFile == null) {
                    configuration.LogFile = "server.log";
                };
                Log.Logger = (ILogger)new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(path: configuration.LogFile, rollingInterval: RollingInterval.Day)
                .MinimumLevel.Information()
                .CreateLogger();
                if (debug) {
                    Log.Logger = (ILogger)new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File(path: configuration.LogFile, rollingInterval: RollingInterval.Day)
                    .MinimumLevel.Debug()
                    .CreateLogger();
                }
                if (configuration.ConnectionString == null || configuration.Port == 0) {
                    throw new IOException("No valid configuration found!");
                }
                Log.Information("Starlight Server " + Assembly.GetEntryAssembly().GetName().Version.ToString());
                Log.Debug("Configuration loaded: \r\n" + configuration.ToString());

                TranslationManager.Instance.ImportFromDocument(Path.Combine(Directory.GetCurrentDirectory(), "Content", "Languages", "en-us.json"));
                Setup.RunSetup(configuration);

                // start the server
                server.Server.Start(configuration.Port);

                var networkDispatch = new NetworkDispatch(configuration, server);
                var database = DbContextFactory.CreateApplicationDbContext(configuration.ConnectionString);

                //Setting universe ticking time

                if (database.GlobalData.Where(x => x.Name == "SecondsPerMinute").FirstOrDefault().Value == null) {
                    Log.Fatal("No timedelay found!");
                    throw new TimeZoneNotFoundException();
                }
                var timedelay = int.Parse(database.GlobalData.Where(x => x.Name == "SecondsPerMinute").FirstOrDefault().Value) * 1000;
                if (timedelay <= 1000) {
                    //You don't want to have 1 sec = 1 minute ingame
                    Log.Fatal("Timedelay is too short! Setting to default.");
                    timedelay = 60000;
                }
                long lastTick = 0;
                var tickcounter = 0;
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

                    if (DateTime.UtcNow.Ticks > lastTick + timedelay * 10000) {
                        Log.Debug("tps: " + (tickcounter / (timedelay / 1000)));
                        lastTick = DateTime.UtcNow.Ticks;
                        tickcounter = 0;
                        PersistentUniverse.DoTick(database);
                    }
                    tickcounter++;
                    Thread.Sleep(1);
                }
            }
            catch (Exception e) {
                Log.Fatal(e, "Error found in Main Loop");
            }
            Log.Information("Stopping server...");
            server.Server.Stop();
            Log.CloseAndFlush();
        }

        private static Configuration LoadConfiguration(string configPath = "config.json") {
            try {
                return Configuration.Read(configPath);
            }
            catch (IOException) {
                return new Configuration();
            }
        }
    }
}
