using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using RobotOverlords.Modules.Models;

namespace RobotOverlords.Modules.Services
{
    public class InfoService
    {
        public async Task<InfoModel> GetCurrentInfo(ICommandContext context)
        {
            var info = await context.Client.GetApplicationInfoAsync();
            return new InfoModel()
            {
                ThirdPartyUsername = context.User.Username,
                BotUsername = context.Client.CurrentUser.Username,
                BotName = info.Name,
                BotDescription = info.Description,
                GuildName = context.Guild.Name,
                ChannelName = context.Channel.Name
            };
        }
    }
}
