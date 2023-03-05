using AutomationAPI.Models;
using AutomationAPI.Utility;
using TechTalk.SpecFlow.Assist;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TechTalk.SpecFlow;
using System.Reflection.Metadata;

namespace AutomationAPI.StepDefinitions
{
    [Binding]
    public  class UpdateUserSteps : Helper
    {
      
        [When(@"Verify Whether the ""([^""]*)"" And ""([^""]*)"" Is Updated")]
        public void ThenVerifyWhetherTheAndIsUpdated(string userName, string userJob)
        {
            var userDetails = JsonConvert.DeserializeObject<UpdateUserModel>(_restResponse.Content);
            if (userDetails != null)
            {
                Assert.AreEqual(userName, userDetails.name, "Verified the created user name");
                Assert.AreEqual(userJob, userDetails.job, "Verified the created user job");
            }
        }

    }
}
