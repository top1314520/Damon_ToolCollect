using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect.FormatClass
{
    /// <summary>
    /// Json格式返回结果
    /// </summary>
    public class JsonFormatResult
    {
        public string success { get; set; } = "";
        public int code { get; set; }
        public string message { get; set; } = "";
        public int num { get; set; }
        public object? data { get; set; }

        public static string GenReturnInfo(string success, int code, string message, object data, int num = 0)
        {
            JsonFormatResult returnInfo = new JsonFormatResult();
            returnInfo.success = success;
            returnInfo.code = code;
            returnInfo.message = message;
            returnInfo.num = num;
            returnInfo.data = data;
            string ret = JsonConvert.SerializeObject(returnInfo, Formatting.None);
            return ret;
        }
    }
}
