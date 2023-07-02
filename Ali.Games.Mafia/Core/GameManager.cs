using Ali.Games.Mafia.Core.Actions;
using Ali.Games.Mafia.Core.Actions.Day;
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
            var steps = game.Steps;
           
            var dayActions = Actions.Where(c => c is IDayAction);
            var nightActions = Actions.Where(c => c is INightAction);
            var round = currentState.Number ;
            var actionNumber = currentState.CurrentAction.Order;

            var step =round<5 ?steps[round] : ;

            var filteredActions = Actions
                .Where(c => step.Actions.Contains(c.GetType().Name))
                .Where(c=>c.Order!=actionNumber)
                .OrderBy(c=>c.Order);

            //a round finished
            if (filteredActions.Count()==0)
            {
                var nextRound = GetNextRound(currentState);


            }

            if (round == 0)
            {
                return dayActions.First(c => c is PlayersTalk);
            }
            
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

        private static GameRound GetNextRound(GameRound fromRound)
        {
            var from = fromRound.CurrentPhase;
            var to = from ==GamePhase.Day? GamePhase.Night: GamePhase.Day;
            
            var newRound = new GameRound()
            {
                Muted = fromRound.MutedNextRound,
                Alives = fromRound.Alives,
                Number = fromRound.Number++,
                CurrentPhase = to,
                Disabled = fromRound.DisabledNextRound,
                
            };

            return newRound;
        }
    }
}
