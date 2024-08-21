using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 读取指定文件的全部内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadFileAll(string filePath)
        {
            string content = string.Empty;
            if (System.IO.File.Exists(filePath))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    content = reader.ReadToEnd();
                }
            }
            return content;
        }
        /// <summary>
        /// 覆盖保存文件内容
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        public static void SaveFile(string filePath, string content)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }
        /// <summary>
        /// 读取指定文件的内容,返回每行list集合
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static List<string> ReadFile(string filePath)
        {
            List<string> list = new List<string>();
            if (System.IO.File.Exists(filePath))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 读取指定文件的内容,返回每行list集合(去除空行)
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<string> ReadFileWithoutEmpty(string filePath)
        {
            List<string> list = new List<string>();
            if (System.IO.File.Exists(filePath))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    string line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line.Trim()))
                        {
                            list.Add(line);
                        }
                    }
                }
            }
            return list;
        }
    }
}
