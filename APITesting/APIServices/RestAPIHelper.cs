using AventStack.ExtentReports;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{

    public class RestApiHelper<T> where T : class, new()
    {
        public T Get(string url, object pars)
        {
            var type = Method.GET;
            return GetApiInfo(url, pars, type);

        }

        private static T GetApiInfo(string url, object pars, Method type)
        {   
            var request = new RestRequest(type);
            request.AddHeader("Accept", "application/json");
            if (pars != null)
            {
                request.AddObject(pars);
            }

            var client = new RestClient(url);
            IRestResponse reval = client.Execute(request);
            if (reval.IsSuccessful())
            {
                T dtoObject = JsonConvert.DeserializeObject<T>(reval.Content);
                return dtoObject;
            }

            string errorInfo = $"{reval.StatusCode} response code is received, {reval.StatusDescription}";
            Reporter.LogToReport(Status.Error, errorInfo);

            return null;
        }
    
    }
}
