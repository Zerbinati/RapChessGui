namespace RapChessGui
{
	partial class FormOptions
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
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.butDefault = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.butColor = new System.Windows.Forms.Button();
			this.cbRotateBoard = new System.Windows.Forms.CheckBox();
			this.cbShowPonder = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// butDefault
			// 
			this.butDefault.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butDefault.Location = new System.Drawing.Point(0, 100);
			this.butDefault.Name = "butDefault";
			this.butDefault.Size = new System.Drawing.Size(262, 24);
			this.butDefault.TabIndex = 2;
			this.butDefault.Text = "Default";
			this.butDefault.UseVisualStyleBackColor = true;
			this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbShowPonder);
			this.groupBox1.Controls.Add(this.cbRotateBoard);
			this.groupBox1.Controls.Add(this.butColor);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(262, 90);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Interface";
			// 
			// butColor
			// 
			this.butColor.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butColor.Location = new System.Drawing.Point(3, 63);
			this.butColor.Name = "butColor";
			this.butColor.Size = new System.Drawing.Size(256, 24);
			this.butColor.TabIndex = 4;
			this.butColor.Text = "Board color";
			this.butColor.UseVisualStyleBackColor = true;
			this.butColor.Click += new System.EventHandler(this.butColor_Click);
			// 
			// cbRotateBoard
			// 
			this.cbRotateBoard.AutoSize = true;
			this.cbRotateBoard.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbRotateBoard.Location = new System.Drawing.Point(3, 16);
			this.cbRotateBoard.Name = "cbRotateBoard";
			this.cbRotateBoard.Size = new System.Drawing.Size(256, 17);
			this.cbRotateBoard.TabIndex = 5;
			this.cbRotateBoard.Text = "Rotate board";
			this.cbRotateBoard.UseVisualStyleBackColor = true;
			this.cbRotateBoard.CheckedChanged += new System.EventHandler(this.CbRotateBoard_CheckedChanged);
			// 
			// cbShowPonder
			// 
			this.cbShowPonder.AutoSize = true;
			this.cbShowPonder.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbShowPonder.Location = new System.Drawing.Point(3, 33);
			this.cbShowPonder.Name = "cbShowPonder";
			this.cbShowPonder.Size = new System.Drawing.Size(256, 17);
			this.cbShowPonder.TabIndex = 6;
			this.cbShowPonder.Text = "Show ponder";
			this.cbShowPonder.UseVisualStyleBackColor = true;
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(262, 124);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.butDefault);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormOptions";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button butDefault;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button butColor;
		public System.Windows.Forms.CheckBox cbShowPonder;
		public System.Windows.Forms.CheckBox cbRotateBoard;
	}
}