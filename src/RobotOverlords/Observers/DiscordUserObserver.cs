using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace RobotOverlords.Observers
{
    public class DiscordUserObserver : DiscordClientObserverBase
    {
        public DiscordUserObserver(CommandService commandService,
            IServiceProvider moduleServiceProvider)
            : base(commandService, moduleServiceProvider) { }

        public override Task Subscribe(DiscordSocketClient observable)
        {
            base.Subscribe(observable);

            //Observable.UserJoined += ;
            //Observable.UserLeft += ;
            //Observable.UserUpdated += ;
            //Observable.UserIsTyping += ;
            //Observable.UserBanned += ;
            //Observable.UserUnbanned += ;

            return Task.CompletedTask;
        }
    }
}
