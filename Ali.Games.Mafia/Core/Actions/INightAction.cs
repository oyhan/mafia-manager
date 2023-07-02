using Ali.Games.Mafia.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions
{
    public interface INightAction : IAction
    {
        public string Ability { get;}
        public Player From { get; set; }

        public Player To { get; set; }
        public Action<GameRound,Player> Action { get; }

       

    }
}
