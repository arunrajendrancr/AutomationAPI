using AutomationAPI.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace AutomationAPI.StepDefinitions
{
    [Binding]
    public class SingleUserSteps :Helper
    {
        [When(@"Verify whether the Name is ""([^""]*)""")]
        public void WhenVerifyWhetherTheNameIs(string name)
        {
            var apiName = GetSingleUserDetails();
            Assert.AreEqual(name, apiName, "Verified that the user name is same");
        }

    }
}
