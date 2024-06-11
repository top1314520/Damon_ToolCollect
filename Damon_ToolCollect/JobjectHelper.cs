using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class JobjectHelper
    {
        /// <summary>
        /// 获取字符串值
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames">指定key</param>
        /// <returns></returns>
        public static string GetStringValue(JObject jobject, params string[] keyNames)
        {
            var value = GetNode(jobject, keyNames);
            if (value == null)
            {
                return "";
            }
            return value.ToString();
        }
        /// <summary>
        /// 获取指定类型的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static T GetValue<T>(JObject jobject, params string[] keyNames) where T : struct
        {
            var value = GetNode(jobject, keyNames);
            if (value == null)
            {
                return default(T);
            }
            return value.ToObject<T>();
        }
        /// <summary>
        /// 获取List指定类型的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static List<T>? GetListValue<T>(JObject jobject, params string[] keyNames) where T : class
        {
            var value = GetNode(jobject, keyNames);
            if (value == null)
            {
                return new List<T>();
            }
            return value.ToObject<List<T>>();
        }
        /// <summary>
        /// 获取实体指定类型的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static T? GetEntityValue<T>(JObject jobject, params string[] keyNames) where T : class
        {
            var value = GetNode(jobject, keyNames);
            if (value == null)
            {
                return null;
            }
            return value.ToObject<T>();
        }

        public static JToken? GetNode(JObject jobject, params string[] keyNames)
        {
            JToken jToken = jobject;
            for (int i = 0; i < keyNames.Length; i++)
            {
                jToken = GetNextNode(jToken, keyNames[i]);
            }
            return jToken;
        }

        /// <summary>
        /// 得到子节点
        /// </summary>
        /// <param name="jtoken"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        private static JToken? GetNextNode(JToken jtoken, string keyName)
        {
            if (jtoken == null)
            {
                return null;
            }
            if (jtoken is JObject)
            {
                JObject jObject = (JObject)jtoken;
                if (jObject.ContainsKey(keyName))
                {
                    return jObject[keyName];
                }
            }
            return null;
        }
    }
}
