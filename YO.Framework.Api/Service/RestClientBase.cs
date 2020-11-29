using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using YO.Framework.Api.Service.Interfaces;

namespace YO.Framework.Api.Service
{
    public class RestClientBase : IHttpRequest
    {
        public TResult Get<TResult>(string url, Dictionary<string, string> queryParameters, Dictionary<string, string> headerParameters = null) where TResult : class
        {
            var request = new RestRequest()
            {
                RequestFormat = DataFormat.Json,
                Method = Method.GET
            };

            if (headerParameters != null)
                request.AddHeaders(headerParameters);

            if (queryParameters != null)
            {
                foreach (var param in queryParameters)
                {
                    request.AddQueryParameter(param.Key, param.Value);
                }
            }

            var response = Execute(url, request);

            var result = RequestParseResult<TResult>(response);

            return result;
        }

        public TResult Post<TResult, TData>(string url, TData data, Dictionary<string, string> headerParameters = null) where TResult : class
        {
            var request = new RestRequest()
            {
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            };

            if (headerParameters != null)
                request.AddHeaders(headerParameters);

            if (data != null)
                request.AddJsonBody(data);

            var response = Execute(url, request);

            var result = RequestParseResult<TResult>(response);

            return result;
        }

        private IRestResponse Execute(string url, RestRequest request)
        {
            var client = new RestClient(url);

            client.AddDefaultHeader("Content-Type", "application/json;charset=UTF-8;");

            IRestResponse response = client.Execute(request);

            return response;
        }

        private TResult RequestParseResult<TResult>(IRestResponse response) where TResult : class
        {
            TResult result = null;

            if (response.IsSuccessful == false)
                return result;

            try
            {
                result = JsonConvert.DeserializeObject<TResult>(response.Content);
            }
            catch (Exception e)
            {
                throw new DeserializationException(response, e);
            }

            return result;
        }


    }
}
