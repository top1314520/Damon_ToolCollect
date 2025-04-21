namespace ToolCollect_Debug
{
    partial class FormToolSet
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
            splitContainer_1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer_1).BeginInit();
            splitContainer_1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer_1
            // 
            splitContainer_1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer_1.Dock = DockStyle.Fill;
            splitContainer_1.Location = new Point(0, 0);
            splitContainer_1.Name = "splitContainer_1";
            // 
            // splitContainer_1.Panel1
            // 
            splitContainer_1.Panel1.BackColor = Color.Black;
            splitContainer_1.Panel1MinSize = 120;
            splitContainer_1.Size = new Size(1264, 811);
            splitContainer_1.SplitterDistance = 120;
            splitContainer_1.SplitterWidth = 2;
            splitContainer_1.TabIndex = 0;
            // 
            // FormToolSet
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 811);
            Controls.Add(splitContainer_1);
            MinimumSize = new Size(1000, 600);
            Name = "FormToolSet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormToolSet";
            ((System.ComponentModel.ISupportInitialize)splitContainer_1).EndInit();
            splitContainer_1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer_1;
    }
}