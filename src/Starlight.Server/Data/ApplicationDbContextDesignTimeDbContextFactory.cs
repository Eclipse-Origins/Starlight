using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Starlight.Server.Data
{
    class ApplicationDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = Configuration.Read("config.development.json");

            var optionsBuilder = new DbContextOptionsBuilder()
                .UseNpgsql(configuration.ConnectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
