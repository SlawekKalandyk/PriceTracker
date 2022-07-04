﻿using MediatR;

namespace PriceTracker.Api
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            return services;
        }
    }
}
