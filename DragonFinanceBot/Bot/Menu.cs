using DragonFinanceBot.AsciiArts;
using DragonFinanceBot.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFinanceBot.Bot
{
    public class Menu
    {
        public static void ShowMenu()
        {
            var asciiImage
                = Dragon.GetDragon();
            System.Console.WriteLine(asciiImage);

            var menu = FinanceMenu.ShowMenu();
            System.Console.WriteLine(menu);

            System.Console.ReadLine();

        }
    }
}
