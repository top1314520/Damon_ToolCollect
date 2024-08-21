using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// 路径帮助类
    /// </summary>
    public class PathHelper
    {
        /// <summary>
        /// 获取程序执行路径(后面没有"\\")
        /// </summary>
        /// <returns></returns>
        public static string GetAppPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }
        /// <summary>
        /// 获取程序运行的exe文件路径(如：G:\122\MailKitPop3Tool.exe)
        /// </summary>
        /// <returns></returns>
        //public static string GetAppExePath()
        //{
        //    return System.Windows.Forms.Application.ExecutablePath;
        //}
        /// <summary>
        /// 判断路径是否存在不存在则创建(文件夹)
        /// </summary>
        /// <param name="path"></param>
        public static void CreatePath(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }
        /// <summary>
        /// 判断文件是否存在不存在则创建(文件)
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.Create(filePath).Close();
            }
        }
    }
}
