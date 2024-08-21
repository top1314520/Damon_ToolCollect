using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class JsonHelper
    {
        /// <summary>
        /// 判断字符串是否为Json
        /// </summary>
        /// <param name="json">字符串</param>
        /// <returns></returns>
        public static bool IsJson(string json)
        {
            try
            {
                JsonConvert.DeserializeObject(json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断节点是否存在(含多级)
        /// </summary>
        /// <param name="json">Json字符串</param>
        /// <param name="nodeName">节点名称(如："age";"prople.age";"data[0].age")</param>
        /// <returns></returns>
        public static bool IsJsonNodeExist(string json, string nodeName)
        {
            try
            {
                var jObject = JsonConvert.DeserializeObject(json) as JObject;
                if (jObject == null)
                {
                    return false;
                }
                var jToken = jObject.SelectToken(nodeName);
                return jToken != null;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取Json节点值返回对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        /// <param name="nodeName">节点名称(如："age";"prople.age";"data[0].age")</param>
        /// <returns></returns>
        public static object GetJsonNodeValue(string json, string nodeName)
        {
            try
            {
                var jObject = JsonConvert.DeserializeObject(json) as JObject;
                if (jObject == null)
                {
                    return null;
                }
                var jToken = jObject.SelectToken(nodeName);
                return jToken;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取Json节点值返回字符串
        /// </summary>
        /// <param name="json">Json字符串</param>
        /// <param name="nodeName">节点名称(如："age";"prople.age";"data[0].age")</param>
        /// <returns></returns>
        public static string GetJsonNodeValueString(string json, string nodeName)
        {
            try
            {
                var jObject = JsonConvert.DeserializeObject(json) as JObject;
                if (jObject == null)
                {
                    return null;
                }
                var jToken = jObject.SelectToken(nodeName);
                return jToken.ToString();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 对象转Json字符串
        /// </summary>
        /// <param name="obj">Json对象</param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj,Formatting.None);
        }
        /// <summary>
        /// Json字符串转对象
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="json">Json字符串</param>
        /// <returns></returns>
        public static T? JsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
