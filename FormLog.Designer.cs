namespace RapChessGui
{
	partial class FormLog
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rtbCommand = new System.Windows.Forms.RichTextBox();
			this.butSend = new System.Windows.Forms.Button();
			this.cbPlayerList = new System.Windows.Forms.ComboBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Location = new System.Drawing.Point(0, 24);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(800, 361);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rtbCommand);
			this.panel1.Controls.Add(this.butSend);
			this.panel1.Controls.Add(this.cbPlayerList);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 385);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 65);
			this.panel1.TabIndex = 1;
			// 
			// rtbCommand
			// 
			this.rtbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbCommand.Location = new System.Drawing.Point(196, 6);
			this.rtbCommand.Name = "rtbCommand";
			this.rtbCommand.Size = new System.Drawing.Size(592, 53);
			this.rtbCommand.TabIndex = 6;
			this.rtbCommand.Text = "";
			// 
			// butSend
			// 
			this.butSend.Location = new System.Drawing.Point(12, 37);
			this.butSend.Name = "butSend";
			this.butSend.Size = new System.Drawing.Size(178, 21);
			this.butSend.TabIndex = 5;
			this.butSend.Text = "Send";
			this.butSend.UseVisualStyleBackColor = true;
			this.butSend.Click += new System.EventHandler(this.butSend_Click);
			// 
			// cbPlayerList
			// 
			this.cbPlayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPlayerList.FormattingEnabled = true;
			this.cbPlayerList.Items.AddRange(new object[] {
            "Human"});
			this.cbPlayerList.Location = new System.Drawing.Point(12, 10);
			this.cbPlayerList.Name = "cbPlayerList";
			this.cbPlayerList.Size = new System.Drawing.Size(178, 21);
			this.cbPlayerList.Sorted = true;
			this.cbPlayerList.TabIndex = 3;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// FormLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimizeBox = false;
			this.Name = "FormLog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Log";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLog_FormClosing);
			this.panel1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.ComboBox cbPlayerList;
		private System.Windows.Forms.Button butSend;
		private System.Windows.Forms.RichTextBox rtbCommand;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
	}
}