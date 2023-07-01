using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions
{
    public interface IAction
    {

        public int Order { get; }
        void Do(GameRound round);

        void Undo(GameRound round);

    }
}
