namespace RapChessGui
{
	partial class FormEditEngine
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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panOptions = new System.Windows.Forms.Panel();
			this.panButtons = new System.Windows.Forms.Panel();
			this.bConsole = new System.Windows.Forms.Button();
			this.bAuto = new System.Windows.Forms.Button();
			this.bReset = new System.Windows.Forms.Button();
			this.bHistory = new System.Windows.Forms.Button();
			this.bDelete = new System.Windows.Forms.Button();
			this.bCreate = new System.Windows.Forms.Button();
			this.bRename = new System.Windows.Forms.Button();
			this.bSave = new System.Windows.Forms.Button();
			this.gbMode = new System.Windows.Forms.GroupBox();
			this.cbModeTournament = new System.Windows.Forms.CheckBox();
			this.cbModeDepth = new System.Windows.Forms.CheckBox();
			this.cbModeTime = new System.Windows.Forms.CheckBox();
			this.cbModeStandard = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.nudTournament = new System.Windows.Forms.NumericUpDown();
			this.gbElo = new System.Windows.Forms.GroupBox();
			this.nudElo = new System.Windows.Forms.NumericUpDown();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tbParameters = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.cbProtocol = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cbFileList = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbEngineName = new System.Windows.Forms.TextBox();
			this.gbEngines = new System.Windows.Forms.GroupBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.timerPhase = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.panButtons.SuspendLayout();
			this.gbMode.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTournament)).BeginInit();
			this.gbElo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudElo)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbEngines.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panOptions);
			this.panel1.Controls.Add(this.panButtons);
			this.panel1.Controls.Add(this.gbMode);
			this.panel1.Controls.Add(this.groupBox5);
			this.panel1.Controls.Add(this.gbElo);
			this.panel1.Controls.Add(this.groupBox3);
			this.panel1.Controls.Add(this.groupBox7);
			this.panel1.Controls.Add(this.groupBox4);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(489, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(311, 804);
			this.panel1.TabIndex = 0;
			// 
			// panOptions
			// 
			this.panOptions.AutoScroll = true;
			this.panOptions.AutoSize = true;
			this.panOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panOptions.Location = new System.Drawing.Point(0, 497);
			this.panOptions.Name = "panOptions";
			this.panOptions.Size = new System.Drawing.Size(311, 307);
			this.panOptions.TabIndex = 36;
			// 
			// panButtons
			// 
			this.panButtons.AutoSize = true;
			this.panButtons.Controls.Add(this.bConsole);
			this.panButtons.Controls.Add(this.bAuto);
			this.panButtons.Controls.Add(this.bReset);
			this.panButtons.Controls.Add(this.bHistory);
			this.panButtons.Controls.Add(this.bDelete);
			this.panButtons.Controls.Add(this.bCreate);
			this.panButtons.Controls.Add(this.bRename);
			this.panButtons.Controls.Add(this.bSave);
			this.panButtons.Dock = System.Windows.Forms.DockStyle.Top;
			this.panButtons.Location = new System.Drawing.Point(0, 305);
			this.panButtons.Name = "panButtons";
			this.panButtons.Size = new System.Drawing.Size(311, 192);
			this.panButtons.TabIndex = 39;
			// 
			// bConsole
			// 
			this.bConsole.AutoSize = true;
			this.bConsole.Dock = System.Windows.Forms.DockStyle.Top;
			this.bConsole.Location = new System.Drawing.Point(0, 168);
			this.bConsole.Name = "bConsole";
			this.bConsole.Size = new System.Drawing.Size(311, 24);
			this.bConsole.TabIndex = 42;
			this.bConsole.Text = "Console";
			this.bConsole.UseVisualStyleBackColor = true;
			this.bConsole.Click += new System.EventHandler(this.bConsole_Click);
			// 
			// bAuto
			// 
			this.bAuto.AutoSize = true;
			this.bAuto.Dock = System.Windows.Forms.DockStyle.Top;
			this.bAuto.Location = new System.Drawing.Point(0, 144);
			this.bAuto.Name = "bAuto";
			this.bAuto.Size = new System.Drawing.Size(311, 24);
			this.bAuto.TabIndex = 41;
			this.bAuto.Text = "Autodetect";
			this.bAuto.UseVisualStyleBackColor = true;
			this.bAuto.Click += new System.EventHandler(this.bAuto_Click);
			// 
			// bReset
			// 
			this.bReset.AutoSize = true;
			this.bReset.Dock = System.Windows.Forms.DockStyle.Top;
			this.bReset.Location = new System.Drawing.Point(0, 120);
			this.bReset.Name = "bReset";
			this.bReset.Size = new System.Drawing.Size(311, 24);
			this.bReset.TabIndex = 40;
			this.bReset.Text = "Reset to defaults";
			this.bReset.UseVisualStyleBackColor = true;
			this.bReset.Click += new System.EventHandler(this.bReset_Click);
			// 
			// bHistory
			// 
			this.bHistory.AutoSize = true;
			this.bHistory.Dock = System.Windows.Forms.DockStyle.Top;
			this.bHistory.Location = new System.Drawing.Point(0, 96);
			this.bHistory.Name = "bHistory";
			this.bHistory.Size = new System.Drawing.Size(311, 24);
			this.bHistory.TabIndex = 39;
			this.bHistory.Text = "Clear tournament history";
			this.bHistory.UseVisualStyleBackColor = true;
			this.bHistory.Click += new System.EventHandler(this.bHistory_Click);
			// 
			// bDelete
			// 
			this.bDelete.AutoSize = true;
			this.bDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.bDelete.Location = new System.Drawing.Point(0, 72);
			this.bDelete.Name = "bDelete";
			this.bDelete.Size = new System.Drawing.Size(311, 24);
			this.bDelete.TabIndex = 38;
			this.bDelete.Text = "Delete";
			this.bDelete.UseVisualStyleBackColor = true;
			this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
			// 
			// bCreate
			// 
			this.bCreate.AutoSize = true;
			this.bCreate.Dock = System.Windows.Forms.DockStyle.Top;
			this.bCreate.Location = new System.Drawing.Point(0, 48);
			this.bCreate.Name = "bCreate";
			this.bCreate.Size = new System.Drawing.Size(311, 24);
			this.bCreate.TabIndex = 37;
			this.bCreate.Text = "Create";
			this.bCreate.UseVisualStyleBackColor = true;
			this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
			// 
			// bRename
			// 
			this.bRename.AutoSize = true;
			this.bRename.Dock = System.Windows.Forms.DockStyle.Top;
			this.bRename.Location = new System.Drawing.Point(0, 24);
			this.bRename.Name = "bRename";
			this.bRename.Size = new System.Drawing.Size(311, 24);
			this.bRename.TabIndex = 36;
			this.bRename.Text = "Rename";
			this.bRename.UseVisualStyleBackColor = true;
			this.bRename.Click += new System.EventHandler(this.bRename_Click);
			// 
			// bSave
			// 
			this.bSave.AutoSize = true;
			this.bSave.Dock = System.Windows.Forms.DockStyle.Top;
			this.bSave.Location = new System.Drawing.Point(0, 0);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(311, 24);
			this.bSave.TabIndex = 26;
			this.bSave.Text = "Save";
			this.bSave.UseVisualStyleBackColor = true;
			this.bSave.Click += new System.EventHandler(this.bSave_Click);
			// 
			// gbMode
			// 
			this.gbMode.AutoSize = true;
			this.gbMode.Controls.Add(this.cbModeTournament);
			this.gbMode.Controls.Add(this.cbModeDepth);
			this.gbMode.Controls.Add(this.cbModeTime);
			this.gbMode.Controls.Add(this.cbModeStandard);
			this.gbMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbMode.Location = new System.Drawing.Point(0, 236);
			this.gbMode.Name = "gbMode";
			this.gbMode.Size = new System.Drawing.Size(311, 69);
			this.gbMode.TabIndex = 31;
			this.gbMode.TabStop = false;
			this.gbMode.Text = "Mode";
			// 
			// cbModeTournament
			// 
			this.cbModeTournament.AutoSize = true;
			this.cbModeTournament.Location = new System.Drawing.Point(159, 33);
			this.cbModeTournament.Name = "cbModeTournament";
			this.cbModeTournament.Size = new System.Drawing.Size(109, 17);
			this.cbModeTournament.TabIndex = 4;
			this.cbModeTournament.Text = "Mode tournament";
			this.cbModeTournament.UseVisualStyleBackColor = true;
			// 
			// cbModeDepth
			// 
			this.cbModeDepth.AutoSize = true;
			this.cbModeDepth.Location = new System.Drawing.Point(159, 16);
			this.cbModeDepth.Name = "cbModeDepth";
			this.cbModeDepth.Size = new System.Drawing.Size(83, 17);
			this.cbModeDepth.TabIndex = 3;
			this.cbModeDepth.Text = "Mode depth";
			this.cbModeDepth.UseVisualStyleBackColor = true;
			// 
			// cbModeTime
			// 
			this.cbModeTime.AutoSize = true;
			this.cbModeTime.Location = new System.Drawing.Point(3, 33);
			this.cbModeTime.Name = "cbModeTime";
			this.cbModeTime.Size = new System.Drawing.Size(75, 17);
			this.cbModeTime.TabIndex = 2;
			this.cbModeTime.Text = "Mode time";
			this.cbModeTime.UseVisualStyleBackColor = true;
			// 
			// cbModeStandard
			// 
			this.cbModeStandard.AutoSize = true;
			this.cbModeStandard.Location = new System.Drawing.Point(3, 16);
			this.cbModeStandard.Name = "cbModeStandard";
			this.cbModeStandard.Size = new System.Drawing.Size(97, 17);
			this.cbModeStandard.TabIndex = 1;
			this.cbModeStandard.Text = "Mode standard";
			this.cbModeStandard.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.AutoSize = true;
			this.groupBox5.Controls.Add(this.nudTournament);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(0, 197);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(311, 39);
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
			this.gbElo.AutoSize = true;
			this.gbElo.Controls.Add(this.nudElo);
			this.gbElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbElo.Location = new System.Drawing.Point(0, 158);
			this.gbElo.Name = "gbElo";
			this.gbElo.Size = new System.Drawing.Size(311, 39);
			this.gbElo.TabIndex = 30;
			this.gbElo.TabStop = false;
			this.gbElo.Text = "Elo";
			// 
			// nudElo
			// 
			this.nudElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudElo.Location = new System.Drawing.Point(3, 16);
			this.nudElo.Maximum = new decimal(new int[] {
            15000,
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
			// groupBox3
			// 
			this.groupBox3.AutoSize = true;
			this.groupBox3.Controls.Add(this.tbParameters);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(0, 119);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(311, 39);
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
			this.groupBox7.AutoSize = true;
			this.groupBox7.Controls.Add(this.cbProtocol);
			this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox7.Location = new System.Drawing.Point(0, 79);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(311, 40);
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
            "Auto",
            "Uci",
            "Unknown",
            "Winboard"});
			this.cbProtocol.Location = new System.Drawing.Point(3, 16);
			this.cbProtocol.Name = "cbProtocol";
			this.cbProtocol.Size = new System.Drawing.Size(305, 21);
			this.cbProtocol.Sorted = true;
			this.cbProtocol.TabIndex = 2;
			// 
			// groupBox4
			// 
			this.groupBox4.AutoSize = true;
			this.groupBox4.Controls.Add(this.cbFileList);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new System.Drawing.Point(0, 39);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(311, 40);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Engine file";
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
			this.cbFileList.TabIndex = 2;
			this.cbFileList.SelectedIndexChanged += new System.EventHandler(this.cbFileList_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.AutoSize = true;
			this.groupBox1.Controls.Add(this.tbEngineName);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(311, 39);
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
			// gbEngines
			// 
			this.gbEngines.AutoSize = true;
			this.gbEngines.Controls.Add(this.listBox1);
			this.gbEngines.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbEngines.Location = new System.Drawing.Point(0, 0);
			this.gbEngines.Name = "gbEngines";
			this.gbEngines.Size = new System.Drawing.Size(489, 804);
			this.gbEngines.TabIndex = 5;
			this.gbEngines.TabStop = false;
			this.gbEngines.Text = "Engines List";
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(3, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(483, 785);
			this.listBox1.Sorted = true;
			this.listBox1.TabIndex = 1;
			this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
			this.listBox1.SelectedValueChanged += new System.EventHandler(this.ListBox1_SelectedValueChanged);
			this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
			this.listBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseMove);
			this.listBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseUp);
			// 
			// FormEditEngine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(800, 804);
			this.Controls.Add(this.gbEngines);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MinimizeBox = false;
			this.Name = "FormEditEngine";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Engines";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEngine_FormClosing);
			this.Shown += new System.EventHandler(this.FormEngine_Shown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panButtons.ResumeLayout(false);
			this.panButtons.PerformLayout();
			this.gbMode.ResumeLayout(false);
			this.gbMode.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTournament)).EndInit();
			this.gbElo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudElo)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbEngines.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbEngineName;
		private System.Windows.Forms.GroupBox gbEngines;
		public System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbFileList;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox tbParameters;
		public System.Windows.Forms.ComboBox cbProtocol;
		private System.Windows.Forms.GroupBox gbElo;
		private System.Windows.Forms.NumericUpDown nudElo;
		private System.Windows.Forms.GroupBox gbMode;
		private System.Windows.Forms.CheckBox cbModeStandard;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown nudTournament;
		private System.Windows.Forms.CheckBox cbModeDepth;
		private System.Windows.Forms.CheckBox cbModeTime;
		private System.Windows.Forms.Panel panOptions;
		private System.Windows.Forms.Timer timerPhase;
		private System.Windows.Forms.Panel panButtons;
		private System.Windows.Forms.Button bConsole;
		private System.Windows.Forms.Button bAuto;
		private System.Windows.Forms.Button bReset;
		private System.Windows.Forms.Button bHistory;
		private System.Windows.Forms.Button bDelete;
		private System.Windows.Forms.Button bCreate;
		private System.Windows.Forms.Button bRename;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.CheckBox cbModeTournament;
	}
}