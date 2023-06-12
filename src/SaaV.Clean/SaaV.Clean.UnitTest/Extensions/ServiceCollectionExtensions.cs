using Microsoft.Extensions.DependencyInjection;
using SaaV.Clean.Application.Shared.Interfaces;
using SaaV.Clean.Domain.Dummies;
using SaaV.Clean.Domain.Shared;
using SaaV.Clean.Infrastructure.Persistence;
using SaaV.Clean.UnitTest.Providers;
using SaaV.Clean.Infrastructure.Repositories;

namespace SaaV.Clean.UnitTest.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProviders(this IServiceCollection services)
        {
            services.AddTransient<ICredentialProvider, CredentialProvider>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IDummyRepository, DummyRepository>();
        }
    }
}
