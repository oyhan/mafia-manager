using Ali.Games.Mafia.Core;
using Ali.Games.Mafia.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.LastMoveCards
{
    public class SilenceOfTheLambs : ILastMoveCard
    {
        public string Name => "SilenceOfTheLambs";

        public Player From { get; set; }
        public Player To { get; set; }

        public void Do(GameRound round)
        {
            var players = round.Alives;
            var totalCount = players.Count();
            var half = round.Game.Players.Count/2 ;
            var howManyShouldGetSilenced = totalCount>=half ? 2 :1;
            for (int i = 0; i < howManyShouldGetSilenced; i++)
            {
                var selectList = players.Except(round.MutedNextRound).ToList();
                var message = "Select the one you want to mute";
                round.MutedNextRound.Add(ConsoleColor.White.ShowAndPickOneOption(selectList, message));
            }            
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
