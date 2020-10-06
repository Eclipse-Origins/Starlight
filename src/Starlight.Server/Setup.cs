using Serilog;
using Starlight.Models;
using Starlight.Server.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Starlight.Server
{
    public static class Setup
    {
        public static void RunSetup(Configuration configuration) {
            
            var dbContext = DbContextFactory.CreateApplicationDbContext(configuration.ConnectionString);
            Log.Information("Updating database...");
            try {
                dbContext.Database.Migrate();
            }
            catch (Exception e){
                Log.Error(e,"Error encountered during update!");
                return;
            };
          
            if (!dbContext.Maps.Any()) {
                Log.Information("Creating initial map.");

                var map = Map.Create();

                dbContext.Maps.Add(map);
            }

            if (!dbContext.GlobalTimeEvents.Any()) {
                Log.Information("Creating global events");

                var events = GlobalTimeEvents.Create();

                dbContext.GlobalTimeEvents.Add(events);
            }

            if (!dbContext.GlobalConstellation.Any()) {
                Log.Information("Creating sun and moons");

                var constellations = GlobalConstellation.Create();
                foreach (var constellation in constellations) 
                    {
                        dbContext.GlobalConstellation.Add(constellation);
                        dbContext.SaveChanges();
                    }
            }

            if (!dbContext.GlobalData.Any()) {
                Log.Information("Creating global data");

                var database = GlobalData.Create();
                foreach(var data in database) {
                    dbContext.GlobalData.Add(data);
                    dbContext.SaveChanges();
                }
            }
            
            if (!dbContext.Clock.Any()) {
                Log.Information("Creating clock");

                var clock = Clock.Create();
                dbContext.Clock.Add(clock);
            }


            dbContext.SaveChanges();
        }
    }
}
