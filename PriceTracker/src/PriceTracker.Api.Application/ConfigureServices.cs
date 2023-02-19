using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PriceTracker.Api.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(serviceConfiguration => serviceConfiguration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
