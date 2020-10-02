using Microsoft.EntityFrameworkCore;
using Starlight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starlight.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<Map> Maps { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Character>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Map>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MapAttribute>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MapLayer>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MapTile>()
                        .HasKey(x => x.Id);
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
