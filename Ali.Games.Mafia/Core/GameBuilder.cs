using Ali.Games.Mafia.Core.Actions;
using Ali.Games.Mafia.Core.Models;
using Ali.Games.Mafia.Core.Roles;
using Ali.Games.Mafia.Roles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core
{
    public class GameBuilder
    {
        private Game _game;
        private readonly string MafieRole = "Mafia";
        private readonly string CitizenRole= "Citizen";
        private readonly IEnumerable<IAction> _actions;

        public List<Role> Roles => JsonConvert.DeserializeObject<List<Role>>(File.ReadAllText("Roles.json"));
        public GameBuilder(IEnumerable<IAction> actions)
        {
            _game = new Game();
            this._actions = actions.OrderBy(c=>c.Order);
        }

        public GameBuilder LoadPlayers()
        {
            var content = File.ReadAllText("Players.json");
            var players = JsonConvert.DeserializeObject<List<Player>>(content);
            _game.Players = players;
            return this;
        }

        public GameBuilder ConfigureSteps()
        {
            var content = File.ReadAllText("GameSteps.json");
            var steps = JsonConvert.DeserializeObject<List<GameStep>>(content);
            _game.Steps = steps;
            return this;
        }

        public GameBuilder DistributeRoles() 
        {
            var players = _game.Players;
           


            var cards = Roles.Select(c=>c.Name).ToList();
            cards.Append("Citizen");
            cards.Append("Citizen");
            //var simpleMafi = cards.FirstOrDefault(r => r.Name == MafieRole);
            //var simpleCitizen = cards.FirstOrDefault(r => r.Name == CitizenRole);
            //cards.Remove(simpleMafi);
            //cards.Add(simpleCitizen);
            //cards.Add(simpleCitizen);

            if (players.Count!= cards.Count() && Roles.Count!=11)
            {
                throw new Exception("Playes count should be 11");
            }
            var numbers = cards.Select(c => cards.IndexOf(c)).ToArray();
            foreach (var player in players)
            {
                if (numbers.Any())
                {
                    var randNo = new Random().Next(numbers.Count() - 1);
                    var randomCard = numbers[randNo];
                    player.Role = new RolesConstants()[cards[randomCard]];
                    cards.Remove(cards[randomCard]);
                    numbers = cards.Select(c => cards.IndexOf(c)).ToArray();
                }
                else
                {
                    player.Role = null;
                }

                
            }
            return this;
        }

        public Game Create()
        {
            GameManager.Actions = _actions.ToList();
            var firstRound = new GameRound()
            {
                Alives = _game.Players,
                CurrentAction = null,
                DoneActions = null,
                LeadOfTalk = null,
                Number = 1,
                Game = _game, 
            };
            _game.Rounds.Add(firstRound);
            _game.CurrentState = firstRound;
            _game.PrevStep = null;
            
            
            return _game;
        }
    }
}
