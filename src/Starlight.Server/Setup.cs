using Serilog;
using Starlight.Models;
using Starlight.Server.Data;
using System.Linq;

namespace Starlight.Server
{
    public static class Setup
    {
        public static void RunSetup(Configuration configuration) {
            var dbContext = DbContextFactory.CreateApplicationDbContext(configuration.ConnectionString);

            if (!dbContext.Maps.Any()) {
                Log.Information("Creating initial map.");

                var map = Map.Create();

                dbContext.Maps.Add(map);
            }

            dbContext.SaveChanges();
        }
    }
}
