using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Day
{
    internal class MatadorWakesup : INightAction
    {
        public int Order => 1;
        public void Do(GameRound round)
        {
           round.d
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
