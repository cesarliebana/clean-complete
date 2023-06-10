using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaaV.Clean.Application.Dummies.Handlers;
using SaaV.Clean.Infrastructure.Persistence;
using SaaV.Clean.UnitTest.Extensions;

namespace SaaV.Clean.UnitTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CleanDbContext>(options => options.UseSqlite("DataSource=:memory:"));
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(CreateDummyHandler).Assembly));
            services.AddRepositories();
            services.AddProviders();
        }

    }
}
