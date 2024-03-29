# RobotOverlords

## Introduction 

RobotOverlords is a discord bot written in dotnet core 3 using discord .net.

### Software dependencies

- Microsoft.NETCore.Platforms 
- Discord .Net
- Microsoft.Extensions.Configuration.CommandLine 
- Microsoft.Extensions.Configuration.Json 
- Microsoft.Extensions.Options.ConfigurationExtensions 
- Microsoft.Extensions.DependencyInjection 
- Microsoft.Extensions.Hosting 
- Microsoft.Extensions.Logging 
- Microsoft.WindowsDesktop.App 
- System.ServiceProcess.ServiceController 

-----

## Getting Started

> This solution has minimum functionality and is meant to be a template to quickly stand up custom bots with.

https://docs.microsoft.com/en-us/dotnet/core/

-----

### Installation process

1. Create a discord developer account, a bot, and obtain a bot token here: https://discord.com/developers/applications
   
> At the end of this, you should have an api key, a registered application with a registered bot, and your bot should be added to a server.

2. Populate .\RobotOverlords\appsettings.json botConfiguration.apiKey with the newly created discord key.
3. Run ```dotnet restore``` on the solution
4. Run the solution from visual studio and confirm that the bot logs in. 
   
> Posting the message !info in a channel the bot can see should cause the bot to response with information about itself.

-----

### Development process

#### Adding message commands

##### Adding a simple command in one class

1. Create a new class in RobotOverlords.Modules, follow the \*Module.cs naming convention
2. Inherit from Discord.Commads.ModuleBase
3. Implement command logic.
4. Register command with the following method attribute:
```csharp
using Discord.Commands;
[Command(""), Summary("")]
```
where the command's trigger is !{{Command}}

##### Adding a data model for your module or service to use

1. Place the model class into RobotOverlords.Modules.Models
2. Access via using declarations

##### Abstracting logic into a service

1. Place service class into RobotOverlords.Modules.Services
2. Register service class in RobotOverlords.Modules.Services.ModuleServiceCollectionBuilder(), this adds the service to an IServiceProvider that is dedicated to RobotOverlords.Modules at Startup.
3. Access via constructor injection.
   
   > See how RobotOverlords.Modules.Services.InfoService is injected into RobotOverlords.Modules.InfoModule

-----

#### Modifying event handling

1. Event handling occurs in RobotOverlords.Observers
2. Changing Observer classes will change how events emitted by the DiscordSocket client are delegated.

-----

### Build and Test

> Like everyone else in existence: //TODO: Implement Unit Tests. 

```dotnet build``` in the .sln directory

