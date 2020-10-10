using Microsoft.EntityFrameworkCore;
using Starlight.Models;
using Starlight.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Starlight.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<Map> Maps { get; set; }

        public DbSet<GlobalData> GlobalData { get; set; }
        public DbSet<GlobalTimeEvents> GlobalTimeEvents { get; set; }
        public DbSet<GlobalConstellation> GlobalConstellation { get; set; }
        public DbSet<Clock> Clock { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddStarlightEntity<User>();
            modelBuilder.AddStarlightEntity<Character>();
            modelBuilder.AddStarlightEntity<Map>();
            modelBuilder.AddStarlightEntity<MapAttribute>();
            modelBuilder.AddStarlightEntity<MapLayer>();
            modelBuilder.AddStarlightEntity<MapTile>();
        }

        public override int SaveChanges() {
            var entities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entity in entities) {
                if (entity.Entity is CoreDataModel coreDataModel) {
                    coreDataModel.ModifiedAt = DateTimeOffset.UtcNow;

                    if (entity.State == EntityState.Added) {
                        coreDataModel.CreatedAt = DateTimeOffset.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
