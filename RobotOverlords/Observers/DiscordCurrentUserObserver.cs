using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace RobotOverlords.Observers
{
    public class DiscordCurrentUserObserver : DiscordClientObserverBase
    {
        public DiscordCurrentUserObserver(CommandService commandService,
            IServiceProvider moduleServiceProvider)
            : base(commandService, moduleServiceProvider) { }

        public override Task Subscribe(DiscordSocketClient observable)
        {
            base.Subscribe(observable);

            //Observable.JoinedGuild += ;
            //Observable.LeftGuild += ;
            //Observable.LoggedIn += ;
            //Observable.LoggedOut += ;

            return Task.CompletedTask;
        }
    }
}
