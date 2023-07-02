using Ali.Games.Mafia.Abilities;
using Ali.Games.Mafia.Core.Roles;
using Ali.Games.Mafia.Extensions;
using Ali.Games.Mafia.Roles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions.Night
{
    public abstract class BaseNightAction : INightAction
    {

        public virtual string RoleName { get; }
        public abstract Action<GameRound, Player> Action { get; }

        public virtual Role Role => new RolesConstants()[RoleName];

        public abstract Func<GameRound, List<Player> > GetTargets { get; }
        public abstract string Ability { get;  }
        public Player From { get ; set ; }
        public Player To { get; set; }

        public int Order => throw new NotImplementedException();

        public virtual void Do(GameRound round)
        {
            var targets = GetTargets(round);
            var message = $@"***{RoleName}***: 
Select one player to {Ability}.";
            var target = ConsoleColor.Red.ShowAndPickOneOption(targets, message);
            var subject = round.Alives.FirstOrDefault(c => c.Is(RoleName));
            From = subject;
            To = target;
            Execute(subject, target, round);
        }

        public virtual void Execute(Player? subject, Player? @object, GameRound round)
        {
            if (subject is null)
            {
                Console.WriteLine($"{RoleName} is not alive just say the instractions");
                return;
            }
            var subjectName = subject.Name;
            var subjectRole = subject.Role.Name;

            var objectName = @object.Name;
            var objectRole = @object.Role.Name;
            var log = $"{subjectName}({subjectRole}) {Ability} {objectName}({objectRole})";
            Action(round, @object);
            Logger.Log(log);
        }

        public void Undo(GameRound round)
        {
            throw new NotImplementedException();
        }
    }
}
