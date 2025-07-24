using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class SimCardHelper
    {
        // 使用ThreadLocal确保每个线程有独立的Random实例
        private static readonly ThreadLocal<Random> _random =
            new ThreadLocal<Random>(() =>
            {
                // 使用Guid的哈希码作为种子，增加随机性
                return new Random(Guid.NewGuid().GetHashCode());
            });
        /*
         * US,311274,Verizon,311274080192229,89311274853709766774
           US,311274,Verizon,311274639079034,89311274386088701583
         规则分析
            IMSI (International Mobile Subscriber Identity)
            格式：MCC(3位) + MNC(2-3位) + MSIN(9-10位)
            在示例中：
            美国 MCC 是 310 或 311
            MNC 是运营商代码的后3位
            MSIN 是9位随机数字
            ICCID (Integrated Circuit Card Identifier)
            格式：89(固定) + 国家代码 + 运营商代码 + 个人账号 + 校验位
            在示例中：
            开头固定为89
            然后是3位国家代码(如311)
            接着是运营商代码(如274)
            然后是16位随机数字
            最后1位校验位
         
         */
        /// <summary>
        /// 生成imsi
        /// </summary>
        /// <param name="countryCode">国家二级宿写(预留)</param>
        /// <param name="operatorCode">运营商代码(6位数字)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GenerateImsi(string countryCode, string operatorCode)
        {
            if (operatorCode == null || operatorCode.Length != 6)
                throw new ArgumentException("Operator code must be 6 digits", nameof(operatorCode));

            string mcc = operatorCode.Substring(0, 3);
            string mnc = operatorCode.Substring(3);
            string msin = GenerateRandomDigits(9);

            return mcc + mnc + msin;
        }
        /// <summary>
        /// 生成ICCID号码
        /// </summary>
        /// <param name="countryCode">国家二级宿写(预留)</param>
        /// <param name="operatorCode">运营商代码(6位数字)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GenerateIccid(string countryCode, string operatorCode)
        {
            if (operatorCode == null || operatorCode.Length != 6)
                throw new ArgumentException("Operator code must be 6 digits", nameof(operatorCode));

            StringBuilder sb = new StringBuilder("89");
            sb.Append(operatorCode);
            sb.Append(GenerateRandomDigits(16));

            char checkDigit = CalculateLuhnCheckDigit(sb.ToString());
            sb.Append(checkDigit);

            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GenerateRandomDigits(int length)
        {
            var random = _random.Value;
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(random.Next(0, 10));
            }
            return sb.ToString();
        }
        private static char CalculateLuhnCheckDigit(string data)
        {
            int sum = 0;
            bool alternate = false;

            for (int i = data.Length - 1; i >= 0; i--)
            {
                int digit = data[i] - '0';

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit = (digit % 10) + 1;
                    }
                }
                sum += digit;
                alternate = !alternate;
            }
            int checkDigit = (10 - (sum % 10)) % 10;
            return (char)(checkDigit + '0');
        }

    }
}
