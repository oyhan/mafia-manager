using Ali.Games.Mafia.LastMoveCards;
using Ali.Games.Mafia.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core
{
    public class Game
    {
        public bool IsDay { get; set; }
        public List<Player> Players { get; set; }
        public List<GameRound> Rounds { get; set; } = new();

        public GameRound CurrentState { get; set; }
        public GameRound PrevStep { get; set; }

        public Player LeadOfTalk { get; set; } = null;
        public List<ILastMoveCard> UsedCards { get; set; } = new();

        public void Start()
        {
            //GoNextStep();
            while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Enter:
                        GoNextStep();
                        break;

                    case ConsoleKey.Backspace:
                        //GoPreviousStep();
                        break;

                    default:
                        break;
                }
            }
           


        }

        private void GoNextStep()
        {
            var action = GameManager.GetNextStep(CurrentState, this);
            action.Do(CurrentState);

        }
    }
}
