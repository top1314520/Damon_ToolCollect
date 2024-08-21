using Damon_ToolCollect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damon_ControlTool
{
    /// <summary>
    /// 日志附件 委托
    /// </summary>
    /// <param name="color">输出字体颜色</param>
    /// <param name="text">输出内容</param>
    delegate void LogAppend(Color color, string text);
    /// <summary>
    /// RichTextBox输出帮助类
    /// </summary>
    public class RichTextBoxHelper
    {

        private RichTextBox _richTextBox { get; set; }
        private LogHelper _logHelper { get; set; }
        private string _tag { get; set; } = "logRichText";
        public RichTextBoxHelper(RichTextBox richTextBox)
        {
            this._richTextBox = richTextBox;
            this._logHelper = new LogHelper("LogRichText");
        }

        /// <summary>
        /// 成功日志(绿色)
        /// </summary>
        /// <param name="countent"></param>
        /// <param name="fileName"></param>
        /// <param name="isLocal"></param>
        public void Success(string countent, string fileName = "", bool isLocal = true)
        {
            if (isLocal)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    this._logHelper.logString(_tag + "_" + TimeHelper.GetDate(), countent);
                }
                else
                {
                    this._logHelper.logString(fileName, countent);
                }
            }
            LogAppend la = new LogAppend(LogAppendMethod);
            this._richTextBox.Invoke(la, Color.Chartreuse, countent);
        }
        /// <summary>
        /// 错误日志(淡红色)
        /// </summary>
        /// <param name="countent"></param>
        /// <param name="fileName"></param>
        /// <param name="isLocal"></param>
        public void Error(string countent, string fileName = "", bool isLocal = true)
        {
            if (isLocal)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    this._logHelper.logString(_tag + "_" + TimeHelper.GetDate(), countent);
                }
                else
                {
                    this._logHelper.logString(fileName, countent);
                }
            }
            LogAppend la = new LogAppend(LogAppendMethod);
            this._richTextBox.Invoke(la, Color.LightPink, countent);
        }
        /// <summary>
        /// 常规日志(白色)
        /// </summary>
        /// <param name="countent"></param>
        /// <param name="fileName"></param>
        /// <param name="isLocal"></param>
        public void Log(string countent, string fileName = "", bool isLocal = true)
        {
            if (isLocal)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    this._logHelper.logString(_tag + "_" + TimeHelper.GetDate(), countent);
                }
                else
                {
                    this._logHelper.logString(fileName, countent);
                }
            }
            LogAppend la = new LogAppend(LogAppendMethod);
            this._richTextBox.Invoke(la, Color.White, countent);
        }
        /// <summary>
        /// 警告日志(深黄色)
        /// </summary>
        /// <param name="countent"></param>
        /// <param name="fileName"></param>
        /// <param name="isLocal"></param>
        public void Warn(string countent, string fileName = "", bool isLocal = true)
        {
            if (isLocal)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    this._logHelper.logString(_tag + "_" + TimeHelper.GetDate(), countent);
                }
                else
                {
                    this._logHelper.logString(fileName, countent);
                }
            }
            LogAppend la = new LogAppend(LogAppendMethod);
            this._richTextBox.Invoke(la, Color.Orange, countent);
        }
        /// <summary>
        /// 蓝色
        /// </summary>
        /// <param name="countent"></param>
        /// <param name="fileName"></param>
        /// <param name="isLocal"></param>
        public void DeepSkyBlue(string countent, string fileName = "", bool isLocal = true)
        {
            if (isLocal)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    this._logHelper.logString(_tag + "_" + TimeHelper.GetDate(), countent);
                }
                else
                {
                    this._logHelper.logString(fileName, countent);
                }
            }
            LogAppend la = new LogAppend(LogAppendMethod);
            this._richTextBox.Invoke(la, Color.DeepSkyBlue, countent);
        }
        /// <summary>
        /// 深紫色
        /// </summary>
        /// <param name="countent"></param>
        /// <param name="fileName"></param>
        /// <param name="isLocal"></param>
        public void BlueViolet(string countent, string fileName = "", bool isLocal = true)
        {
            if (isLocal)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    this._logHelper.logString(_tag + "_" + TimeHelper.GetDate(), countent);
                }
                else
                {
                    this._logHelper.logString(fileName, countent);
                }
            }
            LogAppend la = new LogAppend(LogAppendMethod);
            this._richTextBox.Invoke(la, Color.BlueViolet, countent);
        }
        /// <summary>
        /// 深绿色
        /// </summary>
        /// <param name="countent"></param>
        /// <param name="fileName"></param>
        /// <param name="isLocal"></param>
        public void DarkGreen(string countent, string fileName = "", bool isLocal = true)
        {
            if (isLocal)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    this._logHelper.logString(_tag + "_" + TimeHelper.GetDate(), countent);
                }
                else
                {
                    this._logHelper.logString(fileName, countent);
                }
            }
            LogAppend la = new LogAppend(LogAppendMethod);
            this._richTextBox.Invoke(la, Color.DarkGreen, countent);
        }

        /// <summary>
        /// 自定义颜色
        /// </summary>
        /// <param name="countent"></param>
        /// <param name="fileName"></param>
        /// <param name="isLocal"></param>
        public void CustomColor(string countent, Color color, string fileName = "", bool isLocal = true)
        {
            if (isLocal)
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    this._logHelper.logString(_tag + "_" + TimeHelper.GetDate(), countent);
                }
                else
                {
                    this._logHelper.logString(fileName, countent);
                }
            }
            if (color == null)
            {
                color = Color.Cyan; //青色
            }
            LogAppend la = new LogAppend(LogAppendMethod);
            this._richTextBox.Invoke(la, color, countent);
        }


        /// <summary>
        /// RichTextBox日志追加方法
        /// </summary>
        /// <param name="color"></param>
        /// <param name="text"></param>
        private void LogAppendMethod(Color color, string text)
        {
            if (this._richTextBox.Disposing || this._richTextBox.IsDisposed)
            {
                return;
            }
            this._richTextBox.SelectionColor = Color.White; //Color.FromArgb(35, 155, 200);
            this._richTextBox.AppendText(DateTime.Now.ToString("HH:mm:ss") + " >  ");
            this._richTextBox.SelectionColor = color;
            this._richTextBox.AppendText(text + Environment.NewLine);
            this._richTextBox.ScrollToCaret();
            if (this._richTextBox.Lines.Length > 20000)
            {
                this._richTextBox.Clear();
                this._richTextBox.SelectionColor = Color.FromArgb(35, 155, 200);
                this._richTextBox.AppendText(DateTime.Now.ToString("HH:mm:ss") + " >  ");
                this._richTextBox.SelectionColor = color;
                this._richTextBox.AppendText("清空日志" + Environment.NewLine);
                this._richTextBox.ScrollToCaret();
            }
            Debug.WriteLine(text);
        }
    }
}
