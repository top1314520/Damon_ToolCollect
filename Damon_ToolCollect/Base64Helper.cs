using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class Base64Helper
    {
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Base64_Encode(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new Exception("Base64_Encode=>内容不能为空!");
                }
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                throw new Exception("Base64_Encode=>" + ex.Message);
            }
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Base64_Decode(string input) 
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    throw new Exception("Base64_Decode=>内容不能为空!");
                }
                input = input.Replace("-", "+").Replace("_", "/");
                byte[] bytes = Convert.FromBase64String(input);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                throw new Exception("Base64_Decode=>" + ex.Message);
            }
        }

        ///// <summary>
        ///// Base64ToHex_解码
        ///// </summary>
        ///// <param name="base64"></param>
        ///// <returns></returns>
        //public static string Base64ToHex(string base64)
        //{
        //    if (string.IsNullOrEmpty(base64))
        //    {
        //        return string.Empty;
        //    }
        //    base64 = base64.Replace("-", "+").Replace("_", "/"); 
        //    byte[] bytes = Convert.FromBase64String(base64);
        //    StringBuilder hex = new StringBuilder(bytes.Length * 2);
        //    foreach (byte b in bytes)
        //    {
        //        hex.AppendFormat("{0:x2}", b);
        //    }
        //    return hex.ToString();
        //}

        #region Base64ToHex_解码(兼容标准 + URL-safe)
        /// <summary>
        /// Base64 解码（兼容标准 + URL-safe）
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string Base64ToHex(string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
            {
                throw new Exception("Base64ToHex=>内容不能为空!");
            }
            // 1. 移除所有空白字符（包括换行、空格等）
            base64 = Regex.Replace(base64, @"\s+", "");
            // 2. 替换 URL-safe Base64 字符（- → +，_ → /）
            base64 = base64.Replace("-", "+").Replace("_", "/");
            // 3. 确保长度是 4 的倍数（补 =）
            int padding = base64.Length % 4;
            if (padding > 0)
            {
                base64 += new string('=', 4 - padding);
            }
            try
            {
                byte[] bytes = Convert.FromBase64String(base64);
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
            catch (FormatException)
            {
                try
                {
                    // 终极回退：尝试移除非法字符后解码
                    base64 = Regex.Replace(base64, @"[^A-Za-z0-9+/=]", "");
                    byte[] bytes = Convert.FromBase64String(base64);
                    return BitConverter.ToString(bytes).Replace("-", "").ToLower();
                }
                catch (Exception ex)
                {
                    throw new Exception("Base64ToHex=>"+ex.Message);
                }
            }
        }

        /// <summary>
        /// 字节数组 → 标准 Base64 或 URL-safe Base64
        /// </summary>
        /// <param name="data">原始字节数组</param>
        /// <param name="urlSafe">是否转为 URL-safe 格式（默认 false）</param>
        /// <returns></returns>
        public static string ToBase64String(byte[] data, bool urlSafe = false)
        {
            try
            {
                if (data == null || data.Length == 0)
                {
                    throw new Exception("ToBase64String=>内容不能为空!");
                }
                string base64 = Convert.ToBase64String(data);
                // 转为 URL-safe Base64（+ → -, / → _, 移除 =）
                if (urlSafe)
                {
                    base64 = base64.Replace("+", "-").Replace("/", "_").TrimEnd('=');
                }
                return base64;
            }
            catch (Exception ex)
            {
                throw new Exception("ToBase64String=>" + ex.Message);
            }
        }

        /// <summary>
        /// Hex 字符串 → Base64 或 URL-safe Base64
        /// </summary>
        public static string HexToBase64(string hex, bool urlSafe = false)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(hex))
                {
                    throw new Exception("HexToBase64=>内容不能为空!");
                }
                // 移除可能的 Hex 分隔符（如 "A0-B1-C2" → "A0B1C2"）
                hex = Regex.Replace(hex, @"[^0-9A-Fa-f]", "");
                byte[] bytes = new byte[hex.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                }
                return ToBase64String(bytes, urlSafe);
            }
            catch (Exception ex)
            {
                throw new Exception("HexToBase64=>" + ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// HexToBase64_编码
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string HexToBase64(string hex)
        {
            try
            {
                if (string.IsNullOrEmpty(hex))
                {
                    throw new Exception("HexToBase64=>内容不能为空!");
                }
                byte[] bytes = new byte[hex.Length / 2];
                for (int i = 0; i < hex.Length; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                }
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                throw new Exception("HexToBase64=>" + ex.Message);
            }
        }
    }
}
