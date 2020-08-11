using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Packets.Core
{
    public abstract class AbstractResultPacket : AbstractPacket
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public AbstractResultPacket(bool succeeded, string message) {
            this.Succeeded = succeeded;
            this.Message = message;
        }
    }
}
