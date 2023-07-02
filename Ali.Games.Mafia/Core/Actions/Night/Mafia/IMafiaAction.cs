using Ali.Games.Mafia.Core.Interfaces;
using Ali.Games.Mafia.Core.Roles;
using Ali.Games.Mafia.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Night.Mafia
{
    internal interface IMafiaAction : INightAction
    {
    }

    internal class SixthSense : BaseNightAction, IMafiaAction
    {
        public string Name => "حس ششم";

        public int Order => 0;

        public override Action<GameRound, Player> Action => SixthSenseAction;


        public override Func<GameRound, List<Player>> GetTargets => (GameRound round) => round.Citizens;

        public override string Ability => "6thSense";

        public void SixthSenseAction(GameRound round,Player victim) 
        {
            var players = round.Citizens;

            var roles = RolesConstants.Roles;

            //var chosenPlayer = ConsoleColor.White.ShowAndPickOneOption(players, $"***SixthSense***: Select the one you want to " +
            //    $"guess the role:");

            roles = roles.Where(r => r.Side == Side.Citizen).ToList();
            var chosenRole = ConsoleColor.White.ShowAndPickOneOption(roles, $"You think the selected person is : ");
            

            if (chosenRole.Name.Equals(victim.Role.Name,StringComparison.InvariantCultureIgnoreCase))
            {
                round.Alives.Remove(victim); 
                round.Deads.Add(victim);
                round.Slaughtered.Add(victim);
                round.Disabled.Add(victim);
            }


        }
       
        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }

    internal class Deal :BaseNightAction, IMafiaAction
    {
        public string Name => "خریداری";

        public override Action<GameRound, Player> Action => DealAction;

        private void DealAction(GameRound round, Player selectedPlayer)
        {
            Console.WriteLine("Say loudly : Mafia is buying ... Anybody I touched should wake up");

            if (selectedPlayer.Role==null)
            {
                selectedPlayer.Side = Side.Mafia;
                Console.WriteLine($"Awake {selectedPlayer.Name}, He/She now plays in Mafia side");
            }
        }

        public override Func<GameRound, List<Player>> GetTargets => (GameRound round)=>round.Citizens;

        public override string Ability => "Buy";
    }
    internal class Shot : IMafiaAction
    {
        public string Name => "شلیک";

    }
}
