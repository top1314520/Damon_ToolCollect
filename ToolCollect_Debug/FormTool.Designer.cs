namespace ToolCollect_Debug
{
    partial class FormTool
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            radioButton3 = new RadioButton();
            radio_dump_hex = new RadioButton();
            radio_Str_qhh = new RadioButton();
            radio_Str_qkg = new RadioButton();
            radio_789_jy = new RadioButton();
            radio_789_ys = new RadioButton();
            radio_hex_dz = new RadioButton();
            radio_hex_jkg = new RadioButton();
            radio_base64_hex_jm = new RadioButton();
            radio_base64_hex_bm = new RadioButton();
            radio_base64_jm = new RadioButton();
            radio_base64_bm = new RadioButton();
            radio_url_jm = new RadioButton();
            radio_url_bm = new RadioButton();
            radio_grpc_1f_jy = new RadioButton();
            radio_grpc_1f_ys = new RadioButton();
            radio_ProtoBuf_fxlh = new RadioButton();
            radio_1f_ys = new RadioButton();
            radio_1f_jy = new RadioButton();
            radio_ProtoBuf_jm = new RadioButton();
            radio_Str_HexStr = new RadioButton();
            radio_hex_str = new RadioButton();
            tabPage2 = new TabPage();
            radio_thrift_tbinary = new RadioButton();
            radio_thrift_jx = new RadioButton();
            radio_json_ys = new RadioButton();
            radio_json_jy = new RadioButton();
            tabPage3 = new TabPage();
            radio_xml_ys = new RadioButton();
            radio_xml_jy = new RadioButton();
            groupBox1 = new GroupBox();
            textBox_output = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            outputprompt = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            文件ToolStripMenuItem = new ToolStripMenuItem();
            编辑ToolStripMenuItem = new ToolStripMenuItem();
            示例数据ToolStripMenuItem = new ToolStripMenuItem();
            radioButton1 = new RadioButton();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(5, 31);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1252, 100);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Menu;
            tabPage1.Controls.Add(radioButton3);
            tabPage1.Controls.Add(radio_dump_hex);
            tabPage1.Controls.Add(radio_Str_qhh);
            tabPage1.Controls.Add(radio_Str_qkg);
            tabPage1.Controls.Add(radio_789_jy);
            tabPage1.Controls.Add(radio_789_ys);
            tabPage1.Controls.Add(radio_hex_dz);
            tabPage1.Controls.Add(radio_hex_jkg);
            tabPage1.Controls.Add(radio_base64_hex_jm);
            tabPage1.Controls.Add(radio_base64_hex_bm);
            tabPage1.Controls.Add(radio_base64_jm);
            tabPage1.Controls.Add(radio_base64_bm);
            tabPage1.Controls.Add(radio_url_jm);
            tabPage1.Controls.Add(radio_url_bm);
            tabPage1.Controls.Add(radio_grpc_1f_jy);
            tabPage1.Controls.Add(radio_grpc_1f_ys);
            tabPage1.Controls.Add(radio_ProtoBuf_fxlh);
            tabPage1.Controls.Add(radio_1f_ys);
            tabPage1.Controls.Add(radio_1f_jy);
            tabPage1.Controls.Add(radio_ProtoBuf_jm);
            tabPage1.Controls.Add(radio_Str_HexStr);
            tabPage1.Controls.Add(radio_hex_str);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1244, 70);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "常用工具";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(1032, 39);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(62, 21);
            radioButton3.TabIndex = 21;
            radioButton3.Text = "未实现";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radio_dump_hex
            // 
            radio_dump_hex.AutoSize = true;
            radio_dump_hex.Location = new Point(1032, 12);
            radio_dump_hex.Name = "radio_dump_hex";
            radio_dump_hex.Size = new Size(88, 21);
            radio_dump_hex.TabIndex = 20;
            radio_dump_hex.Text = "Dump_Hex";
            radio_dump_hex.UseVisualStyleBackColor = true;
            radio_dump_hex.CheckedChanged += radio_dump_hex_CheckedChanged;
            // 
            // radio_Str_qhh
            // 
            radio_Str_qhh.AutoSize = true;
            radio_Str_qhh.Location = new Point(943, 39);
            radio_Str_qhh.Name = "radio_Str_qhh";
            radio_Str_qhh.Size = new Size(83, 21);
            radio_Str_qhh.TabIndex = 19;
            radio_Str_qhh.Text = "Str_去换行";
            radio_Str_qhh.UseVisualStyleBackColor = true;
            radio_Str_qhh.CheckedChanged += radio_Str_qhh_CheckedChanged;
            // 
            // radio_Str_qkg
            // 
            radio_Str_qkg.AutoSize = true;
            radio_Str_qkg.Location = new Point(943, 12);
            radio_Str_qkg.Name = "radio_Str_qkg";
            radio_Str_qkg.Size = new Size(83, 21);
            radio_Str_qkg.TabIndex = 18;
            radio_Str_qkg.Text = "Str_去空格";
            radio_Str_qkg.UseVisualStyleBackColor = true;
            radio_Str_qkg.CheckedChanged += radio_Str_qkg_CheckedChanged;
            // 
            // radio_789_jy
            // 
            radio_789_jy.AutoSize = true;
            radio_789_jy.Location = new Point(460, 39);
            radio_789_jy.Name = "radio_789_jy";
            radio_789_jy.Size = new Size(76, 21);
            radio_789_jy.TabIndex = 17;
            radio_789_jy.Text = "789_解压";
            radio_789_jy.UseVisualStyleBackColor = true;
            radio_789_jy.CheckedChanged += radio_789_jy_CheckedChanged;
            // 
            // radio_789_ys
            // 
            radio_789_ys.AutoSize = true;
            radio_789_ys.Location = new Point(460, 12);
            radio_789_ys.Name = "radio_789_ys";
            radio_789_ys.Size = new Size(76, 21);
            radio_789_ys.TabIndex = 16;
            radio_789_ys.Text = "798_压缩";
            radio_789_ys.UseVisualStyleBackColor = true;
            radio_789_ys.CheckedChanged += radio_789_ys_CheckedChanged;
            // 
            // radio_hex_dz
            // 
            radio_hex_dz.AutoSize = true;
            radio_hex_dz.Location = new Point(848, 39);
            radio_hex_dz.Name = "radio_hex_dz";
            radio_hex_dz.Size = new Size(77, 21);
            radio_hex_dz.TabIndex = 15;
            radio_hex_dz.Text = "Hex_倒置";
            radio_hex_dz.UseVisualStyleBackColor = true;
            radio_hex_dz.CheckedChanged += radio_hex_dz_CheckedChanged;
            // 
            // radio_hex_jkg
            // 
            radio_hex_jkg.AutoSize = true;
            radio_hex_jkg.Location = new Point(848, 12);
            radio_hex_jkg.Name = "radio_hex_jkg";
            radio_hex_jkg.Size = new Size(89, 21);
            radio_hex_jkg.TabIndex = 14;
            radio_hex_jkg.Text = "Hex_加空格";
            radio_hex_jkg.UseVisualStyleBackColor = true;
            radio_hex_jkg.CheckedChanged += radio_hex_jkg_CheckedChanged;
            // 
            // radio_base64_hex_jm
            // 
            radio_base64_hex_jm.AutoSize = true;
            radio_base64_hex_jm.Location = new Point(723, 39);
            radio_base64_hex_jm.Name = "radio_base64_hex_jm";
            radio_base64_hex_jm.Size = new Size(119, 21);
            radio_base64_hex_jm.TabIndex = 13;
            radio_base64_hex_jm.Text = "Base64_Hex解码";
            radio_base64_hex_jm.UseVisualStyleBackColor = true;
            radio_base64_hex_jm.CheckedChanged += radio_base64_hex_jm_CheckedChanged;
            // 
            // radio_base64_hex_bm
            // 
            radio_base64_hex_bm.AutoSize = true;
            radio_base64_hex_bm.Location = new Point(723, 12);
            radio_base64_hex_bm.Name = "radio_base64_hex_bm";
            radio_base64_hex_bm.Size = new Size(119, 21);
            radio_base64_hex_bm.TabIndex = 12;
            radio_base64_hex_bm.Text = "Base64_Hex编码";
            radio_base64_hex_bm.UseVisualStyleBackColor = true;
            radio_base64_hex_bm.CheckedChanged += radio_base64_hex_bm_CheckedChanged;
            // 
            // radio_base64_jm
            // 
            radio_base64_jm.AutoSize = true;
            radio_base64_jm.Location = new Point(620, 39);
            radio_base64_jm.Name = "radio_base64_jm";
            radio_base64_jm.Size = new Size(97, 21);
            radio_base64_jm.TabIndex = 11;
            radio_base64_jm.Text = "Base64_解码";
            radio_base64_jm.UseVisualStyleBackColor = true;
            radio_base64_jm.CheckedChanged += radio_base64_jm_CheckedChanged;
            // 
            // radio_base64_bm
            // 
            radio_base64_bm.AutoSize = true;
            radio_base64_bm.Location = new Point(620, 12);
            radio_base64_bm.Name = "radio_base64_bm";
            radio_base64_bm.Size = new Size(97, 21);
            radio_base64_bm.TabIndex = 10;
            radio_base64_bm.Text = "Base64_编码";
            radio_base64_bm.UseVisualStyleBackColor = true;
            radio_base64_bm.CheckedChanged += radio_base64_bm_CheckedChanged;
            // 
            // radio_url_jm
            // 
            radio_url_jm.AutoSize = true;
            radio_url_jm.Location = new Point(542, 39);
            radio_url_jm.Name = "radio_url_jm";
            radio_url_jm.Size = new Size(72, 21);
            radio_url_jm.TabIndex = 9;
            radio_url_jm.Text = "Url_解码";
            radio_url_jm.UseVisualStyleBackColor = true;
            radio_url_jm.CheckedChanged += radio_url_jm_CheckedChanged;
            // 
            // radio_url_bm
            // 
            radio_url_bm.AutoSize = true;
            radio_url_bm.Location = new Point(542, 12);
            radio_url_bm.Name = "radio_url_bm";
            radio_url_bm.Size = new Size(72, 21);
            radio_url_bm.TabIndex = 8;
            radio_url_bm.Text = "Url_编码";
            radio_url_bm.UseVisualStyleBackColor = true;
            radio_url_bm.CheckedChanged += radio_url_bm_CheckedChanged;
            // 
            // radio_grpc_1f_jy
            // 
            radio_grpc_1f_jy.AutoSize = true;
            radio_grpc_1f_jy.Location = new Point(334, 39);
            radio_grpc_1f_jy.Name = "radio_grpc_1f_jy";
            radio_grpc_1f_jy.Size = new Size(120, 21);
            radio_grpc_1f_jy.TabIndex = 7;
            radio_grpc_1f_jy.Text = "Grpc_1F数据解压";
            radio_grpc_1f_jy.UseVisualStyleBackColor = true;
            radio_grpc_1f_jy.CheckedChanged += radio_grpc_1f_jy_CheckedChanged;
            // 
            // radio_grpc_1f_ys
            // 
            radio_grpc_1f_ys.AutoSize = true;
            radio_grpc_1f_ys.Location = new Point(334, 12);
            radio_grpc_1f_ys.Name = "radio_grpc_1f_ys";
            radio_grpc_1f_ys.Size = new Size(120, 21);
            radio_grpc_1f_ys.TabIndex = 6;
            radio_grpc_1f_ys.Text = "Grpc_1F数据压缩";
            radio_grpc_1f_ys.UseVisualStyleBackColor = true;
            radio_grpc_1f_ys.CheckedChanged += radio_grpc_1f_ys_CheckedChanged;
            // 
            // radio_ProtoBuf_fxlh
            // 
            radio_ProtoBuf_fxlh.AutoSize = true;
            radio_ProtoBuf_fxlh.Location = new Point(203, 39);
            radio_ProtoBuf_fxlh.Name = "radio_ProtoBuf_fxlh";
            radio_ProtoBuf_fxlh.Size = new Size(123, 21);
            radio_ProtoBuf_fxlh.TabIndex = 5;
            radio_ProtoBuf_fxlh.Text = "ProtoBuf--序列化";
            radio_ProtoBuf_fxlh.UseVisualStyleBackColor = true;
            radio_ProtoBuf_fxlh.CheckedChanged += radio_ProtoBuf_fxlh_CheckedChanged;
            // 
            // radio_1f_ys
            // 
            radio_1f_ys.AutoSize = true;
            radio_1f_ys.Location = new Point(110, 12);
            radio_1f_ys.Name = "radio_1f_ys";
            radio_1f_ys.Size = new Size(87, 21);
            radio_1f_ys.TabIndex = 4;
            radio_1f_ys.Text = "1F数据压缩";
            radio_1f_ys.UseVisualStyleBackColor = true;
            radio_1f_ys.CheckedChanged += radio_1f_ys_CheckedChanged;
            // 
            // radio_1f_jy
            // 
            radio_1f_jy.AutoSize = true;
            radio_1f_jy.Location = new Point(110, 39);
            radio_1f_jy.Name = "radio_1f_jy";
            radio_1f_jy.Size = new Size(87, 21);
            radio_1f_jy.TabIndex = 3;
            radio_1f_jy.Text = "1F数据解压";
            radio_1f_jy.UseVisualStyleBackColor = true;
            radio_1f_jy.CheckedChanged += radio_1f_jy_CheckedChanged;
            // 
            // radio_ProtoBuf_jm
            // 
            radio_ProtoBuf_jm.AutoSize = true;
            radio_ProtoBuf_jm.Location = new Point(203, 12);
            radio_ProtoBuf_jm.Name = "radio_ProtoBuf_jm";
            radio_ProtoBuf_jm.Size = new Size(125, 21);
            radio_ProtoBuf_jm.TabIndex = 2;
            radio_ProtoBuf_jm.Text = "ProtoBuf   序列化";
            radio_ProtoBuf_jm.UseVisualStyleBackColor = true;
            radio_ProtoBuf_jm.CheckedChanged += radio_ProtoBuf_jm_CheckedChanged;
            // 
            // radio_Str_HexStr
            // 
            radio_Str_HexStr.AutoSize = true;
            radio_Str_HexStr.Location = new Point(9, 39);
            radio_Str_HexStr.Name = "radio_Str_HexStr";
            radio_Str_HexStr.Size = new Size(95, 21);
            radio_Str_HexStr.TabIndex = 1;
            radio_Str_HexStr.Text = "StrToHexStr";
            radio_Str_HexStr.UseVisualStyleBackColor = true;
            radio_Str_HexStr.CheckedChanged += radio_Str_HexStr_CheckedChanged;
            // 
            // radio_hex_str
            // 
            radio_hex_str.AutoSize = true;
            radio_hex_str.Location = new Point(9, 12);
            radio_hex_str.Name = "radio_hex_str";
            radio_hex_str.Size = new Size(95, 21);
            radio_hex_str.TabIndex = 0;
            radio_hex_str.Text = "HexStrToStr";
            radio_hex_str.UseVisualStyleBackColor = true;
            radio_hex_str.CheckedChanged += radio_hex_str_CheckedChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Menu;
            tabPage2.Controls.Add(radioButton1);
            tabPage2.Controls.Add(radio_thrift_tbinary);
            tabPage2.Controls.Add(radio_thrift_jx);
            tabPage2.Controls.Add(radio_json_ys);
            tabPage2.Controls.Add(radio_json_jy);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1244, 70);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "数据解析";
            // 
            // radio_thrift_tbinary
            // 
            radio_thrift_tbinary.AutoSize = true;
            radio_thrift_tbinary.Location = new Point(91, 39);
            radio_thrift_tbinary.Name = "radio_thrift_tbinary";
            radio_thrift_tbinary.Size = new Size(128, 21);
            radio_thrift_tbinary.TabIndex = 4;
            radio_thrift_tbinary.Text = "Thrift_TBinary解析";
            radio_thrift_tbinary.UseVisualStyleBackColor = true;
            radio_thrift_tbinary.CheckedChanged += radio_thrift_tbinary_CheckedChanged;
            // 
            // radio_thrift_jx
            // 
            radio_thrift_jx.AutoSize = true;
            radio_thrift_jx.Location = new Point(91, 12);
            radio_thrift_jx.Name = "radio_thrift_jx";
            radio_thrift_jx.Size = new Size(109, 21);
            radio_thrift_jx.TabIndex = 3;
            radio_thrift_jx.Text = "Thrift_数据解析";
            radio_thrift_jx.UseVisualStyleBackColor = true;
            radio_thrift_jx.CheckedChanged += radio_thrift_jx_CheckedChanged;
            // 
            // radio_json_ys
            // 
            radio_json_ys.AutoSize = true;
            radio_json_ys.Location = new Point(9, 39);
            radio_json_ys.Name = "radio_json_ys";
            radio_json_ys.Size = new Size(76, 21);
            radio_json_ys.TabIndex = 2;
            radio_json_ys.Text = "Json压缩";
            radio_json_ys.UseVisualStyleBackColor = true;
            radio_json_ys.CheckedChanged += radio_json_ys_CheckedChanged;
            // 
            // radio_json_jy
            // 
            radio_json_jy.AutoSize = true;
            radio_json_jy.Location = new Point(9, 12);
            radio_json_jy.Name = "radio_json_jy";
            radio_json_jy.Size = new Size(76, 21);
            radio_json_jy.TabIndex = 1;
            radio_json_jy.Text = "Json解压";
            radio_json_jy.UseVisualStyleBackColor = true;
            radio_json_jy.CheckedChanged += radio_json_jy_CheckedChanged;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = SystemColors.Menu;
            tabPage3.Controls.Add(radio_xml_ys);
            tabPage3.Controls.Add(radio_xml_jy);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1244, 70);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "数据转换";
            // 
            // radio_xml_ys
            // 
            radio_xml_ys.AutoSize = true;
            radio_xml_ys.Location = new Point(9, 39);
            radio_xml_ys.Name = "radio_xml_ys";
            radio_xml_ys.Size = new Size(72, 21);
            radio_xml_ys.TabIndex = 4;
            radio_xml_ys.Text = "Xml压缩";
            radio_xml_ys.UseVisualStyleBackColor = true;
            radio_xml_ys.CheckedChanged += radio_xml_ys_CheckedChanged;
            // 
            // radio_xml_jy
            // 
            radio_xml_jy.AutoSize = true;
            radio_xml_jy.Location = new Point(9, 12);
            radio_xml_jy.Name = "radio_xml_jy";
            radio_xml_jy.Size = new Size(72, 21);
            radio_xml_jy.TabIndex = 3;
            radio_xml_jy.Text = "Xml解压";
            radio_xml_jy.UseVisualStyleBackColor = true;
            radio_xml_jy.CheckedChanged += radio_xml_jy_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(textBox_output);
            groupBox1.Location = new Point(5, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1252, 645);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "输入输出";
            // 
            // textBox_output
            // 
            textBox_output.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_output.Location = new Point(4, 20);
            textBox_output.MaxLength = 999999999;
            textBox_output.Multiline = true;
            textBox_output.Name = "textBox_output";
            textBox_output.ScrollBars = ScrollBars.Both;
            textBox_output.Size = new Size(1244, 619);
            textBox_output.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, outputprompt });
            statusStrip1.Location = new Point(0, 785);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1264, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(58, 21);
            toolStripStatusLabel1.Text = "提示：";
            // 
            // outputprompt
            // 
            outputprompt.ForeColor = Color.Red;
            outputprompt.Name = "outputprompt";
            outputprompt.Size = new Size(15, 21);
            outputprompt.Text = " ";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem, 编辑ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 25);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            文件ToolStripMenuItem.Size = new Size(44, 21);
            文件ToolStripMenuItem.Text = "文件";
            // 
            // 编辑ToolStripMenuItem
            // 
            编辑ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 示例数据ToolStripMenuItem });
            编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            编辑ToolStripMenuItem.Size = new Size(44, 21);
            编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 示例数据ToolStripMenuItem
            // 
            示例数据ToolStripMenuItem.Name = "示例数据ToolStripMenuItem";
            示例数据ToolStripMenuItem.Size = new Size(124, 22);
            示例数据ToolStripMenuItem.Text = "示例数据";
            示例数据ToolStripMenuItem.Click += 示例数据ToolStripMenuItem_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(206, 12);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(62, 21);
            radioButton1.TabIndex = 5;
            radioButton1.Text = "未实现";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // FormTool
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 811);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(groupBox1);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Name = "FormTool";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "工具";
            Load += FormTool_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private TextBox textBox_output;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private RadioButton radio_Str_HexStr;
        private RadioButton radio_hex_str;
        private RadioButton radio_json_ys;
        private RadioButton radio_json_jy;
        private ToolStripStatusLabel outputprompt;
        private RadioButton radio_1f_jy;
        private RadioButton radio_ProtoBuf_jm;
        private RadioButton radio_1f_ys;
        private RadioButton radio_ProtoBuf_fxlh;
        private RadioButton radio_grpc_1f_jy;
        private RadioButton radio_grpc_1f_ys;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 编辑ToolStripMenuItem;
        private ToolStripMenuItem 示例数据ToolStripMenuItem;
        private RadioButton radio_url_jm;
        private RadioButton radio_url_bm;
        private RadioButton radio_base64_jm;
        private RadioButton radio_base64_bm;
        private RadioButton radio_base64_hex_jm;
        private RadioButton radio_base64_hex_bm;
        private RadioButton radio_hex_dz;
        private RadioButton radio_hex_jkg;
        private RadioButton radio_789_jy;
        private RadioButton radio_789_ys;
        private RadioButton radio_Str_qhh;
        private RadioButton radio_Str_qkg;
        private TabPage tabPage3;
        private RadioButton radio_xml_ys;
        private RadioButton radio_xml_jy;
        private RadioButton radioButton3;
        private RadioButton radio_dump_hex;
        private RadioButton radio_thrift_tbinary;
        private RadioButton radio_thrift_jx;
        private RadioButton radioButton1;
    }
}