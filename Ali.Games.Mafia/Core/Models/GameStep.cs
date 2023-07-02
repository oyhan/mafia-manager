using Ali.Games.Mafia.Core.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Models
{
    public class GameStep
    {
        public string Name { get; set; }
        public int Round { get; set; }
        public string[] Actions { get; set; }
    }
}
