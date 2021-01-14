namespace RapChessGui
{
	partial class FormEngine
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
			this.butClearHistory = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			this.bCreate = new System.Windows.Forms.Button();
			this.bUpdate = new System.Windows.Forms.Button();
			this.gbTournament = new System.Windows.Forms.GroupBox();
			this.cbModeStandard = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.nudTournament = new System.Windows.Forms.NumericUpDown();
			this.gbElo = new System.Windows.Forms.GroupBox();
			this.nudElo = new System.Windows.Forms.NumericUpDown();
			this.gbOptions = new System.Windows.Forms.GroupBox();
			this.rtbOptions = new System.Windows.Forms.RichTextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbParameters = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.cbProtocol = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbFileList = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbEngineName = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.gbTournament.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTournament)).BeginInit();
			this.gbElo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudElo)).BeginInit();
			this.gbOptions.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.butClearHistory);
			this.panel1.Controls.Add(this.bDelete);
			this.panel1.Controls.Add(this.bCreate);
			this.panel1.Controls.Add(this.bUpdate);
			this.panel1.Controls.Add(this.gbTournament);
			this.panel1.Controls.Add(this.groupBox5);
			this.panel1.Controls.Add(this.gbElo);
			this.panel1.Controls.Add(this.gbOptions);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox7);
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(489, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(311, 624);
			this.panel1.TabIndex = 0;
			// 
			// butClearHistory
			// 
			this.butClearHistory.Dock = System.Windows.Forms.DockStyle.Top;
			this.butClearHistory.Location = new System.Drawing.Point(0, 558);
			this.butClearHistory.Name = "butClearHistory";
			this.butClearHistory.Size = new System.Drawing.Size(311, 33);
			this.butClearHistory.TabIndex = 32;
			this.butClearHistory.Text = "Clear tournament history";
			this.butClearHistory.UseVisualStyleBackColor = true;
			this.butClearHistory.Click += new System.EventHandler(this.butClearHistory_Click);
			// 
			// bDelete
			// 
			this.bDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.bDelete.Location = new System.Drawing.Point(0, 525);
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
			this.bCreate.Location = new System.Drawing.Point(0, 492);
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
			this.bUpdate.Location = new System.Drawing.Point(0, 465);
			this.bUpdate.Name = "bUpdate";
			this.bUpdate.Size = new System.Drawing.Size(311, 27);
			this.bUpdate.TabIndex = 25;
			this.bUpdate.Text = "Update";
			this.bUpdate.UseVisualStyleBackColor = true;
			this.bUpdate.Click += new System.EventHandler(this.ButUpdate_Click);
			// 
			// gbTournament
			// 
			this.gbTournament.Controls.Add(this.cbModeStandard);
			this.gbTournament.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTournament.Location = new System.Drawing.Point(0, 428);
			this.gbTournament.Name = "gbTournament";
			this.gbTournament.Size = new System.Drawing.Size(311, 37);
			this.gbTournament.TabIndex = 31;
			this.gbTournament.TabStop = false;
			this.gbTournament.Text = "Options";
			// 
			// cbModeStandard
			// 
			this.cbModeStandard.AutoSize = true;
			this.cbModeStandard.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbModeStandard.Location = new System.Drawing.Point(3, 16);
			this.cbModeStandard.Name = "cbModeStandard";
			this.cbModeStandard.Size = new System.Drawing.Size(305, 17);
			this.cbModeStandard.TabIndex = 1;
			this.cbModeStandard.Text = "Mode standard";
			this.cbModeStandard.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.nudTournament);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(0, 383);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(311, 45);
			this.groupBox5.TabIndex = 33;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Tournament priority";
			// 
			// nudTournament
			// 
			this.nudTournament.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTournament.Location = new System.Drawing.Point(3, 16);
			this.nudTournament.Name = "nudTournament";
			this.nudTournament.Size = new System.Drawing.Size(305, 20);
			this.nudTournament.TabIndex = 0;
			this.nudTournament.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTournament.ThousandsSeparator = true;
			this.nudTournament.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// gbElo
			// 
			this.gbElo.Controls.Add(this.nudElo);
			this.gbElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbElo.Location = new System.Drawing.Point(0, 338);
			this.gbElo.Name = "gbElo";
			this.gbElo.Size = new System.Drawing.Size(311, 45);
			this.gbElo.TabIndex = 30;
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
			// gbOptions
			// 
			this.gbOptions.Controls.Add(this.rtbOptions);
			this.gbOptions.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbOptions.Location = new System.Drawing.Point(0, 180);
			this.gbOptions.Name = "gbOptions";
			this.gbOptions.Size = new System.Drawing.Size(311, 158);
			this.gbOptions.TabIndex = 29;
			this.gbOptions.TabStop = false;
			this.gbOptions.Text = "Options";
			// 
			// rtbOptions
			// 
			this.rtbOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtbOptions.Location = new System.Drawing.Point(3, 16);
			this.rtbOptions.Name = "rtbOptions";
			this.rtbOptions.Size = new System.Drawing.Size(305, 139);
			this.rtbOptions.TabIndex = 0;
			this.rtbOptions.Text = "";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tbParameters);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(0, 135);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(311, 45);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Parameters";
			// 
			// tbParameters
			// 
			this.tbParameters.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbParameters.Location = new System.Drawing.Point(3, 16);
			this.tbParameters.Name = "tbParameters";
			this.tbParameters.Size = new System.Drawing.Size(305, 20);
			this.tbParameters.TabIndex = 0;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.cbProtocol);
			this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox7.Location = new System.Drawing.Point(0, 90);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(311, 45);
			this.groupBox7.TabIndex = 28;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Protocol";
			// 
			// cbProtocol
			// 
			this.cbProtocol.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbProtocol.FormattingEnabled = true;
			this.cbProtocol.Items.AddRange(new object[] {
            "Uci",
            "Winboard"});
			this.cbProtocol.Location = new System.Drawing.Point(3, 16);
			this.cbProtocol.Name = "cbProtocol";
			this.cbProtocol.Size = new System.Drawing.Size(305, 21);
			this.cbProtocol.Sorted = true;
			this.cbProtocol.TabIndex = 2;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cbFileList);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new System.Drawing.Point(0, 45);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(311, 45);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Engin file";
			// 
			// cbFileList
			// 
			this.cbFileList.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbFileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFileList.FormattingEnabled = true;
			this.cbFileList.Items.AddRange(new object[] {
            "Human"});
			this.cbFileList.Location = new System.Drawing.Point(3, 16);
			this.cbFileList.Name = "cbFileList";
			this.cbFileList.Size = new System.Drawing.Size(305, 21);
			this.cbFileList.Sorted = true;
			this.cbFileList.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbEngineName);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(311, 45);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Name";
			// 
			// tbEngineName
			// 
			this.tbEngineName.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbEngineName.Location = new System.Drawing.Point(3, 16);
			this.tbEngineName.Name = "tbEngineName";
			this.tbEngineName.Size = new System.Drawing.Size(305, 20);
			this.tbEngineName.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listBox1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(489, 624);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Engines List";
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(3, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(483, 605);
			this.listBox1.Sorted = true;
			this.listBox1.TabIndex = 1;
			this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
			this.listBox1.SelectedValueChanged += new System.EventHandler(this.ListBox1_SelectedValueChanged);
			// 
			// FormEngine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 624);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MinimizeBox = false;
			this.Name = "FormEngine";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Engines";
			this.TopMost = true;
			this.Shown += new System.EventHandler(this.FormEngine_Shown);
			this.panel1.ResumeLayout(false);
			this.gbTournament.ResumeLayout(false);
			this.gbTournament.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTournament)).EndInit();
			this.gbElo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudElo)).EndInit();
			this.gbOptions.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbEngineName;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbFileList;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbParameters;
		private System.Windows.Forms.Button bDelete;
		private System.Windows.Forms.Button bCreate;
		private System.Windows.Forms.Button bUpdate;
		public System.Windows.Forms.ComboBox cbProtocol;
		private System.Windows.Forms.GroupBox gbOptions;
		private System.Windows.Forms.RichTextBox rtbOptions;
		private System.Windows.Forms.GroupBox gbElo;
		private System.Windows.Forms.NumericUpDown nudElo;
		private System.Windows.Forms.GroupBox gbTournament;
		private System.Windows.Forms.Button butClearHistory;
		private System.Windows.Forms.CheckBox cbModeStandard;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown nudTournament;
	}
}