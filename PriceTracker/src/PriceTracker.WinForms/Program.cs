using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceTracker.Api.Application;
using PriceTracker.Api.Infrastructure;
using PriceTracker.Plugins;
using PriceTracker.Shared.Application;
using PriceTracker.Shared.Infrastructure;

namespace PriceTracker.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHost();
            var mainView = host.Services.GetRequiredService<MainView>();
            Application.Run(mainView);
        }

        private static IHost CreateHost()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();
                    configuration
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);

                    configuration.Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSharedApplicationServices(hostContext.Configuration)
                        .AddSharedInfrastructureServices(hostContext.Configuration)
                        .AddApiApplicationServices(hostContext.Configuration)
                        .AddApiInfrastructureServices(hostContext.Configuration)
                        .AddPluginShopServices(hostContext.Configuration)
                        .AddInterfaceServices(hostContext.Configuration);
                }).Build();
        }
    }
}