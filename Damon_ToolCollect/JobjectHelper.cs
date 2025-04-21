using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// JObject帮助类
    /// </summary>
    public class JobjectHelper
    {
        /// <summary>
        /// 判断json字符串中指定的key是否存在
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static bool IsExistKey(string jsonStr, params string[] keyNames)
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                JToken jToken = jobject;
                for (int i = 0; i < keyNames.Length; i++)
                {
#pragma warning disable CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    jToken = GetNextNode(jToken, keyNames[i]);
#pragma warning restore CS8600 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    if (jToken == null)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("IsExistKey=>" + ex);
            }
        }

        /// <summary>
        /// 删除指定节点支持多级返回新的JObject
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static JObject RemoveNode(JObject jobject, params string[] keyNames)
        {
            try
            {
                JObject jObject = jobject;
                JToken jToken = jObject;
                for (int i = 0; i < keyNames.Length; i++)
                {
#pragma warning disable CS8600, CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    jToken = GetNextNode(jToken, keyNames[i]);
#pragma warning restore CS8600, CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                }
#pragma warning disable CS8602 // 解引用可能出现空引用。
                jToken.Parent.Remove();
#pragma warning restore CS8602 // 解引用可能出现空引用。
                return jObject;
            }
            catch (Exception ex)
            {
                throw new Exception("RemoveNode=>" + ex);
            }
        }
        

        /// <summary>
        /// Json字符串格式化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string FormatJson(string json)
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                {
                    return "";
                }
                return JToken.Parse(json).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("FormatJson=>" + ex);
            }
        }

        /// <summary>
        /// Json字符串转JObject
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JObject GetJObject(string json)
        {
            try
            {
                return JObject.Parse(json);
            }
            catch (Exception ex)
            {
                throw new Exception("GetJObject=>" + ex);
            }
        }
        /// <summary>
        /// Jobject转Json字符串格式化压缩
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="isFormat">是否压缩,默认true压缩</param>
        /// <returns></returns>
        public static string GetJson(JObject jobject, bool isFormat = true)
        {
            try
            {
                return jobject.ToString(isFormat ? Newtonsoft.Json.Formatting.None : Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw new Exception("GetJson_2=>" + ex);
            }
        }
        /// <summary>
        /// Jobject转Json字符串格式化压缩
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="isFormat">是否压缩,默认true压缩</param>
        /// <returns></returns>
        public static string GetJson(string jsonStr, bool isFormat = true)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonStr))
                {
                    return "";
                }
                JObject jobject = JObject.Parse(jsonStr);
                return jobject.ToString(isFormat ? Newtonsoft.Json.Formatting.None : Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw new Exception("GetJson_2=>" + ex);
            }
        }

        /// <summary>
        /// 获取字符串值
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames">指定key</param>
        /// <returns></returns>
        public static string GetStringValue(JObject jobject, params string[] keyNames)
        {
            try
            {
                var value = GetNode(jobject, keyNames);
                if (value == null)
                {
                    return "";
                }
                return value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetStringValue_2=>" + ex);
            }
        }
        /// <summary>
        /// 获取字符串值
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames">指定key</param>
        /// <returns></returns>
        public static string GetStringValue(string jsonStr, params string[] keyNames)
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                var value = GetNode(jobject, keyNames);
                if (value == null)
                {
                    return "";
                }
                return value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetStringValue_2=>" + ex);
            }
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
            try
            {
                var value = GetNode(jobject, keyNames);
                if (value == null)
                {
                    return default(T);
                }
                return value.ToObject<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("GetValue<T>_2=>" + ex);
            }
        }
        /// <summary>
        /// 获取指定类型的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static T GetValue<T>(string jsonStr, params string[] keyNames) where T : struct
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                var value = GetNode(jobject, keyNames);
                if (value == null)
                {
                    return default(T);
                }
                return value.ToObject<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("GetValue<T>_2=>" + ex);
            }
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
            try
            {
                var value = GetNode(jobject, keyNames);
                if (value == null)
                {
                    return new List<T>();
                }
                return value.ToObject<List<T>>();
            }
            catch (Exception ex) { throw new Exception("GetListValue<T>_2=>" + ex); }
        }
        /// <summary>
        /// 获取List指定类型的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static List<T>? GetListValue<T>(string jsonStr, params string[] keyNames) where T : class
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                var value = GetNode(jobject, keyNames);
                if (value == null)
                {
                    return new List<T>();
                }
                return value.ToObject<List<T>>();
            }
            catch (Exception ex) { throw new Exception("GetListValue<T>_2=>" + ex); }
        }

        /// <summary>
        /// 获取Jobect指定类型的值
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static JObject? GetJObjectValue(JObject jobject, params string[] keyNames)
        {
            try
            {
                JToken jToken = jobject;
                for (int i = 0; i < keyNames.Length; i++)
                {
#pragma warning disable CS8600, CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    jToken = GetNextNode(jToken, keyNames[i]);
#pragma warning restore CS8600, CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                }
                JObject jObject;
#pragma warning disable CS8602, CS8600 // 解引用可能出现空引用。
                switch (jToken.Type)
                {
                    case JTokenType.Object:
                        jObject = (JObject)jToken;
                        break;
                    case JTokenType.Array:
                        jObject = (JObject)jToken[0];
                        break;
                    default:
                        //抛出异常
                        throw new Exception("获取JObject失败");
                }
#pragma warning restore CS8602, CS8600 // 解引用可能出现空引用。
                return jObject;
            }
            catch (Exception ex)
            {
                throw new Exception("GetJObjectValue_2=>" + ex);
            }
        }
        /// <summary>
        /// 获取Jobect指定类型的值
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static JObject? GetJObjectValue(string jsonStr, params string[] keyNames)
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                JToken jToken = jobject;
                for (int i = 0; i < keyNames.Length; i++)
                {
#pragma warning disable CS8600, CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    jToken = GetNextNode(jToken, keyNames[i]);
#pragma warning restore CS8600, CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                }
                JObject jObject;
#pragma warning disable CS8602, CS8600 // 解引用可能出现空引用。
                switch (jToken.Type)
                {
                    case JTokenType.Object:
                        jObject = (JObject)jToken;
                        break;
                    case JTokenType.Array:
                        jObject = (JObject)jToken[0];
                        break;
                    default:
                        //抛出异常
                        throw new Exception("获取JObject失败");
                }
#pragma warning restore CS8602, CS8600 // 解引用可能出现空引用。
                return jObject;
            }
            catch (Exception ex){ throw new Exception("GetJObjectValue_2=>" + ex); }
        }

        /// <summary>
        /// 获取JArray指定类型的值
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static JArray? GetJArrayValue(JObject jobject, params string[] keyNames)
        {
            try
            {
                JToken jToken = jobject;
                for (int i = 0; i < keyNames.Length; i++)
                {
#pragma warning disable CS8600,CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    jToken = GetNextNode(jToken, keyNames[i]);
#pragma warning restore CS8600,CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                }
                JArray jArray;
#pragma warning disable CS8602 // 解引用可能出现空引用。
                switch (jToken.Type)
                {
                    case JTokenType.Array:
                        jArray = (JArray)jToken;
                        break;
                    default:
                        //抛出异常
                        throw new Exception("获取JArray失败");
                }
#pragma warning restore CS8602 // 解引用可能出现空引用。
                return jArray;
            }
            catch (Exception ex) { throw new Exception("GetJArrayValue_2=>" + ex); }
        }
        /// <summary>
        /// 获取JArray指定类型的值
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static JArray? GetJArrayValue(string jsonStr, params string[] keyNames)
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                JToken jToken = jobject;
                for (int i = 0; i < keyNames.Length; i++)
                {
#pragma warning disable CS8600,CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    jToken = GetNextNode(jToken, keyNames[i]);
#pragma warning restore CS8600,CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                }
                JArray jArray;
#pragma warning disable CS8602 // 解引用可能出现空引用。
                switch (jToken.Type)
                {
                    case JTokenType.Array:
                        jArray = (JArray)jToken;
                        break;
                    default:
                        //抛出异常
                        throw new Exception("获取JArray失败");
                }
#pragma warning restore CS8602 // 解引用可能出现空引用。
                return jArray;
            }
            catch (Exception ex)
            {
                throw new Exception("GetJArrayValue_2=>" + ex);
            }
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
            try
            {
                var value = GetNode(jobject, keyNames);
                if (value == null)
                {
                    return null;
                }
                return value.ToObject<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("GetEntityValue<T>_2=>" + ex);
            }
        }
        /// <summary>
        /// 获取实体指定类型的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static T? GetEntityValue<T>(string jsonStr, params string[] keyNames) where T : class
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                var value = GetNode(jobject, keyNames);
                if (value == null)
                {
                    return null;
                }
                return value.ToObject<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("GetEntityValue<T>_2=>" + ex);
            }
        }

        /// <summary>
        /// 获取多级子节点
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static JToken? GetNode(JObject jobject, params string[] keyNames)
        {
            try
            {
                JToken jToken = jobject;
                for (int i = 0; i < keyNames.Length; i++)
                {
#pragma warning disable CS8600, CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    jToken = GetNextNode(jToken, keyNames[i]);
#pragma warning disable CS8600, CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                }
                return jToken;
            }
            catch (Exception ex)
            {
                throw new Exception("GetNode_2=>" + ex);
            }
        }
        /// <summary>
        /// 获取多级子节点
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static JToken? GetNode(string jsonStr, params string[] keyNames)
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                JToken jToken = jobject;
                for (int i = 0; i < keyNames.Length; i++)
                {
#pragma warning disable CS8600,CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                    jToken = GetNextNode(jToken, keyNames[i]);
#pragma warning restore CS8600,CS8604 // 将 null 字面量或可能为 null 的值转换为非 null 类型。
                }
                return jToken;
            }
            catch (Exception ex)
            {
                throw new Exception("GetNode_2=>" + ex);
            }
        }

        /// <summary>
        /// Jobject转DataTable
        /// </summary>
        /// <param name="jobject"></param>
        /// <returns></returns>
        public static DataTable JobjectToDataTable(JObject jobject)
        {
            try
            {
                DataTable dt = new DataTable();
                if (jobject != null)
                {
                    foreach (JToken item in jobject.Children())
                    {
                        JProperty jProperty = (JProperty)item;
                        dt.Columns.Add(jProperty.Name);
                    }
                    DataRow dr = dt.NewRow();
                    foreach (JToken item2 in jobject.Children())
                    {
                        JProperty jProperty2 = (JProperty)item2;
                        dr[jProperty2.Name] = jProperty2.Value;
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("JobjectToDataTable_1=>" + ex);
            }
        }
        /// <summary>
        /// Jobject转DataTable
        /// </summary>
        /// <param name="jobject"></param>
        /// <returns></returns>
        public static DataTable JobjectToDataTable(string jsonStr)
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                DataTable dt = new DataTable();
                if (jobject != null)
                {
                    foreach (JToken item in jobject.Children())
                    {
                        JProperty jProperty = (JProperty)item;
                        dt.Columns.Add(jProperty.Name);
                    }
                    DataRow dr = dt.NewRow();
                    foreach (JToken item2 in jobject.Children())
                    {
                        JProperty jProperty2 = (JProperty)item2;
                        dr[jProperty2.Name] = jProperty2.Value;
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("JobjectToDataTable_1=>" + ex);
            }
        }

        /// <summary>
        /// Jobject指定多个节点转DataTable
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames">指定节点名</param>
        /// <returns></returns>
        public static DataTable JobjectToDataTable(JObject jobject, params string[] keyNames)
        {
            try
            {
                DataTable dt = new DataTable();
                if (jobject != null)
                {
                    foreach (var keyName in keyNames)
                    {
                        dt.Columns.Add(keyName);
                    }
                    DataRow dr = dt.NewRow();
                    foreach (var keyName in keyNames)
                    {
                        dr[keyName] = jobject.SelectToken(keyName);
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("JobjectToDataTable_2=>" + ex);
            }
        }
        /// <summary>
        /// Jobject指定多个节点转DataTable
        /// </summary>
        /// <param name="jobject"></param>
        /// <param name="keyNames">指定节点名</param>
        /// <returns></returns>
        public static DataTable JobjectToDataTable(string jsonStr, params string[] keyNames)
        {
            try
            {
                JObject jobject = JObject.Parse(jsonStr);
                DataTable dt = new DataTable();
                if (jobject != null)
                {
                    foreach (var keyName in keyNames)
                    {
                        dt.Columns.Add(keyName);
                    }
                    DataRow dr = dt.NewRow();
                    foreach (var keyName in keyNames)
                    {
                        dr[keyName] = jobject.SelectToken(keyName);
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("JobjectToDataTable=>" + ex);
            }
        }

        /// <summary>
        /// JArray指定多个节点转DataTable
        /// </summary>
        /// <param name="jArray"></param>
        /// <param name="keyNames"></param>
        /// <returns></returns>
        public static DataTable JArrayToDataTable(JArray jArray, params string[] keyNames)
        {
            try
            {
                DataTable dt = new DataTable();
                if (jArray.Count > 0)
                {
                    foreach (var keyName in keyNames)
                    {
                        dt.Columns.Add(keyName);
                    }
                    foreach (JToken item in jArray)
                    {
                        DataRow dr = dt.NewRow();
                        foreach (var keyName in keyNames)
                        {
                            dr[keyName] = item.SelectToken(keyName);
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("JArrayToDataTable_2=>" + ex);
            }
        }

        /// <summary>
        /// JArray格式转DataTable格式
        /// </summary>
        /// <param name="jArray"></param>
        /// <returns></returns>
        public static DataTable JArrayToDataTable(JArray jArray)
        {
            try
            {
                DataTable dt = new DataTable();
                if (jArray.Count > 0)
                {
                    JObject jObject = JObject.Parse(jArray[0].ToString());
                    foreach (JToken item in jObject.Children())
                    {
                        JProperty jProperty = (JProperty)item;
                        dt.Columns.Add(jProperty.Name);
                    }
                    foreach (JToken item in jArray)
                    {
                        JObject jObject2 = JObject.Parse(item.ToString());
                        DataRow dr = dt.NewRow();
                        foreach (JToken item2 in jObject2.Children())
                        {
                            JProperty jProperty2 = (JProperty)item2;
                            dr[jProperty2.Name] = jProperty2.Value;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("JArrayToDataTable_1=>" + ex);
            }
        }

        /// <summary>
        /// 获取第一级子节点
        /// </summary>
        /// <param name="jtoken"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        private static JToken? GetNextNode(JToken jtoken, string keyName)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("GetNextNode=>" + ex);
            }
        }
    }
}
