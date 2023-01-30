using NUnit.Framework;
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
    public class HomeSteps
    {
        private DriverHelper _driverHelper;
        private PageObjectManager pageobjectManager;
        private HomePage homepage;

        public HomeSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            pageobjectManager = new PageObjectManager(_driverHelper.driver);
            homepage = pageobjectManager.GetHomePage();
      
        }

        [Then(@"User navigates to Home Page and UserName is displayed")]
        public void ThenUserNavigatesToHomePageAndUserNameIsDisplayed(Table table)
        {
            String acutalUsername = homepage.GetUserName();
            dynamic user = table.CreateDynamicInstance();
            String expectedUsername = user.UserName;
            Assert.That(expectedUsername.Equals(acutalUsername), "User is not navigated to home page and username not disaplyed");
        }
    }
}
