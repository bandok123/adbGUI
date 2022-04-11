
namespace adbGUI.Forms
{
    partial class Bookmarks
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
            this.bookmarksListView = new System.Windows.Forms.ListView();
            this.Label = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Command = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commandLabel = new System.Windows.Forms.Label();
            this.commandTB = new System.Windows.Forms.TextBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.labelTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bookmarksListView
            // 
            this.bookmarksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Label,
            this.Command});
            this.bookmarksListView.FullRowSelect = true;
            this.bookmarksListView.GridLines = true;
            this.bookmarksListView.HideSelection = false;
            this.bookmarksListView.Location = new System.Drawing.Point(12, 12);
            this.bookmarksListView.MultiSelect = false;
            this.bookmarksListView.Name = "bookmarksListView";
            this.bookmarksListView.Size = new System.Drawing.Size(649, 185);
            this.bookmarksListView.TabIndex = 0;
            this.bookmarksListView.UseCompatibleStateImageBehavior = false;
            this.bookmarksListView.View = System.Windows.Forms.View.Details;
            this.bookmarksListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.bookmarksListView_ItemSelectionChanged);
            // 
            // Label
            // 
            this.Label.Text = "Label";
            this.Label.Width = 124;
            // 
            // Command
            // 
            this.Command.Text = "Command";
            this.Command.Width = 496;
            // 
            // commandLabel
            // 
            this.commandLabel.AutoSize = true;
            this.commandLabel.Location = new System.Drawing.Point(12, 245);
            this.commandLabel.Name = "commandLabel";
            this.commandLabel.Size = new System.Drawing.Size(47, 12);
            this.commandLabel.TabIndex = 1;
            this.commandLabel.Text = "Command";
            // 
            // commandTB
            // 
            this.commandTB.Location = new System.Drawing.Point(66, 241);
            this.commandTB.Name = "commandTB";
            this.commandTB.Size = new System.Drawing.Size(595, 21);
            this.commandTB.TabIndex = 2;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(295, 268);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(392, 268);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(75, 23);
            this.modifyBtn.TabIndex = 4;
            this.modifyBtn.Text = "Modify";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(489, 268);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(586, 268);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 23);
            this.runBtn.TabIndex = 6;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // labelTB
            // 
            this.labelTB.Location = new System.Drawing.Point(66, 212);
            this.labelTB.Name = "labelTB";
            this.labelTB.Size = new System.Drawing.Size(595, 21);
            this.labelTB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Label";
            // 
            // Bookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 304);
            this.Controls.Add(this.labelTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.commandTB);
            this.Controls.Add(this.commandLabel);
            this.Controls.Add(this.bookmarksListView);
            this.Name = "Bookmarks";
            this.Text = "Bookmarks";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bookmarks_FormClosed);
            this.Shown += new System.EventHandler(this.Bookmarks_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView bookmarksListView;
        private System.Windows.Forms.Label commandLabel;
        private System.Windows.Forms.TextBox commandTB;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.ColumnHeader Label;
        private System.Windows.Forms.ColumnHeader Command;
        private System.Windows.Forms.TextBox labelTB;
        private System.Windows.Forms.Label label1;
    }
}