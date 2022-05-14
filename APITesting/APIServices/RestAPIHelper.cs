using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public class RestAPIHelper<T> where T : class, new()
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        //public string _baseUrl = "https://api.tmsandbox.co.nz";

        public RestClient SetUrl(string baseUrl, string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            _restClient = new RestClient(url);
            return _restClient;
        }

        public RestRequest CreateGetRequest()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.AddHeader("Accept", "application/json");

            return _restRequest;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        //public T GetContent<T>(RestResponse response)
        //{
        //    var content = response.Content;
        //    T dtoObject = JsonConvert.DeserializeObject<T>(content);
        //    return dtoObject;
        //}

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
            T dtoObject = JsonConvert.DeserializeObject<T>(reval.Content);
            return dtoObject;
        }
    }
}
