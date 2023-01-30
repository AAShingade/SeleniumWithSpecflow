using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QKartTestAutomation.Pages
{
    public class RegisterationPage
    {
        private IWebDriver driver;
        public RegisterationPage(IWebDriver driver) => this.driver = driver;
        private IWebElement registerButton => driver.FindElement(By.XPath("//button[text()='Register']"));
        private IWebElement txtusername => driver.FindElement(By.Id("username"));

        private IWebElement txtpassword => driver.FindElement(By.Id("password"));

        private IWebElement txtconfirmpassword => driver.FindElement(By.Id("confirmPassword"));

        private IWebElement btnregisterNowButton => driver.FindElement(By.XPath("//button[text()='Register Now']"));

        public void EnterUserNamePassword(string username, string password)
        {
            txtusername.SendKeys(username);
            txtpassword.SendKeys(password);
        }

        public void EnterConfirmPassword(string password)
        {
            txtconfirmpassword.SendKeys(password);
        }

        public void ClickRegisterButton()
        {
            btnregisterNowButton.Click();
        }
    }
}
