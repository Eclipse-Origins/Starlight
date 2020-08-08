using MessagePack;
using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telepathy;

namespace Starlight.Network
{
    public class StarlightServer
    {
        public Server Server { get; }

        public StarlightServer(Server server) {
            this.Server = server;
        }

        public void SendPacket<T>(int connectionId, T packet) where T : AbstractPacket {
            var packetHeader = new PacketHeader()
            {
                Type = typeof(T).FullName
            };

            var packetHeaderBytes = MessagePackSerializer.Serialize(typeof(PacketHeader), packetHeader);
            var packetBytes = MessagePackSerializer.Serialize(typeof(T), packet);

            using (var memoryStream = new MemoryStream()) {
                memoryStream.Write(packetHeaderBytes, 0, packetHeaderBytes.Length);
                memoryStream.Write(packetBytes, 0, packetBytes.Length);

                this.Server.Send(connectionId, memoryStream.ToArray());
            }
        }
    }
}
