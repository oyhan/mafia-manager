using Ali.Games.Mafia.Core.Interfaces;
using Ali.Games.Mafia.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core
{
    public class Player : IHasName
    {
        public string Name { get; set; }
        public Side Side { get; set; } = Side.Citizen;
        public Role Role { get; set; } = null;
        public bool Revealed { get;  set; }
    }
}
