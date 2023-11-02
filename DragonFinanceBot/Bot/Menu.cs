using DragonFinanceBot.AsciiArts;
using DragonFinanceBot.Driver;
using DragonFinanceBot.Menu;
using OpenQA.Selenium;
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

            var driverInstance = new DriverInstance();
            var driver = driverInstance.GetDriver();
            Console.Clear();
            
            var asciiImage
                = Dragon.GetDragon();
            Console.WriteLine(asciiImage);

            var menu = FinanceMenu.ShowMenu();
            Console.WriteLine(menu);

            var option = int.Parse(Console.ReadLine());
            SwitchOption(option,driver);
        }

        public static void SwitchOption(int option, IWebDriver driver)
        {
            switch (option)
            {
                case 1:
                    var infoMoneyContext = new InfoMoneyContext(driver);
                    infoMoneyContext.InfoMoneyTrigger();
                    break;
                case 2:
                    var coinMarketCapContext = new CoinMarketCapContext(driver);
                    coinMarketCapContext.CoinMarketCapTrigger();
                    break;
                case 3:
                    DragonFireContext.GenerateAnimation();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }

    }
}






