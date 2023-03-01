using AutomationAPI.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationAPI.StepDefinitions
{
    [Binding]
    public class SingleUserSteps :Helper
    {
        [Then(@"Verify whether the Name is ""([^""]*)""")]
        public void ThenVerifyWhetherTheNameIs(string name)
        {
           var apiName= GetSingleUserDetails();
            Assert.AreEqual(name, apiName,"Verified that the user name is same");
        }
    }
}
