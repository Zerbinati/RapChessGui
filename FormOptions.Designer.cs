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
			this.label1 = new System.Windows.Forms.Label();
			this.nudSpeed = new System.Windows.Forms.NumericUpDown();
			this.cbAttack = new System.Windows.Forms.CheckBox();
			this.cbShowPonder = new System.Windows.Forms.CheckBox();
			this.cbRotateBoard = new System.Windows.Forms.CheckBox();
			this.butColor = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.gbGame = new System.Windows.Forms.GroupBox();
			this.cbGameAutoElo = new System.Windows.Forms.CheckBox();
			this.gbTournament = new System.Windows.Forms.GroupBox();
			this.nudTournament = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.labFill = new System.Windows.Forms.Label();
			this.gbInterface.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
			this.gbGame.SuspendLayout();
			this.gbTournament.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTournament)).BeginInit();
			this.SuspendLayout();
			// 
			// butDefault
			// 
			this.butDefault.Dock = System.Windows.Forms.DockStyle.Top;
			this.butDefault.Location = new System.Drawing.Point(0, 171);
			this.butDefault.Name = "butDefault";
			this.butDefault.Size = new System.Drawing.Size(286, 24);
			this.butDefault.TabIndex = 2;
			this.butDefault.Text = "Default";
			this.butDefault.UseVisualStyleBackColor = true;
			this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
			// 
			// gbInterface
			// 
			this.gbInterface.Controls.Add(this.label1);
			this.gbInterface.Controls.Add(this.nudSpeed);
			this.gbInterface.Controls.Add(this.cbAttack);
			this.gbInterface.Controls.Add(this.cbShowPonder);
			this.gbInterface.Controls.Add(this.cbRotateBoard);
			this.gbInterface.Controls.Add(this.butColor);
			this.gbInterface.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbInterface.Location = new System.Drawing.Point(0, 39);
			this.gbInterface.Name = "gbInterface";
			this.gbInterface.Size = new System.Drawing.Size(286, 132);
			this.gbInterface.TabIndex = 4;
			this.gbInterface.TabStop = false;
			this.gbInterface.Text = "Interface";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(168, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Animation speed";
			// 
			// nudSpeed
			// 
			this.nudSpeed.Location = new System.Drawing.Point(6, 79);
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
			this.nudSpeed.Size = new System.Drawing.Size(156, 20);
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
			this.cbAttack.Location = new System.Drawing.Point(3, 50);
			this.cbAttack.Name = "cbAttack";
			this.cbAttack.Size = new System.Drawing.Size(280, 17);
			this.cbAttack.TabIndex = 7;
			this.cbAttack.Text = "Show attack";
			this.cbAttack.UseVisualStyleBackColor = true;
			// 
			// cbShowPonder
			// 
			this.cbShowPonder.AutoSize = true;
			this.cbShowPonder.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbShowPonder.Location = new System.Drawing.Point(3, 33);
			this.cbShowPonder.Name = "cbShowPonder";
			this.cbShowPonder.Size = new System.Drawing.Size(280, 17);
			this.cbShowPonder.TabIndex = 6;
			this.cbShowPonder.Text = "Show ponder";
			this.cbShowPonder.UseVisualStyleBackColor = true;
			// 
			// cbRotateBoard
			// 
			this.cbRotateBoard.AutoSize = true;
			this.cbRotateBoard.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbRotateBoard.Location = new System.Drawing.Point(3, 16);
			this.cbRotateBoard.Name = "cbRotateBoard";
			this.cbRotateBoard.Size = new System.Drawing.Size(280, 17);
			this.cbRotateBoard.TabIndex = 5;
			this.cbRotateBoard.Text = "Rotate board";
			this.cbRotateBoard.UseVisualStyleBackColor = true;
			this.cbRotateBoard.CheckedChanged += new System.EventHandler(this.CbRotateBoard_CheckedChanged);
			// 
			// butColor
			// 
			this.butColor.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.butColor.Location = new System.Drawing.Point(3, 105);
			this.butColor.Name = "butColor";
			this.butColor.Size = new System.Drawing.Size(280, 24);
			this.butColor.TabIndex = 4;
			this.butColor.Text = "Board color";
			this.butColor.UseVisualStyleBackColor = true;
			this.butColor.Click += new System.EventHandler(this.butColor_Click);
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Dock = System.Windows.Forms.DockStyle.Top;
			this.button1.Location = new System.Drawing.Point(0, 195);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(286, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Ok";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// gbGame
			// 
			this.gbGame.Controls.Add(this.cbGameAutoElo);
			this.gbGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbGame.Location = new System.Drawing.Point(0, 0);
			this.gbGame.Name = "gbGame";
			this.gbGame.Size = new System.Drawing.Size(286, 39);
			this.gbGame.TabIndex = 6;
			this.gbGame.TabStop = false;
			this.gbGame.Text = "Game";
			// 
			// cbGameAutoElo
			// 
			this.cbGameAutoElo.AutoSize = true;
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
			this.gbTournament.Controls.Add(this.labFill);
			this.gbTournament.Controls.Add(this.label2);
			this.gbTournament.Controls.Add(this.nudTournament);
			this.gbTournament.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbTournament.Location = new System.Drawing.Point(0, 219);
			this.gbTournament.Name = "gbTournament";
			this.gbTournament.Size = new System.Drawing.Size(286, 52);
			this.gbTournament.TabIndex = 7;
			this.gbTournament.TabStop = false;
			this.gbTournament.Text = "Tournament";
			// 
			// nudTournament
			// 
			this.nudTournament.Location = new System.Drawing.Point(6, 19);
			this.nudTournament.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudTournament.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudTournament.Name = "nudTournament";
			this.nudTournament.Size = new System.Drawing.Size(156, 20);
			this.nudTournament.TabIndex = 9;
			this.nudTournament.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTournament.ThousandsSeparator = true;
			this.nudTournament.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
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
			// labFill
			// 
			this.labFill.AutoSize = true;
			this.labFill.Location = new System.Drawing.Point(168, 29);
			this.labFill.Name = "labFill";
			this.labFill.Size = new System.Drawing.Size(19, 13);
			this.labFill.TabIndex = 11;
			this.labFill.Text = "Fill";
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(286, 278);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.butDefault);
			this.Controls.Add(this.gbInterface);
this.Controls.Add(this.gbTournament);
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
			((System.ComponentModel.ISupportInitialize)(this.nudTournament)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button butDefault;
		private System.Windows.Forms.GroupBox gbInterface;
		private System.Windows.Forms.Button butColor;
		public System.Windows.Forms.CheckBox cbShowPonder;
		public System.Windows.Forms.CheckBox cbRotateBoard;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox gbGame;
		public System.Windows.Forms.CheckBox cbGameAutoElo;
		public System.Windows.Forms.CheckBox cbAttack;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.NumericUpDown nudSpeed;
		private System.Windows.Forms.GroupBox gbTournament;
		private System.Windows.Forms.Label labFill;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.NumericUpDown nudTournament;
	}
}