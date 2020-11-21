using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YO.Framework.Api
{
    public class ServiceResponse<T> where T : new()
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public bool IsStatus { get; set; }
    }
}
