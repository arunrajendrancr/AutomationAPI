using AutomationAPI.Data;
using AutomationAPI.Hooks;
using AutomationAPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
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
        public static RestResponse? _restResponse;
        public static string? baseUrl = IntializeHooks.baseUrl;

       public static void SetRequest(string resource,string requestType, object? payload =null) 
        {
            _restclient = new RestClient(baseUrl);
            switch (requestType)
            {
                case "GET":
                    _restRequest = new RestRequest(resource, Method.Get);
                    break;
                case "POST":
                    _restRequest = new RestRequest(resource, Method.Post);
                    _restRequest = _restRequest.AddJsonBody(payload);
                    break;
                case "PUT":
                    _restRequest = new RestRequest(resource, Method.Put);
                    _restRequest = _restRequest.AddJsonBody(payload);
                    break;
                case "PATCH":
                    _restRequest = new RestRequest(resource, Method.Put);
                    _restRequest = _restRequest.AddJsonBody(payload);
                    break;
            }
        }

            
        public static RestResponse ExecuteRequest()
        {
            if (_restclient != null)
                _restResponse = _restclient.Execute(_restRequest);
            else
                throw new Exception("Restclient is null");
            
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

       

        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static string GetResource(string requestType,string? user=null,string? parameter=null)
        {
            var resource=string.Empty;
            switch(requestType)
            {
                case "GET":
                    if (user == "Single" && parameter == "Id")
                        resource = AppConstants.resource;
                    else if (user == "All" && parameter == "PageNumber")
                        resource = AppConstants.resourceWithPage;
                    else
                        throw new Exception("Invalid data for GET request");
                        break;
                case "POST":
                   resource= AppConstants.Postresource;
                    break;
                case "PUT":
                    resource = AppConstants.resource;
                    break;
                case "PATCH":
                    resource = AppConstants.resource;
                    break;
            }
            return resource;
        }

        public static object CreatePayLoad(string requestType,Table table) 
        {
            var dictionary = ToDictionary(table);
            object payload;
            switch (requestType)
            {
                case "POST":
                    {
                        payload = new User()
                        {
                            name = dictionary["Name"],
                            job = dictionary["Job"]
                        };
                        return Convert.ChangeType(payload, typeof(User)); ;
                    }
                    case "PUT":
                    {
                        payload = new User()
                        {
                            name = dictionary["Name"],
                            job = dictionary["Job"]
                        };
                        return Convert.ChangeType(payload, typeof(User));
                    }
                case "PATCH":
                    {
                        payload = new User()
                        {
                            name = dictionary["Name"],
                            job = dictionary["Job"]
                        };
                        return  Convert.ChangeType(payload,typeof(User));
                       
                    }
                 default: throw new Exception("Invalid RequestType");
        }

          
        }
    }
}
