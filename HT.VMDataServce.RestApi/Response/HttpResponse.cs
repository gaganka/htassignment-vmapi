using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HT.VMDataServce.RestApi.Response
{
    public class HttpResponse
    {
        public dynamic Data { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode ResponseStatusCode { get; set; }
    }
}
