using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using RobotOverlords.Extensions;

namespace RobotOverlords.Observers
{
    public class DiscordMessageObserver : DiscordClientObserverBase
    {
        public DiscordMessageObserver(CommandService commandService,
            IServiceProvider moduleServiceProvider)
            : base(commandService, moduleServiceProvider) { }

        public override Task Subscribe(DiscordSocketClient observable)
        {
            base.Subscribe(observable);

            Observable.MessageReceived += OnMessageReceived;
            //Observable.MessageDeleted += ;
            //Observable.MessageUpdated += ;
            //Observable.ReactionAdded += ;
            //Observable.ReactionRemoved += ;
            //Observable.ReactionsCleared += ;

            return Task.CompletedTask;
        }

        public async Task OnMessageReceived(SocketMessage message)
        {
            if (message.IsNotUserMessage()) return;

            SocketUserMessage userMessage = message as SocketUserMessage;
            if (userMessage?.Author?.Username != Observable.CurrentUser.Username)
            {
                int index = 0;
                if (userMessage.HasCharPrefix('!', ref index) /* || msg.HasMentionPrefix(client.CurrentUser, ref pos) */)
                {
                    var context = new SocketCommandContext(Observable, userMessage);
                    var result = await CommandService.ExecuteAsync(context, index, ModuleServiceProvider);
                }
            }
        }
    }
}
