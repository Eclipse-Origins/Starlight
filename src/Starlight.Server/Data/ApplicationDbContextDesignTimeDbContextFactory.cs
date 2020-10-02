using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Starlight.Server.Data
{
    class ApplicationDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args) {
            var configuration = Configuration.Read("config.development.json");

            return DbContextFactory.CreateApplicationDbContext(configuration.ConnectionString);
        }
    }
}
