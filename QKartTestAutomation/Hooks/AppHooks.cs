using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using LivingDoc.Dtos;
using MongoDB.Bson.Serialization.Conventions;
using NUnit.Framework;
using OpenQA.Selenium;
using QKartTestAutomation.Factory;
using System.Configuration;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace QKartTestAutomation.Hooks
{
    [Binding]
    public sealed class AppHooks
    {

        private DriverHelper _driverHelper;
        private static ExtentHtmlReporter reporter;
        private static ExtentReports report;
        [ThreadStatic]
        private static ExtentTest feature; 
        [ThreadStatic]
        private static ExtentTest scenario;
        public AppHooks(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;

        }
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun]
        public static void InitializeReport() 
        {
            reporter = new ExtentHtmlReporter(@"\\");
            report = new ExtentReports();
            report.AttachReporter(reporter);
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            report.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = report.CreateTest<Feature>(featureContext.FeatureInfo.Title);            
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            var browserName = ConfigurationManager.AppSettings["BrowserName"];
            _driverHelper.driver = DriverFactory.InitDriver("Chrome");
        }

        [AfterScenario]
        public void AfterScenario()
        {   
          _driverHelper.driver.Quit();
        }

        [AfterStep]
        public void InsertReportingsteps(ScenarioContext scenariocontext)
        {
                var steptype = scenariocontext.StepContext.StepInfo.StepDefinitionType.ToString();
            var testresult = scenariocontext.ScenarioExecutionStatus;
            if (scenariocontext.TestError == null)
               {
                   if (steptype == "Given")
                       scenario.CreateNode<Given>(scenariocontext.StepContext.StepInfo.Text);
                   else if (steptype == "When")
                       scenario.CreateNode<When>(scenariocontext.StepContext.StepInfo.Text);
                   else if (steptype == "Then")
                       scenario.CreateNode<Then>(scenariocontext.StepContext.StepInfo.Text);
                   else if (steptype == "And")
                       scenario.CreateNode<And>(scenariocontext.StepContext.StepInfo.Text);
               }
               else if (scenariocontext.TestError != null)
               {
                if (steptype == "Given")
                {
                    scenario.CreateNode<Given>(scenariocontext.StepContext.StepInfo.Text).Fail(scenariocontext.TestError.InnerException,MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenshot()).Build()); 
                }
                else if (steptype == "When")
                {
                    scenario.CreateNode<When>(scenariocontext.StepContext.StepInfo.Text).Fail(scenariocontext.TestError.InnerException,MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenshot()).Build());
                }
                else if (steptype == "Then")
                {
                    scenario.CreateNode<Then>(scenariocontext.StepContext.StepInfo.Text).Fail(scenariocontext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenshot()).Build());
                }
            }
               
               //Pending Status
              if (testresult.ToString() == "StepDefinitionPending")
               {
                   if (steptype == "Given")
                       scenario.CreateNode<Given>(scenariocontext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                   else if (steptype == "When")
                       scenario.CreateNode<When>(scenariocontext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
                   else if (steptype == "Then")
                       scenario.CreateNode<Then>(scenariocontext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
               }
        }

        private string GetScreenshot()
        {
            return (((ITakesScreenshot)_driverHelper.driver).GetScreenshot().AsBase64EncodedString);
        }
    }

  
}