using AutomationAPI.Models;
using AutomationAPI.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationAPI.StepDefinitions
{
    [Binding]
    public class ListUserSteps : Helper
    {        
        [Given(@"User send GET request with ""([^""]*)""")]
        public void GivenUserSendGETRequestWith(string resource)
        {
            _restResponse= GetRequest(resource);
        }

        [Then(@"Verify whether the status code ""([^""]*)""")]
        public void ThenVerifyWhetherTheStatusCode(string statuscode)
        { 
            var result=GetStatusCode();
            Assert.AreEqual(Int32.Parse(statuscode) ,result, "Verfied The status code");
        }

        [Then(@"Verify whether the ""([^""]*)"" exist in User's list")]
        public void ThenVerifyWhetherTheExistInUsersList(string userName)
        {
            var result = CheckUserNameExist(userName);
            Assert.True(result, $"Verified that the user {userName} is exist");
        }

    }
}
