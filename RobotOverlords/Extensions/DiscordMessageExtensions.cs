using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotOverlords.Extensions
{
    public static class DiscordMessageExtensions
    {
        public static bool IsUserMessage(this SocketMessage message)
        {
            return message is SocketUserMessage;
        }

        public static bool IsNotUserMessage(this SocketMessage message)
        {
            return !message.IsUserMessage();
        }
    }
}
