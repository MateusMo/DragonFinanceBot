using DragonFinanceBot.AsciiArts;
using DragonFinanceBot.Menu;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFinanceBot.Bot
{
    public class InfoMoneyContext
    {
        //Idem aqui
        private static IWebDriver _driver;

        public InfoMoneyContext(IWebDriver driver)
        {
            _driver = driver;
        }

        public void InfoMoneyTrigger()
        {
            InfoMoneyStartConsole();
            NavigateToWebsite();
        }

        public void InfoMoneyStartConsole()
        {
            Console.Clear();
            Console.WriteLine(Dragon.InfoMoneyDragon());
        }

        public static void NavigateToWebsite()
        {
            _driver
                .Navigate()
                .GoToUrl("https://www.infomoney.com.br/ferramentas/altas-e-baixas/");
            
            Scraping();
        }

        public static void Scraping()
        {
            IWebElement containerTable = 
                _driver.FindElement(By.Id("container_table"));
        
            string tableHtml = 
                containerTable.GetAttribute("innerHTML");
            
            var doc = new HtmlDocument();
            doc.LoadHtml(tableHtml);
            var rows = doc.DocumentNode.SelectNodes("//table/tbody/tr");

            if (rows != null)
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("|    Ativo    |    Data    |    Último (R$)    |    VAR. DIA (%)    |");
                Console.WriteLine("--------------------------------------------------------------------");
                foreach (var row in rows)
                {
                    var columns = row.SelectNodes("td");

                    if (columns != null && columns.Count >= 10)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"|    {columns[0].InnerText.Trim()}    |    {columns[1].InnerText.Trim()}    |    {columns[2].InnerText.Trim()}    |    {columns[3].InnerText.Trim()}    |");
                        Console.WriteLine("------------------------------------------------------------");
                    }
                }

            }

            Choose();
        }

        public static void Choose()
        {
            Console.WriteLine("Digite 1 para encerrar o bot");
            Console.WriteLine("Digite 2 para voltar ao menu");
            var option = int.Parse(Console.ReadLine());
            if(option == 1)
            {
                Environment.Exit(0);
            } else
            {
                Menu.ShowMenu();
            }
        }
    }
}
