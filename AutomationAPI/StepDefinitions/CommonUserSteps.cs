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
    public class CommonUserSteps :Helper
    {

       
        [Given(@"User Create ""([^""]*)"" request with payload")]
        public void GivenUserCreateRequestWithPayload(string requestType, Table table)
        {
           var payload= CreatePayLoad(requestType,table);
            var resource = requestType=="POST"?GetResource(requestType): GetResource(requestType)+ToDictionary(table)["Id"];
            SetRequest(resource, requestType, payload);
        }

        [When(@"User Execute the request")]
        public void WhenUserExecuteTheRequest()
        {
            _restResponse = ExecuteGetRequest();
        }


        [Given(@"User Create ""([^""]*)"" request for ""([^""]*)"" with ""([^""]*)""  and its ""([^""]*)""")]
        public void GivenUserCreateRequestForWithAndIts(string requestType, string user, string parameter, string value)
        {
            var resource = GetResource(requestType, user, parameter) + value;
            SetRequest(resource, requestType);
        }

        [Then(@"Verify whether the status code ""([^""]*)""")]
        public void ThenVerifyWhetherTheStatusCode(string statuscode)
        {
            var result = GetStatusCode();
            Assert.AreEqual(Int32.Parse(statuscode), result, "Verfied The status code");
        }
    }


}
