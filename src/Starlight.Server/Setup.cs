using Serilog;
using Starlight.Models;
using Starlight.Server.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Starlight.Server
{
    public static class Setup
    {
        public static void RunSetup(Configuration configuration) {
            
            var dbContext = DbContextFactory.CreateApplicationDbContext(configuration.ConnectionString);
            Console.WriteLine("Updating database...");
            try {
                dbContext.Database.Migrate();
            }
            catch {
                Log.Error("Error encountered during update!");
                return;
            };
          
            if (!dbContext.Maps.Any()) {
                Log.Information("Creating initial map.");

                var map = Map.Create();

                dbContext.Maps.Add(map);
            }

            dbContext.SaveChanges();
        }
    }
}
