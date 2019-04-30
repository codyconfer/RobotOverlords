﻿using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotOverlords.Builders
{
    public class DiscordCommandServiceBuilder
    {
        public async Task<CommandService> BuildService(IServiceProvider moduleServiceProvider)
        {
            var service = new CommandService();

            await service.AddModulesAsync(Assembly.Load("RobotOverlords.Modules"),
                moduleServiceProvider);

            return service;
        }
    }
}
