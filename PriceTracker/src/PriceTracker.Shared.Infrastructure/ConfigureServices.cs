using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PriceTracker.Shared.Application.Common.Interfaces;
using PriceTracker.Shared.Infrastructure.Persistence;

namespace PriceTracker.Shared.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddSharedInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = Environment.ExpandEnvironmentVariables(configuration.GetConnectionString("DefaultConnection"));

            services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlite(
                    connectionString,
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    ));


            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
