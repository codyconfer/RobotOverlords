using System;
using System.Threading.Tasks;
using Discord.Commands;
using RobotOverlords.Modules.Constants;
using RobotOverlords.Modules.ServiceContracts;

namespace RobotOverlords.Modules
{
    public abstract class RobotOverlordsModuleBase : ModuleBase
    {
        protected async Task<string> CreateContextModel(IContextService service)
        {
            await service.InflateServerContext(Context);
            await service.InflateThirdPartyContext();
            return service.Model;
        }

        protected async Task<TReturnModel> CreateContextModel<TReturnModel>(
            IContextService<TReturnModel> service)
        {
            await service.InflateServerContext(Context);
            await service.InflateThirdPartyContext();
            return service.Model;
        }

        protected async Task<TReturnModel> CreateContextModel<TParamData, TReturnModel>(
            IContextService<TParamData, TReturnModel> service,
            TParamData data)
        {
            await service.InflateServerContext(Context, data);
            await service.InflateThirdPartyContext(data);
            return service.Model;
        }

        protected async Task SendMessageAsync(string message)
        {
            var logMessage = message.Length > 255
                ? message.Substring(0, 255)
                : message;
            Console.WriteLine($"[Outgoing Message]{Environment.NewLine}{logMessage}{Environment.NewLine}{LogStrings.Divider}", ConsoleColor.Gray);
            await Context.Channel.SendMessageAsync(message);
        }
    }
}
