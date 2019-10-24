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
			this.cbRotateBoard = new System.Windows.Forms.CheckBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.butDefault = new System.Windows.Forms.Button();
			this.butColor = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbRotateBoard
			// 
			this.cbRotateBoard.AutoSize = true;
			this.cbRotateBoard.Location = new System.Drawing.Point(44, 33);
			this.cbRotateBoard.Name = "cbRotateBoard";
			this.cbRotateBoard.Size = new System.Drawing.Size(88, 17);
			this.cbRotateBoard.TabIndex = 0;
			this.cbRotateBoard.Text = "Rotate board";
			this.cbRotateBoard.UseVisualStyleBackColor = true;
			this.cbRotateBoard.CheckedChanged += new System.EventHandler(this.CbRotateBoard_CheckedChanged);
			// 
			// butDefault
			// 
			this.butDefault.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butDefault.Location = new System.Drawing.Point(0, 87);
			this.butDefault.Name = "butDefault";
			this.butDefault.Size = new System.Drawing.Size(162, 24);
			this.butDefault.TabIndex = 2;
			this.butDefault.Text = "Default";
			this.butDefault.UseVisualStyleBackColor = true;
			this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
			// 
			// butColor
			// 
			this.butColor.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butColor.Location = new System.Drawing.Point(0, 63);
			this.butColor.Name = "butColor";
			this.butColor.Size = new System.Drawing.Size(162, 24);
			this.butColor.TabIndex = 3;
			this.butColor.Text = "Board color";
			this.butColor.UseVisualStyleBackColor = true;
			this.butColor.Click += new System.EventHandler(this.button1_Click);
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(162, 111);
			this.Controls.Add(this.butColor);
			this.Controls.Add(this.butDefault);
			this.Controls.Add(this.cbRotateBoard);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormOptions";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbRotateBoard;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button butDefault;
		private System.Windows.Forms.Button butColor;
	}
}