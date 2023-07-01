using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Day
{
    internal class Vote : IDayAction
    {
        public int Order => 2;
        public void Do(GameRound round)
        {
            //if (round.CurrentAction is SetLeadOfTalk)
            {
                foreach (var player in round.Alives)
                {
                    Console.WriteLine($"{player.Name} votes:");
                    int vote = 0;
                    while (!int.TryParse(Console.ReadLine(), out  vote))
                    {
                        Console.WriteLine("Invalid input try again");
                    }
                    round.Votes.Add((player, vote));

                }
            }
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
