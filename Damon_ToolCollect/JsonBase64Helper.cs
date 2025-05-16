using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.Json.Serialization.Metadata;

namespace Damon_ToolCollect
{
    public class JsonBase64Helper
    {
        /// <summary>
        /// 将JSON中的Base64字符串解码为可读文本或十六进制字符串
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static string DecodeBase64InJson(string jsonString)
        {
            try
            {
                JsonNode jsonNode = JsonNode.Parse(jsonString);
                ProcessNode(jsonNode);
                return jsonNode.ToJsonString(new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    TypeInfoResolver = System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault ? new DefaultJsonTypeInfoResolver()  : JsonTypeInfoResolver.Combine()
                });
            }
            catch (Exception ex)
            {
                return $"{{\"error\": \"Failed to decode JSON: {ex.Message}\"}}";
            }
        }

        /// <summary>
        /// 将JSON中的十六进制字符串编码为Base64
        /// </summary>
        public static string EncodeHexToBase64InJson(string jsonString)
        {
            try
            {
                JsonNode jsonNode = JsonNode.Parse(jsonString);
                ProcessNodeForHexEncoding(jsonNode);
                return jsonNode.ToJsonString(new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    TypeInfoResolver = System.Text.Json.JsonSerializer.IsReflectionEnabledByDefault ? new DefaultJsonTypeInfoResolver() : JsonTypeInfoResolver.Combine()
                });
            }
            catch (Exception ex)
            {
                return $"{{\"error\": \"Failed to encode hex in JSON: {ex.Message}\"}}";
            }
        }


        private static void ProcessNode(JsonNode? node)
        {
            switch (node)
            {
                case JsonObject obj:
                    ProcessJsonObject(obj);
                    break;
                case JsonArray arr:
                    ProcessJsonArray(arr);
                    break;
                case JsonValue value when value.TryGetValue(out string str):
                    if (IsBase64String(str))
                    {
                        // 直接创建新节点替换当前值
                        var parent = node.Parent;
                        if (parent is JsonObject jsonObj)
                        {
                            var property = jsonObj.FirstOrDefault(p => p.Value == node);
                            if (property.Value != null)
                            {
                                jsonObj[property.Key] = JsonValue.Create(TryDecodeBase64(str));
                            }
                        }
                        else if (parent is JsonArray jsonArr)
                        {
                            int index = jsonArr.IndexOf(node);
                            if (index >= 0)
                            {
                                jsonArr[index] = JsonValue.Create(TryDecodeBase64(str));
                            }
                        }
                    }
                    break;
            }
        }

        private static void ProcessJsonObject(JsonObject obj)
        {
            foreach (var property in obj.ToList()) // ToList()避免修改时迭代异常
            {
                var value = property.Value;
                if (value is JsonValue jValue && jValue.TryGetValue(out string str))
                {
                    if (IsBase64String(str))
                    {
                        obj[property.Key] = JsonValue.Create(TryDecodeBase64(str));
                    }
                }
                else
                {
                    ProcessNode(value);
                }
            }
        }

        private static void ProcessJsonArray(JsonArray arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                var item = arr[i];
                if (item is JsonValue jValue && jValue.TryGetValue(out string str))
                {
                    if (IsBase64String(str))
                    {
                        arr[i] = JsonValue.Create(TryDecodeBase64(str));
                    }
                }
                else
                {
                    ProcessNode(item);
                }
            }
        }

        private static bool IsBase64String(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;

            // 简单启发式判断：
            // 1. 长度是4的倍数
            // 2. 只包含base64字符
            // 3. 可能包含1-2个等号后缀
            var span = str.AsSpan();
            if ((span.Length % 4) != 0) return false;

            foreach (var c in span)
            {
                if (!char.IsLetterOrDigit(c) && c != '+' && c != '/' && c != '=')
                {
                    return false;
                }
            }
            return true;
        }

        private static object TryDecodeBase64(string base64Str)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64Str);

                // 尝试解码为UTF-8文本
                try
                {
                    string text = Encoding.UTF8.GetString(bytes);
                    // 检查是否包含不可打印字符
                    if (!text.Any(c => char.IsControl(c) && !char.IsWhiteSpace(c)))
                    {
                        return text;
                    }
                }
                catch { }

                // 如果是二进制数据，转为十六进制字符串
                return "0x" + BitConverter.ToString(bytes).Replace("-", "");
            }
            catch
            {
                return base64Str; // 解码失败返回原字符串
            }
        }

        //
        private static void ProcessNodeForHexEncoding(JsonNode node)
        {
            switch (node)
            {
                case JsonObject obj:
                    ProcessJsonObjectForHexEncoding(obj);
                    break;
                case JsonArray arr:
                    ProcessJsonArrayForHexEncoding(arr);
                    break;
            }
        }

        private static void ProcessJsonObjectForHexEncoding(JsonObject obj)
        {
            var properties = obj.ToList(); // 创建副本避免修改时迭代异常
            foreach (var property in properties)
            {
                if (property.Value is JsonValue jsonValue && jsonValue.TryGetValue(out string str))
                {
                    if (IsHexString(str))
                    {
                        obj[property.Key] = TryEncodeHexToBase64(str);
                    }
                }
                else
                {
                    ProcessNodeForHexEncoding(property.Value);
                }
            }
        }

        private static void ProcessJsonArrayForHexEncoding(JsonArray arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] is JsonValue jsonValue && jsonValue.TryGetValue(out string str))
                {
                    if (IsHexString(str))
                    {
                        arr[i] = TryEncodeHexToBase64(str);
                    }
                }
                else
                {
                    ProcessNodeForHexEncoding(arr[i]);
                }
            }
        }

        private static bool IsHexString(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;

            ReadOnlySpan<char> span = str.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                ? str.AsSpan(2)
                : str.AsSpan();

            if (span.Length == 0 || span.Length % 2 != 0) return false;

            foreach (var c in span)
            {
                if (!Uri.IsHexDigit(c))
                    return false;
            }
            return true;
        }

        private static string TryEncodeHexToBase64(string hexStr)
        {
            try
            {
                ReadOnlySpan<char> hexSpan = hexStr.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
                    ? hexStr.AsSpan(2)
                    : hexStr.AsSpan();

                hexSpan = hexSpan.Trim().Trim('-');

                byte[] bytes = new byte[hexSpan.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    if (!byte.TryParse(hexSpan.Slice(i * 2, 2), NumberStyles.HexNumber, null, out bytes[i]))
                    {
                        return hexStr;
                    }
                }
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return hexStr;
            }
        }

    }
}
