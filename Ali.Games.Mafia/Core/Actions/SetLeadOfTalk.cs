using Ali.Games.Mafia.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions
{
    public class SetLeadOfTalk : IAction
    {
        private List<Player> _list;

        public GamePhase Phase=> GamePhase.Day;
        
        public int Order => 0;

        public void Do(GameRound round)
        {
            _list = round.Alives;
            if (round.Number == 0)
            {
               var leadOfTalkPlayer =  ConsoleColor.DarkGreen.ShowAndPickOneOption(round.Alives, "Who wants to be the lead of talk?");

               
                var indexOfLead = round.Alives.IndexOf(leadOfTalkPlayer);
                if (indexOfLead == 0) { return; }


                ReOrderList(indexOfLead,round);

            }
            else
            {
                var leadIndex = 2;
                ReOrderList(leadIndex, round);

            }

        }

        private void ReOrderList(int indexOfLead , GameRound round)
        {
            var count = round.Alives.Count;
            
            var indecie = round.Alives
                   .Select(c => round.Alives.IndexOf(c))
                   .Select(i => i - indexOfLead <
                   0 ? i+(count - indexOfLead) : i - indexOfLead).ToList();
            var orderedList = new Player[count];

            for (int i = 0; i < count; i++)
            {
                var newIndex = indecie[i];
                orderedList[newIndex] = round.Alives[i];
            }

            round.Alives = orderedList.ToList();
        }

        public void Undo(GameRound round)
        {
            round.LeadOfTalk = null;
            round.DoneActions.Remove((IAction)this);
            round.Alives = _list;
        }
    }
}
