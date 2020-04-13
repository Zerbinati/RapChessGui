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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChess));
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageGame = new System.Windows.Forms.TabPage();
			this.butStop = new System.Windows.Forms.Button();
			this.butContinueGame = new System.Windows.Forms.Button();
			this.butNewGame = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.nudValue = new System.Windows.Forms.NumericUpDown();
			this.cbBook = new System.Windows.Forms.ComboBox();
			this.cbMode = new System.Windows.Forms.ComboBox();
			this.cbEngine = new System.Windows.Forms.ComboBox();
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
			this.nudValue2 = new System.Windows.Forms.NumericUpDown();
			this.cbBook2 = new System.Windows.Forms.ComboBox();
			this.cbMode2 = new System.Windows.Forms.ComboBox();
			this.cbEngine2 = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.nudValue1 = new System.Windows.Forms.NumericUpDown();
			this.cbBook1 = new System.Windows.Forms.ComboBox();
			this.cbMode1 = new System.Windows.Forms.ComboBox();
			this.cbEngine1 = new System.Windows.Forms.ComboBox();
			this.tabPageTournament = new System.Windows.Forms.TabPage();
			this.splitContainerTournament = new System.Windows.Forms.SplitContainer();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lPlayer = new System.Windows.Forms.Label();
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
			this.timerStart = new System.Windows.Forms.Timer(this.components);
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
			this.labFPS = new System.Windows.Forms.Label();
			this.panMenu = new System.Windows.Forms.Panel();
			this.labEco = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.labNpsT = new System.Windows.Forms.Label();
			this.labBookT = new System.Windows.Forms.Label();
			this.labPonderT = new System.Windows.Forms.Label();
			this.labScoreT = new System.Windows.Forms.Label();
			this.labDepthT = new System.Windows.Forms.Label();
			this.labNodesT = new System.Windows.Forms.Label();
			this.labNpsB = new System.Windows.Forms.Label();
			this.labBookB = new System.Windows.Forms.Label();
			this.labPonderB = new System.Windows.Forms.Label();
			this.labScoreB = new System.Windows.Forms.Label();
			this.labDepthB = new System.Windows.Forms.Label();
			this.labNodesB = new System.Windows.Forms.Label();
			this.labTimeD = new System.Windows.Forms.Label();
			this.labEloD = new System.Windows.Forms.Label();
			this.labColorD = new System.Windows.Forms.Label();
			this.labNameD = new System.Windows.Forms.Label();
			this.labEloT = new System.Windows.Forms.Label();
			this.labColorT = new System.Windows.Forms.Label();
			this.labNameT = new System.Windows.Forms.Label();
			this.labMovesW = new System.Windows.Forms.Label();
			this.labWhite = new System.Windows.Forms.Label();
			this.labProtocolW = new System.Windows.Forms.Label();
			this.labEloW = new System.Windows.Forms.Label();
			this.labEloB = new System.Windows.Forms.Label();
			this.labProtocolB = new System.Windows.Forms.Label();
			this.labBlack = new System.Windows.Forms.Label();
			this.labMovesB = new System.Windows.Forms.Label();
			this.labTimeT = new System.Windows.Forms.Label();
			this.cbMainMode = new System.Windows.Forms.ComboBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssMove = new System.Windows.Forms.ToolStripStatusLabel();
			this.tssMoves = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainerBoard = new System.Windows.Forms.SplitContainer();
			this.panBoard = new System.Windows.Forms.Panel();
			this.tlpBoardD = new System.Windows.Forms.TableLayoutPanel();
			this.tlpBoardT = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainerMode = new System.Windows.Forms.SplitContainer();
			this.splitContainerChart = new System.Windows.Forms.SplitContainer();
			this.lvMoves = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.tlpEngineT = new System.Windows.Forms.TableLayoutPanel();
			this.tlpEngineB = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainerMoves = new System.Windows.Forms.SplitContainer();
			this.lvMovesW = new System.Windows.Forms.ListView();
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tlpWhite = new System.Windows.Forms.TableLayoutPanel();
			this.lvMovesB = new System.Windows.Forms.ListView();
			this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tlpChartT = new System.Windows.Forms.TableLayoutPanel();
			this.labTakenT = new System.Windows.Forms.Label();
			this.labMaterialT = new System.Windows.Forms.Label();
			this.tlpChartD = new System.Windows.Forms.TableLayoutPanel();
			this.labMaterialD = new System.Windows.Forms.Label();
			this.labTakenD = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabPageGame.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tabPageMatch.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudValue2)).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudValue1)).BeginInit();
			this.tabPageTournament.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTournament)).BeginInit();
			this.splitContainerTournament.Panel1.SuspendLayout();
			this.splitContainerTournament.Panel2.SuspendLayout();
			this.splitContainerTournament.SuspendLayout();
			this.tabPageTraining.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTeacher)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTrained)).BeginInit();
			this.tabPageEdit.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.gbToMove.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.panMenu.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerBoard)).BeginInit();
			this.splitContainerBoard.Panel1.SuspendLayout();
			this.splitContainerBoard.Panel2.SuspendLayout();
			this.splitContainerBoard.SuspendLayout();
			this.tlpBoardD.SuspendLayout();
			this.tlpBoardT.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMode)).BeginInit();
			this.splitContainerMode.Panel1.SuspendLayout();
			this.splitContainerMode.Panel2.SuspendLayout();
			this.splitContainerMode.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerChart)).BeginInit();
			this.splitContainerChart.Panel1.SuspendLayout();
			this.splitContainerChart.Panel2.SuspendLayout();
			this.splitContainerChart.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.tlpEngineT.SuspendLayout();
			this.tlpEngineB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMoves)).BeginInit();
			this.splitContainerMoves.Panel1.SuspendLayout();
			this.splitContainerMoves.Panel2.SuspendLayout();
			this.splitContainerMoves.SuspendLayout();
			this.tlpWhite.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tlpChartT.SuspendLayout();
			this.tlpChartD.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
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
			this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(372, 396);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 9;
			this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
			// 
			// tabPageGame
			// 
			this.tabPageGame.Controls.Add(this.butStop);
			this.tabPageGame.Controls.Add(this.butContinueGame);
			this.tabPageGame.Controls.Add(this.butNewGame);
			this.tabPageGame.Controls.Add(this.groupBox2);
			this.tabPageGame.Controls.Add(this.groupBox1);
			this.tabPageGame.Location = new System.Drawing.Point(4, 5);
			this.tabPageGame.Name = "tabPageGame";
			this.tabPageGame.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGame.Size = new System.Drawing.Size(364, 387);
			this.tabPageGame.TabIndex = 0;
			this.tabPageGame.Text = "Game";
			// 
			// butStop
			// 
			this.butStop.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStop.Location = new System.Drawing.Point(3, 261);
			this.butStop.Name = "butStop";
			this.butStop.Size = new System.Drawing.Size(358, 23);
			this.butStop.TabIndex = 24;
			this.butStop.Text = "Stop calculating";
			this.toolTip1.SetToolTip(this.butStop, "Engine stop calculating and makes a move immediately");
			this.butStop.UseVisualStyleBackColor = true;
			this.butStop.Click += new System.EventHandler(this.ButStop_Click);
			// 
			// butContinueGame
			// 
			this.butContinueGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.butContinueGame.Location = new System.Drawing.Point(3, 238);
			this.butContinueGame.Name = "butContinueGame";
			this.butContinueGame.Size = new System.Drawing.Size(358, 23);
			this.butContinueGame.TabIndex = 23;
			this.butContinueGame.Text = "Continue game";
			this.toolTip1.SetToolTip(this.butContinueGame, "Continue game with current position");
			this.butContinueGame.UseVisualStyleBackColor = true;
			this.butContinueGame.Click += new System.EventHandler(this.butContinueGame_Click);
			// 
			// butNewGame
			// 
			this.butNewGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.butNewGame.Location = new System.Drawing.Point(3, 215);
			this.butNewGame.Name = "butNewGame";
			this.butNewGame.Size = new System.Drawing.Size(358, 23);
			this.butNewGame.TabIndex = 20;
			this.butNewGame.Text = "New game";
			this.toolTip1.SetToolTip(this.butNewGame, "Start new game");
			this.butNewGame.UseVisualStyleBackColor = true;
			this.butNewGame.Click += new System.EventHandler(this.ButStart_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.nudValue);
			this.groupBox2.Controls.Add(this.cbBook);
			this.groupBox2.Controls.Add(this.cbMode);
			this.groupBox2.Controls.Add(this.cbEngine);
			this.groupBox2.Controls.Add(this.cbComputer);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(3, 84);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(358, 131);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Computer";
			// 
			// nudValue
			// 
			this.nudValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudValue.Location = new System.Drawing.Point(3, 100);
			this.nudValue.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.nudValue.Name = "nudValue";
			this.nudValue.Size = new System.Drawing.Size(352, 20);
			this.nudValue.TabIndex = 50;
			this.nudValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudValue.ThousandsSeparator = true;
			this.nudValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudValue.ValueChanged += new System.EventHandler(this.nudValue_ValueChanged);
			// 
			// cbBook
			// 
			this.cbBook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBook.FormattingEnabled = true;
			this.cbBook.Location = new System.Drawing.Point(3, 79);
			this.cbBook.Name = "cbBook";
			this.cbBook.Size = new System.Drawing.Size(352, 21);
			this.cbBook.Sorted = true;
			this.cbBook.TabIndex = 49;
			this.toolTip1.SetToolTip(this.cbBook, "Select engine book");
			// 
			// cbMode
			// 
			this.cbMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMode.FormattingEnabled = true;
			this.cbMode.Items.AddRange(new object[] {
            "Blitz",
            "Depth",
            "Infinite",
            "Nodes",
            "Time"});
			this.cbMode.Location = new System.Drawing.Point(3, 58);
			this.cbMode.Name = "cbMode";
			this.cbMode.Size = new System.Drawing.Size(352, 21);
			this.cbMode.Sorted = true;
			this.cbMode.TabIndex = 47;
			this.toolTip1.SetToolTip(this.cbMode, "Select engine mode");
			this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
			// 
			// cbEngine
			// 
			this.cbEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEngine.FormattingEnabled = true;
			this.cbEngine.Location = new System.Drawing.Point(3, 37);
			this.cbEngine.Name = "cbEngine";
			this.cbEngine.Size = new System.Drawing.Size(352, 21);
			this.cbEngine.Sorted = true;
			this.cbEngine.TabIndex = 46;
			this.toolTip1.SetToolTip(this.cbEngine, "Select engine");
			// 
			// cbComputer
			// 
			this.cbComputer.AccessibleDescription = "";
			this.cbComputer.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbComputer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbComputer.FormattingEnabled = true;
			this.cbComputer.Items.AddRange(new object[] {
            "Auto",
            "Custom",
            "Human"});
			this.cbComputer.Location = new System.Drawing.Point(3, 16);
			this.cbComputer.Name = "cbComputer";
			this.cbComputer.Size = new System.Drawing.Size(352, 21);
			this.cbComputer.Sorted = true;
			this.cbComputer.TabIndex = 1;
			this.toolTip1.SetToolTip(this.cbComputer, "Select human opponent");
			this.cbComputer.SelectedValueChanged += new System.EventHandler(this.cbComputer_SelectedValueChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labAutoElo);
			this.groupBox1.Controls.Add(this.labBack);
			this.groupBox1.Controls.Add(this.cbColor);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(358, 81);
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
			this.labAutoElo.Size = new System.Drawing.Size(352, 21);
			this.labAutoElo.TabIndex = 31;
			this.labAutoElo.Text = "Auto Elo On";
			this.labAutoElo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labBack
			// 
			this.labBack.Dock = System.Windows.Forms.DockStyle.Top;
			this.labBack.Location = new System.Drawing.Point(3, 37);
			this.labBack.Name = "labBack";
			this.labBack.Size = new System.Drawing.Size(352, 21);
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
			this.cbColor.Size = new System.Drawing.Size(352, 21);
			this.cbColor.TabIndex = 2;
			this.toolTip1.SetToolTip(this.cbColor, "Select human color");
			this.cbColor.SelectedIndexChanged += new System.EventHandler(this.cbColor_SelectedIndexChanged);
			// 
			// tabPageMatch
			// 
			this.tabPageMatch.Controls.Add(this.tableLayoutPanel2);
			this.tabPageMatch.Controls.Add(this.labMatchGames);
			this.tabPageMatch.Controls.Add(this.butContinueMatch);
			this.tabPageMatch.Controls.Add(this.butNewMatch);
			this.tabPageMatch.Controls.Add(this.groupBox6);
			this.tabPageMatch.Controls.Add(this.groupBox5);
			this.tabPageMatch.Location = new System.Drawing.Point(4, 5);
			this.tabPageMatch.Name = "tabPageMatch";
			this.tabPageMatch.Size = new System.Drawing.Size(364, 390);
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
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 286);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(364, 100);
			this.tableLayoutPanel2.TabIndex = 26;
			// 
			// labMatch24
			// 
			this.labMatch24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch24.Location = new System.Drawing.Point(304, 67);
			this.labMatch24.Name = "labMatch24";
			this.labMatch24.Size = new System.Drawing.Size(56, 32);
			this.labMatch24.TabIndex = 14;
			this.labMatch24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch23
			// 
			this.labMatch23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch23.Location = new System.Drawing.Point(244, 67);
			this.labMatch23.Name = "labMatch23";
			this.labMatch23.Size = new System.Drawing.Size(53, 32);
			this.labMatch23.TabIndex = 13;
			this.labMatch23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch22
			// 
			this.labMatch22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch22.Location = new System.Drawing.Point(184, 67);
			this.labMatch22.Name = "labMatch22";
			this.labMatch22.Size = new System.Drawing.Size(53, 32);
			this.labMatch22.TabIndex = 12;
			this.labMatch22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch21
			// 
			this.labMatch21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch21.Location = new System.Drawing.Point(124, 67);
			this.labMatch21.Name = "labMatch21";
			this.labMatch21.Size = new System.Drawing.Size(53, 32);
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
			this.labMatch20.Size = new System.Drawing.Size(113, 32);
			this.labMatch20.TabIndex = 10;
			this.labMatch20.Text = "Player 2";
			this.labMatch20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch14
			// 
			this.labMatch14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch14.Location = new System.Drawing.Point(304, 34);
			this.labMatch14.Name = "labMatch14";
			this.labMatch14.Size = new System.Drawing.Size(56, 32);
			this.labMatch14.TabIndex = 9;
			this.labMatch14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch13
			// 
			this.labMatch13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch13.Location = new System.Drawing.Point(244, 34);
			this.labMatch13.Name = "labMatch13";
			this.labMatch13.Size = new System.Drawing.Size(53, 32);
			this.labMatch13.TabIndex = 8;
			this.labMatch13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch12
			// 
			this.labMatch12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch12.Location = new System.Drawing.Point(184, 34);
			this.labMatch12.Name = "labMatch12";
			this.labMatch12.Size = new System.Drawing.Size(53, 32);
			this.labMatch12.TabIndex = 7;
			this.labMatch12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch11
			// 
			this.labMatch11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch11.Location = new System.Drawing.Point(124, 34);
			this.labMatch11.Name = "labMatch11";
			this.labMatch11.Size = new System.Drawing.Size(53, 32);
			this.labMatch11.TabIndex = 6;
			this.labMatch11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label26.Location = new System.Drawing.Point(304, 1);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(56, 32);
			this.label26.TabIndex = 4;
			this.label26.Text = "Result";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label27
			// 
			this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label27.Location = new System.Drawing.Point(244, 1);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(53, 32);
			this.label27.TabIndex = 3;
			this.label27.Text = "Draw";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label28
			// 
			this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label28.Location = new System.Drawing.Point(184, 1);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(53, 32);
			this.label28.TabIndex = 2;
			this.label28.Text = "Loose";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label29
			// 
			this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label29.Location = new System.Drawing.Point(124, 1);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(53, 32);
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
			this.label30.Size = new System.Drawing.Size(113, 32);
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
			this.labMatch10.Size = new System.Drawing.Size(113, 32);
			this.labMatch10.TabIndex = 5;
			this.labMatch10.Text = "Player 1";
			this.labMatch10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatchGames
			// 
			this.labMatchGames.Dock = System.Windows.Forms.DockStyle.Top;
			this.labMatchGames.Location = new System.Drawing.Point(0, 262);
			this.labMatchGames.Name = "labMatchGames";
			this.labMatchGames.Size = new System.Drawing.Size(364, 24);
			this.labMatchGames.TabIndex = 23;
			this.labMatchGames.Text = "Games 0";
			this.labMatchGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butContinueMatch
			// 
			this.butContinueMatch.Dock = System.Windows.Forms.DockStyle.Top;
			this.butContinueMatch.Location = new System.Drawing.Point(0, 239);
			this.butContinueMatch.Name = "butContinueMatch";
			this.butContinueMatch.Size = new System.Drawing.Size(364, 23);
			this.butContinueMatch.TabIndex = 27;
			this.butContinueMatch.Text = "Continue match";
			this.toolTip1.SetToolTip(this.butContinueMatch, "Continue match with old results");
			this.butContinueMatch.UseVisualStyleBackColor = true;
			this.butContinueMatch.Click += new System.EventHandler(this.butContinueMatch_Click);
			// 
			// butNewMatch
			// 
			this.butNewMatch.Dock = System.Windows.Forms.DockStyle.Top;
			this.butNewMatch.Location = new System.Drawing.Point(0, 216);
			this.butNewMatch.Name = "butNewMatch";
			this.butNewMatch.Size = new System.Drawing.Size(364, 23);
			this.butNewMatch.TabIndex = 22;
			this.butNewMatch.Text = "New match";
			this.toolTip1.SetToolTip(this.butNewMatch, "Clear old results and start new match");
			this.butNewMatch.UseVisualStyleBackColor = true;
			this.butNewMatch.Click += new System.EventHandler(this.bStartMatch_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.nudValue2);
			this.groupBox6.Controls.Add(this.cbBook2);
			this.groupBox6.Controls.Add(this.cbMode2);
			this.groupBox6.Controls.Add(this.cbEngine2);
			this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox6.Location = new System.Drawing.Point(0, 108);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(364, 108);
			this.groupBox6.TabIndex = 20;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Player 2";
			// 
			// nudValue2
			// 
			this.nudValue2.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudValue2.Location = new System.Drawing.Point(3, 79);
			this.nudValue2.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.nudValue2.Name = "nudValue2";
			this.nudValue2.Size = new System.Drawing.Size(358, 20);
			this.nudValue2.TabIndex = 51;
			this.nudValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudValue2.ThousandsSeparator = true;
			this.nudValue2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbBook2
			// 
			this.cbBook2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBook2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBook2.FormattingEnabled = true;
			this.cbBook2.Location = new System.Drawing.Point(3, 58);
			this.cbBook2.Name = "cbBook2";
			this.cbBook2.Size = new System.Drawing.Size(358, 21);
			this.cbBook2.Sorted = true;
			this.cbBook2.TabIndex = 32;
			this.toolTip1.SetToolTip(this.cbBook2, "Select engine opening book");
			// 
			// cbMode2
			// 
			this.cbMode2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbMode2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMode2.FormattingEnabled = true;
			this.cbMode2.Items.AddRange(new object[] {
            "Blitz",
            "Depth",
            "Nodes",
            "Time"});
			this.cbMode2.Location = new System.Drawing.Point(3, 37);
			this.cbMode2.Name = "cbMode2";
			this.cbMode2.Size = new System.Drawing.Size(358, 21);
			this.cbMode2.Sorted = true;
			this.cbMode2.TabIndex = 30;
			this.toolTip1.SetToolTip(this.cbMode2, "Select engine mode");
			this.cbMode2.SelectedIndexChanged += new System.EventHandler(this.cbMode2_SelectedIndexChanged);
			// 
			// cbEngine2
			// 
			this.cbEngine2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEngine2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEngine2.FormattingEnabled = true;
			this.cbEngine2.Location = new System.Drawing.Point(3, 16);
			this.cbEngine2.Name = "cbEngine2";
			this.cbEngine2.Size = new System.Drawing.Size(358, 21);
			this.cbEngine2.Sorted = true;
			this.cbEngine2.TabIndex = 29;
			this.toolTip1.SetToolTip(this.cbEngine2, "Select engine");
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.nudValue1);
			this.groupBox5.Controls.Add(this.cbBook1);
			this.groupBox5.Controls.Add(this.cbMode1);
			this.groupBox5.Controls.Add(this.cbEngine1);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(0, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(364, 108);
			this.groupBox5.TabIndex = 19;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Player 1";
			// 
			// nudValue1
			// 
			this.nudValue1.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudValue1.Location = new System.Drawing.Point(3, 79);
			this.nudValue1.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.nudValue1.Name = "nudValue1";
			this.nudValue1.Size = new System.Drawing.Size(358, 20);
			this.nudValue1.TabIndex = 51;
			this.nudValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudValue1.ThousandsSeparator = true;
			this.nudValue1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbBook1
			// 
			this.cbBook1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBook1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBook1.FormattingEnabled = true;
			this.cbBook1.Location = new System.Drawing.Point(3, 58);
			this.cbBook1.Name = "cbBook1";
			this.cbBook1.Size = new System.Drawing.Size(358, 21);
			this.cbBook1.Sorted = true;
			this.cbBook1.TabIndex = 31;
			this.toolTip1.SetToolTip(this.cbBook1, "Select engine opening book");
			// 
			// cbMode1
			// 
			this.cbMode1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbMode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMode1.FormattingEnabled = true;
			this.cbMode1.Items.AddRange(new object[] {
            "Blitz",
            "Depth",
            "Nodes",
            "Time"});
			this.cbMode1.Location = new System.Drawing.Point(3, 37);
			this.cbMode1.Name = "cbMode1";
			this.cbMode1.Size = new System.Drawing.Size(358, 21);
			this.cbMode1.Sorted = true;
			this.cbMode1.TabIndex = 29;
			this.toolTip1.SetToolTip(this.cbMode1, "Select engine mode");
			this.cbMode1.SelectedIndexChanged += new System.EventHandler(this.cbMode1_SelectedIndexChanged);
			// 
			// cbEngine1
			// 
			this.cbEngine1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEngine1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEngine1.FormattingEnabled = true;
			this.cbEngine1.Location = new System.Drawing.Point(3, 16);
			this.cbEngine1.Name = "cbEngine1";
			this.cbEngine1.Size = new System.Drawing.Size(358, 21);
			this.cbEngine1.Sorted = true;
			this.cbEngine1.TabIndex = 28;
			this.toolTip1.SetToolTip(this.cbEngine1, "Select engine");
			// 
			// tabPageTournament
			// 
			this.tabPageTournament.Controls.Add(this.splitContainerTournament);
			this.tabPageTournament.Controls.Add(this.butStartTournament);
			this.tabPageTournament.Location = new System.Drawing.Point(4, 5);
			this.tabPageTournament.Name = "tabPageTournament";
			this.tabPageTournament.Size = new System.Drawing.Size(364, 390);
			this.tabPageTournament.TabIndex = 3;
			this.tabPageTournament.Text = "Tournament";
			this.tabPageTournament.UseVisualStyleBackColor = true;
			// 
			// splitContainerTournament
			// 
			this.splitContainerTournament.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerTournament.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerTournament.Location = new System.Drawing.Point(0, 23);
			this.splitContainerTournament.Name = "splitContainerTournament";
			this.splitContainerTournament.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerTournament.Panel1
			// 
			this.splitContainerTournament.Panel1.Controls.Add(this.listView1);
			// 
			// splitContainerTournament.Panel2
			// 
			this.splitContainerTournament.Panel2.Controls.Add(this.listView2);
			this.splitContainerTournament.Panel2.Controls.Add(this.lPlayer);
			this.splitContainerTournament.Size = new System.Drawing.Size(364, 367);
			this.splitContainerTournament.SplitterDistance = 244;
			this.splitContainerTournament.TabIndex = 26;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.ShowGroups = false;
			this.listView1.Size = new System.Drawing.Size(360, 240);
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 23;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			this.listView1.Resize += new System.EventHandler(this.listView1_Resize);
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
			// listView2
			// 
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader8,
            this.columnHeader10});
			this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView2.FullRowSelect = true;
			this.listView2.GridLines = true;
			this.listView2.HideSelection = false;
			this.listView2.Location = new System.Drawing.Point(0, 13);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.ShowGroups = false;
			this.listView2.Size = new System.Drawing.Size(360, 102);
			this.listView2.TabIndex = 27;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Details;
			this.listView2.Resize += new System.EventHandler(this.listView2_Resize);
			// 
			// columnHeader7
			// 
			this.columnHeader7.Tag = "";
			this.columnHeader7.Text = "Player";
			this.columnHeader7.Width = 140;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Elo";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader9.Width = 50;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Games";
			this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader8.Width = 50;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Score";
			this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader10.Width = 50;
			// 
			// lPlayer
			// 
			this.lPlayer.Dock = System.Windows.Forms.DockStyle.Top;
			this.lPlayer.Location = new System.Drawing.Point(0, 0);
			this.lPlayer.Name = "lPlayer";
			this.lPlayer.Size = new System.Drawing.Size(360, 13);
			this.lPlayer.TabIndex = 26;
			this.lPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butStartTournament
			// 
			this.butStartTournament.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStartTournament.Location = new System.Drawing.Point(0, 0);
			this.butStartTournament.Name = "butStartTournament";
			this.butStartTournament.Size = new System.Drawing.Size(364, 23);
			this.butStartTournament.TabIndex = 21;
			this.butStartTournament.Text = "Start";
			this.toolTip1.SetToolTip(this.butStartTournament, "Start tournament");
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
			this.tabPageTraining.Location = new System.Drawing.Point(4, 5);
			this.tabPageTraining.Name = "tabPageTraining";
			this.tabPageTraining.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTraining.Size = new System.Drawing.Size(364, 390);
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
			this.tableLayoutPanel1.Size = new System.Drawing.Size(358, 100);
			this.tableLayoutPanel1.TabIndex = 25;
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.Location = new System.Drawing.Point(299, 67);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(55, 32);
			this.label15.TabIndex = 14;
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.Location = new System.Drawing.Point(240, 67);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(52, 32);
			this.label14.TabIndex = 13;
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.Location = new System.Drawing.Point(181, 67);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(52, 32);
			this.label13.TabIndex = 12;
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.Location = new System.Drawing.Point(122, 67);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(52, 32);
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
			this.label11.Size = new System.Drawing.Size(111, 32);
			this.label11.TabIndex = 10;
			this.label11.Text = "Teacher";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.Location = new System.Drawing.Point(299, 34);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(55, 32);
			this.label10.TabIndex = 9;
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.Location = new System.Drawing.Point(240, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 32);
			this.label9.TabIndex = 8;
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(181, 34);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(52, 32);
			this.label8.TabIndex = 7;
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point(122, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(52, 32);
			this.label7.TabIndex = 6;
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(299, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 32);
			this.label5.TabIndex = 4;
			this.label5.Text = "Result";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(240, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 32);
			this.label4.TabIndex = 3;
			this.label4.Text = "Draw";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(181, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 32);
			this.label3.TabIndex = 2;
			this.label3.Text = "Loose";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(122, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 32);
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
			this.label6.Size = new System.Drawing.Size(111, 32);
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
			this.label16.Size = new System.Drawing.Size(111, 32);
			this.label16.TabIndex = 5;
			this.label16.Text = "Trained";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labGames
			// 
			this.labGames.Dock = System.Windows.Forms.DockStyle.Top;
			this.labGames.Location = new System.Drawing.Point(3, 236);
			this.labGames.Name = "labGames";
			this.labGames.Size = new System.Drawing.Size(358, 24);
			this.labGames.TabIndex = 22;
			this.labGames.Text = "Games 0";
			this.labGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butTraining
			// 
			this.butTraining.Dock = System.Windows.Forms.DockStyle.Top;
			this.butTraining.Location = new System.Drawing.Point(3, 213);
			this.butTraining.Name = "butTraining";
			this.butTraining.Size = new System.Drawing.Size(358, 23);
			this.butTraining.TabIndex = 21;
			this.butTraining.Text = "Start";
			this.toolTip1.SetToolTip(this.butTraining, "Start training");
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
			this.groupBox4.Size = new System.Drawing.Size(358, 105);
			this.groupBox4.TabIndex = 20;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Teacher";
			// 
			// nudTeacher
			// 
			this.nudTeacher.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTeacher.Location = new System.Drawing.Point(3, 79);
			this.nudTeacher.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.nudTeacher.Name = "nudTeacher";
			this.nudTeacher.Size = new System.Drawing.Size(352, 20);
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
			this.cbTeacherBook.Size = new System.Drawing.Size(352, 21);
			this.cbTeacherBook.Sorted = true;
			this.cbTeacherBook.TabIndex = 26;
			this.toolTip1.SetToolTip(this.cbTeacherBook, "Select chess opening book");
			// 
			// cbTeacherMode
			// 
			this.cbTeacherMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTeacherMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeacherMode.FormattingEnabled = true;
			this.cbTeacherMode.Items.AddRange(new object[] {
            "Blitz",
            "Depth",
            "Nodes",
            "Time"});
			this.cbTeacherMode.Location = new System.Drawing.Point(3, 37);
			this.cbTeacherMode.Name = "cbTeacherMode";
			this.cbTeacherMode.Size = new System.Drawing.Size(352, 21);
			this.cbTeacherMode.Sorted = true;
			this.cbTeacherMode.TabIndex = 30;
			this.toolTip1.SetToolTip(this.cbTeacherMode, "Select mode");
			this.cbTeacherMode.SelectedIndexChanged += new System.EventHandler(this.cbTeacherMode_SelectedIndexChanged);
			// 
			// cbTeacherEngine
			// 
			this.cbTeacherEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTeacherEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeacherEngine.Location = new System.Drawing.Point(3, 16);
			this.cbTeacherEngine.Name = "cbTeacherEngine";
			this.cbTeacherEngine.Size = new System.Drawing.Size(352, 21);
			this.cbTeacherEngine.Sorted = true;
			this.cbTeacherEngine.TabIndex = 2;
			this.toolTip1.SetToolTip(this.cbTeacherEngine, "Select engine");
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
			this.groupBox3.Size = new System.Drawing.Size(358, 105);
			this.groupBox3.TabIndex = 19;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Trained";
			// 
			// nudTrained
			// 
			this.nudTrained.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTrained.Location = new System.Drawing.Point(3, 79);
			this.nudTrained.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.nudTrained.Name = "nudTrained";
			this.nudTrained.Size = new System.Drawing.Size(352, 20);
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
			this.cbTrainedBook.Size = new System.Drawing.Size(352, 21);
			this.cbTrainedBook.Sorted = true;
			this.cbTrainedBook.TabIndex = 29;
			this.toolTip1.SetToolTip(this.cbTrainedBook, "Select chess opening book");
			// 
			// cbTrainedMode
			// 
			this.cbTrainedMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTrainedMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrainedMode.FormattingEnabled = true;
			this.cbTrainedMode.Items.AddRange(new object[] {
            "Blitz",
            "Depth",
            "Nodes",
            "Time"});
			this.cbTrainedMode.Location = new System.Drawing.Point(3, 37);
			this.cbTrainedMode.Name = "cbTrainedMode";
			this.cbTrainedMode.Size = new System.Drawing.Size(352, 21);
			this.cbTrainedMode.Sorted = true;
			this.cbTrainedMode.TabIndex = 30;
			this.toolTip1.SetToolTip(this.cbTrainedMode, "Select mode");
			this.cbTrainedMode.SelectedIndexChanged += new System.EventHandler(this.cbTrainedMode_SelectedIndexChanged);
			// 
			// cbTrainedEngine
			// 
			this.cbTrainedEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTrainedEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrainedEngine.Location = new System.Drawing.Point(3, 16);
			this.cbTrainedEngine.Name = "cbTrainedEngine";
			this.cbTrainedEngine.Size = new System.Drawing.Size(352, 21);
			this.cbTrainedEngine.Sorted = true;
			this.cbTrainedEngine.TabIndex = 2;
			this.toolTip1.SetToolTip(this.cbTrainedEngine, "Select engine");
			// 
			// tabPageEdit
			// 
			this.tabPageEdit.Controls.Add(this.groupBox7);
			this.tabPageEdit.Controls.Add(this.gbToMove);
			this.tabPageEdit.Controls.Add(this.butDefault);
			this.tabPageEdit.Controls.Add(this.butClearBoard);
			this.tabPageEdit.Location = new System.Drawing.Point(4, 5);
			this.tabPageEdit.Name = "tabPageEdit";
			this.tabPageEdit.Size = new System.Drawing.Size(364, 390);
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
			this.groupBox7.Size = new System.Drawing.Size(364, 84);
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
			this.clbCastling.Size = new System.Drawing.Size(358, 65);
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
			this.gbToMove.Size = new System.Drawing.Size(364, 53);
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
			this.rbBlack.Size = new System.Drawing.Size(358, 17);
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
			this.rbWhite.Size = new System.Drawing.Size(358, 17);
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
			this.butDefault.Size = new System.Drawing.Size(364, 25);
			this.butDefault.TabIndex = 3;
			this.butDefault.Text = "Default position";
			this.toolTip1.SetToolTip(this.butDefault, "Put the chess pieces in the starting position");
			this.butDefault.UseVisualStyleBackColor = true;
			this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
			// 
			// butClearBoard
			// 
			this.butClearBoard.Dock = System.Windows.Forms.DockStyle.Top;
			this.butClearBoard.Location = new System.Drawing.Point(0, 0);
			this.butClearBoard.Name = "butClearBoard";
			this.butClearBoard.Size = new System.Drawing.Size(364, 25);
			this.butClearBoard.TabIndex = 0;
			this.butClearBoard.Text = "Clear board";
			this.toolTip1.SetToolTip(this.butClearBoard, "Remove all pieces");
			this.butClearBoard.UseVisualStyleBackColor = true;
			this.butClearBoard.Click += new System.EventHandler(this.butClearBoard_Click);
			// 
			// timerStart
			// 
			this.timerStart.Interval = 6000;
			this.timerStart.Tick += new System.EventHandler(this.TimerStart_Tick);
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
			// labFPS
			// 
			this.labFPS.Dock = System.Windows.Forms.DockStyle.Right;
			this.labFPS.Location = new System.Drawing.Point(1093, 0);
			this.labFPS.Name = "labFPS";
			this.labFPS.Size = new System.Drawing.Size(87, 22);
			this.labFPS.TabIndex = 2;
			this.labFPS.Text = "FPS";
			this.labFPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panMenu
			// 
			this.panMenu.BackColor = System.Drawing.SystemColors.Control;
			this.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panMenu.Controls.Add(this.labEco);
			this.panMenu.Controls.Add(this.labFPS);
			this.panMenu.Controls.Add(this.menuStrip1);
			this.panMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.panMenu.Location = new System.Drawing.Point(0, 0);
			this.panMenu.Name = "panMenu";
			this.panMenu.Size = new System.Drawing.Size(1184, 26);
			this.panMenu.TabIndex = 26;
			// 
			// labEco
			// 
			this.labEco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labEco.Location = new System.Drawing.Point(380, 0);
			this.labEco.Name = "labEco";
			this.labEco.Size = new System.Drawing.Size(713, 22);
			this.labEco.TabIndex = 3;
			this.labEco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labNpsT
			// 
			this.labNpsT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNpsT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNpsT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labNpsT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNpsT.ForeColor = System.Drawing.Color.Black;
			this.labNpsT.Location = new System.Drawing.Point(591, 0);
			this.labNpsT.Margin = new System.Windows.Forms.Padding(0);
			this.labNpsT.Name = "labNpsT";
			this.labNpsT.Size = new System.Drawing.Size(197, 24);
			this.labNpsT.TabIndex = 15;
			this.labNpsT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNpsT, "Searched nodes per second");
			// 
			// labBookT
			// 
			this.labBookT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labBookT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBookT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labBookT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBookT.ForeColor = System.Drawing.Color.Black;
			this.labBookT.Location = new System.Drawing.Point(788, 0);
			this.labBookT.Margin = new System.Windows.Forms.Padding(0);
			this.labBookT.Name = "labBookT";
			this.labBookT.Size = new System.Drawing.Size(197, 24);
			this.labBookT.TabIndex = 14;
			this.labBookT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labBookT, "Number of moves read from the opening book");
			// 
			// labPonderT
			// 
			this.labPonderT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labPonderT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labPonderT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labPonderT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPonderT.ForeColor = System.Drawing.Color.Black;
			this.labPonderT.Location = new System.Drawing.Point(985, 0);
			this.labPonderT.Margin = new System.Windows.Forms.Padding(0);
			this.labPonderT.Name = "labPonderT";
			this.labPonderT.Size = new System.Drawing.Size(199, 24);
			this.labPonderT.TabIndex = 13;
			this.labPonderT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPonderT, "Next move expected");
			// 
			// labScoreT
			// 
			this.labScoreT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labScoreT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labScoreT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labScoreT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labScoreT.ForeColor = System.Drawing.Color.Black;
			this.labScoreT.Location = new System.Drawing.Point(0, 0);
			this.labScoreT.Margin = new System.Windows.Forms.Padding(0);
			this.labScoreT.Name = "labScoreT";
			this.labScoreT.Size = new System.Drawing.Size(197, 24);
			this.labScoreT.TabIndex = 12;
			this.labScoreT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labScoreT, "The score from the engine\'s point of view in centipawns");
			// 
			// labDepthT
			// 
			this.labDepthT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labDepthT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labDepthT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labDepthT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labDepthT.ForeColor = System.Drawing.Color.Black;
			this.labDepthT.Location = new System.Drawing.Point(197, 0);
			this.labDepthT.Margin = new System.Windows.Forms.Padding(0);
			this.labDepthT.Name = "labDepthT";
			this.labDepthT.Size = new System.Drawing.Size(197, 24);
			this.labDepthT.TabIndex = 9;
			this.labDepthT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labDepthT, "Search depth in plies");
			// 
			// labNodesT
			// 
			this.labNodesT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNodesT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNodesT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labNodesT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNodesT.ForeColor = System.Drawing.Color.Black;
			this.labNodesT.Location = new System.Drawing.Point(394, 0);
			this.labNodesT.Margin = new System.Windows.Forms.Padding(0);
			this.labNodesT.Name = "labNodesT";
			this.labNodesT.Size = new System.Drawing.Size(197, 24);
			this.labNodesT.TabIndex = 8;
			this.labNodesT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNodesT, "Searched nodes");
			// 
			// labNpsB
			// 
			this.labNpsB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNpsB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNpsB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labNpsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNpsB.ForeColor = System.Drawing.Color.Black;
			this.labNpsB.Location = new System.Drawing.Point(591, 0);
			this.labNpsB.Margin = new System.Windows.Forms.Padding(0);
			this.labNpsB.Name = "labNpsB";
			this.labNpsB.Size = new System.Drawing.Size(197, 24);
			this.labNpsB.TabIndex = 15;
			this.labNpsB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNpsB, "Searched nodes per second");
			// 
			// labBookB
			// 
			this.labBookB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labBookB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBookB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labBookB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBookB.ForeColor = System.Drawing.Color.Black;
			this.labBookB.Location = new System.Drawing.Point(788, 0);
			this.labBookB.Margin = new System.Windows.Forms.Padding(0);
			this.labBookB.Name = "labBookB";
			this.labBookB.Size = new System.Drawing.Size(197, 24);
			this.labBookB.TabIndex = 14;
			this.labBookB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labBookB, "Number of moves read from the opening book");
			// 
			// labPonderB
			// 
			this.labPonderB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labPonderB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labPonderB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labPonderB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPonderB.ForeColor = System.Drawing.Color.Black;
			this.labPonderB.Location = new System.Drawing.Point(985, 0);
			this.labPonderB.Margin = new System.Windows.Forms.Padding(0);
			this.labPonderB.Name = "labPonderB";
			this.labPonderB.Size = new System.Drawing.Size(199, 24);
			this.labPonderB.TabIndex = 13;
			this.labPonderB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPonderB, "Next move expected");
			// 
			// labScoreB
			// 
			this.labScoreB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labScoreB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labScoreB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labScoreB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labScoreB.ForeColor = System.Drawing.Color.Black;
			this.labScoreB.Location = new System.Drawing.Point(0, 0);
			this.labScoreB.Margin = new System.Windows.Forms.Padding(0);
			this.labScoreB.Name = "labScoreB";
			this.labScoreB.Size = new System.Drawing.Size(197, 24);
			this.labScoreB.TabIndex = 12;
			this.labScoreB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labScoreB, "The score from the engine\'s point of view in centipawns");
			// 
			// labDepthB
			// 
			this.labDepthB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labDepthB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labDepthB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labDepthB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labDepthB.ForeColor = System.Drawing.Color.Black;
			this.labDepthB.Location = new System.Drawing.Point(197, 0);
			this.labDepthB.Margin = new System.Windows.Forms.Padding(0);
			this.labDepthB.Name = "labDepthB";
			this.labDepthB.Size = new System.Drawing.Size(197, 24);
			this.labDepthB.TabIndex = 9;
			this.labDepthB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labDepthB, "Search depth in plies");
			// 
			// labNodesB
			// 
			this.labNodesB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNodesB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNodesB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labNodesB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNodesB.ForeColor = System.Drawing.Color.Black;
			this.labNodesB.Location = new System.Drawing.Point(394, 0);
			this.labNodesB.Margin = new System.Windows.Forms.Padding(0);
			this.labNodesB.Name = "labNodesB";
			this.labNodesB.Size = new System.Drawing.Size(197, 24);
			this.labNodesB.TabIndex = 8;
			this.labNodesB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNodesB, "Searched nodes");
			// 
			// labTimeD
			// 
			this.labTimeD.BackColor = System.Drawing.Color.LightGray;
			this.labTimeD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTimeD.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labTimeD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTimeD.ForeColor = System.Drawing.Color.Black;
			this.labTimeD.Location = new System.Drawing.Point(183, 0);
			this.labTimeD.Margin = new System.Windows.Forms.Padding(0);
			this.labTimeD.Name = "labTimeD";
			this.labTimeD.Size = new System.Drawing.Size(106, 24);
			this.labTimeD.TabIndex = 23;
			this.labTimeD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labTimeD, "Player time");
			// 
			// labEloD
			// 
			this.labEloD.BackColor = System.Drawing.Color.LightGray;
			this.labEloD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEloD.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labEloD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEloD.ForeColor = System.Drawing.Color.Black;
			this.labEloD.Location = new System.Drawing.Point(289, 0);
			this.labEloD.Margin = new System.Windows.Forms.Padding(0);
			this.labEloD.Name = "labEloD";
			this.labEloD.Size = new System.Drawing.Size(107, 24);
			this.labEloD.TabIndex = 22;
			this.labEloD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labEloD, "Player strength in chess rating points");
			// 
			// labColorD
			// 
			this.labColorD.BackColor = System.Drawing.Color.LightGray;
			this.labColorD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labColorD.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labColorD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labColorD.ForeColor = System.Drawing.Color.Black;
			this.labColorD.Location = new System.Drawing.Point(0, 0);
			this.labColorD.Margin = new System.Windows.Forms.Padding(0);
			this.labColorD.Name = "labColorD";
			this.labColorD.Size = new System.Drawing.Size(24, 24);
			this.labColorD.TabIndex = 21;
			this.labColorD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labColorD, "Player color");
			// 
			// labNameD
			// 
			this.labNameD.BackColor = System.Drawing.Color.LightGray;
			this.labNameD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNameD.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labNameD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNameD.ForeColor = System.Drawing.Color.Black;
			this.labNameD.Location = new System.Drawing.Point(24, 0);
			this.labNameD.Margin = new System.Windows.Forms.Padding(0);
			this.labNameD.Name = "labNameD";
			this.labNameD.Size = new System.Drawing.Size(159, 24);
			this.labNameD.TabIndex = 20;
			this.labNameD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNameD, "Player name");
			// 
			// labEloT
			// 
			this.labEloT.BackColor = System.Drawing.Color.LightGray;
			this.labEloT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEloT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labEloT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEloT.ForeColor = System.Drawing.Color.Black;
			this.labEloT.Location = new System.Drawing.Point(289, 0);
			this.labEloT.Margin = new System.Windows.Forms.Padding(0);
			this.labEloT.Name = "labEloT";
			this.labEloT.Size = new System.Drawing.Size(107, 24);
			this.labEloT.TabIndex = 22;
			this.labEloT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labEloT, "Player strength in chess rating points");
			// 
			// labColorT
			// 
			this.labColorT.BackColor = System.Drawing.Color.LightGray;
			this.labColorT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labColorT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labColorT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labColorT.ForeColor = System.Drawing.Color.Black;
			this.labColorT.Location = new System.Drawing.Point(0, 0);
			this.labColorT.Margin = new System.Windows.Forms.Padding(0);
			this.labColorT.Name = "labColorT";
			this.labColorT.Size = new System.Drawing.Size(24, 24);
			this.labColorT.TabIndex = 21;
			this.labColorT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labColorT, "Player color");
			// 
			// labNameT
			// 
			this.labNameT.BackColor = System.Drawing.Color.LightGray;
			this.labNameT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNameT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNameT.ForeColor = System.Drawing.Color.Black;
			this.labNameT.Location = new System.Drawing.Point(24, 0);
			this.labNameT.Margin = new System.Windows.Forms.Padding(0);
			this.labNameT.Name = "labNameT";
			this.labNameT.Size = new System.Drawing.Size(159, 24);
			this.labNameT.TabIndex = 20;
			this.labNameT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNameT, "Player name");
			// 
			// labMovesW
			// 
			this.labMovesW.BackColor = System.Drawing.Color.Olive;
			this.labMovesW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMovesW.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labMovesW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMovesW.ForeColor = System.Drawing.Color.White;
			this.labMovesW.Location = new System.Drawing.Point(24, 0);
			this.labMovesW.Margin = new System.Windows.Forms.Padding(0);
			this.labMovesW.Name = "labMovesW";
			this.labMovesW.Size = new System.Drawing.Size(385, 24);
			this.labMovesW.TabIndex = 13;
			this.labMovesW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labMovesW, "The score from the engine\'s point of view in centipawns");
			// 
			// labWhite
			// 
			this.labWhite.BackColor = System.Drawing.Color.White;
			this.labWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labWhite.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labWhite.ForeColor = System.Drawing.Color.Black;
			this.labWhite.Location = new System.Drawing.Point(0, 0);
			this.labWhite.Margin = new System.Windows.Forms.Padding(0);
			this.labWhite.Name = "labWhite";
			this.labWhite.Size = new System.Drawing.Size(24, 24);
			this.labWhite.TabIndex = 14;
			this.labWhite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labWhite, "The score from the engine\'s point of view in centipawns");
			// 
			// labProtocolW
			// 
			this.labProtocolW.BackColor = System.Drawing.Color.Olive;
			this.labProtocolW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labProtocolW.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labProtocolW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labProtocolW.ForeColor = System.Drawing.Color.White;
			this.labProtocolW.Location = new System.Drawing.Point(794, 0);
			this.labProtocolW.Margin = new System.Windows.Forms.Padding(0);
			this.labProtocolW.Name = "labProtocolW";
			this.labProtocolW.Size = new System.Drawing.Size(386, 24);
			this.labProtocolW.TabIndex = 15;
			this.labProtocolW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labProtocolW, "The score from the engine\'s point of view in centipawns");
			// 
			// labEloW
			// 
			this.labEloW.BackColor = System.Drawing.Color.Olive;
			this.labEloW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEloW.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labEloW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEloW.ForeColor = System.Drawing.Color.White;
			this.labEloW.Location = new System.Drawing.Point(409, 0);
			this.labEloW.Margin = new System.Windows.Forms.Padding(0);
			this.labEloW.Name = "labEloW";
			this.labEloW.Size = new System.Drawing.Size(385, 24);
			this.labEloW.TabIndex = 16;
			this.labEloW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labEloW, "Player strength in chess rating points");
			// 
			// labEloB
			// 
			this.labEloB.BackColor = System.Drawing.Color.Olive;
			this.labEloB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEloB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labEloB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEloB.ForeColor = System.Drawing.Color.White;
			this.labEloB.Location = new System.Drawing.Point(409, 0);
			this.labEloB.Margin = new System.Windows.Forms.Padding(0);
			this.labEloB.Name = "labEloB";
			this.labEloB.Size = new System.Drawing.Size(385, 24);
			this.labEloB.TabIndex = 16;
			this.labEloB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labEloB, "Player strength in chess rating points");
			// 
			// labProtocolB
			// 
			this.labProtocolB.BackColor = System.Drawing.Color.Olive;
			this.labProtocolB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labProtocolB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labProtocolB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labProtocolB.ForeColor = System.Drawing.Color.White;
			this.labProtocolB.Location = new System.Drawing.Point(794, 0);
			this.labProtocolB.Margin = new System.Windows.Forms.Padding(0);
			this.labProtocolB.Name = "labProtocolB";
			this.labProtocolB.Size = new System.Drawing.Size(386, 24);
			this.labProtocolB.TabIndex = 15;
			this.labProtocolB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labProtocolB, "The score from the engine\'s point of view in centipawns");
			// 
			// labBlack
			// 
			this.labBlack.BackColor = System.Drawing.Color.Black;
			this.labBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBlack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBlack.ForeColor = System.Drawing.Color.Black;
			this.labBlack.Location = new System.Drawing.Point(0, 0);
			this.labBlack.Margin = new System.Windows.Forms.Padding(0);
			this.labBlack.Name = "labBlack";
			this.labBlack.Size = new System.Drawing.Size(24, 24);
			this.labBlack.TabIndex = 14;
			this.labBlack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labBlack, "The score from the engine\'s point of view in centipawns");
			// 
			// labMovesB
			// 
			this.labMovesB.BackColor = System.Drawing.Color.Olive;
			this.labMovesB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMovesB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labMovesB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMovesB.ForeColor = System.Drawing.Color.White;
			this.labMovesB.Location = new System.Drawing.Point(24, 0);
			this.labMovesB.Margin = new System.Windows.Forms.Padding(0);
			this.labMovesB.Name = "labMovesB";
			this.labMovesB.Size = new System.Drawing.Size(385, 24);
			this.labMovesB.TabIndex = 13;
			this.labMovesB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labMovesB, "The score from the engine\'s point of view in centipawns");
			// 
			// labTimeT
			// 
			this.labTimeT.BackColor = System.Drawing.Color.LightGray;
			this.labTimeT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTimeT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labTimeT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTimeT.ForeColor = System.Drawing.Color.Black;
			this.labTimeT.Location = new System.Drawing.Point(183, 0);
			this.labTimeT.Margin = new System.Windows.Forms.Padding(0);
			this.labTimeT.Name = "labTimeT";
			this.labTimeT.Size = new System.Drawing.Size(106, 24);
			this.labTimeT.TabIndex = 24;
			this.labTimeT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labTimeT, "Player time");
			// 
			// cbMainMode
			// 
			this.cbMainMode.AutoCompleteCustomSource.AddRange(new string[] {
            "White",
            "Black"});
			this.cbMainMode.BackColor = System.Drawing.SystemColors.Window;
			this.cbMainMode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbMainMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbMainMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMainMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cbMainMode.Items.AddRange(new object[] {
            "Game",
            "Match",
            "Tournament",
            "Training",
            "Edit"});
			this.cbMainMode.Location = new System.Drawing.Point(0, 0);
			this.cbMainMode.Name = "cbMainMode";
			this.cbMainMode.Size = new System.Drawing.Size(372, 24);
			this.cbMainMode.TabIndex = 10;
			this.toolTip1.SetToolTip(this.cbMainMode, "Select game mode");
			this.cbMainMode.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.Color.Black;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMove,
            this.tssMoves});
			this.statusStrip1.Location = new System.Drawing.Point(0, 740);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1184, 22);
			this.statusStrip1.TabIndex = 33;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tssMove
			// 
			this.tssMove.AutoSize = false;
			this.tssMove.ForeColor = System.Drawing.Color.Gainsboro;
			this.tssMove.Name = "tssMove";
			this.tssMove.Size = new System.Drawing.Size(100, 17);
			// 
			// tssMoves
			// 
			this.tssMoves.ForeColor = System.Drawing.Color.Gainsboro;
			this.tssMoves.Name = "tssMoves";
			this.tssMoves.Size = new System.Drawing.Size(0, 17);
			// 
			// splitContainerBoard
			// 
			this.splitContainerBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerBoard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerBoard.Location = new System.Drawing.Point(0, 24);
			this.splitContainerBoard.Name = "splitContainerBoard";
			// 
			// splitContainerBoard.Panel1
			// 
			this.splitContainerBoard.Panel1.Controls.Add(this.panBoard);
			this.splitContainerBoard.Panel1.Controls.Add(this.tlpBoardD);
			this.splitContainerBoard.Panel1.Controls.Add(this.tlpBoardT);
			// 
			// splitContainerBoard.Panel2
			// 
			this.splitContainerBoard.Panel2.Controls.Add(this.splitContainerMode);
			this.splitContainerBoard.Size = new System.Drawing.Size(1184, 424);
			this.splitContainerBoard.SplitterDistance = 400;
			this.splitContainerBoard.TabIndex = 37;
			// 
			// panBoard
			// 
			this.panBoard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panBoard.Location = new System.Drawing.Point(0, 24);
			this.panBoard.Name = "panBoard";
			this.panBoard.Size = new System.Drawing.Size(396, 372);
			this.panBoard.TabIndex = 2;
			this.panBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panBoard_Paint);
			this.panBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.panBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.panBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			this.panBoard.Resize += new System.EventHandler(this.panBoard_Resize);
			// 
			// tlpBoardD
			// 
			this.tlpBoardD.ColumnCount = 4;
			this.tlpBoardD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tlpBoardD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.29412F));
			this.tlpBoardD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.52941F));
			this.tlpBoardD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.52941F));
			this.tlpBoardD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
			this.tlpBoardD.Controls.Add(this.labTimeD, 0, 0);
			this.tlpBoardD.Controls.Add(this.labEloD, 0, 0);
			this.tlpBoardD.Controls.Add(this.labColorD, 0, 0);
			this.tlpBoardD.Controls.Add(this.labNameD, 0, 0);
			this.tlpBoardD.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlpBoardD.Location = new System.Drawing.Point(0, 396);
			this.tlpBoardD.Margin = new System.Windows.Forms.Padding(0);
			this.tlpBoardD.Name = "tlpBoardD";
			this.tlpBoardD.RowCount = 1;
			this.tlpBoardD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpBoardD.Size = new System.Drawing.Size(396, 24);
			this.tlpBoardD.TabIndex = 1;
			// 
			// tlpBoardT
			// 
			this.tlpBoardT.ColumnCount = 4;
			this.tlpBoardT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tlpBoardT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.29412F));
			this.tlpBoardT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.52941F));
			this.tlpBoardT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.52941F));
			this.tlpBoardT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.64706F));
			this.tlpBoardT.Controls.Add(this.labTimeT, 0, 0);
			this.tlpBoardT.Controls.Add(this.labEloT, 0, 0);
			this.tlpBoardT.Controls.Add(this.labColorT, 0, 0);
			this.tlpBoardT.Controls.Add(this.labNameT, 0, 0);
			this.tlpBoardT.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpBoardT.Location = new System.Drawing.Point(0, 0);
			this.tlpBoardT.Margin = new System.Windows.Forms.Padding(0);
			this.tlpBoardT.Name = "tlpBoardT";
			this.tlpBoardT.RowCount = 1;
			this.tlpBoardT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpBoardT.Size = new System.Drawing.Size(396, 24);
			this.tlpBoardT.TabIndex = 0;
			// 
			// splitContainerMode
			// 
			this.splitContainerMode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMode.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMode.Name = "splitContainerMode";
			// 
			// splitContainerMode.Panel1
			// 
			this.splitContainerMode.Panel1.Controls.Add(this.splitContainerChart);
			this.splitContainerMode.Panel1.Controls.Add(this.tlpChartD);
			this.splitContainerMode.Panel1.Controls.Add(this.tlpChartT);
			// 
			// splitContainerMode.Panel2
			// 
			this.splitContainerMode.Panel2.Controls.Add(this.tabControl1);
			this.splitContainerMode.Panel2.Controls.Add(this.cbMainMode);
			this.splitContainerMode.Size = new System.Drawing.Size(776, 420);
			this.splitContainerMode.SplitterDistance = 400;
			this.splitContainerMode.TabIndex = 14;
			// 
			// splitContainerChart
			// 
			this.splitContainerChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerChart.Location = new System.Drawing.Point(0, 28);
			this.splitContainerChart.Name = "splitContainerChart";
			this.splitContainerChart.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerChart.Panel1
			// 
			this.splitContainerChart.Panel1.Controls.Add(this.lvMoves);
			// 
			// splitContainerChart.Panel2
			// 
			this.splitContainerChart.Panel2.Controls.Add(this.chart1);
			this.splitContainerChart.Size = new System.Drawing.Size(400, 364);
			this.splitContainerChart.SplitterDistance = 210;
			this.splitContainerChart.TabIndex = 27;
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
			this.lvMoves.Location = new System.Drawing.Point(0, 0);
			this.lvMoves.MultiSelect = false;
			this.lvMoves.Name = "lvMoves";
			this.lvMoves.ShowGroups = false;
			this.lvMoves.Size = new System.Drawing.Size(396, 206);
			this.lvMoves.TabIndex = 27;
			this.lvMoves.UseCompatibleStateImageBehavior = false;
			this.lvMoves.View = System.Windows.Forms.View.Details;
			this.lvMoves.Resize += new System.EventHandler(this.lvMoves_Resize);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Move";
			this.columnHeader3.Width = 50;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "White";
			this.columnHeader4.Width = 50;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Black";
			this.columnHeader5.Width = 50;
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.chart1.BorderlineColor = System.Drawing.Color.Silver;
			chartArea1.AxisX.IsLabelAutoFit = false;
			chartArea1.AxisX.MajorGrid.Enabled = false;
			chartArea1.AxisX.MajorTickMark.Enabled = false;
			chartArea1.AxisY.IsLabelAutoFit = false;
			chartArea1.AxisY.MajorGrid.Interval = 5D;
			chartArea1.AxisY.Maximum = 5D;
			chartArea1.AxisY.Minimum = -5D;
			chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chart1.Location = new System.Drawing.Point(0, 0);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Olive};
			series1.ChartArea = "ChartArea1";
			series1.CustomProperties = "PointWidth=1";
			series1.IsVisibleInLegend = false;
			series1.Name = "Series1";
			series2.ChartArea = "ChartArea1";
			series2.CustomProperties = "PointWidth=1";
			series2.Name = "Series2";
			this.chart1.Series.Add(series1);
			this.chart1.Series.Add(series2);
			this.chart1.Size = new System.Drawing.Size(396, 146);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 26);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.splitContainerBoard);
			this.splitContainerMain.Panel1.Controls.Add(this.tlpEngineT);
			this.splitContainerMain.Panel1.Controls.Add(this.tlpEngineB);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.splitContainerMoves);
			this.splitContainerMain.Size = new System.Drawing.Size(1184, 714);
			this.splitContainerMain.SplitterDistance = 472;
			this.splitContainerMain.TabIndex = 38;
			// 
			// tlpEngineT
			// 
			this.tlpEngineT.ColumnCount = 6;
			this.tlpEngineT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineT.Controls.Add(this.labNpsT, 0, 0);
			this.tlpEngineT.Controls.Add(this.labBookT, 0, 0);
			this.tlpEngineT.Controls.Add(this.labPonderT, 0, 0);
			this.tlpEngineT.Controls.Add(this.labScoreT, 0, 0);
			this.tlpEngineT.Controls.Add(this.labDepthT, 0, 0);
			this.tlpEngineT.Controls.Add(this.labNodesT, 0, 0);
			this.tlpEngineT.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpEngineT.Location = new System.Drawing.Point(0, 0);
			this.tlpEngineT.Margin = new System.Windows.Forms.Padding(0);
			this.tlpEngineT.Name = "tlpEngineT";
			this.tlpEngineT.RowCount = 1;
			this.tlpEngineT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpEngineT.Size = new System.Drawing.Size(1184, 24);
			this.tlpEngineT.TabIndex = 38;
			// 
			// tlpEngineB
			// 
			this.tlpEngineB.ColumnCount = 6;
			this.tlpEngineB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpEngineB.Controls.Add(this.labNpsB, 0, 0);
			this.tlpEngineB.Controls.Add(this.labBookB, 0, 0);
			this.tlpEngineB.Controls.Add(this.labPonderB, 0, 0);
			this.tlpEngineB.Controls.Add(this.labScoreB, 0, 0);
			this.tlpEngineB.Controls.Add(this.labDepthB, 0, 0);
			this.tlpEngineB.Controls.Add(this.labNodesB, 0, 0);
			this.tlpEngineB.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlpEngineB.Location = new System.Drawing.Point(0, 448);
			this.tlpEngineB.Margin = new System.Windows.Forms.Padding(0);
			this.tlpEngineB.Name = "tlpEngineB";
			this.tlpEngineB.RowCount = 1;
			this.tlpEngineB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpEngineB.Size = new System.Drawing.Size(1184, 24);
			this.tlpEngineB.TabIndex = 37;
			// 
			// splitContainerMoves
			// 
			this.splitContainerMoves.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerMoves.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMoves.Location = new System.Drawing.Point(0, 0);
			this.splitContainerMoves.Name = "splitContainerMoves";
			this.splitContainerMoves.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMoves.Panel1
			// 
			this.splitContainerMoves.Panel1.Controls.Add(this.lvMovesW);
			this.splitContainerMoves.Panel1.Controls.Add(this.tlpWhite);
			// 
			// splitContainerMoves.Panel2
			// 
			this.splitContainerMoves.Panel2.Controls.Add(this.lvMovesB);
			this.splitContainerMoves.Panel2.Controls.Add(this.tableLayoutPanel3);
			this.splitContainerMoves.Size = new System.Drawing.Size(1184, 238);
			this.splitContainerMoves.SplitterDistance = 111;
			this.splitContainerMoves.TabIndex = 33;
			// 
			// lvMovesW
			// 
			this.lvMovesW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
			this.lvMovesW.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvMovesW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvMovesW.FullRowSelect = true;
			this.lvMovesW.GridLines = true;
			this.lvMovesW.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvMovesW.HideSelection = false;
			this.lvMovesW.Location = new System.Drawing.Point(0, 24);
			this.lvMovesW.MultiSelect = false;
			this.lvMovesW.Name = "lvMovesW";
			this.lvMovesW.ShowGroups = false;
			this.lvMovesW.Size = new System.Drawing.Size(1180, 83);
			this.lvMovesW.TabIndex = 32;
			this.lvMovesW.UseCompatibleStateImageBehavior = false;
			this.lvMovesW.View = System.Windows.Forms.View.Details;
			this.lvMovesW.Resize += new System.EventHandler(this.lvLines_Resize);
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Time";
			this.columnHeader11.Width = 70;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Score";
			this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader12.Width = 100;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Depth";
			this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader13.Width = 100;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Nodes";
			this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader14.Width = 92;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "NPS";
			this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "Moves";
			this.columnHeader16.Width = 100;
			// 
			// tlpWhite
			// 
			this.tlpWhite.ColumnCount = 4;
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpWhite.Controls.Add(this.labEloW, 0, 0);
			this.tlpWhite.Controls.Add(this.labProtocolW, 0, 0);
			this.tlpWhite.Controls.Add(this.labWhite, 0, 0);
			this.tlpWhite.Controls.Add(this.labMovesW, 0, 0);
			this.tlpWhite.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpWhite.Location = new System.Drawing.Point(0, 0);
			this.tlpWhite.Name = "tlpWhite";
			this.tlpWhite.RowCount = 1;
			this.tlpWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpWhite.Size = new System.Drawing.Size(1180, 24);
			this.tlpWhite.TabIndex = 34;
			// 
			// lvMovesB
			// 
			this.lvMovesB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22});
			this.lvMovesB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvMovesB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvMovesB.FullRowSelect = true;
			this.lvMovesB.GridLines = true;
			this.lvMovesB.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvMovesB.HideSelection = false;
			this.lvMovesB.Location = new System.Drawing.Point(0, 24);
			this.lvMovesB.MultiSelect = false;
			this.lvMovesB.Name = "lvMovesB";
			this.lvMovesB.ShowGroups = false;
			this.lvMovesB.Size = new System.Drawing.Size(1180, 95);
			this.lvMovesB.TabIndex = 32;
			this.lvMovesB.UseCompatibleStateImageBehavior = false;
			this.lvMovesB.View = System.Windows.Forms.View.Details;
			this.lvMovesB.Resize += new System.EventHandler(this.lvLines_Resize);
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "Time";
			this.columnHeader17.Width = 70;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Text = "Score";
			this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader18.Width = 100;
			// 
			// columnHeader19
			// 
			this.columnHeader19.Text = "Depth";
			this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader19.Width = 100;
			// 
			// columnHeader20
			// 
			this.columnHeader20.Text = "Nodes";
			this.columnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader20.Width = 92;
			// 
			// columnHeader21
			// 
			this.columnHeader21.Text = "NPS";
			this.columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader22
			// 
			this.columnHeader22.Text = "Moves";
			this.columnHeader22.Width = 100;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.Controls.Add(this.labEloB, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.labProtocolB, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.labBlack, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.labMovesB, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(1180, 24);
			this.tableLayoutPanel3.TabIndex = 35;
			// 
			// tlpChartT
			// 
			this.tlpChartT.ColumnCount = 2;
			this.tlpChartT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.5F));
			this.tlpChartT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
			this.tlpChartT.Controls.Add(this.labMaterialT, 0, 0);
			this.tlpChartT.Controls.Add(this.labTakenT, 0, 0);
			this.tlpChartT.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpChartT.Location = new System.Drawing.Point(0, 0);
			this.tlpChartT.Margin = new System.Windows.Forms.Padding(0);
			this.tlpChartT.Name = "tlpChartT";
			this.tlpChartT.RowCount = 1;
			this.tlpChartT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpChartT.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpChartT.Size = new System.Drawing.Size(400, 28);
			this.tlpChartT.TabIndex = 29;
			// 
			// labTakenT
			// 
			this.labTakenT.BackColor = System.Drawing.Color.DarkGray;
			this.labTakenT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTakenT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labTakenT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTakenT.ForeColor = System.Drawing.Color.Black;
			this.labTakenT.Location = new System.Drawing.Point(0, 0);
			this.labTakenT.Margin = new System.Windows.Forms.Padding(0);
			this.labTakenT.Name = "labTakenT";
			this.labTakenT.Size = new System.Drawing.Size(310, 28);
			this.labTakenT.TabIndex = 15;
			this.labTakenT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.labTakenT, "Taken pieces");
			// 
			// labMaterialT
			// 
			this.labMaterialT.BackColor = System.Drawing.Color.DarkGray;
			this.labMaterialT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMaterialT.Dock = System.Windows.Forms.DockStyle.Right;
			this.labMaterialT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMaterialT.ForeColor = System.Drawing.Color.Black;
			this.labMaterialT.Location = new System.Drawing.Point(310, 0);
			this.labMaterialT.Margin = new System.Windows.Forms.Padding(0);
			this.labMaterialT.Name = "labMaterialT";
			this.labMaterialT.Size = new System.Drawing.Size(90, 28);
			this.labMaterialT.TabIndex = 24;
			this.labMaterialT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labMaterialT, "Difference of pieces material between players");
			// 
			// tlpChartD
			// 
			this.tlpChartD.ColumnCount = 2;
			this.tlpChartD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.5F));
			this.tlpChartD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
			this.tlpChartD.Controls.Add(this.labMaterialD, 0, 0);
			this.tlpChartD.Controls.Add(this.labTakenD, 0, 0);
			this.tlpChartD.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlpChartD.Location = new System.Drawing.Point(0, 392);
			this.tlpChartD.Margin = new System.Windows.Forms.Padding(0);
			this.tlpChartD.Name = "tlpChartD";
			this.tlpChartD.RowCount = 1;
			this.tlpChartD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpChartD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpChartD.Size = new System.Drawing.Size(400, 28);
			this.tlpChartD.TabIndex = 30;
			// 
			// labMaterialD
			// 
			this.labMaterialD.BackColor = System.Drawing.Color.DarkGray;
			this.labMaterialD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMaterialD.Dock = System.Windows.Forms.DockStyle.Right;
			this.labMaterialD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMaterialD.ForeColor = System.Drawing.Color.Black;
			this.labMaterialD.Location = new System.Drawing.Point(310, 0);
			this.labMaterialD.Margin = new System.Windows.Forms.Padding(0);
			this.labMaterialD.Name = "labMaterialD";
			this.labMaterialD.Size = new System.Drawing.Size(90, 28);
			this.labMaterialD.TabIndex = 24;
			this.labMaterialD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labMaterialD, "Difference of pieces material between players");
			// 
			// labTakenD
			// 
			this.labTakenD.BackColor = System.Drawing.Color.DarkGray;
			this.labTakenD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTakenD.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labTakenD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTakenD.ForeColor = System.Drawing.Color.Black;
			this.labTakenD.Location = new System.Drawing.Point(0, 0);
			this.labTakenD.Margin = new System.Windows.Forms.Padding(0);
			this.labTakenD.Name = "labTakenD";
			this.labTakenD.Size = new System.Drawing.Size(310, 28);
			this.labTakenD.TabIndex = 15;
			this.labTakenD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.labTakenD, "Taken pieces");
			// 
			// FormChess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1184, 762);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormChess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RapChessGui";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChess_FormClosed);
			this.Resize += new System.EventHandler(this.FormChess_Resize);
			this.tabControl1.ResumeLayout(false);
			this.tabPageGame.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.tabPageMatch.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudValue2)).EndInit();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudValue1)).EndInit();
			this.tabPageTournament.ResumeLayout(false);
			this.splitContainerTournament.Panel1.ResumeLayout(false);
			this.splitContainerTournament.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTournament)).EndInit();
			this.splitContainerTournament.ResumeLayout(false);
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
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panMenu.ResumeLayout(false);
			this.panMenu.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainerBoard.Panel1.ResumeLayout(false);
			this.splitContainerBoard.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerBoard)).EndInit();
			this.splitContainerBoard.ResumeLayout(false);
			this.tlpBoardD.ResumeLayout(false);
			this.tlpBoardT.ResumeLayout(false);
			this.splitContainerMode.Panel1.ResumeLayout(false);
			this.splitContainerMode.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMode)).EndInit();
			this.splitContainerMode.ResumeLayout(false);
			this.splitContainerChart.Panel1.ResumeLayout(false);
			this.splitContainerChart.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerChart)).EndInit();
			this.splitContainerChart.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.tlpEngineT.ResumeLayout(false);
			this.tlpEngineB.ResumeLayout(false);
			this.splitContainerMoves.Panel1.ResumeLayout(false);
			this.splitContainerMoves.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMoves)).EndInit();
			this.splitContainerMoves.ResumeLayout(false);
			this.tlpWhite.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tlpChartT.ResumeLayout(false);
			this.tlpChartD.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
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
		private System.Windows.Forms.NumericUpDown nudTeacher;
		private System.Windows.Forms.ComboBox cbTeacherBook;
		private System.Windows.Forms.TabPage tabPageTournament;
		private System.Windows.Forms.Button butStartTournament;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TabPage tabPageEdit;
		private System.Windows.Forms.Button butClearBoard;
		private System.Windows.Forms.GroupBox gbToMove;
		private System.Windows.Forms.RadioButton rbBlack;
		private System.Windows.Forms.RadioButton rbWhite;
		private System.Windows.Forms.Button butStop;
		private System.Windows.Forms.Button butContinueGame;
		private System.Windows.Forms.Label labBack;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.CheckedListBox clbCastling;
		private System.Windows.Forms.Button butContinueMatch;
		private System.Windows.Forms.Button butDefault;
		private System.Windows.Forms.Label labAutoElo;
		private System.Windows.Forms.ComboBox cbBook1;
		private System.Windows.Forms.ComboBox cbMode1;
		private System.Windows.Forms.ComboBox cbEngine1;
		private System.Windows.Forms.ComboBox cbEngine2;
		private System.Windows.Forms.ComboBox cbMode2;
		private System.Windows.Forms.ComboBox cbBook2;
		private System.Windows.Forms.ComboBox cbTrainedBook;
		private System.Windows.Forms.ComboBox cbTeacherMode;
		private System.Windows.Forms.ComboBox cbTrainedMode;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToClipboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadFromClipboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pgnToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToClipboardToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem loadFromClipboardToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem enginesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
		private System.Windows.Forms.Label labFPS;
		private System.Windows.Forms.Panel panMenu;
		private System.Windows.Forms.Label labEco;
		private System.Windows.Forms.ComboBox cbEngine;
		private System.Windows.Forms.ComboBox cbMode;
		private System.Windows.Forms.ComboBox cbBook;
		private System.Windows.Forms.NumericUpDown nudValue;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssMove;
		private System.Windows.Forms.ToolStripStatusLabel tssMoves;
		private System.Windows.Forms.SplitContainer splitContainerBoard;
		private System.Windows.Forms.TableLayoutPanel tlpBoardT;
		private System.Windows.Forms.Label labEloT;
		private System.Windows.Forms.Label labColorT;
		private System.Windows.Forms.Label labNameT;
		private System.Windows.Forms.TableLayoutPanel tlpBoardD;
		private System.Windows.Forms.Label labTimeD;
		private System.Windows.Forms.Label labEloD;
		private System.Windows.Forms.Label labColorD;
		private System.Windows.Forms.Label labNameD;
		private System.Windows.Forms.Panel panBoard;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.SplitContainer splitContainerMoves;
		private System.Windows.Forms.ListView lvMovesW;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ListView lvMovesB;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader columnHeader19;
		private System.Windows.Forms.ColumnHeader columnHeader20;
		private System.Windows.Forms.ColumnHeader columnHeader21;
		private System.Windows.Forms.ColumnHeader columnHeader22;
		private System.Windows.Forms.TableLayoutPanel tlpEngineT;
		private System.Windows.Forms.Label labNpsT;
		private System.Windows.Forms.Label labBookT;
		private System.Windows.Forms.Label labPonderT;
		private System.Windows.Forms.Label labScoreT;
		private System.Windows.Forms.Label labDepthT;
		private System.Windows.Forms.Label labNodesT;
		private System.Windows.Forms.TableLayoutPanel tlpEngineB;
		private System.Windows.Forms.Label labNpsB;
		private System.Windows.Forms.Label labBookB;
		private System.Windows.Forms.Label labPonderB;
		private System.Windows.Forms.Label labScoreB;
		private System.Windows.Forms.Label labDepthB;
		private System.Windows.Forms.Label labNodesB;
		private System.Windows.Forms.SplitContainer splitContainerTournament;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.Label lPlayer;
		private System.Windows.Forms.SplitContainer splitContainerMode;
		private System.Windows.Forms.SplitContainer splitContainerChart;
		private System.Windows.Forms.ListView lvMoves;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.NumericUpDown nudValue2;
		private System.Windows.Forms.NumericUpDown nudValue1;
		private System.Windows.Forms.TableLayoutPanel tlpWhite;
		private System.Windows.Forms.Label labEloW;
		private System.Windows.Forms.Label labProtocolW;
		private System.Windows.Forms.Label labWhite;
		private System.Windows.Forms.Label labMovesW;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label labEloB;
		private System.Windows.Forms.Label labProtocolB;
		private System.Windows.Forms.Label labBlack;
		private System.Windows.Forms.Label labMovesB;
		private System.Windows.Forms.Label labTimeT;
		public System.Windows.Forms.ComboBox cbMainMode;
		private System.Windows.Forms.TableLayoutPanel tlpChartT;
		private System.Windows.Forms.Label labMaterialT;
		private System.Windows.Forms.Label labTakenT;
		private System.Windows.Forms.TableLayoutPanel tlpChartD;
		private System.Windows.Forms.Label labMaterialD;
		private System.Windows.Forms.Label labTakenD;
	}
}

