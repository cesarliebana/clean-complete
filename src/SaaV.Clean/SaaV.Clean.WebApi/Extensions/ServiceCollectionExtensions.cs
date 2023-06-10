using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SaaV.Clean.Application.Shared.Interfaces;
using SaaV.Clean.WebApi.Authentication;
using SaaV.Clean.Infrastructure.Providers;
using System.Text;
using SaaV.Clean.Domain.Shared;
using SaaV.Clean.Domain.Dummies;
using SaaV.Clean.Infrastructure.Repositories;
using SaaV.Clean.Infrastructure.Persistence;

namespace SaaV.Clean.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthenticationEndpoints.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

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
