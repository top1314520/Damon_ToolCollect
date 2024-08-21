using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect.FormatClass
{
    /// <summary>
    /// http请求结果
    /// </summary>
    public class HttpReponseResult
    {
        public HttpResponseHeaders? headers { get; set; }

        public HttpStatusCode statusCode { get; set; }

        public Dictionary<string, string> setCookie { get; set; }

        public byte[] content { get; set; }

        public string etag { get; set; }

        public string last_Modified { get; set; }

        public string tk { get; set; }

        public string contentRange { get; set; }

        public string obsoid { get; set; }

        public string errorMsg { get; set; }

        public HttpReponseResult()
        {
            headers = null;
            setCookie = new Dictionary<string, string>();
            statusCode = (HttpStatusCode)0;
            content = new byte[0];
            etag = "";
            last_Modified = "";
            tk = "";
            contentRange = "";
            obsoid = "";
            errorMsg = "";
        }
    }
}
