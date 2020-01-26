using Discord.WebSocket;

namespace RobotOverlords.Builders
{
    public static class DiscordSocketClientBuilder
    {
        public static DiscordSocketClient BuildClient(DiscordSocketConfig config = null) =>
            new DiscordSocketClient(config ?? BuildConfig());

        //TODO: put in config
        public static DiscordSocketConfig BuildConfig() =>
            new DiscordSocketConfig
            {
                MessageCacheSize = 100
            };
    }
}
