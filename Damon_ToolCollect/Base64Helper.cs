using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Base64_Decode(string input) 
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            input = input.Replace("-", "+").Replace("_", "/");
            byte[] bytes = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Base64ToHex_解码
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static string Base64ToHex(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                return string.Empty;
            }
            base64 = base64.Replace("-", "+").Replace("_", "/"); 
            byte[] bytes = Convert.FromBase64String(base64);
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
        /// <summary>
        /// HexToBase64_编码
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static string HexToBase64(string hex)
        {
            if (string.IsNullOrEmpty(hex))
            {
                return string.Empty;
            }
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return Convert.ToBase64String(bytes);
        }
    }
}
