using Ali.Games.Mafia.Core.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core
{
    public class GameManager
    {
        public static List<IAction> Actions { get; internal set; }

        public static IAction GetNextStep(GameRound currentState, Game game)
        {
            var index = currentState.CurrentAction?.Order;
            IAction action;
            if (index !=null)
            {
                action = Actions.ToList()[index.Value + 1];
            }
            else
            {
                action = Actions.FirstOrDefault();
            }
            currentState.CurrentAction = action;

            return action;

        }
    }
}
