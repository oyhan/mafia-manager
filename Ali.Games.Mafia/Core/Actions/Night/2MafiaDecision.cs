using Ali.Games.Mafia.Core.Interfaces;
using Ali.Games.Mafia.Extensions;
using Ali.Games.Mafia.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Day
{
    internal class MafiaDecision : INightAction
    {
        public int Order => 2;

        public string[] MafiaNightActions => new string[] { "Shot", "SixthSense", "Deal" };

        public Action<GameRound, Player> Action => (GameRound round,Player victim)=> round.Deads.Add(victim);

        public void Do(GameRound round)
        {
            ConsoleColor.DarkBlue.ShowAndPickOneOption(MafiaNightActions.ToList(), @$"***Mafai*** 

              Choose what do you want to do :");
        }

        private void NightAction(GameRound round, Player victim) 
        {

        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }

    public class MafiaAction : IHasName
    {
        public string Name => throw new NotImplementedException();

        SixthSense,
        Shot,
        Deal
    }
}
