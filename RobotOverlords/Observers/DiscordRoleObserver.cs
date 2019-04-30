using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace RobotOverlords.Observers
{
    public class DiscordRoleObserver : DiscordClientObserverBase
    {
        public DiscordRoleObserver(CommandService commandService,
            IServiceProvider moduleServiceProvider)
            : base(commandService, moduleServiceProvider) { }

        public override Task Subscribe(DiscordSocketClient observable)
        {
            base.Subscribe(observable);

            //Observable.RoleCreated += ;
            //Observable.RoleUpdated += ;
            //Observable.RoleDeleted += ;

            return Task.CompletedTask;
        }
    }
}
