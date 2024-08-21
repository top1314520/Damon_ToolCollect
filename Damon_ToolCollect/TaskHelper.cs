using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// 任务帮助类
    /// </summary>
    public class TaskHelper
    {
        /// <summary>
        /// 计算平均任务持续时间（秒）
        /// </summary>
        /// <param name="taskCount">需要执行的任务数量</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int CalculateAverageTaskDurationInSeconds(int taskCount, DateTime endTime)
        {
            // 获取当前时间  
            DateTime currentTime = DateTime.Now;
            // 检查结束时间是否已经过去  
            if (endTime <= currentTime)
            {
                throw new ArgumentException("结束时间不能小于或等于当前时间");
            }
            // 计算时间间隔  
            TimeSpan interval = endTime - currentTime;
            // 计算总秒数  
            double totalSeconds = interval.TotalSeconds;
            // 如果任务数为0，则无法计算平均时间  
            if (taskCount == 0)
            {
                throw new ArgumentException("任务数不能为0");
            }
            // 计算每个任务需要的平均时间（秒）  
            double averageTaskDurationInSeconds = totalSeconds / taskCount;
            int averageTaskDurationInSecondsInt = Convert.ToInt32(averageTaskDurationInSeconds);
            // 返回平均时间
            return averageTaskDurationInSecondsInt;
        }
    }
}
