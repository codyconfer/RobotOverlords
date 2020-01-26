using System.Threading.Tasks;
using Discord.Commands;

namespace RobotOverlords.Modules.ServiceContracts
{
    public interface IContextService
    {
        string Model { get; }

        Task<IContextService> InflateServerContext(ICommandContext context);

        Task<IContextService> InflateThirdPartyContext();
    }

    public interface IContextService<TReturnModel>
    {
        TReturnModel Model { get; }

        Task<IContextService<TReturnModel>> InflateServerContext(ICommandContext context);

        Task<IContextService<TReturnModel>> InflateThirdPartyContext();
    }

    public interface IContextService<TParamData, TReturnModel>
    {
        TReturnModel Model { get; }

        Task<IContextService<TParamData, TReturnModel>> InflateServerContext(ICommandContext context, TParamData data);

        Task<IContextService<TParamData, TReturnModel>> InflateThirdPartyContext(TParamData data);
    }
}
