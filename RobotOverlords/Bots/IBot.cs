using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RobotOverlords.Observers;

namespace RobotOverlords.Bots
{
    public interface IBot<out TClient> : IHostedService
    {
        TClient Client { get; }
    }
}
