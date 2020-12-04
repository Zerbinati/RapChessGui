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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChess));
			this.timerMessages = new System.Windows.Forms.Timer(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageGame = new System.Windows.Forms.TabPage();
			this.chartGame = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.butBackward = new System.Windows.Forms.Button();
			this.butForward = new System.Windows.Forms.Button();
			this.butResignation = new System.Windows.Forms.Button();
			this.butStop = new System.Windows.Forms.Button();
			this.butContinueGame = new System.Windows.Forms.Button();
			this.butNewGame = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.nudValue = new System.Windows.Forms.NumericUpDown();
			this.cbMode = new System.Windows.Forms.ComboBox();
			this.cbBook = new System.Windows.Forms.ComboBox();
			this.cbEngine = new System.Windows.Forms.ComboBox();
			this.cbComputer = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labAutoElo = new System.Windows.Forms.Label();
			this.labBack = new System.Windows.Forms.Label();
			this.cbColor = new System.Windows.Forms.ComboBox();
			this.tabPageMatch = new System.Windows.Forms.TabPage();
			this.chartMatch = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tlpMatch = new System.Windows.Forms.TableLayoutPanel();
			this.labMatch24 = new System.Windows.Forms.Label();
			this.labMatch23 = new System.Windows.Forms.Label();
			this.labMatch22 = new System.Windows.Forms.Label();
			this.labMatch21 = new System.Windows.Forms.Label();
			this.labMatchPlayer2 = new System.Windows.Forms.Label();
			this.labMatch14 = new System.Windows.Forms.Label();
			this.labMatch13 = new System.Windows.Forms.Label();
			this.labMatch12 = new System.Windows.Forms.Label();
			this.labMatch11 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.labMatchPlayer = new System.Windows.Forms.Label();
			this.labMatchPlayer1 = new System.Windows.Forms.Label();
			this.labMatchGames = new System.Windows.Forms.Label();
			this.butContinueMatch = new System.Windows.Forms.Button();
			this.butNewMatch = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.nudValue2 = new System.Windows.Forms.NumericUpDown();
			this.cbMode2 = new System.Windows.Forms.ComboBox();
			this.cbBook2 = new System.Windows.Forms.ComboBox();
			this.cbEngine2 = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.nudValue1 = new System.Windows.Forms.NumericUpDown();
			this.cbMode1 = new System.Windows.Forms.ComboBox();
			this.cbBook1 = new System.Windows.Forms.ComboBox();
			this.cbEngine1 = new System.Windows.Forms.ComboBox();
			this.tabPageTourE = new System.Windows.Forms.TabPage();
			this.splitContainerTourE = new System.Windows.Forms.SplitContainer();
			this.scTournamentEList = new System.Windows.Forms.SplitContainer();
			this.lvEngine = new System.Windows.Forms.ListView();
			this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvEngineH = new System.Windows.Forms.ListView();
			this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labEngine = new System.Windows.Forms.Label();
			this.chartTournamentE = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.cbTourEBook = new System.Windows.Forms.ComboBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.nudTourE = new System.Windows.Forms.NumericUpDown();
			this.cbTourEMode = new System.Windows.Forms.ComboBox();
			this.butTourEStart = new System.Windows.Forms.Button();
			this.tabPageTourP = new System.Windows.Forms.TabPage();
			this.splitContainerTourP = new System.Windows.Forms.SplitContainer();
			this.scTournamentPList = new System.Windows.Forms.SplitContainer();
			this.lvPlayer = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvPlayerH = new System.Windows.Forms.ListView();
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labPlayer = new System.Windows.Forms.Label();
			this.chartTournamentP = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.butStartTournament = new System.Windows.Forms.Button();
			this.tabPageTraining = new System.Windows.Forms.TabPage();
			this.chartTraining = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.tlpTraining = new System.Windows.Forms.TableLayoutPanel();
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
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.labErrors = new System.Windows.Forms.Label();
			this.labGames = new System.Windows.Forms.Label();
			this.butTraining = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.nudTeacher = new System.Windows.Forms.NumericUpDown();
			this.cbTeacherMode = new System.Windows.Forms.ComboBox();
			this.cbTeacherBook = new System.Windows.Forms.ComboBox();
			this.cbTeacherEngine = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.nudTrained = new System.Windows.Forms.NumericUpDown();
			this.cbTrainedMode = new System.Windows.Forms.ComboBox();
			this.cbTrainedBook = new System.Windows.Forms.ComboBox();
			this.cbTrainedEngine = new System.Windows.Forms.ComboBox();
			this.tabPageEdit = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.clbCastling = new System.Windows.Forms.CheckedListBox();
			this.gbToMove = new System.Windows.Forms.GroupBox();
			this.rbBlack = new System.Windows.Forms.RadioButton();
			this.rbWhite = new System.Windows.Forms.RadioButton();
			this.butEditStart = new System.Windows.Forms.Button();
			this.butDefault = new System.Windows.Forms.Button();
			this.butClearBoard = new System.Windows.Forms.Button();
			this.timerStart = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
			this.programLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enginesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.lastGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lastMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lasstTournamentenginesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lastTournamentplayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.lastErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enginesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labFPS = new System.Windows.Forms.Label();
			this.panMenu = new System.Windows.Forms.Panel();
			this.labError = new System.Windows.Forms.Label();
			this.labEco = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.labTimeD = new System.Windows.Forms.Label();
			this.labEloD = new System.Windows.Forms.Label();
			this.labColorD = new System.Windows.Forms.Label();
			this.labNameD = new System.Windows.Forms.Label();
			this.labEloT = new System.Windows.Forms.Label();
			this.labColorT = new System.Windows.Forms.Label();
			this.labNameT = new System.Windows.Forms.Label();
			this.labEngineW = new System.Windows.Forms.Label();
			this.labWhite = new System.Windows.Forms.Label();
			this.labBookNW = new System.Windows.Forms.Label();
			this.labProtocolW = new System.Windows.Forms.Label();
			this.labTimeT = new System.Windows.Forms.Label();
			this.labTakenT = new System.Windows.Forms.Label();
			this.labMaterialT = new System.Windows.Forms.Label();
			this.labMaterialD = new System.Windows.Forms.Label();
			this.labTakenD = new System.Windows.Forms.Label();
			this.labModeW = new System.Windows.Forms.Label();
			this.labModeB = new System.Windows.Forms.Label();
			this.labProtocolB = new System.Windows.Forms.Label();
			this.labBookNB = new System.Windows.Forms.Label();
			this.labBlack = new System.Windows.Forms.Label();
			this.labEngineB = new System.Windows.Forms.Label();
			this.combMainMode = new System.Windows.Forms.ComboBox();
			this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.labPlayerW = new System.Windows.Forms.Label();
			this.labPlayerB = new System.Windows.Forms.Label();
			this.labPromoB = new System.Windows.Forms.Label();
			this.labPromoN = new System.Windows.Forms.Label();
			this.labPromoQ = new System.Windows.Forms.Label();
			this.labPromoR = new System.Windows.Forms.Label();
			this.labMemoryW = new System.Windows.Forms.Label();
			this.labMemoryB = new System.Windows.Forms.Label();
			this.labColW = new System.Windows.Forms.Label();
			this.labScoreW = new System.Windows.Forms.Label();
			this.labDepthW = new System.Windows.Forms.Label();
			this.labPonderW = new System.Windows.Forms.Label();
			this.labNpsW = new System.Windows.Forms.Label();
			this.labBookCW = new System.Windows.Forms.Label();
			this.labNodesW = new System.Windows.Forms.Label();
			this.labColB = new System.Windows.Forms.Label();
			this.labScoreB = new System.Windows.Forms.Label();
			this.labDepthB = new System.Windows.Forms.Label();
			this.labNodesB = new System.Windows.Forms.Label();
			this.labNpsB = new System.Windows.Forms.Label();
			this.labBookCB = new System.Windows.Forms.Label();
			this.labPonderB = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssMove = new System.Windows.Forms.ToolStripStatusLabel();
			this.tssInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainerBoard = new System.Windows.Forms.SplitContainer();
			this.panBoard = new System.Windows.Forms.Panel();
			this.tlpPromotion = new System.Windows.Forms.TableLayoutPanel();
			this.tlpBoardD = new System.Windows.Forms.TableLayoutPanel();
			this.tlpBoardT = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainerMode = new System.Windows.Forms.SplitContainer();
			this.splitContainerChart = new System.Windows.Forms.SplitContainer();
			this.lvMoves = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.labResult = new System.Windows.Forms.Label();
			this.tlpChartD = new System.Windows.Forms.TableLayoutPanel();
			this.tlpChartT = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
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
			this.tlpBlack = new System.Windows.Forms.TableLayoutPanel();
			this.lastTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.tabPageGame.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartGame)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tabPageMatch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartMatch)).BeginInit();
			this.tlpMatch.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudValue2)).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudValue1)).BeginInit();
			this.tabPageTourE.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTourE)).BeginInit();
			this.splitContainerTourE.Panel1.SuspendLayout();
			this.splitContainerTourE.Panel2.SuspendLayout();
			this.splitContainerTourE.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scTournamentEList)).BeginInit();
			this.scTournamentEList.Panel1.SuspendLayout();
			this.scTournamentEList.Panel2.SuspendLayout();
			this.scTournamentEList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartTournamentE)).BeginInit();
			this.groupBox9.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTourE)).BeginInit();
			this.tabPageTourP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTourP)).BeginInit();
			this.splitContainerTourP.Panel1.SuspendLayout();
			this.splitContainerTourP.Panel2.SuspendLayout();
			this.splitContainerTourP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scTournamentPList)).BeginInit();
			this.scTournamentPList.Panel1.SuspendLayout();
			this.scTournamentPList.Panel2.SuspendLayout();
			this.scTournamentPList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartTournamentP)).BeginInit();
			this.tabPageTraining.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartTraining)).BeginInit();
			this.tlpTraining.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTeacher)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTrained)).BeginInit();
			this.tabPageEdit.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.gbToMove.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.panMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerBoard)).BeginInit();
			this.splitContainerBoard.Panel1.SuspendLayout();
			this.splitContainerBoard.Panel2.SuspendLayout();
			this.splitContainerBoard.SuspendLayout();
			this.panBoard.SuspendLayout();
			this.tlpPromotion.SuspendLayout();
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
			this.tlpChartD.SuspendLayout();
			this.tlpChartT.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMoves)).BeginInit();
			this.splitContainerMoves.Panel1.SuspendLayout();
			this.splitContainerMoves.Panel2.SuspendLayout();
			this.splitContainerMoves.SuspendLayout();
			this.tlpWhite.SuspendLayout();
			this.tlpBlack.SuspendLayout();
			this.SuspendLayout();
			// 
			// timerMessages
			// 
			this.timerMessages.Interval = 10;
			this.timerMessages.Tick += new System.EventHandler(this.Timer1_Tick_1);
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPageGame);
			this.tabControl1.Controls.Add(this.tabPageMatch);
			this.tabControl1.Controls.Add(this.tabPageTourE);
			this.tabControl1.Controls.Add(this.tabPageTourP);
			this.tabControl1.Controls.Add(this.tabPageTraining);
			this.tabControl1.Controls.Add(this.tabPageEdit);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
			this.tabControl1.Location = new System.Drawing.Point(0, 39);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(400, 474);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 9;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPageGame
			// 
			this.tabPageGame.Controls.Add(this.chartGame);
			this.tabPageGame.Controls.Add(this.butBackward);
			this.tabPageGame.Controls.Add(this.butForward);
			this.tabPageGame.Controls.Add(this.butResignation);
			this.tabPageGame.Controls.Add(this.butStop);
			this.tabPageGame.Controls.Add(this.butContinueGame);
			this.tabPageGame.Controls.Add(this.butNewGame);
			this.tabPageGame.Controls.Add(this.groupBox2);
			this.tabPageGame.Controls.Add(this.groupBox1);
			this.tabPageGame.Location = new System.Drawing.Point(4, 5);
			this.tabPageGame.Name = "tabPageGame";
			this.tabPageGame.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageGame.Size = new System.Drawing.Size(392, 465);
			this.tabPageGame.TabIndex = 0;
			this.tabPageGame.Text = "Game";
			// 
			// chartGame
			// 
			this.chartGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chartGame.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea1.AxisX.LabelStyle.Enabled = false;
			chartArea1.AxisX.MajorGrid.Enabled = false;
			chartArea1.AxisX.MajorTickMark.Enabled = false;
			chartArea1.AxisY.IsStartedFromZero = false;
			chartArea1.AxisY.MajorGrid.Enabled = false;
			chartArea1.AxisY.MajorTickMark.Enabled = false;
			chartArea1.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea1.Name = "ChartArea1";
			this.chartGame.ChartAreas.Add(chartArea1);
			this.chartGame.Location = new System.Drawing.Point(3, 359);
			this.chartGame.Name = "chartGame";
			this.chartGame.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.chartGame.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Olive};
			series1.BorderWidth = 4;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.IsVisibleInLegend = false;
			series1.Name = "Series1";
			this.chartGame.Series.Add(series1);
			this.chartGame.Size = new System.Drawing.Size(386, 103);
			this.chartGame.TabIndex = 28;
			this.chartGame.Text = "chart1";
			this.toolTip1.SetToolTip(this.chartGame, "User progress history");
			// 
			// butBackward
			// 
			this.butBackward.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butBackward.Dock = System.Windows.Forms.DockStyle.Top;
			this.butBackward.Location = new System.Drawing.Point(3, 330);
			this.butBackward.Name = "butBackward";
			this.butBackward.Size = new System.Drawing.Size(386, 23);
			this.butBackward.TabIndex = 27;
			this.butBackward.Text = "Back move";
			this.toolTip1.SetToolTip(this.butBackward, "Resignation from further play");
			this.butBackward.UseVisualStyleBackColor = true;
			this.butBackward.Click += new System.EventHandler(this.butBackward_Click);
			// 
			// butForward
			// 
			this.butForward.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butForward.Dock = System.Windows.Forms.DockStyle.Top;
			this.butForward.Location = new System.Drawing.Point(3, 307);
			this.butForward.Name = "butForward";
			this.butForward.Size = new System.Drawing.Size(386, 23);
			this.butForward.TabIndex = 26;
			this.butForward.Text = "Make move";
			this.toolTip1.SetToolTip(this.butForward, "Resignation from further play");
			this.butForward.UseVisualStyleBackColor = true;
			this.butForward.Click += new System.EventHandler(this.butForward_Click);
			// 
			// butResignation
			// 
			this.butResignation.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butResignation.Dock = System.Windows.Forms.DockStyle.Top;
			this.butResignation.Location = new System.Drawing.Point(3, 284);
			this.butResignation.Name = "butResignation";
			this.butResignation.Size = new System.Drawing.Size(386, 23);
			this.butResignation.TabIndex = 25;
			this.butResignation.Text = "Resignation";
			this.toolTip1.SetToolTip(this.butResignation, "Resignation from further play");
			this.butResignation.UseVisualStyleBackColor = true;
			this.butResignation.Click += new System.EventHandler(this.butResignation_Click);
			// 
			// butStop
			// 
			this.butStop.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butStop.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStop.Location = new System.Drawing.Point(3, 261);
			this.butStop.Name = "butStop";
			this.butStop.Size = new System.Drawing.Size(386, 23);
			this.butStop.TabIndex = 24;
			this.butStop.Text = "Stop calculating";
			this.toolTip1.SetToolTip(this.butStop, "Engine stop calculating and makes a move immediately");
			this.butStop.UseVisualStyleBackColor = true;
			this.butStop.Click += new System.EventHandler(this.ButStop_Click);
			// 
			// butContinueGame
			// 
			this.butContinueGame.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butContinueGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.butContinueGame.Location = new System.Drawing.Point(3, 238);
			this.butContinueGame.Name = "butContinueGame";
			this.butContinueGame.Size = new System.Drawing.Size(386, 23);
			this.butContinueGame.TabIndex = 23;
			this.butContinueGame.Text = "Continue game";
			this.toolTip1.SetToolTip(this.butContinueGame, "Continue game with current position");
			this.butContinueGame.UseVisualStyleBackColor = true;
			this.butContinueGame.Click += new System.EventHandler(this.butContinueGame_Click);
			// 
			// butNewGame
			// 
			this.butNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butNewGame.Dock = System.Windows.Forms.DockStyle.Top;
			this.butNewGame.Location = new System.Drawing.Point(3, 215);
			this.butNewGame.Name = "butNewGame";
			this.butNewGame.Size = new System.Drawing.Size(386, 23);
			this.butNewGame.TabIndex = 20;
			this.butNewGame.Text = "New game";
			this.toolTip1.SetToolTip(this.butNewGame, "Start new game");
			this.butNewGame.UseVisualStyleBackColor = true;
			this.butNewGame.Click += new System.EventHandler(this.ButStart_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.nudValue);
			this.groupBox2.Controls.Add(this.cbMode);
			this.groupBox2.Controls.Add(this.cbBook);
			this.groupBox2.Controls.Add(this.cbEngine);
			this.groupBox2.Controls.Add(this.cbComputer);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(3, 84);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(386, 131);
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
			this.nudValue.Size = new System.Drawing.Size(380, 20);
			this.nudValue.TabIndex = 50;
			this.nudValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudValue.ThousandsSeparator = true;
			this.nudValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudValue.ValueChanged += new System.EventHandler(this.nudValue_ValueChanged);
			this.nudValue.Click += new System.EventHandler(this.nudValue_Click);
			// 
			// cbMode
			// 
			this.cbMode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMode.FormattingEnabled = true;
			this.cbMode.Items.AddRange(new object[] {
            "Depth",
            "Infinite",
            "Nodes",
            "Standard",
            "Time"});
			this.cbMode.Location = new System.Drawing.Point(3, 79);
			this.cbMode.Name = "cbMode";
			this.cbMode.Size = new System.Drawing.Size(380, 21);
			this.cbMode.Sorted = true;
			this.cbMode.TabIndex = 47;
			this.toolTip1.SetToolTip(this.cbMode, "Select engine mode");
			this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
			this.cbMode.Click += new System.EventHandler(this.cbEngine_Click);
			// 
			// cbBook
			// 
			this.cbBook.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbBook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBook.FormattingEnabled = true;
			this.cbBook.Location = new System.Drawing.Point(3, 58);
			this.cbBook.Name = "cbBook";
			this.cbBook.Size = new System.Drawing.Size(380, 21);
			this.cbBook.Sorted = true;
			this.cbBook.TabIndex = 49;
			this.toolTip1.SetToolTip(this.cbBook, "Select engine book");
			this.cbBook.Click += new System.EventHandler(this.cbEngine_Click);
			// 
			// cbEngine
			// 
			this.cbEngine.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEngine.FormattingEnabled = true;
			this.cbEngine.Location = new System.Drawing.Point(3, 37);
			this.cbEngine.Name = "cbEngine";
			this.cbEngine.Size = new System.Drawing.Size(380, 21);
			this.cbEngine.Sorted = true;
			this.cbEngine.TabIndex = 46;
			this.toolTip1.SetToolTip(this.cbEngine, "Select engine");
			this.cbEngine.Click += new System.EventHandler(this.cbEngine_Click);
			// 
			// cbComputer
			// 
			this.cbComputer.AccessibleDescription = "";
			this.cbComputer.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbComputer.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbComputer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbComputer.FormattingEnabled = true;
			this.cbComputer.Items.AddRange(new object[] {
            "Auto",
            "Custom",
            "Human"});
			this.cbComputer.Location = new System.Drawing.Point(3, 16);
			this.cbComputer.Name = "cbComputer";
			this.cbComputer.Size = new System.Drawing.Size(380, 21);
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
			this.groupBox1.Size = new System.Drawing.Size(386, 81);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Human color";
			// 
			// labAutoElo
			// 
			this.labAutoElo.Dock = System.Windows.Forms.DockStyle.Top;
			this.labAutoElo.ForeColor = System.Drawing.Color.White;
			this.labAutoElo.Location = new System.Drawing.Point(3, 58);
			this.labAutoElo.Name = "labAutoElo";
			this.labAutoElo.Size = new System.Drawing.Size(380, 21);
			this.labAutoElo.TabIndex = 31;
			this.labAutoElo.Text = "Auto Elo On";
			this.labAutoElo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labBack
			// 
			this.labBack.Dock = System.Windows.Forms.DockStyle.Top;
			this.labBack.Location = new System.Drawing.Point(3, 37);
			this.labBack.Name = "labBack";
			this.labBack.Size = new System.Drawing.Size(380, 21);
			this.labBack.TabIndex = 30;
			this.labBack.Text = "Back 0";
			this.labBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbColor
			// 
			this.cbColor.AutoCompleteCustomSource.AddRange(new string[] {
            "White",
            "Black"});
			this.cbColor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbColor.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbColor.Items.AddRange(new object[] {
            "Auto",
            "White",
            "Black"});
			this.cbColor.Location = new System.Drawing.Point(3, 16);
			this.cbColor.Name = "cbColor";
			this.cbColor.Size = new System.Drawing.Size(380, 21);
			this.cbColor.TabIndex = 2;
			this.toolTip1.SetToolTip(this.cbColor, "Select human color");
			this.cbColor.SelectedIndexChanged += new System.EventHandler(this.cbColor_SelectedIndexChanged);
			// 
			// tabPageMatch
			// 
			this.tabPageMatch.Controls.Add(this.chartMatch);
			this.tabPageMatch.Controls.Add(this.tlpMatch);
			this.tabPageMatch.Controls.Add(this.labMatchGames);
			this.tabPageMatch.Controls.Add(this.butContinueMatch);
			this.tabPageMatch.Controls.Add(this.butNewMatch);
			this.tabPageMatch.Controls.Add(this.groupBox6);
			this.tabPageMatch.Controls.Add(this.groupBox5);
			this.tabPageMatch.Location = new System.Drawing.Point(4, 5);
			this.tabPageMatch.Name = "tabPageMatch";
			this.tabPageMatch.Size = new System.Drawing.Size(392, 465);
			this.tabPageMatch.TabIndex = 2;
			this.tabPageMatch.Text = "Match";
			this.tabPageMatch.UseVisualStyleBackColor = true;
			// 
			// chartMatch
			// 
			this.chartMatch.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea2.AxisX.LabelStyle.Enabled = false;
			chartArea2.AxisX.MajorGrid.Enabled = false;
			chartArea2.AxisX.MajorTickMark.Enabled = false;
			chartArea2.AxisY.IsStartedFromZero = false;
			chartArea2.AxisY.MajorGrid.Enabled = false;
			chartArea2.AxisY.MajorTickMark.Enabled = false;
			chartArea2.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea2.Name = "ChartArea1";
			this.chartMatch.ChartAreas.Add(chartArea2);
			this.chartMatch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartMatch.Location = new System.Drawing.Point(0, 386);
			this.chartMatch.Name = "chartMatch";
			this.chartMatch.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.chartMatch.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Olive};
			series2.BorderWidth = 4;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.IsVisibleInLegend = false;
			series2.Name = "Series1";
			this.chartMatch.Series.Add(series2);
			this.chartMatch.Size = new System.Drawing.Size(392, 79);
			this.chartMatch.TabIndex = 29;
			this.chartMatch.Text = "chart1";
			this.toolTip1.SetToolTip(this.chartMatch, "User progress history");
			// 
			// tlpMatch
			// 
			this.tlpMatch.BackColor = System.Drawing.Color.White;
			this.tlpMatch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tlpMatch.ColumnCount = 5;
			this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpMatch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpMatch.Controls.Add(this.labMatch24, 4, 2);
			this.tlpMatch.Controls.Add(this.labMatch23, 3, 2);
			this.tlpMatch.Controls.Add(this.labMatch22, 2, 2);
			this.tlpMatch.Controls.Add(this.labMatch21, 1, 2);
			this.tlpMatch.Controls.Add(this.labMatchPlayer2, 0, 2);
			this.tlpMatch.Controls.Add(this.labMatch14, 4, 1);
			this.tlpMatch.Controls.Add(this.labMatch13, 3, 1);
			this.tlpMatch.Controls.Add(this.labMatch12, 2, 1);
			this.tlpMatch.Controls.Add(this.labMatch11, 1, 1);
			this.tlpMatch.Controls.Add(this.label26, 4, 0);
			this.tlpMatch.Controls.Add(this.label27, 3, 0);
			this.tlpMatch.Controls.Add(this.label28, 2, 0);
			this.tlpMatch.Controls.Add(this.label29, 1, 0);
			this.tlpMatch.Controls.Add(this.labMatchPlayer, 0, 0);
			this.tlpMatch.Controls.Add(this.labMatchPlayer1, 0, 1);
			this.tlpMatch.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpMatch.Location = new System.Drawing.Point(0, 286);
			this.tlpMatch.Name = "tlpMatch";
			this.tlpMatch.RowCount = 3;
			this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.31313F));
			this.tlpMatch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
			this.tlpMatch.Size = new System.Drawing.Size(392, 100);
			this.tlpMatch.TabIndex = 26;
			this.tlpMatch.Resize += new System.EventHandler(this.tlp_Resize);
			// 
			// labMatch24
			// 
			this.labMatch24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch24.BackColor = System.Drawing.Color.Transparent;
			this.labMatch24.Location = new System.Drawing.Point(316, 63);
			this.labMatch24.Name = "labMatch24";
			this.labMatch24.Size = new System.Drawing.Size(72, 36);
			this.labMatch24.TabIndex = 14;
			this.labMatch24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch23
			// 
			this.labMatch23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch23.BackColor = System.Drawing.Color.Transparent;
			this.labMatch23.Location = new System.Drawing.Point(238, 63);
			this.labMatch23.Name = "labMatch23";
			this.labMatch23.Size = new System.Drawing.Size(71, 36);
			this.labMatch23.TabIndex = 13;
			this.labMatch23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch22
			// 
			this.labMatch22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch22.BackColor = System.Drawing.Color.Transparent;
			this.labMatch22.Location = new System.Drawing.Point(160, 63);
			this.labMatch22.Name = "labMatch22";
			this.labMatch22.Size = new System.Drawing.Size(71, 36);
			this.labMatch22.TabIndex = 12;
			this.labMatch22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch21
			// 
			this.labMatch21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch21.BackColor = System.Drawing.Color.Transparent;
			this.labMatch21.Location = new System.Drawing.Point(82, 63);
			this.labMatch21.Name = "labMatch21";
			this.labMatch21.Size = new System.Drawing.Size(71, 36);
			this.labMatch21.TabIndex = 11;
			this.labMatch21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatchPlayer2
			// 
			this.labMatchPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatchPlayer2.BackColor = System.Drawing.Color.Transparent;
			this.labMatchPlayer2.Location = new System.Drawing.Point(4, 63);
			this.labMatchPlayer2.Name = "labMatchPlayer2";
			this.labMatchPlayer2.Size = new System.Drawing.Size(71, 36);
			this.labMatchPlayer2.TabIndex = 10;
			this.labMatchPlayer2.Text = "Player 2";
			this.labMatchPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch14
			// 
			this.labMatch14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch14.BackColor = System.Drawing.Color.Transparent;
			this.labMatch14.Location = new System.Drawing.Point(316, 33);
			this.labMatch14.Name = "labMatch14";
			this.labMatch14.Size = new System.Drawing.Size(72, 29);
			this.labMatch14.TabIndex = 9;
			this.labMatch14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch13
			// 
			this.labMatch13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch13.BackColor = System.Drawing.Color.Transparent;
			this.labMatch13.Location = new System.Drawing.Point(238, 33);
			this.labMatch13.Name = "labMatch13";
			this.labMatch13.Size = new System.Drawing.Size(71, 29);
			this.labMatch13.TabIndex = 8;
			this.labMatch13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch12
			// 
			this.labMatch12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch12.BackColor = System.Drawing.Color.Transparent;
			this.labMatch12.Location = new System.Drawing.Point(160, 33);
			this.labMatch12.Name = "labMatch12";
			this.labMatch12.Size = new System.Drawing.Size(71, 29);
			this.labMatch12.TabIndex = 7;
			this.labMatch12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatch11
			// 
			this.labMatch11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatch11.BackColor = System.Drawing.Color.Transparent;
			this.labMatch11.Location = new System.Drawing.Point(82, 33);
			this.labMatch11.Name = "labMatch11";
			this.labMatch11.Size = new System.Drawing.Size(71, 29);
			this.labMatch11.TabIndex = 6;
			this.labMatch11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label26.BackColor = System.Drawing.Color.Transparent;
			this.label26.Location = new System.Drawing.Point(316, 1);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(72, 31);
			this.label26.TabIndex = 4;
			this.label26.Text = "Result";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label27
			// 
			this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label27.BackColor = System.Drawing.Color.Transparent;
			this.label27.Location = new System.Drawing.Point(238, 1);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(71, 31);
			this.label27.TabIndex = 3;
			this.label27.Text = "Draw";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label28
			// 
			this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label28.BackColor = System.Drawing.Color.Transparent;
			this.label28.Location = new System.Drawing.Point(160, 1);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(71, 31);
			this.label28.TabIndex = 2;
			this.label28.Text = "Loose";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label29
			// 
			this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label29.BackColor = System.Drawing.Color.Transparent;
			this.label29.Location = new System.Drawing.Point(82, 1);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(71, 31);
			this.label29.TabIndex = 1;
			this.label29.Text = "Win";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatchPlayer
			// 
			this.labMatchPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatchPlayer.BackColor = System.Drawing.Color.Transparent;
			this.labMatchPlayer.Location = new System.Drawing.Point(4, 1);
			this.labMatchPlayer.Name = "labMatchPlayer";
			this.labMatchPlayer.Size = new System.Drawing.Size(71, 31);
			this.labMatchPlayer.TabIndex = 0;
			this.labMatchPlayer.Text = "Player";
			this.labMatchPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatchPlayer1
			// 
			this.labMatchPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMatchPlayer1.BackColor = System.Drawing.Color.Transparent;
			this.labMatchPlayer1.Location = new System.Drawing.Point(4, 33);
			this.labMatchPlayer1.Name = "labMatchPlayer1";
			this.labMatchPlayer1.Size = new System.Drawing.Size(71, 29);
			this.labMatchPlayer1.TabIndex = 5;
			this.labMatchPlayer1.Text = "Player 1";
			this.labMatchPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labMatchGames
			// 
			this.labMatchGames.BackColor = System.Drawing.Color.Transparent;
			this.labMatchGames.Dock = System.Windows.Forms.DockStyle.Top;
			this.labMatchGames.Location = new System.Drawing.Point(0, 262);
			this.labMatchGames.Name = "labMatchGames";
			this.labMatchGames.Size = new System.Drawing.Size(392, 24);
			this.labMatchGames.TabIndex = 23;
			this.labMatchGames.Text = "Games 0";
			this.labMatchGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// butContinueMatch
			// 
			this.butContinueMatch.Dock = System.Windows.Forms.DockStyle.Top;
			this.butContinueMatch.Location = new System.Drawing.Point(0, 239);
			this.butContinueMatch.Name = "butContinueMatch";
			this.butContinueMatch.Size = new System.Drawing.Size(392, 23);
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
			this.butNewMatch.Size = new System.Drawing.Size(392, 23);
			this.butNewMatch.TabIndex = 22;
			this.butNewMatch.Text = "New match";
			this.toolTip1.SetToolTip(this.butNewMatch, "Clear old results and start new match");
			this.butNewMatch.UseVisualStyleBackColor = true;
			this.butNewMatch.Click += new System.EventHandler(this.bStartMatch_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.nudValue2);
			this.groupBox6.Controls.Add(this.cbMode2);
			this.groupBox6.Controls.Add(this.cbBook2);
			this.groupBox6.Controls.Add(this.cbEngine2);
			this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox6.Location = new System.Drawing.Point(0, 108);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(392, 108);
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
			this.nudValue2.Size = new System.Drawing.Size(386, 20);
			this.nudValue2.TabIndex = 51;
			this.nudValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudValue2.ThousandsSeparator = true;
			this.nudValue2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbMode2
			// 
			this.cbMode2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbMode2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMode2.FormattingEnabled = true;
			this.cbMode2.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Standard",
            "Time"});
			this.cbMode2.Location = new System.Drawing.Point(3, 58);
			this.cbMode2.Name = "cbMode2";
			this.cbMode2.Size = new System.Drawing.Size(386, 21);
			this.cbMode2.Sorted = true;
			this.cbMode2.TabIndex = 30;
			this.toolTip1.SetToolTip(this.cbMode2, "Select engine mode");
			this.cbMode2.SelectedIndexChanged += new System.EventHandler(this.cbMode2_SelectedIndexChanged);
			// 
			// cbBook2
			// 
			this.cbBook2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBook2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBook2.FormattingEnabled = true;
			this.cbBook2.Location = new System.Drawing.Point(3, 37);
			this.cbBook2.Name = "cbBook2";
			this.cbBook2.Size = new System.Drawing.Size(386, 21);
			this.cbBook2.Sorted = true;
			this.cbBook2.TabIndex = 32;
			this.toolTip1.SetToolTip(this.cbBook2, "Select engine opening book");
			// 
			// cbEngine2
			// 
			this.cbEngine2.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEngine2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEngine2.FormattingEnabled = true;
			this.cbEngine2.Location = new System.Drawing.Point(3, 16);
			this.cbEngine2.Name = "cbEngine2";
			this.cbEngine2.Size = new System.Drawing.Size(386, 21);
			this.cbEngine2.Sorted = true;
			this.cbEngine2.TabIndex = 29;
			this.toolTip1.SetToolTip(this.cbEngine2, "Select engine");
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.nudValue1);
			this.groupBox5.Controls.Add(this.cbMode1);
			this.groupBox5.Controls.Add(this.cbBook1);
			this.groupBox5.Controls.Add(this.cbEngine1);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(0, 0);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(392, 108);
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
			this.nudValue1.Size = new System.Drawing.Size(386, 20);
			this.nudValue1.TabIndex = 51;
			this.nudValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudValue1.ThousandsSeparator = true;
			this.nudValue1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbMode1
			// 
			this.cbMode1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbMode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMode1.FormattingEnabled = true;
			this.cbMode1.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Standard",
            "Time"});
			this.cbMode1.Location = new System.Drawing.Point(3, 58);
			this.cbMode1.Name = "cbMode1";
			this.cbMode1.Size = new System.Drawing.Size(386, 21);
			this.cbMode1.Sorted = true;
			this.cbMode1.TabIndex = 29;
			this.toolTip1.SetToolTip(this.cbMode1, "Select engine mode");
			this.cbMode1.SelectedIndexChanged += new System.EventHandler(this.cbMode1_SelectedIndexChanged);
			// 
			// cbBook1
			// 
			this.cbBook1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbBook1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBook1.FormattingEnabled = true;
			this.cbBook1.Location = new System.Drawing.Point(3, 37);
			this.cbBook1.Name = "cbBook1";
			this.cbBook1.Size = new System.Drawing.Size(386, 21);
			this.cbBook1.Sorted = true;
			this.cbBook1.TabIndex = 31;
			this.toolTip1.SetToolTip(this.cbBook1, "Select engine opening book");
			// 
			// cbEngine1
			// 
			this.cbEngine1.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbEngine1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEngine1.FormattingEnabled = true;
			this.cbEngine1.Location = new System.Drawing.Point(3, 16);
			this.cbEngine1.Name = "cbEngine1";
			this.cbEngine1.Size = new System.Drawing.Size(386, 21);
			this.cbEngine1.Sorted = true;
			this.cbEngine1.TabIndex = 28;
			this.toolTip1.SetToolTip(this.cbEngine1, "Select engine");
			// 
			// tabPageTourE
			// 
			this.tabPageTourE.Controls.Add(this.splitContainerTourE);
			this.tabPageTourE.Controls.Add(this.groupBox9);
			this.tabPageTourE.Controls.Add(this.groupBox8);
			this.tabPageTourE.Controls.Add(this.butTourEStart);
			this.tabPageTourE.Location = new System.Drawing.Point(4, 5);
			this.tabPageTourE.Name = "tabPageTourE";
			this.tabPageTourE.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTourE.Size = new System.Drawing.Size(392, 465);
			this.tabPageTourE.TabIndex = 5;
			this.tabPageTourE.Text = "TourE";
			this.tabPageTourE.UseVisualStyleBackColor = true;
			// 
			// splitContainerTourE
			// 
			this.splitContainerTourE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerTourE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerTourE.Location = new System.Drawing.Point(3, 131);
			this.splitContainerTourE.Name = "splitContainerTourE";
			this.splitContainerTourE.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerTourE.Panel1
			// 
			this.splitContainerTourE.Panel1.Controls.Add(this.scTournamentEList);
			// 
			// splitContainerTourE.Panel2
			// 
			this.splitContainerTourE.Panel2.Controls.Add(this.chartTournamentE);
			this.splitContainerTourE.Size = new System.Drawing.Size(386, 331);
			this.splitContainerTourE.SplitterDistance = 207;
			this.splitContainerTourE.TabIndex = 27;
			// 
			// scTournamentEList
			// 
			this.scTournamentEList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.scTournamentEList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scTournamentEList.Location = new System.Drawing.Point(0, 0);
			this.scTournamentEList.Name = "scTournamentEList";
			this.scTournamentEList.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scTournamentEList.Panel1
			// 
			this.scTournamentEList.Panel1.Controls.Add(this.lvEngine);
			// 
			// scTournamentEList.Panel2
			// 
			this.scTournamentEList.Panel2.Controls.Add(this.lvEngineH);
			this.scTournamentEList.Panel2.Controls.Add(this.labEngine);
			this.scTournamentEList.Size = new System.Drawing.Size(386, 207);
			this.scTournamentEList.SplitterDistance = 102;
			this.scTournamentEList.TabIndex = 24;
			// 
			// lvEngine
			// 
			this.lvEngine.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25});
			this.lvEngine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvEngine.FullRowSelect = true;
			this.lvEngine.GridLines = true;
			this.lvEngine.HideSelection = false;
			this.lvEngine.Location = new System.Drawing.Point(0, 0);
			this.lvEngine.MultiSelect = false;
			this.lvEngine.Name = "lvEngine";
			this.lvEngine.ShowGroups = false;
			this.lvEngine.Size = new System.Drawing.Size(382, 98);
			this.lvEngine.Sorting = System.Windows.Forms.SortOrder.Descending;
			this.lvEngine.TabIndex = 24;
			this.lvEngine.UseCompatibleStateImageBehavior = false;
			this.lvEngine.View = System.Windows.Forms.View.Details;
			this.lvEngine.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
			this.lvEngine.SelectedIndexChanged += new System.EventHandler(this.lvEngine_SelectedIndexChanged);
			this.lvEngine.Resize += new System.EventHandler(this.lvEngine_Resize);
			// 
			// columnHeader23
			// 
			this.columnHeader23.Tag = "";
			this.columnHeader23.Text = "Engine";
			this.columnHeader23.Width = 150;
			// 
			// columnHeader24
			// 
			this.columnHeader24.Tag = "";
			this.columnHeader24.Text = "Elo";
			this.columnHeader24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader24.Width = 80;
			// 
			// columnHeader25
			// 
			this.columnHeader25.Text = "Changes";
			this.columnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lvEngineH
			// 
			this.lvEngineH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29});
			this.lvEngineH.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvEngineH.FullRowSelect = true;
			this.lvEngineH.GridLines = true;
			this.lvEngineH.HideSelection = false;
			this.lvEngineH.Location = new System.Drawing.Point(0, 13);
			this.lvEngineH.MultiSelect = false;
			this.lvEngineH.Name = "lvEngineH";
			this.lvEngineH.ShowGroups = false;
			this.lvEngineH.Size = new System.Drawing.Size(382, 84);
			this.lvEngineH.TabIndex = 28;
			this.lvEngineH.UseCompatibleStateImageBehavior = false;
			this.lvEngineH.View = System.Windows.Forms.View.Details;
			this.lvEngineH.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
			this.lvEngineH.Resize += new System.EventHandler(this.lvEngineH_Resize);
			// 
			// columnHeader26
			// 
			this.columnHeader26.Tag = "";
			this.columnHeader26.Text = "Engine";
			this.columnHeader26.Width = 140;
			// 
			// columnHeader27
			// 
			this.columnHeader27.Text = "Elo";
			this.columnHeader27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader27.Width = 50;
			// 
			// columnHeader28
			// 
			this.columnHeader28.Text = "Games";
			this.columnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader28.Width = 50;
			// 
			// columnHeader29
			// 
			this.columnHeader29.Text = "Score";
			this.columnHeader29.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader29.Width = 50;
			// 
			// labEngine
			// 
			this.labEngine.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.labEngine.Location = new System.Drawing.Point(0, 0);
			this.labEngine.Name = "labEngine";
			this.labEngine.Size = new System.Drawing.Size(382, 13);
			this.labEngine.TabIndex = 29;
			this.labEngine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labEngine, "Select current engine");
			this.labEngine.Click += new System.EventHandler(this.labEngine_Click);
			// 
			// chartTournamentE
			// 
			this.chartTournamentE.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea3.AxisX.LabelStyle.Enabled = false;
			chartArea3.AxisX.MajorGrid.Enabled = false;
			chartArea3.AxisX.MajorTickMark.Enabled = false;
			chartArea3.AxisY.IsStartedFromZero = false;
			chartArea3.AxisY.MajorGrid.Enabled = false;
			chartArea3.AxisY.MajorTickMark.Enabled = false;
			chartArea3.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea3.Name = "ChartArea1";
			this.chartTournamentE.ChartAreas.Add(chartArea3);
			this.chartTournamentE.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartTournamentE.Location = new System.Drawing.Point(0, 0);
			this.chartTournamentE.Name = "chartTournamentE";
			this.chartTournamentE.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.chartTournamentE.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Olive,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))))};
			series3.BorderWidth = 4;
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series3.IsVisibleInLegend = false;
			series3.Name = "Series1";
			series4.BorderWidth = 4;
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series4.IsVisibleInLegend = false;
			series4.Name = "Series2";
			series5.BorderWidth = 4;
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series5.IsVisibleInLegend = false;
			series5.Name = "Series3";
			this.chartTournamentE.Series.Add(series3);
			this.chartTournamentE.Series.Add(series4);
			this.chartTournamentE.Series.Add(series5);
			this.chartTournamentE.Size = new System.Drawing.Size(382, 116);
			this.chartTournamentE.TabIndex = 30;
			this.chartTournamentE.Text = "chart1";
			this.toolTip1.SetToolTip(this.chartTournamentE, "Tournament history");
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.cbTourEBook);
			this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox9.Location = new System.Drawing.Point(3, 87);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(386, 44);
			this.groupBox9.TabIndex = 28;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Opening book";
			// 
			// cbTourEBook
			// 
			this.cbTourEBook.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourEBook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourEBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourEBook.FormattingEnabled = true;
			this.cbTourEBook.Location = new System.Drawing.Point(3, 16);
			this.cbTourEBook.Name = "cbTourEBook";
			this.cbTourEBook.Size = new System.Drawing.Size(380, 21);
			this.cbTourEBook.Sorted = true;
			this.cbTourEBook.TabIndex = 32;
			this.toolTip1.SetToolTip(this.cbTourEBook, "Select engine opening book");
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.nudTourE);
			this.groupBox8.Controls.Add(this.cbTourEMode);
			this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox8.Location = new System.Drawing.Point(3, 26);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(386, 61);
			this.groupBox8.TabIndex = 23;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Time control";
			// 
			// nudTourE
			// 
			this.nudTourE.Dock = System.Windows.Forms.DockStyle.Top;
			this.nudTourE.Location = new System.Drawing.Point(3, 37);
			this.nudTourE.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.nudTourE.Name = "nudTourE";
			this.nudTourE.Size = new System.Drawing.Size(380, 20);
			this.nudTourE.TabIndex = 51;
			this.nudTourE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTourE.ThousandsSeparator = true;
			this.nudTourE.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbTourEMode
			// 
			this.cbTourEMode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTourEMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTourEMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTourEMode.FormattingEnabled = true;
			this.cbTourEMode.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Standard",
            "Time"});
			this.cbTourEMode.Location = new System.Drawing.Point(3, 16);
			this.cbTourEMode.Name = "cbTourEMode";
			this.cbTourEMode.Size = new System.Drawing.Size(380, 21);
			this.cbTourEMode.Sorted = true;
			this.cbTourEMode.TabIndex = 29;
			this.toolTip1.SetToolTip(this.cbTourEMode, "Select engine mode");
			this.cbTourEMode.SelectedIndexChanged += new System.EventHandler(this.cbTourEMode_SelectedIndexChanged);
			// 
			// butTourEStart
			// 
			this.butTourEStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butTourEStart.Dock = System.Windows.Forms.DockStyle.Top;
			this.butTourEStart.Location = new System.Drawing.Point(3, 3);
			this.butTourEStart.Name = "butTourEStart";
			this.butTourEStart.Size = new System.Drawing.Size(386, 23);
			this.butTourEStart.TabIndex = 22;
			this.butTourEStart.Text = "Start";
			this.toolTip1.SetToolTip(this.butTourEStart, "Start tournament");
			this.butTourEStart.UseVisualStyleBackColor = true;
			this.butTourEStart.Click += new System.EventHandler(this.butStartTournamentE_Click);
			// 
			// tabPageTourP
			// 
			this.tabPageTourP.Controls.Add(this.splitContainerTourP);
			this.tabPageTourP.Controls.Add(this.butStartTournament);
			this.tabPageTourP.Location = new System.Drawing.Point(4, 5);
			this.tabPageTourP.Name = "tabPageTourP";
			this.tabPageTourP.Size = new System.Drawing.Size(392, 465);
			this.tabPageTourP.TabIndex = 3;
			this.tabPageTourP.Text = "TourP";
			this.tabPageTourP.UseVisualStyleBackColor = true;
			// 
			// splitContainerTourP
			// 
			this.splitContainerTourP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerTourP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerTourP.Location = new System.Drawing.Point(0, 23);
			this.splitContainerTourP.Name = "splitContainerTourP";
			this.splitContainerTourP.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerTourP.Panel1
			// 
			this.splitContainerTourP.Panel1.Controls.Add(this.scTournamentPList);
			// 
			// splitContainerTourP.Panel2
			// 
			this.splitContainerTourP.Panel2.Controls.Add(this.chartTournamentP);
			this.splitContainerTourP.Size = new System.Drawing.Size(392, 442);
			this.splitContainerTourP.SplitterDistance = 289;
			this.splitContainerTourP.TabIndex = 26;
			// 
			// scTournamentPList
			// 
			this.scTournamentPList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.scTournamentPList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scTournamentPList.Location = new System.Drawing.Point(0, 0);
			this.scTournamentPList.Name = "scTournamentPList";
			this.scTournamentPList.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scTournamentPList.Panel1
			// 
			this.scTournamentPList.Panel1.Controls.Add(this.lvPlayer);
			// 
			// scTournamentPList.Panel2
			// 
			this.scTournamentPList.Panel2.Controls.Add(this.lvPlayerH);
			this.scTournamentPList.Panel2.Controls.Add(this.labPlayer);
			this.scTournamentPList.Size = new System.Drawing.Size(392, 289);
			this.scTournamentPList.SplitterDistance = 170;
			this.scTournamentPList.TabIndex = 24;
			// 
			// lvPlayer
			// 
			this.lvPlayer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader6});
			this.lvPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvPlayer.FullRowSelect = true;
			this.lvPlayer.GridLines = true;
			this.lvPlayer.HideSelection = false;
			this.lvPlayer.Location = new System.Drawing.Point(0, 0);
			this.lvPlayer.MultiSelect = false;
			this.lvPlayer.Name = "lvPlayer";
			this.lvPlayer.ShowGroups = false;
			this.lvPlayer.Size = new System.Drawing.Size(388, 166);
			this.lvPlayer.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvPlayer.TabIndex = 24;
			this.lvPlayer.UseCompatibleStateImageBehavior = false;
			this.lvPlayer.View = System.Windows.Forms.View.Details;
			this.lvPlayer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
			this.lvPlayer.SelectedIndexChanged += new System.EventHandler(this.lvPlayer_SelectedIndexChanged);
			this.lvPlayer.Resize += new System.EventHandler(this.lvEngine_Resize);
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
			// lvPlayerH
			// 
			this.lvPlayerH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader8,
            this.columnHeader10});
			this.lvPlayerH.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvPlayerH.FullRowSelect = true;
			this.lvPlayerH.GridLines = true;
			this.lvPlayerH.HideSelection = false;
			this.lvPlayerH.Location = new System.Drawing.Point(0, 13);
			this.lvPlayerH.MultiSelect = false;
			this.lvPlayerH.Name = "lvPlayerH";
			this.lvPlayerH.ShowGroups = false;
			this.lvPlayerH.Size = new System.Drawing.Size(388, 98);
			this.lvPlayerH.TabIndex = 28;
			this.lvPlayerH.UseCompatibleStateImageBehavior = false;
			this.lvPlayerH.View = System.Windows.Forms.View.Details;
			this.lvPlayerH.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ColumnClick);
			this.lvPlayerH.Resize += new System.EventHandler(this.lvEngineH_Resize);
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
			// labPlayer
			// 
			this.labPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labPlayer.Dock = System.Windows.Forms.DockStyle.Top;
			this.labPlayer.Location = new System.Drawing.Point(0, 0);
			this.labPlayer.Name = "labPlayer";
			this.labPlayer.Size = new System.Drawing.Size(388, 13);
			this.labPlayer.TabIndex = 27;
			this.labPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPlayer, "Select current player");
			this.labPlayer.Click += new System.EventHandler(this.labPlayer_Click);
			// 
			// chartTournamentP
			// 
			this.chartTournamentP.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea4.AxisX.LabelStyle.Enabled = false;
			chartArea4.AxisX.MajorGrid.Enabled = false;
			chartArea4.AxisX.MajorTickMark.Enabled = false;
			chartArea4.AxisY.IsStartedFromZero = false;
			chartArea4.AxisY.MajorGrid.Enabled = false;
			chartArea4.AxisY.MajorTickMark.Enabled = false;
			chartArea4.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea4.Name = "ChartArea1";
			this.chartTournamentP.ChartAreas.Add(chartArea4);
			this.chartTournamentP.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartTournamentP.Location = new System.Drawing.Point(0, 0);
			this.chartTournamentP.Name = "chartTournamentP";
			this.chartTournamentP.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.chartTournamentP.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Olive,
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))))};
			series6.BorderWidth = 4;
			series6.ChartArea = "ChartArea1";
			series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series6.IsVisibleInLegend = false;
			series6.Name = "Series1";
			series7.BorderWidth = 4;
			series7.ChartArea = "ChartArea1";
			series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series7.IsVisibleInLegend = false;
			series7.Name = "Series2";
			series8.BorderWidth = 4;
			series8.ChartArea = "ChartArea1";
			series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series8.IsVisibleInLegend = false;
			series8.Name = "Series3";
			this.chartTournamentP.Series.Add(series6);
			this.chartTournamentP.Series.Add(series7);
			this.chartTournamentP.Series.Add(series8);
			this.chartTournamentP.Size = new System.Drawing.Size(388, 145);
			this.chartTournamentP.TabIndex = 31;
			this.chartTournamentP.Text = "chart1";
			this.toolTip1.SetToolTip(this.chartTournamentP, "Tournament history");
			// 
			// butStartTournament
			// 
			this.butStartTournament.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butStartTournament.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStartTournament.Location = new System.Drawing.Point(0, 0);
			this.butStartTournament.Name = "butStartTournament";
			this.butStartTournament.Size = new System.Drawing.Size(392, 23);
			this.butStartTournament.TabIndex = 21;
			this.butStartTournament.Text = "Start";
			this.toolTip1.SetToolTip(this.butStartTournament, "Start tournament");
			this.butStartTournament.UseVisualStyleBackColor = true;
			this.butStartTournament.Click += new System.EventHandler(this.butStartTournamentP_Click);
			// 
			// tabPageTraining
			// 
			this.tabPageTraining.Controls.Add(this.chartTraining);
			this.tabPageTraining.Controls.Add(this.tlpTraining);
			this.tabPageTraining.Controls.Add(this.tableLayoutPanel3);
			this.tabPageTraining.Controls.Add(this.butTraining);
			this.tabPageTraining.Controls.Add(this.groupBox4);
			this.tabPageTraining.Controls.Add(this.groupBox3);
			this.tabPageTraining.Location = new System.Drawing.Point(4, 5);
			this.tabPageTraining.Name = "tabPageTraining";
			this.tabPageTraining.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageTraining.Size = new System.Drawing.Size(392, 465);
			this.tabPageTraining.TabIndex = 1;
			this.tabPageTraining.Text = "Training";
			this.tabPageTraining.UseVisualStyleBackColor = true;
			// 
			// chartTraining
			// 
			this.chartTraining.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea5.AxisX.LabelStyle.Enabled = false;
			chartArea5.AxisX.MajorGrid.Enabled = false;
			chartArea5.AxisX.MajorTickMark.Enabled = false;
			chartArea5.AxisY.MajorGrid.Enabled = false;
			chartArea5.AxisY.MajorTickMark.Enabled = false;
			chartArea5.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea5.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea5.Name = "ChartArea1";
			this.chartTraining.ChartAreas.Add(chartArea5);
			this.chartTraining.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartTraining.Location = new System.Drawing.Point(3, 373);
			this.chartTraining.Name = "chartTraining";
			this.chartTraining.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.chartTraining.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Olive};
			series9.BorderWidth = 4;
			series9.ChartArea = "ChartArea1";
			series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series9.IsVisibleInLegend = false;
			series9.Name = "Series1";
			this.chartTraining.Series.Add(series9);
			this.chartTraining.Size = new System.Drawing.Size(386, 89);
			this.chartTraining.TabIndex = 29;
			this.chartTraining.Text = "chart1";
			this.toolTip1.SetToolTip(this.chartTraining, "Training history");
			// 
			// tlpTraining
			// 
			this.tlpTraining.BackColor = System.Drawing.Color.White;
			this.tlpTraining.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tlpTraining.ColumnCount = 5;
			this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpTraining.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tlpTraining.Controls.Add(this.label15, 4, 2);
			this.tlpTraining.Controls.Add(this.label14, 3, 2);
			this.tlpTraining.Controls.Add(this.label13, 2, 2);
			this.tlpTraining.Controls.Add(this.label12, 1, 2);
			this.tlpTraining.Controls.Add(this.label11, 0, 2);
			this.tlpTraining.Controls.Add(this.label10, 4, 1);
			this.tlpTraining.Controls.Add(this.label9, 3, 1);
			this.tlpTraining.Controls.Add(this.label8, 2, 1);
			this.tlpTraining.Controls.Add(this.label7, 1, 1);
			this.tlpTraining.Controls.Add(this.label5, 4, 0);
			this.tlpTraining.Controls.Add(this.label4, 3, 0);
			this.tlpTraining.Controls.Add(this.label3, 2, 0);
			this.tlpTraining.Controls.Add(this.label2, 1, 0);
			this.tlpTraining.Controls.Add(this.label6, 0, 0);
			this.tlpTraining.Controls.Add(this.label16, 0, 1);
			this.tlpTraining.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpTraining.Location = new System.Drawing.Point(3, 272);
			this.tlpTraining.Name = "tlpTraining";
			this.tlpTraining.RowCount = 3;
			this.tlpTraining.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpTraining.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpTraining.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpTraining.Size = new System.Drawing.Size(386, 101);
			this.tlpTraining.TabIndex = 25;
			this.tlpTraining.Resize += new System.EventHandler(this.tlp_Resize);
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.Location = new System.Drawing.Point(312, 67);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(70, 33);
			this.label15.TabIndex = 14;
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.Location = new System.Drawing.Point(235, 67);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(70, 33);
			this.label14.TabIndex = 13;
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.Location = new System.Drawing.Point(158, 67);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(70, 33);
			this.label13.TabIndex = 12;
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.Location = new System.Drawing.Point(81, 67);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(70, 33);
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
			this.label11.Size = new System.Drawing.Size(70, 33);
			this.label11.TabIndex = 10;
			this.label11.Text = "Teacher";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label10.Location = new System.Drawing.Point(312, 34);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(70, 32);
			this.label10.TabIndex = 9;
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.Location = new System.Drawing.Point(235, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(70, 32);
			this.label9.TabIndex = 8;
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(158, 34);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(70, 32);
			this.label8.TabIndex = 7;
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point(81, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 32);
			this.label7.TabIndex = 6;
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(312, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 32);
			this.label5.TabIndex = 4;
			this.label5.Text = "Result";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(235, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 32);
			this.label4.TabIndex = 3;
			this.label4.Text = "Draw";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(158, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 32);
			this.label3.TabIndex = 2;
			this.label3.Text = "Loose";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(81, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 32);
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
			this.label6.Size = new System.Drawing.Size(70, 32);
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
			this.label16.Size = new System.Drawing.Size(70, 32);
			this.label16.TabIndex = 5;
			this.label16.Text = "Trained";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.labErrors, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.labGames, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 236);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(386, 36);
			this.tableLayoutPanel3.TabIndex = 26;
			// 
			// labErrors
			// 
			this.labErrors.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labErrors.Location = new System.Drawing.Point(196, 0);
			this.labErrors.Name = "labErrors";
			this.labErrors.Size = new System.Drawing.Size(187, 36);
			this.labErrors.TabIndex = 24;
			this.labErrors.Text = "Errors 0";
			this.labErrors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labErrors, "The number of wrong moves and time out");
			// 
			// labGames
			// 
			this.labGames.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labGames.Location = new System.Drawing.Point(3, 0);
			this.labGames.Name = "labGames";
			this.labGames.Size = new System.Drawing.Size(187, 36);
			this.labGames.TabIndex = 23;
			this.labGames.Text = "Games 0";
			this.labGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labGames, "Count played games");
			// 
			// butTraining
			// 
			this.butTraining.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butTraining.Dock = System.Windows.Forms.DockStyle.Top;
			this.butTraining.Location = new System.Drawing.Point(3, 213);
			this.butTraining.Name = "butTraining";
			this.butTraining.Size = new System.Drawing.Size(386, 23);
			this.butTraining.TabIndex = 21;
			this.butTraining.Text = "Start";
			this.toolTip1.SetToolTip(this.butTraining, "Start training");
			this.butTraining.UseVisualStyleBackColor = true;
			this.butTraining.Click += new System.EventHandler(this.ButTraining_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.nudTeacher);
			this.groupBox4.Controls.Add(this.cbTeacherMode);
			this.groupBox4.Controls.Add(this.cbTeacherBook);
			this.groupBox4.Controls.Add(this.cbTeacherEngine);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new System.Drawing.Point(3, 108);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(386, 105);
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
			this.nudTeacher.Size = new System.Drawing.Size(380, 20);
			this.nudTeacher.TabIndex = 28;
			this.nudTeacher.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTeacher.ThousandsSeparator = true;
			this.nudTeacher.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbTeacherMode
			// 
			this.cbTeacherMode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTeacherMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTeacherMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeacherMode.FormattingEnabled = true;
			this.cbTeacherMode.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Standard",
            "Time"});
			this.cbTeacherMode.Location = new System.Drawing.Point(3, 58);
			this.cbTeacherMode.Name = "cbTeacherMode";
			this.cbTeacherMode.Size = new System.Drawing.Size(380, 21);
			this.cbTeacherMode.Sorted = true;
			this.cbTeacherMode.TabIndex = 30;
			this.toolTip1.SetToolTip(this.cbTeacherMode, "Select mode");
			this.cbTeacherMode.SelectedIndexChanged += new System.EventHandler(this.cbTeacherMode_SelectedIndexChanged);
			// 
			// cbTeacherBook
			// 
			this.cbTeacherBook.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTeacherBook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTeacherBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeacherBook.FormattingEnabled = true;
			this.cbTeacherBook.Location = new System.Drawing.Point(3, 37);
			this.cbTeacherBook.Name = "cbTeacherBook";
			this.cbTeacherBook.Size = new System.Drawing.Size(380, 21);
			this.cbTeacherBook.Sorted = true;
			this.cbTeacherBook.TabIndex = 26;
			this.toolTip1.SetToolTip(this.cbTeacherBook, "Select chess opening book");
			// 
			// cbTeacherEngine
			// 
			this.cbTeacherEngine.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTeacherEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTeacherEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTeacherEngine.Location = new System.Drawing.Point(3, 16);
			this.cbTeacherEngine.Name = "cbTeacherEngine";
			this.cbTeacherEngine.Size = new System.Drawing.Size(380, 21);
			this.cbTeacherEngine.Sorted = true;
			this.cbTeacherEngine.TabIndex = 2;
			this.toolTip1.SetToolTip(this.cbTeacherEngine, "Select engine");
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.nudTrained);
			this.groupBox3.Controls.Add(this.cbTrainedMode);
			this.groupBox3.Controls.Add(this.cbTrainedBook);
			this.groupBox3.Controls.Add(this.cbTrainedEngine);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(3, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(386, 105);
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
			this.nudTrained.Size = new System.Drawing.Size(380, 20);
			this.nudTrained.TabIndex = 27;
			this.nudTrained.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.nudTrained.ThousandsSeparator = true;
			this.nudTrained.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// cbTrainedMode
			// 
			this.cbTrainedMode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTrainedMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTrainedMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrainedMode.FormattingEnabled = true;
			this.cbTrainedMode.Items.AddRange(new object[] {
            "Depth",
            "Nodes",
            "Standard",
            "Time"});
			this.cbTrainedMode.Location = new System.Drawing.Point(3, 58);
			this.cbTrainedMode.Name = "cbTrainedMode";
			this.cbTrainedMode.Size = new System.Drawing.Size(380, 21);
			this.cbTrainedMode.Sorted = true;
			this.cbTrainedMode.TabIndex = 30;
			this.toolTip1.SetToolTip(this.cbTrainedMode, "Select mode");
			this.cbTrainedMode.SelectedIndexChanged += new System.EventHandler(this.cbTrainedMode_SelectedIndexChanged);
			// 
			// cbTrainedBook
			// 
			this.cbTrainedBook.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTrainedBook.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTrainedBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrainedBook.FormattingEnabled = true;
			this.cbTrainedBook.Location = new System.Drawing.Point(3, 37);
			this.cbTrainedBook.Name = "cbTrainedBook";
			this.cbTrainedBook.Size = new System.Drawing.Size(380, 21);
			this.cbTrainedBook.Sorted = true;
			this.cbTrainedBook.TabIndex = 29;
			this.toolTip1.SetToolTip(this.cbTrainedBook, "Select chess opening book");
			// 
			// cbTrainedEngine
			// 
			this.cbTrainedEngine.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbTrainedEngine.Dock = System.Windows.Forms.DockStyle.Top;
			this.cbTrainedEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrainedEngine.Location = new System.Drawing.Point(3, 16);
			this.cbTrainedEngine.Name = "cbTrainedEngine";
			this.cbTrainedEngine.Size = new System.Drawing.Size(380, 21);
			this.cbTrainedEngine.Sorted = true;
			this.cbTrainedEngine.TabIndex = 2;
			this.toolTip1.SetToolTip(this.cbTrainedEngine, "Select engine");
			// 
			// tabPageEdit
			// 
			this.tabPageEdit.BackColor = System.Drawing.Color.Transparent;
			this.tabPageEdit.Controls.Add(this.groupBox7);
			this.tabPageEdit.Controls.Add(this.gbToMove);
			this.tabPageEdit.Controls.Add(this.butEditStart);
			this.tabPageEdit.Controls.Add(this.butDefault);
			this.tabPageEdit.Controls.Add(this.butClearBoard);
			this.tabPageEdit.Location = new System.Drawing.Point(4, 5);
			this.tabPageEdit.Name = "tabPageEdit";
			this.tabPageEdit.Size = new System.Drawing.Size(392, 465);
			this.tabPageEdit.TabIndex = 4;
			this.tabPageEdit.Text = "Edit";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.clbCastling);
			this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox7.Location = new System.Drawing.Point(0, 128);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(392, 84);
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
			this.clbCastling.Size = new System.Drawing.Size(386, 65);
			this.clbCastling.TabIndex = 0;
			this.clbCastling.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCastling_ItemCheck);
			// 
			// gbToMove
			// 
			this.gbToMove.Controls.Add(this.rbBlack);
			this.gbToMove.Controls.Add(this.rbWhite);
			this.gbToMove.Dock = System.Windows.Forms.DockStyle.Top;
			this.gbToMove.Location = new System.Drawing.Point(0, 75);
			this.gbToMove.Name = "gbToMove";
			this.gbToMove.Size = new System.Drawing.Size(392, 53);
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
			this.rbBlack.Size = new System.Drawing.Size(386, 17);
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
			this.rbWhite.Size = new System.Drawing.Size(386, 17);
			this.rbWhite.TabIndex = 0;
			this.rbWhite.TabStop = true;
			this.rbWhite.Text = "White";
			this.rbWhite.UseVisualStyleBackColor = true;
			this.rbWhite.CheckedChanged += new System.EventHandler(this.rbColorChanged);
			// 
			// butEditStart
			// 
			this.butEditStart.Dock = System.Windows.Forms.DockStyle.Top;
			this.butEditStart.Location = new System.Drawing.Point(0, 50);
			this.butEditStart.Name = "butEditStart";
			this.butEditStart.Size = new System.Drawing.Size(392, 25);
			this.butEditStart.TabIndex = 4;
			this.butEditStart.Text = "Start";
			this.toolTip1.SetToolTip(this.butEditStart, "Start new game from current position");
			this.butEditStart.UseVisualStyleBackColor = true;
			this.butEditStart.Click += new System.EventHandler(this.butEditStart_Click);
			// 
			// butDefault
			// 
			this.butDefault.Dock = System.Windows.Forms.DockStyle.Top;
			this.butDefault.Location = new System.Drawing.Point(0, 25);
			this.butDefault.Name = "butDefault";
			this.butDefault.Size = new System.Drawing.Size(392, 25);
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
			this.butClearBoard.Size = new System.Drawing.Size(392, 25);
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
            this.fenToolStripMenuItem,
            this.pgnToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.logToolStripMenuItem,
            this.historyToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 2);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.ShowItemToolTips = true;
			this.menuStrip1.Size = new System.Drawing.Size(310, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
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
			this.loadFromClipboardToolStripMenuItem1.Click += new System.EventHandler(this.loadPgnFromClipboard_Click);
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
			this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programLogToolStripMenuItem,
            this.gamesToolStripMenuItem,
            this.enginesToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.lastGameToolStripMenuItem,
            this.lastMatchToolStripMenuItem,
            this.lasstTournamentenginesToolStripMenuItem,
            this.lastTournamentplayersToolStripMenuItem,
            this.lastTrainingToolStripMenuItem,
            this.toolStripMenuItem2,
            this.lastErrorToolStripMenuItem});
			this.logToolStripMenuItem.Name = "logToolStripMenuItem";
			this.logToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.logToolStripMenuItem.Text = "Logs";
			// 
			// programLogToolStripMenuItem
			// 
			this.programLogToolStripMenuItem.Name = "programLogToolStripMenuItem";
			this.programLogToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.programLogToolStripMenuItem.Text = "Program log";
			this.programLogToolStripMenuItem.Click += new System.EventHandler(this.programLogToolStripMenuItem_Click);
			// 
			// gamesToolStripMenuItem
			// 
			this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
			this.gamesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.gamesToolStripMenuItem.Text = "Games log";
			this.gamesToolStripMenuItem.Click += new System.EventHandler(this.gamesToolStripMenuItem_Click);
			// 
			// enginesToolStripMenuItem1
			// 
			this.enginesToolStripMenuItem1.Name = "enginesToolStripMenuItem1";
			this.enginesToolStripMenuItem1.Size = new System.Drawing.Size(212, 22);
			this.enginesToolStripMenuItem1.Text = "Engines log";
			this.enginesToolStripMenuItem1.Click += new System.EventHandler(this.enginesToolStripMenuItem1_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(209, 6);
			// 
			// lastGameToolStripMenuItem
			// 
			this.lastGameToolStripMenuItem.Name = "lastGameToolStripMenuItem";
			this.lastGameToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.lastGameToolStripMenuItem.Text = "Last game";
			this.lastGameToolStripMenuItem.Click += new System.EventHandler(this.lastGameToolStripMenuItem_Click);
			// 
			// lastMatchToolStripMenuItem
			// 
			this.lastMatchToolStripMenuItem.Name = "lastMatchToolStripMenuItem";
			this.lastMatchToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.lastMatchToolStripMenuItem.Text = "Last match";
			this.lastMatchToolStripMenuItem.Click += new System.EventHandler(this.lastMatchToolStripMenuItem_Click);
			// 
			// lasstTournamentenginesToolStripMenuItem
			// 
			this.lasstTournamentenginesToolStripMenuItem.Name = "lasstTournamentenginesToolStripMenuItem";
			this.lasstTournamentenginesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.lasstTournamentenginesToolStripMenuItem.Text = "Lasst tournament-engines";
			this.lasstTournamentenginesToolStripMenuItem.Click += new System.EventHandler(this.lasstTournamentenginesToolStripMenuItem_Click);
			// 
			// lastTournamentplayersToolStripMenuItem
			// 
			this.lastTournamentplayersToolStripMenuItem.Name = "lastTournamentplayersToolStripMenuItem";
			this.lastTournamentplayersToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.lastTournamentplayersToolStripMenuItem.Text = "Last tournament-players";
			this.lastTournamentplayersToolStripMenuItem.Click += new System.EventHandler(this.lastTournamentplayersToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(209, 6);
			// 
			// lastErrorToolStripMenuItem
			// 
			this.lastErrorToolStripMenuItem.Name = "lastErrorToolStripMenuItem";
			this.lastErrorToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.lastErrorToolStripMenuItem.Text = "Last error";
			this.lastErrorToolStripMenuItem.Click += new System.EventHandler(this.lastErrorToolStripMenuItem_Click);
			// 
			// historyToolStripMenuItem
			// 
			this.historyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enginesToolStripMenuItem2,
            this.playersToolStripMenuItem});
			this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
			this.historyToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.historyToolStripMenuItem.Text = "Charts";
			// 
			// enginesToolStripMenuItem2
			// 
			this.enginesToolStripMenuItem2.Name = "enginesToolStripMenuItem2";
			this.enginesToolStripMenuItem2.Size = new System.Drawing.Size(115, 22);
			this.enginesToolStripMenuItem2.Text = "Engines";
			this.enginesToolStripMenuItem2.Click += new System.EventHandler(this.enginesToolStripMenuItem2_Click);
			// 
			// playersToolStripMenuItem
			// 
			this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
			this.playersToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.playersToolStripMenuItem.Text = "Players";
			this.playersToolStripMenuItem.Click += new System.EventHandler(this.playersToolStripMenuItem_Click);
			// 
			// labFPS
			// 
			this.labFPS.Dock = System.Windows.Forms.DockStyle.Right;
			this.labFPS.Location = new System.Drawing.Point(1035, 0);
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
			this.panMenu.Controls.Add(this.labFPS);
			this.panMenu.Controls.Add(this.labError);
			this.panMenu.Controls.Add(this.labEco);
			this.panMenu.Controls.Add(this.menuStrip1);
			this.panMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.panMenu.Location = new System.Drawing.Point(0, 0);
			this.panMenu.Name = "panMenu";
			this.panMenu.Size = new System.Drawing.Size(1184, 26);
			this.panMenu.TabIndex = 26;
			// 
			// labError
			// 
			this.labError.BackColor = System.Drawing.Color.DarkRed;
			this.labError.Dock = System.Windows.Forms.DockStyle.Right;
			this.labError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labError.ForeColor = System.Drawing.Color.White;
			this.labError.Location = new System.Drawing.Point(1122, 0);
			this.labError.Name = "labError";
			this.labError.Size = new System.Drawing.Size(58, 22);
			this.labError.TabIndex = 4;
			this.labError.Text = "Error";
			this.labError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labError, "A new engine error has occurred");
			this.labError.Visible = false;
			this.labError.Click += new System.EventHandler(this.labError_Click);
			// 
			// labEco
			// 
			this.labEco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labEco.Cursor = System.Windows.Forms.Cursors.Default;
			this.labEco.Location = new System.Drawing.Point(380, 0);
			this.labEco.Name = "labEco";
			this.labEco.Size = new System.Drawing.Size(713, 22);
			this.labEco.TabIndex = 3;
			this.labEco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labEco, "Names of chess openings variations");
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 8000;
			this.toolTip1.BackColor = System.Drawing.SystemColors.Window;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.IsBalloon = true;
			this.toolTip1.ReshowDelay = 100;
			// 
			// labTimeD
			// 
			this.labTimeD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labTimeD.BackColor = System.Drawing.Color.LightGray;
			this.labTimeD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTimeD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTimeD.ForeColor = System.Drawing.Color.Black;
			this.labTimeD.Location = new System.Drawing.Point(189, 0);
			this.labTimeD.Margin = new System.Windows.Forms.Padding(0);
			this.labTimeD.Name = "labTimeD";
			this.labTimeD.Size = new System.Drawing.Size(110, 24);
			this.labTimeD.TabIndex = 23;
			this.labTimeD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labTimeD, "Player time");
			// 
			// labEloD
			// 
			this.labEloD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labEloD.BackColor = System.Drawing.Color.LightGray;
			this.labEloD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEloD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEloD.ForeColor = System.Drawing.Color.Black;
			this.labEloD.Location = new System.Drawing.Point(299, 0);
			this.labEloD.Margin = new System.Windows.Forms.Padding(0);
			this.labEloD.Name = "labEloD";
			this.labEloD.Size = new System.Drawing.Size(111, 24);
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
			this.labNameD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labNameD.BackColor = System.Drawing.Color.LightGray;
			this.labNameD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNameD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNameD.ForeColor = System.Drawing.Color.Black;
			this.labNameD.Location = new System.Drawing.Point(24, 0);
			this.labNameD.Margin = new System.Windows.Forms.Padding(0);
			this.labNameD.Name = "labNameD";
			this.labNameD.Size = new System.Drawing.Size(165, 24);
			this.labNameD.TabIndex = 20;
			this.labNameD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNameD, "Player name");
			// 
			// labEloT
			// 
			this.labEloT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labEloT.BackColor = System.Drawing.Color.LightGray;
			this.labEloT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEloT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEloT.ForeColor = System.Drawing.Color.Black;
			this.labEloT.Location = new System.Drawing.Point(299, 0);
			this.labEloT.Margin = new System.Windows.Forms.Padding(0);
			this.labEloT.Name = "labEloT";
			this.labEloT.Size = new System.Drawing.Size(111, 24);
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
			this.labNameT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labNameT.BackColor = System.Drawing.Color.LightGray;
			this.labNameT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNameT.ForeColor = System.Drawing.Color.Black;
			this.labNameT.Location = new System.Drawing.Point(24, 0);
			this.labNameT.Margin = new System.Windows.Forms.Padding(0);
			this.labNameT.Name = "labNameT";
			this.labNameT.Size = new System.Drawing.Size(165, 24);
			this.labNameT.TabIndex = 20;
			this.labNameT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNameT, "Player name");
			// 
			// labEngineW
			// 
			this.labEngineW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labEngineW.BackColor = System.Drawing.Color.Olive;
			this.labEngineW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEngineW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEngineW.ForeColor = System.Drawing.Color.White;
			this.labEngineW.Location = new System.Drawing.Point(216, 0);
			this.labEngineW.Margin = new System.Windows.Forms.Padding(0);
			this.labEngineW.Name = "labEngineW";
			this.labEngineW.Size = new System.Drawing.Size(192, 20);
			this.labEngineW.TabIndex = 13;
			this.labEngineW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labEngineW, "Chess engine name");
			// 
			// labWhite
			// 
			this.labWhite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labWhite.BackColor = System.Drawing.Color.White;
			this.labWhite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labWhite.ForeColor = System.Drawing.Color.Black;
			this.labWhite.Location = new System.Drawing.Point(0, 0);
			this.labWhite.Margin = new System.Windows.Forms.Padding(0);
			this.labWhite.Name = "labWhite";
			this.labWhite.Size = new System.Drawing.Size(24, 20);
			this.labWhite.TabIndex = 14;
			this.labWhite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labWhite, "Player color");
			// 
			// labBookNW
			// 
			this.labBookNW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labBookNW.BackColor = System.Drawing.Color.Olive;
			this.labBookNW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBookNW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBookNW.ForeColor = System.Drawing.Color.White;
			this.labBookNW.Location = new System.Drawing.Point(408, 0);
			this.labBookNW.Margin = new System.Windows.Forms.Padding(0);
			this.labBookNW.Name = "labBookNW";
			this.labBookNW.Size = new System.Drawing.Size(192, 20);
			this.labBookNW.TabIndex = 15;
			this.labBookNW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labBookNW, "Chess opening book name");
			// 
			// labProtocolW
			// 
			this.labProtocolW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labProtocolW.BackColor = System.Drawing.Color.Olive;
			this.labProtocolW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labProtocolW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labProtocolW.ForeColor = System.Drawing.Color.White;
			this.labProtocolW.Location = new System.Drawing.Point(792, 0);
			this.labProtocolW.Margin = new System.Windows.Forms.Padding(0);
			this.labProtocolW.Name = "labProtocolW";
			this.labProtocolW.Size = new System.Drawing.Size(192, 20);
			this.labProtocolW.TabIndex = 16;
			this.labProtocolW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labProtocolW, "Chess engine protocol");
			// 
			// labTimeT
			// 
			this.labTimeT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labTimeT.BackColor = System.Drawing.Color.LightGray;
			this.labTimeT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTimeT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTimeT.ForeColor = System.Drawing.Color.Black;
			this.labTimeT.Location = new System.Drawing.Point(189, 0);
			this.labTimeT.Margin = new System.Windows.Forms.Padding(0);
			this.labTimeT.Name = "labTimeT";
			this.labTimeT.Size = new System.Drawing.Size(110, 24);
			this.labTimeT.TabIndex = 24;
			this.labTimeT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labTimeT, "Player time");
			// 
			// labTakenT
			// 
			this.labTakenT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labTakenT.BackColor = System.Drawing.Color.DarkGray;
			this.labTakenT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTakenT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTakenT.ForeColor = System.Drawing.Color.Black;
			this.labTakenT.Location = new System.Drawing.Point(0, 0);
			this.labTakenT.Margin = new System.Windows.Forms.Padding(0);
			this.labTakenT.Name = "labTakenT";
			this.labTakenT.Size = new System.Drawing.Size(277, 28);
			this.labTakenT.TabIndex = 15;
			this.labTakenT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.labTakenT, "Taken pieces");
			// 
			// labMaterialT
			// 
			this.labMaterialT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMaterialT.BackColor = System.Drawing.Color.DarkGray;
			this.labMaterialT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMaterialT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMaterialT.ForeColor = System.Drawing.Color.Black;
			this.labMaterialT.Location = new System.Drawing.Point(277, 0);
			this.labMaterialT.Margin = new System.Windows.Forms.Padding(0);
			this.labMaterialT.Name = "labMaterialT";
			this.labMaterialT.Size = new System.Drawing.Size(81, 28);
			this.labMaterialT.TabIndex = 24;
			this.labMaterialT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labMaterialT, "Difference of pieces material between players");
			// 
			// labMaterialD
			// 
			this.labMaterialD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMaterialD.BackColor = System.Drawing.Color.DarkGray;
			this.labMaterialD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMaterialD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMaterialD.ForeColor = System.Drawing.Color.Black;
			this.labMaterialD.Location = new System.Drawing.Point(277, 0);
			this.labMaterialD.Margin = new System.Windows.Forms.Padding(0);
			this.labMaterialD.Name = "labMaterialD";
			this.labMaterialD.Size = new System.Drawing.Size(81, 28);
			this.labMaterialD.TabIndex = 24;
			this.labMaterialD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labMaterialD, "Difference of pieces material between players");
			// 
			// labTakenD
			// 
			this.labTakenD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labTakenD.BackColor = System.Drawing.Color.DarkGray;
			this.labTakenD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labTakenD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labTakenD.ForeColor = System.Drawing.Color.Black;
			this.labTakenD.Location = new System.Drawing.Point(0, 0);
			this.labTakenD.Margin = new System.Windows.Forms.Padding(0);
			this.labTakenD.Name = "labTakenD";
			this.labTakenD.Size = new System.Drawing.Size(277, 28);
			this.labTakenD.TabIndex = 15;
			this.labTakenD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip1.SetToolTip(this.labTakenD, "Taken pieces");
			// 
			// labModeW
			// 
			this.labModeW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labModeW.BackColor = System.Drawing.Color.Olive;
			this.labModeW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labModeW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labModeW.ForeColor = System.Drawing.Color.White;
			this.labModeW.Location = new System.Drawing.Point(600, 0);
			this.labModeW.Margin = new System.Windows.Forms.Padding(0);
			this.labModeW.Name = "labModeW";
			this.labModeW.Size = new System.Drawing.Size(192, 20);
			this.labModeW.TabIndex = 17;
			this.labModeW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labModeW, "Control time");
			// 
			// labModeB
			// 
			this.labModeB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labModeB.BackColor = System.Drawing.Color.Olive;
			this.labModeB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labModeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labModeB.ForeColor = System.Drawing.Color.White;
			this.labModeB.Location = new System.Drawing.Point(600, 0);
			this.labModeB.Margin = new System.Windows.Forms.Padding(0);
			this.labModeB.Name = "labModeB";
			this.labModeB.Size = new System.Drawing.Size(192, 20);
			this.labModeB.TabIndex = 17;
			this.labModeB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labModeB, "Control time");
			// 
			// labProtocolB
			// 
			this.labProtocolB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labProtocolB.BackColor = System.Drawing.Color.Olive;
			this.labProtocolB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labProtocolB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labProtocolB.ForeColor = System.Drawing.Color.White;
			this.labProtocolB.Location = new System.Drawing.Point(792, 0);
			this.labProtocolB.Margin = new System.Windows.Forms.Padding(0);
			this.labProtocolB.Name = "labProtocolB";
			this.labProtocolB.Size = new System.Drawing.Size(192, 20);
			this.labProtocolB.TabIndex = 16;
			this.labProtocolB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labProtocolB, "Chess engine protocol");
			// 
			// labBookNB
			// 
			this.labBookNB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labBookNB.BackColor = System.Drawing.Color.Olive;
			this.labBookNB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBookNB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBookNB.ForeColor = System.Drawing.Color.White;
			this.labBookNB.Location = new System.Drawing.Point(408, 0);
			this.labBookNB.Margin = new System.Windows.Forms.Padding(0);
			this.labBookNB.Name = "labBookNB";
			this.labBookNB.Size = new System.Drawing.Size(192, 20);
			this.labBookNB.TabIndex = 15;
			this.labBookNB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labBookNB, "Chess opening book name");
			// 
			// labBlack
			// 
			this.labBlack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labBlack.BackColor = System.Drawing.Color.Black;
			this.labBlack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBlack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBlack.ForeColor = System.Drawing.Color.Black;
			this.labBlack.Location = new System.Drawing.Point(0, 0);
			this.labBlack.Margin = new System.Windows.Forms.Padding(0);
			this.labBlack.Name = "labBlack";
			this.labBlack.Size = new System.Drawing.Size(24, 20);
			this.labBlack.TabIndex = 14;
			this.labBlack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labBlack, "Player color");
			// 
			// labEngineB
			// 
			this.labEngineB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labEngineB.BackColor = System.Drawing.Color.Olive;
			this.labEngineB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labEngineB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labEngineB.ForeColor = System.Drawing.Color.White;
			this.labEngineB.Location = new System.Drawing.Point(216, 0);
			this.labEngineB.Margin = new System.Windows.Forms.Padding(0);
			this.labEngineB.Name = "labEngineB";
			this.labEngineB.Size = new System.Drawing.Size(192, 20);
			this.labEngineB.TabIndex = 13;
			this.labEngineB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labEngineB, "Chess engine name");
			// 
			// combMainMode
			// 
			this.combMainMode.AutoCompleteCustomSource.AddRange(new string[] {
            "White",
            "Black"});
			this.combMainMode.BackColor = System.Drawing.SystemColors.Window;
			this.combMainMode.Cursor = System.Windows.Forms.Cursors.Hand;
			this.combMainMode.Dock = System.Windows.Forms.DockStyle.Top;
			this.combMainMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combMainMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.combMainMode.Items.AddRange(new object[] {
            "Game",
            "Match",
            "Tournament-engines",
            "Tournament-players",
            "Training",
            "Edit"});
			this.combMainMode.Location = new System.Drawing.Point(8, 8);
			this.combMainMode.Name = "combMainMode";
			this.combMainMode.Size = new System.Drawing.Size(384, 24);
			this.combMainMode.TabIndex = 11;
			this.toolTip1.SetToolTip(this.combMainMode, "Select game mode");
			this.combMainMode.SelectedIndexChanged += new System.EventHandler(this.cbMainMode_SelectedIndexChanged);
			// 
			// chartMain
			// 
			this.chartMain.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea6.AxisX.IsLabelAutoFit = false;
			chartArea6.AxisX.MajorGrid.Enabled = false;
			chartArea6.AxisX.MajorTickMark.Enabled = false;
			chartArea6.AxisY.IsLabelAutoFit = false;
			chartArea6.AxisY.MajorGrid.Interval = 5D;
			chartArea6.AxisY.MajorTickMark.Enabled = false;
			chartArea6.AxisY.Maximum = 5D;
			chartArea6.AxisY.Minimum = -5D;
			chartArea6.BackColor = System.Drawing.Color.WhiteSmoke;
			chartArea6.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea6.Name = "ChartArea1";
			this.chartMain.ChartAreas.Add(chartArea6);
			this.chartMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartMain.Location = new System.Drawing.Point(0, 34);
			this.chartMain.Name = "chartMain";
			this.chartMain.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.chartMain.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Olive};
			series10.ChartArea = "ChartArea1";
			series10.CustomProperties = "PointWidth=1";
			series10.IsVisibleInLegend = false;
			series10.Name = "Series1";
			series11.ChartArea = "ChartArea1";
			series11.CustomProperties = "PointWidth=1";
			series11.Name = "Series2";
			this.chartMain.Series.Add(series10);
			this.chartMain.Series.Add(series11);
			this.chartMain.Size = new System.Drawing.Size(354, 153);
			this.chartMain.TabIndex = 0;
			this.chartMain.Text = "chart1";
			this.toolTip1.SetToolTip(this.chartMain, "Graphic representation of the game scores white player is  represent by light bar" +
        "s black player is represent by dark bars");
			// 
			// labPlayerW
			// 
			this.labPlayerW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labPlayerW.BackColor = System.Drawing.Color.Olive;
			this.labPlayerW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labPlayerW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPlayerW.ForeColor = System.Drawing.Color.White;
			this.labPlayerW.Location = new System.Drawing.Point(24, 0);
			this.labPlayerW.Margin = new System.Windows.Forms.Padding(0);
			this.labPlayerW.Name = "labPlayerW";
			this.labPlayerW.Size = new System.Drawing.Size(192, 20);
			this.labPlayerW.TabIndex = 18;
			this.labPlayerW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPlayerW, "Player name");
			// 
			// labPlayerB
			// 
			this.labPlayerB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labPlayerB.BackColor = System.Drawing.Color.Olive;
			this.labPlayerB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labPlayerB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPlayerB.ForeColor = System.Drawing.Color.White;
			this.labPlayerB.Location = new System.Drawing.Point(24, 0);
			this.labPlayerB.Margin = new System.Windows.Forms.Padding(0);
			this.labPlayerB.Name = "labPlayerB";
			this.labPlayerB.Size = new System.Drawing.Size(192, 20);
			this.labPlayerB.TabIndex = 18;
			this.labPlayerB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPlayerB, "Player name");
			// 
			// labPromoB
			// 
			this.labPromoB.BackColor = System.Drawing.Color.Transparent;
			this.labPromoB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labPromoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPromoB.ForeColor = System.Drawing.Color.Black;
			this.labPromoB.Location = new System.Drawing.Point(204, 0);
			this.labPromoB.Margin = new System.Windows.Forms.Padding(0);
			this.labPromoB.Name = "labPromoB";
			this.labPromoB.Size = new System.Drawing.Size(102, 52);
			this.labPromoB.TabIndex = 23;
			this.labPromoB.Text = "b";
			this.labPromoB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPromoB, "Promotion bishop");
			this.labPromoB.Click += new System.EventHandler(this.labPromoQ_Click);
			// 
			// labPromoN
			// 
			this.labPromoN.BackColor = System.Drawing.Color.Transparent;
			this.labPromoN.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labPromoN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPromoN.ForeColor = System.Drawing.Color.Black;
			this.labPromoN.Location = new System.Drawing.Point(306, 0);
			this.labPromoN.Margin = new System.Windows.Forms.Padding(0);
			this.labPromoN.Name = "labPromoN";
			this.labPromoN.Size = new System.Drawing.Size(104, 52);
			this.labPromoN.TabIndex = 22;
			this.labPromoN.Text = "n";
			this.labPromoN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPromoN, "Promotion kinght");
			this.labPromoN.Click += new System.EventHandler(this.labPromoQ_Click);
			// 
			// labPromoQ
			// 
			this.labPromoQ.BackColor = System.Drawing.Color.Transparent;
			this.labPromoQ.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labPromoQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPromoQ.ForeColor = System.Drawing.Color.Black;
			this.labPromoQ.Location = new System.Drawing.Point(0, 0);
			this.labPromoQ.Margin = new System.Windows.Forms.Padding(0);
			this.labPromoQ.Name = "labPromoQ";
			this.labPromoQ.Size = new System.Drawing.Size(102, 52);
			this.labPromoQ.TabIndex = 21;
			this.labPromoQ.Text = "q";
			this.labPromoQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPromoQ, "Promotion queen");
			this.labPromoQ.Click += new System.EventHandler(this.labPromoQ_Click);
			// 
			// labPromoR
			// 
			this.labPromoR.BackColor = System.Drawing.Color.Transparent;
			this.labPromoR.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labPromoR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPromoR.ForeColor = System.Drawing.Color.Black;
			this.labPromoR.Location = new System.Drawing.Point(102, 0);
			this.labPromoR.Margin = new System.Windows.Forms.Padding(0);
			this.labPromoR.Name = "labPromoR";
			this.labPromoR.Size = new System.Drawing.Size(102, 52);
			this.labPromoR.TabIndex = 20;
			this.labPromoR.Text = "r";
			this.labPromoR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPromoR, "Promotion rook");
			this.labPromoR.Click += new System.EventHandler(this.labPromoQ_Click);
			// 
			// labMemoryW
			// 
			this.labMemoryW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMemoryW.BackColor = System.Drawing.Color.Olive;
			this.labMemoryW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMemoryW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMemoryW.ForeColor = System.Drawing.Color.White;
			this.labMemoryW.Location = new System.Drawing.Point(984, 0);
			this.labMemoryW.Margin = new System.Windows.Forms.Padding(0);
			this.labMemoryW.Name = "labMemoryW";
			this.labMemoryW.Size = new System.Drawing.Size(196, 20);
			this.labMemoryW.TabIndex = 19;
			this.labMemoryW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labMemoryW, "Engine memory usage");
			// 
			// labMemoryB
			// 
			this.labMemoryB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labMemoryB.BackColor = System.Drawing.Color.Olive;
			this.labMemoryB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labMemoryB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labMemoryB.ForeColor = System.Drawing.Color.White;
			this.labMemoryB.Location = new System.Drawing.Point(984, 0);
			this.labMemoryB.Margin = new System.Windows.Forms.Padding(0);
			this.labMemoryB.Name = "labMemoryB";
			this.labMemoryB.Size = new System.Drawing.Size(196, 20);
			this.labMemoryB.TabIndex = 19;
			this.labMemoryB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labMemoryB, "Engine memory usage");
			// 
			// labColW
			// 
			this.labColW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labColW.BackColor = System.Drawing.Color.DarkGray;
			this.labColW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labColW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labColW.ForeColor = System.Drawing.Color.Black;
			this.labColW.Location = new System.Drawing.Point(0, 20);
			this.labColW.Margin = new System.Windows.Forms.Padding(0);
			this.labColW.Name = "labColW";
			this.labColW.Size = new System.Drawing.Size(24, 20);
			this.labColW.TabIndex = 20;
			this.labColW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labColW, "Player color");
			// 
			// labScoreW
			// 
			this.labScoreW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labScoreW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labScoreW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labScoreW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labScoreW.ForeColor = System.Drawing.Color.Black;
			this.labScoreW.Location = new System.Drawing.Point(24, 20);
			this.labScoreW.Margin = new System.Windows.Forms.Padding(0);
			this.labScoreW.Name = "labScoreW";
			this.labScoreW.Size = new System.Drawing.Size(192, 20);
			this.labScoreW.TabIndex = 21;
			this.labScoreW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labScoreW, "The score from the engine\'s point of view in centipawns");
			// 
			// labDepthW
			// 
			this.labDepthW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labDepthW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labDepthW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labDepthW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labDepthW.ForeColor = System.Drawing.Color.Black;
			this.labDepthW.Location = new System.Drawing.Point(216, 20);
			this.labDepthW.Margin = new System.Windows.Forms.Padding(0);
			this.labDepthW.Name = "labDepthW";
			this.labDepthW.Size = new System.Drawing.Size(192, 20);
			this.labDepthW.TabIndex = 22;
			this.labDepthW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labDepthW, "Search depth in plies");
			// 
			// labPonderW
			// 
			this.labPonderW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labPonderW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labPonderW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labPonderW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPonderW.ForeColor = System.Drawing.Color.Black;
			this.labPonderW.Location = new System.Drawing.Point(984, 20);
			this.labPonderW.Margin = new System.Windows.Forms.Padding(0);
			this.labPonderW.Name = "labPonderW";
			this.labPonderW.Size = new System.Drawing.Size(196, 20);
			this.labPonderW.TabIndex = 23;
			this.labPonderW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPonderW, "Next move expected");
			// 
			// labNpsW
			// 
			this.labNpsW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labNpsW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNpsW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNpsW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNpsW.ForeColor = System.Drawing.Color.Black;
			this.labNpsW.Location = new System.Drawing.Point(600, 20);
			this.labNpsW.Margin = new System.Windows.Forms.Padding(0);
			this.labNpsW.Name = "labNpsW";
			this.labNpsW.Size = new System.Drawing.Size(192, 20);
			this.labNpsW.TabIndex = 24;
			this.labNpsW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNpsW, "Average searched nodes per second");
			// 
			// labBookCW
			// 
			this.labBookCW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labBookCW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labBookCW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBookCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBookCW.ForeColor = System.Drawing.Color.Black;
			this.labBookCW.Location = new System.Drawing.Point(792, 20);
			this.labBookCW.Margin = new System.Windows.Forms.Padding(0);
			this.labBookCW.Name = "labBookCW";
			this.labBookCW.Size = new System.Drawing.Size(192, 20);
			this.labBookCW.TabIndex = 25;
			this.labBookCW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labBookCW, "Number of moves read from the opening book");
			// 
			// labNodesW
			// 
			this.labNodesW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labNodesW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNodesW.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNodesW.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNodesW.ForeColor = System.Drawing.Color.Black;
			this.labNodesW.Location = new System.Drawing.Point(408, 20);
			this.labNodesW.Margin = new System.Windows.Forms.Padding(0);
			this.labNodesW.Name = "labNodesW";
			this.labNodesW.Size = new System.Drawing.Size(192, 20);
			this.labNodesW.TabIndex = 26;
			this.labNodesW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNodesW, "Searched nodes");
			// 
			// labColB
			// 
			this.labColB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labColB.BackColor = System.Drawing.Color.DarkGray;
			this.labColB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labColB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labColB.ForeColor = System.Drawing.Color.Black;
			this.labColB.Location = new System.Drawing.Point(0, 20);
			this.labColB.Margin = new System.Windows.Forms.Padding(0);
			this.labColB.Name = "labColB";
			this.labColB.Size = new System.Drawing.Size(24, 20);
			this.labColB.TabIndex = 21;
			this.labColB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labColB, "Player color");
			// 
			// labScoreB
			// 
			this.labScoreB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labScoreB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labScoreB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labScoreB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labScoreB.ForeColor = System.Drawing.Color.Black;
			this.labScoreB.Location = new System.Drawing.Point(24, 20);
			this.labScoreB.Margin = new System.Windows.Forms.Padding(0);
			this.labScoreB.Name = "labScoreB";
			this.labScoreB.Size = new System.Drawing.Size(192, 20);
			this.labScoreB.TabIndex = 22;
			this.labScoreB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labScoreB, "The score from the engine\'s point of view in centipawns");
			// 
			// labDepthB
			// 
			this.labDepthB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labDepthB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labDepthB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labDepthB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labDepthB.ForeColor = System.Drawing.Color.Black;
			this.labDepthB.Location = new System.Drawing.Point(216, 20);
			this.labDepthB.Margin = new System.Windows.Forms.Padding(0);
			this.labDepthB.Name = "labDepthB";
			this.labDepthB.Size = new System.Drawing.Size(192, 20);
			this.labDepthB.TabIndex = 23;
			this.labDepthB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labDepthB, "Search depth in plies");
			// 
			// labNodesB
			// 
			this.labNodesB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labNodesB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNodesB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNodesB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNodesB.ForeColor = System.Drawing.Color.Black;
			this.labNodesB.Location = new System.Drawing.Point(408, 20);
			this.labNodesB.Margin = new System.Windows.Forms.Padding(0);
			this.labNodesB.Name = "labNodesB";
			this.labNodesB.Size = new System.Drawing.Size(192, 20);
			this.labNodesB.TabIndex = 24;
			this.labNodesB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNodesB, "Searched nodes");
			// 
			// labNpsB
			// 
			this.labNpsB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labNpsB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labNpsB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labNpsB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labNpsB.ForeColor = System.Drawing.Color.Black;
			this.labNpsB.Location = new System.Drawing.Point(600, 20);
			this.labNpsB.Margin = new System.Windows.Forms.Padding(0);
			this.labNpsB.Name = "labNpsB";
			this.labNpsB.Size = new System.Drawing.Size(192, 20);
			this.labNpsB.TabIndex = 25;
			this.labNpsB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labNpsB, "Average searched nodes per second");
			// 
			// labBookCB
			// 
			this.labBookCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labBookCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labBookCB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labBookCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labBookCB.ForeColor = System.Drawing.Color.Black;
			this.labBookCB.Location = new System.Drawing.Point(792, 20);
			this.labBookCB.Margin = new System.Windows.Forms.Padding(0);
			this.labBookCB.Name = "labBookCB";
			this.labBookCB.Size = new System.Drawing.Size(192, 20);
			this.labBookCB.TabIndex = 26;
			this.labBookCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labBookCB, "Number of moves read from the opening book");
			// 
			// labPonderB
			// 
			this.labPonderB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labPonderB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(160)))));
			this.labPonderB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labPonderB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labPonderB.ForeColor = System.Drawing.Color.Black;
			this.labPonderB.Location = new System.Drawing.Point(984, 20);
			this.labPonderB.Margin = new System.Windows.Forms.Padding(0);
			this.labPonderB.Name = "labPonderB";
			this.labPonderB.Size = new System.Drawing.Size(196, 20);
			this.labPonderB.TabIndex = 27;
			this.labPonderB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.labPonderB, "Next move expected");
			// 
			// statusStrip1
			// 
			this.statusStrip1.BackColor = System.Drawing.Color.Black;
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMove,
            this.tssInfo});
			this.statusStrip1.Location = new System.Drawing.Point(0, 840);
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
			// tssInfo
			// 
			this.tssInfo.ForeColor = System.Drawing.Color.Gainsboro;
			this.tssInfo.Name = "tssInfo";
			this.tssInfo.Size = new System.Drawing.Size(0, 17);
			// 
			// splitContainerBoard
			// 
			this.splitContainerBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerBoard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerBoard.Location = new System.Drawing.Point(0, 0);
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
			this.splitContainerBoard.Size = new System.Drawing.Size(1184, 517);
			this.splitContainerBoard.SplitterDistance = 414;
			this.splitContainerBoard.TabIndex = 37;
			// 
			// panBoard
			// 
			this.panBoard.BackColor = System.Drawing.Color.Transparent;
			this.panBoard.Controls.Add(this.tlpPromotion);
			this.panBoard.Cursor = System.Windows.Forms.Cursors.Default;
			this.panBoard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panBoard.Location = new System.Drawing.Point(0, 24);
			this.panBoard.Name = "panBoard";
			this.panBoard.Size = new System.Drawing.Size(410, 465);
			this.panBoard.TabIndex = 2;
			this.panBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panBoard_Paint);
			this.panBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.panBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.panBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			this.panBoard.Resize += new System.EventHandler(this.panBoard_Resize);
			// 
			// tlpPromotion
			// 
			this.tlpPromotion.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.tlpPromotion.ColumnCount = 4;
			this.tlpPromotion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPromotion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPromotion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPromotion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tlpPromotion.Controls.Add(this.labPromoB, 0, 0);
			this.tlpPromotion.Controls.Add(this.labPromoN, 0, 0);
			this.tlpPromotion.Controls.Add(this.labPromoQ, 0, 0);
			this.tlpPromotion.Controls.Add(this.labPromoR, 0, 0);
			this.tlpPromotion.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tlpPromotion.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlpPromotion.Location = new System.Drawing.Point(0, 413);
			this.tlpPromotion.Name = "tlpPromotion";
			this.tlpPromotion.RowCount = 1;
			this.tlpPromotion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpPromotion.Size = new System.Drawing.Size(410, 52);
			this.tlpPromotion.TabIndex = 2;
			this.tlpPromotion.Visible = false;
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
			this.tlpBoardD.Location = new System.Drawing.Point(0, 489);
			this.tlpBoardD.Margin = new System.Windows.Forms.Padding(0);
			this.tlpBoardD.Name = "tlpBoardD";
			this.tlpBoardD.RowCount = 1;
			this.tlpBoardD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpBoardD.Size = new System.Drawing.Size(410, 24);
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
			this.tlpBoardT.Size = new System.Drawing.Size(410, 24);
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
			this.splitContainerMode.Panel2.Controls.Add(this.panel1);
			this.splitContainerMode.Panel2MinSize = 400;
			this.splitContainerMode.Size = new System.Drawing.Size(762, 513);
			this.splitContainerMode.SplitterDistance = 358;
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
			this.splitContainerChart.Panel2.Controls.Add(this.chartMain);
			this.splitContainerChart.Panel2.Controls.Add(this.labResult);
			this.splitContainerChart.Size = new System.Drawing.Size(358, 457);
			this.splitContainerChart.SplitterDistance = 262;
			this.splitContainerChart.TabIndex = 27;
			// 
			// lvMoves
			// 
			this.lvMoves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvMoves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
			this.lvMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvMoves.FullRowSelect = true;
			this.lvMoves.GridLines = true;
			this.lvMoves.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvMoves.HideSelection = false;
			this.lvMoves.Location = new System.Drawing.Point(0, 0);
			this.lvMoves.MultiSelect = false;
			this.lvMoves.Name = "lvMoves";
			this.lvMoves.ShowGroups = false;
			this.lvMoves.Size = new System.Drawing.Size(354, 258);
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
			// labResult
			// 
			this.labResult.BackColor = System.Drawing.Color.Black;
			this.labResult.Dock = System.Windows.Forms.DockStyle.Top;
			this.labResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labResult.Location = new System.Drawing.Point(0, 0);
			this.labResult.Name = "labResult";
			this.labResult.Size = new System.Drawing.Size(354, 34);
			this.labResult.TabIndex = 1;
			this.labResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labResult.Visible = false;
			// 
			// tlpChartD
			// 
			this.tlpChartD.ColumnCount = 2;
			this.tlpChartD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.5F));
			this.tlpChartD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
			this.tlpChartD.Controls.Add(this.labMaterialD, 0, 0);
			this.tlpChartD.Controls.Add(this.labTakenD, 0, 0);
			this.tlpChartD.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlpChartD.Location = new System.Drawing.Point(0, 485);
			this.tlpChartD.Margin = new System.Windows.Forms.Padding(0);
			this.tlpChartD.Name = "tlpChartD";
			this.tlpChartD.RowCount = 1;
			this.tlpChartD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpChartD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpChartD.Size = new System.Drawing.Size(358, 28);
			this.tlpChartD.TabIndex = 30;
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
			this.tlpChartT.Size = new System.Drawing.Size(358, 28);
			this.tlpChartT.TabIndex = 29;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.combMainMode);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(8);
			this.panel1.Size = new System.Drawing.Size(400, 39);
			this.panel1.TabIndex = 11;
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.BackColor = System.Drawing.Color.Transparent;
			this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 26);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.splitContainerBoard);
			this.splitContainerMain.Panel1MinSize = 400;
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.splitContainerMoves);
			this.splitContainerMain.Panel2MinSize = 100;
			this.splitContainerMain.Size = new System.Drawing.Size(1184, 814);
			this.splitContainerMain.SplitterDistance = 517;
			this.splitContainerMain.TabIndex = 38;
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
			this.splitContainerMoves.Panel2.Controls.Add(this.tlpBlack);
			this.splitContainerMoves.Size = new System.Drawing.Size(1184, 293);
			this.splitContainerMoves.SplitterDistance = 146;
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
			this.lvMovesW.Location = new System.Drawing.Point(0, 40);
			this.lvMovesW.MultiSelect = false;
			this.lvMovesW.Name = "lvMovesW";
			this.lvMovesW.ShowGroups = false;
			this.lvMovesW.Size = new System.Drawing.Size(1180, 102);
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
			this.tlpWhite.ColumnCount = 7;
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpWhite.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpWhite.Controls.Add(this.labNpsW, 4, 1);
			this.tlpWhite.Controls.Add(this.labNodesW, 3, 1);
			this.tlpWhite.Controls.Add(this.labModeW, 4, 0);
			this.tlpWhite.Controls.Add(this.labProtocolW, 5, 0);
			this.tlpWhite.Controls.Add(this.labEngineW, 2, 0);
			this.tlpWhite.Controls.Add(this.labMemoryW, 6, 0);
			this.tlpWhite.Controls.Add(this.labDepthW, 2, 1);
			this.tlpWhite.Controls.Add(this.labBookCW, 5, 1);
			this.tlpWhite.Controls.Add(this.labPonderW, 6, 1);
			this.tlpWhite.Controls.Add(this.labWhite, 0, 0);
			this.tlpWhite.Controls.Add(this.labColW, 0, 1);
			this.tlpWhite.Controls.Add(this.labScoreW, 1, 1);
			this.tlpWhite.Controls.Add(this.labPlayerW, 1, 0);
			this.tlpWhite.Controls.Add(this.labBookNW, 3, 0);
			this.tlpWhite.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpWhite.Location = new System.Drawing.Point(0, 0);
			this.tlpWhite.Name = "tlpWhite";
			this.tlpWhite.RowCount = 2;
			this.tlpWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpWhite.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpWhite.Size = new System.Drawing.Size(1180, 40);
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
			this.lvMovesB.Location = new System.Drawing.Point(0, 40);
			this.lvMovesB.MultiSelect = false;
			this.lvMovesB.Name = "lvMovesB";
			this.lvMovesB.ShowGroups = false;
			this.lvMovesB.Size = new System.Drawing.Size(1180, 99);
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
			// tlpBlack
			// 
			this.tlpBlack.ColumnCount = 7;
			this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
			this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpBlack.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
			this.tlpBlack.Controls.Add(this.labPonderB, 6, 1);
			this.tlpBlack.Controls.Add(this.labBookCB, 5, 1);
			this.tlpBlack.Controls.Add(this.labNpsB, 4, 1);
			this.tlpBlack.Controls.Add(this.labNodesB, 3, 1);
			this.tlpBlack.Controls.Add(this.labDepthB, 2, 1);
			this.tlpBlack.Controls.Add(this.labScoreB, 1, 1);
			this.tlpBlack.Controls.Add(this.labColB, 0, 1);
			this.tlpBlack.Controls.Add(this.labModeB, 4, 0);
			this.tlpBlack.Controls.Add(this.labProtocolB, 5, 0);
			this.tlpBlack.Controls.Add(this.labMemoryB, 6, 0);
			this.tlpBlack.Controls.Add(this.labBookNB, 3, 0);
			this.tlpBlack.Controls.Add(this.labBlack, 0, 0);
			this.tlpBlack.Controls.Add(this.labPlayerB, 1, 0);
			this.tlpBlack.Controls.Add(this.labEngineB, 2, 0);
			this.tlpBlack.Dock = System.Windows.Forms.DockStyle.Top;
			this.tlpBlack.Location = new System.Drawing.Point(0, 0);
			this.tlpBlack.Name = "tlpBlack";
			this.tlpBlack.RowCount = 2;
			this.tlpBlack.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpBlack.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tlpBlack.Size = new System.Drawing.Size(1180, 40);
			this.tlpBlack.TabIndex = 35;
			// 
			// lastTrainingToolStripMenuItem
			// 
			this.lastTrainingToolStripMenuItem.Name = "lastTrainingToolStripMenuItem";
			this.lastTrainingToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.lastTrainingToolStripMenuItem.Text = "Last training";
			this.lastTrainingToolStripMenuItem.Click += new System.EventHandler(this.lastTrainingToolStripMenuItem_Click);
			// 
			// FormChess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1184, 862);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panMenu);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormChess";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RapChessGui";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChess_FormClosed);
			this.Resize += new System.EventHandler(this.FormChess_Resize);
			this.tabControl1.ResumeLayout(false);
			this.tabPageGame.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartGame)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.tabPageMatch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartMatch)).EndInit();
			this.tlpMatch.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudValue2)).EndInit();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudValue1)).EndInit();
			this.tabPageTourE.ResumeLayout(false);
			this.splitContainerTourE.Panel1.ResumeLayout(false);
			this.splitContainerTourE.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTourE)).EndInit();
			this.splitContainerTourE.ResumeLayout(false);
			this.scTournamentEList.Panel1.ResumeLayout(false);
			this.scTournamentEList.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scTournamentEList)).EndInit();
			this.scTournamentEList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartTournamentE)).EndInit();
			this.groupBox9.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nudTourE)).EndInit();
			this.tabPageTourP.ResumeLayout(false);
			this.splitContainerTourP.Panel1.ResumeLayout(false);
			this.splitContainerTourP.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerTourP)).EndInit();
			this.splitContainerTourP.ResumeLayout(false);
			this.scTournamentPList.Panel1.ResumeLayout(false);
			this.scTournamentPList.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scTournamentPList)).EndInit();
			this.scTournamentPList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartTournamentP)).EndInit();
			this.tabPageTraining.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chartTraining)).EndInit();
			this.tlpTraining.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
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
			((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainerBoard.Panel1.ResumeLayout(false);
			this.splitContainerBoard.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerBoard)).EndInit();
			this.splitContainerBoard.ResumeLayout(false);
			this.panBoard.ResumeLayout(false);
			this.tlpPromotion.ResumeLayout(false);
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
			this.tlpChartD.ResumeLayout(false);
			this.tlpChartT.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.splitContainerMoves.Panel1.ResumeLayout(false);
			this.splitContainerMoves.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMoves)).EndInit();
			this.splitContainerMoves.ResumeLayout(false);
			this.tlpWhite.ResumeLayout(false);
			this.tlpBlack.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Timer timerMessages;
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
		private System.Windows.Forms.TableLayoutPanel tlpTraining;
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
		private System.Windows.Forms.TabPage tabPageMatch;
		private System.Windows.Forms.TableLayoutPanel tlpMatch;
		private System.Windows.Forms.Label labMatch24;
		private System.Windows.Forms.Label labMatch23;
		private System.Windows.Forms.Label labMatch22;
		private System.Windows.Forms.Label labMatch21;
		private System.Windows.Forms.Label labMatchPlayer2;
		private System.Windows.Forms.Label labMatch14;
		private System.Windows.Forms.Label labMatch13;
		private System.Windows.Forms.Label labMatch12;
		private System.Windows.Forms.Label labMatch11;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label labMatchPlayer;
		private System.Windows.Forms.Label labMatchPlayer1;
		private System.Windows.Forms.Label labMatchGames;
		private System.Windows.Forms.Button butNewMatch;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown nudTrained;
		private System.Windows.Forms.NumericUpDown nudTeacher;
		private System.Windows.Forms.ComboBox cbTeacherBook;
		private System.Windows.Forms.TabPage tabPageTourP;
		private System.Windows.Forms.Button butStartTournament;
		private System.Windows.Forms.TabPage tabPageEdit;
		private System.Windows.Forms.Button butClearBoard;
		private System.Windows.Forms.GroupBox gbToMove;
		private System.Windows.Forms.RadioButton rbBlack;
		private System.Windows.Forms.RadioButton rbWhite;
		private System.Windows.Forms.Button butStop;
		private System.Windows.Forms.Button butContinueGame;
		private System.Windows.Forms.Label labBack;
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
		private System.Windows.Forms.ToolStripStatusLabel tssInfo;
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
		private System.Windows.Forms.SplitContainer splitContainerTourP;
		private System.Windows.Forms.SplitContainer splitContainerMode;
		private System.Windows.Forms.SplitContainer splitContainerChart;
		private System.Windows.Forms.ListView lvMoves;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
		private System.Windows.Forms.NumericUpDown nudValue2;
		private System.Windows.Forms.NumericUpDown nudValue1;
		private System.Windows.Forms.TableLayoutPanel tlpWhite;
		private System.Windows.Forms.Label labProtocolW;
		private System.Windows.Forms.Label labBookNW;
		private System.Windows.Forms.Label labWhite;
		private System.Windows.Forms.Label labEngineW;
		private System.Windows.Forms.Label labTimeT;
		private System.Windows.Forms.TableLayoutPanel tlpChartT;
		private System.Windows.Forms.Label labMaterialT;
		private System.Windows.Forms.Label labTakenT;
		private System.Windows.Forms.TableLayoutPanel tlpChartD;
		private System.Windows.Forms.Label labMaterialD;
		private System.Windows.Forms.Label labTakenD;
		private System.Windows.Forms.Label labModeW;
		private System.Windows.Forms.TableLayoutPanel tlpBlack;
		private System.Windows.Forms.Label labModeB;
		private System.Windows.Forms.Label labProtocolB;
		private System.Windows.Forms.Label labBookNB;
		private System.Windows.Forms.Label labBlack;
		private System.Windows.Forms.Label labEngineB;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.ComboBox combMainMode;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label labErrors;
		private System.Windows.Forms.Label labGames;
		private System.Windows.Forms.Button butResignation;
		private System.Windows.Forms.TabPage tabPageTourE;
		private System.Windows.Forms.SplitContainer splitContainerTourE;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.NumericUpDown nudTourE;
		private System.Windows.Forms.ComboBox cbTourEMode;
		private System.Windows.Forms.Button butTourEStart;
		private System.Windows.Forms.Label labPlayerW;
		private System.Windows.Forms.Label labPlayerB;
		private System.Windows.Forms.Button butBackward;
		private System.Windows.Forms.Button butForward;
		private System.Windows.Forms.TableLayoutPanel tlpPromotion;
		private System.Windows.Forms.Label labPromoB;
		private System.Windows.Forms.Label labPromoN;
		private System.Windows.Forms.Label labPromoQ;
		private System.Windows.Forms.Label labPromoR;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.ComboBox cbTourEBook;
		private System.Windows.Forms.ToolStripMenuItem enginesToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
		public System.Windows.Forms.DataVisualization.Charting.Chart chartGame;
		public System.Windows.Forms.DataVisualization.Charting.Chart chartTraining;
		private System.Windows.Forms.SplitContainer scTournamentEList;
		private System.Windows.Forms.ListView lvEngine;
		private System.Windows.Forms.ColumnHeader columnHeader23;
		private System.Windows.Forms.ColumnHeader columnHeader24;
		private System.Windows.Forms.ColumnHeader columnHeader25;
		private System.Windows.Forms.ListView lvEngineH;
		private System.Windows.Forms.ColumnHeader columnHeader26;
		private System.Windows.Forms.ColumnHeader columnHeader27;
		private System.Windows.Forms.ColumnHeader columnHeader28;
		private System.Windows.Forms.ColumnHeader columnHeader29;
		private System.Windows.Forms.Label labEngine;
		public System.Windows.Forms.DataVisualization.Charting.Chart chartTournamentE;
		private System.Windows.Forms.SplitContainer scTournamentPList;
		private System.Windows.Forms.ListView lvPlayer;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Label labPlayer;
		private System.Windows.Forms.ListView lvPlayerH;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		public System.Windows.Forms.DataVisualization.Charting.Chart chartTournamentP;
		private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem enginesToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem programLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem lastGameToolStripMenuItem;
		private System.Windows.Forms.Button butEditStart;
		private System.Windows.Forms.Label labResult;
		private System.Windows.Forms.Label labMemoryW;
		private System.Windows.Forms.Label labMemoryB;
		private System.Windows.Forms.Label labError;
		private System.Windows.Forms.ToolStripMenuItem lastErrorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lastMatchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lasstTournamentenginesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lastTournamentplayersToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.Label labScoreW;
		private System.Windows.Forms.Label labColW;
		private System.Windows.Forms.Label labNodesW;
		private System.Windows.Forms.Label labNpsW;
		private System.Windows.Forms.Label labDepthW;
		private System.Windows.Forms.Label labBookCW;
		private System.Windows.Forms.Label labPonderW;
		private System.Windows.Forms.Label labBookCB;
		private System.Windows.Forms.Label labNpsB;
		private System.Windows.Forms.Label labNodesB;
		private System.Windows.Forms.Label labDepthB;
		private System.Windows.Forms.Label labScoreB;
		private System.Windows.Forms.Label labColB;
		private System.Windows.Forms.Label labPonderB;
		private System.Windows.Forms.DataVisualization.Charting.Chart chartMatch;
		private System.Windows.Forms.ToolStripMenuItem lastTrainingToolStripMenuItem;
	}
}

