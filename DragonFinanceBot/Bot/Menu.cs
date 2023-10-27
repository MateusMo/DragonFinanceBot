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
            Console.WriteLine(asciiImage);

            var menu = FinanceMenu.ShowMenu();
            Console.WriteLine(menu);
            
            var option = int.Parse(Console.ReadLine());
            SwitchOption(option);
        }

        public static void SwitchOption(int option)
        {
            switch (option)
            {
                case 1:
                    //Caso o usuário digite
                    //1 entra no nosso contexto
                    //da infomoney,
                    //bora testar!!!
                    var infoMoneyContext = new InfoMoneyContext();
                    //Chamada do gatilho
                    infoMoneyContext.InfoMoneyTrigger();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;

            }
        }

    }
}






