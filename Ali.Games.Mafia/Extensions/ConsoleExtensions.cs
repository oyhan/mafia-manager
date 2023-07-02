using Ali.Games.Mafia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ali.Games.Mafia.Extensions
{
    public static class ConsoleExtensions
    {
        public static T ShowAndPickOneOption<T>(this ConsoleColor color, IList<T> items, string message) where T : IHasName
        {
            System.Console.WriteLine($@"{message} :

{string.Join("   ", items.Select(c => $"{items.IndexOf(c) + 1}- {c.Name}"))}");
            var playerNo = 0;
            while (!int.TryParse(System.Console.ReadLine(), out playerNo) || playerNo > items.Count)
            {
                System.Console.WriteLine("Invalid input try again");
            }
            var selectedItem = items[playerNo - 1];

            return selectedItem;
        }

        public static List<T> ShowAndPickMultipleOption<T>(this ConsoleColor color, IList<T> items,int options, string message) where T : IHasName
        {
            var selection = new List<T>();
            for (int i = 0; i < options; i++)
            {
                selection.Add(ShowAndPickOneOption(color, items, message));
            }

            return selection;
        }
    }
}
