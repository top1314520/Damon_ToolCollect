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
        /// <summary>
        /// 合并2个Bytes
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <returns></returns>
        public static byte[] AddBytes(byte[] data1, byte[] data2)
        {
            byte[] data3 = new byte[data1.Length + data2.Length];
            data1.CopyTo(data3, 0);
            data2.CopyTo(data3, data1.Length);
            return data3;
        }
        /// <summary>
        /// 合并多个Bytes
        /// </summary>
        /// <param name="arrays"></param> 
        /// <returns></returns>
        public static byte[] AddBytes(params byte[][] arrays)
        {
            int totalLength = arrays.Sum(arr => arr.Length);
            byte[] result = new byte[totalLength];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                Buffer.BlockCopy(array, 0, result, offset, array.Length);
                offset += array.Length;
            }
            return result;
        }
    }
}
