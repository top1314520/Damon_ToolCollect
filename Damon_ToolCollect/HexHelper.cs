using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class HexHelper
    {
        /// <summary>
        /// 检查是否是十六进制字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHexString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            foreach (char c in str)
            {
                if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F')))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToHexString(byte[] bytes)
        {
            string hexString = string.Empty;
            try
            {
                if (bytes != null)
                {
                    StringBuilder strB = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        strB.Append(b.ToString("X2"));
                    }
                    hexString = strB.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BytesToHexString失败:" + ex.Message);
            }
            return hexString;
        }
        /// <summary>
        /// 16进制字符串转字节数组
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] HexStringToBytes(string hex)
        {
            byte[]? bytes = null;
            hex = hex.Replace(" ", "");
            try
            {
                if ((hex.Length % 2) != 0)
                    hex += " ";
                bytes = new byte[hex.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = byte.Parse(hex.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("HexStringToBytes失败:" + ex.Message);
            }
            return bytes;
        }

        /// <summary>
        /// 十六进制字符串转换为正常字符串
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string HexStringToString(string hex)
        {
            byte[] bytes = HexStringToBytes(hex);
            return Encoding.UTF8.GetString(bytes);
        }
        /// <summary>
        /// 正常字符串转换为十六进制字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string StringToHexString(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            return BytesToHexString(bytes);
        }
        /// <summary>
        /// 格式化 十六进制字符串,每16个字节换行
        /// </summary>
        /// <param name="hexString"></param>
        /// <param name="bytesPerLine"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string FormatHexStringWithLineBreaks(string hexString, int bytesPerLine = 16)
        {
            if (string.IsNullOrEmpty(hexString))
                return string.Empty;

            hexString = hexString.Replace(" ", "");
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException("输入的十六进制字符串长度必须是偶数。");
            }
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hexString.Length; i += 2)
            {
                if (i > 0)
                {
                    // 换行逻辑：每 bytesPerLine 组换行
                    if (i % (bytesPerLine * 2) == 0)
                        result.AppendLine();
                    else
                        result.Append(" ");
                }
                result.Append(hexString.Substring(i, 2));
            }

            return result.ToString();
        }

        /// <summary>
        /// 十六进制倒置
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string ReverseHexString(string hex)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = hex.Length - 2; i >= 0; i -= 2)
            {
                sb.Append(hex.Substring(i, 2));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Json中的十六进制字符串转换为正常字符串
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string ConvertHexStringsInJson(string json)
        {
            // 解析JSON到JObject  
            JObject jsonObject = JObject.Parse(json);

            // 遍历所有属性  
            foreach (JProperty prop in jsonObject.Properties())
            {
                string strValue = prop.Value.ToString();

                // 检查字符串是否可能是十六进制  
                if (strValue.Length > 0 && strValue.Length % 2 == 0 && strValue.All(c => (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F')))
                {
                    // 尝试将十六进制字符串转换为字节数组  
                    try
                    {
                        string decodedString = HexStringToString(strValue);
                        if (!StringHelper.IsMessyCode(decodedString)) 
                        {
                            // 更新JSON对象的属性值  
                            prop.Value = JToken.FromObject(StringHelper.ReplaceSpecialChar(decodedString));
                        }
                    }
                    catch 
                    {
                        //异常就不修改
                    }
                }
            }
            // 将更新后的JObject转换回JSON字符串  
            return jsonObject.ToString();
        }
    }
}
