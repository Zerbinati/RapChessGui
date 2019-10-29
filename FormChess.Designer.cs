namespace RapChessGui
{
	partial class FormChess
	{
		/// <summary>
		/// Wymagana zmienna projektanta.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Wyczyść wszystkie używane zasoby.
		/// </summary>
		/// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Kod generowany przez Projektanta formularzy systemu Windows

		/// <summary>
		/// Metoda wymagana do obsługi projektanta — nie należy modyfikować
		/// jej zawartości w edytorze kodu.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChess));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pgnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToClipboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.loadFromClipboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panMenu = new System.Windows.Forms.Panel();
			this.labMode = new System.Windows.Forms.Label();
			this.labBack = new System.Windows.Forms.Label();
			this.labBook = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.labTakenT = new System.Windows.Forms.Label();
			this.labNpsT = new System.Windows.Forms.Label();
			this.labDepthT = new System.Windows.Forms.Label();
			this.labScoreT = new System.Windows.Forms.Label();
			this.labTimeT = new System.Windows.Forms.Label();
			this.labNameT = new System.Windows.Forms.Label();
			this.panTop = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageGame = new System.Windows.Forms.TabPage();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.butStop = new System.Windows.Forms.Button();
			this.bStart = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.labEloComputer = new System.Windows.Forms.Label();
			this.labEngine = new System.Windows.Forms.Label();
			this.cbCommand = new System.Windows.Forms.ComboBox();
			this.cbComputer = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labEloHuman = new System.Windows.Forms.Label();
			this.cbColor = new System.Windows.Forms.ComboBox();
			this.tabPageMatch = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.labMatch24 = new System.Windows.Forms.Label();
			this.labMatch23 = new System.Windows.Forms.Label();
			this.labMatch22 = new System.Windows.Forms.Label();
			this.labMatch21 = new System.Windows.Forms.Label();
			this.labMatch20 = new System.Windows.Forms.Label();
			this.labMatch14 = new System.Windows.Forms.Label();
			this.labMatch13 = new System.Windows.Forms.Label();
			this.labMatch12 = new System.Windows.Forms.Label();
			this.labMatch11 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.labMatch10 = new System.Windows.Forms.Label();
			this.labMatchGames = new System.Windows.Forms.Label();
			this.bStartMatch = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cbPlayer2 = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cbPlayer1 = new System.Windows.Forms.ComboBox();
			this.tabPageTournament = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.butStartTournament = new System.Windows.Forms.Button();
			this.tabPageTraining = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.labGames = new System.Windows.Forms.Label();
			this.butTraining = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.nudTeacher = new System.Windows.Forms.NumericUpDown();
			this.label18 = new System.Windows.Forms.Label();
			this.cbBookList = new System.Windows.Forms.ComboBox();
			this.labTrainTime = new System.Windows.Forms.Label();
			this.comboBoxTeacher = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.nudTrained = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxTrained = new System.Windows.Forms.ComboBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.labTakenB = new System.Windows.Forms.Label();
			this.labNpsB = new System.Windows.Forms.Label();
			this.labDepthB = new System.Windows.Forms.Label();
			this.labScoreB = new System.Windows.Forms.Label();
			this.labTimeB = new System.Windows.Forms.Label();
			this.labNameB = new System.Windows.Forms.Label();
			this.panBottom = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labLast = new System.Windows.Forms.Label();
			this.labMove = new System.Windows.Forms.Label();
			this.timerStart = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1.SuspendLayout();
			this.panMenu.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageGame.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPageMatch.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPageTournament.SuspendLayout();
			this.tabPageTraining.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTeacher)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTrained)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.backToolStripMenuItem,
            this.fenToolStripMenuItem,
            this.pgnToolStripMenuItem,
            this.playersToolStripMenuItem,
            this.bookToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.logToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 2);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(409, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.newGameToolStripMenuItem.Text = "New Game";
			this.newGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameToolStripMenuItem_Click);
			// 
			// backToolStripMenuItem
			// 
			this.backToolStripMenuItem.Name = "backToolStripMenuItem";
			this.backToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.backToolStripMenuItem.Text = "Back";
			this.backToolStripMenuItem.Click += new System.EventHandler(this.BackToolStripMenuItem_Click);
			// 
			// fenToolStripMenuItem
			// 
			this.fenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToClipboardToolStripMenuItem,
            this.loadFromClipboardToolStripMenuItem});
			this.fenToolStripMenuItem.Name = "fenToolStripMenuItem";
			this.fenToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
			this.fenToolStripMenuItem.Text = "Fen";
			// 
			// saveToClipboardToolStripMenuItem
			// 
			this.saveToClipboardToolStripMenuItem.Name = "saveToClipboardToolStripMenuItem";
			this.saveToClipboardToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.saveToClipboardToolStripMenuItem.Text = "Save to clipboard";
			this.saveToClipboardToolStripMenuItem.Click += new System.EventHandler(this.saveToClipboardToolStripMenuItem_Click);
			// 
			// loadFromClipboardToolStripMenuItem
			// 
			this.loadFromClipboardToolStripMenuItem.Name = "loadFromClipboardToolStripMenuItem";
			this.loadFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.loadFromClipboardToolStripMenuItem.Text = "Load from clipboard";
			this.loadFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.loadFromClipboardToolStripMenuItem_Click);
			// 
			// pgnToolStripMenuItem
			// 
			this.pgnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToClipboardToolStripMenuItem1,
            this.loadFromClipboardToolStripMenuItem1});
			this.pgnToolStripMenuItem.Name = "pgnToolStripMenuItem";
			this.pgnToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.pgnToolStripMenuItem.Text = "Pgn";
			// 
			// saveToClipboardToolStripMenuItem1
			// 
			this.saveToClipboardToolStripMenuItem1.Name = "saveToClipboardToolStripMenuItem1";
			this.saveToClipboardToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.saveToClipboardToolStripMenuItem1.Text = "Save to clipboard";
			this.saveToClipboardToolStripMenuItem1.Click += new System.EventHandler(this.saveToClipboardToolStripMenuItem1_Click);
			// 
			// loadFromClipboardToolStripMenuItem1
			// 
			this.loadFromClipboardToolStripMenuItem1.Name = "loadFromClipboardToolStripMenuItem1";
			this.loadFromClipboardToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.loadFromClipboardToolStripMenuItem1.Text = "Load from clipboard";
			this.loadFromClipboardToolStripMenuItem1.Click += new System.EventHandler(this.loadFromClipboardToolStripMenuItem1_Click);
			// 
			// playersToolStripMenuItem
			// 
			this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
			this.playersToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.playersToolStripMenuItem.Text = "Players";
			this.playersToolStripMenuItem.Click += new System.EventHandler(this.PlayersToolStripMenuItem_Click);
			// 
			// bookToolStripMenuItem
			// 
			this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
			this.bookToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.bookToolStripMenuItem.Text = "Book";
			this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
			// 
			// logToolStripMenuItem
			// 
			this.logToolStripMenuItem.Name = "logToolStripMenuItem";
			this.logToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.logToolStripMenuItem.Text = "Log";
			this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
			// 
			// panMenu
			// 
			this.panMenu.BackColor = System.Drawing.SystemColors.Control;
			this.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panMenu.Controls.Add(this.labMode);
			this.panMenu.Controls.Add(this.labBack);
			this.panMenu.Controls.Add(this.labBook);
			this.panMenu.Controls.Add(this.menuStrip1);
			this.panMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.panMenu.Location = new System.Drawing.Point(0, 0);
			this.panMenu.Name = "panMenu";
			this.panMenu.Size = new System.Drawing.Size(909, 26);
			this.panMenu.TabIndex = 26;
			// 
			// labMode
			// 
			this.labMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.labMode.Location = new System.Drawing.Point(665, 0);
			this.labMode.Name = "labMode";
			this.labMode.Size = new System.Drawing.Size(80, 22);
			this.labMode.TabIndex = 4;
			this.labMode.Text = "Game";
			this.labMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labBack
			// 
			this.labBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBack.Dock = System.Windows.Forms.DockStyle.Right;
			this.labBack.Location = new System.Drawing.Point(745, 0);
			this.labBack.Name = "labBack";
			this.labBack.Size = new System.Drawing.Size(80, 22);
			this.labBack.TabIndex = 3;
			this.labBack.Text = "Back 0";
			this.labBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labBook
			// 
			this.labBook.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBook.Dock = System.Windows.Forms.DockStyle.Right;
			this.labBook.Location = new System.Drawing.Point(825, 0);
			this.labBook.Name = "labBook";
			this.labBook.Size = new System.Drawing.Size(80, 22);
			this.labBook.TabIndex = 2;
			this.labBook.Text = "Book 0";
			this.labBook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Silver;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.labTakenT);
			this.panel2.Controls.Add(this.labNpsT);
			this.panel2.Controls.Add(this.labDepthT);
			this.panel2.Controls.Add(this.labScoreT);
			this.panel2.Controls.Add(this.labTimeT);
			this.panel2.Controls.Add(this.labNameT);
			this.panel2.Controls.Add(this.panTop);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 26);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(909, 30);
			this.panel2.TabIndex = 7;
			// 
			// labTakenT
			// 
			this.labTakenT.BackColor = System.Drawing.Color.DarkGray;
			this.labTakenT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTakenT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labTakenT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTakenT.ForeColor = System.Drawing.Color.Black;
			this.labTakenT.Location = new System.Drawing.Point(626, 0);
			this.labTakenT.Name = "labTakenT";
			this.labTakenT.Size = new System.Drawing.Size(279, 26);
			this.labTakenT.TabIndex = 8;
			this.labTakenT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labNpsT
			// 
			this.labNpsT.BackColor = System.Drawing.Color.LightGray;
			this.labNpsT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNpsT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNpsT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNpsT.ForeColor = System.Drawing.Color.Black;
			this.labNpsT.Location = new System.Drawing.Point(506, 0);
			this.labNpsT.Name = "labNpsT";
			this.labNpsT.Size = new System.Drawing.Size(120, 26);
			this.labNpsT.TabIndex = 7;
			this.labNpsT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labDepthT
			// 
			this.labDepthT.BackColor = System.Drawing.Color.LightGray;
			this.labDepthT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labDepthT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labDepthT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labDepthT.ForeColor = System.Drawing.Color.Black;
			this.labDepthT.Location = new System.Drawing.Point(386, 0);
			this.labDepthT.Name = "labDepthT";
			this.labDepthT.Size = new System.Drawing.Size(120, 26);
			this.labDepthT.TabIndex = 6;
			this.labDepthT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labScoreT
			// 
			this.labScoreT.BackColor = System.Drawing.Color.LightGray;
			this.labScoreT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labScoreT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labScoreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labScoreT.ForeColor = System.Drawing.Color.Black;
			this.labScoreT.Location = new System.Drawing.Point(266, 0);
			this.labScoreT.Name = "labScoreT";
			this.labScoreT.Size = new System.Drawing.Size(120, 26);
			this.labScoreT.TabIndex = 5;
			this.labScoreT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labTimeT
			// 
			this.labTimeT.BackColor = System.Drawing.Color.LightGray;
			this.labTimeT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTimeT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labTimeT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTimeT.ForeColor = System.Drawing.Color.Black;
			this.labTimeT.Location = new System.Drawing.Point(146, 0);
			this.labTimeT.Name = "labTimeT";
			this.labTimeT.Size = new System.Drawing.Size(120, 26);
			this.labTimeT.TabIndex = 3;
			this.labTimeT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labNameT
			// 
			this.labNameT.BackColor = System.Drawing.Color.LightGray;
			this.labNameT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNameT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNameT.ForeColor = System.Drawing.Color.Black;
			this.labNameT.Location = new System.Drawing.Point(26, 0);
			this.labNameT.Name = "labNameT";
			this.labNameT.Size = new System.Drawing.Size(120, 26);
			this.labNameT.TabIndex = 2;
			this.labNameT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panTop
			// 
			this.panTop.BackColor = System.Drawing.Color.Silver;
			this.panTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panTop.Dock = System.Windows.Forms.DockStyle.Left;
			this.panTop.Location = new System.Drawing.Point(0, 0);
			this.panTop.Name = "panTop";
			this.panTop.Size = new System.Drawing.Size(26, 26);
			this.panTop.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.tabControl1);
			this.panel4.Controls.Add(this.pictureBox1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 56);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(909, 576);
			this.panel4.TabIndex = 9;
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPageGame);
			this.tabControl1.Controls.Add(this.tabPageMatch);
			this.tabControl1.Controls.Add(this.tabPageTournament);
			this.tabControl1.Controls.Add(this.tabPageTraining);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(576, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(333, 576);
			this.tabControl1.TabIndex = 9;
			// 
			// tabPageGame
			// 
			this.tabPageGame.Controls.Add(this.richTextBox1);
			this.tabPageGame.Controls.Add(this.butStop);
			this.tabPageGame.Controls.Add(this.bStart);
			this.tabPageGame.Controls.Add(this.groupBox2);
			this.tabPageGame.Controls.Add(this.groupBox1);
			this.tabPageGame.Location = new System.Drawing.Point(4, 25);
			this.tabPageGame.Name = "tabPageGame";
			this.tabPageGame.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGame.Size = new System.Drawing.Size(325, 547);
			this.tabPageGame.TabIndex = 0;
			this.tabPageGame.Text = "Game";
			this.tabPageGame.UseVisualStyleBackColor = true;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.richTextBox1.Location = new System.Drawing.Point(3, 221);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(319, 323);
			this.richTextBox1.TabIndex = 22;
			this.richTextBox1.Text = "";
			// 
			// butStop
			// 
			this.butStop.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStop.Location = new System.Drawing.Point(3, 192);
			this.butStop.Name = "butStop";
			this.butStop.Size = new System.Drawing.Size(319, 23);
			this.butStop.TabIndex = 21;
			this.butStop.Text = "Stop calculating";
			this.butStop.UseVisualStyleBackColor = true;
			this.butStop.Click += new System.EventHandler(this.ButStop_Click);
			// 
			// bStart
			// 
			this.bStart.Dock = System.Windows.Forms.DockStyle.Top;
			this.bStart.Location = new System.Drawing.Point(3, 169);
			this.bStart.Name = "bStart";
			this.bStart.Size = new System.Drawing.Size(319, 23);
			this.bStart.TabIndex = 20;
			this.bStart.Text = "Start";
			this.bStart.UseVisualStyleBackColor = true;
			this.bStart.Click += new System.EventHandler(this.ButStart_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.labEloComputer);
			this.groupBox2.Controls.Add(this.labEngine);
			this.groupBox2.Controls.Add(this.cbCommand);
			this.groupBox2.Controls.Add(this.cbComputer);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(3, 67);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(319, 102);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Computer";
			// 
			// labEloComputer
			// 
			this.labEloComputer.Dock = System.Windows.Forms.DockStyle.Top;
			this.labEloComputer.Location = new System.Drawing.Point(3, 79);
			this.labEloComputer.Name = "labEloComputer";
			this.labEloComputer.Size = new System.Drawing.Size(313, 21);
			this.labEloComputer.TabIndex = 46;
			this.labEloComputer.Text = "Elo 0";
			this.labEloComputer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labEngine
			// 
			this.labEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.labEngine.Location = new System.Drawing.Point(3, 58);
			this.labEngine.Name = "labEngine";
			this.labEngine.Size = new System.Drawing.Size(313, 21);
			this.labEngine.TabIndex = 45;
			this.labEngine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbCommand
			// 
			this.cbCommand.AutoCompleteCustomSource.AddRange(new string[] {
            "mvetime 1000",
            "depth 3"});
			this.cbCommand.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbCommand.FormattingEnabled = true;
			this.cbCommand.Items.AddRange(new object[] {
            "movetime 1000",
            "depth 3",
            "nodes 100000",
            "infinite"});
			this.cbCommand.Location = new System.Drawing.Point(3, 37);
			this.cbCommand.Name = "cbCommand";
			this.cbCommand.Size = new System.Drawing.Size(313, 21);
			this.cbCommand.TabIndex = 43;
			// 
			// cbComputer
			// 
			this.cbComputer.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbComputer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbComputer.FormattingEnabled = true;
			this.cbComputer.Location = new System.Drawing.Point(3, 16);
			this.cbComputer.Name = "cbComputer";
			this.cbComputer.Size = new System.Drawing.Size(313, 21);
			this.cbComputer.Sorted = true;
			this.cbComputer.TabIndex = 1;
			this.cbComputer.TextChanged += new System.EventHandler(this.cbComputer_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labEloHuman);
			this.groupBox1.Controls.Add(this.cbColor);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(319, 64);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Human";
			// 
			// labEloHuman
			// 
			this.labEloHuman.Dock = System.Windows.Forms.DockStyle.Top;
			this.labEloHuman.Location = new System.Drawing.Point(3, 37);
			this.labEloHuman.Name = "labEloHuman";
			this.labEloHuman.Size = new System.Drawing.Size(313, 21);
			this.labEloHuman.TabIndex = 29;
			this.labEloHuman.Text = "Elo 0";
			this.labEloHuman.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbColor
			// 
			this.cbColor.AutoCompleteCustomSource.AddRange(new string[] {
            "White",
            "Black"});
			this.cbColor.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbColor.Items.AddRange(new object[] {
            "Auto",
            "White",
            "Black"});
			this.cbColor.Location = new System.Drawing.Point(3, 16);
			this.cbColor.Name = "cbColor";
			this.cbColor.Size = new System.Drawing.Size(313, 21);
			this.cbColor.TabIndex = 2;
			// 
			// tabPageMatch
			// 
			this.tabPageMatch.Controls.Add(this.tableLayoutPanel2);
			this.tabPageMatch.Controls.Add(this.labMatchGames);
			this.tabPageMatch.Controls.Add(this.bStartMatch);
			this.tabPageMatch.Controls.Add(this.groupBox6);
			this.tabPageMatch.Controls.Add(this.groupBox5);
			this.tabPageMatch.Location = new System.Drawing.Point(4, 25);
			this.tabPageMatch.Name = "tabPageMatch";
			this.tabPageMatch.Size = new System.Drawing.Size(325, 547);
			this.tabPageMatch.TabIndex = 2;
			this.tabPageMatch.Text = "Match";
			this.tabPageMatch.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel2.ColumnCount = 5;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel2.Controls.Add(this.labMatch24, 4, 2);
			this.tableLayoutPanel2.Controls.Add(this.labMatch23, 3, 2);
			this.tableLayoutPanel2.Controls.Add(this.labMatch22, 2, 2);
			this.tableLayoutPanel2.Controls.Add(this.labMatch21, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.labMatch20, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.labMatch14, 4, 1);
			this.tableLayoutPanel2.Controls.Add(this.labMatch13, 3, 1);
			this.tableLayoutPanel2.Controls.Add(this.labMatch12, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.labMatch11, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.label26, 4, 0);
			this.tableLayoutPanel2.Controls.Add(this.label27, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.label28, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.label29, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.label30, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.labMatch10, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 141);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(325, 100);
			this.tableLayoutPanel2.TabIndex = 26;
			// 
			// labMatch24
			// 
			this.labMatch24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch24.Location = new System.Drawing.Point(273, 67);
			this.labMatch24.Name = "labMatch24";
			this.labMatch24.Size = new System.Drawing.Size(48, 32);
			this.labMatch24.TabIndex = 14;
			this.labMatch24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch23
			// 
			this.labMatch23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch23.Location = new System.Drawing.Point(219, 67);
			this.labMatch23.Name = "labMatch23";
			this.labMatch23.Size = new System.Drawing.Size(47, 32);
			this.labMatch23.TabIndex = 13;
			this.labMatch23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch22
			// 
			this.labMatch22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch22.Location = new System.Drawing.Point(165, 67);
			this.labMatch22.Name = "labMatch22";
			this.labMatch22.Size = new System.Drawing.Size(47, 32);
			this.labMatch22.TabIndex = 12;
			this.labMatch22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch21
			// 
			this.labMatch21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch21.Location = new System.Drawing.Point(111, 67);
			this.labMatch21.Name = "labMatch21";
			this.labMatch21.Size = new System.Drawing.Size(47, 32);
			this.labMatch21.TabIndex = 11;
			this.labMatch21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch20
			// 
			this.labMatch20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch20.Location = new System.Drawing.Point(4, 67);
			this.labMatch20.Name = "labMatch20";
			this.labMatch20.Size = new System.Drawing.Size(100, 32);
			this.labMatch20.TabIndex = 10;
			this.labMatch20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch14
			// 
			this.labMatch14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch14.Location = new System.Drawing.Point(273, 34);
			this.labMatch14.Name = "labMatch14";
			this.labMatch14.Size = new System.Drawing.Size(48, 32);
			this.labMatch14.TabIndex = 9;
			this.labMatch14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch13
			// 
			this.labMatch13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch13.Location = new System.Drawing.Point(219, 34);
			this.labMatch13.Name = "labMatch13";
			this.labMatch13.Size = new System.Drawing.Size(47, 32);
			this.labMatch13.TabIndex = 8;
			this.labMatch13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch12
			// 
			this.labMatch12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch12.Location = new System.Drawing.Point(165, 34);
			this.labMatch12.Name = "labMatch12";
			this.labMatch12.Size = new System.Drawing.Size(47, 32);
			this.labMatch12.TabIndex = 7;
			this.labMatch12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch11
			// 
			this.labMatch11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch11.Location = new System.Drawing.Point(111, 34);
			this.labMatch11.Name = "labMatch11";
			this.labMatch11.Size = new System.Drawing.Size(47, 32);
			this.labMatch11.TabIndex = 6;
			this.labMatch11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label26.Location = new System.Drawing.Point(273, 1);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(48, 32);
			this.label26.TabIndex = 4;
			this.label26.Text = "Result";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label27
			// 
			this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label27.Location = new System.Drawing.Point(219, 1);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(47, 32);
			this.label27.TabIndex = 3;
			this.label27.Text = "Draw";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label28
			// 
			this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label28.Location = new System.Drawing.Point(165, 1);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(47, 32);
			this.label28.TabIndex = 2;
			this.label28.Text = "Loose";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label29
			// 
			this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label29.Location = new System.Drawing.Point(111, 1);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(47, 32);
			this.label29.TabIndex = 1;
			this.label29.Text = "Win";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label30
			// 
			this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label30.Location = new System.Drawing.Point(4, 1);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(100, 32);
			this.label30.TabIndex = 0;
			this.label30.Text = "Player";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch10
			// 
			this.labMatch10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch10.Location = new System.Drawing.Point(4, 34);
			this.labMatch10.Name = "labMatch10";
			this.labMatch10.Size = new System.Drawing.Size(100, 32);
			this.labMatch10.TabIndex = 5;
			this.labMatch10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatchGames
			// 
			this.labMatchGames.Dock = System.Windows.Forms.DockStyle.Top;
			this.labMatchGames.Location = new System.Drawing.Point(0, 117);
			this.labMatchGames.Name = "labMatchGames";
			this.labMatchGames.Size = new System.Drawing.Size(325, 24);
			this.labMatchGames.TabIndex = 23;
			this.labMatchGames.Text = "Games 0";
			this.labMatchGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// bStartMatch
			// 
			this.bStartMatch.Dock = System.Windows.Forms.DockStyle.Top;
			this.bStartMatch.Location = new System.Drawing.Point(0, 94);
			this.bStartMatch.Name = "bStartMatch";
			this.bStartMatch.Size = new System.Drawing.Size(325, 23);
			this.bStartMatch.TabIndex = 22;
			this.bStartMatch.Text = "Start";
			this.bStartMatch.UseVisualStyleBackColor = true;
			this.bStartMatch.Click += new System.EventHandler(this.bStartMatch_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cbPlayer2);
			this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox6.Location = new System.Drawing.Point(0, 47);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(325, 47);
			this.groupBox6.TabIndex = 20;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Player 2";
			// 
			// cbPlayer2
			// 
			this.cbPlayer2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbPlayer2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPlayer2.Location = new System.Drawing.Point(3, 16);
			this.cbPlayer2.Name = "cbPlayer2";
			this.cbPlayer2.Size = new System.Drawing.Size(319, 21);
			this.cbPlayer2.Sorted = true;
			this.cbPlayer2.TabIndex = 2;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cbPlayer1);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(0, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(325, 47);
			this.groupBox5.TabIndex = 19;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Player 1";
			// 
			// cbPlayer1
			// 
			this.cbPlayer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbPlayer1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPlayer1.Location = new System.Drawing.Point(3, 16);
			this.cbPlayer1.Name = "cbPlayer1";
			this.cbPlayer1.Size = new System.Drawing.Size(319, 21);
			this.cbPlayer1.Sorted = true;
			this.cbPlayer1.TabIndex = 2;
			// 
			// tabPageTournament
			// 
			this.tabPageTournament.Controls.Add(this.listView1);
			this.tabPageTournament.Controls.Add(this.butStartTournament);
			this.tabPageTournament.Location = new System.Drawing.Point(4, 25);
			this.tabPageTournament.Name = "tabPageTournament";
			this.tabPageTournament.Size = new System.Drawing.Size(325, 547);
			this.tabPageTournament.TabIndex = 3;
			this.tabPageTournament.Text = "Tournament";
			this.tabPageTournament.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 23);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(325, 524);
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 23;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Engine";
			this.columnHeader1.Width = 240;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Elo";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 80;
			// 
			// butStartTournament
			// 
			this.butStartTournament.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStartTournament.Location = new System.Drawing.Point(0, 0);
			this.butStartTournament.Name = "butStartTournament";
			this.butStartTournament.Size = new System.Drawing.Size(325, 23);
			this.butStartTournament.TabIndex = 21;
			this.butStartTournament.Text = "Start";
			this.butStartTournament.UseVisualStyleBackColor = true;
			this.butStartTournament.Click += new System.EventHandler(this.butStartTournament_Click);
			// 
			// tabPageTraining
			// 
			this.tabPageTraining.Controls.Add(this.tableLayoutPanel1);
			this.tabPageTraining.Controls.Add(this.labGames);
			this.tabPageTraining.Controls.Add(this.butTraining);
			this.tabPageTraining.Controls.Add(this.groupBox4);
			this.tabPageTraining.Controls.Add(this.groupBox3);
			this.tabPageTraining.Location = new System.Drawing.Point(4, 25);
			this.tabPageTraining.Name = "tabPageTraining";
			this.tabPageTraining.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTraining.Size = new System.Drawing.Size(325, 547);
			this.tabPageTraining.TabIndex = 1;
			this.tabPageTraining.Text = "Training";
			this.tabPageTraining.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tableLayoutPanel1.Controls.Add(this.label15, 4, 2);
			this.tableLayoutPanel1.Controls.Add(this.label14, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.label13, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.label12, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label11, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label10, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.label9, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label7, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 262);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(319, 100);
			this.tableLayoutPanel1.TabIndex = 25;
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.Location = new System.Drawing.Point(268, 67);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(47, 32);
			this.label15.TabIndex = 14;
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.Location = new System.Drawing.Point(215, 67);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(46, 32);
			this.label14.TabIndex = 13;
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.Location = new System.Drawing.Point(162, 67);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(46, 32);
			this.label13.TabIndex = 12;
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.Location = new System.Drawing.Point(109, 67);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(46, 32);
			this.label12.TabIndex = 11;
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.Location = new System.Drawing.Point(4, 67);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(98, 32);
			this.label11.TabIndex = 10;
			this.label11.Text = "Teacher";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.Location = new System.Drawing.Point(268, 34);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(47, 32);
			this.label10.TabIndex = 9;
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.Location = new System.Drawing.Point(215, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(46, 32);
			this.label9.TabIndex = 8;
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(162, 34);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(46, 32);
			this.label8.TabIndex = 7;
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point(109, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 32);
			this.label7.TabIndex = 6;
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(268, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 32);
			this.label5.TabIndex = 4;
			this.label5.Text = "Result";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(215, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 32);
			this.label4.TabIndex = 3;
			this.label4.Text = "Draw";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(162, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 32);
			this.label3.TabIndex = 2;
			this.label3.Text = "Loose";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(109, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 32);
			this.label2.TabIndex = 1;
			this.label2.Text = "Win";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(4, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(98, 32);
			this.label6.TabIndex = 0;
			this.label6.Text = "Player";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label16.Location = new System.Drawing.Point(4, 34);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(98, 32);
			this.label16.TabIndex = 5;
			this.label16.Text = "Trained";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labGames
			// 
			this.labGames.Dock = System.Windows.Forms.DockStyle.Top;
			this.labGames.Location = new System.Drawing.Point(3, 238);
			this.labGames.Name = "labGames";
			this.labGames.Size = new System.Drawing.Size(319, 24);
			this.labGames.TabIndex = 22;
			this.labGames.Text = "Games 0";
			this.labGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butTraining
			// 
			this.butTraining.Dock = System.Windows.Forms.DockStyle.Top;
			this.butTraining.Location = new System.Drawing.Point(3, 215);
			this.butTraining.Name = "butTraining";
			this.butTraining.Size = new System.Drawing.Size(319, 23);
			this.butTraining.TabIndex = 21;
			this.butTraining.Text = "Start";
			this.butTraining.UseVisualStyleBackColor = true;
			this.butTraining.Click += new System.EventHandler(this.ButTraining_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.nudTeacher);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.cbBookList);
			this.groupBox4.Controls.Add(this.labTrainTime);
			this.groupBox4.Controls.Add(this.comboBoxTeacher);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new System.Drawing.Point(3, 88);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(319, 127);
			this.groupBox4.TabIndex = 20;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Teacher";
			// 
			// nudTeacher
			// 
			this.nudTeacher.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTeacher.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudTeacher.Location = new System.Drawing.Point(3, 100);
			this.nudTeacher.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nudTeacher.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTeacher.Name = "nudTeacher";
			this.nudTeacher.Size = new System.Drawing.Size(313, 20);
			this.nudTeacher.TabIndex = 28;
			this.nudTeacher.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTeacher.ThousandsSeparator = true;
			this.nudTeacher.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// label18
			// 
			this.label18.Dock = System.Windows.Forms.DockStyle.Top;
			this.label18.Location = new System.Drawing.Point(3, 79);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(313, 21);
			this.label18.TabIndex = 27;
			this.label18.Text = "Time";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbBookList
			// 
			this.cbBookList.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBookList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBookList.FormattingEnabled = true;
			this.cbBookList.Location = new System.Drawing.Point(3, 58);
			this.cbBookList.Name = "cbBookList";
			this.cbBookList.Size = new System.Drawing.Size(313, 21);
			this.cbBookList.Sorted = true;
			this.cbBookList.TabIndex = 26;
			// 
			// labTrainTime
			// 
			this.labTrainTime.Dock = System.Windows.Forms.DockStyle.Top;
			this.labTrainTime.Location = new System.Drawing.Point(3, 37);
			this.labTrainTime.Name = "labTrainTime";
			this.labTrainTime.Size = new System.Drawing.Size(313, 21);
			this.labTrainTime.TabIndex = 24;
			this.labTrainTime.Text = "Book";
			this.labTrainTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxTeacher
			// 
			this.comboBoxTeacher.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBoxTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTeacher.Location = new System.Drawing.Point(3, 16);
			this.comboBoxTeacher.Name = "comboBoxTeacher";
			this.comboBoxTeacher.Size = new System.Drawing.Size(313, 21);
			this.comboBoxTeacher.Sorted = true;
			this.comboBoxTeacher.TabIndex = 2;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.nudTrained);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.comboBoxTrained);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(3, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(319, 85);
			this.groupBox3.TabIndex = 19;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Trained";
			// 
			// nudTrained
			// 
			this.nudTrained.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTrained.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.nudTrained.Location = new System.Drawing.Point(3, 58);
			this.nudTrained.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nudTrained.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTrained.Name = "nudTrained";
			this.nudTrained.Size = new System.Drawing.Size(313, 20);
			this.nudTrained.TabIndex = 27;
			this.nudTrained.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTrained.ThousandsSeparator = true;
			this.nudTrained.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(3, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(313, 21);
			this.label1.TabIndex = 26;
			this.label1.Text = "Time";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxTrained
			// 
			this.comboBoxTrained.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBoxTrained.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTrained.Location = new System.Drawing.Point(3, 16);
			this.comboBoxTrained.Name = "comboBoxTrained";
			this.comboBoxTrained.Size = new System.Drawing.Size(313, 21);
			this.comboBoxTrained.Sorted = true;
			this.comboBoxTrained.TabIndex = 2;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.ErrorImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(576, 576);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Silver;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.labTakenB);
			this.panel3.Controls.Add(this.labNpsB);
			this.panel3.Controls.Add(this.labDepthB);
			this.panel3.Controls.Add(this.labScoreB);
			this.panel3.Controls.Add(this.labTimeB);
			this.panel3.Controls.Add(this.labNameB);
			this.panel3.Controls.Add(this.panBottom);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 632);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(909, 30);
			this.panel3.TabIndex = 10;
			// 
			// labTakenB
			// 
			this.labTakenB.BackColor = System.Drawing.Color.DarkGray;
			this.labTakenB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTakenB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labTakenB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTakenB.ForeColor = System.Drawing.Color.Black;
			this.labTakenB.Location = new System.Drawing.Point(626, 0);
			this.labTakenB.Name = "labTakenB";
			this.labTakenB.Size = new System.Drawing.Size(279, 26);
			this.labTakenB.TabIndex = 8;
			this.labTakenB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labNpsB
			// 
			this.labNpsB.BackColor = System.Drawing.Color.LightGray;
			this.labNpsB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNpsB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNpsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNpsB.ForeColor = System.Drawing.Color.Black;
			this.labNpsB.Location = new System.Drawing.Point(506, 0);
			this.labNpsB.Name = "labNpsB";
			this.labNpsB.Size = new System.Drawing.Size(120, 26);
			this.labNpsB.TabIndex = 7;
			this.labNpsB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labDepthB
			// 
			this.labDepthB.BackColor = System.Drawing.Color.LightGray;
			this.labDepthB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labDepthB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labDepthB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labDepthB.ForeColor = System.Drawing.Color.Black;
			this.labDepthB.Location = new System.Drawing.Point(386, 0);
			this.labDepthB.Name = "labDepthB";
			this.labDepthB.Size = new System.Drawing.Size(120, 26);
			this.labDepthB.TabIndex = 6;
			this.labDepthB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labScoreB
			// 
			this.labScoreB.BackColor = System.Drawing.Color.LightGray;
			this.labScoreB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labScoreB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labScoreB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labScoreB.ForeColor = System.Drawing.Color.Black;
			this.labScoreB.Location = new System.Drawing.Point(266, 0);
			this.labScoreB.Name = "labScoreB";
			this.labScoreB.Size = new System.Drawing.Size(120, 26);
			this.labScoreB.TabIndex = 5;
			this.labScoreB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labTimeB
			// 
			this.labTimeB.BackColor = System.Drawing.Color.LightGray;
			this.labTimeB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTimeB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labTimeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTimeB.ForeColor = System.Drawing.Color.Black;
			this.labTimeB.Location = new System.Drawing.Point(146, 0);
			this.labTimeB.Name = "labTimeB";
			this.labTimeB.Size = new System.Drawing.Size(120, 26);
			this.labTimeB.TabIndex = 4;
			this.labTimeB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labNameB
			// 
			this.labNameB.BackColor = System.Drawing.Color.LightGray;
			this.labNameB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNameB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNameB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNameB.ForeColor = System.Drawing.Color.Black;
			this.labNameB.Location = new System.Drawing.Point(26, 0);
			this.labNameB.Name = "labNameB";
			this.labNameB.Size = new System.Drawing.Size(120, 26);
			this.labNameB.TabIndex = 3;
			this.labNameB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panBottom
			// 
			this.panBottom.BackColor = System.Drawing.Color.Silver;
			this.panBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panBottom.Dock = System.Windows.Forms.DockStyle.Left;
			this.panBottom.Location = new System.Drawing.Point(0, 0);
			this.panBottom.Name = "panBottom";
			this.panBottom.Size = new System.Drawing.Size(26, 26);
			this.panBottom.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.labLast);
			this.panel1.Controls.Add(this.labMove);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.ForeColor = System.Drawing.Color.Gainsboro;
			this.panel1.Location = new System.Drawing.Point(0, 662);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(909, 36);
			this.panel1.TabIndex = 11;
			// 
			// labLast
			// 
			this.labLast.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labLast.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labLast.ForeColor = System.Drawing.Color.Gainsboro;
			this.labLast.Location = new System.Drawing.Point(137, 0);
			this.labLast.Name = "labLast";
			this.labLast.Size = new System.Drawing.Size(768, 32);
			this.labLast.TabIndex = 2;
			this.labLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labMove
			// 
			this.labMove.BackColor = System.Drawing.Color.Black;
			this.labMove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMove.Dock = System.Windows.Forms.DockStyle.Left;
			this.labMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMove.ForeColor = System.Drawing.Color.Gainsboro;
			this.labMove.Location = new System.Drawing.Point(0, 0);
			this.labMove.Name = "labMove";
			this.labMove.Size = new System.Drawing.Size(137, 32);
			this.labMove.TabIndex = 1;
			this.labMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timerStart
			// 
			this.timerStart.Interval = 6000;
			this.timerStart.Tick += new System.EventHandler(this.TimerStart_Tick);
			// 
			// FormChess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(909, 698);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "FormChess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RapChessGui";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChess_FormClosed);
			this.Load += new System.EventHandler(this.FormChess_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panMenu.ResumeLayout(false);
			this.panMenu.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPageGame.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPageMatch.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.tabPageTournament.ResumeLayout(false);
			this.tabPageTraining.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTeacher)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTrained)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
		private System.Windows.Forms.Panel panMenu;
  		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label labLast;
		private System.Windows.Forms.Label labMove;
		private System.Windows.Forms.Panel panTop;
		private System.Windows.Forms.Panel panBottom;
		private System.Windows.Forms.Label labNameT;
		private System.Windows.Forms.Label labNameB;
		private System.Windows.Forms.Label labTimeT;
		private System.Windows.Forms.Label labTimeB;
		private System.Windows.Forms.Label labScoreT;
		private System.Windows.Forms.Label labScoreB;
		private System.Windows.Forms.Label labTakenT;
		private System.Windows.Forms.Label labNpsT;
		private System.Windows.Forms.Label labDepthT;
		private System.Windows.Forms.Label labTakenB;
		private System.Windows.Forms.Label labNpsB;
		private System.Windows.Forms.Label labDepthB;
		private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageGame;
		private System.Windows.Forms.TabPage tabPageTraining;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button butStop;
		private System.Windows.Forms.Button bStart;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbComputer;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbColor;
		private System.Windows.Forms.Button butTraining;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox comboBoxTeacher;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox comboBoxTrained;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.Timer timerStart;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label labGames;
		private System.Windows.Forms.ToolStripMenuItem fenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToClipboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadFromClipboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
		private System.Windows.Forms.TabPage tabPageMatch;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label labMatch24;
		private System.Windows.Forms.Label labMatch23;
		private System.Windows.Forms.Label labMatch22;
		private System.Windows.Forms.Label labMatch21;
		private System.Windows.Forms.Label labMatch20;
		private System.Windows.Forms.Label labMatch14;
		private System.Windows.Forms.Label labMatch13;
		private System.Windows.Forms.Label labMatch12;
		private System.Windows.Forms.Label labMatch11;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label labMatch10;
		private System.Windows.Forms.Label labMatchGames;
		private System.Windows.Forms.Button bStartMatch;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.ComboBox cbPlayer2;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ComboBox cbPlayer1;
		private System.Windows.Forms.NumericUpDown nudTrained;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Label labBook;
		public System.Windows.Forms.Label labBack;
		private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pgnToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToClipboardToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem loadFromClipboardToolStripMenuItem1;
		private System.Windows.Forms.NumericUpDown nudTeacher;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox cbBookList;
		private System.Windows.Forms.Label labTrainTime;
		private System.Windows.Forms.Label labEloHuman;
		private System.Windows.Forms.ComboBox cbCommand;
		private System.Windows.Forms.Label labEloComputer;
		private System.Windows.Forms.Label labEngine;
		private System.Windows.Forms.TabPage tabPageTournament;
		private System.Windows.Forms.Button butStartTournament;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		public System.Windows.Forms.Label labMode;
	}
}

