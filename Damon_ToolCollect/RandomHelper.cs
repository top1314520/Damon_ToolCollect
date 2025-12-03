using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class RandomHelper
    {
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <param name="isNumber">是否包含数字</param>
        /// <param name="isLower">是否包含小写字母</param>
        /// <param name="isUpper">是否包含大写字母</param>
        /// <returns></returns>
        public static string GetRandomString(int length, bool isNumber = true, bool isLower = true, bool isUpper = true)
        {
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int type = random.Next(1, 4);
                switch (type)
                {
                    case 1:
                        if (isNumber)
                        {
                            str += random.Next(0, 10);
                        }
                        else
                        {
                            i--;
                        }
                        break;
                    case 2:
                        if (isLower)
                        {
                            str += (char)random.Next(97, 123);
                        }
                        else
                        {
                            i--;
                        }
                        break;
                    case 3:
                        if (isUpper)
                        {
                            str += (char)random.Next(65, 91);
                        }
                        else
                        {
                            i--;
                        }
                        break;
                }
            }
            return str;
        }

        /// <summary>
        /// 随机UUID
        /// </summary>
        /// <returns></returns>
        public static string GetRandomUUID()
        {
            return Guid.NewGuid().ToString();
        }
        //根据时间生成唯一订单号
        public static string GetOrderNumber()
        {
            string strDateTimeNumber = DateTime.Now.ToString("yyyyMMddHHmmssms");
            string strRandomResult = NextRandom(1000, 1).ToString();
            return strDateTimeNumber + strRandomResult;
        }
        /// <summary>
        /// 参考：msdn上的RNGCryptoServiceProvider例子
        /// </summary>
        /// <param name="numSeeds"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static int NextRandom(int numSeeds, int length)
        {
            //创建一个字节数组来保存随机值  
            byte[] randomNumber = new byte[length];
            randomNumber = RandomNumberGenerator.GetBytes(length);
            //将字节转换为uint值，使模数运算更容易
            uint randomResult = 0x0;
            for (int i = 0; i < length; i++)
            {
                randomResult |= ((uint)randomNumber[i] << ((length - 1 - i) * 8));
            }
            return (int)(randomResult % numSeeds) + 1;
        }
        private static readonly Random random = new Random();
        public static string GenerateRandomDigits(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be greater than 0");
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(random.Next(0, 10)); // 生成0-9的随机数
            }
            return sb.ToString();
        }
        /// <summary>
        /// 随机虚拟号规则
        /// </summary>
        /// <param name="prefix">指定前面数字</param>
        /// <param name="totalLength">总长度</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GenerateFormattedString(string prefix, int totalLength)
        {
            if (totalLength <= prefix.Length)
            {
                throw new ArgumentException("Total length must be greater than prefix length");
            }
            // 计算剩余可用长度（前缀后至少需要1个0和1位随机数）
            int remainingLength = totalLength - prefix.Length - 1;
            // 确定随机数字的位数（最大4位，最小1位）
            int randomDigits = Math.Min(4, remainingLength);
            if (randomDigits < 1)
            {
                throw new ArgumentException("Total length is too short to include both prefix and random digits");
            }
            // 生成随机数字
            int minValue = (int)Math.Pow(10, randomDigits - 1);
            int maxValue = (int)Math.Pow(10, randomDigits) - 1;
            int randomNumber = random.Next(minValue, maxValue + 1);
            // 计算需要补零的数量
            int zerosToAdd = totalLength - prefix.Length - randomDigits;
            // 构建结果字符串
            var sb = new StringBuilder();
            sb.Append(prefix);
            sb.Append('0', zerosToAdd);
            sb.Append(randomNumber);
            return "+"+sb.ToString();
        }
        /// <summary>
        /// 随机虚拟号规则_同意规则(中间加3个0后面随机4位)
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string GenerateFormattedString(string prefix)
        {
            // 构建结果字符串
            var sb = new StringBuilder();
            sb.Append(prefix);
            sb.Append("000");
            sb.Append(GenerateRandomDigits(4));
            return "+" + sb.ToString();
        }
    }
}
