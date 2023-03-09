using AutomationAPI.Data;
using AutomationAPI.Models;
using AutomationAPI.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers;
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
    public class ListUserSteps : Helper
    {

        [Then(@"Verify whether the ""([^""]*)"" exist in User's list")]
        public void ThenVerifyWhetherTheExistInUsersList(string userName)
        {
            var result = CheckUserNameExist(userName);
            Assert.True(result, $"Verified that the user {userName} is exist");
        }
    }
}
