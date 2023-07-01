using Ali.Games.Mafia.Core;
using Ali.Games.Mafia.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.LastMoveCards
{
    public class BeautifulMind : ILastMoveCard
    {
        public string Name => "BeautifulMind";

        public Player From { get; set; }
        public Player To { get; set; }

        public void Do(GameRound round)
        {
            var firedPlayer = round.Fired;
            From = firedPlayer;
            Console.WriteLine("Who is the Nostradamus?");
            var players = round.Alives;

            var selectedPlayer = ConsoleColor.White
                .ShowAndPickOneOption(players,
                $@"Pick the one who you think is Nostradamus: ");

            var isNostradamus = selectedPlayer.Role.Side == Side.Independ;
            if (isNostradamus)
            {
                Console.WriteLine($"Correct! {selectedPlayer.Name} is the {selectedPlayer.Role.Name} of the game");
                round.Alives.Add(firedPlayer);
                round.Alives.Remove(selectedPlayer);
            }
            Console.WriteLine($"No..... {firedPlayer.Name} should leave the game");
            
            round.Game.UsedCards.Add(this);
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
