function Invoke-AppBuild 
{
  dotnet publish ./src/RobotOverlords/RobotOverlords.csproj -r win-x64 -c Release /p:PublishSingleFile=true -o ./deploy
  Copy-Item ./src/RobotOverlords/appsettings.json ./deploy/appsettings.json
}

function Invoke-ContainerBuild 
{
  docker build -t robotoverlords -f bot.dockerfile .
  docker create robotoverlords --name
  docker ps -a
}

Invoke-AppBuild
Invoke-ContainerBuild
