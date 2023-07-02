using Ali.Games.Mafia.Core.LastMoveCards;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Core.Actions
{
    public static class Registrar
    {
        public static IServiceCollection AddActions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(c => 
            c.GetInterface(typeof(IAction).Name) 
            != null && !c.IsInterface && !c.IsAbstract);

            foreach (var type in types)
            {
                services.AddScoped(typeof(IAction), type);
            }

            return services;
        }

        public static IServiceCollection AddLastMoveCards(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(c =>
            c.GetInterface(typeof(ILastMoveCard).Name)
            != null && !c.IsInterface && !c.IsAbstract);

            foreach (var type in types)
            {
                services.AddScoped(typeof(ILastMoveCard), type);
            }

            return services;
        }
    }

}
