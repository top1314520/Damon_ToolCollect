using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// 文件夹帮助类
    /// </summary>
    public class FolderHelper
    {
        /// <summary>
        /// 获取指定文件夹下的所有文件
        /// </summary>
        /// <param name="folderPath">文件夹路径</param>
        /// <param name="isSubFolder">是否包含子文件夹;true为包含；false为不包含</param>
        /// <returns></returns>
        public static List<string> GetFiles(string folderPath,bool isSubFolder = true)
        {
            List<string> files = new List<string>();
            if (System.IO.Directory.Exists(folderPath))
            {
                files.AddRange(System.IO.Directory.GetFiles(folderPath));//获取当前目录的文件
                if (isSubFolder)
                {
                    string[] folders = System.IO.Directory.GetDirectories(folderPath);//获取当前目录的子目录
                    foreach (string folder in folders)
                    {
                        files.AddRange(GetFiles(folder));//递归调用
                    }
                }
            }
            return files;
        }
    }
}
