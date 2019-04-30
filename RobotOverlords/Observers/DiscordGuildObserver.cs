using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace RobotOverlords.Observers
{
    public class DiscordGuildObserver : DiscordClientObserverBase
    {
        public DiscordGuildObserver(CommandService commandService,
            IServiceProvider moduleServiceProvider)
            : base(commandService, moduleServiceProvider) { }

        public override Task Subscribe(DiscordSocketClient observable)
        {
            base.Subscribe(observable);

            //Observable.GuildAvailable += ;
            //Observable.GuildUnavailable += ;
            //Observable.GuildUpdated += ;
            //Observable.GuildMemberUpdated += ;
            //Observable.GuildMembersDownloaded += ;

            return Task.CompletedTask;
        }
    }
}
