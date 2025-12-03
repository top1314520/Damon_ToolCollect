using Damon_ToolCollect;
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
    public partial class Form_GenerateTool : Form
    {
        public Form_GenerateTool()
        {
            InitializeComponent();
        }

        private void Form_GenerateTool_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qz_str = "";
            if (comboBox1.Text.StartsWith("南苏丹-"))
            {
                qz_str = "21192-211922010287";  //211920001295
            }
            else if (comboBox1.Text.StartsWith("奥地利-"))
            {
                qz_str = "431-4367870373464";   //4310005615
            }
            else if (comboBox1.Text.StartsWith("美国-"))
            {
                qz_str = "147-19297811821"; //14708059645
            }
            else if (comboBox1.Text.StartsWith("塞拉利昂-"))
            {
                qz_str = "2321-23276120333";    //23210004270
            }
            else if (comboBox1.Text.StartsWith("赞比亚-"))
            {
                qz_str = "26094-260770726398";  //260940006956
            }
            else if (comboBox1.Text.StartsWith("利比里亚-"))
            {
                qz_str = "2311-231774795508";   //23110004452
            }
            else if (comboBox1.Text.StartsWith("莫桑比克-"))
            {
                qz_str = "2581-258864196147";   //25810001356
            }
            else if (comboBox1.Text.StartsWith("蒙古-"))
            {
                qz_str = "9761-97697713299";    //97610003870
            }
            else if (comboBox1.Text.StartsWith("印度尼西亚-"))
            {
                qz_str = "621-6285168793367";   //6210007497
            }
            else if (comboBox1.Text.StartsWith("埃塞俄比亚-"))
            {
                qz_str = "2511-251943682249";   //25110000658
            }
            else if (comboBox1.Text.StartsWith("南非-"))
            {
                qz_str = "271-27691082301";     //2710004353
            }
            else if (comboBox1.Text.StartsWith("哥伦比亚-"))
            {
                qz_str = "57310-573164198544";  //573100007174
            }
            else if (comboBox1.Text.StartsWith("巴西-"))
            {
                qz_str = "5561-5561983720851";
            }
            else if (comboBox1.Text.StartsWith("智利-"))
            {
                qz_str = "5623-56994027229";
            }
            else
            {
                qz_str = comboBox1.Text+" 国家无对应关系";
            }
            textBox_qz.Text = qz_str;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] strings = new string[2];
            try
            {
                strings = textBox_qz.Text.Split('-');
                if (strings.Length != 2)
                {
                    MessageBox.Show("前缀=>格式不正确(如：21192-211922010287)"); //211922010287为对应国家的手机号码
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常:"+ex.Message); 
                return;
            }
            string retNumStr = "";
            int num = 9;
            try
            {
                num = Convert.ToInt32(textBox_num.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常:" + ex.Message);
                return;
            }
            bool is_tygz = checkBox_tygz.Checked;
            for (int i=0;i< num;i++)
            {
                if (is_tygz == false)
                {
                    retNumStr += RandomHelper.GenerateFormattedString(strings[0], strings[1].Length) + Environment.NewLine;
                }
                else 
                {
                    retNumStr += RandomHelper.GenerateFormattedString(strings[0]) + Environment.NewLine;
                }
            }
            text_output.Text = retNumStr;
        }
    }
}
