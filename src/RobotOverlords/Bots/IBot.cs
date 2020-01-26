using Microsoft.Extensions.Hosting;

namespace RobotOverlords.Bots
{
    public interface IBot<out TClient> : IHostedService
    {
        TClient Client { get; }
    }
}
