using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class HmacshaHelper
    {
        /// <summary>
        /// HMACSHA1加密
        /// </summary>
        /// <param name="plaintext">明文</param>
        /// <returns></returns>
        public static string HMACSHA1(string plaintext)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.UTF8.GetBytes("cvumopflszdhrygb");
            byte[] dataBuffer = Encoding.UTF8.GetBytes(plaintext);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            string _sha1HexStr = HexHelper.BytesToHexString(hashBytes);
            return _sha1HexStr.ToUpper();
        }
    }
}
