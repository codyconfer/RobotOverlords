using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace RobotOverlords.Modules.Services
{
    public static class ModuleServiceCollectionBuilder
    {
        public static IServiceCollection BuildModuleServiceCollection()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<InfoService>();

            return serviceCollection;
        }
    }
}
