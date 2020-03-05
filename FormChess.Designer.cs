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
			this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pgnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToClipboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.loadFromClipboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.booksToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.enginesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panMenu = new System.Windows.Forms.Panel();
			this.labFPS = new System.Windows.Forms.Label();
			this.panelT1 = new System.Windows.Forms.Panel();
			this.labTakenT = new System.Windows.Forms.Label();
			this.labMaterialT = new System.Windows.Forms.Label();
			this.labProtocolT = new System.Windows.Forms.Label();
			this.labEloT = new System.Windows.Forms.Label();
			this.labTimeT = new System.Windows.Forms.Label();
			this.labNameT = new System.Windows.Forms.Label();
			this.panTop = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageGame = new System.Windows.Forms.TabPage();
			this.lvMoves = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.butStop = new System.Windows.Forms.Button();
			this.butContinueGame = new System.Windows.Forms.Button();
			this.butNewGame = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.labEngine = new System.Windows.Forms.Label();
			this.cbCommand = new System.Windows.Forms.ComboBox();
			this.cbComputer = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labAutoElo = new System.Windows.Forms.Label();
			this.labBack = new System.Windows.Forms.Label();
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
			this.butContinueMatch = new System.Windows.Forms.Button();
			this.butNewMatch = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.tbCommand2 = new System.Windows.Forms.TextBox();
			this.cbBook2 = new System.Windows.Forms.ComboBox();
			this.cbValue2 = new System.Windows.Forms.ComboBox();
			this.cbMode2 = new System.Windows.Forms.ComboBox();
			this.cbEngine2 = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.tbCommand1 = new System.Windows.Forms.TextBox();
			this.cbBook1 = new System.Windows.Forms.ComboBox();
			this.cbValue1 = new System.Windows.Forms.ComboBox();
			this.cbMode1 = new System.Windows.Forms.ComboBox();
			this.cbEngine1 = new System.Windows.Forms.ComboBox();
			this.tabPageTournament = new System.Windows.Forms.TabPage();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lPlayer = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
			this.cbTeacherBook = new System.Windows.Forms.ComboBox();
			this.cbTeacherMode = new System.Windows.Forms.ComboBox();
			this.cbTeacherEngine = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.nudTrained = new System.Windows.Forms.NumericUpDown();
			this.cbTrainedBook = new System.Windows.Forms.ComboBox();
			this.cbTrainedMode = new System.Windows.Forms.ComboBox();
			this.cbTrainedEngine = new System.Windows.Forms.ComboBox();
			this.tabPageEdit = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.clbCastling = new System.Windows.Forms.CheckedListBox();
			this.gbToMove = new System.Windows.Forms.GroupBox();
			this.rbBlack = new System.Windows.Forms.RadioButton();
			this.rbWhite = new System.Windows.Forms.RadioButton();
			this.butDefault = new System.Windows.Forms.Button();
			this.butClearBoard = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panelB1 = new System.Windows.Forms.Panel();
			this.labTakenB = new System.Windows.Forms.Label();
			this.labMaterialB = new System.Windows.Forms.Label();
			this.labProtocolB = new System.Windows.Forms.Label();
			this.labEloB = new System.Windows.Forms.Label();
			this.labTimeB = new System.Windows.Forms.Label();
			this.labNameB = new System.Windows.Forms.Label();
			this.panBottom = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labLast = new System.Windows.Forms.Label();
			this.labMove = new System.Windows.Forms.Label();
			this.timerStart = new System.Windows.Forms.Timer(this.components);
			this.panelB2 = new System.Windows.Forms.Panel();
			this.labPonderB = new System.Windows.Forms.Label();
			this.labBookB = new System.Windows.Forms.Label();
			this.labNpsB = new System.Windows.Forms.Label();
			this.labNodesB = new System.Windows.Forms.Label();
			this.labDepthB = new System.Windows.Forms.Label();
			this.labScoreB = new System.Windows.Forms.Label();
			this.panelT2 = new System.Windows.Forms.Panel();
			this.labPonderT = new System.Windows.Forms.Label();
			this.labBookT = new System.Windows.Forms.Label();
			this.labNpsT = new System.Windows.Forms.Label();
			this.labNodesT = new System.Windows.Forms.Label();
			this.labDepthT = new System.Windows.Forms.Label();
			this.labScoreT = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.panMenu.SuspendLayout();
			this.panelT1.SuspendLayout();
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
			this.tabPageEdit.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.gbToMove.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panelB1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panelB2.SuspendLayout();
			this.panelT2.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.fenToolStripMenuItem,
            this.pgnToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.logToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 2);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(377, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// newGameToolStripMenuItem
			// 
			this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
			this.newGameToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
			this.newGameToolStripMenuItem.Text = "New game";
			this.newGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameToolStripMenuItem_Click);
			// 
			// moveToolStripMenuItem
			// 
			this.moveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.forwardToolStripMenuItem});
			this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
			this.moveToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.moveToolStripMenuItem.Text = "Move";
			// 
			// backToolStripMenuItem
			// 
			this.backToolStripMenuItem.Name = "backToolStripMenuItem";
			this.backToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.backToolStripMenuItem.Text = "Back";
			this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click_1);
			// 
			// forwardToolStripMenuItem
			// 
			this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
			this.forwardToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.forwardToolStripMenuItem.Text = "Make";
			this.forwardToolStripMenuItem.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
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
			this.saveToClipboardToolStripMenuItem1.Click += new System.EventHandler(this.SaveToClipboardToolStripMenuItem1_Click);
			// 
			// loadFromClipboardToolStripMenuItem1
			// 
			this.loadFromClipboardToolStripMenuItem1.Name = "loadFromClipboardToolStripMenuItem1";
			this.loadFromClipboardToolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
			this.loadFromClipboardToolStripMenuItem1.Text = "Load from clipboard";
			this.loadFromClipboardToolStripMenuItem1.Click += new System.EventHandler(this.loadFromClipboardToolStripMenuItem1_Click);
			// 
			// manageToolStripMenuItem
			// 
			this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.booksToolStripMenuItem1,
            this.enginesToolStripMenuItem,
            this.playersToolStripMenuItem1});
			this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
			this.manageToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.manageToolStripMenuItem.Text = "Manager";
			// 
			// booksToolStripMenuItem1
			// 
			this.booksToolStripMenuItem1.Name = "booksToolStripMenuItem1";
			this.booksToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
			this.booksToolStripMenuItem1.Text = "Books";
			this.booksToolStripMenuItem1.Click += new System.EventHandler(this.booksToolStripMenuItem1_Click);
			// 
			// enginesToolStripMenuItem
			// 
			this.enginesToolStripMenuItem.Name = "enginesToolStripMenuItem";
			this.enginesToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.enginesToolStripMenuItem.Text = "Engines";
			this.enginesToolStripMenuItem.Click += new System.EventHandler(this.enginesToolStripMenuItem_Click);
			// 
			// playersToolStripMenuItem1
			// 
			this.playersToolStripMenuItem1.Name = "playersToolStripMenuItem1";
			this.playersToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
			this.playersToolStripMenuItem1.Text = "Players";
			this.playersToolStripMenuItem1.Click += new System.EventHandler(this.playersToolStripMenuItem1_Click);
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
			this.panMenu.Controls.Add(this.labFPS);
			this.panMenu.Controls.Add(this.menuStrip1);
			this.panMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.panMenu.Location = new System.Drawing.Point(0, 0);
			this.panMenu.Name = "panMenu";
			this.panMenu.Size = new System.Drawing.Size(904, 26);
			this.panMenu.TabIndex = 26;
			// 
			// labFPS
			// 
			this.labFPS.Dock = System.Windows.Forms.DockStyle.Right;
			this.labFPS.Location = new System.Drawing.Point(813, 0);
			this.labFPS.Name = "labFPS";
			this.labFPS.Size = new System.Drawing.Size(87, 22);
			this.labFPS.TabIndex = 2;
			this.labFPS.Text = "FPS";
			this.labFPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelT1
			// 
			this.panelT1.BackColor = System.Drawing.Color.Silver;
			this.panelT1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelT1.Controls.Add(this.labTakenT);
			this.panelT1.Controls.Add(this.labMaterialT);
			this.panelT1.Controls.Add(this.labProtocolT);
			this.panelT1.Controls.Add(this.labEloT);
			this.panelT1.Controls.Add(this.labTimeT);
			this.panelT1.Controls.Add(this.labNameT);
			this.panelT1.Controls.Add(this.panTop);
			this.panelT1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelT1.Location = new System.Drawing.Point(0, 26);
			this.panelT1.Name = "panelT1";
			this.panelT1.Size = new System.Drawing.Size(904, 30);
			this.panelT1.TabIndex = 7;
			// 
			// labTakenT
			// 
			this.labTakenT.BackColor = System.Drawing.Color.DarkGray;
			this.labTakenT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTakenT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labTakenT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTakenT.ForeColor = System.Drawing.Color.Black;
			this.labTakenT.Location = new System.Drawing.Point(696, 0);
			this.labTakenT.Name = "labTakenT";
			this.labTakenT.Size = new System.Drawing.Size(204, 26);
			this.labTakenT.TabIndex = 11;
			this.labTakenT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labMaterialT
			// 
			this.labMaterialT.BackColor = System.Drawing.Color.LightGray;
			this.labMaterialT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMaterialT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labMaterialT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMaterialT.ForeColor = System.Drawing.Color.Black;
			this.labMaterialT.Location = new System.Drawing.Point(566, 0);
			this.labMaterialT.Name = "labMaterialT";
			this.labMaterialT.Size = new System.Drawing.Size(130, 26);
			this.labMaterialT.TabIndex = 13;
			this.labMaterialT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labProtocolT
			// 
			this.labProtocolT.BackColor = System.Drawing.Color.LightGray;
			this.labProtocolT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labProtocolT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labProtocolT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labProtocolT.ForeColor = System.Drawing.Color.Black;
			this.labProtocolT.Location = new System.Drawing.Point(436, 0);
			this.labProtocolT.Name = "labProtocolT";
			this.labProtocolT.Size = new System.Drawing.Size(130, 26);
			this.labProtocolT.TabIndex = 10;
			this.labProtocolT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labEloT
			// 
			this.labEloT.BackColor = System.Drawing.Color.LightGray;
			this.labEloT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEloT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labEloT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEloT.ForeColor = System.Drawing.Color.Black;
			this.labEloT.Location = new System.Drawing.Point(306, 0);
			this.labEloT.Name = "labEloT";
			this.labEloT.Size = new System.Drawing.Size(130, 26);
			this.labEloT.TabIndex = 12;
			this.labEloT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labTimeT
			// 
			this.labTimeT.BackColor = System.Drawing.Color.LightGray;
			this.labTimeT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTimeT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labTimeT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTimeT.ForeColor = System.Drawing.Color.Black;
			this.labTimeT.Location = new System.Drawing.Point(176, 0);
			this.labTimeT.Name = "labTimeT";
			this.labTimeT.Size = new System.Drawing.Size(130, 26);
			this.labTimeT.TabIndex = 9;
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
			this.labNameT.Size = new System.Drawing.Size(150, 26);
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
			this.panel4.Location = new System.Drawing.Point(0, 86);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(904, 576);
			this.panel4.TabIndex = 9;
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPageGame);
			this.tabControl1.Controls.Add(this.tabPageMatch);
			this.tabControl1.Controls.Add(this.tabPageTournament);
			this.tabControl1.Controls.Add(this.tabPageTraining);
			this.tabControl1.Controls.Add(this.tabPageEdit);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(576, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(328, 576);
			this.tabControl1.TabIndex = 9;
			this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
			// 
			// tabPageGame
			// 
			this.tabPageGame.Controls.Add(this.lvMoves);
			this.tabPageGame.Controls.Add(this.butStop);
			this.tabPageGame.Controls.Add(this.butContinueGame);
			this.tabPageGame.Controls.Add(this.butNewGame);
			this.tabPageGame.Controls.Add(this.groupBox2);
			this.tabPageGame.Controls.Add(this.groupBox1);
			this.tabPageGame.Location = new System.Drawing.Point(4, 25);
			this.tabPageGame.Name = "tabPageGame";
			this.tabPageGame.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGame.Size = new System.Drawing.Size(320, 547);
			this.tabPageGame.TabIndex = 0;
			this.tabPageGame.Text = "Game";
			this.tabPageGame.UseVisualStyleBackColor = true;
			// 
			// lvMoves
			// 
			this.lvMoves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.lvMoves.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvMoves.FullRowSelect = true;
			this.lvMoves.GridLines = true;
			this.lvMoves.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvMoves.HideSelection = false;
			this.lvMoves.Location = new System.Drawing.Point(3, 237);
			this.lvMoves.MultiSelect = false;
			this.lvMoves.Name = "lvMoves";
			this.lvMoves.ShowGroups = false;
			this.lvMoves.Size = new System.Drawing.Size(314, 307);
			this.lvMoves.TabIndex = 25;
			this.lvMoves.UseCompatibleStateImageBehavior = false;
			this.lvMoves.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Move";
			this.columnHeader3.Width = 50;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "White";
			this.columnHeader4.Width = 100;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Black";
			this.columnHeader5.Width = 100;
			// 
			// butStop
			// 
			this.butStop.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStop.Location = new System.Drawing.Point(3, 214);
			this.butStop.Name = "butStop";
			this.butStop.Size = new System.Drawing.Size(314, 23);
			this.butStop.TabIndex = 24;
			this.butStop.Text = "Stop calculating";
			this.butStop.UseVisualStyleBackColor = true;
			this.butStop.Click += new System.EventHandler(this.ButStop_Click);
			// 
			// butContinueGame
			// 
			this.butContinueGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.butContinueGame.Location = new System.Drawing.Point(3, 191);
			this.butContinueGame.Name = "butContinueGame";
			this.butContinueGame.Size = new System.Drawing.Size(314, 23);
			this.butContinueGame.TabIndex = 23;
			this.butContinueGame.Text = "Continue game";
			this.butContinueGame.UseVisualStyleBackColor = true;
			this.butContinueGame.Click += new System.EventHandler(this.butContinueGame_Click);
			// 
			// butNewGame
			// 
			this.butNewGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.butNewGame.Location = new System.Drawing.Point(3, 168);
			this.butNewGame.Name = "butNewGame";
			this.butNewGame.Size = new System.Drawing.Size(314, 23);
			this.butNewGame.TabIndex = 20;
			this.butNewGame.Text = "New game";
			this.butNewGame.UseVisualStyleBackColor = true;
			this.butNewGame.Click += new System.EventHandler(this.ButStart_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.labEngine);
			this.groupBox2.Controls.Add(this.cbCommand);
			this.groupBox2.Controls.Add(this.cbComputer);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(3, 84);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(314, 84);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Computer";
			// 
			// labEngine
			// 
			this.labEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.labEngine.Location = new System.Drawing.Point(3, 58);
			this.labEngine.Name = "labEngine";
			this.labEngine.Size = new System.Drawing.Size(308, 21);
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
			this.cbCommand.Size = new System.Drawing.Size(308, 21);
			this.cbCommand.TabIndex = 43;
			// 
			// cbComputer
			// 
			this.cbComputer.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbComputer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbComputer.FormattingEnabled = true;
			this.cbComputer.Location = new System.Drawing.Point(3, 16);
			this.cbComputer.Name = "cbComputer";
			this.cbComputer.Size = new System.Drawing.Size(308, 21);
			this.cbComputer.Sorted = true;
			this.cbComputer.TabIndex = 1;
			this.cbComputer.SelectedValueChanged += new System.EventHandler(this.cbComputer_SelectedValueChanged);
			this.cbComputer.TextChanged += new System.EventHandler(this.cbComputer_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labAutoElo);
			this.groupBox1.Controls.Add(this.labBack);
			this.groupBox1.Controls.Add(this.cbColor);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(314, 81);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Human";
			// 
			// labAutoElo
			// 
			this.labAutoElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.labAutoElo.ForeColor = System.Drawing.Color.White;
			this.labAutoElo.Location = new System.Drawing.Point(3, 58);
			this.labAutoElo.Name = "labAutoElo";
			this.labAutoElo.Size = new System.Drawing.Size(308, 21);
			this.labAutoElo.TabIndex = 31;
			this.labAutoElo.Text = "Auto Elo On";
			this.labAutoElo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labBack
			// 
			this.labBack.Dock = System.Windows.Forms.DockStyle.Top;
			this.labBack.Location = new System.Drawing.Point(3, 37);
			this.labBack.Name = "labBack";
			this.labBack.Size = new System.Drawing.Size(308, 21);
			this.labBack.TabIndex = 30;
			this.labBack.Text = "Back 0";
			this.labBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.cbColor.Size = new System.Drawing.Size(308, 21);
			this.cbColor.TabIndex = 2;
			this.cbColor.SelectedValueChanged += new System.EventHandler(this.cbColor_SelectedValueChanged);
			// 
			// tabPageMatch
			// 
			this.tabPageMatch.Controls.Add(this.tableLayoutPanel2);
			this.tabPageMatch.Controls.Add(this.labMatchGames);
			this.tabPageMatch.Controls.Add(this.butContinueMatch);
			this.tabPageMatch.Controls.Add(this.butNewMatch);
			this.tabPageMatch.Controls.Add(this.groupBox6);
			this.tabPageMatch.Controls.Add(this.groupBox5);
			this.tabPageMatch.Location = new System.Drawing.Point(4, 25);
			this.tabPageMatch.Name = "tabPageMatch";
			this.tabPageMatch.Size = new System.Drawing.Size(320, 547);
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
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 326);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(320, 100);
			this.tableLayoutPanel2.TabIndex = 26;
			// 
			// labMatch24
			// 
			this.labMatch24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch24.Location = new System.Drawing.Point(268, 67);
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
			this.labMatch23.Location = new System.Drawing.Point(215, 67);
			this.labMatch23.Name = "labMatch23";
			this.labMatch23.Size = new System.Drawing.Size(46, 32);
			this.labMatch23.TabIndex = 13;
			this.labMatch23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch22
			// 
			this.labMatch22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch22.Location = new System.Drawing.Point(162, 67);
			this.labMatch22.Name = "labMatch22";
			this.labMatch22.Size = new System.Drawing.Size(46, 32);
			this.labMatch22.TabIndex = 12;
			this.labMatch22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch21
			// 
			this.labMatch21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch21.Location = new System.Drawing.Point(109, 67);
			this.labMatch21.Name = "labMatch21";
			this.labMatch21.Size = new System.Drawing.Size(46, 32);
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
			this.labMatch20.Size = new System.Drawing.Size(98, 32);
			this.labMatch20.TabIndex = 10;
			this.labMatch20.Text = "Player 2";
			this.labMatch20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch14
			// 
			this.labMatch14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch14.Location = new System.Drawing.Point(268, 34);
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
			this.labMatch13.Location = new System.Drawing.Point(215, 34);
			this.labMatch13.Name = "labMatch13";
			this.labMatch13.Size = new System.Drawing.Size(46, 32);
			this.labMatch13.TabIndex = 8;
			this.labMatch13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch12
			// 
			this.labMatch12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch12.Location = new System.Drawing.Point(162, 34);
			this.labMatch12.Name = "labMatch12";
			this.labMatch12.Size = new System.Drawing.Size(46, 32);
			this.labMatch12.TabIndex = 7;
			this.labMatch12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch11
			// 
			this.labMatch11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch11.Location = new System.Drawing.Point(109, 34);
			this.labMatch11.Name = "labMatch11";
			this.labMatch11.Size = new System.Drawing.Size(46, 32);
			this.labMatch11.TabIndex = 6;
			this.labMatch11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label26.Location = new System.Drawing.Point(268, 1);
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
			this.label27.Location = new System.Drawing.Point(215, 1);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(46, 32);
			this.label27.TabIndex = 3;
			this.label27.Text = "Draw";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label28
			// 
			this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label28.Location = new System.Drawing.Point(162, 1);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(46, 32);
			this.label28.TabIndex = 2;
			this.label28.Text = "Loose";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label29
			// 
			this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label29.Location = new System.Drawing.Point(109, 1);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(46, 32);
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
			this.label30.Size = new System.Drawing.Size(98, 32);
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
			this.labMatch10.Size = new System.Drawing.Size(98, 32);
			this.labMatch10.TabIndex = 5;
			this.labMatch10.Text = "Player 1";
			this.labMatch10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatchGames
			// 
			this.labMatchGames.Dock = System.Windows.Forms.DockStyle.Top;
			this.labMatchGames.Location = new System.Drawing.Point(0, 302);
			this.labMatchGames.Name = "labMatchGames";
			this.labMatchGames.Size = new System.Drawing.Size(320, 24);
			this.labMatchGames.TabIndex = 23;
			this.labMatchGames.Text = "Games 0";
			this.labMatchGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butContinueMatch
			// 
			this.butContinueMatch.Dock = System.Windows.Forms.DockStyle.Top;
			this.butContinueMatch.Location = new System.Drawing.Point(0, 279);
			this.butContinueMatch.Name = "butContinueMatch";
			this.butContinueMatch.Size = new System.Drawing.Size(320, 23);
			this.butContinueMatch.TabIndex = 27;
			this.butContinueMatch.Text = "Continue match";
			this.butContinueMatch.UseVisualStyleBackColor = true;
			this.butContinueMatch.Click += new System.EventHandler(this.butContinueMatch_Click);
			// 
			// butNewMatch
			// 
			this.butNewMatch.Dock = System.Windows.Forms.DockStyle.Top;
			this.butNewMatch.Location = new System.Drawing.Point(0, 256);
			this.butNewMatch.Name = "butNewMatch";
			this.butNewMatch.Size = new System.Drawing.Size(320, 23);
			this.butNewMatch.TabIndex = 22;
			this.butNewMatch.Text = "New match";
			this.butNewMatch.UseVisualStyleBackColor = true;
			this.butNewMatch.Click += new System.EventHandler(this.bStartMatch_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.tbCommand2);
			this.groupBox6.Controls.Add(this.cbBook2);
			this.groupBox6.Controls.Add(this.cbValue2);
			this.groupBox6.Controls.Add(this.cbMode2);
			this.groupBox6.Controls.Add(this.cbEngine2);
			this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox6.Location = new System.Drawing.Point(0, 128);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(320, 128);
			this.groupBox6.TabIndex = 20;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Player 2";
			// 
			// tbCommand2
			// 
			this.tbCommand2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbCommand2.Location = new System.Drawing.Point(3, 100);
			this.tbCommand2.Name = "tbCommand2";
			this.tbCommand2.Size = new System.Drawing.Size(314, 20);
			this.tbCommand2.TabIndex = 33;
			// 
			// cbBook2
			// 
			this.cbBook2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBook2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBook2.FormattingEnabled = true;
			this.cbBook2.Location = new System.Drawing.Point(3, 79);
			this.cbBook2.Name = "cbBook2";
			this.cbBook2.Size = new System.Drawing.Size(314, 21);
			this.cbBook2.Sorted = true;
			this.cbBook2.TabIndex = 32;
			// 
			// cbValue2
			// 
			this.cbValue2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbValue2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbValue2.FormattingEnabled = true;
			this.cbValue2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.cbValue2.Location = new System.Drawing.Point(3, 58);
			this.cbValue2.Name = "cbValue2";
			this.cbValue2.Size = new System.Drawing.Size(314, 21);
			this.cbValue2.Sorted = true;
			this.cbValue2.TabIndex = 31;
			// 
			// cbMode2
			// 
			this.cbMode2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbMode2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMode2.FormattingEnabled = true;
			this.cbMode2.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Time"});
			this.cbMode2.Location = new System.Drawing.Point(3, 37);
			this.cbMode2.Name = "cbMode2";
			this.cbMode2.Size = new System.Drawing.Size(314, 21);
			this.cbMode2.Sorted = true;
			this.cbMode2.TabIndex = 30;
			// 
			// cbEngine2
			// 
			this.cbEngine2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEngine2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEngine2.FormattingEnabled = true;
			this.cbEngine2.Location = new System.Drawing.Point(3, 16);
			this.cbEngine2.Name = "cbEngine2";
			this.cbEngine2.Size = new System.Drawing.Size(314, 21);
			this.cbEngine2.Sorted = true;
			this.cbEngine2.TabIndex = 29;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.tbCommand1);
			this.groupBox5.Controls.Add(this.cbBook1);
			this.groupBox5.Controls.Add(this.cbValue1);
			this.groupBox5.Controls.Add(this.cbMode1);
			this.groupBox5.Controls.Add(this.cbEngine1);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(0, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(320, 128);
			this.groupBox5.TabIndex = 19;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Player 1";
			// 
			// tbCommand1
			// 
			this.tbCommand1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbCommand1.Location = new System.Drawing.Point(3, 100);
			this.tbCommand1.Name = "tbCommand1";
			this.tbCommand1.Size = new System.Drawing.Size(314, 20);
			this.tbCommand1.TabIndex = 32;
			// 
			// cbBook1
			// 
			this.cbBook1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBook1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBook1.FormattingEnabled = true;
			this.cbBook1.Location = new System.Drawing.Point(3, 79);
			this.cbBook1.Name = "cbBook1";
			this.cbBook1.Size = new System.Drawing.Size(314, 21);
			this.cbBook1.Sorted = true;
			this.cbBook1.TabIndex = 31;
			// 
			// cbValue1
			// 
			this.cbValue1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbValue1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbValue1.FormattingEnabled = true;
			this.cbValue1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.cbValue1.Location = new System.Drawing.Point(3, 58);
			this.cbValue1.Name = "cbValue1";
			this.cbValue1.Size = new System.Drawing.Size(314, 21);
			this.cbValue1.Sorted = true;
			this.cbValue1.TabIndex = 30;
			// 
			// cbMode1
			// 
			this.cbMode1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbMode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMode1.FormattingEnabled = true;
			this.cbMode1.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Time"});
			this.cbMode1.Location = new System.Drawing.Point(3, 37);
			this.cbMode1.Name = "cbMode1";
			this.cbMode1.Size = new System.Drawing.Size(314, 21);
			this.cbMode1.Sorted = true;
			this.cbMode1.TabIndex = 29;
			// 
			// cbEngine1
			// 
			this.cbEngine1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEngine1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEngine1.FormattingEnabled = true;
			this.cbEngine1.Location = new System.Drawing.Point(3, 16);
			this.cbEngine1.Name = "cbEngine1";
			this.cbEngine1.Size = new System.Drawing.Size(314, 21);
			this.cbEngine1.Sorted = true;
			this.cbEngine1.TabIndex = 28;
			// 
			// tabPageTournament
			// 
			this.tabPageTournament.Controls.Add(this.listView2);
			this.tabPageTournament.Controls.Add(this.lPlayer);
			this.tabPageTournament.Controls.Add(this.listView1);
			this.tabPageTournament.Controls.Add(this.butStartTournament);
			this.tabPageTournament.Location = new System.Drawing.Point(4, 25);
			this.tabPageTournament.Name = "tabPageTournament";
			this.tabPageTournament.Size = new System.Drawing.Size(320, 547);
			this.tabPageTournament.TabIndex = 3;
			this.tabPageTournament.Text = "Tournament";
			this.tabPageTournament.UseVisualStyleBackColor = true;
			// 
			// listView2
			// 
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10});
			this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView2.FullRowSelect = true;
			this.listView2.GridLines = true;
			this.listView2.HideSelection = false;
			this.listView2.Location = new System.Drawing.Point(0, 373);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.ShowGroups = false;
			this.listView2.Size = new System.Drawing.Size(320, 174);
			this.listView2.TabIndex = 25;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Tag = "";
			this.columnHeader7.Text = "Player";
			this.columnHeader7.Width = 150;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Elo";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Results";
			this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader10.Width = 80;
			// 
			// lPlayer
			// 
			this.lPlayer.Dock = System.Windows.Forms.DockStyle.Top;
			this.lPlayer.Location = new System.Drawing.Point(0, 360);
			this.lPlayer.Name = "lPlayer";
			this.lPlayer.Size = new System.Drawing.Size(320, 13);
			this.lPlayer.TabIndex = 24;
			this.lPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 23);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.ShowGroups = false;
			this.listView1.Size = new System.Drawing.Size(320, 337);
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 23;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Tag = "";
			this.columnHeader1.Text = "Player";
			this.columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Tag = "";
			this.columnHeader2.Text = "Elo";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 80;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Changes";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// butStartTournament
			// 
			this.butStartTournament.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStartTournament.Location = new System.Drawing.Point(0, 0);
			this.butStartTournament.Name = "butStartTournament";
			this.butStartTournament.Size = new System.Drawing.Size(320, 23);
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
			this.tabPageTraining.Size = new System.Drawing.Size(320, 547);
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 260);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(314, 100);
			this.tableLayoutPanel1.TabIndex = 25;
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.Location = new System.Drawing.Point(263, 67);
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
			this.label14.Location = new System.Drawing.Point(211, 67);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(45, 32);
			this.label14.TabIndex = 13;
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.Location = new System.Drawing.Point(159, 67);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(45, 32);
			this.label13.TabIndex = 12;
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.Location = new System.Drawing.Point(107, 67);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(45, 32);
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
			this.label11.Size = new System.Drawing.Size(96, 32);
			this.label11.TabIndex = 10;
			this.label11.Text = "Teacher";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.Location = new System.Drawing.Point(263, 34);
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
			this.label9.Location = new System.Drawing.Point(211, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 32);
			this.label9.TabIndex = 8;
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(159, 34);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(45, 32);
			this.label8.TabIndex = 7;
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point(107, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(45, 32);
			this.label7.TabIndex = 6;
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(263, 1);
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
			this.label4.Location = new System.Drawing.Point(211, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 32);
			this.label4.TabIndex = 3;
			this.label4.Text = "Draw";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(159, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 32);
			this.label3.TabIndex = 2;
			this.label3.Text = "Loose";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(107, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 32);
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
			this.label6.Size = new System.Drawing.Size(96, 32);
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
			this.label16.Size = new System.Drawing.Size(96, 32);
			this.label16.TabIndex = 5;
			this.label16.Text = "Trained";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labGames
			// 
			this.labGames.Dock = System.Windows.Forms.DockStyle.Top;
			this.labGames.Location = new System.Drawing.Point(3, 236);
			this.labGames.Name = "labGames";
			this.labGames.Size = new System.Drawing.Size(314, 24);
			this.labGames.TabIndex = 22;
			this.labGames.Text = "Games 0";
			this.labGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butTraining
			// 
			this.butTraining.Dock = System.Windows.Forms.DockStyle.Top;
			this.butTraining.Location = new System.Drawing.Point(3, 213);
			this.butTraining.Name = "butTraining";
			this.butTraining.Size = new System.Drawing.Size(314, 23);
			this.butTraining.TabIndex = 21;
			this.butTraining.Text = "Start";
			this.butTraining.UseVisualStyleBackColor = true;
			this.butTraining.Click += new System.EventHandler(this.ButTraining_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.nudTeacher);
			this.groupBox4.Controls.Add(this.cbTeacherBook);
			this.groupBox4.Controls.Add(this.cbTeacherMode);
			this.groupBox4.Controls.Add(this.cbTeacherEngine);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new System.Drawing.Point(3, 108);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(314, 105);
			this.groupBox4.TabIndex = 20;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Teacher";
			// 
			// nudTeacher
			// 
			this.nudTeacher.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTeacher.Location = new System.Drawing.Point(3, 79);
			this.nudTeacher.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTeacher.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTeacher.Name = "nudTeacher";
			this.nudTeacher.Size = new System.Drawing.Size(308, 20);
			this.nudTeacher.TabIndex = 28;
			this.nudTeacher.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTeacher.ThousandsSeparator = true;
			this.nudTeacher.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbTeacherBook
			// 
			this.cbTeacherBook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTeacherBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeacherBook.FormattingEnabled = true;
			this.cbTeacherBook.Location = new System.Drawing.Point(3, 58);
			this.cbTeacherBook.Name = "cbTeacherBook";
			this.cbTeacherBook.Size = new System.Drawing.Size(308, 21);
			this.cbTeacherBook.Sorted = true;
			this.cbTeacherBook.TabIndex = 26;
			// 
			// cbTeacherMode
			// 
			this.cbTeacherMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTeacherMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeacherMode.FormattingEnabled = true;
			this.cbTeacherMode.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Time"});
			this.cbTeacherMode.Location = new System.Drawing.Point(3, 37);
			this.cbTeacherMode.Name = "cbTeacherMode";
			this.cbTeacherMode.Size = new System.Drawing.Size(308, 21);
			this.cbTeacherMode.Sorted = true;
			this.cbTeacherMode.TabIndex = 30;
			// 
			// cbTeacherEngine
			// 
			this.cbTeacherEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTeacherEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeacherEngine.Location = new System.Drawing.Point(3, 16);
			this.cbTeacherEngine.Name = "cbTeacherEngine";
			this.cbTeacherEngine.Size = new System.Drawing.Size(308, 21);
			this.cbTeacherEngine.Sorted = true;
			this.cbTeacherEngine.TabIndex = 2;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.nudTrained);
			this.groupBox3.Controls.Add(this.cbTrainedBook);
			this.groupBox3.Controls.Add(this.cbTrainedMode);
			this.groupBox3.Controls.Add(this.cbTrainedEngine);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(3, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(314, 105);
			this.groupBox3.TabIndex = 19;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Trained";
			// 
			// nudTrained
			// 
			this.nudTrained.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTrained.Location = new System.Drawing.Point(3, 79);
			this.nudTrained.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudTrained.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTrained.Name = "nudTrained";
			this.nudTrained.Size = new System.Drawing.Size(308, 20);
			this.nudTrained.TabIndex = 27;
			this.nudTrained.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTrained.ThousandsSeparator = true;
			this.nudTrained.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbTrainedBook
			// 
			this.cbTrainedBook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTrainedBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrainedBook.FormattingEnabled = true;
			this.cbTrainedBook.Location = new System.Drawing.Point(3, 58);
			this.cbTrainedBook.Name = "cbTrainedBook";
			this.cbTrainedBook.Size = new System.Drawing.Size(308, 21);
			this.cbTrainedBook.Sorted = true;
			this.cbTrainedBook.TabIndex = 29;
			// 
			// cbTrainedMode
			// 
			this.cbTrainedMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTrainedMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrainedMode.FormattingEnabled = true;
			this.cbTrainedMode.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Time"});
			this.cbTrainedMode.Location = new System.Drawing.Point(3, 37);
			this.cbTrainedMode.Name = "cbTrainedMode";
			this.cbTrainedMode.Size = new System.Drawing.Size(308, 21);
			this.cbTrainedMode.Sorted = true;
			this.cbTrainedMode.TabIndex = 30;
			// 
			// cbTrainedEngine
			// 
			this.cbTrainedEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTrainedEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrainedEngine.Location = new System.Drawing.Point(3, 16);
			this.cbTrainedEngine.Name = "cbTrainedEngine";
			this.cbTrainedEngine.Size = new System.Drawing.Size(308, 21);
			this.cbTrainedEngine.Sorted = true;
			this.cbTrainedEngine.TabIndex = 2;
			// 
			// tabPageEdit
			// 
			this.tabPageEdit.Controls.Add(this.groupBox7);
			this.tabPageEdit.Controls.Add(this.gbToMove);
			this.tabPageEdit.Controls.Add(this.butDefault);
			this.tabPageEdit.Controls.Add(this.butClearBoard);
			this.tabPageEdit.Location = new System.Drawing.Point(4, 25);
			this.tabPageEdit.Name = "tabPageEdit";
			this.tabPageEdit.Size = new System.Drawing.Size(320, 547);
			this.tabPageEdit.TabIndex = 4;
			this.tabPageEdit.Text = "Edit";
			this.tabPageEdit.UseVisualStyleBackColor = true;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.clbCastling);
			this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox7.Location = new System.Drawing.Point(0, 103);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(320, 84);
			this.groupBox7.TabIndex = 2;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Castling possibilities";
			// 
			// clbCastling
			// 
			this.clbCastling.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clbCastling.FormattingEnabled = true;
			this.clbCastling.Items.AddRange(new object[] {
            "White Short",
            "White Long",
            "Black Short",
            "Black Long"});
			this.clbCastling.Location = new System.Drawing.Point(3, 16);
			this.clbCastling.Name = "clbCastling";
			this.clbCastling.Size = new System.Drawing.Size(314, 65);
			this.clbCastling.TabIndex = 0;
			this.clbCastling.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCastling_ItemCheck);
			// 
			// gbToMove
			// 
			this.gbToMove.Controls.Add(this.rbBlack);
			this.gbToMove.Controls.Add(this.rbWhite);
			this.gbToMove.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbToMove.Location = new System.Drawing.Point(0, 50);
			this.gbToMove.Name = "gbToMove";
			this.gbToMove.Size = new System.Drawing.Size(320, 53);
			this.gbToMove.TabIndex = 1;
			this.gbToMove.TabStop = false;
			this.gbToMove.Text = "To move";
			// 
			// rbBlack
			// 
			this.rbBlack.AutoSize = true;
			this.rbBlack.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbBlack.Location = new System.Drawing.Point(3, 33);
			this.rbBlack.Name = "rbBlack";
			this.rbBlack.Size = new System.Drawing.Size(314, 17);
			this.rbBlack.TabIndex = 1;
			this.rbBlack.Text = "Black";
			this.rbBlack.UseVisualStyleBackColor = true;
			// 
			// rbWhite
			// 
			this.rbWhite.AutoSize = true;
			this.rbWhite.Checked = true;
			this.rbWhite.Dock = System.Windows.Forms.DockStyle.Top;
			this.rbWhite.Location = new System.Drawing.Point(3, 16);
			this.rbWhite.Name = "rbWhite";
			this.rbWhite.Size = new System.Drawing.Size(314, 17);
			this.rbWhite.TabIndex = 0;
			this.rbWhite.TabStop = true;
			this.rbWhite.Text = "White";
			this.rbWhite.UseVisualStyleBackColor = true;
			this.rbWhite.CheckedChanged += new System.EventHandler(this.rbColorChanged);
			// 
			// butDefault
			// 
			this.butDefault.Dock = System.Windows.Forms.DockStyle.Top;
			this.butDefault.Location = new System.Drawing.Point(0, 25);
			this.butDefault.Name = "butDefault";
			this.butDefault.Size = new System.Drawing.Size(320, 25);
			this.butDefault.TabIndex = 3;
			this.butDefault.Text = "Default position";
			this.butDefault.UseVisualStyleBackColor = true;
			this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
			// 
			// butClearBoard
			// 
			this.butClearBoard.Dock = System.Windows.Forms.DockStyle.Top;
			this.butClearBoard.Location = new System.Drawing.Point(0, 0);
			this.butClearBoard.Name = "butClearBoard";
			this.butClearBoard.Size = new System.Drawing.Size(320, 25);
			this.butClearBoard.TabIndex = 0;
			this.butClearBoard.Text = "Clear board";
			this.butClearBoard.UseVisualStyleBackColor = true;
			this.butClearBoard.Click += new System.EventHandler(this.butClearBoard_Click);
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
			// panelB1
			// 
			this.panelB1.BackColor = System.Drawing.Color.Silver;
			this.panelB1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelB1.Controls.Add(this.labTakenB);
			this.panelB1.Controls.Add(this.labMaterialB);
			this.panelB1.Controls.Add(this.labProtocolB);
			this.panelB1.Controls.Add(this.labEloB);
			this.panelB1.Controls.Add(this.labTimeB);
			this.panelB1.Controls.Add(this.labNameB);
			this.panelB1.Controls.Add(this.panBottom);
			this.panelB1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelB1.Location = new System.Drawing.Point(0, 662);
			this.panelB1.Name = "panelB1";
			this.panelB1.Size = new System.Drawing.Size(904, 30);
			this.panelB1.TabIndex = 10;
			// 
			// labTakenB
			// 
			this.labTakenB.BackColor = System.Drawing.Color.DarkGray;
			this.labTakenB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTakenB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labTakenB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTakenB.ForeColor = System.Drawing.Color.Black;
			this.labTakenB.Location = new System.Drawing.Point(696, 0);
			this.labTakenB.Name = "labTakenB";
			this.labTakenB.Size = new System.Drawing.Size(204, 26);
			this.labTakenB.TabIndex = 11;
			this.labTakenB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labMaterialB
			// 
			this.labMaterialB.BackColor = System.Drawing.Color.LightGray;
			this.labMaterialB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMaterialB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labMaterialB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMaterialB.ForeColor = System.Drawing.Color.Black;
			this.labMaterialB.Location = new System.Drawing.Point(566, 0);
			this.labMaterialB.Name = "labMaterialB";
			this.labMaterialB.Size = new System.Drawing.Size(130, 26);
			this.labMaterialB.TabIndex = 13;
			this.labMaterialB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labProtocolB
			// 
			this.labProtocolB.BackColor = System.Drawing.Color.LightGray;
			this.labProtocolB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labProtocolB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labProtocolB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labProtocolB.ForeColor = System.Drawing.Color.Black;
			this.labProtocolB.Location = new System.Drawing.Point(436, 0);
			this.labProtocolB.Name = "labProtocolB";
			this.labProtocolB.Size = new System.Drawing.Size(130, 26);
			this.labProtocolB.TabIndex = 10;
			this.labProtocolB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labEloB
			// 
			this.labEloB.BackColor = System.Drawing.Color.LightGray;
			this.labEloB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEloB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labEloB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEloB.ForeColor = System.Drawing.Color.Black;
			this.labEloB.Location = new System.Drawing.Point(306, 0);
			this.labEloB.Name = "labEloB";
			this.labEloB.Size = new System.Drawing.Size(130, 26);
			this.labEloB.TabIndex = 12;
			this.labEloB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labTimeB
			// 
			this.labTimeB.BackColor = System.Drawing.Color.LightGray;
			this.labTimeB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTimeB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labTimeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTimeB.ForeColor = System.Drawing.Color.Black;
			this.labTimeB.Location = new System.Drawing.Point(176, 0);
			this.labTimeB.Name = "labTimeB";
			this.labTimeB.Size = new System.Drawing.Size(130, 26);
			this.labTimeB.TabIndex = 9;
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
			this.labNameB.Size = new System.Drawing.Size(150, 26);
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
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.ForeColor = System.Drawing.Color.Gainsboro;
			this.panel1.Location = new System.Drawing.Point(0, 723);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(904, 40);
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
			this.labLast.Size = new System.Drawing.Size(763, 36);
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
			this.labMove.Size = new System.Drawing.Size(137, 36);
			this.labMove.TabIndex = 1;
			this.labMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timerStart
			// 
			this.timerStart.Interval = 6000;
			this.timerStart.Tick += new System.EventHandler(this.TimerStart_Tick);
			// 
			// panelB2
			// 
			this.panelB2.BackColor = System.Drawing.Color.DarkGray;
			this.panelB2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelB2.Controls.Add(this.labPonderB);
			this.panelB2.Controls.Add(this.labBookB);
			this.panelB2.Controls.Add(this.labNpsB);
			this.panelB2.Controls.Add(this.labNodesB);
			this.panelB2.Controls.Add(this.labDepthB);
			this.panelB2.Controls.Add(this.labScoreB);
			this.panelB2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelB2.Location = new System.Drawing.Point(0, 692);
			this.panelB2.Name = "panelB2";
			this.panelB2.Size = new System.Drawing.Size(904, 30);
			this.panelB2.TabIndex = 27;
			// 
			// labPonderB
			// 
			this.labPonderB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labPonderB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labPonderB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labPonderB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPonderB.ForeColor = System.Drawing.Color.Black;
			this.labPonderB.Location = new System.Drawing.Point(750, 0);
			this.labPonderB.Name = "labPonderB";
			this.labPonderB.Size = new System.Drawing.Size(150, 26);
			this.labPonderB.TabIndex = 6;
			this.labPonderB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labBookB
			// 
			this.labBookB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labBookB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBookB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labBookB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBookB.ForeColor = System.Drawing.Color.Black;
			this.labBookB.Location = new System.Drawing.Point(600, 0);
			this.labBookB.Name = "labBookB";
			this.labBookB.Size = new System.Drawing.Size(150, 26);
			this.labBookB.TabIndex = 10;
			this.labBookB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labNpsB
			// 
			this.labNpsB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNpsB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNpsB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNpsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNpsB.ForeColor = System.Drawing.Color.Black;
			this.labNpsB.Location = new System.Drawing.Point(450, 0);
			this.labNpsB.Name = "labNpsB";
			this.labNpsB.Size = new System.Drawing.Size(150, 26);
			this.labNpsB.TabIndex = 9;
			this.labNpsB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labNodesB
			// 
			this.labNodesB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNodesB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNodesB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNodesB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNodesB.ForeColor = System.Drawing.Color.Black;
			this.labNodesB.Location = new System.Drawing.Point(300, 0);
			this.labNodesB.Name = "labNodesB";
			this.labNodesB.Size = new System.Drawing.Size(150, 26);
			this.labNodesB.TabIndex = 11;
			this.labNodesB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labDepthB
			// 
			this.labDepthB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labDepthB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labDepthB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labDepthB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labDepthB.ForeColor = System.Drawing.Color.Black;
			this.labDepthB.Location = new System.Drawing.Point(150, 0);
			this.labDepthB.Name = "labDepthB";
			this.labDepthB.Size = new System.Drawing.Size(150, 26);
			this.labDepthB.TabIndex = 8;
			this.labDepthB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labScoreB
			// 
			this.labScoreB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labScoreB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labScoreB.Dock = System.Windows.Forms.DockStyle.Left;
			this.labScoreB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labScoreB.ForeColor = System.Drawing.Color.Black;
			this.labScoreB.Location = new System.Drawing.Point(0, 0);
			this.labScoreB.Name = "labScoreB";
			this.labScoreB.Size = new System.Drawing.Size(150, 26);
			this.labScoreB.TabIndex = 7;
			this.labScoreB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panelT2
			// 
			this.panelT2.BackColor = System.Drawing.Color.DarkGray;
			this.panelT2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelT2.Controls.Add(this.labPonderT);
			this.panelT2.Controls.Add(this.labBookT);
			this.panelT2.Controls.Add(this.labNpsT);
			this.panelT2.Controls.Add(this.labNodesT);
			this.panelT2.Controls.Add(this.labDepthT);
			this.panelT2.Controls.Add(this.labScoreT);
			this.panelT2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelT2.Location = new System.Drawing.Point(0, 56);
			this.panelT2.Name = "panelT2";
			this.panelT2.Size = new System.Drawing.Size(904, 30);
			this.panelT2.TabIndex = 28;
			// 
			// labPonderT
			// 
			this.labPonderT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labPonderT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labPonderT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labPonderT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPonderT.ForeColor = System.Drawing.Color.Black;
			this.labPonderT.Location = new System.Drawing.Point(750, 0);
			this.labPonderT.Name = "labPonderT";
			this.labPonderT.Size = new System.Drawing.Size(150, 26);
			this.labPonderT.TabIndex = 5;
			this.labPonderT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labBookT
			// 
			this.labBookT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labBookT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBookT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labBookT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBookT.ForeColor = System.Drawing.Color.Black;
			this.labBookT.Location = new System.Drawing.Point(600, 0);
			this.labBookT.Name = "labBookT";
			this.labBookT.Size = new System.Drawing.Size(150, 26);
			this.labBookT.TabIndex = 10;
			this.labBookT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labNpsT
			// 
			this.labNpsT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNpsT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNpsT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNpsT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNpsT.ForeColor = System.Drawing.Color.Black;
			this.labNpsT.Location = new System.Drawing.Point(450, 0);
			this.labNpsT.Name = "labNpsT";
			this.labNpsT.Size = new System.Drawing.Size(150, 26);
			this.labNpsT.TabIndex = 8;
			this.labNpsT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labNodesT
			// 
			this.labNodesT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNodesT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNodesT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labNodesT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNodesT.ForeColor = System.Drawing.Color.Black;
			this.labNodesT.Location = new System.Drawing.Point(300, 0);
			this.labNodesT.Name = "labNodesT";
			this.labNodesT.Size = new System.Drawing.Size(150, 26);
			this.labNodesT.TabIndex = 11;
			this.labNodesT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labDepthT
			// 
			this.labDepthT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labDepthT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labDepthT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labDepthT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labDepthT.ForeColor = System.Drawing.Color.Black;
			this.labDepthT.Location = new System.Drawing.Point(150, 0);
			this.labDepthT.Name = "labDepthT";
			this.labDepthT.Size = new System.Drawing.Size(150, 26);
			this.labDepthT.TabIndex = 7;
			this.labDepthT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labScoreT
			// 
			this.labScoreT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labScoreT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labScoreT.Dock = System.Windows.Forms.DockStyle.Left;
			this.labScoreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labScoreT.ForeColor = System.Drawing.Color.Black;
			this.labScoreT.Location = new System.Drawing.Point(0, 0);
			this.labScoreT.Name = "labScoreT";
			this.labScoreT.Size = new System.Drawing.Size(150, 26);
			this.labScoreT.TabIndex = 6;
			this.labScoreT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormChess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(904, 763);
			this.Controls.Add(this.panelB2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panelB1);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panelT2);
			this.Controls.Add(this.panelT1);
			this.Controls.Add(this.panMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "FormChess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RapChessGui";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChess_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panMenu.ResumeLayout(false);
			this.panMenu.PerformLayout();
			this.panelT1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPageGame.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPageMatch.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabPageTournament.ResumeLayout(false);
			this.tabPageTraining.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTeacher)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTrained)).EndInit();
			this.tabPageEdit.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.gbToMove.ResumeLayout(false);
			this.gbToMove.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panelB1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panelB2.ResumeLayout(false);
			this.panelT2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
		private System.Windows.Forms.Panel panMenu;
  		private System.Windows.Forms.Panel panelT1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panelB1;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.Label labLast;
		private System.Windows.Forms.Label labMove;
		private System.Windows.Forms.Panel panTop;
		private System.Windows.Forms.Panel panBottom;
		private System.Windows.Forms.Label labNameT;
		private System.Windows.Forms.Label labNameB;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageGame;
		private System.Windows.Forms.TabPage tabPageTraining;
		private System.Windows.Forms.Button butNewGame;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbComputer;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cbColor;
		private System.Windows.Forms.Button butTraining;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox cbTeacherEngine;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cbTrainedEngine;
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
		private System.Windows.Forms.Button butNewMatch;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown nudTrained;
		private System.Windows.Forms.ToolStripMenuItem pgnToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToClipboardToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem loadFromClipboardToolStripMenuItem1;
		private System.Windows.Forms.NumericUpDown nudTeacher;
		private System.Windows.Forms.ComboBox cbTeacherBook;
		private System.Windows.Forms.ComboBox cbCommand;
		private System.Windows.Forms.Label labEngine;
		private System.Windows.Forms.TabPage tabPageTournament;
		private System.Windows.Forms.Button butStartTournament;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Panel panelB2;
		private System.Windows.Forms.Panel panelT2;
		private System.Windows.Forms.Label labPonderB;
		private System.Windows.Forms.Label labPonderT;
		private System.Windows.Forms.Label labTimeT;
		private System.Windows.Forms.Label labTimeB;
		private System.Windows.Forms.Label labScoreB;
		private System.Windows.Forms.Label labScoreT;
		private System.Windows.Forms.Label labNpsB;
		private System.Windows.Forms.Label labDepthB;
		private System.Windows.Forms.Label labNpsT;
		private System.Windows.Forms.Label labDepthT;
		private System.Windows.Forms.Label labProtocolT;
		private System.Windows.Forms.Label labProtocolB;
		private System.Windows.Forms.Label labBookB;
		private System.Windows.Forms.Label labBookT;
		private System.Windows.Forms.Label labNodesB;
		private System.Windows.Forms.Label labNodesT;
		private System.Windows.Forms.Label labTakenT;
		private System.Windows.Forms.Label labTakenB;
		private System.Windows.Forms.TabPage tabPageEdit;
		private System.Windows.Forms.Button butClearBoard;
		private System.Windows.Forms.GroupBox gbToMove;
		private System.Windows.Forms.RadioButton rbBlack;
		private System.Windows.Forms.RadioButton rbWhite;
		private System.Windows.Forms.Button butStop;
		private System.Windows.Forms.Button butContinueGame;
		private System.Windows.Forms.Label labBack;
		private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
		private System.Windows.Forms.Label labEloT;
		private System.Windows.Forms.Label labEloB;
		private System.Windows.Forms.ListView lvMoves;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Label labFPS;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.CheckedListBox clbCastling;
		private System.Windows.Forms.Label labMaterialT;
		private System.Windows.Forms.Label labMaterialB;
		private System.Windows.Forms.Button butContinueMatch;
		private System.Windows.Forms.Button butDefault;
		private System.Windows.Forms.Label labAutoElo;
		private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem enginesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem1;
		private System.Windows.Forms.TextBox tbCommand1;
		private System.Windows.Forms.ComboBox cbBook1;
		private System.Windows.Forms.ComboBox cbValue1;
		private System.Windows.Forms.ComboBox cbMode1;
		private System.Windows.Forms.ComboBox cbEngine1;
		private System.Windows.Forms.ComboBox cbEngine2;
		private System.Windows.Forms.ComboBox cbMode2;
		private System.Windows.Forms.ComboBox cbValue2;
		private System.Windows.Forms.TextBox tbCommand2;
		private System.Windows.Forms.ComboBox cbBook2;
		private System.Windows.Forms.ComboBox cbTrainedBook;
		private System.Windows.Forms.ComboBox cbTeacherMode;
		private System.Windows.Forms.ComboBox cbTrainedMode;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.Label lPlayer;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
	}
}

