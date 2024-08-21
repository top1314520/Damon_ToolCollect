using Damon_ToolCollect.FormatClass;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Damon_ToolCollect
{
    public class HttpHelper
    {
        static HttpHelper()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }
        /// <summary>
        /// 解析Url中的域名
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ParseDomain(string url)
        {
            string result = "";
            try
            {
                string pattern = "(http|https)://(?<domain>[^/]+)";
                Match match = Regex.Match(url, pattern);
                if (match.Success)
                {
                    result = match.Groups["domain"].Value;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// post请求Bodey form-data
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="cookies"></param>
        /// <param name="forms"></param>
        /// <param name="socksProxy"></param>
        /// <param name="debugFlag"></param>
        /// <returns></returns>
        public static string HttpClientPostFormData(string url, Dictionary<string, string> headers, Dictionary<string, string> cookies, Dictionary<string, string> forms, IWebProxy socksProxy = null, int debugFlag = 0)
        {
            HttpClientHandler handler;
            if (socksProxy != null)
            {
                handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip,
                    UseCookies = false,
                    AllowAutoRedirect = false,
                    Proxy = socksProxy,
                    UseProxy = true
                };
            }
            else if (debugFlag == 1)
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.AutomaticDecompression = DecompressionMethods.GZip;
                httpClientHandler.UseCookies = false;
                httpClientHandler.AllowAutoRedirect = false;
                httpClientHandler.Proxy = new WebProxy("http://localhost:8888", BypassOnLocal: false, new string[0]);
                httpClientHandler.UseProxy = true;
                handler = httpClientHandler;
            }
            else
            {
                handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip,
                    UseCookies = false,
                    AllowAutoRedirect = false
                };
            }
            HttpClient httpClient = new HttpClient(handler);
            try
            {
                httpClient.BaseAddress = new Uri(url);
                foreach (string key in headers.Keys)
                {
                    if ("user-agent" == key || "User-Agent" == key)
                    {
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("user-agent", headers[key]);
                    }
                    else
                    {
                        httpClient.DefaultRequestHeaders.Add(key, headers[key]);
                    }
                }
                string text = "";
                foreach (string key2 in cookies.Keys)
                {
                    text = text + key2 + "=" + cookies[key2] + "; ";
                }
                if (text.Length > 0)
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", text);
                }
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(forms);
                Task<HttpResponseMessage> task = httpClient.PostAsync(url, formUrlEncodedContent);
                HttpReponseResult hTTPReponseResult = new HttpReponseResult();
                return ProcessHttpResponseMessage(task.Result);
            }
            catch (Exception ex)
            {
                HttpReponseResult hTTPReponseResult2 = new HttpReponseResult();
                hTTPReponseResult2.errorMsg = "HttpClientPostFormData失败：" + ex.ToString();
                return JsonHelper.ObjectToJson(hTTPReponseResult2);
            }
        }


        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <param name="headers">包头</param>
        /// <param name="cookies">cookies</param>
        /// <param name="forms">请求数据
        ///                     ByteArrayContent byteArrayContent = new ByteArrayContent(data);
        ///                     byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuffer");
        ///                     </param>
        /// <param name="parameter">Post:Url需要跟的参数</param>
        /// <param name="socksProxy">代理信息</param>
        /// <param name="debugFlag">是否启用调试代理1启用</param>
        /// <returns></returns>
        public static string HttpClientPost(string url, Dictionary<string, string> headers, Dictionary<string, string> cookies, HttpContent forms, Dictionary<string, string> parameter, IWebProxy socksProxy = null, int debugFlag = 0)
        {
            HttpClientHandler handler;
            if (socksProxy != null)
            {
                handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip,
                    UseCookies = false,
                    AllowAutoRedirect = false,
                    Proxy = socksProxy,
                    UseProxy = true
                };
            }
            else if (debugFlag == 1)
            {
                HttpClientHandler httpClientHandler = new HttpClientHandler();
                httpClientHandler.AutomaticDecompression = DecompressionMethods.GZip;
                httpClientHandler.UseCookies = false;
                httpClientHandler.AllowAutoRedirect = false;
                httpClientHandler.Proxy = new WebProxy("http://localhost:8888", BypassOnLocal: false, new string[0]);
                httpClientHandler.UseProxy = true;
                handler = httpClientHandler;
            }
            else
            {
                handler = new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip,
                    UseCookies = false,
                    AllowAutoRedirect = false
                };
            }
            HttpClient httpClient = new HttpClient(handler);
            try
            {
                httpClient.BaseAddress = new Uri(url);
                foreach (string key in headers.Keys)
                {
                    if ("user-agent" == key || "User-Agent" == key)
                    {
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("user-agent", headers[key]);
                    }
                    else
                    {
                        httpClient.DefaultRequestHeaders.Add(key, headers[key]);
                    }
                }
                string text = "";
                foreach (string key2 in cookies.Keys)
                {
                    text = text + key2 + "=" + cookies[key2] + "; ";
                }
                if (text.Length > 0)
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", text);
                }
                NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string.Empty);
                foreach (string key3 in parameter.Keys)
                {
                    nameValueCollection[key3] = parameter[key3];
                }
                string requestUri = url+"?" + nameValueCollection.ToString();
                Task<HttpResponseMessage> task = httpClient.PostAsync(requestUri, forms);
                HttpReponseResult hTTPReponseResult = new HttpReponseResult();
                return ProcessHttpResponseMessage(task.Result);
            }
            catch (Exception ex)
            {
                HttpReponseResult hTTPReponseResult2 = new HttpReponseResult();
                hTTPReponseResult2.errorMsg = "HttpClientPost失败：" + ex.ToString();
                return JsonHelper.ObjectToJson(hTTPReponseResult2);
            }
        }
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">Url地址含参数</param>
        /// <param name="headers">包头</param>
        /// <param name="cookies">cookies</param>
        /// <param name="socksProxy">代理信息</param>
        /// <param name="debugFlag">是否启用调试代理1启用</param>
        /// <returns></returns>
        public static string HttpClientGet(string url, Dictionary<string, string> headers, Dictionary<string, string> cookies, IWebProxy socksProxy = null, int debugFlag = 0)
        {
            HttpClientHandler handler;
            HttpReponseResult hTTPReponseResult = new HttpReponseResult();
            try
            {
                if (socksProxy != null)
                {
                    handler = new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip,
                        UseCookies = false,
                        AllowAutoRedirect = false,
                        Proxy = socksProxy,
                        UseProxy = true
                    };
                }
                else if (debugFlag == 1)
                {
                    HttpClientHandler httpClientHandler = new HttpClientHandler();
                    httpClientHandler.AutomaticDecompression = DecompressionMethods.GZip;
                    httpClientHandler.UseCookies = false;
                    httpClientHandler.AllowAutoRedirect = false;
                    httpClientHandler.Proxy = new WebProxy("http://localhost:8888", BypassOnLocal: false, new string[0]);
                    httpClientHandler.UseProxy = true;
                    handler = httpClientHandler;
                }
                else
                {
                    handler = new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip,
                        UseCookies = false,
                        AllowAutoRedirect = false
                    };
                }
                HttpClient httpClient = new HttpClient(handler);

                string baseUrl = "";
                NameValueCollection nvc = new NameValueCollection();
                ParseUrl(url, out baseUrl, out nvc);
                httpClient.BaseAddress = new Uri(baseUrl);
                foreach (string key in headers.Keys)
                {
                    if ("user-agent" == key || "User-Agent" == key)
                    {
                        httpClient.DefaultRequestHeaders.TryAddWithoutValidation("user-agent", headers[key]);
                    }
                    else
                    {
                        httpClient.DefaultRequestHeaders.Add(key, headers[key]);
                    }
                }
                string text = "";
                foreach (string key2 in cookies.Keys)
                {
                    text = text + key2 + "=" + cookies[key2] + "; ";
                }
                if (!string.IsNullOrEmpty(text))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", text);
                }
                Task<HttpResponseMessage> async = httpClient.GetAsync(url);
                return ProcessHttpResponseMessage(async.Result);
            }
            catch (Exception ex)
            {
                HttpReponseResult hTTPReponseResult2 = new HttpReponseResult();
                hTTPReponseResult2.errorMsg = "HttpClientGet失败：" + ex.ToString();
                return JsonHelper.ObjectToJson(hTTPReponseResult2);
            }
        }

        private static string ProcessHttpResponseMessage(HttpResponseMessage response)
        {
            HttpReponseResult hTTPReponseResult = new HttpReponseResult();
            if (response.Headers.TryGetValues("Set-Cookie", out var values))
            {
                foreach (string item in values)
                {
                    string[] array = item.Split(';');
                    if (array.Length != 0)
                    {
                        int num = array[0].IndexOf("=");
                        string key = array[0].Substring(0, num);
                        string value = array[0].Substring(num + 1);
                        string value2 = "";
                        if (!hTTPReponseResult.setCookie.TryGetValue(key, out value2))
                        {
                            hTTPReponseResult.setCookie.Add(key, value);
                        }
                    }
                }
            }
            if (response.Headers.TryGetValues("etag", out var values2))
            {
                foreach (string item2 in values2)
                {
                    string text = (hTTPReponseResult.etag = item2);
                }
            }
            if (response.Headers.TryGetValues("Last-Modified", out var values3))
            {
                foreach (string item3 in values3)
                {
                    string text2 = (hTTPReponseResult.last_Modified = item3);
                }
            }
            if (response.Content.Headers.TryGetValues("Content-Range", out var values4))
            {
                foreach (string item4 in values4)
                {
                    string text3 = (hTTPReponseResult.contentRange = item4);
                }
            }
            if (response.Headers.TryGetValues("x-obs-oid", out var values5))
            {
                foreach (string item5 in values5)
                {
                    string text4 = (hTTPReponseResult.obsoid = item5);
                }
            }
            hTTPReponseResult.statusCode = response.StatusCode;
            Task<byte[]> task = response.Content.ReadAsByteArrayAsync();
            task.Wait();
            hTTPReponseResult.content = task.Result;
            return JsonHelper.ObjectToJson(hTTPReponseResult);
        }
        /// <summary>
        /// Get方法参数解析
        /// </summary>
        /// <param name="url"></param>
        /// <param name="baseUrl"></param>
        /// <param name="nvc"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        private static void ParseUrl(string url, out string baseUrl, out NameValueCollection nvc)
        {
            if (url == null)
            {
                throw new ArgumentNullException("ParseUrl-->url is null");
            }
            try
            {
                nvc = new NameValueCollection();
                baseUrl = "";
                if (url == "")
                {
                    return;
                }
                int num = url.IndexOf('?');
                if (num == -1)
                {
                    baseUrl = url;
                    return;
                }
                baseUrl = url.Substring(0, num);
                if (num == url.Length - 1)
                {
                    return;
                }
                string input = url.Substring(num + 1);
                Regex regex = new Regex("(^|&)?(\\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
                MatchCollection matchCollection = regex.Matches(input);
                foreach (Match item in matchCollection)
                {
                    nvc.Add(item.Result("$2").ToLower(), item.Result("$3"));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ParseUrl-->" + ex.Message);
            }
        }
    }
}
