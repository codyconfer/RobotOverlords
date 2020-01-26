using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace RobotOverlords.Observers
{
    public abstract class DiscordClientObserverBase : IClientObserver<DiscordSocketClient>
    {
        protected readonly CommandService CommandService;
        protected readonly IServiceProvider ModuleServiceProvider;

        protected DiscordClientObserverBase(CommandService commandService,
            IServiceProvider moduleServiceProvider)
        {
            CommandService = commandService;
            ModuleServiceProvider = moduleServiceProvider;
        }

        public DiscordSocketClient Observable { get; private set; }

        public virtual Task Subscribe(DiscordSocketClient observable)
        {
            Observable = observable;
            return Task.CompletedTask;
        }

        public Task Unsubscribe()
        {
            Observable = null;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}
