using System.Text;

namespace RobotOverlords.Modules.Info
{
    public class InfoModel
    {
        public string ThirdPartyUsername { get; set; }
        public string BotUsername { get; set; }
        public string BotName { get; set; }
        public string BotDescription { get; set; }
        public string GuildName { get; set; }
        public string ChannelName { get; set; }
        public override string ToString() =>
            new StringBuilder()
                .AppendLine($"hello, {ThirdPartyUsername}.")
                .AppendLine($"this is {BotName}, {BotDescription}.")
                .AppendLine($"current alias: {BotUsername}")
                .AppendLine($"current server: {GuildName}")
                .AppendLine($"current channel: #{ChannelName}")
                .ToString();
    }
}
