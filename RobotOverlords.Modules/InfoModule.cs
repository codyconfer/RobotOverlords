using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord.Commands;
using RobotOverlords.Modules.Services;

namespace RobotOverlords.Modules
{
    public class InfoModule : ModuleBase
    {
        private readonly InfoService _infoService;

        public InfoModule(InfoService infoService)
        {
            _infoService = infoService;
        }

        [Command("info"), Summary("prints bot information in discord message.")]
        public async Task Info()
        {
            var info = await _infoService.GetCurrentInfo(Context);
            await Context.Channel.SendMessageAsync(info.ToString());
            int sleep = 5000;
            await Task.Run(() => Thread.Sleep(sleep));
            await Context.Channel.SendMessageAsync($"o'doyle rules!");
        }
    }
}
