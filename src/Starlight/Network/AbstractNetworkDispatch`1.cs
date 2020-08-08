using MessagePack;
using Starlight.Packets;
using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Starlight.Network
{
    public abstract class AbstractNetworkDispatch<TRequestContext> where TRequestContext : IDisposable
    {
        protected abstract TRequestContext BuildRequestContext();

        public void HandleData(int connectionId, byte[] data) {
            using (var memoryStream = new MemoryStream(data)) {
                var packetHeader = MessagePackSerializer.Deserialize<PacketHeader>(memoryStream);
                var packetType = Type.GetType(packetHeader.Type);
                var packet = MessagePackSerializer.Deserialize(packetType, memoryStream);

                using (var requestContext = BuildRequestContext()) {

                }
            }
        }
    }
}
