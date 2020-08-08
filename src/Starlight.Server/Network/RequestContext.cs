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
        public ApplicationDbContext DbContext { get; }

        public RequestContext(int connectionId, Configuration configuration, StarlightServer server) {
            this.ConnectionId = connectionId;
            this.Configuration = configuration;
            this.Server = server;

            this.DbContext = new ApplicationDbContext(ConfigureDbContext(configuration));
        }

        private DbContextOptions ConfigureDbContext(Configuration configuration) {
            var optionBuilder = new DbContextOptionsBuilder().UseNpgsql(configuration.ConnectionString);

            return optionBuilder.Options;
        }

        public void Dispose() {
            this.DbContext.Dispose();
        }
    }
}
