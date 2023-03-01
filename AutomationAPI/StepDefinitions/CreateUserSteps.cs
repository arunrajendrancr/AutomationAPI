using AutomationAPI.Models;
using AutomationAPI.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationAPI.StepDefinitions
{
    [Binding]
    public class CreateUserSteps :Helper
    {
        [Given(@"User send Post request with ""([^""]*)"" with ""([^""]*)"" And ""([^""]*)""")]
        public void GivenUserSendPostRequestWith(string resource,string userName,string userJob)
        {
            var payload = new User()
            {
                name = userName,
                job = userJob
            };
            _restResponse = CreatePostRequest(resource , payload);   
        }

        [Then(@"Verify whether the status code is ""([^""]*)""")]
        public void ThenVerifyWhetherTheStatusCodeIs(string statusCode)
        {
            var apiStatusCode= (int)_restResponse.StatusCode;
            var intStatusCode= Int32.Parse(statusCode);
            Assert.AreEqual(apiStatusCode, intStatusCode,  "Verified the created user status code");
        }

        [Then(@"Verify Whether the ""([^""]*)"" And ""([^""]*)"" Is Same")]
        public void ThenVerifyWhetherTheAndIsSame(string userName, string userJob)
        {
            var userDetails = JsonConvert.DeserializeObject<CreateUserModel>(_restResponse.Content);

            Assert.AreEqual(userName, userDetails.name, "Verified the created user name");
            Assert.AreEqual(userJob, userDetails.job, "Verified the created user job");
        }
    }
}
