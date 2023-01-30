using OpenQA.Selenium;
using QKartTestAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QKartTestAutomation.Factory
{
    public class PageObjectManager
    {
        private RegisterationPage regpage;

        private IWebDriver driver;

        private LoginPage loginpage;

        private HomePage homepage;
        public PageObjectManager(IWebDriver driver)
        {
            this.driver = driver;
        }
        public RegisterationPage GetRegPage()
        {
            return regpage == null ? regpage = new RegisterationPage(driver) : regpage;
        }

        public LoginPage GetLoginPage()
        {
            return loginpage == null ? loginpage = new LoginPage(driver) : loginpage;
        }

        public HomePage GetHomePage()
        {
            return homepage == null ? homepage = new HomePage(driver) : homepage;
        }
    }
}
