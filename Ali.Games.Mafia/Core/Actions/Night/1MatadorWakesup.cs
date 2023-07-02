using Ali.Games.Mafia.Core.Roles;
using Ali.Games.Mafia.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Night
{
    public class MatadorWakesup : BaseNightAction, INightAction
    {
       

        public override string[] RoleName => new string[] { "Matador" };

        public override Action<GameRound, Player> Action => (GameRound round, Player disabled) => round.Disabled.Add(disabled);

        public int Order => 1;

        public override string Ability => "Block";

        public override Func<GameRound, List<Player>> GetTargets => (GameRound round )=>round.Citizens;

        

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
