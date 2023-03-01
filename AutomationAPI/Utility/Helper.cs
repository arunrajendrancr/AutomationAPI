using AutomationAPI.Hooks;
using AutomationAPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace AutomationAPI.Utility
{
    public class Helper
    {
        public static RestClient? _restclient;
        public static RestRequest? _restRequest;
        public static RestResponse _restResponse;
        public static string baseUrl = IntializeHooks.baseUrl;
  
        public static RestResponse GetRequest(string resource)
        {
          
            _restclient = new RestClient(baseUrl);
            _restRequest = new RestRequest(resource, Method.Get);
            _restRequest.AddHeader("Accept", "application/json");
            _restResponse = _restclient.Execute(_restRequest);

            return _restResponse;
        }

        public static int GetStatusCode()
        {
            var statusCode = (int)_restResponse.StatusCode;
            return statusCode;
        }

        public static string GetSingleUserDetails()
        {
            var content = _restResponse.Content;
            var users = JsonConvert.DeserializeObject<SingleUserModel>(content);
            var userName =  string.Format("{0} {1}", users.data.first_name, users.data.last_name) ;
            return userName;
        }

        public static bool CheckUserNameExist(string userName)
        {
            var content = _restResponse.Content;
            var users = JsonConvert.DeserializeObject<ListOfUsersModel>(content);
            var userNames = users.data.Select(x => new { v = string.Format("{0} {1}", x.first_name, x.last_name) }).Select(x => x.v).ToList();
            var result = userNames.Contains(userName);
            return result;
        }

        public static RestResponse CreatePostRequest(string resource, User payload)
        {
           
            _restclient = new RestClient(baseUrl);
            _restRequest = new RestRequest(resource, Method.Post);
            var request= _restRequest.AddJsonBody<User>(payload);
            var result=_restclient.Execute(request);
            return result;
        }

        public static RestResponse PutRequest(string resource, User payload)
        {

            _restclient = new RestClient(baseUrl);
            _restRequest = new RestRequest(resource, Method.Put);
            var request = _restRequest.AddJsonBody<User>(payload);
            var result = _restclient.Execute(request);
            return result;
        }

        public static RestResponse PatchRequest(string resource, User payload)
        {

            _restclient = new RestClient(baseUrl);
            _restRequest = new RestRequest(resource, Method.Patch);
            var request = _restRequest.AddJsonBody<User>(payload);
            var result = _restclient.Execute(request);
            return result;
        }

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }
    }
}
