using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PriceTracker.WinForms
{
    internal static class ConfigureServices
    {
        internal static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(serviceConfiguration => serviceConfiguration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<MainView>();

            return services;
        }
    }
}
