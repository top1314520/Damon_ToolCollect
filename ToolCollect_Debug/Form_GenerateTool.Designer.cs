namespace ToolCollect_Debug
{
    partial class Form_GenerateTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            label1 = new Label();
            textBox_qz = new TextBox();
            label2 = new Label();
            button1 = new Button();
            text_output = new TextBox();
            label3 = new Label();
            textBox_num = new TextBox();
            checkBox_tygz = new CheckBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "南苏丹-SS-211", "奥地利-AT-43", "美国-US-1", "塞拉利昂-SL-232", "赞比亚-ZM-260", "利比里亚-LR-231", "莫桑比克-MZ-258", "蒙古-MN-976", "印度尼西亚-ID-62", "埃塞俄比亚-ET-251", "南非-ZA-27", "哥伦比亚-CO-57", "巴西-BR-55", "智利-CL-56" });
            comboBox1.Location = new Point(53, 11);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(142, 25);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 15);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 1;
            label1.Text = "国家：";
            // 
            // textBox_qz
            // 
            textBox_qz.Location = new Point(251, 12);
            textBox_qz.Name = "textBox_qz";
            textBox_qz.Size = new Size(184, 23);
            textBox_qz.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(201, 15);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 3;
            label2.Text = "前缀：";
            // 
            // button1
            // 
            button1.Location = new Point(700, 12);
            button1.Name = "button1";
            button1.Size = new Size(88, 23);
            button1.TabIndex = 4;
            button1.Text = "生  成";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // text_output
            // 
            text_output.Location = new Point(7, 55);
            text_output.MaxLength = 32767000;
            text_output.Multiline = true;
            text_output.Name = "text_output";
            text_output.Size = new Size(781, 383);
            text_output.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(443, 14);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 7;
            label3.Text = "数量：";
            // 
            // textBox_num
            // 
            textBox_num.Location = new Point(493, 11);
            textBox_num.Name = "textBox_num";
            textBox_num.Size = new Size(66, 23);
            textBox_num.TabIndex = 6;
            textBox_num.Text = "9";
            // 
            // checkBox_tygz
            // 
            checkBox_tygz.AutoSize = true;
            checkBox_tygz.Checked = true;
            checkBox_tygz.CheckState = CheckState.Checked;
            checkBox_tygz.Location = new Point(575, 15);
            checkBox_tygz.Name = "checkBox_tygz";
            checkBox_tygz.Size = new Size(75, 21);
            checkBox_tygz.TabIndex = 8;
            checkBox_tygz.Text = "统一规则";
            checkBox_tygz.UseVisualStyleBackColor = true;
            // 
            // Form_GenerateTool
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkBox_tygz);
            Controls.Add(label3);
            Controls.Add(textBox_num);
            Controls.Add(text_output);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox_qz);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form_GenerateTool";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "生成虚拟数据工具";
            Load += Form_GenerateTool_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private TextBox textBox_qz;
        private Label label2;
        private Button button1;
        private TextBox text_output;
        private Label label3;
        private TextBox textBox_num;
        private CheckBox checkBox_tygz;
    }
}