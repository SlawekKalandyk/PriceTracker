using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PriceTracker.Api;
using PriceTracker.Plugins;
using PriceTracker.Shared;
using PriceTracker.Shared.Features.Commands;
using PriceTracker.Shared.Persistence;
using PriceTracker.WinForms.Views;

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
            LoadShops(host);
            
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

#if DEBUG
                    configuration.AddUserSecrets<ApplicationDbContext>();
#endif

                    configuration.Build();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSharedServices(hostContext.Configuration)
                        .AddApiServices(hostContext.Configuration)
                        .AddPluginShopServices(hostContext.Configuration)
                        .AddInterfaceServices(hostContext.Configuration);
                }).Build();
        }

        private static void LoadShops(IHost host)
        {
            var mediator = host.Services.GetRequiredService<IMediator>();
            mediator.Send(new LoadShopsCommand()).Wait();
        }
    }
}