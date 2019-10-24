namespace RapChessGui
{
	partial class FormBook
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
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cbBookList = new System.Windows.Forms.ComboBox();
			this.bSort = new System.Windows.Forms.Button();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cbBookList);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(0, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(323, 45);
			this.groupBox5.TabIndex = 21;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Book";
			// 
			// cbBookList
			// 
			this.cbBookList.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBookList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBookList.FormattingEnabled = true;
			this.cbBookList.Items.AddRange(new object[] {
            "None"});
			this.cbBookList.Location = new System.Drawing.Point(3, 16);
			this.cbBookList.Name = "cbBookList";
			this.cbBookList.Size = new System.Drawing.Size(317, 21);
			this.cbBookList.Sorted = true;
			this.cbBookList.TabIndex = 2;
			// 
			// bSort
			// 
			this.bSort.Dock = System.Windows.Forms.DockStyle.Top;
			this.bSort.Location = new System.Drawing.Point(0, 45);
			this.bSort.Name = "bSort";
			this.bSort.Size = new System.Drawing.Size(323, 27);
			this.bSort.TabIndex = 22;
			this.bSort.Text = "Sort";
			this.bSort.UseVisualStyleBackColor = true;
			this.bSort.Click += new System.EventHandler(this.bSort_Click);
			// 
			// FormBook
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(323, 80);
			this.Controls.Add(this.bSort);
			this.Controls.Add(this.groupBox5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormBook";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Book";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBook_FormClosing);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox5;
		public System.Windows.Forms.ComboBox cbBookList;
		private System.Windows.Forms.Button bSort;
	}
}