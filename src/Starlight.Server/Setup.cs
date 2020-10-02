using Starlight.Models;
using Starlight.Server.Data;
using System;
using System.Collections.Generic;
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
                Console.WriteLine("Error encountered during update!");
                return;
            };
            if (!dbContext.Maps.Any()) {
                Console.WriteLine("Creating initial map.");

                var map = Map.Create();

                dbContext.Maps.Add(map);
            }

            dbContext.SaveChanges();
        }
    }
}
