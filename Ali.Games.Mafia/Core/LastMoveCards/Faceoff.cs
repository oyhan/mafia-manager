using Ali.Games.Mafia.Core;
using Ali.Games.Mafia.Extensions;

namespace Ali.Games.Mafia.LastMoveCards
{
    public class Faceoff : ILastMoveCard
    {
        public string Name => "Faceoff";

        public Player From { get; set; }
        public Player To { get; set; }

        public void Do(GameRound round)
        {
            Console.WriteLine("Game goes to Night mode ");
            Console.BackgroundColor= ConsoleColor.DarkBlue;
            var fired = round.Fired;
            From = fired;
            var players = round.Alives;

            var selectedPlayer = ConsoleColor.White
                .ShowAndPickOneOption(players, 
                $@"Show one of the following players to put the Faceoff card in front :");
            To = selectedPlayer;

            var role = selectedPlayer.Role;
            selectedPlayer.Role = fired.Role;
            fired.Role = role ;
            round.Game.UsedCards.Add(this);

        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
