using Starlight.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Network
{
    public class ConnectedUserManager
    {
        private readonly Dictionary<int, RequestUser> users;

        public ConnectedUserManager() {
            this.users = new Dictionary<int, RequestUser>();
        }

        public bool TryGetUser(int connectionId, out RequestUser user) {
            return this.users.TryGetValue(connectionId, out user);
        }

        public void AddUser(int connectionId, RequestUser user) {
            this.users.Add(connectionId, user);
        }

        public void RemoveUser(int connectionId) {
            this.users.Remove(connectionId);
        }
    }
}
