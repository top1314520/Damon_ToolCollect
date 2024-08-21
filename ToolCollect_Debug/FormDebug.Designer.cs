namespace ToolCollect_Debug
{
    partial class FormDebug
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDebug));
            menuStrip1 = new MenuStrip();
            日志ToolStripMenuItem = new ToolStripMenuItem();
            logHelperToolStripMenuItem = new ToolStripMenuItem();
            logBytesToolStripMenuItem = new ToolStripMenuItem();
            logStringToolStripMenuItem = new ToolStripMenuItem();
            logDictionaryToolStripMenuItem = new ToolStripMenuItem();
            hexToolStripMenuItem = new ToolStripMenuItem();
            hexHelperToolStripMenuItem = new ToolStripMenuItem();
            bytesToHexStringToolStripMenuItem = new ToolStripMenuItem();
            hexStringToBytesToolStripMenuItem = new ToolStripMenuItem();
            基础类型ToolStripMenuItem = new ToolStripMenuItem();
            basicTypeHelperToolStripMenuItem = new ToolStripMenuItem();
            isNullOrEmptyToolStripMenuItem = new ToolStripMenuItem();
            isNumberToolStripMenuItem = new ToolStripMenuItem();
            timeHelperToolStripMenuItem = new ToolStripMenuItem();
            stringHelperToolStripMenuItem = new ToolStripMenuItem();
            jsonToolStripMenuItem = new ToolStripMenuItem();
            jsonHelperToolStripMenuItem = new ToolStripMenuItem();
            jobjectHelperToolStripMenuItem = new ToolStripMenuItem();
            json格式化ToolStripMenuItem = new ToolStripMenuItem();
            json压缩ToolStripMenuItem = new ToolStripMenuItem();
            转义ToolStripMenuItem = new ToolStripMenuItem();
            增加转义符ToolStripMenuItem = new ToolStripMenuItem();
            删除转义符ToolStripMenuItem = new ToolStripMenuItem();
            richTextBox1 = new RichTextBox();
            statusStrip1 = new StatusStrip();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            convertHexStringsInJsonToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 日志ToolStripMenuItem, hexToolStripMenuItem, 基础类型ToolStripMenuItem, jsonToolStripMenuItem, 转义ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1101, 25);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 日志ToolStripMenuItem
            // 
            日志ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logHelperToolStripMenuItem });
            日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
            日志ToolStripMenuItem.Size = new Size(44, 21);
            日志ToolStripMenuItem.Text = "日志";
            // 
            // logHelperToolStripMenuItem
            // 
            logHelperToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logBytesToolStripMenuItem, logStringToolStripMenuItem, logDictionaryToolStripMenuItem });
            logHelperToolStripMenuItem.Name = "logHelperToolStripMenuItem";
            logHelperToolStripMenuItem.Size = new Size(137, 22);
            logHelperToolStripMenuItem.Text = "LogHelper";
            // 
            // logBytesToolStripMenuItem
            // 
            logBytesToolStripMenuItem.Name = "logBytesToolStripMenuItem";
            logBytesToolStripMenuItem.Size = new Size(153, 22);
            logBytesToolStripMenuItem.Text = "logBytes";
            logBytesToolStripMenuItem.ToolTipText = "写入日志(Byte[])";
            logBytesToolStripMenuItem.Click += logBytesToolStripMenuItem_Click;
            // 
            // logStringToolStripMenuItem
            // 
            logStringToolStripMenuItem.Name = "logStringToolStripMenuItem";
            logStringToolStripMenuItem.Size = new Size(153, 22);
            logStringToolStripMenuItem.Text = "logString";
            logStringToolStripMenuItem.ToolTipText = "写入日志(String)";
            logStringToolStripMenuItem.Click += logStringToolStripMenuItem_Click;
            // 
            // logDictionaryToolStripMenuItem
            // 
            logDictionaryToolStripMenuItem.Name = "logDictionaryToolStripMenuItem";
            logDictionaryToolStripMenuItem.Size = new Size(153, 22);
            logDictionaryToolStripMenuItem.Text = "logDictionary";
            logDictionaryToolStripMenuItem.ToolTipText = "写入日志(Dictionary)";
            logDictionaryToolStripMenuItem.Click += logDictionaryToolStripMenuItem_Click;
            // 
            // hexToolStripMenuItem
            // 
            hexToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { hexHelperToolStripMenuItem });
            hexToolStripMenuItem.Name = "hexToolStripMenuItem";
            hexToolStripMenuItem.Size = new Size(44, 21);
            hexToolStripMenuItem.Text = "进制";
            // 
            // hexHelperToolStripMenuItem
            // 
            hexHelperToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bytesToHexStringToolStripMenuItem, hexStringToBytesToolStripMenuItem, convertHexStringsInJsonToolStripMenuItem });
            hexHelperToolStripMenuItem.Name = "hexHelperToolStripMenuItem";
            hexHelperToolStripMenuItem.Size = new Size(180, 22);
            hexHelperToolStripMenuItem.Text = "HexHelper";
            // 
            // bytesToHexStringToolStripMenuItem
            // 
            bytesToHexStringToolStripMenuItem.Name = "bytesToHexStringToolStripMenuItem";
            bytesToHexStringToolStripMenuItem.Size = new Size(180, 22);
            bytesToHexStringToolStripMenuItem.Text = "BytesToHexString";
            bytesToHexStringToolStripMenuItem.ToolTipText = "字节数组转16进制字符串";
            bytesToHexStringToolStripMenuItem.Click += bytesToHexStringToolStripMenuItem_Click;
            // 
            // hexStringToBytesToolStripMenuItem
            // 
            hexStringToBytesToolStripMenuItem.Name = "hexStringToBytesToolStripMenuItem";
            hexStringToBytesToolStripMenuItem.Size = new Size(180, 22);
            hexStringToBytesToolStripMenuItem.Text = "HexStringToBytes";
            hexStringToBytesToolStripMenuItem.ToolTipText = "16进制字符串转字节数组";
            hexStringToBytesToolStripMenuItem.Click += hexStringToBytesToolStripMenuItem_Click;
            // 
            // 基础类型ToolStripMenuItem
            // 
            基础类型ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { basicTypeHelperToolStripMenuItem, timeHelperToolStripMenuItem, stringHelperToolStripMenuItem });
            基础类型ToolStripMenuItem.Name = "基础类型ToolStripMenuItem";
            基础类型ToolStripMenuItem.Size = new Size(68, 21);
            基础类型ToolStripMenuItem.Text = "基础类型";
            // 
            // basicTypeHelperToolStripMenuItem
            // 
            basicTypeHelperToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { isNullOrEmptyToolStripMenuItem, isNumberToolStripMenuItem });
            basicTypeHelperToolStripMenuItem.Name = "basicTypeHelperToolStripMenuItem";
            basicTypeHelperToolStripMenuItem.Size = new Size(173, 22);
            basicTypeHelperToolStripMenuItem.Text = "BasicTypeHelper";
            // 
            // isNullOrEmptyToolStripMenuItem
            // 
            isNullOrEmptyToolStripMenuItem.Name = "isNullOrEmptyToolStripMenuItem";
            isNullOrEmptyToolStripMenuItem.Size = new Size(160, 22);
            isNullOrEmptyToolStripMenuItem.Text = "IsNullOrEmpty";
            isNullOrEmptyToolStripMenuItem.ToolTipText = "判断对象或字符串是否为空";
            isNullOrEmptyToolStripMenuItem.Click += isNullOrEmptyToolStripMenuItem_Click;
            // 
            // isNumberToolStripMenuItem
            // 
            isNumberToolStripMenuItem.Name = "isNumberToolStripMenuItem";
            isNumberToolStripMenuItem.Size = new Size(160, 22);
            isNumberToolStripMenuItem.Text = "IsNumber";
            isNumberToolStripMenuItem.ToolTipText = "判断字符串是否为数字";
            isNumberToolStripMenuItem.Click += isNumberToolStripMenuItem_Click;
            // 
            // timeHelperToolStripMenuItem
            // 
            timeHelperToolStripMenuItem.Name = "timeHelperToolStripMenuItem";
            timeHelperToolStripMenuItem.Size = new Size(173, 22);
            timeHelperToolStripMenuItem.Text = "TimeHelper";
            timeHelperToolStripMenuItem.ToolTipText = "输出所有的时间相关方法";
            timeHelperToolStripMenuItem.Click += timeHelperToolStripMenuItem_Click;
            // 
            // stringHelperToolStripMenuItem
            // 
            stringHelperToolStripMenuItem.Name = "stringHelperToolStripMenuItem";
            stringHelperToolStripMenuItem.Size = new Size(173, 22);
            stringHelperToolStripMenuItem.Text = "StringHelper";
            stringHelperToolStripMenuItem.Click += stringHelperToolStripMenuItem_Click;
            // 
            // jsonToolStripMenuItem
            // 
            jsonToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { jsonHelperToolStripMenuItem, jobjectHelperToolStripMenuItem, json格式化ToolStripMenuItem, json压缩ToolStripMenuItem });
            jsonToolStripMenuItem.Name = "jsonToolStripMenuItem";
            jsonToolStripMenuItem.Size = new Size(46, 21);
            jsonToolStripMenuItem.Text = "Json";
            // 
            // jsonHelperToolStripMenuItem
            // 
            jsonHelperToolStripMenuItem.Name = "jsonHelperToolStripMenuItem";
            jsonHelperToolStripMenuItem.Size = new Size(156, 22);
            jsonHelperToolStripMenuItem.Text = "JsonHelper";
            jsonHelperToolStripMenuItem.Click += jsonHelperToolStripMenuItem_Click;
            // 
            // jobjectHelperToolStripMenuItem
            // 
            jobjectHelperToolStripMenuItem.Name = "jobjectHelperToolStripMenuItem";
            jobjectHelperToolStripMenuItem.Size = new Size(156, 22);
            jobjectHelperToolStripMenuItem.Text = "JobjectHelper";
            jobjectHelperToolStripMenuItem.Click += jobjectHelperToolStripMenuItem_Click;
            // 
            // json格式化ToolStripMenuItem
            // 
            json格式化ToolStripMenuItem.Name = "json格式化ToolStripMenuItem";
            json格式化ToolStripMenuItem.Size = new Size(156, 22);
            json格式化ToolStripMenuItem.Text = "Json格式化";
            json格式化ToolStripMenuItem.Click += json格式化ToolStripMenuItem_Click;
            // 
            // json压缩ToolStripMenuItem
            // 
            json压缩ToolStripMenuItem.Name = "json压缩ToolStripMenuItem";
            json压缩ToolStripMenuItem.Size = new Size(156, 22);
            json压缩ToolStripMenuItem.Text = "Json压缩";
            json压缩ToolStripMenuItem.Click += json压缩ToolStripMenuItem_Click;
            // 
            // 转义ToolStripMenuItem
            // 
            转义ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 增加转义符ToolStripMenuItem, 删除转义符ToolStripMenuItem });
            转义ToolStripMenuItem.Name = "转义ToolStripMenuItem";
            转义ToolStripMenuItem.Size = new Size(44, 21);
            转义ToolStripMenuItem.Text = "转义";
            // 
            // 增加转义符ToolStripMenuItem
            // 
            增加转义符ToolStripMenuItem.Name = "增加转义符ToolStripMenuItem";
            增加转义符ToolStripMenuItem.Size = new Size(136, 22);
            增加转义符ToolStripMenuItem.Text = "增加转义符";
            增加转义符ToolStripMenuItem.Click += 增加转义符ToolStripMenuItem_Click;
            // 
            // 删除转义符ToolStripMenuItem
            // 
            删除转义符ToolStripMenuItem.Name = "删除转义符ToolStripMenuItem";
            删除转义符ToolStripMenuItem.Size = new Size(136, 22);
            删除转义符ToolStripMenuItem.Text = "删除转义符";
            删除转义符ToolStripMenuItem.Click += 删除转义符ToolStripMenuItem_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.InfoText;
            richTextBox1.ForeColor = SystemColors.Window;
            richTextBox1.Location = new Point(4, 92);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            richTextBox1.Size = new Size(1095, 465);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 562);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1101, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(40, 40);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSeparator1 });
            toolStrip1.Location = new Point(0, 25);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1101, 64);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(48, 61);
            toolStripButton1.Text = "快捷键";
            toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 64);
            // 
            // convertHexStringsInJsonToolStripMenuItem
            // 
            convertHexStringsInJsonToolStripMenuItem.Name = "convertHexStringsInJsonToolStripMenuItem";
            convertHexStringsInJsonToolStripMenuItem.Size = new Size(220, 22);
            convertHexStringsInJsonToolStripMenuItem.Text = "ConvertHexStringsInJson";
            convertHexStringsInJsonToolStripMenuItem.ToolTipText = "Json中的十六进制字符串转换为正常字符串";
            convertHexStringsInJsonToolStripMenuItem.Click += convertHexStringsInJsonToolStripMenuItem_Click;
            // 
            // FormDebug
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 584);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(richTextBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FormDebug";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "工具集成测试";
            Load += FormDebug_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 日志ToolStripMenuItem;
        private ToolStripMenuItem logHelperToolStripMenuItem;
        private ToolStripMenuItem logBytesToolStripMenuItem;
        private ToolStripMenuItem hexToolStripMenuItem;
        private ToolStripMenuItem hexHelperToolStripMenuItem;
        private ToolStripMenuItem bytesToHexStringToolStripMenuItem;
        private RichTextBox richTextBox1;
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem hexStringToBytesToolStripMenuItem;
        private ToolStripMenuItem 基础类型ToolStripMenuItem;
        private ToolStripMenuItem basicTypeHelperToolStripMenuItem;
        private ToolStripMenuItem isNullOrEmptyToolStripMenuItem;
        private ToolStripMenuItem isNumberToolStripMenuItem;
        private ToolStripMenuItem logStringToolStripMenuItem;
        private ToolStripMenuItem logDictionaryToolStripMenuItem;
        private ToolStripMenuItem timeHelperToolStripMenuItem;
        private ToolStripMenuItem jsonToolStripMenuItem;
        private ToolStripMenuItem jsonHelperToolStripMenuItem;
        private ToolStripMenuItem jobjectHelperToolStripMenuItem;
        private ToolStripMenuItem stringHelperToolStripMenuItem;
        private ToolStripMenuItem 转义ToolStripMenuItem;
        private ToolStripMenuItem 增加转义符ToolStripMenuItem;
        private ToolStripMenuItem 删除转义符ToolStripMenuItem;
        private ToolStripMenuItem json格式化ToolStripMenuItem;
        private ToolStripMenuItem json压缩ToolStripMenuItem;
        private ToolStripMenuItem convertHexStringsInJsonToolStripMenuItem;
    }
}
