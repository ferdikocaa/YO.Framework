using System.Collections.Generic;

namespace YO.Framework.Api.Service.Interfaces
{
    public interface IHttpRequest
    {
        TResult Get<TResult>(string url, Dictionary<string, string> queryParameters, Dictionary<string, string> headerParameters = null) where TResult : class;
        TResult Post<TResult, TData>(string url, TData data, Dictionary<string, string> headerParameters = null) where TResult : class;
    }
}
