namespace RapChessGui
{
	partial class FormPlayer
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.bDelete = new System.Windows.Forms.Button();
			this.bCreate = new System.Windows.Forms.Button();
			this.bUpdate = new System.Windows.Forms.Button();
			this.gbElo = new System.Windows.Forms.GroupBox();
			this.nudElo = new System.Windows.Forms.NumericUpDown();
			this.gbMode = new System.Windows.Forms.GroupBox();
			this.nudDepth = new System.Windows.Forms.NumericUpDown();
			this.nudTime = new System.Windows.Forms.NumericUpDown();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.gbBook = new System.Windows.Forms.GroupBox();
			this.cbBookList = new System.Windows.Forms.ComboBox();
			this.gbEngine = new System.Windows.Forms.GroupBox();
			this.cbEngineList = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbPlayerName = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.gbElo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudElo)).BeginInit();
			this.gbMode.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
			this.gbBook.SuspendLayout();
			this.gbEngine.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.bDelete);
			this.panel1.Controls.Add(this.bCreate);
			this.panel1.Controls.Add(this.bUpdate);
			this.panel1.Controls.Add(this.gbElo);
			this.panel1.Controls.Add(this.gbMode);
			this.panel1.Controls.Add(this.gbBook);
			this.panel1.Controls.Add(this.gbEngine);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(489, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(311, 591);
			this.panel1.TabIndex = 0;
			// 
			// bDelete
			// 
			this.bDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.bDelete.Location = new System.Drawing.Point(0, 310);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(311, 33);
			this.bDelete.TabIndex = 27;
			this.bDelete.Text = "Delete";
			this.bDelete.UseVisualStyleBackColor = true;
			this.bDelete.Click += new System.EventHandler(this.ButDelete_Click);
			// 
			// bCreate
			// 
			this.bCreate.Dock = System.Windows.Forms.DockStyle.Top;
			this.bCreate.Location = new System.Drawing.Point(0, 277);
			this.bCreate.Name = "bCreate";
			this.bCreate.Size = new System.Drawing.Size(311, 33);
			this.bCreate.TabIndex = 26;
			this.bCreate.Text = "Create";
			this.bCreate.UseVisualStyleBackColor = true;
			this.bCreate.Click += new System.EventHandler(this.ButCreate_Click);
			// 
			// bUpdate
			// 
			this.bUpdate.Dock = System.Windows.Forms.DockStyle.Top;
			this.bUpdate.Location = new System.Drawing.Point(0, 250);
			this.bUpdate.Name = "bUpdate";
			this.bUpdate.Size = new System.Drawing.Size(311, 27);
			this.bUpdate.TabIndex = 25;
			this.bUpdate.Text = "Update";
			this.bUpdate.UseVisualStyleBackColor = true;
			this.bUpdate.Click += new System.EventHandler(this.ButUpdate_Click);
			// 
			// gbElo
			// 
			this.gbElo.Controls.Add(this.nudElo);
			this.gbElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbElo.Location = new System.Drawing.Point(0, 205);
			this.gbElo.Name = "gbElo";
			this.gbElo.Size = new System.Drawing.Size(311, 45);
			this.gbElo.TabIndex = 24;
			this.gbElo.TabStop = false;
			this.gbElo.Text = "Elo";
			// 
			// nudElo
			// 
			this.nudElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudElo.Location = new System.Drawing.Point(3, 16);
			this.nudElo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudElo.Name = "nudElo";
			this.nudElo.Size = new System.Drawing.Size(305, 20);
			this.nudElo.TabIndex = 0;
			this.nudElo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudElo.ThousandsSeparator = true;
			this.nudElo.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// gbMode
			// 
			this.gbMode.Controls.Add(this.nudDepth);
			this.gbMode.Controls.Add(this.nudTime);
			this.gbMode.Controls.Add(this.radioButton2);
			this.gbMode.Controls.Add(this.radioButton1);
			this.gbMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbMode.Location = new System.Drawing.Point(0, 135);
			this.gbMode.Name = "gbMode";
			this.gbMode.Size = new System.Drawing.Size(311, 70);
			this.gbMode.TabIndex = 16;
			this.gbMode.TabStop = false;
			this.gbMode.Text = "Mode";
			// 
			// nudDepth
			// 
			this.nudDepth.Location = new System.Drawing.Point(83, 39);
			this.nudDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudDepth.Name = "nudDepth";
			this.nudDepth.Size = new System.Drawing.Size(222, 20);
			this.nudDepth.TabIndex = 3;
			this.nudDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudDepth.ThousandsSeparator = true;
			this.nudDepth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// nudTime
			// 
			this.nudTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudTime.Location = new System.Drawing.Point(83, 16);
			this.nudTime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nudTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTime.Name = "nudTime";
			this.nudTime.Size = new System.Drawing.Size(222, 20);
			this.nudTime.TabIndex = 2;
			this.nudTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTime.ThousandsSeparator = true;
			this.nudTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(6, 42);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(54, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Depth";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(48, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Time";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// gbBook
			// 
			this.gbBook.Controls.Add(this.cbBookList);
			this.gbBook.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbBook.Location = new System.Drawing.Point(0, 90);
			this.gbBook.Name = "gbBook";
			this.gbBook.Size = new System.Drawing.Size(311, 45);
			this.gbBook.TabIndex = 20;
			this.gbBook.TabStop = false;
			this.gbBook.Text = "Book";
			// 
			// cbBookList
			// 
			this.cbBookList.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBookList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBookList.FormattingEnabled = true;
			this.cbBookList.Location = new System.Drawing.Point(3, 16);
			this.cbBookList.Name = "cbBookList";
			this.cbBookList.Size = new System.Drawing.Size(305, 21);
			this.cbBookList.Sorted = true;
			this.cbBookList.TabIndex = 2;
			// 
			// gbEngine
			// 
			this.gbEngine.Controls.Add(this.cbEngineList);
			this.gbEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbEngine.Location = new System.Drawing.Point(0, 45);
			this.gbEngine.Name = "gbEngine";
			this.gbEngine.Size = new System.Drawing.Size(311, 45);
			this.gbEngine.TabIndex = 11;
			this.gbEngine.TabStop = false;
			this.gbEngine.Text = "Engine";
			// 
			// cbEngineList
			// 
			this.cbEngineList.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEngineList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEngineList.FormattingEnabled = true;
			this.cbEngineList.Items.AddRange(new object[] {
            "Human"});
			this.cbEngineList.Location = new System.Drawing.Point(3, 16);
			this.cbEngineList.Name = "cbEngineList";
			this.cbEngineList.Size = new System.Drawing.Size(305, 21);
			this.cbEngineList.Sorted = true;
			this.cbEngineList.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbPlayerName);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(311, 45);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Name";
			// 
			// tbPlayerName
			// 
			this.tbPlayerName.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbPlayerName.Location = new System.Drawing.Point(3, 16);
			this.tbPlayerName.Name = "tbPlayerName";
			this.tbPlayerName.Size = new System.Drawing.Size(305, 20);
			this.tbPlayerName.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listBox1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(489, 591);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Players List";
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(3, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(483, 572);
			this.listBox1.Sorted = true;
			this.listBox1.TabIndex = 1;
			this.listBox1.SelectedValueChanged += new System.EventHandler(this.ListBox1_SelectedValueChanged);
			// 
			// FormPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 591);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MinimizeBox = false;
			this.Name = "FormPlayer";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Players";
			this.TopMost = true;
			this.Shown += new System.EventHandler(this.FormPlayer_Shown);
			this.panel1.ResumeLayout(false);
			this.gbElo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudElo)).EndInit();
			this.gbMode.ResumeLayout(false);
			this.gbMode.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
			this.gbBook.ResumeLayout(false);
			this.gbEngine.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbPlayerName;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.GroupBox gbEngine;
		private System.Windows.Forms.ComboBox cbEngineList;
		private System.Windows.Forms.GroupBox gbMode;
		private System.Windows.Forms.NumericUpDown nudDepth;
		private System.Windows.Forms.NumericUpDown nudTime;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.GroupBox gbBook;
		public System.Windows.Forms.ComboBox cbBookList;
		private System.Windows.Forms.Button bDelete;
		private System.Windows.Forms.Button bCreate;
		private System.Windows.Forms.Button bUpdate;
		private System.Windows.Forms.GroupBox gbElo;
		private System.Windows.Forms.NumericUpDown nudElo;
	}
}