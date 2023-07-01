using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Day
{
    public class VoteResult : IDayAction
    {
        public int Order => 5;


        public void Do(GameRound round)
        {
            var totalPeopleCount = round.DefenceVote.Count;
            if (totalPeopleCount == 0) { return; }
            if (totalPeopleCount == 1) 
            {
                var shouldExit = round.DefenceVote.First().Item2 > round.ExitThreashold;
                if (shouldExit)
                {
                    SetAndAnnounceFired(round, round.DefenceVote.First().Item1);
                    return;
                }
            }
            var sameVoting = round.DefenceVote.GroupBy(c => c.Item2);
            var maxVoted = round.DefenceVote.MaxBy(c => c.Item2);
            if (sameVoting.Any(v=>v.First().Item2==maxVoted.Item2 && v.Count()>1))
            {
                throw new NotImplementedException("2 players should do death match");
            }
            SetAndAnnounceFired(round, maxVoted.Item1);
        }

        private void SetAndAnnounceFired(GameRound round, Player item1)
        {
            round.Fired = item1;
            round.Alives.Remove(item1);
            Console.WriteLine($"{item1.Name} leaves the game");
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
