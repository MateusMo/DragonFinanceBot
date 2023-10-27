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
        //Caminho do
        //chrome driver
        private readonly string driverPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "Driver\\chromedriver.exe");
        //Elemento webdriver
        private static IWebDriver _driver;

        //Construtor que inicia
        //o chrome driver
        public InfoMoneyContext()
        {
            if(_driver == null)
            {
                _driver =
                    new ChromeDriver(driverPath);
            }
        }

        //Vamos criar um gatilho
        //Para chamar a nossa
        //interação
        //Gatilho
        public void InfoMoneyTrigger()
        {
            InfoMoneyStartConsole();
            NavigateToWebsite();
        }

        //Vamos criar uma ação
        //No nosso console
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
            //chama o nosso
            //webscraping
            HtmlContext();
        }

        //Falta criar um 
        //método com o nosso
        //webscraping

        //Esse método é grande
        //por isso já deixei pronto
        //vou explicar oq ele
        //faz


        public static void HtmlContext()
        {
            //Busca o elemento pelo id
            //esse elemento é a
            //tabela do infomoney
            IWebElement containerTable = 
                _driver.FindElement(By.Id("container_table"));
            //converte a tabela para
            //html
            string tableHtml = 
                containerTable.GetAttribute("innerHTML");
            //Cria novo doc html
            var doc = new HtmlDocument();
            //carrega o doc
            doc.LoadHtml(tableHtml);
            //busca cada linha da tabela
            var rows = doc.DocumentNode.SelectNodes("//table/tbody/tr");

            if (rows != null)
            {
                //printa o header
                //da tabela
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("|    Ativo    |    Data    |    Último (R$)    |    VAR. DIA (%)    |");
                Console.WriteLine("--------------------------------------------------------------------");
                //printa cada linha
                //da tabela
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
                //_driver.Quit();
            }

        }


    }
}
