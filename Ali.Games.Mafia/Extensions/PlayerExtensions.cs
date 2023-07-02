using Ali.Games.Mafia.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Extensions
{
    public static class PlayerExtensions
    {
        public static bool Is(this Player player,string roleName)
        {
            return player.Role.Name.Equals(roleName,StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
