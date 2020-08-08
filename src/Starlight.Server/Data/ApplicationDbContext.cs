using Microsoft.EntityFrameworkCore;
using Starlight.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }
    }
}
