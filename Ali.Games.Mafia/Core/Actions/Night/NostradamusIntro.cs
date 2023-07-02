using Ali.Games.Mafia.Core.Roles;
using Ali.Games.Mafia.Extensions;
using Ali.Games.Mafia.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Night
{
    public class NostradamusIntro : INightAction
    {
        public int Order => -1;

        public Role Role => new RolesConstants()["Nostradamus"];

        public void Do(GameRound round)
        {
            var players = round.Alives;

            var selected = ConsoleColor.Red.ShowAndPickMultipleOption(players, 3, "Choose 3 people to inquery");

            var countToShowToNostradamus = selected.Count(p => p.Role.IsMafia(Role));
            var isAre = countToShowToNostradamus > 1 ? "are" : "is";
            Console.WriteLine($"There {isAre} {countToShowToNostradamus} Mafia(s) in your selection");

        }

        public void Undo(GameRound round)
        {
            
        }
    }
}
