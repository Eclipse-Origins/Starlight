using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Data
{
    public static class DbContextFactory
    {
        public static ApplicationDbContext CreateApplicationDbContext(string connectionString) {
            return new ApplicationDbContext(ConfigureDbContext(connectionString));
        }

        private static DbContextOptions ConfigureDbContext(string connectionString) {
            var optionBuilder = new DbContextOptionsBuilder().UseNpgsql(connectionString);

            return optionBuilder.Options;
        }
    }
}
