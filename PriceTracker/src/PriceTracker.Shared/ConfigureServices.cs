using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PriceTracker.Shared.Common.Interfaces;
using PriceTracker.Shared.Persistence;

namespace PriceTracker.Shared
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(serviceConfiguration => serviceConfiguration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

#if SQLITE
            var connectionString = configuration["ConnectionStrings:Sqlite"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString, builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                );
#else
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
