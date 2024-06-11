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
        /// ��־��¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logBytesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogHelper logHelper = new LogHelper("Logs\\Bytes");
            //���������
            string input = Interaction.InputBox("������Ҫд�������", "д����־", "", 100, 100);
            byte[] data = Encoding.UTF8.GetBytes(input);
            logHelper.logBytes("test", data, 1);
            _richTextBoxHelper.Log(input, "ͳһ��ʽ");
        }
        /// <summary>
        /// �ֽ�����ת16�����ַ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bytesToHexStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("������Ҫת��������", "�ֽ�����ת16�����ַ���", "", 100, 100);
            string ret_str = HexHelper.BytesToHexString(Encoding.UTF8.GetBytes(input));
            _richTextBoxHelper.Success(ret_str, "ͳһ��ʽ");
        }
        /// <summary>
        /// 16�����ַ���ת�ֽ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hexStringToBytesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("������Ҫת��������", "16�����ַ���ת�ֽ�����", "", 100, 100);
            byte[] ret_bytes = HexHelper.HexStringToBytes(input);
            string ret_str = Encoding.UTF8.GetString(ret_bytes);
            _richTextBoxHelper.Warn(ret_str, "ͳһ��ʽ");
        }
        /// <summary>
        /// �ж϶�����ַ����Ƿ�Ϊ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isNullOrEmptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            object obj = null;
            string ret_str = BasicTypeHelper.IsNullOrEmpty(obj).ToString();
            _richTextBoxHelper.Success("����null=>" + ret_str, "ͳһ��ʽ");
            ret_str = BasicTypeHelper.IsNullOrEmpty("123").ToString();
            _richTextBoxHelper.Success("�ַ���123=>" + ret_str, "ͳһ��ʽ");
        }
        /// <summary>
        /// �ж��ַ����Ƿ�Ϊ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret_str = BasicTypeHelper.IsNumber("123").ToString();
            _richTextBoxHelper.Success("�ַ���123=>" + ret_str, "ͳһ��ʽ");
            ret_str = BasicTypeHelper.IsNumber("123a").ToString();
            _richTextBoxHelper.Success("�ַ���123a=>" + ret_str, "ͳһ��ʽ");
        }
        /// <summary>
        /// д����־(String)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret_str = Interaction.InputBox("������Ҫд�������", "д����־", "", 100, 100);
            LogHelper logHelper = new LogHelper("Logs\\String");
            logHelper.logString("test", ret_str);
            _richTextBoxHelper.Success("д��StringLog==>" + ret_str, "ͳһ��ʽ");
        }
        /// <summary>
        /// д����־(Dictionary)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret_str = Interaction.InputBox("������Ҫд�������", "д����־", "", 100, 100);
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();
            dataDictionary.Add("name", "����");
            dataDictionary.Add("age", "18");
            LogHelper logHelper = new LogHelper("Logs\\Dictionary");
            logHelper.logDictionary("test", ret_str, dataDictionary);
            _richTextBoxHelper.Success("д��DictionaryLog==>" + ret_str, "ͳһ��ʽ");
        }
        /// <summary>
        /// �������ʱ����ط���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret_str = TimeHelper.GetDateTime();
            _richTextBoxHelper.Success("��ǰʱ��==>" + ret_str, "ͳһ��ʽ");
            ret_str = TimeHelper.GetDate();
            _richTextBoxHelper.Success("��ǰ����==>" + ret_str, "ͳһ��ʽ");
            long ret_long10 = TimeHelper.GetTimeStamp10();
            _richTextBoxHelper.Success("��ǰʱ���(10λ)==>" + ret_long10, "ͳһ��ʽ");
            long ret_long13 = TimeHelper.GetTimeStamp13();
            _richTextBoxHelper.Success("��ǰʱ���(13λ)==>" + ret_long13, "ͳһ��ʽ");
            ret_str = TimeHelper.GetTime13Utc(ret_long13).ToString();
            _richTextBoxHelper.Success("13λʱ���תʱ��UTC==>" + ret_str, "ͳһ��ʽ");
            ret_str = TimeHelper.GetTime10Utc(ret_long10).ToString();
            _richTextBoxHelper.Success("10λʱ���תʱ��UTC==>" + ret_str, "ͳһ��ʽ");
            ret_str = TimeHelper.GetTime13Local(ret_long13).ToString();
            _richTextBoxHelper.Success("13λʱ���ת����ʱ��==>" + ret_str, "ͳһ��ʽ");
            ret_str = TimeHelper.GetTime10Local(ret_long10).ToString();
            _richTextBoxHelper.Success("10λʱ���ת����ʱ��==>" + ret_str, "ͳһ��ʽ");
        }
        /// <summary>
        /// Json������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jsonHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string json = "{\"name\":\"����\",\"age\":18}";
            _richTextBoxHelper.Success("Json==>" + json, "ͳһ��ʽ");
            string nodeName = "name";
            bool ret_bool = JsonHelper.IsJson(json);
            _richTextBoxHelper.Success("�Ƿ�ΪJson==>" + ret_bool, "ͳһ��ʽ");
            ret_bool = JsonHelper.IsJsonNodeExist(json, nodeName);
            _richTextBoxHelper.Success("�ڵ�name�Ƿ����==>" + ret_bool, "ͳһ��ʽ");
            object ret_obj = JsonHelper.GetJsonNodeValue(json, nodeName);
            _richTextBoxHelper.Success("�ڵ�name��ֵobject==>" + ret_obj, "ͳһ��ʽ");
            string ret_str = JsonHelper.GetJsonNodeValueString(json, nodeName);
            _richTextBoxHelper.Success("�ڵ�name��ֵstring==>" + ret_str, "ͳһ��ʽ");
            object ret_object = JsonHelper.JsonToObject<object>(json);
            _richTextBoxHelper.Success("JsonתObject==>" + ret_object, "ͳһ��ʽ");
            ret_str = JsonHelper.ObjectToJson(ret_object);
            _richTextBoxHelper.Success("ObjectתJson==>" + ret_str, "ͳһ��ʽ");
        }
    }
}
