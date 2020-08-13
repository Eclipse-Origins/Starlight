using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Network
{
    public class RequestUser
    {
        public int Id { get; set; }
        public ClientType ClientType { get; set; }

        public RequestUser(int userId, ClientType clientType) {
            this.Id = userId;
            this.ClientType = clientType;
        }
    }
}
