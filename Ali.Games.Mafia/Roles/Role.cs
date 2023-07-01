using Ali.Games.Mafia.Abilities;
using Ali.Games.Mafia.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Roles
{
    public  class Role
    {
        public string Name { get; set; }

        public Side Side { get; set; }
        public List<Ability> Abilities { get; set; } 
    }
}
