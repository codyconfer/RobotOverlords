using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using RobotOverlords.Extensions;
using RobotOverlords.Modules.Constants;

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
                var logMessage = userMessage?.Content?.Length > 255
                    ? userMessage.Content.Substring(0, 255)
                    : userMessage?.Content ?? string.Empty;
                Console.WriteLine($"[Incoming Message]{Environment.NewLine}[From] {userMessage?.Author?.Username}{Environment.NewLine}[Message] {logMessage}{Environment.NewLine}{LogStrings.Divider}", ConsoleColor.Cyan);
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
