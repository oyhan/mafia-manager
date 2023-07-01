using Ali.Games.Mafia.Core;
using Ali.Games.Mafia.Core.Actions;
using Ali.Games.Mafia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.LastMoveCards
{
    public interface ILastMoveCard : IHasName
    {
        void Do(GameRound round);

        void Undo(GameRound round);
        public Player From { get; set; }
        public Player To { get; set; }

    }
}
