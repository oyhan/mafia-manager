using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Day
{
    internal class CitizenCane : IAction
    {
        public int Order => 1;
        public void Do(GameRound round)
        {
            //if (round.CurrentAction is SetLeadOfTalk)
            {
                foreach (var player in round.Alives)
                {
                    Console.WriteLine($"{player.Name} start talk");
                    Console.ReadKey();
                    round.Talked.Add( player );
                    
                }
            }
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
