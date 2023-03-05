using AutomationAPI.Utility;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationAPI.Hooks
{
    [Binding]
    public class IntializeHooks 
    {
        private static ExtentTest featureName= null!;
        private static ExtentTest scenario= null!;
        private static ExtentReports extent = null!;
        public static string? userName { get; set; }
        public static string? password { get; set; }
        public static string? baseUrl { get; set; }

        public static string reportPath = System.IO.Directory.GetParent(@"../../../").FullName +
           Path.DirectorySeparatorChar + "Report"
           + Path.DirectorySeparatorChar + "Report_" + DateTime.Now.ToString("ddMMyyyy HHmmss") + Path.DirectorySeparatorChar;
        [BeforeTestRun]
        public static void InitializeReport()
        {  
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        [AfterTestRun]
        public static void TearDownReport()
        {     
            extent.Flush();
        }

        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {         
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        [Obsolete]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            } 
        }


        [BeforeScenario]
        [Obsolete]
        public void Initialize()
        {
            var secretValues = new ConfigurationBuilder().AddUserSecrets<IntializeHooks>().Build();
             userName = secretValues["SecretData:userName"];
            password = secretValues["SecretData:password"];
            var config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            var Environment = config.GetSection("Environment").Value;
            baseUrl = config.GetSection($"Environments:{Environment}:Url").Value;
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }
    }

}
