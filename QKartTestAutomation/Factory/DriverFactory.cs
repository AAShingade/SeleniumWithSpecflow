using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QKartTestAutomation.Factory
{
    public class DriverFactory
    {
        public static IWebDriver InitDriver(string drivertype)
        {
            IWebDriver driver = null;
            switch (drivertype)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                deafult:
                    break;
            }
            return driver;
        }
    }
}
