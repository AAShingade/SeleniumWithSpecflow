using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QKartTestAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement txtusername => driver.FindElement(By.Id("username"));

        private IWebElement txtpassword => driver.FindElement(By.Id("password"));

        private IWebElement btnlogin => driver.FindElement(By.XPath("//button[text()='Login to QKart']"));

        public void EnterUserCred(string username, string password)
        {
            txtusername.SendKeys(username);
            txtpassword.SendKeys(password);
        }

        public void ClickLogin()
        {
            btnlogin.Click();
        }
    }
}
