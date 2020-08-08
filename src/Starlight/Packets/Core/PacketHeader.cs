using MessagePack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets.Core
{
    [MessagePackObject(keyAsPropertyName: true)]
    public class PacketHeader
    {
        public string Type { get; set; }
    }
}
