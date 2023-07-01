using Ali.Games.Mafia.Core.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core
{
    public class GameRound
    {
        public int DefenceThreashold => Alives.Count / 2 +1;
        public int ExitThreashold => Alives.Count / 2 +1;
        public int Number { get; set; }
        public List<Player> Alives { get; set; } = new();
        public List<(Player,int)> Votes { get; set; } = new();
        public List<(Player,int)> DefenceVote { get; set; } = new();
        public Player Fired { set; get; }
        public List<Player> Deads { get; set; } = new();
        public List<Player> Warned { get; set; } = new();
        public List<Player> Muted { get; set; } = new();
        public List<Player> Kicked { get; set; } = new();
        public List<Player> Talked { get; set; } = new();
        public List<Player> DefenceTalk { get; set; } = new();
        public List<Player> Disabled { get; set; } = new();
        public List<Player> InDefence => Votes.Where(p => p.Item2 >= DefenceThreashold).Select(c => c.Item1).ToList();

        public int NoOfAliveMafias => Alives.Count(p => p.Side == Side.Mafia);
        public int NoOfAliveCitiZens => Alives.Count(p => p.Side == Side.Citizen);

        public GamePhase CurrentPhase { get; set; }

        public Player LeadOfTalk { get; internal set; } = null;

        public List<IAction> DoneActions { get; set; } = null;

        public IAction CurrentAction { get; set; } = null;

        public Game Game { get; set; }

    }
}
