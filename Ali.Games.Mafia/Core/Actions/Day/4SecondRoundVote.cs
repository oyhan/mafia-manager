using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Day
{
    internal class SecondRoundVote : IAction
    {
        public int Order => 4;
        public void Do(GameRound round)
        {
            //if (round.CurrentAction is SetLeadOfTalk)
            {
                var inDefence = round.InDefence;
                foreach (var player in inDefence)
                {
                    Console.WriteLine($"{player.Name} votes:");
                    var vote = int.Parse(Console.ReadLine());
                    round.DefenceVote.Add((player, vote));

                }
               
            }
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
