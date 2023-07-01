using Ali.Games.Mafia.Core;
using Ali.Games.Mafia.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.LastMoveCards
{
    public class Handcalf : ILastMoveCard
    {
        public string Name => "Handcalf";

        public Player From { get; set; }
        public Player To { get; set; }

        public void Do(GameRound round)
        {
            var players = round.Alives;

            var selectedPlayer = ConsoleColor.White
                .ShowAndPickOneOption(players,
                $@"Pick the one who you want to take the ability off him/her: ");

            Console.WriteLine($"{selectedPlayer.Name} can not do his job in next night");

            round.Disabled.Add(selectedPlayer);
            To = selectedPlayer;

            round.Game.UsedCards.Add(this);
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
