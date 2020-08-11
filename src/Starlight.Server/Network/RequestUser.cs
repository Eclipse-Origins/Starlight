using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Network
{
    public class RequestUser
    {
        public int Id { get; set; }

        public RequestUser(int userId) {
            this.Id = userId;
        }
    }
}
