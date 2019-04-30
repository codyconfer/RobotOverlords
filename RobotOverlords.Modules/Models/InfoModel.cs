using System;
using System.Collections.Generic;
using System.Text;

namespace RobotOverlords.Modules.Models
{
    public class InfoModel
    {
        public string ThirdPartyUsername { get; set; }
        public string BotUsername { get; set; }
        public string BotName { get; set; }
        public string BotDescription { get; set; }
        public string GuildName { get; set; }
        public string ChannelName { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder()
                .AppendLine(
                    $"hello, {ThirdPartyUsername}."
                );
            builder
                .AppendLine(
                    $"this is {BotName}, {BotDescription}."
                )
                .AppendLine(
                    $"current alias: {BotUsername}"
                )
                .AppendLine(
                    $"current server: {GuildName}"
                )
                .AppendLine(
                    $"current channel: #{ChannelName}"
                );

            return builder.ToString();
        }
    }
}
