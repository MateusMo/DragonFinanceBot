using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonFinanceBot.Driver
{
    public class DriverInstance
    {

        private readonly string driverPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "Driver\\chromedriver.exe");
        private static IWebDriver _driver;
        public DriverInstance()
        {
            if (_driver == null)
            {
                _driver =
                    new ChromeDriver(driverPath);
            }
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
