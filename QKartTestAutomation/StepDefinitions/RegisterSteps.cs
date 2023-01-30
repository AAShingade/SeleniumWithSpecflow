using NUnit.Framework;
using QKartTestAutomation.Factory;
using QKartTestAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QKartTestAutomation.StepDefinitions
{
    [Binding]
    public class RegisterSteps
    {
        private DriverHelper _driverHelper;
        private RegisterationPage regPage;
        private PageObjectManager pageobjectManager;

        public RegisterSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            pageobjectManager = new PageObjectManager(_driverHelper.driver);
            regPage = pageobjectManager.GetRegPage();
        }
        [Given(@"User is on Registeration page")]
        public void GivenUserIsOnRegisterationPage()
        {
            _driverHelper.driver.Url = "https://crio-qkart-frontend-qa.vercel.app/register";
        }
        [Scope(Feature = "Register User")]
        [When(@"User enters (.*) and (.*)")]
        public void WhenUserEntersTestuser_AndTest(string username, string password)
        {
            regPage.EnterUserNamePassword(username, password);
        }

        [When(@"User enters confirm (.*)")]
        public void WhenUserEntersConfirmTest(string password)
        {
            regPage.EnterConfirmPassword(password);
        }

        [When(@"User clicks on RegisterButton")]
        public void WhenUserClicksOnRegisterButton()
        {
            regPage.ClickRegisterButton();
        }

        [Then(@"User navigates to Login Page")]
        public void ThenUserNavigatesToLoginPage()
        {
            Assert.IsTrue(_driverHelper.driver.Url.Contains("login"), "User failed to register");
        }
    }
}
