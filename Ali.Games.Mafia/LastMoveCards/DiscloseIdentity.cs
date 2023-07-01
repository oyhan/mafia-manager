using Ali.Games.Mafia.Core;
using Ali.Games.Mafia.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.LastMoveCards
{
    public class DiscloseIdentity : ILastMoveCard
    {
        public string Name => "DiscloseIdentity";

        public Player From { get; set; }
        public Player To { get; set; }

        public void Do(GameRound round)
        {
            var fired = round.Fired;
            Console.WriteLine($"Say this loudly: {round.Fired.Name} is the {round.Fired.Role.Name} of the game");
            fired.Revealed = true;

        }

        public void Undo(GameRound round)
        {
            return;
        }
    }
}
