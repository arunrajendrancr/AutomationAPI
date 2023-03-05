using AutomationAPI.Models;
using AutomationAPI.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationAPI.StepDefinitions
{
    [Binding]
    public class CreateUserSteps :Helper
    {

        [When(@"Verify Whether the ""([^""]*)"" And ""([^""]*)"" Is Same")]
        public void ThenVerifyWhetherTheAndIsSame(string userName, string userJob)
        {
            var userDetails = JsonConvert.DeserializeObject<CreateUserModel>(_restResponse.Content);
            if(userDetails != null) { 
            Assert.AreEqual(userName, userDetails.name, "Verified the created user name");
            Assert.AreEqual(userJob, userDetails.job, "Verified the created user job");
            }
        }

    }


}
