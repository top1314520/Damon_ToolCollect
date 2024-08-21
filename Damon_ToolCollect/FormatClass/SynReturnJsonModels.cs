using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect.FormatClass
{
    public class SynReturnJsonModels
    {
        public bool Success { get; set; }
        /// <summary>
        /// 0成功 其他都是失败
        /// </summary>
        public string code { get; set; } = "";
        public string message { get; set; } = "";
        public string serialno { get; set; } = "";
        public string service_time { get; set; } = "";
        public string extend { get; set; } = "";
        public object data { get; set; }
        public static string GetSynReturnModels(bool success, string code, string message, string serial_no, object data = null)
        {
            SynReturnJsonModels model = new SynReturnJsonModels();
            model.Success = success;
            model.code = code;
            model.message = message;
            model.serialno = serial_no;
            model.service_time = TimeHelper.GetDateTime();
            model.data = data;
            return JsonHelper.ObjectToJson(model);
        }
    }
}
