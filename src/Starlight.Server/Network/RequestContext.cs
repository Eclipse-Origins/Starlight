using Microsoft.EntityFrameworkCore;
using Starlight.Server.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Network
{
    public class RequestContext : IDisposable
    {
        private readonly Configuration configuration;
        private readonly ApplicationDbContext applicationDbContext;

        public RequestContext(Configuration configuration) {
            this.configuration = configuration;

            this.applicationDbContext = new ApplicationDbContext(ConfigureDbContext(configuration));
        }

        private DbContextOptions ConfigureDbContext(Configuration configuration) {
            var optionBuilder = new DbContextOptionsBuilder().UseNpgsql(configuration.ConnectionString);

            return optionBuilder.Options;
        }

        public void Dispose() {
            this.applicationDbContext.Dispose();
        }
    }
}
