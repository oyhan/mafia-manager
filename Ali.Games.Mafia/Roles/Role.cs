using Ali.Games.Mafia.Abilities;
using Ali.Games.Mafia.Core;
using Ali.Games.Mafia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Roles
{
    public class Role : IHasName
    {
        public string Name { get; set; }


        public Side Side { get; set; }
        public bool IsMafia(Role caller)
        {
            var isGodFather = Name.Equals("GodFather", StringComparison.InvariantCultureIgnoreCase);
            var callerIsCitizenKane = caller.Name.Equals("CitizenCane", StringComparison.InvariantCultureIgnoreCase);


            if (Side == Side.Mafia)
            {
                if (callerIsCitizenKane) return true;

                if (isGodFather) return false;

                else
                {
                    return true;
                }
            }

            return false;

        }
        public List<Ability> Abilities { get; set; }
    }
}
