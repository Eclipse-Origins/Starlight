using Microsoft.EntityFrameworkCore;
using Starlight.Network;
using Starlight.Server.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Network
{
    public class RequestContext : IDisposable
    {
        public int ConnectionId { get; }
        public Configuration Configuration { get; }
        public StarlightServer Server { get; }
        public ConnectedUserManager ConnectedUserManager { get; }
        public RequestUser User { get; }
        public ApplicationDbContext DbContext { get; }

        public RequestContext(int connectionId, Configuration configuration, StarlightServer server, ConnectedUserManager connectedUserManager) {
            this.ConnectionId = connectionId;
            this.Configuration = configuration;
            this.Server = server;
            this.ConnectedUserManager = connectedUserManager;

            this.DbContext = DbContextFactory.CreateApplicationDbContext(configuration.ConnectionString);

            if (this.ConnectedUserManager.TryGetUser(connectionId, out var user)) {
                this.User = user;
            }
        }

        public void Dispose() {
            this.DbContext.Dispose();
        }
    }
}
