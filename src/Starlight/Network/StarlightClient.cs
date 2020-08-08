using MessagePack;
using Starlight.Packets;
using Starlight.Packets.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telepathy;

namespace Starlight.Network
{
    public class StarlightClient
    {
        public Client Client { get; }

        public StarlightClient(Client client) {
            this.Client = client;
        }

        public void SendPacket<T>(T packet) where T : AbstractPacket {
            var packetHeader = new PacketHeader()
            {
                Type = typeof(T).FullName
            };

            var packetHeaderBytes = MessagePackSerializer.Serialize(typeof(PacketHeader), packetHeader);
            var packetBytes = MessagePackSerializer.Serialize(typeof(T), packet);

            using (var memoryStream = new MemoryStream()) {
                memoryStream.Write(packetHeaderBytes, 0, packetHeaderBytes.Length);
                memoryStream.Write(packetBytes, 0, packetBytes.Length);

                this.Client.Send(memoryStream.ToArray());
            }
        }
    }
}
