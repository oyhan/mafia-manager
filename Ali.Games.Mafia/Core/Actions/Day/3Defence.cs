using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Day
{
    internal class Defence : IDayAction
    {
        public int Order => 3;
        public void Do(GameRound round)
        {
            var inDefence = round.InDefence;
            if (inDefence.Count==0)
            {
                Console.WriteLine($"No body in defence");
                return;
            }
            //if (round.CurrentAction is SetLeadOfTalk)
            {
                foreach (var player in round.InDefence)
                {
                    Console.WriteLine($"{player.Name} start talk");
                    Console.ReadKey();
                    round.DefenceTalk.Add(player);

                }
            }
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
