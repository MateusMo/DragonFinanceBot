using DragonFinanceBot.AsciiArts;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DragonFinanceBot.Bot
{
    public class CoinMarketCapContext
    {
        //Agora eu posso tirar
        //essa dependência da
        //Classe
        private static IWebDriver _driver;
        public CoinMarketCapContext(IWebDriver driver)
        {
            //vou receber o driver pelo
            //Construtor
            _driver = driver;
        }

        public void CoinMarketCapTrigger()
        {
            CoinMarketCapConsole();
            NavigateToWebsite();
        }

        public static void CoinMarketCapConsole()
        {
            Console.Clear();
            Console.WriteLine(Dragon.CoinMarketCapDragon());
        }

        public static void NavigateToWebsite()
        {
            _driver
                .Navigate()
                .GoToUrl("https://coinmarketcap.com");

            Scraping();
        }

        public static void Scraping()
        {
            IWebElement containerTable = _driver.FindElement(By.ClassName("sc-66133f36-2"));

            string tableHtml = containerTable.GetAttribute("innerHTML");

            var doc = new HtmlDocument();
            doc.LoadHtml(tableHtml);

            var rows = doc.DocumentNode.SelectNodes("//table/tbody/tr");

            if (rows != null)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                Console.WriteLine("|        Name        |        Price        |        7d %        |        Market Cap        |");
                Console.WriteLine("-------------------------------------------------------------------------------------------");

                foreach (var row in rows)
                {
                    var columns = row.SelectNodes("td");
                    var conditions =
                        (
                            columns != null &&
                            columns.Count > 7 &&
                            columns[2].InnerText.Any() &&
                            columns[3].InnerText.Any() &&
                            columns[6].InnerText.Any() &&
                            columns[7].InnerText.Any()
                        );
                    if (conditions)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"|    {columns[2].InnerText.Trim() ?? "Dado não disponível"}    |    {columns[3].InnerText.Trim() ?? "Dado não disponível"}    |    {columns[6].InnerText.Trim() ?? "Dado não disponível"}    |    {columns[7].InnerText.Trim() ?? "Dado não disponível"}    |");
                        Console.WriteLine("-------------------------------------------------------");
                    }
                }

                Choose();
            }
        }

        public static void Choose()
        {
            Console.WriteLine("Digite 1 para encerrar o bot");
            Console.WriteLine("Digite 2 para voltar ao menu");
            var option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                Environment.Exit(0);
            }
            else
            {
                Menu.ShowMenu();
            }
        }
    }
}
