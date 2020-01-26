using System.Threading;
using System.Threading.Tasks;
using Discord.Commands;

namespace RobotOverlords.Modules.Info
{
    public class InfoModule : RobotOverlordsModuleBase
    {
        private readonly InfoService _infoService;

        public InfoModule(InfoService infoService)
        {
            _infoService = infoService;
        }

        [Command("info"), Summary("prints bot information in discord message.")]
        public async Task Info()
        {
            var info = await CreateContextModel(_infoService);
            await SendMessageAsync(info.ToString());
            int sleep = 5000;
            await Task.Run(() => Thread.Sleep(sleep));
            await SendMessageAsync($"o'doyle rules!");
        }
    }
}
