using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ToolCollect
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        private string directoryPath = string.Empty;
        public LogHelper(string folderName = "logs") 
        {
            if (!string.IsNullOrEmpty(folderName))
            {
                if (!folderName.EndsWith("\\"))
                {
                    folderName += "\\";
                }
                directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);
            }
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("LogHelper创建路径失败:" + ex.Message);
            }
        }
        /// <summary>
        /// 写入日志(Byte[])
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="data">日志内容</param>
        /// <param name="dataType">明文1；密文2</param>
        /// <param name="logLeve">是否记录本地日志：默认true为记录</param>
        public void logBytes(string filename, byte[] data, int dataType = 0, bool logLeve = true)
        {
            if (logLeve)
            {
                string dataStr = BytesToHexString(data);
                if (dataType == 1)
                {
                    info(filename, "明文=>" + dataStr);
                }
                else if (dataType == 2)
                {
                    info(filename, "密文=>" + dataStr);
                }
                else
                {
                    info(filename, dataStr);
                }
            }
        }
        /// <summary>
        /// 写入日志(String)
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="dataStr">日志内容</param>
        /// <param name="logLeve">是否记录本地日志：默认true为记录</param>
        public void logString(string filename, string dataStr, bool logLeve = true)
        {
            if (logLeve)
            {
                info(filename, dataStr);
            }
        }

        /// <summary>
        /// 写入日志(Dictionary)
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <param name="describe">描述：HEAD_DATA</param>
        /// <param name="dataDictionary">Dictionary对象数据</param>
        /// <param name="logLeve">是否记录本地日志：默认true为记录</param>
        public void logDictionary(string filename, string describe, Dictionary<string, string> dataDictionary, bool logLeve = true)
        {
            if (logLeve)
            {
                string dataStr = GetDictionaryString(dataDictionary);
                info(filename, describe + "==>" + dataStr);
            }
        }


        #region 私有
        private string GetDictionaryString(Dictionary<string, string> dataDictionary)
        {
            string result = "";
            if (dataDictionary != null)
            {
                foreach (var keyValue in dataDictionary)
                {
                    result += Environment.NewLine + keyValue.Key + "=" + keyValue.Value + ";";
                }
            }
            return result;
        }
        private volatile object _Lock = new object();
        private void info(string pre, string log)
        {
            lock (_Lock)
            {
                try
                {
                    string path = directoryPath + "{0}_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                    string message_pre = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffff") + ">>> " + log + "\r\n";
                    File.AppendAllText(string.Format(path, pre), message_pre, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    throw new Exception("写入文件失败:" + ex.Message);
                }
            }
        }
        /// <summary>
        /// byte数组转十六进制字符串
        /// </summary>
        /// <param name="byteArray">数据</param>
        /// <param name="nType">类型：0为默认;1为全部大写;2为全部小写</param>
        /// <returns></returns>
        private static string BytesToHexString(byte[] byteArray, int nType = 0)
        {
            string hexString = "";
            try
            {
                if (nType == 0)
                {
                    hexString = BitConverter.ToString(byteArray, 0, byteArray.Length).Replace("-", string.Empty);
                }
                else if (nType == 1)
                {
                    hexString = BitConverter.ToString(byteArray, 0, byteArray.Length).Replace("-", string.Empty).ToUpper();
                }
                else
                {
                    hexString = BitConverter.ToString(byteArray, 0, byteArray.Length).Replace("-", string.Empty).ToLower();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BytesToHexString异常:" + ex.Message);
            }
            return hexString;
        } 
        #endregion
    }
}
