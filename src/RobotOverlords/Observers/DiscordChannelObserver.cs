using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace RobotOverlords.Observers
{
    public class DiscordChannelObserver : DiscordClientObserverBase
    {
        public DiscordChannelObserver(CommandService commandService,
            IServiceProvider moduleServiceProvider) 
            : base(commandService, moduleServiceProvider) { }

        public override Task Subscribe(DiscordSocketClient observable)
        {
            base.Subscribe(observable);

            //Observable.ChannelCreated += ;
            //Observable.ChannelUpdated += ;
            //Observable.ChannelDestroyed += ;
            //Observable.RecipientAdded += ;
            //Observable.RecipientRemoved += ;

            return Task.CompletedTask;
        }
    }
}
