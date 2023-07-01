// See https://aka.ms/new-console-template for more information
using Ali.Games.Mafia.Core;
using Ali.Games.Mafia.Core.Actions;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddActions()
    .AddLastMoveCards()
    .AddSingleton<GameBuilder>()
    .BuildServiceProvider() ;


Console.WriteLine("Hello, World!");


var gb = serviceProvider.GetRequiredService<GameBuilder>();

var game = gb.LoadPlayers()
    .DistributeRoles()
    .Create();

game.Start();

