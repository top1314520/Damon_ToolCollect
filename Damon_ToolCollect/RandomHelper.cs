using System;
using System.Collections.Generic;
using System.Linq;
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
            //创建RNGCryptoServiceProvider的新实例
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            //用随机值填充数组
            rng.GetBytes(randomNumber);
            //将字节转换为uint值，使模数运算更容易
            uint randomResult = 0x0;
            for (int i = 0; i < length; i++)
            {
                randomResult |= ((uint)randomNumber[i] << ((length - 1 - i) * 8));
            }
            return (int)(randomResult % numSeeds) + 1;
        }
    }
}
