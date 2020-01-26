using Discord.WebSocket;

namespace RobotOverlords.Extensions
{
    public static class DiscordMessageExtensions
    {
        public static bool IsUserMessage(this SocketMessage message) =>
            message is SocketUserMessage;

        public static bool IsNotUserMessage(this SocketMessage message) =>
            !message.IsUserMessage();
    }
}
