using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 替换特需字符和转义字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceSpecialChar(string str)
        {
            return str.Replace("\b", "\\b").Replace("\\u", "\\\\u").Replace("\u0000", "\\u").Replace(".%","%").Replace("%.","%").Replace("'", "’");
        }
        /// <summary>
        /// 判断字符串是否为乱码(true为乱码;false不是乱码)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMessyCode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            byte[] byteArray = Encoding.Default.GetBytes(str);
            string newStr = Encoding.Default.GetString(byteArray);
            return str != newStr;
        }


        /// <summary>
        /// 添加字符串转义符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AddEscape(string str)
        {
            return str.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\'", "\\\'");
        }
        /// <summary>
        /// 移除字符串转义符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveEscape(string str)
        {
            return str.Replace("\\\\", "\\").Replace("\\\"", "\"").Replace("\\\'", "\'");
        }
        /// <summary>
        /// 字符串截取(字符串和字符串之间的内容)
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="start">指定开始字符串</param>
        /// <param name="end">指定结束字符串</param>
        /// <returns></returns>
        public static string GetBetween(string str, string start, string end)
        {
            int startIndex = str.IndexOf(start);
            if (startIndex == -1)
            {
                return "";
            }
            startIndex += start.Length;
            int endIndex = str.IndexOf(end, startIndex);
            if (endIndex == -1)
            {
                return "";
            }
            return str.Substring(startIndex, endIndex - startIndex);
        }
        /// <summary>
        /// 字符串截取(单个字符结束)
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="v1">开始字符串</param>
        /// <param name="v2">结束字符(单个字符)</param>
        /// <returns></returns>
        public static string SubstringBetweenMarkers(string str, string v1, string v2)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(v1) || string.IsNullOrEmpty(v2))
            {
                return string.Empty; // 或者你可以抛出一个异常  
            }
            int startIndex = str.IndexOf(v1);
            if (startIndex == -1)
            {
                return string.Empty; // v1没有在str中找到  
            }
            startIndex += v1.Length; // 跳过v1的长度  
            int endIndex = str.IndexOf(v2, startIndex); // 从startIndex开始查找v2  
            if (endIndex == -1)
            {
                // v2没有在str的剩余部分中找到，返回从v1到字符串末尾的子串  
                return str.Substring(startIndex);
            }
            // 返回从v1到v2（不包括v2）的子串  
            return str.Substring(startIndex, endIndex - startIndex);
        }
        /// <summary>
        /// 去除字符串中的空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpaces(string str)
        {
            return str.Replace(" ", "");
        }
        /// <summary>
        /// 去除字符串中的换行符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveNewLines(string str)
        {
            return str.Replace("\r", "").Replace("\n", "");
        }
        /// <summary>
        /// 判断字符串长度是否为偶数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEvenLength(string str)
        {
            return str.Length % 2 == 0;
        }
        /// <summary>
        /// 计算字符串长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetStringLength(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            int length = 0;
            foreach (char c in str)
            {
                if (c > 127) // 如果是非ASCII字符
                {
                    length += 2; // 非ASCII字符占用2个字节
                }
                else
                {
                    length += 1; // ASCII字符占用1个字节
                }
            }
            return length;
        }

    }
}
