using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Threading;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RobotOverlords.Builders;
using RobotOverlords.Models;
using RobotOverlords.Observers;

namespace RobotOverlords.Bots
{
    public class DiscordBot : ServiceBase, IBot<DiscordSocketClient>
    {
        private readonly TaskCompletionSource<object> _delayStart;
        private readonly TaskCompletionSource<object> _botConnection;

        public DiscordBot(DiscordSocketClient client,
            ServiceProvider moduleServiceProvider,
            IOptions<BotConfiguration> botOptions,
            IHostApplicationLifetime applicationLifetime)
        {
            ApplicationLifetime = applicationLifetime ??
                throw new ArgumentNullException(nameof(applicationLifetime));
            _delayStart = new TaskCompletionSource<object>();
            _botConnection = new TaskCompletionSource<object>();
            BotConfiguration = botOptions.Value;
            ModuleServiceProvider = moduleServiceProvider;
            Client = client;
        }

        public DiscordSocketClient Client { get; }
        private IServiceProvider ModuleServiceProvider { get; }
        private CommandService CommandService { get; set; }
        private IHostApplicationLifetime ApplicationLifetime { get; }
        private IEnumerable<IClientObserver<DiscordSocketClient>> ClientObservers { get; set; }
        private BotConfiguration BotConfiguration { get; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            cancellationToken.Register(() => _botConnection.TrySetCanceled());
            await SetClientObservers();
            await SubscribeClientObservers();
            await Client.LoginAsync(TokenType.Bot, BotConfiguration.ApiKey);
            await Client.StartAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            cancellationToken.Register(() => _botConnection.TrySetCanceled());
            await Client.StopAsync();
            Stop();
        }

        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            cancellationToken.Register(() => _delayStart.TrySetCanceled());
            ApplicationLifetime.ApplicationStopping.Register(Stop);
            new Thread(Run).Start();
            return _delayStart.Task;
        }

        private void Run()
        {
            try
            {
                Run(this);
                _delayStart.TrySetException(new InvalidOperationException("Stopped without starting"));
            }
            catch (Exception ex)
            {
                _delayStart.TrySetException(ex);
            }
        }

        protected override void OnStart(string[] args)
        {
            _delayStart.TrySetResult(null);
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            ApplicationLifetime.StopApplication();
            base.OnStop();
        }

        private async Task SetClientObservers()
        {
            var commandBuilder = new DiscordCommandServiceBuilder();
            CommandService = await commandBuilder.BuildService(ModuleServiceProvider);
            ClientObservers = new List<IClientObserver<DiscordSocketClient>>
            {
                new DiscordConnectionObserver(CommandService, ModuleServiceProvider),
                new DiscordCurrentUserObserver(CommandService, ModuleServiceProvider),
                new DiscordGuildObserver(CommandService, ModuleServiceProvider),
                new DiscordChannelObserver(CommandService, ModuleServiceProvider),
                new DiscordMessageObserver(CommandService, ModuleServiceProvider),
                new DiscordRoleObserver(CommandService, ModuleServiceProvider),
                new DiscordUserObserver(CommandService, ModuleServiceProvider),
                new DiscordVoiceChatObserver(CommandService, ModuleServiceProvider)
            };
        }

        private async Task SubscribeClientObservers()
        {
            var observersList = ClientObservers.ToList();
            foreach (var observer in observersList)
            {
                await observer.Subscribe(Client);
            }
        }
    }
}
