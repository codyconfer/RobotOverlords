using System.Threading.Tasks;
using Discord.Commands;
using RobotOverlords.Modules.ServiceContracts;

namespace RobotOverlords.Modules.Info
{
    public class InfoService : IContextService<InfoModel>
    {
        public InfoModel Model { get; } = new InfoModel();

        public async Task<IContextService<InfoModel>> InflateServerContext(ICommandContext context)
        {
            var info = await context.Client.GetApplicationInfoAsync();
            Model.ThirdPartyUsername = context.User.Username;
            Model.BotUsername = context.Client.CurrentUser.Username;
            Model.BotName = info.Name;
            Model.BotDescription = info.Description;
            Model.GuildName = context.Guild.Name;
            Model.ChannelName = context.Channel.Name;
            return this;
        }

        public Task<IContextService<InfoModel>> InflateThirdPartyContext() =>
            Task.FromResult(this as IContextService<InfoModel>);
    }
}
