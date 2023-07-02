// See https://aka.ms/new-console-template for more information
using Ali.Games.Mafia;
using Ali.Games.Mafia.Core;
using Ali.Games.Mafia.Core.Actions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter("Microsoft", LogLevel.Warning)
        .AddFilter("System", LogLevel.Warning)
        .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug);
        //.AddConsole()
        //.AddEventLog();
});
ILogger logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation("Example log message");

var serviceProvider = new ServiceCollection()
    .AddScoped(typeof(ILogger<>), c => loggerFactory.CreateLogger(typeof(ILogger<>)))
    .AddLastMoveCards()
    .AddSingleton<GameBuilder>()
    .BuildServiceProvider() ;

Logger.logger = serviceProvider.GetRequiredService<ILogger<Game>>();

Console.WriteLine("Hello, World!");


var gb = serviceProvider.GetRequiredService<GameBuilder>();

var game = gb.LoadPlayers()
    .DistributeRoles()
    .Create();

game.Start();

