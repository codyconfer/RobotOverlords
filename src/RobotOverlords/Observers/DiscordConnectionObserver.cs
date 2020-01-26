using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace RobotOverlords.Observers
{
    public class DiscordConnectionObserver : DiscordClientObserverBase
    {
        public DiscordConnectionObserver(CommandService commandService,
            IServiceProvider moduleServiceProvider)
            : base(commandService, moduleServiceProvider) { }

        public override Task Subscribe(DiscordSocketClient observable)
        {
            base.Subscribe(observable);

            //Observable.Connected += ;
            //Observable.Disconnected += ;
            //Observable.LatencyUpdated += ;
            //Observable.Ready += ;

            return Task.CompletedTask;
        }
    }
}
