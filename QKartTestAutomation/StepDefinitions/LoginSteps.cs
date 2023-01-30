using AventStack.ExtentReports.Gherkin.Model;
using QKartTestAutomation.Factory;
using QKartTestAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace QKartTestAutomation.StepDefinitions
{
    [Binding]
    public class LoginSteps : Steps
    {
        private DriverHelper _driverHelper;
        private PageObjectManager pageobjectManager;
        private LoginPage loginpage;
        public LoginSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            pageobjectManager = new PageObjectManager(_driverHelper.driver);
            loginpage = pageobjectManager.GetLoginPage();
        } 

        [Given(@"User is on Login Page")]
        public void GivenUserIsOnLoginPage()
        {
            _driverHelper.driver.Url = "https://crio-qkart-frontend-qa.vercel.app/login";
        }

        [When(@"User enters")]
        public void WhenUserEnters(Table table)
        {
            dynamic cred = table.CreateDynamicInstance();
            loginpage.EnterUserCred(cred.UserName, cred.Password); 
        }

        [When(@"User clicks on Login button")]
        public void WhenUserClicksOnLoginButton()
        {
            loginpage.ClickLogin();
        }

    }
}
