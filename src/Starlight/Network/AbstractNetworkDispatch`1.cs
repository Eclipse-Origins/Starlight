using MessagePack;
using Serilog;
using Starlight.Packets;
using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Starlight.Network
{
    public abstract class AbstractNetworkDispatch<TRequestContext> where TRequestContext : IDisposable
    {
        Dictionary<string, IPacketHandler<TRequestContext>> handlers;
        private readonly Assembly handlersAssembly;

        public AbstractNetworkDispatch(Assembly handlersAssembly) {
            this.handlers = new Dictionary<string, IPacketHandler<TRequestContext>>();
            this.handlersAssembly = handlersAssembly;
        }

        public void ResolveHandlers() {
            foreach (var type in this.handlersAssembly.ExportedTypes.Where(x => !x.IsAbstract)) {
                var packetHandlerInterface = type.GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IPacketHandler<,>)).FirstOrDefault();
                if (packetHandlerInterface != null) {
                    var packetType = packetHandlerInterface.GenericTypeArguments[1];

                    var packetHandler = (IPacketHandler<TRequestContext>)Activator.CreateInstance(type);

                    handlers.Add(packetType.FullName, packetHandler);
                }
            }
        }

        protected abstract TRequestContext BuildRequestContext(int connectionId);

        public void HandleData(int connectionId, byte[] data) {
            using (var memoryStream = new MemoryStream(data)) {
                var packetHeader = MessagePackSerializer.Deserialize<PacketHeader>(memoryStream);
                var packetType = Type.GetType(packetHeader.Type);
                var packet = MessagePackSerializer.Deserialize(packetType, memoryStream);

                using (var requestContext = BuildRequestContext(connectionId)) {
                    if (this.handlers.TryGetValue(packetHeader.Type, out var handler)) {
                        handler.HandleGenericPacket(requestContext, packet);

                        OnRequestCompleted(requestContext);
                    }
                    else {
                        Log.Warning("[" + connectionId + "] Possible hack attempt detected! PacketType: " + packetHeader.Type);
                    }
                }
            }
        }

        protected virtual void OnRequestCompleted(TRequestContext requestContext) {
        }
    }
}
