using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// 基础类型帮助类
    /// </summary>
    public class BasicTypeHelper
    {
        /// <summary>
        /// 判断对象或字符串是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(object? obj)
        {
            return obj == null || string.IsNullOrEmpty(obj.ToString());
        }
        /// <summary>
        /// 判断字符串是否为数字
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isMinus">是否可以为负数;默认false不可以;true为可以</param>
        /// <returns></returns>
        public static bool IsNumber(string str,bool isMinus = false)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            foreach (char c in str)
            {
                if (isMinus)
                {
                    if (!char.IsNumber(c) && c != '-' && c != '+')
                    {
                        return false;
                    }
                }
                else
                {
                    if (!char.IsNumber(c))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="digits">保留小数点位数(为负数,则保留整数部分)</param>
        /// <returns></returns>
        public static double Round(double value, int digits)
        {
            return Math.Round(value, digits, MidpointRounding.AwayFromZero);
        }
        /// <summary>
        /// 向下取整
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static int Floor(double value)
        {
            return (int)Math.Floor(value);
        }
        /// <summary>
        /// 向上取整
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static int Ceiling(double value)
        {
            return (int)Math.Ceiling(value);
        }
    }
}
