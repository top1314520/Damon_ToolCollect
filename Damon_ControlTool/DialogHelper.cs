using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ControlTool
{
    /// <summary>
    /// 对话框帮助类
    /// </summary>
    public class DialogHelper
    {
        /// <summary>
        /// 获取文件夹路径(FolderBrowserDialog)
        /// </summary>
        /// <returns></returns>
        public static string GetFolderPath()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return string.Empty;
        }
        /// <summary>
        /// 获取文件路径(OpenFileDialog)
        /// </summary>
        /// <param name="filter">指定后缀如:文本文件|*.txt, 所有文件|*.*", 文本文件|*.txt|所有文件|*.*</param>
        /// <returns></returns>
        public static string GetFilePath(string filter = "")
        {
            if (string.IsNullOrEmpty(filter))
            {
                filter = "所有文件|*.*";
            }
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.FileName;
            }
            return string.Empty;
        }
    }
}
