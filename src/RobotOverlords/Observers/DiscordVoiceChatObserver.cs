using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace RobotOverlords.Observers
{
    public class DiscordVoiceChatObserver : DiscordClientObserverBase
    {
        public DiscordVoiceChatObserver(CommandService commandService,
            IServiceProvider moduleServiceProvider)
            : base(commandService, moduleServiceProvider) { }

        public override Task Subscribe(DiscordSocketClient observable)
        {
            base.Subscribe(observable);

            //Observable.VoiceServerUpdated += ;
            //Observable.UserVoiceStateUpdated += ;

            return Task.CompletedTask;
        }
    }
}
