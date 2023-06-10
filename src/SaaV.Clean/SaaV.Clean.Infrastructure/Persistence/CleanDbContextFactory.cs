using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SaaV.Clean.Infrastructure.Persistence
{
    public class CleanDbContextFactory : IDesignTimeDbContextFactory<CleanDbContext>
    {
        public CleanDbContext CreateDbContext(string[]? args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<CleanDbContextFactory>()
            .Build();

            DbContextOptionsBuilder<CleanDbContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(config.GetConnectionString("CleanConnectionString"));

            return new CleanDbContext(optionsBuilder.Options, null);
        }
    }
}
