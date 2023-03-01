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

namespace AutomationAPI.StepDefinitions
{
    [Binding]
    public  class UpdateUserSteps : Helper
    {
        [Given(@"User send Put request with ""([^""]*)"" with ""([^""]*)"" And ""([^""]*)"" to update")]
        public void GivenUserSendPutRequestWithAndToUpdate(string resource, string userName,  string userJob)
        {
            var payload = new User()
            {
                name = userName,
                job = userJob
            };
            _restResponse = PutRequest(resource, payload);
        }


        [Then(@"Verify Whether the ""([^""]*)"" And ""([^""]*)"" Is Updated")]
        public void ThenVerifyWhetherTheAndIsUpdated(string userName, string userJob)
        {
            var userDetails = JsonConvert.DeserializeObject<UpdateUserModel>(_restResponse.Content);

            Assert.AreEqual(userName, userDetails.name, "Verified the created user name");
            Assert.AreEqual(userJob, userDetails.job, "Verified the created user job");
        }


        [Given(@"User send Patch request with ""([^""]*)"" with ""([^""]*)"" And ""([^""]*)"" to update")]
        public void GivenUserSendPatchRequestWithWithAndToUpdate(string resource, string userName, string userJob)
        {
            var payload = new User()
            {
                name = userName,
                job = userJob
            };
            _restResponse = PatchRequest(resource, payload);
        }


        [Given(@"User send Patch request with ""([^""]*)"" and payload")]
        public void GivenUserSendPatchRequestWithAndPayload(string resource, Table table)
        {
            var dictionary = ToDictionary(table);
            var payload = new User()
            {
                name = dictionary["Name"],
                job = dictionary["Job"]
        };
            _restResponse = PatchRequest(resource, payload);
        }



    }
}
