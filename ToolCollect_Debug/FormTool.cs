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
                        List<string> retList = JsonHelper.ExtractAllValidJsonStrings(this.textBox_output.Text); //支持提取多个Json
                        if (retList.Count <= 0)
                        {
                            outputprompt.Text = "不是Json数据";
                            return;
                        }
                        string retStr = "";
                        for (int i = 0; i < retList.Count; i++)
                        {
                            retStr += JobjectHelper.FormatJson(retList[i]) + Environment.NewLine;
                        }
                        this.textBox_output.Text = retStr;
                        outputprompt.Text = " ";
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
                        List<string> retList = JsonHelper.ExtractAllValidJsonStrings(this.textBox_output.Text); //支持提取多个Json
                        if (retList.Count <= 0)
                        {
                            outputprompt.Text = "不是Json数据";
                            return;
                        }
                        string retStr = "";
                        for (int i = 0; i < retList.Count; i++)
                        {
                            retStr += JobjectHelper.GetJson(retList[i]) + Environment.NewLine;
                        }
                        this.textBox_output.Text = retStr;
                        outputprompt.Text = " ";
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
                    this.textBox_output.Text = StringHelper.RemoveNewLines(StringHelper.RemoveSpaces(this.textBox_output.Text));//去除空格和换行
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
        /// 解析Protobuf--
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_ProtoBuf_fxlh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_ProtoBuf_fxlh.Checked)
            {
                try
                {
                    this.textBox_output.Text = StringHelper.RemoveNewLines(StringHelper.RemoveSpaces(this.textBox_output.Text));//去除空格和换行
                    if (!HexHelper.IsHexString(this.textBox_output.Text))
                    {
                        outputprompt.Text = "不是Protobuf数据";
                        return;
                    }
                    this.textBox_output.Text = ProtobufHelper.ParseAndFormatProtobuf(this.textBox_output.Text, true);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
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

        private void 示例数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (radio_hex_str.Checked)
            {
                textBox_output.Text = "48656c6c6f20576f726c6421"; // Hello World!
                radio_hex_str.Checked = false;
            }
            else if (radio_Str_HexStr.Checked)
            {
                textBox_output.Text = "Hello World!";
                radio_Str_HexStr.Checked = false;
            }
            else if (radio_json_jy.Checked)
            {
                textBox_output.Text = "{\"name\":\"Damon\",\"age\":18,\"sex\":\"男\"}";
                radio_json_jy.Checked = false;
            }
            else if (radio_json_ys.Checked)
            {
                textBox_output.Text = "{\"name\":\"Damon\",\"age\":18,\"sex\":\"男\"}";
                radio_json_ys.Checked = false;
            }
            else if (radio_ProtoBuf_jm.Checked)
            {
                textBox_output.Text = "0A16636F6D2E676F6F676C652E616E64726F69642E676D7310FD82DA771A290A164D617073436F726544796E616D6974652E696E7465671A0F3235303632353430303130303430302001200220032005280228013801";
                radio_ProtoBuf_jm.Checked = false;
            }
            else if (radio_ProtoBuf_fxlh.Checked)
            {
                textBox_output.Text = "未实现";
                radio_ProtoBuf_fxlh.Checked = false;
            }
            else if (radio_1f_jy.Checked)
            {
                textBox_output.Text = "1F8B080000000000000AE3124BCECFD54BCFCF4FCF49D54BCC4B29CACF4CD14BCF2D16F8DB74AB5C4A934BCC37B1A0D839BF28D5A5322F3137B324552F33AF24355D8ADFC8D4C0CCC8D4C4C0C0D0C000482A302A3029302BB06A3069305A30020091C0C00456000000";
                radio_1f_jy.Checked = false;
            }
            else if (radio_1f_ys.Checked)
            {
                textBox_output.Text = "0A16636F6D2E676F6F676C652E616E64726F69642E676D7310FD82DA771A290A164D617073436F726544796E616D6974652E696E7465671A0F3235303632353430303130303430302001200220032005280228013801";
                radio_1f_ys.Checked = false;
            }
            else if (radio_grpc_1f_jy.Checked)
            {
                textBox_output.Text = "01000000691F8B080000000000000AE3124BCECFD54BCFCF4FCF49D54BCC4B29CACF4CD14BCF2D16F8DB74AB5C4A934BCC37B1A0D839BF28D5A5322F3137B324552F33AF24355D8ADFC8D4C0CCC8D4C4C0C0D0C000482A302A3029302BB06A3069305A30020091C0C00456000000";
                radio_grpc_1f_jy.Checked = false;
            }
            else if (radio_grpc_1f_ys.Checked)
            {
                textBox_output.Text = "0A16636F6D2E676F6F676C652E616E64726F69642E676D7310FD82DA771A290A164D617073436F726544796E616D6974652E696E7465671A0F3235303632353430303130303430302001200220032005280228013801";
                radio_grpc_1f_ys.Checked = false;
            }
            else if (radio_url_bm.Checked)
            {
                textBox_output.Text = "https://www.baidu.com/s?wd=hello%20world";
                radio_url_bm.Checked = false;
            }
            else if (radio_url_jm.Checked)
            {
                textBox_output.Text = "https://www.baidu.com/s?wd=hello world";
                radio_url_jm.Checked = false;
            }
            else if (radio_base64_bm.Checked)
            {
                textBox_output.Text = "Hello World!";
                radio_base64_bm.Checked = false;
            }
            else if (radio_base64_jm.Checked)
            {
                textBox_output.Text = "SGVsbG8gV29ybGQh";
                radio_base64_jm.Checked = false;
            }
            else if (radio_base64_hex_bm.Checked)
            {
                textBox_output.Text = "0a16636f6d2e676f6f676c652e616e64726f69642e676d7310fd82da771a290a164d617073436f726544796e616d6974652e696e7465671a0f3235303632353430303130303430302001200220032005280228013801"; // Hello World!
                radio_base64_hex_bm.Checked = false;
            }
            else if (radio_base64_hex_jm.Checked)
            {
                textBox_output.Text = "ChZjb20uZ29vZ2xlLmFuZHJvaWQuZ21zEP2C2ncaKQoWTWFwc0NvcmVEeW5hbWl0ZS5pbnRlZxoPMjUwNjI1NDAwMTAwNDAwIAEgAiADIAUoAigBOAE=";
                radio_base64_hex_jm.Checked = false;
            }
            else if (radio_hex_jkg.Checked)
            {
                textBox_output.Text = "0a16636f6d2e676f6f676c652e616e64726f69642e676d7310fd82da771a290a164d617073436f726544796e616d6974652e696e7465671a0f3235303632353430303130303430302001200220032005280228"; // Hello World!
                radio_hex_jkg.Checked = false;
            }
            else if (radio_hex_dz.Checked)
            {
                textBox_output.Text = "0a16636f6d2e676f6f676c652e616e64726f69642e676d7310fd82da771a290a164d617073436f726544796e616d6974652e696e7465671a0f3235303632353430303130303430302001200220032005280228"; // Hello World!
                radio_hex_dz.Checked = false;
            }
            else if (radio_789_ys.Checked)
            {
                textBox_output.Text = "0a16636f6d2e676f6f676c652e616e64726f69642e676d7310fd82da771a290a164d617073436f726544796e616d6974652e696e7465671a0f3235303632353430303130303430302001200220032005280228";
                radio_789_ys.Checked = false;
            }
            else if (radio_789_jy.Checked)
            {
                textBox_output.Text = "789CE3124BCECFD54BCFCF4FCF49D54BCC4B29CACF4CD14BCF2D16F8DB74AB5C4A934BCC37B1A0D839BF28D5A5322F3137B324552F33AF24355D8ADFC8D4C0CCC8D4C4C0C0D0C000482A302A3029302BB06A30690000A83F185F"; // Hello World!
                radio_789_jy.Checked = false;
            }
            else if (radio_Str_qkg.Checked)
            {
                textBox_output.Text = "Hello World!";
                radio_Str_qkg.Checked = false;
            }
            else if (radio_Str_qhh.Checked)
            {
                textBox_output.Text = "Hello\r\nWorld!";
                radio_Str_qhh.Checked = false;
            }
            else if (radio_dump_hex.Checked)
            {
                textBox_output.Text = "00000000  0a 16 63 6f 6d 2e 67 6f 67 6c 65 2e 61 6e 64 72   |..com.google.andr|\r\n" +
                                      "00000010  6f 69 64 2e 67 6d 73 10 fd 82 da 77 1a 29 0a 16   |oid.gms...w.)...|\r\n" +
                                      "00000020  d6 f4 d7 a3 c4 b2 c4 b2 c4 b2 c4 b2 c4 b2 c4 b2   |.................|\r\n" +
                                      "00000030  c4 b2 c4 b2 c4 b2 c4 b2 c4 b2 c4 b2 c4 b2 c4 b2   |.................|\r\n" +
                                      "00000040  c4 b2 c4 b2 c4 b2 c4 b2 c4 b2 c4 b2 c4 b2 c4 b2   |.................|\r\n" +
                                      "00000050";
                radio_dump_hex.Checked = false;
            }
            else if (radio_thrift_jx.Checked)
            {
                textBox_output.Text = "8221010d676574436f6e746163747356321c1918217566333133613233653337666537303834396464663661323462386436396234631a051200151000";
                radio_thrift_jx.Checked = false;
            }
            else if (radio_thrift_tbinary.Checked)
            {
                textBox_output.Text = "0C00010B000100000013313933353532383339303933303633363830300B00020000002431623261366430322D376462622D346264362D626163622D6562383036303730613262360B000300000013313933343531343539393131393937343430310B000400000027313933343531343539393131393937343430313A313933343531343539393131393937343430310B0005000000D765794A68624763694F694A49557A49314E694A392E65794A795A5846315A584E306157356E56584E6C63694936494349784F544D304E5445304E546B354D5445354F5463304E44417849697767496E4A6C59326C776157567564434936494349784F544D304E5445304E546B354D5445354F5463304E44417849697767496E5A6862476C6B55326C755932564E5532566A496A6F67496A45334E4455344F4451344D4441774D44416966512E7A316E63756A7A39654E31714133786957334C37536E42514D5A52514B666C32367A5F6F2D7244415F4B6F0B00060000000D313735303330303930333433340C00070C00010B0064000000566BE99037C5DE25F54BDEEEFAE89277EEBD6C0798B2B7C779F2AA7E10033A41D915FEB4892E80AF266B8B42F55E590598318F8B24976CE709EC65BF1B53DDD8CD51978E5972ED086964502C3233BB93007AD45792C1C90B00650000000D31373530323938383834303730020066000A0068000001978610482A0000080008000000000000";
                radio_thrift_tbinary.Checked = false;
            }
            else if (radio_str_zy.Checked)
            {
                textBox_output.Text = "{\"region\":\"英国\",\"resourceCode\":\"1104\",\"resourceName\":\"ipweb-am-short\",\"ip\":\"gate3.ipweb.cc\",\"port\":7778,\"username\":\"B_37676_GB___30_d86z76jxw0\",\"password\":\"ipwebAa\"}";
                radio_str_zy.Checked = false;
            }
            else if (radio_str_qzy.Checked)
            {
                textBox_output.Text = "{\\\"region\\\":\\\"英国\\\",\\\"resourceCode\\\":\\\"1104\\\",\\\"resourceName\\\":\\\"ipweb-am-short\\\",\\\"ip\\\":\\\"gate3.ipweb.cc\\\",\\\"port\\\":7778,\\\"username\\\":\\\"B_37676_GB___30_d86z76jxw0\\\",\\\"password\\\":\\\"ipwebAa\\\"}";
                radio_str_qzy.Checked = false;
            }
        }
        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_url_bm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_url_bm.Checked)
            {
                try
                {
                    this.textBox_output.Text = UrlHelper.UrlEncode(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_url_jm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_url_jm.Checked)
            {
                try
                {
                    this.textBox_output.Text = UrlHelper.UrlDecode(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// Base64编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_base64_bm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_base64_bm.Checked)
            {
                try
                {
                    if (JsonHelper.IsJson(this.textBox_output.Text))
                    {
                        this.textBox_output.Text = JsonBase64Helper.EncodeHexToBase64InJson(this.textBox_output.Text);
                        outputprompt.Text = "";
                        return;
                    }
                    this.textBox_output.Text = Base64Helper.Base64_Encode(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_base64_jm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_base64_jm.Checked)
            {
                try
                {
                    if (JsonHelper.IsJson(this.textBox_output.Text))
                    {
                        this.textBox_output.Text = JsonBase64Helper.DecodeBase64InJson(this.textBox_output.Text);
                        outputprompt.Text = "";
                        return;
                    }

                    this.textBox_output.Text = Base64Helper.Base64_Decode(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// Hex转Base64_编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_base64_hex_bm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_base64_hex_bm.Checked)
            {
                try
                {
                    if (JsonHelper.IsJson(this.textBox_output.Text))
                    {
                        this.textBox_output.Text = JsonBase64Helper.EncodeHexToBase64InJson(this.textBox_output.Text);
                        outputprompt.Text = "";
                        return;
                    }
                    this.textBox_output.Text = Base64Helper.HexToBase64(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// Base64转Hex_解码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_base64_hex_jm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_base64_hex_jm.Checked)
            {
                try
                {
                    if (JsonHelper.IsJson(this.textBox_output.Text))
                    {
                        this.textBox_output.Text = JsonBase64Helper.DecodeBase64InJson(this.textBox_output.Text);
                        outputprompt.Text = "";
                        return;
                    }
                    this.textBox_output.Text = Base64Helper.Base64ToHex(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 格式化十六进制字符串_加空格和16个换行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_hex_jkg_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_hex_jkg.Checked)
            {
                try
                {
                    this.textBox_output.Text = HexHelper.FormatHexStringWithLineBreaks(this.textBox_output.Text, 16);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 十六进制倒置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_hex_dz_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_hex_dz.Checked)
            {
                try
                {
                    this.textBox_output.Text = HexHelper.ReverseHexString(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 789数据压缩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_789_ys_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_789_ys.Checked)
            {
                try
                {
                    this.textBox_output.Text = WinRAR_789_DataHelper.compress(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 789数据解压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_789_jy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_789_jy.Checked)
            {
                try
                {
                    this.textBox_output.Text = WinRAR_789_DataHelper.decompress(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 去字符串空格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_Str_qkg_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_Str_qkg.Checked)
            {
                try
                {
                    this.textBox_output.Text = StringHelper.RemoveSpaces(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 去字符串换行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_Str_qhh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_Str_qhh.Checked)
            {
                try
                {
                    this.textBox_output.Text = StringHelper.RemoveNewLines(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// Dump格式数据转十六进制字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_dump_hex_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_dump_hex.Checked)
            {
                try
                {
                    this.textBox_output.Text = HexHelper.ExtractHexData_Dump(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// thrift 数据解析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_thrift_jx_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_thrift_jx.Checked)
            {
                try
                {
                    this.textBox_output.Text = ThriftHelper.ThriftUnPackToJson(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// thrift tbinary解析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_thrift_tbinary_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_thrift_tbinary.Checked)
            {
                try
                {
                    this.textBox_output.Text = ThriftHelper.retThrift_TBinary(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 字符_转义(添加转义)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_str_zy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_str_zy.Checked)
            {
                try
                {
                    this.textBox_output.Text = StringHelper.AddEscape(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// 字符串_去转义(移除转义)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_str_qzy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_str_qzy.Checked)
            {
                try
                {
                    this.textBox_output.Text = StringHelper.RemoveEscape(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
            }
        }
        /// <summary>
        /// xml_解压
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_xml_jy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_xml_jy.Checked)
            {
                try
                {
                    this.textBox_output.Text = XmlHelper.FormatNamespacedXml(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
                this.radio_xml_jy.Checked = false;
            }
        }
        /// <summary>
        /// xml_压缩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_xml_ys_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_xml_ys.Checked)
            {
                try
                {
                    this.textBox_output.Text = XmlHelper.FormatNamespacedXml(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
                this.radio_xml_ys.Checked = false;
            }
        }
        /// <summary>
        /// 生成 HMACSHA1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_jm_hmacsha1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radio_jm_hmacsha1.Checked)
            {
                try
                {
                    this.textBox_output.Text = HmacshaHelper.HMACSHA1(this.textBox_output.Text);
                    outputprompt.Text = "";
                }
                catch (Exception ex)
                {
                    outputprompt.Text = ex.Message;
                }
                this.radio_jm_hmacsha1.Checked = false;
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string imsi = SimCardHelper.GenerateImsi("", this.textBox_output.Text);
                string iccid = SimCardHelper.GenerateIccid("", this.textBox_output.Text);

                this.textBox_output.Text = imsi + Environment.NewLine + iccid;
                outputprompt.Text = "";
            }
            catch (Exception ex)
            {
                outputprompt.Text = ex.Message;
            }
        }
    }
}
