
namespace adbGUI.Forms
{
    partial class LogcatView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogcatView));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.DevicesComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.FilterTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.StartOrStopBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.xxxSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regexxxxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uidxxxxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logviewBox = new System.Windows.Forms.RichTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.DevicesComboBox,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.FilterTextBox,
            this.StartOrStopBtn,
            this.toolStripSeparator2,
            this.ClearBtn,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "Devices:";
            // 
            // DevicesComboBox
            // 
            this.DevicesComboBox.Name = "DevicesComboBox";
            this.DevicesComboBox.Size = new System.Drawing.Size(121, 25);
            this.DevicesComboBox.SelectedIndexChanged += new System.EventHandler(this.OnDevicesIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel2.Text = "Filter:";
            // 
            // FilterTextBox
            // 
            this.FilterTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.FilterTextBox.Name = "FilterTextBox";
            this.FilterTextBox.Size = new System.Drawing.Size(150, 25);
            // 
            // StartOrStopBtn
            // 
            this.StartOrStopBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.StartOrStopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StartOrStopBtn.Image = ((System.Drawing.Image)(resources.GetObject("StartOrStopBtn.Image")));
            this.StartOrStopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartOrStopBtn.Name = "StartOrStopBtn";
            this.StartOrStopBtn.Size = new System.Drawing.Size(39, 22);
            this.StartOrStopBtn.Text = "Start";
            this.StartOrStopBtn.Click += new System.EventHandler(this.StartOrStopBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ClearBtn
            // 
            this.ClearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClearBtn.Image = ((System.Drawing.Image)(resources.GetObject("ClearBtn.Image")));
            this.ClearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(42, 22);
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xxxSToolStripMenuItem,
            this.regexxxxxToolStripMenuItem,
            this.uidxxxxToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton1.Text = "模板";
            // 
            // xxxSToolStripMenuItem
            // 
            this.xxxSToolStripMenuItem.Name = "xxxSToolStripMenuItem";
            this.xxxSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xxxSToolStripMenuItem.Text = "xxx *:S";
            this.xxxSToolStripMenuItem.Click += new System.EventHandler(this.xxxSToolStripMenuItem_Click);
            // 
            // regexxxxxToolStripMenuItem
            // 
            this.regexxxxxToolStripMenuItem.Name = "regexxxxxToolStripMenuItem";
            this.regexxxxxToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.regexxxxxToolStripMenuItem.Text = "--regex=xxxx";
            this.regexxxxxToolStripMenuItem.Click += new System.EventHandler(this.regexxxxxToolStripMenuItem_Click);
            // 
            // uidxxxxToolStripMenuItem
            // 
            this.uidxxxxToolStripMenuItem.Name = "uidxxxxToolStripMenuItem";
            this.uidxxxxToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.uidxxxxToolStripMenuItem.Text = "--uid=xxxx";
            this.uidxxxxToolStripMenuItem.Click += new System.EventHandler(this.uidxxxxToolStripMenuItem_Click);
            // 
            // logviewBox
            // 
            this.logviewBox.BackColor = System.Drawing.SystemColors.Control;
            this.logviewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logviewBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.logviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logviewBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logviewBox.HideSelection = false;
            this.logviewBox.Location = new System.Drawing.Point(0, 25);
            this.logviewBox.Name = "logviewBox";
            this.logviewBox.ReadOnly = true;
            this.logviewBox.Size = new System.Drawing.Size(800, 425);
            this.logviewBox.TabIndex = 1;
            this.logviewBox.Text = "";
            this.logviewBox.WordWrap = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // LogcatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logviewBox);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LogcatView";
            this.Text = "LogcatView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosedAction);
            this.Load += new System.EventHandler(this.OnFormLoadAction);
            this.Shown += new System.EventHandler(this.OnFormShown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox DevicesComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox FilterTextBox;
        private System.Windows.Forms.ToolStripButton StartOrStopBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ClearBtn;
        private System.Windows.Forms.RichTextBox logviewBox;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem xxxSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regexxxxxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uidxxxxToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}