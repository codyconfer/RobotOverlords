using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RobotOverlords.Bots;
using RobotOverlords.Builders;
using RobotOverlords.Models;
using RobotOverlords.Modules.Configuration;

namespace RobotOverlords
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder();
            UseDiscord(hostBuilder);
            var cancellationToken = new CancellationToken();
            //await hostBuilder.RunConsoleAsync(cancellationToken);
            var botLifetime = args.Contains("--console") ? hostBuilder.RunConsoleAsync(cancellationToken) :
                hostBuilder.Build().RunAsync(cancellationToken);

            await botLifetime;
        }

        private static IHostBuilder CreateHostBuilder() =>
            new HostBuilder()
                .ConfigureAppConfiguration(CreateAppConfiguration)
                .ConfigureServices(CreateServiceCollection);

        private static IHostBuilder UseDiscord(IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<DiscordBot>();
                services.AddSingleton(ModuleServiceCollectionBuilder
                    .BuildModuleServiceCollection()
                    .BuildServiceProvider()
                );
                services.AddSingleton(DiscordSocketClientBuilder.BuildClient());
            });

        private static readonly Action<HostBuilderContext, IConfigurationBuilder> CreateAppConfiguration =
            (hostContext, configBuilder) =>
            {
                configBuilder.SetBasePath(Directory.GetCurrentDirectory());
                configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            };

        private static readonly Action<HostBuilderContext, IServiceCollection> CreateServiceCollection =
            (hostContext, services) =>
            {
                services.Configure<ConsoleLifetimeOptions>(o => o.SuppressStatusMessages = true);
                services.Configure<BotConfiguration>(hostContext.Configuration.GetSection("botConfiguration"));
            };
    }
}
