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
			this.gbInterface = new System.Windows.Forms.GroupBox();
			this.butColor = new System.Windows.Forms.Button();
			this.cbTips = new System.Windows.Forms.CheckBox();
			this.cbArrow = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nudSpeed = new System.Windows.Forms.NumericUpDown();
			this.cbAttack = new System.Windows.Forms.CheckBox();
			this.cbShowPonder = new System.Windows.Forms.CheckBox();
			this.butOk = new System.Windows.Forms.Button();
			this.gbGame = new System.Windows.Forms.GroupBox();
			this.cbRotateBoard = new System.Windows.Forms.CheckBox();
			this.cbGameAutoElo = new System.Windows.Forms.CheckBox();
			this.gbTournament = new System.Windows.Forms.GroupBox();
			this.labTourP = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.nudTourP = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.combModeTime = new System.Windows.Forms.ComboBox();
			this.combModeStandard = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.labTourE = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.nudTourE = new System.Windows.Forms.NumericUpDown();
			this.gbNotation = new System.Windows.Forms.GroupBox();
			this.rbUci = new System.Windows.Forms.RadioButton();
			this.rbSan = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.combPriority = new System.Windows.Forms.ComboBox();
			this.gbInterface.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
			this.gbGame.SuspendLayout();
			this.gbTournament.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourP)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourE)).BeginInit();
			this.gbNotation.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// butDefault
			// 
			this.butDefault.Dock = System.Windows.Forms.DockStyle.Top;
			this.butDefault.Location = new System.Drawing.Point(0, 485);
			this.butDefault.Name = "butDefault";
			this.butDefault.Size = new System.Drawing.Size(286, 24);
			this.butDefault.TabIndex = 2;
			this.butDefault.Text = "Default";
			this.butDefault.UseVisualStyleBackColor = true;
			this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
			// 
			// gbInterface
			// 
			this.gbInterface.Controls.Add(this.butColor);
			this.gbInterface.Controls.Add(this.cbTips);
			this.gbInterface.Controls.Add(this.cbArrow);
			this.gbInterface.Controls.Add(this.label1);
			this.gbInterface.Controls.Add(this.nudSpeed);
			this.gbInterface.Controls.Add(this.cbAttack);
			this.gbInterface.Controls.Add(this.cbShowPonder);
			this.gbInterface.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbInterface.Location = new System.Drawing.Point(0, 234);
			this.gbInterface.Name = "gbInterface";
			this.gbInterface.Size = new System.Drawing.Size(286, 148);
			this.gbInterface.TabIndex = 4;
			this.gbInterface.TabStop = false;
			this.gbInterface.Text = "Interface";
			// 
			// butColor
			// 
			this.butColor.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butColor.Location = new System.Drawing.Point(3, 121);
			this.butColor.Name = "butColor";
			this.butColor.Size = new System.Drawing.Size(280, 24);
			this.butColor.TabIndex = 4;
			this.butColor.Text = "Board color";
			this.butColor.UseVisualStyleBackColor = true;
			this.butColor.Click += new System.EventHandler(this.butColor_Click);
			// 
			// cbTips
			// 
			this.cbTips.AutoSize = true;
			this.cbTips.Checked = true;
			this.cbTips.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbTips.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTips.Location = new System.Drawing.Point(3, 67);
			this.cbTips.Name = "cbTips";
			this.cbTips.Size = new System.Drawing.Size(280, 17);
			this.cbTips.TabIndex = 12;
			this.cbTips.Text = "Show Tips";
			this.cbTips.UseVisualStyleBackColor = true;
			// 
			// cbArrow
			// 
			this.cbArrow.AutoSize = true;
			this.cbArrow.Checked = true;
			this.cbArrow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbArrow.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbArrow.Location = new System.Drawing.Point(3, 50);
			this.cbArrow.Name = "cbArrow";
			this.cbArrow.Size = new System.Drawing.Size(280, 17);
			this.cbArrow.TabIndex = 10;
			this.cbArrow.Text = "Show arrow";
			this.cbArrow.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(168, 97);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Animation speed";
			// 
			// nudSpeed
			// 
			this.nudSpeed.Location = new System.Drawing.Point(6, 90);
			this.nudSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudSpeed.Name = "nudSpeed";
			this.nudSpeed.Size = new System.Drawing.Size(153, 20);
			this.nudSpeed.TabIndex = 8;
			this.nudSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudSpeed.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			// 
			// cbAttack
			// 
			this.cbAttack.AutoSize = true;
			this.cbAttack.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbAttack.Location = new System.Drawing.Point(3, 33);
			this.cbAttack.Name = "cbAttack";
			this.cbAttack.Size = new System.Drawing.Size(280, 17);
			this.cbAttack.TabIndex = 7;
			this.cbAttack.Text = "Show attack";
			this.cbAttack.UseVisualStyleBackColor = true;
			// 
			// cbShowPonder
			// 
			this.cbShowPonder.AutoSize = true;
			this.cbShowPonder.Checked = true;
			this.cbShowPonder.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbShowPonder.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbShowPonder.Location = new System.Drawing.Point(3, 16);
			this.cbShowPonder.Name = "cbShowPonder";
			this.cbShowPonder.Size = new System.Drawing.Size(280, 17);
			this.cbShowPonder.TabIndex = 6;
			this.cbShowPonder.Text = "Show ponder";
			this.cbShowPonder.UseVisualStyleBackColor = true;
			// 
			// butOk
			// 
			this.butOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.butOk.Dock = System.Windows.Forms.DockStyle.Top;
			this.butOk.Location = new System.Drawing.Point(0, 509);
			this.butOk.Name = "butOk";
			this.butOk.Size = new System.Drawing.Size(286, 24);
			this.butOk.TabIndex = 1;
			this.butOk.Text = "Ok";
			this.butOk.UseVisualStyleBackColor = true;
			this.butOk.Click += new System.EventHandler(this.butOk_Click);
			// 
			// gbGame
			// 
			this.gbGame.Controls.Add(this.cbRotateBoard);
			this.gbGame.Controls.Add(this.cbGameAutoElo);
			this.gbGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbGame.Location = new System.Drawing.Point(0, 0);
			this.gbGame.Name = "gbGame";
			this.gbGame.Size = new System.Drawing.Size(286, 52);
			this.gbGame.TabIndex = 6;
			this.gbGame.TabStop = false;
			this.gbGame.Text = "Game";
			// 
			// cbRotateBoard
			// 
			this.cbRotateBoard.AutoSize = true;
			this.cbRotateBoard.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbRotateBoard.Location = new System.Drawing.Point(3, 33);
			this.cbRotateBoard.Name = "cbRotateBoard";
			this.cbRotateBoard.Size = new System.Drawing.Size(280, 17);
			this.cbRotateBoard.TabIndex = 6;
			this.cbRotateBoard.Text = "Rotate board";
			this.cbRotateBoard.UseVisualStyleBackColor = true;
			this.cbRotateBoard.CheckedChanged += new System.EventHandler(this.CbRotateBoard_CheckedChanged);
			// 
			// cbGameAutoElo
			// 
			this.cbGameAutoElo.AutoSize = true;
			this.cbGameAutoElo.Checked = true;
			this.cbGameAutoElo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbGameAutoElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbGameAutoElo.Location = new System.Drawing.Point(3, 16);
			this.cbGameAutoElo.Name = "cbGameAutoElo";
			this.cbGameAutoElo.Size = new System.Drawing.Size(280, 17);
			this.cbGameAutoElo.TabIndex = 5;
			this.cbGameAutoElo.Text = "Auto elo";
			this.cbGameAutoElo.UseVisualStyleBackColor = true;
			// 
			// gbTournament
			// 
			this.gbTournament.Controls.Add(this.labTourP);
			this.gbTournament.Controls.Add(this.label2);
			this.gbTournament.Controls.Add(this.nudTourP);
			this.gbTournament.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTournament.Location = new System.Drawing.Point(0, 104);
			this.gbTournament.Name = "gbTournament";
			this.gbTournament.Size = new System.Drawing.Size(286, 52);
			this.gbTournament.TabIndex = 7;
			this.gbTournament.TabStop = false;
			this.gbTournament.Text = "Tournament-players";
			// 
			// labTourP
			// 
			this.labTourP.AutoSize = true;
			this.labTourP.Location = new System.Drawing.Point(168, 29);
			this.labTourP.Name = "labTourP";
			this.labTourP.Size = new System.Drawing.Size(19, 13);
			this.labTourP.TabIndex = 11;
			this.labTourP.Text = "Fill";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(168, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Max history records";
			// 
			// nudTourP
			// 
			this.nudTourP.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourP.Location = new System.Drawing.Point(6, 19);
			this.nudTourP.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudTourP.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourP.Name = "nudTourP";
			this.nudTourP.Size = new System.Drawing.Size(156, 20);
			this.nudTourP.TabIndex = 9;
			this.nudTourP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourP.ThousandsSeparator = true;
			this.nudTourP.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.combModeTime);
			this.groupBox1.Controls.Add(this.combModeStandard);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 156);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(286, 78);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Time margin";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(168, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Mode time";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(168, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Mode standard";
			// 
			// combModeTime
			// 
			this.combModeTime.AutoCompleteCustomSource.AddRange(new string[] {
            "White",
            "Black"});
			this.combModeTime.Cursor = System.Windows.Forms.Cursors.Hand;
			this.combModeTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combModeTime.Items.AddRange(new object[] {
            "Off",
            "0 sec",
            "1 sec",
            "2 sec",
            "5 sec"});
			this.combModeTime.Location = new System.Drawing.Point(6, 46);
			this.combModeTime.Name = "combModeTime";
			this.combModeTime.Size = new System.Drawing.Size(153, 21);
			this.combModeTime.TabIndex = 4;
			// 
			// combModeStandard
			// 
			this.combModeStandard.AutoCompleteCustomSource.AddRange(new string[] {
            "White",
            "Black"});
			this.combModeStandard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.combModeStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combModeStandard.Items.AddRange(new object[] {
            "Off",
            "0 sec",
            "1 sec",
            "2 sec",
            "5 sec"});
			this.combModeStandard.Location = new System.Drawing.Point(6, 19);
			this.combModeStandard.Name = "combModeStandard";
			this.combModeStandard.Size = new System.Drawing.Size(153, 21);
			this.combModeStandard.TabIndex = 3;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.labTourE);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.nudTourE);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 52);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(286, 52);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tournament-engines";
			// 
			// labTourE
			// 
			this.labTourE.AutoSize = true;
			this.labTourE.Location = new System.Drawing.Point(168, 29);
			this.labTourE.Name = "labTourE";
			this.labTourE.Size = new System.Drawing.Size(19, 13);
			this.labTourE.TabIndex = 11;
			this.labTourE.Text = "Fill";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(168, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(98, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Max history records";
			// 
			// nudTourE
			// 
			this.nudTourE.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourE.Location = new System.Drawing.Point(6, 19);
			this.nudTourE.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudTourE.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTourE.Name = "nudTourE";
			this.nudTourE.Size = new System.Drawing.Size(156, 20);
			this.nudTourE.TabIndex = 9;
			this.nudTourE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourE.ThousandsSeparator = true;
			this.nudTourE.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			// 
			// gbNotation
			// 
			this.gbNotation.Controls.Add(this.rbUci);
			this.gbNotation.Controls.Add(this.rbSan);
			this.gbNotation.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbNotation.Location = new System.Drawing.Point(0, 382);
			this.gbNotation.Name = "gbNotation";
			this.gbNotation.Size = new System.Drawing.Size(286, 53);
			this.gbNotation.TabIndex = 10;
			this.gbNotation.TabStop = false;
			this.gbNotation.Text = "Notation";
			// 
			// rbUci
			// 
			this.rbUci.AutoSize = true;
			this.rbUci.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbUci.Location = new System.Drawing.Point(3, 33);
			this.rbUci.Name = "rbUci";
			this.rbUci.Size = new System.Drawing.Size(280, 17);
			this.rbUci.TabIndex = 1;
			this.rbUci.Text = "Uci";
			this.rbUci.UseVisualStyleBackColor = true;
			// 
			// rbSan
			// 
			this.rbSan.AutoSize = true;
			this.rbSan.Checked = true;
			this.rbSan.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbSan.Location = new System.Drawing.Point(3, 16);
			this.rbSan.Name = "rbSan";
			this.rbSan.Size = new System.Drawing.Size(280, 17);
			this.rbSan.TabIndex = 0;
			this.rbSan.TabStop = true;
			this.rbSan.Text = "San";
			this.rbSan.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.combPriority);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(0, 435);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(286, 50);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Priority";
			// 
			// combPriority
			// 
			this.combPriority.Dock = System.Windows.Forms.DockStyle.Top;
			this.combPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combPriority.FormattingEnabled = true;
			this.combPriority.Items.AddRange(new object[] {
            "Idle",
            "Below normal",
            "Normal",
            "Above normal",
            "High"});
			this.combPriority.Location = new System.Drawing.Point(3, 16);
			this.combPriority.Name = "combPriority";
			this.combPriority.Size = new System.Drawing.Size(280, 21);
			this.combPriority.TabIndex = 49;
			this.combPriority.SelectedIndexChanged += new System.EventHandler(this.cbPriority_SelectedIndexChanged);
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(286, 548);
			this.Controls.Add(this.butOk);
			this.Controls.Add(this.butDefault);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.gbNotation);
			this.Controls.Add(this.gbInterface);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.gbTournament);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.gbGame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormOptions";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.Shown += new System.EventHandler(this.FormOptions_Shown);
			this.gbInterface.ResumeLayout(false);
			this.gbInterface.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
			this.gbGame.ResumeLayout(false);
			this.gbGame.PerformLayout();
			this.gbTournament.ResumeLayout(false);
			this.gbTournament.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourP)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourE)).EndInit();
			this.gbNotation.ResumeLayout(false);
			this.gbNotation.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button butDefault;
		private System.Windows.Forms.GroupBox gbInterface;
		private System.Windows.Forms.Button butColor;
		public System.Windows.Forms.CheckBox cbShowPonder;
		private System.Windows.Forms.Button butOk;
		private System.Windows.Forms.GroupBox gbGame;
		public System.Windows.Forms.CheckBox cbGameAutoElo;
		public System.Windows.Forms.CheckBox cbAttack;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.NumericUpDown nudSpeed;
		private System.Windows.Forms.GroupBox gbTournament;
		private System.Windows.Forms.Label labTourP;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.NumericUpDown nudTourP;
		public System.Windows.Forms.CheckBox cbArrow;
		public System.Windows.Forms.CheckBox cbTips;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox combModeTime;
		private System.Windows.Forms.ComboBox combModeStandard;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label labTourE;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.NumericUpDown nudTourE;
		private System.Windows.Forms.GroupBox gbNotation;
		private System.Windows.Forms.RadioButton rbUci;
		public System.Windows.Forms.RadioButton rbSan;
		public System.Windows.Forms.CheckBox cbRotateBoard;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox combPriority;
	}
}