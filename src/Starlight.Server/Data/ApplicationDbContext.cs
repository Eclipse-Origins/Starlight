using Microsoft.EntityFrameworkCore;
using Starlight.Models;
using Starlight.Server.Models;
using System;
using System.Collections.Generic;
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

            modelBuilder.Entity<Map>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MapAttribute>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MapLayer>()
                        .HasKey(x => x.Id);

            modelBuilder.Entity<MapTile>()
                        .HasKey(x => x.Id);
        }
    }
}
