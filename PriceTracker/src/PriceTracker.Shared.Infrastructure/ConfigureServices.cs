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
#if SQLITE
            var connectionString = configuration["ConnectionStrings:Sqlite"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString, builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                );
#elif DEBUG
            var connectionString = configuration["ConnectionStrings:Postgres"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString, builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );
#endif
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
