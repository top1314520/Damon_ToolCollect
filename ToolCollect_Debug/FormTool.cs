using Damon_ToolCollect;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolCollect_Debug
{
    public partial class FormTool : Form
    {
        public FormTool()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTool_Load(object sender, EventArgs e)
        {
            #region 设置水平线
            Label label_segment = new Label();
            label_segment.AutoSize = false;
            label_segment.Height = 1; //线的高度
            label_segment.Width = this.Width - 20; //线的宽度
            label_segment.BorderStyle = BorderStyle.Fixed3D;  // 3D 效果
            label_segment.BackColor = Color.Blue;  // 自定义颜色   Silver
            label_segment.Location = new Point(1, 28); //线的位置
            label_segment.BringToFront(); // 置于最上层
            label_segment.Visible = true; // 显示线
            this.Controls.Add(label_segment); // 添加到窗体控件集合中                   
            #endregion

        }
        /// <summary>
        /// Json解压(格式化)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_json_jy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_json_jy.Checked)
            {
                try
                {
                    if (!JsonHelper.IsJson(this.textBox_output.Text))
                    {
                        outputprompt.Text = "不是Json数据";
                        return;
                    }
                    this.textBox_output.Text = JobjectHelper.FormatJson(this.textBox_output.Text);
                    outputprompt.Text = " ";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// Json压缩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_json_ys_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_json_ys.Checked)
            {
                try
                {
                    if (!JsonHelper.IsJson(this.textBox_output.Text))
                    {
                        outputprompt.Text = "不是Json数据";
                        return;
                    }
                    this.textBox_output.Text = JobjectHelper.GetJson(this.textBox_output.Text);
                    outputprompt.Text = " ";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 十六进制字符串转 正常字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_hex_str_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_hex_str.Checked)
            {
                try
                {
                    if (!HexHelper.IsHexString(this.textBox_output.Text))
                    {
                        outputprompt.Text = "不是十六进制字符串数据";
                        return;
                    }
                    this.textBox_output.Text = HexHelper.HexStringToString(this.textBox_output.Text);
                    outputprompt.Text = " ";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 正常字符串转 十六进制字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_Str_HexStr_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_Str_HexStr.Checked)
            {
                try
                {
                    this.textBox_output.Text = HexHelper.StringToHexString(this.textBox_output.Text);
                    outputprompt.Text = " ";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 解析Protobuf数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_ProtoBuf_jm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_ProtoBuf_jm.Checked)
            {
                try
                {
                    if (!HexHelper.IsHexString(this.textBox_output.Text))
                    {
                        outputprompt.Text = "不是Protobuf数据";
                        return;
                    }
                    if (!ProtobufHelper.IsProtobuf(this.textBox_output.Text))
                    {
                        outputprompt.Text = "不是Protobuf数据";
                        return;
                    }
                    this.textBox_output.Text = ProtobufHelper.ParseAndFormatProtobuf(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_ProtoBuf_fxlh_CheckedChanged(object sender, EventArgs e)
        {
            outputprompt.Text = "暂未实现";
        }
        /// <summary>
        /// 解压1f数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_1f_jy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_1f_jy.Checked)
            {
                try
                {
                    if (!HexHelper.IsHexString(this.textBox_output.Text))
                    {
                        outputprompt.Text = "不是1f数据";
                        return;
                    }
                    if (!WinRAR_1f_DataHelper.Is1fData(this.textBox_output.Text))
                    {
                        outputprompt.Text = "不是1f数据";
                        return;
                    }
                    this.textBox_output.Text = WinRAR_1f_DataHelper.Decomress1f(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 压缩1f数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_1f_ys_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_1f_ys.Checked)
            {
                try
                {
                    this.textBox_output.Text = WinRAR_1f_DataHelper.Compress1f(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// grpc_1F数据压缩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_grpc_1f_ys_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_grpc_1f_ys.Checked)
            {
                try
                {
                    this.textBox_output.Text = WinRAR_1f_DataHelper.PackGrpc1f(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// grpc_1F数据解压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_grpc_1f_jy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_grpc_1f_jy.Checked)
            {
                try
                {
                    this.textBox_output.Text = WinRAR_1f_DataHelper.UnPackGrpc1f(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        
    }
}
