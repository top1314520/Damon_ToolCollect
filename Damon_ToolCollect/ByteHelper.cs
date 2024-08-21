using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class ByteHelper
    {
        /// <summary>
        /// Byte数组转字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
        /// <summary>
        /// 字符串转Byte数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
