using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// 检测帮助类
    /// </summary>
    public class CheckHelper
    {
        /// <summary>
        /// 检测字符串是否是Sql语句
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckSql(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            string[] sqlCheck = { "select", "insert", "update", "delete", "drop", "truncate", "exec", "xp_cmdshell", "net user", "net localgroup administrators" };
            foreach (var item in sqlCheck)
            {
                if (str.ToLower().Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 检测字符串是否是查询Sql语句格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckSelectSql(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            if (str.ToLower().Contains("select") && str.ToLower().Contains("from"))
            {
                return true;
            }
            return false;
        }

    }
}
