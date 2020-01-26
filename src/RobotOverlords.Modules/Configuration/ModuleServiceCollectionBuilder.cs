using Microsoft.Extensions.DependencyInjection;

namespace RobotOverlords.Modules.Configuration
{
    public static class ModuleServiceCollectionBuilder
    {
        public static IServiceCollection BuildModuleServiceCollection() =>
            new ServiceCollection()
                .AddScoped<Info.InfoService>();
    }
}
