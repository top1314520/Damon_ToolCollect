using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    public class TimeHelper
    {
        /// <summary>
        /// 2个时间相差的小时数
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        public static double DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            double dateDiff = 0;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.TotalHours;
            return dateDiff;
        }

        /// <summary>
        /// 用当前时间减去指定秒数再和当前时间比较大小(当前时间大于当前时间减去的秒数,则为true或者为false)
        /// </summary>
        /// <param name="second">秒数</param>
        /// <returns></returns>
        public static bool CompareTime(int second)
        {
            DateTime dt = DateTime.Now.AddSeconds(-second);
            return dt < DateTime.Now;
        }

        /// <summary>
        /// 获取当前日期(如：2024-06-06)
        /// </summary>
        /// <returns></returns>
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 获取当前时间(如：2024-06-06 12:12:12)
        /// </summary>
        /// <returns></returns>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>  
        /// 获取当前时间戳（13位，毫秒级）  
        /// </summary>  
        /// <returns></returns>  
        public static long GetTimeStamp13()
        {
            // 获取当前时间的 UTC DateTime 对象  
            DateTime utcNow = DateTime.UtcNow;
            // Unix 时间戳起始时间是 1970 年 1 月 1 日 00:00:00 UTC  
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            // 计算时间差并转换为毫秒  
            TimeSpan elapsed = utcNow - unixEpoch;
            // 返回毫秒数  
            return (long)elapsed.TotalMilliseconds;
        }
        /// <summary>  
        /// 获取当前时间戳（10位，秒级）  
        /// </summary>  
        /// <returns></returns>  
        public static long GetTimeStamp10()
        {
            // 获取当前时间的 UTC DateTimeOffset 对象  
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            // Unix 时间戳起始时间是 1970 年 1 月 1 日 00:00:00 UTC  
            DateTimeOffset unixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            // 计算时间差并转换为秒  
            TimeSpan elapsed = utcNow - unixEpoch;
            // 返回秒数  
            return (long)elapsed.TotalSeconds;
        }
        /// <summary>  
        /// 13位时间戳转为时间（UTC）  
        /// </summary>  
        /// <param name="timeStamp">13位时间戳（毫秒级）</param>  
        /// <returns>转换后的DateTime对象（UTC）</returns>  
        public static DateTime GetTime13Utc(long timeStamp)
        {
            // Unix 时间戳起始时间是 1970 年 1 月 1 日 00:00:00 UTC  
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            // 添加时间差，返回UTC时间  
            return unixEpoch.AddMilliseconds(timeStamp);
        }

        /// <summary>  
        /// 13位时间戳转为时间（本地时间）  
        /// </summary>  
        /// <param name="timeStamp">13位时间戳（毫秒级）</param>  
        /// <returns>转换后的DateTime对象（本地时间）</returns>  
        public static DateTime GetTime13Local(long timeStamp)
        {
            // 首先转换为UTC时间  
            DateTime utcDateTime = GetTime13Utc(timeStamp);
            // 然后转换为本地时间  
            return utcDateTime.ToLocalTime();
        }

        /// <summary>  
        /// 10位时间戳转为时间（UTC）  
        /// </summary>  
        /// <param name="timeStamp">10位时间戳（秒级）</param>  
        /// <returns>转换后的DateTime对象（UTC）</returns>  
        public static DateTime GetTime10Utc(long timeStamp)
        {
            // Unix 时间戳起始时间是 1970 年 1 月 1 日 00:00:00 UTC  
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            // 添加时间差，返回UTC时间  
            return unixEpoch.AddSeconds(timeStamp);
        }

        /// <summary>  
        /// 10位时间戳转为时间（本地时间）  
        /// </summary>  
        /// <param name="timeStamp">10位时间戳（秒级）</param>  
        /// <returns>转换后的DateTime对象（本地时间）</returns>  
        public static DateTime GetTime10Local(long timeStamp)
        {
            // 首先转换为UTC时间  
            DateTime utcDateTime = GetTime10Utc(timeStamp);
            // 然后转换为本地时间  
            return utcDateTime.ToLocalTime();
        }
        /// <summary>
        /// 计算代码执行时间 返回秒
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static double GetRunTime(Action action)
        {
            DateTime start = DateTime.Now;
            action();
            DateTime end = DateTime.Now;
            TimeSpan ts = end - start;
            return ts.TotalSeconds;
        }
    }
}
