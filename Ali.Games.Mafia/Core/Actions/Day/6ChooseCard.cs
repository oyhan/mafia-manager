using Ali.Games.Mafia.Extensions;
using Ali.Games.Mafia.LastMoveCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Day
{
    public class ChooseCard : IDayAction
    {
        private readonly IEnumerable<ILastMoveCard> lastMoveCards;

        public int Order => 6;

        public ChooseCard(IEnumerable<ILastMoveCard> lastMoveCards)
        {
            this.lastMoveCards = lastMoveCards;
        }
        public void Do(GameRound round)
        {
            var fired = round.Fired;
            var availableCards = lastMoveCards.Except(round.Game.UsedCards).ToList();

            var chosenCard = ConsoleColor.Green
                .ShowAndPickOneOption(availableCards, $@"Last move card : {fired.Name} should select one of the following cards :");

            round.Game.UsedCards.Add(chosenCard);

            Console.WriteLine($"{chosenCard.Name} was selected by {fired.Name}");

            chosenCard.Do(round);
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
