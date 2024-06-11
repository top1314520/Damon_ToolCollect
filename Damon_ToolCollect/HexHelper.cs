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
            byte[] bytes = null;
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
    }
}
