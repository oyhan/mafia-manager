using Ali.Games.Mafia.Roles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Roles
{
    internal  class RolesConstants
    {
        public static List<Role> Roles => JsonConvert.DeserializeObject<List<Role>>(File.ReadAllText("Roles.json"));

        public Role this[string roleName]
        {
            get 
            {
                var role  =  Roles.FirstOrDefault(c=>c.Name == roleName);
                if (role == null) return null;
                return role;
            }
        }
    }
}
