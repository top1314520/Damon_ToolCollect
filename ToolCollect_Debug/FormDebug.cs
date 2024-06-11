using Damon_ToolCollect;
using Microsoft.VisualBasic;
using System.Text;

namespace ToolCollect_Debug
{
    public partial class FormDebug : Form
    {
        public FormDebug()
        {
            InitializeComponent();
        }
        private RichTextBoxHelper _richTextBoxHelper { get; set; }
        private void FormDebug_Load(object sender, EventArgs e)
        {
            _richTextBoxHelper = new RichTextBoxHelper(richTextBox1);
        }
        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logBytesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogHelper logHelper = new LogHelper("Logs\\Bytes");
            //弹出输入框
            string input = Interaction.InputBox("请输入要写入的内容", "写入日志", "", 100, 100);
            byte[] data = Encoding.UTF8.GetBytes(input);
            logHelper.logBytes("test", data, 1);
            _richTextBoxHelper.Log(input, "统一调式");
        }
        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bytesToHexStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("请输入要转换的内容", "字节数组转16进制字符串", "", 100, 100);
            string ret_str = HexHelper.BytesToHexString(Encoding.UTF8.GetBytes(input));
            _richTextBoxHelper.Success(ret_str, "统一调式");
        }
        /// <summary>
        /// 16进制字符串转字节数组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hexStringToBytesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("请输入要转换的内容", "16进制字符串转字节数组", "", 100, 100);
            byte[] ret_bytes = HexHelper.HexStringToBytes(input);
            string ret_str = Encoding.UTF8.GetString(ret_bytes);
            _richTextBoxHelper.Warn(ret_str, "统一调式");
        }
        /// <summary>
        /// 判断对象或字符串是否为空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isNullOrEmptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object obj = null;
            string ret_str = BasicTypeHelper.IsNullOrEmpty(obj).ToString();
            _richTextBoxHelper.Success("对象null=>" + ret_str, "统一调式");
            ret_str = BasicTypeHelper.IsNullOrEmpty("123").ToString();
            _richTextBoxHelper.Success("字符串123=>" + ret_str, "统一调式");
        }
        /// <summary>
        /// 判断字符串是否为数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret_str = BasicTypeHelper.IsNumber("123").ToString();
            _richTextBoxHelper.Success("字符串123=>" + ret_str, "统一调式");
            ret_str = BasicTypeHelper.IsNumber("123a").ToString();
            _richTextBoxHelper.Success("字符串123a=>" + ret_str, "统一调式");
        }
        /// <summary>
        /// 写入日志(String)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret_str = Interaction.InputBox("请输入要写入的内容", "写入日志", "", 100, 100);
            LogHelper logHelper = new LogHelper("Logs\\String");
            logHelper.logString("test", ret_str);
            _richTextBoxHelper.Success("写入StringLog==>" + ret_str, "统一调式");
        }
        /// <summary>
        /// 写入日志(Dictionary)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret_str = Interaction.InputBox("请输入要写入的内容", "写入日志", "", 100, 100);
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();
            dataDictionary.Add("name", "张三");
            dataDictionary.Add("age", "18");
            LogHelper logHelper = new LogHelper("Logs\\Dictionary");
            logHelper.logDictionary("test", ret_str, dataDictionary);
            _richTextBoxHelper.Success("写入DictionaryLog==>" + ret_str, "统一调式");
        }
        /// <summary>
        /// 输出所有时间相关方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret_str = TimeHelper.GetDateTime();
            _richTextBoxHelper.Success("当前时间==>" + ret_str, "统一调式");
            ret_str = TimeHelper.GetDate();
            _richTextBoxHelper.Success("当前日期==>" + ret_str, "统一调式");
            long ret_long10 = TimeHelper.GetTimeStamp10();
            _richTextBoxHelper.Success("当前时间戳(10位)==>" + ret_long10, "统一调式");
            long ret_long13 = TimeHelper.GetTimeStamp13();
            _richTextBoxHelper.Success("当前时间戳(13位)==>" + ret_long13, "统一调式");
            ret_str = TimeHelper.GetTime13Utc(ret_long13).ToString();
            _richTextBoxHelper.Success("13位时间戳转时间UTC==>" + ret_str, "统一调式");
            ret_str = TimeHelper.GetTime10Utc(ret_long10).ToString();
            _richTextBoxHelper.Success("10位时间戳转时间UTC==>" + ret_str, "统一调式");
            ret_str = TimeHelper.GetTime13Local(ret_long13).ToString();
            _richTextBoxHelper.Success("13位时间戳转本地时间==>" + ret_str, "统一调式");
            ret_str = TimeHelper.GetTime10Local(ret_long10).ToString();
            _richTextBoxHelper.Success("10位时间戳转本地时间==>" + ret_str, "统一调式");
        }
        /// <summary>
        /// Json帮助类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jsonHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json = "{\"name\":\"张三\",\"age\":18}";
            _richTextBoxHelper.Success("Json==>" + json, "统一调式");
            string nodeName = "name";
            bool ret_bool = JsonHelper.IsJson(json);
            _richTextBoxHelper.Success("是否为Json==>" + ret_bool, "统一调式");
            ret_bool = JsonHelper.IsJsonNodeExist(json, nodeName);
            _richTextBoxHelper.Success("节点name是否存在==>" + ret_bool, "统一调式");
            object ret_obj = JsonHelper.GetJsonNodeValue(json, nodeName);
            _richTextBoxHelper.Success("节点name的值object==>" + ret_obj, "统一调式");
            string ret_str = JsonHelper.GetJsonNodeValueString(json, nodeName);
            _richTextBoxHelper.Success("节点name的值string==>" + ret_str, "统一调式");
            object ret_object = JsonHelper.JsonToObject<object>(json);
            _richTextBoxHelper.Success("Json转Object==>" + ret_object, "统一调式");
            ret_str = JsonHelper.ObjectToJson(ret_object);
            _richTextBoxHelper.Success("Object转Json==>" + ret_str, "统一调式");
        }
    }
}
