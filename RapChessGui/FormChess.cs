using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using RapIni;
using RapLog;
using NSUci;
using NSChess;

namespace RapChessGui
{
	public partial class FormChess : Form
	{
		[DllImport("gdi32.dll")]
		private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

		[DllImport("user32")]
		private static extern bool ShowScrollBar(IntPtr hwnd, int wBar, [MarshalAs(UnmanagedType.Bool)] bool bShow);

		public const int WM_GAME_NEXT = 1024;
		public static IntPtr handle;
		public static FormChess This;
		public static bool boardRotate;
		string lastEco = "";
		List<int> moves = new List<int>();
		public static CRapIni RapIni = new CRapIni();
		public static CDirBookList DirBookList = new CDirBookList();
		readonly CBoard Board = new CBoard();
		readonly CEcoList EcoList = new CEcoList();
		public static CChess Chess = new CChess();
		readonly CGamerList GamerList = new CGamerList();
		readonly CUci Uci = new CUci();
		readonly SoundPlayer audioMove = new SoundPlayer(Properties.Resources.Move);
		public static PrivateFontCollection pfc = new PrivateFontCollection();
		public static CBookList bookList = new CBookList();
		public static CEngineList engineList = new CEngineList();
		public static CPlayerList playerList = new CPlayerList();
		readonly FormLogProgram formLogProgram = new FormLogProgram();
		readonly FormLogGames formLogGames = new FormLogGames();
		readonly FormLogEngines formLogEngines = new FormLogEngines();
		readonly FormLastGame formLastGame = new FormLastGame();
		readonly FormChartP formHisP = new FormChartP();
		readonly FormChartE formHisE = new FormChartE();

		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x0112;
			const int SC_MINIMIZE = 0xF020;
			switch (m.Msg)
			{
				case WM_SYSCOMMAND:
					int command = m.WParam.ToInt32() & 0xfff0;
					if (command == SC_MINIMIZE)
					{
						SplitSaveToIni();
					}
					break;
				case WM_GAME_NEXT:
					NextGame();
					break;
			}
			base.WndProc(ref m);
		}

		#region initiation

		public FormChess()
		{
			This = this;
			CreateDir("Books");
			CreateDir("Engines");
			CreateDir(@"Engines/Uci");
			CreateDir(@"Engines/Winboard");
			CreateDir("History");
			CData.UpdateFileEngine();
			CData.UpdateFileBook();
			int fontLength = Properties.Resources.ChessPiece.Length;
			byte[] fontData = Properties.Resources.ChessPiece;
			IntPtr data = Marshal.AllocCoTaskMem(fontLength);
			Marshal.Copy(fontData, 0, data, fontLength);
			uint cFonts = 0;
			AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);
			pfc.AddMemoryFont(data, fontLength);
			Marshal.FreeCoTaskMem(data);
			FormOptions.This = new FormOptions();
			FormEngine.This = new FormEngine();
			FormBook.This = new FormBook();
			FormPlayer.This = new FormPlayer();
			InitializeComponent();
			IniCreate();
			DirBookList.LoadFromIni();
			IniLoad();
			Reset(true);
			Font fontChess = new Font(pfc.Families[0], 16);
			Font fontChessPromo = new Font(pfc.Families[0], 32);
			labTakenT.Font = fontChess;
			labTakenD.Font = fontChess;
			labPromoQ.Font = fontChessPromo;
			labPromoR.Font = fontChessPromo;
			labPromoB.Font = fontChessPromo;
			labPromoN.Font = fontChessPromo;
			toolTip1.Active = FormOptions.ShowTips();
			CWinMessage.winHandle = Handle;
			Chess.Initialize();
			BoardPrepare();
			combMainMode.SelectedIndex = 0;
			timerAnimation.Enabled = true;
		}

		void CreateDir(string dir)
		{
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
		}

		void IniCreate()
		{
			if (engineList.LoadFromIni() == 0)
			{
				engineList.SetElo("RapChessCs");
				engineList.SetElo("RapSimpleCs");
				engineList.SetElo("RapShortCs");
				engineList.SaveToIni();
			}
			if (bookList.LoadFromIni() == 0)
			{
				CBook b;
				b = new CBook();
				b.exe = "BookReaderBin.exe";
				b.name = "AutoBin";
				b.parameters = "[engine] -w";
				bookList.Add(b);
				b = new CBook();
				b.exe = "BookReaderMem.exe";
				b.name = "AutoMem";
				b.parameters = "[engine] -w 100K";
				b = new CBook();
				b.exe = "BookReaderUmo.exe";
				b.name = "AutoUmo";
				b.parameters = "[engine] -w";
				bookList.Add(b);

				bookList.Add(b);
				b = new CBook("BigBin");
				b.exe = "BookReaderBin.exe";
				b.parameters = b.name;
				bookList.Add(b);
				b = new CBook("BigMem");
				b.exe = "BookReaderMem.exe";
				b.parameters = $"{b.name} -w 100K";
				bookList.Add(b);
				b = new CBook("BigUmo");
				b.exe = "BookReaderUmo.exe";
				b.parameters = b.name;
				bookList.Add(b);

				b = new CBook("Chess DB");
				b.exe = "BookReaderCdb.exe";
				bookList.Add(b);

				for (int n = 1; n < 10; n++)
				{
					int v = n * 10;
					b = new CBook();
					b.exe = "BookReaderRnd.exe";
					b.parameters = v.ToString();
					bookList.Add(b);
				}
				bookList.SaveToIni();
				RapIni.Write("options>dir>Bin", "BookReaderBin.exe");
				RapIni.Write("options>dir>Mem", "BookReaderMem.exe");
				RapIni.Write("options>dir>Umo", "BookReaderUmo.exe");
			}
			playerList.LoadFromIni();
			if (playerList.GetPlayerRealHuman() == null)
			{
				CPlayer p = new CPlayer("Human");
				p.tournament = 0;
				p.elo = "500";
				p.eloOrg = "500";
				p.modeValue.mode = "Infinite";
				p.modeValue.value = 0;
				p.SaveToIni();
				playerList.Add(p);
			}
			if (playerList.GetPlayerComputer() == null)
			{
				CPlayer p = new CPlayer();
				p.engine = "RapChessCs";
				p.book = "BRR 90";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "200";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChessCs";
				p.book = "BRR 70";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "400";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChessCs";
				p.book = "BRR 50";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "600";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChessCs";
				p.book = "BRR 30";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "800";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChessCs";
				p.book = "BRR 10";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "1000";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapShortCs";
				p.book = "Eco";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "500";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapSimpleCs";
				p.book = "ChessDb";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "1000";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChessCs";
				p.book = "BigMem";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "1200";
				playerList.Add(p);
				playerList.SaveToIni();
			}
			UpdateEngineList();
		}

		void IniLoad()
		{
			Width = RapIni.ReadInt("position>width", Width);
			Height = RapIni.ReadInt("position>height", Height);
			if (Width < 600)
				Width = 600;
			if (Height < 600)
				Height = 600;
			int x = RapIni.ReadInt("position>x", Location.X);
			int y = RapIni.ReadInt("position>y", Location.Y);
			if (x < 0)
				x = 0;
			if (y < 0)
				y = 0;
			Location = new Point(x, y);
			if (RapIni.ReadBool("position>maximized", false))
				WindowState = FormWindowState.Maximized;
			CModeGame.LoadFromIni();
			CModeMatch.LoadFromIni();
			CModeTournamentE.LoadFromIni();
			CModeTournamentP.LoadFromIni();
			CModeTraining.LoadFromIni();
		}

		void IniSave()
		{
			bool maximized = WindowState == FormWindowState.Maximized;
			int width = maximized ? RestoreBounds.Width : Width;
			int height = maximized ? RestoreBounds.Height : Height;
			int x = maximized ? RestoreBounds.X : Location.X;
			int y = maximized ? RestoreBounds.Y : Location.Y;
			RapIni.Write("position>maximized", maximized);
			RapIni.Write("position>width", width);
			RapIni.Write("position>height", height);
			RapIni.Write("position>x", x);
			RapIni.Write("position>y", y);
			SplitSaveToIni();
		}

		void SplitSaveToIni(SplitContainer sc)
		{
			int size = sc.Orientation == Orientation.Horizontal ? sc.Size.Height : sc.Size.Width;
			double p = (double)sc.SplitterDistance / size;
			RapIni.Write($"position>split>{sc.Name}", p);
		}

		void SplitLoadFromIni(SplitContainer sc)
		{
			int size = sc.Orientation == Orientation.Horizontal ? sc.Size.Height : sc.Size.Width;
			double o = (double)sc.SplitterDistance / size;
			double p = RapIni.ReadDouble($"position>split>{sc.Name}", o);
			int d = Convert.ToInt32(p * size);
			try
			{
				if (p > 0) sc.SplitterDistance = d;
			}
			catch { }
		}

		void SplitLoadFromIni()
		{
			SplitLoadFromIni(splitContainerMain);
			SplitLoadFromIni(splitContainerBoard);
			SplitLoadFromIni(splitContainerChart);
			SplitLoadFromIni(splitContainerTourE);
			SplitLoadFromIni(splitContainerTourP);
			SplitLoadFromIni(scTournamentEList);
			SplitLoadFromIni(scTournamentPList);
		}

		void SplitSaveToIni()
		{
			SplitSaveToIni(splitContainerMain);
			SplitSaveToIni(splitContainerBoard);
			SplitSaveToIni(splitContainerChart);
			SplitSaveToIni(splitContainerTourE);
			SplitSaveToIni(splitContainerTourP);
			SplitSaveToIni(scTournamentEList);
			SplitSaveToIni(scTournamentPList);
		}

		#endregion

		#region main

		void PlaySound()
		{
			if (FormOptions.This.cbSound.Checked)
				audioMove.Play();
		}

		void SquareBoard()
		{
			splitContainerBoard.SplitterDistance = panBoard.Height;
		}

		void GameLoop()
		{
			if (CBoard.animated || CDrag.dragged)
				RenderBoard();
			else if (CData.gameState == CGameState.normal)
			{
				GamerList.GamerCur().TryStart();
				ShowInfo(GamerList.GamerCur());
				ShowInfo(GamerList.GamerSec());
			}
		}

		void ComClear()
		{
			lastEco = String.Empty;
			Text = $"RapChessGui Games {CData.gamesPlayed} Draws {CData.gamesDraw} Time out {CData.gamesTime} Errors {CData.gamesError}";
			CData.eco = String.Empty;
			CData.gameState = CGameState.normal;
			labEloD.BackColor = Color.LightGray;
			labEloD.ForeColor = Color.Black;
			labEloT.BackColor = Color.LightGray;
			labEloT.ForeColor = Color.Black;
			labEco.Text = "";
			tssMove.Text = "Move 1 0";
			ShowInfo("Good luck", Color.Gainsboro, 1);
			labResult.Hide();
			chartMain.Series[0].Points.Clear();
			chartMain.Series[1].Points.Clear();
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			PrepareFen();
			GamerList.Init();
		}

		void ComShow()
		{
			CGamer gw = GamerList.gamer[0];
			CGamer gb = GamerList.gamer[1];
			FormLogEngines.WriteHeader(gw, gb);
			ShowGamers();
			ShowInfo(gw);
			ShowInfo(gb);
			SetBoardRotate();
			if (GamerList.GamerCur().player.IsRealHuman())
				moves = Chess.GenerateValidMoves(out _);
		}

		public void SetColor()
		{
			labPlayerW.BackColor = CBoard.colorLabelB;
			labPlayerB.BackColor = CBoard.colorLabelB;
			labEngineW.BackColor = CBoard.colorLabelB;
			labEngineB.BackColor = CBoard.colorLabelB;
			labBookNW.BackColor = CBoard.colorLabelB;
			labBookNB.BackColor = CBoard.colorLabelB;
			labModeW.BackColor = CBoard.colorLabelB;
			labModeB.BackColor = CBoard.colorLabelB;
			labProtocolW.BackColor = CBoard.colorLabelB;
			labProtocolB.BackColor = CBoard.colorLabelB;
			labMemoryW.BackColor = CBoard.colorLabelB;
			labMemoryB.BackColor = CBoard.colorLabelB;
			labScoreW.BackColor = CBoard.colorLabelW;
			labScoreB.BackColor = CBoard.colorLabelW;
			labDepthW.BackColor = CBoard.colorLabelW;
			labDepthB.BackColor = CBoard.colorLabelW;
			labNodesW.BackColor = CBoard.colorLabelW;
			labNodesB.BackColor = CBoard.colorLabelW;
			labNpsW.BackColor = CBoard.colorLabelW;
			labNpsB.BackColor = CBoard.colorLabelW;
			labBookCW.BackColor = CBoard.colorLabelW;
			labBookCB.BackColor = CBoard.colorLabelW;
			labPonderW.BackColor = CBoard.colorLabelW;
			labPonderB.BackColor = CBoard.colorLabelW;
			chartMain.PaletteCustomColors[0] = CBoard.colorChartM;
			chartMain.PaletteCustomColors[1] = CBoard.colorChartD;
			chartGame.PaletteCustomColors[0] = CBoard.colorChartD;
			chartMatch.PaletteCustomColors[0] = CBoard.colorChartD;
			chartTournamentE.PaletteCustomColors[0] = CBoard.colorChartM;
			chartTournamentE.PaletteCustomColors[1] = CBoard.colorChartD;
			chartTournamentE.PaletteCustomColors[2] = CBoard.colorChartL;
			chartTournamentP.PaletteCustomColors[0] = CBoard.colorChartM;
			chartTournamentP.PaletteCustomColors[1] = CBoard.colorChartD;
			chartTournamentP.PaletteCustomColors[2] = CBoard.colorChartL;
			BackColor = CBoard.colorChartD;
			chartGame.Invalidate();
			chartMatch.Invalidate();
			ShowAutoElo();
			TournamentEReset();
			TournamentPReset();
		}

		void NextGame()
		{
			switch (CData.gameMode)
			{
				case CGameMode.match:
					MatchStart();
					break;
				case CGameMode.tourE:
					TournamentEStart();
					break;
				case CGameMode.tourP:
					TournamentPStart();
					break;
				case CGameMode.training:
					TrainingStart();
					break;
			}
		}

		void PrepareFen(string fen = CChess.defFen)
		{
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			Chess.SetFen(fen);
			CHistory.SetFen(Chess.GetFen(), Chess.g_moveNumber);
			Board.ClearArrows();
			Board.ClearColors();
			Board.Fill();
		}

		void ShowGamers()
		{
			CGamer gw = GamerList.gamer[0];
			CGamer gb = GamerList.gamer[1];
			labPlayerW.Text = gw.GetPlayerName();
			labPlayerB.Text = gb.GetPlayerName();
			labEngineW.Text = gw.GetEngineName();
			labEngineB.Text = gb.GetEngineName();
			labBookNW.Text = gw.GetBook();
			labBookNB.Text = gb.GetBook();
			labModeW.Text = gw.GetMode();
			labModeB.Text = gb.GetMode();
			labProtocolW.Text = gw.GetProtocol();
			labProtocolB.Text = gb.GetProtocol();
			labMemoryW.Text = gw.GetMemory();
			labMemoryB.Text = gb.GetMemory();
			splitContainerMoves.Panel1Collapsed = gw.player.IsRealHuman();
			splitContainerMoves.Panel2Collapsed = gb.player.IsRealHuman();
		}

		void ShowInfo(CGamer g)
		{
			if (!FormOptions.This.cbShowPonder.Checked)
				g.ponder = "";
			if (g.isWhite)
			{
				labScoreW.Text = $"Score {g.score}";
				labNodesW.Text = $"Nodes {g.nodes:N0}";
				labNpsW.Text = $"Nps {g.GetNps():N0}";
				labPonderW.Text = $"Ponder {g.ponder}";
				labBookCW.Text = $"Book {g.countMovesBook}";
				labDepthW.Text = $"Depth {g.GetDepth()}";
				labColW.BackColor = g.GetScoreColor();
			}
			else
			{
				labScoreB.Text = $"Score {g.score}";
				labNodesB.Text = $"Nodes {g.nodes:N0}";
				labNpsB.Text = $"Nps {g.GetNps():N0}";
				labPonderB.Text = $"Ponder {g.ponder}";
				labBookCB.Text = $"Book {g.countMovesBook}";
				labDepthB.Text = $"Depth {g.GetDepth()}";
				labColB.BackColor = g.GetScoreColor();
			}
			if (boardRotate ^ g.isWhite)
			{
				if (CData.gameState == CGameState.normal)
				{
					labTimeD.Text = g.GetTime(out bool low);
					if ((g.timer.IsRunning) || (CData.gameState != CGameState.normal))
					{
						labTimeD.BackColor = low ? CBoard.colorRed : CBoard.colorLabelB;
						labTimeD.ForeColor = CBoard.colorMessage;
					}
					else
					{
						labTimeD.BackColor = Color.LightGray;
						labTimeD.ForeColor = Color.Black;
					}
				}
				labEloD.Text = g.GetElo();
			}
			else
			{
				if (CData.gameState == CGameState.normal)
				{
					labTimeT.Text = g.GetTime(out bool low);
					if ((g.timer.IsRunning) || (CData.gameState != CGameState.normal))
					{
						labTimeT.BackColor = low ? CBoard.colorRed : CBoard.colorLabelB;
						labTimeT.ForeColor = CBoard.colorMessage;
					}
					else
					{
						labTimeT.BackColor = Color.LightGray;
						labTimeT.ForeColor = Color.Black;
					}
				}
				labEloT.Text = g.GetElo();
			}
		}

		public void SetGameState(CGameState gs, CGamer gamer = null, string umo = "")
		{
			if (gs == CGameState.normal)
			{
				CData.gameState = CGameState.normal;
				return;
			}
			if (CData.gameState != CGameState.normal)
				return;
			CData.gameState = gs;
			CGamer gw = GamerList.GamerWinner();
			CGamer gl = GamerList.GamerLoser();
			if (gamer == gw)
			{
				gw = gl;
				gl = gamer;
			}
			CPlayer pw = gw.player;
			CPlayer pl = gl.player;
			bool isDraw = false;
			switch (CData.gameState)
			{
				case CGameState.mate:
					ShowInfo(gw.GetName() + " win", Color.Lime, 1);
					break;
				case CGameState.stalemate:
					isDraw = true;
					ShowInfo("Stalemate", Color.Yellow, 1);
					break;
				case CGameState.repetition:
					isDraw = true;
					ShowInfo("Threefold repetition", Color.Yellow, 1);
					break;
				case CGameState.move50:
					isDraw = true;
					ShowInfo("Fifty-move rule", Color.Yellow, 1);
					break;
				case CGameState.material:
					isDraw = true;
					ShowInfo("Insufficient material", Color.Yellow, 1);
					break;
				case CGameState.resignation:
					ShowInfo($"{pl.name} resign", Color.Red, 1);
					break;
				case CGameState.time:
					CData.gamesTime++;
					ShowInfo($"{pl.name} time out", Color.Red, 1);
					CRapLog.Add($"Time out {pl.name}");
					FormLogEngines.AppendText($"Time out {pl.name}\n", Color.Red);
					break;
				case CGameState.error:
					CData.gamesError++;
					labError.Show();
					ShowInfo($"{pl.name} make wrong move", Color.Red, 1);
					CRapLog.Add($"Wrong move {pl.name} ({umo}) {Chess.GetFen()}");
					FormLogEngines.AppendText($"Wrong move: ({umo})\n", Color.Red);
					FormLogEngines.AppendText($"Fen: {Chess.GetFen()}\n", Color.Black);
					break;
			}
			labResult.Text = tssInfo.Text;
			labResult.ForeColor = tssInfo.ForeColor;
			labResult.Show();
			CGamer gWhi = GamerList.GamerWhite();
			CGamer gBla = GamerList.GamerBlack();
			FormLogEngines.AppendTimeText($" White: {gWhi.player.name}\n", Color.DimGray);
			FormLogEngines.AppendTimeText($" Engine: {gWhi.GetEngineName()}\n", Color.DimGray);
			FormLogEngines.AppendTimeText($" Clock: {gWhi.GetTime(out _)} Moves: {gWhi.countMoves} ({gWhi.countMoves - gWhi.countMovesBook}) Book: {gWhi.countMovesBook}\n", Color.DimGray);
			FormLogEngines.AppendTimeText($" Black: {gBla.player.name}\n", Color.Black);
			FormLogEngines.AppendTimeText($" Engine: {gBla.GetEngineName()}\n", Color.Black);
			FormLogEngines.AppendTimeText($" Clock: {gBla.GetTime(out _)} Moves: {gBla.countMoves} ({gBla.countMoves - gBla.countMovesBook}) Book: {gBla.countMovesBook}\n", Color.Black);
			FormLogEngines.AppendTimeText($" Finish {tssInfo.Text}\n", Color.Olive);
			if (isDraw)
				CData.gamesDraw++;
			CData.gamesPlayed++;
			CreateRtf();
			CreatePgn();
			GamerList.Terminate();
			if (CData.gameMode == CGameMode.game)
				GaemEnd(pw, pl, isDraw);
			else
			{
				if (CData.gameMode == CGameMode.match)
					MatchEnd(pw, isDraw);
				if (CData.gameMode == CGameMode.tourE)
					TournamentEEnd(gw, gl, isDraw);
				if (CData.gameMode == CGameMode.tourP)
					TournamentPEnd(pw, pl, isDraw);
				if (CData.gameMode == CGameMode.training)
					TrainingEnd(gw, isDraw);
				Task.Delay(FormOptions.gameBreak * 1000).ContinueWith(t => CWinMessage.Message(WM_GAME_NEXT));
			}
		}

		public void BoardPrepare()
		{
			CBoard.SetColor();
			SetColor();
			SetBoardRotate();
			Board.Resize(panBoard.Width, panBoard.Height);
			RenderBoard();
		}

		void AddLines(CGamer g)
		{
			DateTime dt = new DateTime();
			try
			{
				dt = dt.AddMilliseconds(g.infMs);
			}
			catch
			{
				CRapLog.Add($"milliseconds {g.engine.name} {g.infMs}");
			}
			ListViewItem lvi = new ListViewItem(new[] { dt.ToString("mm:ss.ff"), g.score, g.GetDepth(), g.nodes.ToString("N0"), g.nps.ToString("N0"), g.pv });
			ListView lv = g.isWhite ? lvMovesW : lvMovesB;
			if ((lv.Items.Count & 1) > 0)
				lvi.BackColor = CBoard.colorMessage;
			lv.Items.Insert(0, lvi);
		}

		void SetPv(int i, CGamer g)
		{
			int selfdepth = 0;
			string pv = "";
			List<int> moves = new List<int>();
			for (int n = i; n < Uci.tokens.Length; n++)
			{
				string move = Uci.tokens[n];
				if (Chess.IsValidMove(move, out string umo, out string san, out int emo))
				{
					selfdepth++;
					if (moves.Count == 0)
					{
						g.lastMove = umo;
						Board.arrowCur.AddMoves(umo);
						RenderBoard();
					}
					Chess.MakeMove(emo);
					moves.Add(emo);
					if (FormOptions.This.rbSan.Checked)
						pv += $" {san}";
					else
						pv += $" {umo}";
				}
			}
			for (int n = moves.Count - 1; n >= 0; n--)
				Chess.UnmakeMove(moves[n]);
			if (pv != "")
				g.pv = pv;
			g.seldepth = selfdepth;
			ShowInfo(pv, Color.Gainsboro);
			AddLines(g);
		}

		public void GetMessageUci(CGamer g, string msg)
		{
			Uci.SetMsg(msg);
			switch (Uci.command)
			{
				case "uciok":
				case "readyok":
					g.UciNextPhase();
					break;
				case "enginemove":
					g.isBookFail = true;
					break;
				case "bestmove":
					if (GamerList.GamerCur() == g)
					{
						Uci.GetValue("bestmove", out string umo);
						Uci.GetValue("ponder", out g.ponder);
						if (g.isBookStarted && !g.isBookFail)
						{
							g.countMovesBook++;
							g.score = "book";
							ShowInfo($"book {umo}", Color.Aquamarine);
							if ((g.engine != null) && (g.engine.protocol == CProtocol.winboard))
								g.isPositionWb = false;
						}
						else
							g.countMovesEngine++;
						MakeMove(umo);
						if ((g.ponder != "") && FormOptions.This.rbSan.Checked)
							g.ponder = Chess.UmoToSan(g.ponder);
					}
					break;
				case "info":
					if (Uci.GetIndex("string", 0) == 1)
					{
						ShowInfo(Uci.GetValue(2, Uci.tokens.Length - 1), Color.Gainsboro, 1);
						break;
					}
					ulong nps = 0;
					if (Uci.GetValue("cp", out string s))
					{
						g.score = s;
						g.iScore = Int32.Parse(s);
					}
					if (Uci.GetValue("mate", out s))
					{
						int ip = Int32.Parse(s);
						if (ip > 0)
						{
							g.score = $"+{s}M";
							g.iScore = 0xffff - ip;
						}
						else
						{
							g.score = $"{s}M";
							g.iScore = -0xffff + ip;
						}
					}
					if (Uci.GetValue("depth", out s))
						g.depth = Int32.Parse(s);
					if (Uci.GetValue("seldepth", out s))
						g.seldepth = Int32.Parse(s);
					if (Uci.GetValue("nodes", out s))
					{
						try
						{
							g.nodes = (ulong)Convert.ToInt64(s);
						}
						catch
						{
							g.nodes = 0;
						}
					}
					if (Uci.GetValue("nps", out s))
					{
						try
						{
							g.nps = (ulong)Convert.ToInt64(s);
						}
						catch
						{
							g.nps = 0;
						}
						nps = g.nps;
					}
					if (Uci.GetValue("time", out s))
					{
						try
						{
							g.infMs = (ulong)Convert.ToInt64(s);
						}
						catch
						{
							g.infMs = 0;
						}
						if (nps == 0)
							nps = g.infMs > 0 ? (g.nodes * 1000) / g.infMs : 0;
					}
					if (nps > 0)
						g.SetNps(nps);
					int i = Uci.GetIndex("pv", 0);
					if (i > 0)
						SetPv(i + 1, g);
					break;
			}
		}

		bool GetMoveXb(string xmo, out string umo)
		{
			umo = xmo = new string(xmo.Where(c => !char.IsControl(c)).ToArray()).ToLower();
			if ((xmo == "o-o") || (xmo == "0-0"))
				umo = Chess.whiteTurn ? "e1g1" : "e8g8";
			if ((xmo == "o-o-o") || (xmo == "0-0-0"))
				umo = Chess.whiteTurn ? "e1c1" : "e8c8";
			if (Chess.IsValidMove(umo, out _))
				return true;
			if (umo.Length > 4)
			{
				umo = umo.Substring(0, 4);
				if (Chess.IsValidMove(umo, out _))
					return true;
			}
			umo += "q";
			if (Chess.IsValidMove(umo, out _))
				return true;
			umo = xmo;
			return false;
		}

		public void GetMessageXb(CGamer g, string msg)
		{
			string umo;
			Uci.SetMsg(msg);
			switch (Uci.command)
			{
				case "0-1":
				case "1-0":
				case "1/2-1/2":
					SetGameState(CGameState.resignation, g);
					break;
				case "move":
					Uci.GetValue("ponder", out g.ponder);
					GetMoveXb(Uci.tokens[1], out umo);
					MakeMove(umo);
					break;
				default:
					string s = msg.ToLower();
					if (s.Contains("move"))
					{
						if (GetMoveXb(Uci.Last(), out umo))
							MakeMove(umo);
					}
					else if (s.Contains("resign") || s.Contains("illegal"))
						SetGameState(CGameState.resignation, g);
					else if (g.isPrepareFinished && Char.IsDigit(Uci.tokens[0][0]) && (Uci.tokens.Length > 4))
					{
						try
						{
							g.depth = Int32.Parse(Uci.tokens[0]);
							g.score = Uci.tokens[1];
							g.iScore = Convert.ToInt32(g.score);
							g.infMs = (ulong)Convert.ToInt64(Uci.tokens[2]) * 10;
							g.nodes = (ulong)Convert.ToInt64(Uci.tokens[3]);
							g.nps = g.infMs > 0 ? (g.nodes * 1000) / g.infMs : 0;
							if (g.nps > 0)
								g.SetNps(g.nps);
							SetPv(4, g);
						}
						catch
						{
							CRapLog.Add($"{g.player.name} ({g.player.engine}) ({msg})");
						}
					}
					break;
			}
		}

		delegate void DeleMessage(int id, string message);

		readonly static DeleMessage deleMessage = new DeleMessage(NewMessage);

		public static void SetMessage(int id, string message)
		{
			This.Invoke(deleMessage, new object[] { id, message });
		}

		public static void NewMessage(int id, string msg)
		{
			This.GetMessage(id, msg);
		}

		public void GetMessage(int pid, string msg)
		{
			CGamer gamer = GamerList.GetGamerPid(pid, out string protocol);
			if (gamer == null)
			{
				if (pid == FormEngine.process.GetPid())
				{
					FormEngine.AddOption(msg);
				}
				else if (pid == FormLogEngines.process.GetPid())
				{
					FormLogEngines.AppendText($"{msg}\n", Color.Black, true);
				}
				else if (CData.gameState == CGameState.normal)
					CRapLog.Add($"Unknown pid ({GamerList.GamerCur().player.engine} - {GamerList.GamerSec().player.engine})");
			}
			else
			{
				FormLogEngines.SetMessage(gamer, protocol, msg);
				if ((protocol == "Uci") || (protocol == "Book"))
					GetMessageUci(gamer, msg);
				if (protocol == "Winboard")
					GetMessageXb(gamer, msg);
			}
		}

		void CreateRtf()
		{
			string fn = CData.gameState == CGameState.error ? "Error" : combMainMode.Text;
			fn = $"History\\{fn}.rtf";
			try
			{
				FormLogEngines.Save(fn);
			}
			catch
			{
				CRapLog.Add($"Error save {fn}");
			}
		}

		void CreatePgn()
		{
			List<string> list = new List<string>();
			string result = "1/2-1/2";
			if ((CData.gameState == CGameState.mate) || (CData.gameState == CGameState.time) || (CData.gameState == CGameState.error) || (CData.gameState == CGameState.resignation))
				if ((CHistory.moveList.Count & 1) > 0)
					result = "1-0";
				else
					result = "0-1";
			list.Add("");
			list.Add("[Site \"RapChessGui\"]");
			list.Add($"[Event \"{combMainMode.Text}\"]");
			list.Add($"[Date \"{DateTime.Now:yyyy.MM.dd}\"]");
			list.Add($"[Round \"{CData.gamesPlayed}\"]");
			list.Add($"[White \"{GamerList.gamer[0].player.name}\"]");
			list.Add($"[Black \"{GamerList.gamer[1].player.name}\"]");
			list.Add($"[WhiteElo \"{GamerList.gamer[0].player.elo}\"]");
			list.Add($"[BlackElo \"{GamerList.gamer[1].player.elo}\"]");
			list.Add($"[Result \"{result}\"]");
			list.Add("");
			list.Add($"{CHistory.GetPgn()} {result}");
			foreach (String s in list)
				formLogGames.textBox1.Text += $"{s}\r\n";
			formLogGames.textBox1.Select(0, 0);
			if (CData.gameState == CGameState.error)
				File.WriteAllLines("History\\Error.pgn", list);
			else
				File.WriteAllText($"History\\{combMainMode.Text}.pgn", formLogGames.textBox1.Text);
		}

		void SetMode(CGameMode mode)
		{
			GamerList.Terminate();
			string fen = Chess.GetFen();
			ComClear();
			CData.gameMode = mode;
			switch (mode)
			{
				case CGameMode.game:
					GameShow();
					break;
				case CGameMode.match:
					MatchShow();
					break;
				case CGameMode.tourE:
					TournamentEShow();
					break;
				case CGameMode.training:
					TrainingShow();
					break;
				case CGameMode.edit:
					EditShow(fen);
					break;
			}
			ComShow();
		}

		bool IsGameLong()
		{
			return (Chess.g_moveNumber >> 1) > 4;
		}

		bool IsGameProgress()
		{
			return CData.gameState == CGameState.normal;
		}

		bool GetRanked()
		{
			return (cbComputer.Text == "Auto") && FormOptions.This.cbGameAutoElo.Checked && (CData.gameMode == CGameMode.game);
		}

		void SetUnranked()
		{
			if (CModeGame.ranked == true)
			{
				CModeGame.ranked = false;
				CPlayer ph = playerList.GetPlayerRealHuman();
				ph.elo = ph.eloOrg;
				ph.SaveToIni();
			}
			ShowAutoElo();
		}

		void ShowInfo(string info, Color color, int ip = 0)
		{
			if (Convert.ToInt32(tssInfo.Tag) <= ip)
			{
				tssInfo.Text = info;
				tssInfo.ForeColor = color;
				tssInfo.Tag = ip;
			}
		}

		CGamer GamerD()
		{
			return GamerList.gamer[boardRotate ? 1 : 0];
		}

		CGamer GamerT()
		{
			return GamerList.gamer[boardRotate ? 0 : 1];
		}

		void ShowAutoElo()
		{
			labEloD.BackColor = Color.LightGray;
			labEloD.ForeColor = Color.Black;
			labEloT.BackColor = Color.LightGray;
			labEloT.ForeColor = Color.Black;
			if (GetRanked() && CModeGame.ranked)
			{
				if (GamerD().player.IsRealHuman())
				{
					labEloD.BackColor = CBoard.colorLabelB;
					labEloD.ForeColor = CBoard.colorMessage;
				}
				if (GamerT().player.IsRealHuman())
				{
					labEloT.BackColor = CBoard.colorLabelB;
					labEloT.ForeColor = CBoard.colorMessage;
				}
			}
		}

		bool ShowLastGame(bool changeProgress = false)
		{
			bool result = false;
			CPlayer hu = playerList.GetPlayerRealHuman();
			int eloCur = Convert.ToInt32(hu.elo);
			int eloOld = Convert.ToInt32(hu.eloOrg);
			int eloDel = eloCur - eloOld;
			if (eloDel > 0)
			{
				result = true;
				ShowInfo($"Last game you win new elo is {hu.elo} (+{eloDel})", Color.FromArgb(0, 0xff, 0), 1);
			}
			if (eloDel < 0)
			{
				result = true;
				ShowInfo($"Last game you loose new elo is {hu.elo} ({eloDel})", Color.FromArgb(0xff, 0, 0), 1);
			}
			if (result || changeProgress)
			{
				hu.hisElo.Add(Convert.ToDouble(hu.elo));
				CData.HisToPoints(hu.hisElo, chartGame.Series[0].Points);
			}
			hu.eloOrg = hu.elo;
			hu.SaveToIni();
			return result;
		}

		void ShowFormLastGame(string name)
		{
			FormLastGame.lastName = name;
			if (formLastGame.Visible)
				formLastGame.Focus();
			else
				formLastGame.Show(this);
		}

		void UpdateEngineList()
		{
			CData.UpdateFileEngine();
			engineList.AutoUpdate();
			playerList.Check(engineList);
			Reset(true);
		}

		void Reset(bool auto = false)
		{
			CBoard.SetColor(FormOptions.colorBoard);
			BackColor = CBoard.colorChartD;
			if (!auto && !CData.reset)
				return;
			CData.reset = false;
			cbEngine.Items.Clear();
			cbTeacherEngine.Items.Clear();
			cbTrainedEngine.Items.Clear();
			cbEngine1.Items.Clear();
			cbEngine2.Items.Clear();
			foreach (CEngine e in engineList.list)
				if (e.FileExists())
				{
					cbEngine.Items.Add(e.name);
					cbEngine1.Items.Add(e.name);
					cbEngine2.Items.Add(e.name);
					cbTeacherEngine.Items.Add(e.name);
					cbTrainedEngine.Items.Add(e.name);
				}
			cbBook.Items.Clear();
			cbMatchBook1.Items.Clear();
			cbMatchBook2.Items.Clear();
			cbTourEBook.Items.Clear();
			cbTeacherBook.Items.Clear();
			cbTrainedBook.Items.Clear();
			cbTourEBook.Items.Add("None");
			cbTeacherBook.Items.Add("None");
			cbTrainedBook.Items.Add("None");
			cbBook.Items.Add("None");
			cbMatchBook1.Items.Add("None");
			cbMatchBook2.Items.Add("None");
			foreach (CBook b in bookList.list)
				if (b.FileExists())
				{
					cbBook.Items.Add(b.name);
					cbMatchBook1.Items.Add(b.name);
					cbMatchBook2.Items.Add(b.name);
					cbTourEBook.Items.Add(b.name);
					cbTeacherBook.Items.Add(b.name);
					cbTrainedBook.Items.Add(b.name);
				}
			cbTourEBook.SelectedIndex = cbTourEBook.Items.Count > 0 ? 0 : -1; ;
			cbTeacherBook.SelectedIndex = cbTeacherBook.Items.Count > 0 ? 0 : -1;
			cbTrainedBook.SelectedIndex = cbTrainedBook.Items.Count > 0 ? 0 : -1;
			cbBook.SelectedIndex = cbBook.Items.Count > 0 ? 0 : -1; ;
			cbMatchBook1.SelectedIndex = cbMatchBook1.Items.Count > 0 ? 0 : -1; ;
			cbMatchBook2.SelectedIndex = cbMatchBook2.Items.Count > 0 ? 0 : -1; ;
			cbEngine.SelectedIndex = cbEngine.Items.Count > 0 ? 0 : -1;
			bookList.Update();
			TournamentEReset();
			TournamentPReset();
			lvPlayer.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			lvEngine.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			MatchShow();
			TournamentEShow();
			TrainingShow();
		}

		void ShowEco()
		{
			labEco.Text = $"{CData.eco} - {CHistory.GetMovesNotation(4)}";
		}

		public bool MakeMove(string umo)
		{
			umo = umo.Trim('\0').ToLower();
			if (CData.gameState != CGameState.normal)
				return false;
			Board.arrowCur.Clear();
			CGamer cg = GamerList.GamerCur();
			cg.timer.Stop();
			double m = GamerList.curIndex == 0 ? 0.01 : -0.01;
			chartMain.Series[GamerList.curIndex].Points.Add(cg.iScore * m);
			if (GetRanked() && CModeGame.ranked && (cg.engine == null) && ((Chess.g_moveNumber >> 1) == 4))
			{
				cg.player.eloOrg = cg.player.elo;
				cg.player.elo = cg.player.GetEloLess().ToString();
				cg.player.SaveToIni();
			}
			if (!Chess.IsValidMove(umo, out umo, out int gmo))
			{
				SetGameState(CGameState.error, cg, umo);
				return false;
			}
			PlaySound();
			cg.countMoves++;
			string san = Chess.UmoToSan(umo);
			CChess.UmoToSD(umo, out CDrag.lastSou, out CDrag.lastDes);
			Board.MakeMove(gmo);
			Chess.MakeMove(umo, out _, out int piece);
			CHistory.AddMove(piece, gmo, umo, san);
			MoveToLvMoves(CHistory.moveList.Count - 1, piece, CHistory.LastNotation(), cg.score);
			CEco eco = EcoList.GetEcoFen(Chess.GetEpd());
			tssInfo.Tag = 0;
			if (cg.player.IsRealHuman())
			{
				tssInfo.Text = "";
				Board.ClearArrows();
				if (eco != null)
					ShowInfo(eco.name, Color.Lime, 1);
				else if ((lastEco != "") && (!lastEco.Contains(umo)))
				{
					ShowInfo("You missed the opening moves", Color.Pink, 1);
					Board.arrowEco.AddMoves(lastEco);
				}
			}
			if (cg.isWhite)
				labMemoryW.Text = cg.GetMemory();
			else
				labMemoryB.Text = cg.GetMemory();
			if (eco != null)
			{
				labEco.ForeColor = Color.Brown;
				CData.eco = eco.name;
				ShowEco();
				lastEco = eco.continuations;
			}
			else
			{
				labEco.ForeColor = Color.Black;
				lastEco = String.Empty;
			}
			int moveNumber = (Chess.g_moveNumber >> 1) + 1;
			tssMove.Text = $"Move {moveNumber} {Chess.g_move50}";
			SetGameState(Chess.GetGameState());
			if (CData.gameState == CGameState.normal)
			{
				GamerList.Next();
				if (GamerList.GamerCur().player.IsRealHuman())
					moves = Chess.GenerateValidMoves(out _);
				else
					if (GamerList.GamerCur().isWhite)
					lvMovesW.Items.Clear();
				else
					lvMovesB.Items.Clear();
			}
			SetBoardRotate();
			return true;
		}

		void SetBoardRotate()
		{
			boardRotate = (GamerList.gamer[1].player.IsRealHuman() && GamerList.gamer[0].player.IsComputer()) ^ CData.rotateBoard;
			if ((GamerList.gamer[1].player.IsRealHuman()) && (GamerList.gamer[0].player.IsRealHuman()))
				boardRotate = !Chess.whiteTurn;
		}

		public void RenderBoard(bool forced = false)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			CGamer gt, gd;
			if (boardRotate)
			{
				gt = GamerList.gamer[0];
				gd = GamerList.gamer[1];
				labNameT.Text = gt.player.name;
				labNameD.Text = gd.player.name;
				labColorT.BackColor = Color.White;
				labColorD.BackColor = Color.Black;
				labTakenT.ForeColor = Color.White;
				labTakenD.ForeColor = Color.Black;
				labMaterialT.ForeColor = Color.White;
				labMaterialD.ForeColor = Color.Black;
			}
			else
			{
				gt = GamerList.gamer[1];
				gd = GamerList.gamer[0];
				labNameT.Text = gt.player.name;
				labNameD.Text = gd.player.name;
				labColorT.BackColor = Color.Black;
				labColorD.BackColor = Color.White;
				labTakenT.ForeColor = Color.Black;
				labTakenD.ForeColor = Color.White;
				labMaterialT.ForeColor = Color.Black;
				labMaterialD.ForeColor = Color.White;
			}
			if (CBoard.animated || CDrag.dragged || forced)
				Board.RenderBoard();
			if (CBoard.animated)
				CBoard.finished = false;
			CBoard.UpdatePosition();
			if (!CBoard.animated && !CBoard.finished)
			{
				CBoard.finished = true;
				if (!tlpPromotion.Visible)
				{
					Board.Fill();
					RenderTaken();
				}
			}
			Graphics pg = panBoard.CreateGraphics();
			Board.RenderArrows(pg);
			pg.Dispose();
			stopwatch.Stop();
			CData.fps = stopwatch.ElapsedMilliseconds > 0 ? CData.fps * 0.9 + 100 / stopwatch.ElapsedMilliseconds : 0;
			labFPS.Text = $"FPS {Convert.ToInt32(CData.fps)}";
		}

		void RenderTaken()
		{
			int[] arrPiece = { 0, 0, 0, 0, 0, 0, 0, 0 };
			int[] arrMaterial = { 0, 1, 3, 3, 5, 8, 0, 0 };
			int material = 0;
			for (int y = 0; y < 8; y++)
			{
				for (int x = 0; x < 8; x++)
				{
					int piece = Chess.g_board[((y + 4) << 4) + x + 4];
					int rank = piece & 7;
					if ((piece & CChess.colorWhite) > 0)
					{
						arrPiece[rank]++;
						material += arrMaterial[rank];
					}
					if ((piece & CChess.colorBlack) > 0)
					{
						arrPiece[rank]--;
						material -= arrMaterial[rank];
					}
				}
			}
			string w = "";
			string b = "";
			for (int n = 5; n > 0; n--)
			{
				for (int c = 0; c < arrPiece[n]; c++)
					w += " pnbrqk"[n];
				for (int c = 0; c > arrPiece[n]; c--)
					b += " pnbrqk"[n];
			}
			string mw = material.ToString();
			if (material > 0)
				mw = $"+{mw}";
			string mb = (-material).ToString();
			if (-material > 0)
				mb = $"+{mb}";
			if (boardRotate)
			{
				labTakenT.Text = w;
				labTakenD.Text = b;
				labMaterialT.Text = mw;
				labMaterialD.Text = mb;
			}
			else
			{
				labTakenT.Text = b;
				labTakenD.Text = w;
				labMaterialT.Text = mb;
				labMaterialD.Text = mw;
			}
		}

		void LoadFen(string fen)
		{
			combMainMode.SelectedIndex = 0;
			SetMode(CGameMode.game);
			if (!Chess.SetFen(fen))
			{
				MessageBox.Show("Wrong fen");
				return;
			}
			CHistory.SetFen(Chess.GetFen(), Chess.g_moveNumber);

			CChess.UmoToSD(CHistory.LastUmo(), out CDrag.lastSou, out CDrag.lastDes);
			Board.ClearArrows();
			Board.Fill();
			HistoryToLvMoves();
			SetingsToGamers();
			int curColor = Chess.g_moveNumber & 1;
			GamerList.curIndex = curColor;
			if (GamerList.GamerCur().player.IsComputer())
				GamerList.Rotate(curColor);

			CGamer gw = GamerList.gamer[0];
			CGamer gb = GamerList.gamer[1];
			FormLogEngines.WriteHeader(gw, gb);
			FormLogEngines.AppendTimeText($"Fen {Chess.GetFen()}\n", Color.Gray);
			ShowInfo($"Load fen {Chess.GetFen()}", Color.Lime, 1);
			ShowInfo(gw);
			ShowInfo(gb);

			moves = Chess.GenerateValidMoves(out _);
			CData.gameState = CGameState.normal;
			SetGameState(Chess.GetGameState());
			SetBoardRotate();
			RenderBoard(true);
			SetUnranked();
		}

		void LoadFromHistory()
		{
			labEloD.BackColor = Color.LightGray;
			labEloD.ForeColor = Color.Black;
			labEloT.BackColor = Color.LightGray;
			labEloT.ForeColor = Color.Black;
			labEco.Text = "";
			labResult.Hide();
			Chess.SetFen(CHistory.fen);
			foreach (CHisMove m in CHistory.moveList)
				Chess.MakeMove(m.emo);
			CChess.UmoToSD(CHistory.LastUmo(), out CDrag.lastSou, out CDrag.lastDes);
			Board.ClearArrows();
			Board.Fill();
			HistoryToLvMoves();
			SetingsToGamers();
			int curColor = Chess.g_moveNumber & 1;
			GamerList.curIndex = curColor;
			if (GamerList.GamerCur().player.IsComputer())
				GamerList.Rotate(curColor);
			moves = Chess.GenerateValidMoves(out _);
			CData.gameState = CGameState.normal;
			SetGameState(Chess.GetGameState());
			SetBoardRotate();
			SetUnranked();
			RenderBoard(true);
		}

		void LoadPgn(string pgn)
		{
			combMainMode.SelectedIndex = 0;
			SetMode(CGameMode.game);
			string[] ml = pgn.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			Chess.SetFen();
			CHistory.SetFen();
			foreach (string san in ml)
			{
				if (Char.IsDigit(san, 0))
					continue;
				string umo2 = Chess.SanToUmo(san);
				string san2 = Chess.UmoToSan(umo2);
				if (Chess.MakeMove(umo2, out int emo, out int piece))
					CHistory.AddMove(piece, emo, umo2, san2);
				else break;
			}

			CChess.UmoToSD(CHistory.LastUmo(), out CDrag.lastSou, out CDrag.lastDes);
			Board.ClearArrows();
			Board.Fill();
			HistoryToLvMoves();
			SetingsToGamers();
			int curColor = Chess.g_moveNumber & 1;
			GamerList.curIndex = curColor;
			if (GamerList.GamerCur().player.IsComputer())
				GamerList.Rotate(curColor);

			CGamer gw = GamerList.gamer[0];
			CGamer gb = GamerList.gamer[1];
			FormLogEngines.WriteHeader(gw, gb);
			FormLogEngines.AppendTimeText($"Pgn {CHistory.GetPgn()}\n", Color.Gray);
			ShowInfo($"Load pgn {CHistory.GetPgn()}", Color.Lime, 1);
			ShowInfo(gw);
			ShowInfo(gb);

			moves = Chess.GenerateValidMoves(out _);
			CData.gameState = CGameState.normal;
			SetGameState(Chess.GetGameState());
			SetBoardRotate();
			RenderBoard(true);
			SetUnranked();
		}

		private void MoveToLvMoves(int count, int piece, string umo, string score)
		{
			string[] p = { "", "\u2659", "\u2658", "\u2657", "\u2656", "\u2655", "\u2654", "", "", "\u265F", "\u265E", "\u265D", "\u265C", "\u265B", "\u265A", "" };
			string m = $"{p[piece]} {umo}";
			bool white = (count & 1) == 0;
			if (white || (lvMoves.Items.Count == 0))
			{
				var items = lvMoves.Items;
				bool last = items.Count <= 0 || items[items.Count - 1].Selected;
				int moveNumber = (count >> 1) + 1;
				string wm = "";
				string ws = "";
				string bm = "";
				string bs = "";
				if (white)
				{
					wm = m;
					ws = score;
				}
				else
				{
					bm = m;
					bs = score;
				}
				ListViewItem lvItem = new ListViewItem(new[] { moveNumber.ToString(), wm, ws, bm, bs });
				lvMoves.Items.Add(lvItem);
				if (last)
				{
					lvItem.Selected = true;
					lvItem.EnsureVisible();
				}
			}
			else
			{
				lvMoves.Items[lvMoves.Items.Count - 1].SubItems[3].Text = m;
				lvMoves.Items[lvMoves.Items.Count - 1].SubItems[4].Text = score;
			}
		}

		void HistoryToLvMoves()
		{
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			for (int n = 0; n < CHistory.moveList.Count; n++)
			{
				CHisMove m = CHistory.moveList[n];
				MoveToLvMoves(n, m.piece, m.GetNotation(), "");
			}
		}

		bool TryMove(int s, int d)
		{
			if ((s < 0) || (d < 0) || (s > 63) || (d > 63))
				return false;
			string umo = CChess.IndexToUmo(s) + CChess.IndexToUmo(d);
			if (Chess.IsValidMove(umo, out _))
			{
				MakeMove(umo);
				return true;
			}
			if (Chess.IsValidMove(umo + "q", out _))
			{
				CPromotion.umo = umo;
				CPromotion.sou = s;
				CPromotion.des = d;
				CBoard.MakeMove(s, d);
				Board.RenderBoard();
				RenderBoard();
				tlpPromotion.Dock = boardRotate ^ Chess.whiteTurn ? DockStyle.Bottom : DockStyle.Top;
				tlpPromotion.BackColor = Chess.whiteTurn ? Color.Black : Color.White;
				Color color = Chess.whiteTurn ? Color.White : Color.Black;
				foreach (Control ctl in tlpPromotion.Controls)
					ctl.ForeColor = color;
				tlpPromotion.Show();
				return true;
			}
			return false;
		}

		bool IsValid(int i)
		{
			foreach (int c in moves)
			{
				int x = i & 7;
				int y = i >> 3;
				int s = Chess.MakeSquare(x, y);
				if ((c & 0xff) == s) return true;
			}
			return false;
		}

		bool IsValid(int sou, int des)
		{
			if (sou == des)
				return true;
			int sx = sou & 7;
			int sy = sou >> 3;
			int sa = Chess.MakeSquare(sx, sy);
			int dx = des & 7;
			int dy = des >> 3;
			int da = Chess.MakeSquare(dx, dy);
			int a = (da << 8) | sa;
			foreach (int c in moves)
				if ((c & 0xffff) == a)
					return true;
			return false;
		}

		void ShowValid()
		{
			foreach (int c in moves)
			{
				int sou = c & 0xff;
				int i = CChess.Con256To64(sou);
				CBoard.arrField[i].color = Color.Yellow;
			}
		}

		void ShowValid(int index)
		{
			int max = index & 7;
			int may = index >> 3;
			int sa = Chess.MakeSquare(max, may);
			foreach (int c in moves)
				if ((c & 0xff) == sa)
				{
					int des = (c >> 8) & 0xff;
					int x = (des & 0xf) - 4;
					int y = (des >> 4) - 4;
					int i = y * 8 + x;
					CBoard.arrField[i].color = Color.Yellow;
				}
		}

		void SetIndex(int i)
		{
			Board.ClearColors();
			if (i == -1)
			{
				ShowValid();
			}
			else
			{
				if (i == CDrag.lastDes)
					ShowValid(i);
			}
			CDrag.lastDes = i;
			CDrag.lastSou = -1;
		}

		void LinesResize(ListView lv)
		{
			int w = 100;
			for (int n = 0; n < lv.Columns.Count - 1; n++)
				lv.Columns[n].Width = w;
			lv.Columns[lv.Columns.Count - 1].Width = lv.Width - 32 - w * (lv.Columns.Count - 1);
		}

		#endregion

		#region mode

		void GameSet()
		{
			CModeGame.color = cbColor.Text;
			CModeGame.computer = cbComputer.Text;
			CModeGame.engine = cbEngine.Text;
			CModeGame.book = cbBook.Text;
			CModeGame.modeValue.mode = cbMode.Text;
			CModeGame.modeValue.SetValue((int)nudValue.Value);
			CModeGame.SaveToIni();
		}

		void GameGet()
		{
			cbColor.Text = CModeGame.color;
			cbComputer.Text = CModeGame.computer;
			cbEngine.Text = CModeGame.engine;
			cbBook.Text = CModeGame.book;
			cbMode.Text = CModeGame.modeValue.mode;
			nudValue.Value = CModeGame.modeValue.GetValue();
		}

		void SetingsToGamers()
		{
			GamerList.Init();
			GamerList.gamer[0].SetPlayer(playerList.GetPlayerRealHuman());
			CPlayer pc = new CPlayer();
			if (cbComputer.Text == "Custom")
			{
				pc.engine = cbEngine.Text;
				pc.book = cbBook.Text;
				pc.modeValue.mode = CModeGame.modeValue.mode;
				pc.modeValue.value = CModeGame.modeValue.value;
			}
			else
				pc = playerList.GetPlayerAuto(cbComputer.Text);
			GamerList.gamer[1].SetPlayer(pc);
		}

		void GameStart()
		{
			ComClear();
			CPlayer hu = playerList.GetPlayerRealHuman();
			CData.HisToPoints(hu.hisElo, chartGame.Series[0].Points);
			CModeGame.ranked = GetRanked();
			GameSet();
			SetingsToGamers();
			if (ShowLastGame())
				CModeGame.rotate = !CModeGame.rotate;
			if ((CModeGame.rotate && (cbColor.Text == "Auto")) || (cbColor.Text == "Black"))
				GamerList.Rotate(0);
			SetBoardRotate();
			RenderBoard(true);
			ShowAutoElo();
			ComShow();
		}

		void GameShow()
		{
			GameGet();
			GameStart();
		}

		void GaemEnd(CPlayer pw, CPlayer pl, bool isDraw)
		{
			if (GetRanked() && CModeGame.ranked)
			{
				if (pw.IsRealHuman())
				{
					if (isDraw)
						pw.elo = pw.eloOrg;
					else
						pw.elo = pw.GetEloMore().ToString();
				}
				else
				{
					if (isDraw)
						pl.elo = pl.eloOrg;
					else
						pl.elo = pl.GetEloLess().ToString();
				}
				ShowLastGame(true);
			}
			else
				SetUnranked();
		}

		void MatchSet()
		{
			CModeMatch.engine1 = cbEngine1.Text;
			CModeMatch.engine2 = cbEngine2.Text;
			CModeMatch.book1 = cbMatchBook1.Text;
			CModeMatch.book2 = cbMatchBook2.Text;
			CModeMatch.modeValue1.mode = cbMode1.Text;
			CModeMatch.modeValue2.mode = cbMode2.Text;
			CModeMatch.modeValue1.SetValue((int)nudValue1.Value);
			CModeMatch.modeValue2.SetValue((int)nudValue2.Value);
		}

		void MatchGet()
		{
			cbEngine1.Text = CModeMatch.engine1;
			cbEngine2.Text = CModeMatch.engine2;
			cbMatchBook1.Text = CModeMatch.book1;
			cbMatchBook2.Text = CModeMatch.book2;
			cbMode1.Text = CModeMatch.modeValue1.mode;
			cbMode2.Text = CModeMatch.modeValue2.mode;
			nudValue1.Value = CModeMatch.modeValue1.GetValue();
			nudValue2.Value = CModeMatch.modeValue2.GetValue();
		}

		void MatchShow()
		{
			MatchGet();
			CModeMatch.his.MinMax(out double min, out double max);
			double last = CModeMatch.his.Last();
			labMatchGames.Text = $"Games {CModeMatch.games} result {last} min {min} max {max}";
			labMatch11.Text = CModeMatch.win.ToString();
			labMatch12.Text = CModeMatch.loose.ToString();
			labMatch13.Text = CModeMatch.draw.ToString();
			labMatch14.Text = $"{Math.Round(CModeMatch.Result(false))}%";
			labMatch21.Text = CModeMatch.loose.ToString();
			labMatch22.Text = CModeMatch.win.ToString();
			labMatch23.Text = CModeMatch.draw.ToString();
			labMatch24.Text = $"{Math.Round(CModeMatch.Result(true))}%";
			CData.HisToPoints(CModeMatch.his, chartMatch.Series[0].Points);
		}

		void MatchStart()
		{
			ComClear();
			MatchSet();
			SetMode(CGameMode.match);
			CPlayer p1 = new CPlayer("Player 1");
			p1.engine = CModeMatch.engine1;
			p1.book = CModeMatch.book1;
			p1.modeValue.mode = CModeMatch.modeValue1.mode;
			p1.modeValue.value = CModeMatch.modeValue1.value;
			CPlayer p2 = new CPlayer("Player 2");
			p2.engine = CModeMatch.engine2;
			p2.book = CModeMatch.book2;
			p2.modeValue.mode = CModeMatch.modeValue2.mode;
			p2.modeValue.value = CModeMatch.modeValue2.value;
			GamerList.gamer[0].SetPlayer(p1);
			GamerList.gamer[1].SetPlayer(p2);
			p1.elo = GamerList.gamer[0].engine.elo;
			p2.elo = GamerList.gamer[1].engine.elo;
			if (CModeMatch.rotate)
				GamerList.Rotate(0);
			CModeMatch.rotate = !CModeMatch.rotate;
			moves = Chess.GenerateValidMoves(out _);
			CModeMatch.SaveToIni();
			ComShow();
		}

		void MatchEnd(CPlayer pw, bool isDraw)
		{
			CModeMatch.games++;
			if (!isDraw)
			{
				if (pw.name == labMatchPlayer1.Text)
					CModeMatch.win++;
				else
					CModeMatch.loose++;
			}
			else
				CModeMatch.draw++;
			CModeMatch.his.Add(CModeMatch.win - CModeMatch.loose);
			CModeMatch.SaveToIni();
		}

		void TournamentEShow()
		{
			cbTourEMode.SelectedIndex = cbTourEMode.FindStringExact(CModeTournamentE.modeValue.mode);
			cbTourEBook.SelectedIndex = cbTourEBook.FindStringExact(CModeTournamentE.book);
		}

		void TournamentEReset()
		{
			lvEngine.Items.Clear();
			CEngineList engList = CModeTournamentE.FillList();
			foreach (CEngine e in engList.list)
			{
				ListViewItem lvi = new ListViewItem(new[] { e.name, e.elo, e.GetDeltaElo().ToString() });
				lvi.BackColor = e.hisElo.GetColor();
				lvEngine.Items.Add(lvi);
			}
			ListViewItem item = lvEngine.FindItemWithText(CModeTournamentE.engine);
			if (item != null)
				item.Selected = true;
		}

		void TournamentEUpdate(CEngine e)
		{
			if (e != null)
				foreach (ListViewItem lvi in lvEngine.Items)
					if (lvi.Text == e.name)
					{
						lvi.SubItems[1].Text = e.elo;
						lvi.SubItems[2].Text = e.GetDeltaElo().ToString();
						lvi.BackColor = e.hisElo.GetColor();
					}
		}

		void TournamentEShowHistory()
		{
			if (lvEngine.SelectedItems.Count == 0)
				return;
			ListViewItem top2 = null;
			string name = lvEngine.SelectedItems[0].Text;
			CEngineList engineList = CModeTournamentE.engineList;
			CEngine engine = engineList.GetEngine(name);
			lvEngineH.Items.Clear();
			engineList.SortElo();
			engineList.FillPosition();
			int countGames = 0;
			int opponents = 0;
			foreach (CEngine e in engineList.list)
			{
				int count = CModeTournamentE.tourList.CountGames(name, e.name, out int gw, out int gl, out int gd);
				if (count > 0)
				{
					opponents++;
					int pro = (gw * 200 + gd * 100) / count - 100;
					int elo = Convert.ToInt32(engine.elo) - Convert.ToInt32(e.elo);
					ListViewItem lvi = new ListViewItem(new[] { e.name, elo.ToString(), count.ToString(), pro.ToString() });
					if (elo > 0)
						lvi.BackColor = CBoard.colorListW;
					if (elo < 0)
						lvi.BackColor = CBoard.colorListB;
					if (elo == 0)
						lvi.BackColor = Color.White;
					lvEngineH.Items.Add(lvi);
					int up = (lvEngineH.ClientRectangle.Height / lvi.Bounds.Height) >> 1;
					int del = engine.position - e.position;
					if (del >= up)
						top2 = lvi;
				}
				countGames += count;
			}
			int rep1 = engine.name == CModeTournamentE.engine ? CModeTournamentE.games : 0;
			int rep2 = engine.name == CModeTournamentE.engine ? CModeTournamentE.repetition - 1 : engine.tournament;
			labEngine.BackColor = engine.hisElo.GetColor();
			labEngine.Text = $"{engine.name} games {countGames} opponents {opponents}/{engineList.list.Count} repetitions {rep1}/{rep2}";
			if (top2 != null)
				lvEngineH.TopItem = top2;
			CData.HisToPoints(engine.hisElo, chartTournamentE.Series[1].Points);
			CEngine eb = engineList.NextTournament(engine, false, true);
			if (eb != null)
				CData.HisToPoints(eb.hisElo, chartTournamentE.Series[0].Points);
			else
				chartTournamentE.Series[0].Points.Clear();
			CEngine en = engineList.NextTournament(engine, false, false);
			if (en != null)
				CData.HisToPoints(en.hisElo, chartTournamentE.Series[2].Points);
			else
				chartTournamentE.Series[2].Points.Clear();
		}

		void TournamentESelect()
		{
			int del = lvEngine.TopItem.Bounds.Top;
			foreach (ListViewItem lvi in lvEngine.Items)
				if (lvi.Text == CModeTournamentE.engine)
				{
					int c = (lvEngine.ClientRectangle.Height - del) / lvi.Bounds.Height;
					int top = lvi.Index - (c >> 1);
					if (top < 0)
						top = 0;
					lvi.Selected = true;
					lvEngine.TopItem = lvEngine.Items[top];
					lvEngine.Sort();
					lvEngine.Focus();
					TournamentEShowHistory();
					break;
				}
		}

		void TournamentEStart()
		{
			ComClear();
			TournamentEUpdate(CModeTournamentE.engWin);
			TournamentEUpdate(CModeTournamentE.engLoose);
			CModeTournamentE.modeValue.mode = cbTourEMode.Text;
			CModeTournamentE.modeValue.SetValue((int)nudTourE.Value);
			CModeTournamentE.book = cbTourEBook.Text;
			CModeTournamentE.SaveToIni();
			SetMode(CGameMode.tourE);
			CEngine e1 = CModeTournamentE.SelectEngine();
			CEngine e2 = CModeTournamentE.SelectOpponent(e1);
			CPlayer p1 = new CPlayer(e1.name);
			CPlayer p2 = new CPlayer(e2.name);
			p1.engine = e1.name;
			p2.engine = e2.name;
			p1.elo = e1.elo;
			p2.elo = e2.elo;
			p1.book = CModeTournamentE.book;
			p1.modeValue.mode = CModeTournamentE.modeValue.mode;
			p1.modeValue.value = CModeTournamentE.modeValue.value;
			p2.book = CModeTournamentE.book;
			p2.modeValue.mode = CModeTournamentE.modeValue.mode;
			p2.modeValue.value = CModeTournamentE.modeValue.value;
			CModeTournamentE.SetRepeition(e1, e2);
			GamerList.gamer[CModeTournamentE.rotate ? 1 : 0].SetPlayer(p1);
			GamerList.gamer[CModeTournamentE.rotate ? 0 : 1].SetPlayer(p2);
			TournamentESelect();
			ComShow();
		}

		void TournamentEEnd(CGamer gw, CGamer gl, bool isDraw)
		{
			CEngineList engList = CModeTournamentE.engineList;
			CPlayer plw = GamerList.gamer[0].player;
			CPlayer plb = GamerList.gamer[1].player;
			CEngine ew = gw.engine;
			CEngine el = gl.engine;
			CModeTournamentE.engWin = ew;
			CModeTournamentE.engLoose = el;
			int eloW = gw.engine.GetElo();
			int eloL = gl.engine.GetElo();
			int indexW = engList.GetIndexElo(eloW);
			int indexL = engList.GetIndexElo(eloL);
			int optW = engList.GetOptElo(indexW, CModeTournamentE.minElo, CModeTournamentE.maxElo);
			int optL = engList.GetOptElo(indexL, CModeTournamentE.minElo, CModeTournamentE.maxElo);
			int OW = optW;
			int OL = optL;
			int newW;
			int newL;
			if (!isDraw)
			{
				if (eloW <= eloL)
				{
					OW = optL;
					OL = optW;
				}
				if (OW < eloW)
					OW = eloW;
				if (OL > eloL)
					OL = eloL;
				if (OW == OL)
					OW = engList.GetOptElo(indexW + 1);
				double cg = CModeTournamentE.tourList.CountGames(CModeTournamentE.engine, CModeTournamentE.opponent, out _, out _, out _);
				double mod = 0.6 + (cg / 0xf) * 0.3;
				if (mod > 0.9)
					mod = 0.9;
				newW = Convert.ToInt32(eloW * mod + Math.Max(OW, eloL) * (1.0 - mod));
				newL = Convert.ToInt32(eloL * mod + Math.Min(OL, eloW) * (1.0 - mod));
				string r = gw.player == plw ? "w" : "b";
				CModeTournamentE.tourList.Write(plw.engine, plb.engine, r);
			}
			else
			{
				int opt = (OW + OL) >> 1;
				newW = Convert.ToInt32(eloW * 0.9 + opt * 0.1);
				newL = Convert.ToInt32(eloL * 0.9 + opt * 0.1);
				CModeTournamentE.tourList.Write(plw.engine, plb.engine, "d");
			}
			ew.hisElo.Add(newW);
			el.hisElo.Add(newL);
			ew.elo = newW.ToString();
			el.elo = newL.ToString();
			ew.SaveToIni();
			el.SaveToIni();
			if (isDraw || (newW > newL))
				CModeTournamentE.repetition--;
		}

		void TournamentPReset()
		{
			lvPlayer.Items.Clear();
			CPlayerList plaList = CModeTournamentP.FillList();
			foreach (CPlayer p in plaList.list)
			{
				ListViewItem lvi = new ListViewItem(new[] { p.name, p.elo, p.GetDeltaElo().ToString() });
				lvi.BackColor = p.hisElo.GetColor();
				lvPlayer.Items.Add(lvi);
			}
			ListViewItem item = lvPlayer.FindItemWithText(CModeTournamentP.player);
			if (item != null)
				item.Selected = true;
		}

		void TournamentPUpdate(CPlayer p)
		{
			if (p != null)
				foreach (ListViewItem lvi in lvPlayer.Items)
					if (lvi.Text == p.name)
					{
						lvi.SubItems[1].Text = p.elo;
						lvi.SubItems[2].Text = p.GetDeltaElo().ToString();
						lvi.BackColor = p.hisElo.GetColor();
					}
		}

		void TournamentPShowHistory()
		{
			if (lvPlayer.SelectedItems.Count == 0)
				return;
			ListViewItem top2 = null;
			string name = lvPlayer.SelectedItems[0].Text;
			CPlayerList playerList = CModeTournamentP.playerList;
			CPlayer player = playerList.GetPlayer(name);
			lvPlayerH.Items.Clear();
			playerList.SortElo();
			playerList.FillPosition();
			int countGames = 0;
			int opponents = 0;
			foreach (CPlayer p in playerList.list)
				if (p.engine != "Human")
				{
					int count = CModeTournamentP.tourList.CountGames(name, p.name, out int gw, out int gl, out int gd);
					if (count > 0)
					{
						opponents++;
						int pro = (gw * 200 + gd * 100) / count - 100;
						int elo = Convert.ToInt32(player.elo) - Convert.ToInt32(p.elo);
						ListViewItem lvi = new ListViewItem(new[] { p.name, elo.ToString(), count.ToString(), pro.ToString() });
						if (elo > 0)
							lvi.BackColor = CBoard.colorListW;
						if (elo < 0)
							lvi.BackColor = CBoard.colorListB;
						if (elo == 0)
							lvi.BackColor = Color.White;
						lvPlayerH.Items.Add(lvi);
						int up = (lvPlayerH.ClientRectangle.Height / lvi.Bounds.Height) >> 1;
						int del = player.position - p.position;
						if (del >= up)
							top2 = lvi;
					}
					countGames += count;
				}
			int rep1 = player.name == CModeTournamentP.player ? CModeTournamentP.games : 0;
			int rep2 = player.name == CModeTournamentP.player ? CModeTournamentP.repetition : player.tournament - 1;
			labPlayer.BackColor = player.hisElo.GetColor();
			labPlayer.Text = $"{player.name} games {countGames} opponents {opponents}/{playerList.list.Count} repetitions {rep1}/{rep2}";
			if (top2 != null)
				lvPlayerH.TopItem = top2;
			CData.HisToPoints(player.hisElo, chartTournamentP.Series[1].Points);
			CPlayer pb = playerList.NextTournament(player, false, true);
			if (pb != null)
				CData.HisToPoints(pb.hisElo, chartTournamentP.Series[0].Points);
			else
				chartTournamentP.Series[0].Points.Clear();
			CPlayer pn = playerList.NextTournament(player, false, false);
			if (pn != null)
				CData.HisToPoints(pn.hisElo, chartTournamentP.Series[2].Points);
			else
				chartTournamentP.Series[2].Points.Clear();
		}

		void TournamentPSelect()
		{
			int del = lvEngine.TopItem.Bounds.Top;
			foreach (ListViewItem lvi in lvPlayer.Items)
				if (lvi.Text == CModeTournamentP.player)
				{
					int c = (lvPlayer.ClientRectangle.Height - del) / lvi.Bounds.Height;
					int top = lvi.Index - (c >> 1);
					if (top < 0)
						top = 0;
					lvi.Selected = true;
					lvPlayer.TopItem = lvPlayer.Items[top];
					lvPlayer.Sort();
					lvPlayer.Focus();
					TournamentPShowHistory();
					break;
				}
		}

		void TournamentPStart()
		{
			ComClear();
			TournamentPUpdate(CModeTournamentP.plaWin);
			TournamentPUpdate(CModeTournamentP.plaLoose);
			SetMode(CGameMode.tourP);
			CPlayer p1 = CModeTournamentP.SelectPlayer();
			CPlayer p2 = CModeTournamentP.SelectOpponent(p1);
			CModeTournamentP.SetRepeition(p1, p2);
			GamerList.gamer[CModeTournamentP.rotate ? 1 : 0].SetPlayer(p1);
			GamerList.gamer[CModeTournamentP.rotate ? 0 : 1].SetPlayer(p2);
			TournamentPSelect();
			ComShow();
		}

		void TournamentPEnd(CPlayer pw, CPlayer pl, bool isDraw)
		{
			CPlayerList plaList = CModeTournamentP.playerList;
			CPlayer plw = GamerList.gamer[0].player;
			CPlayer plb = GamerList.gamer[1].player;
			CModeTournamentP.plaWin = pw;
			CModeTournamentP.plaLoose = pl;
			int eloW = pw.GetElo();
			int eloL = pl.GetElo();
			int indexW = plaList.GetIndexElo(eloW);
			int indexL = plaList.GetIndexElo(eloL);
			int optW = plaList.GetOptElo(indexW, CModeTournamentP.minElo, CModeTournamentP.maxElo);
			int optL = plaList.GetOptElo(indexL, CModeTournamentP.minElo, CModeTournamentP.maxElo);
			int OW = optW;
			int OL = optL;
			int newW;
			int newL;
			if (!isDraw)
			{
				if (eloW <= eloL)
				{
					OW = optL;
					OL = optW;
				}
				if (OW < eloW)
					OW = eloW;
				if (OL > eloL)
					OL = eloL;
				if (OW == OL)
					OW = plaList.GetOptElo(indexW + 1);
				double cg = CModeTournamentP.tourList.CountGames(CModeTournamentE.engine, CModeTournamentE.opponent, out _, out _, out _);
				double mod = 0.6 + (cg / 0xf) * 0.3;
				if (mod > 0.9)
					mod = 0.9;
				newW = Convert.ToInt32(eloW * mod + Math.Max(OW, eloL) * (1.0 - mod));
				newL = Convert.ToInt32(eloL * mod + Math.Min(OL, eloW) * (1.0 - mod));
				string r = pw == plw ? "w" : "b";
				CModeTournamentP.tourList.Write(plw.name, plb.name, r);
			}
			else
			{
				int opt = (OW + OL) >> 1;
				newW = Convert.ToInt32(eloW * 0.9 + opt * 0.1);
				newL = Convert.ToInt32(eloL * 0.9 + opt * 0.1);
				CModeTournamentP.tourList.Write(plw.name, plb.name, "d");
			}
			pw.hisElo.Add(newW);
			pl.hisElo.Add(newL);
			pw.elo = newW.ToString();
			pl.elo = newL.ToString();
			pw.SaveToIni();
			pl.SaveToIni();
			if (isDraw || (newW > newL))
				CModeTournamentP.repetition--;
		}

		void TrainingShow()
		{
			cbTeacherEngine.SelectedIndex = cbTeacherEngine.FindStringExact(CModeTraining.teacher);
			cbTrainedEngine.SelectedIndex = cbTrainedEngine.FindStringExact(CModeTraining.trained);
			cbTeacherMode.SelectedIndex = cbTeacherMode.FindStringExact(CModeTraining.modeValueTeacher.mode);
			cbTrainedMode.SelectedIndex = cbTrainedMode.FindStringExact(CModeTraining.modeValueTrained.mode);
			cbTeacherBook.SelectedIndex = cbTeacherBook.FindStringExact(CModeTraining.teacherBook);
			cbTrainedBook.SelectedIndex = cbTrainedBook.FindStringExact(CModeTraining.trainedBook);
			nudTrained.Value = CModeTraining.modeValueTrained.GetValue();
			nudTrained.Increment = CModeTraining.modeValueTrained.GetValueIncrement();
			nudTeacher.Value = CModeTraining.modeValueTeacher.GetValue();
			nudTeacher.Increment = CModeTraining.modeValueTeacher.GetValueIncrement();
			TrainingUpdate();
		}

		void TrainingUpdate()
		{
			label12.Text = CModeTraining.win.ToString();
			label13.Text = CModeTraining.loose.ToString();
			label14.Text = CModeTraining.draw.ToString();
			label15.Text = $"{CModeTraining.Result(false)}%";
			label7.Text = CModeTraining.loose.ToString();
			label8.Text = CModeTraining.win.ToString();
			label9.Text = CModeTraining.draw.ToString();
			label10.Text = $"{CModeTraining.Result(true)}%";
		}

		void TrainingStart()
		{
			ComClear();
			TrainingUpdate();
			CModeTraining.teacher = cbTeacherEngine.Text;
			CModeTraining.trained = cbTrainedEngine.Text;
			CModeTraining.modeValueTeacher.mode = cbTeacherMode.Text;
			CModeTraining.modeValueTrained.mode = cbTrainedMode.Text;
			CModeTraining.teacherBook = cbTeacherBook.Text;
			CModeTraining.trainedBook = cbTrainedBook.Text;
			CModeTraining.modeValueTeacher.SetValue((int)nudTeacher.Value);
			CModeTraining.modeValueTrained.SetValue((int)nudTrained.Value);
			SetMode(CGameMode.training);
			CPlayer pw = new CPlayer("Trained");
			pw.engine = CModeTraining.trained;
			pw.book = CModeTraining.trainedBook;
			pw.modeValue.mode = CModeTraining.modeValueTrained.mode;
			pw.modeValue.value = CModeTraining.modeValueTrained.value;
			CPlayer pb = new CPlayer("Teacher");
			pb.engine = CModeTraining.teacher;
			pb.book = CModeTraining.teacherBook;
			pb.modeValue.mode = CModeTraining.modeValueTeacher.mode;
			pb.modeValue.value = CModeTraining.modeValueTeacher.value;
			GamerList.gamer[0].SetPlayer(pw);
			GamerList.gamer[1].SetPlayer(pb);
			pw.elo = GamerList.gamer[0].engine.elo;
			pb.elo = GamerList.gamer[1].engine.elo;
			if (CModeTraining.rotate)
				GamerList.Rotate(0);
			CModeTraining.rotate = !CModeTraining.rotate;
			chartTraining.Series[0].Points.Add((double)nudTeacher.Value);
			if (chartTraining.Series[0].Points.Count > FormOptions.This.nudHistory.Value)
				chartTraining.Series[0].Points.RemoveAt(0);
			chartTraining.ChartAreas[0].RecalculateAxesScale();
			CModeTraining.SaveToIni();
			ComShow();
		}

		void TrainingEnd(CGamer gw, bool isDraw)
		{
			bool up = true;
			CModeTraining.games++;
			if (!isDraw)
			{
				if (gw.player.name == "Teacher")
				{
					CModeTraining.win++;
					if (--CModeTraining.modeValueTeacher.value < 1)
						CModeTraining.modeValueTeacher.value = 1;
					decimal nv = nudTeacher.Value - nudTeacher.Increment;
					if (nv < nudTeacher.Minimum)
						nv = nudTeacher.Minimum;
					nudTeacher.Value = nv;
					up = false;
				}
				else
				{
					CModeTraining.loose++;
					CModeTraining.modeValueTeacher.value++;
				}
			}
			else
			{
				CModeTraining.draw++;
				CModeTraining.modeValueTeacher.value++;
			}
			if (up)
				nudTeacher.Value += nudTeacher.Increment;
		}

		void EditShow(string fen = CChess.defFen)
		{
			PrepareFen(fen);
			List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
			int i = Chess.whiteTurn ? 1 : 0;
			list[i].Select();
			int cr = Chess.g_castleRights;
			clbCastling.SetItemChecked(0, (Chess.g_castleRights & 1) > 0);
			clbCastling.SetItemChecked(1, (Chess.g_castleRights & 2) > 0);
			clbCastling.SetItemChecked(2, (Chess.g_castleRights & 4) > 0);
			clbCastling.SetItemChecked(3, (Chess.g_castleRights & 8) > 0);
			Chess.g_castleRights = cr;
		}

		#endregion

		#region show

		private void enginesToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (formHisE.Visible)
				formHisE.Focus();
			else
				formHisE.Show(this);
		}

		private void playersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formHisP.Visible)
				formHisP.Focus();
			else
				formHisP.Show(this);
		}

		private void programLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formLogProgram.Visible)
				formLogProgram.Focus();
			else
				formLogProgram.Show(this);
		}

		private void gamesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (formLogGames.Visible)
				formLogGames.Focus();
			else
				formLogGames.Show(this);
		}

		private void enginesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (formLogEngines.Visible)
				formLogEngines.Focus();
			else
				formLogEngines.Show(this);
		}

		private void lastGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("game");
		}

		private void lastMatchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("match");
		}

		private void lasstTournamentenginesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("tournament-engines");
		}

		private void lastTournamentplayersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("tournament-players");
		}

		private void lastTrainingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowFormLastGame("training");
		}

		private void lastErrorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			labError.Hide();
			ShowFormLastGame("error");
		}

		private void booksToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			FormBook.This.ShowDialog(this);
			Reset();
		}

		private void playersToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			FormPlayer.This.ShowDialog(this);
			Reset();
		}

		private void enginesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormEngine.This.ShowDialog(this);
			Reset();
		}

		private void labError_Click(object sender, EventArgs e)
		{
			labError.Hide();
			ShowFormLastGame("error");
		}

		#endregion

		#region events

		private void FormChess_FormClosing(object sender, FormClosingEventArgs e)
		{
			IniSave();
			GamerList.Terminate();
			FormEngine.process.Terminate();
			FormLogEngines.process.Terminate();
		}

		private void ButStart_Click(object sender, EventArgs e)
		{
			GameStart();
		}

		private void ButStop_Click(object sender, EventArgs e)
		{
			GamerList.GamerCur().EngineStop();
		}

		private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormOptions.This.ShowDialog(this);
			toolTip1.Active = FormOptions.ShowTips();
			CBoard.SetColor(FormOptions.colorBoard);
			CBoard.ClearAttack();
			CBoard.animated = true;
			Board.arrowCur.Clear();
			Board.arrowEco.Clear();
			ShowAutoElo();
			ShowEco();
			HistoryToLvMoves();
			BoardPrepare();
			RenderBoard();
		}

		private void ButTraining_Click(object sender, EventArgs e)
		{
			CModeTraining.Reset();
			chartTraining.Series[0].Points.Clear();
			TrainingStart();
		}

		private void saveToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Chess.GetFen());
		}

		private void loadFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadFen(Clipboard.GetText().Trim());
		}

		private void loadPgnFromClipboard_Click(object sender, EventArgs e)
		{
			LoadPgn(Clipboard.GetText().Trim());
		}

		private void bStartMatch_Click(object sender, EventArgs e)
		{
			CModeMatch.Reset();
			MatchStart();
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			CDrag.mouseX = e.X;
			CDrag.mouseY = e.Y;
			Board.GetFieldXY(e.X, e.Y, out int x, out int y);
			if (boardRotate)
			{
				x = 7 - x;
				y = 7 - y;
			}
			CDrag.mouseIndex = y * 8 + x;
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (tlpPromotion.Visible)
				return;
			if (CData.gameMode == CGameMode.edit)
			{
				int i = CChess.arrField[CDrag.mouseIndex];
				int f = Chess.g_board[i];
				int r = f & 7;
				if (e.Button == MouseButtons.Left)
				{
					if ((Chess.g_board[i] & CChess.colorWhite) == 0)
						Chess.g_board[i] = CChess.colorWhite | CChess.piecePawn;
					else
					{
						if (++r == CChess.pieceKing + 1)
							Chess.g_board[i] = CChess.colorEmpty;
						else
							Chess.g_board[i] = CChess.colorWhite | r;
					}
				}
				if (e.Button == MouseButtons.Right)
				{
					if ((Chess.g_board[i] & CChess.colorBlack) == 0)
						Chess.g_board[i] = CChess.colorBlack | CChess.piecePawn;
					else
					{
						if (++r == CChess.pieceKing + 1)
							Chess.g_board[i] = CChess.colorEmpty;
						else
							Chess.g_board[i] = CChess.colorBlack | r;
					}
				}
				if (e.Button == MouseButtons.Middle)
				{
					Chess.g_board[i] = CChess.colorEmpty;
				}
				Board.Fill();
				RenderBoard(true);
			}
			if (CData.gameMode == (int)CGameMode.game)
			{
				if (e.Button == MouseButtons.Right)
				{
					CField f = CBoard.arrField[CDrag.mouseIndex];
					f.circle = !f.circle;
					return;
				}
				if (GamerList.GamerCur().engine != null)
					return;
				if (IsValid(CDrag.mouseIndex))
				{
					CDrag.last = CDrag.lastDes;
					CDrag.dragged = true;
					SetIndex(CDrag.mouseIndex);
				}
				else
					if (!IsValid(CDrag.lastDes))
					SetIndex(-1);
				if (!IsValid(CDrag.lastDes, CDrag.mouseIndex))
					SetIndex(-1);
			}
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (tlpPromotion.Visible)
				return;
			if (CData.gameMode == (int)CGameMode.game)
			{
				if (CDrag.lastDes == CDrag.mouseIndex)
					TryMove(CDrag.last, CDrag.mouseIndex);
				else
					TryMove(CDrag.lastDes, CDrag.mouseIndex);
				CDrag.dragged = false;
				CBoard.animated = true;
			}
		}

		private void butClearBoard_Click(object sender, EventArgs e)
		{
			for (int n = 0; n < 64; n++)
			{
				int i = CChess.arrField[n];
				Chess.g_board[i] = CChess.colorEmpty;
				CBoard.UpdateField(n);
			}
			RenderBoard(true);
		}

		private void rbColorChanged(object sender, EventArgs e)
		{
			var checkedButton = gbToMove.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
			int i = list.IndexOf(checkedButton);
			Chess.whiteTurn = i == 1;
			boardRotate = !Chess.whiteTurn;
			Board.Fill();
			RenderBoard(true);
		}

		private void butContinueGame_Click(object sender, EventArgs e)
		{
			LoadFen(Chess.GetFen());
		}

		private void SaveToClipboardToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(CHistory.GetPgn());
		}

		private void clbCastling_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			switch (e.Index)
			{
				case 0:
					Chess.g_castleRights ^= 1;
					break;
				case 1:
					Chess.g_castleRights ^= 2;
					break;
				case 2:
					Chess.g_castleRights ^= 4;
					break;
				case 3:
					Chess.g_castleRights ^= 8;
					break;
			}
		}

		private void butContinueMatch_Click(object sender, EventArgs e)
		{
			CModeMatch.SaveToIni();
			MatchStart();
		}

		private void butDefault_Click(object sender, EventArgs e)
		{
			Chess.SetFen();
			Board.Fill();
			RenderBoard(true);
		}

		private void cbComputer_SelectedValueChanged(object sender, EventArgs e)
		{
			CModeGame.ranked = cbComputer.Text == "Auto";
			ShowAutoElo();
			butNewGame.Focus();
		}

		private void panBoard_Resize(object sender, EventArgs e)
		{
			panBoard.Invalidate();
			BoardPrepare();
		}

		private void lvLines_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = 100;
			for (int n = 0; n < lv.Columns.Count - 1; n++)
				lv.Columns[n].Width = w;
			lv.Columns[lv.Columns.Count - 1].Width = lv.Width - w * (lv.Columns.Count - 1);
			ShowScrollBar(lv.Handle, 0, false);
		}

		private void lvMoves_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = lv.Width - 32;
			w = Convert.ToInt32(w / 9);
			lv.Columns[0].Width = w;
			lv.Columns[1].Width = w * 2;
			lv.Columns[2].Width = w * 2;
			lv.Columns[3].Width = w * 2;
			lv.Columns[4].Width = w * 2;
			ShowScrollBar(lv.Handle, 0, false);
		}

		private void panBoard_Paint(object sender, PaintEventArgs e)
		{
			RenderBoard();
		}

		private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeGame.modeValue.mode = cbMode.Text;
			nudValue.Increment = CModeGame.modeValue.GetValueIncrement();
			nudValue.Minimum = nudValue.Increment;
			nudValue.Value = CModeGame.modeValue.GetValue();
			toolTip1.SetToolTip(nudValue, CModeGame.modeValue.GetTip());
		}

		private void cbMode1_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeMatch.modeValue1.mode = cbMode1.Text;
			nudValue1.Increment = CModeMatch.modeValue1.GetValueIncrement();
			nudValue1.Minimum = nudValue1.Increment;
			nudValue1.Value = CModeMatch.modeValue1.GetValue();
			toolTip1.SetToolTip(nudValue1, CModeMatch.modeValue1.GetTip());
		}

		private void cbMode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeMatch.modeValue2.mode = cbMode2.Text;
			nudValue2.Increment = CModeMatch.modeValue2.GetValueIncrement();
			nudValue2.Minimum = nudValue2.Increment;
			nudValue2.Value = CModeMatch.modeValue2.GetValue();
			toolTip1.SetToolTip(nudValue2, CModeMatch.modeValue2.GetTip());
		}

		private void cbTrainedMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTraining.modeValueTrained.mode = cbTrainedMode.Text;
			nudTrained.Increment = CModeTraining.modeValueTrained.GetValueIncrement();
			nudTrained.Minimum = nudTrained.Increment;
			nudTrained.Value = CModeTraining.modeValueTrained.GetValue();
			toolTip1.SetToolTip(nudTrained, CModeTraining.modeValueTrained.GetTip());
		}

		private void cbTeacherMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTraining.modeValueTeacher.mode = cbTeacherMode.Text;
			nudTeacher.Increment = CModeTraining.modeValueTeacher.GetValueIncrement();
			nudTeacher.Minimum = nudTeacher.Increment;
			nudTeacher.Value = Math.Max(CModeTraining.modeValueTeacher.GetValue(), nudTeacher.Minimum);
			toolTip1.SetToolTip(nudTeacher, CModeTraining.modeValueTeacher.GetTip());
		}

		private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowAutoElo();
		}

		private void cbMainMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CData.Clear();
			FormLogGames.This.textBox1.Text = String.Empty;
			tabControl1.SelectedIndex = combMainMode.SelectedIndex;
			Board.Fill();
			RenderBoard();
			SetMode((CGameMode)combMainMode.SelectedIndex);
		}

		private void butResignation_Click(object sender, EventArgs e)
		{
			if (GetRanked() && IsGameLong() && IsGameProgress())
			{
				CPlayer hu = playerList.GetPlayerRealHuman();
				hu.elo = hu.GetEloLess().ToString();
			}
			SetGameState(CGameState.resignation);
		}

		private void butStartTournamentE_Click(object sender, EventArgs e)
		{
			CModeTournamentE.NewGame();
			TournamentEStart();
		}

		private void butStartTournamentP_Click(object sender, EventArgs e)
		{
			CModeTournamentP.NewGame();
			TournamentPStart();
		}

		private void cbTourEMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTournamentE.modeValue.mode = (sender as ComboBox).Text;
			nudTourE.Increment = CModeTournamentE.modeValue.GetValueIncrement();
			nudTourE.Minimum = nudTourE.Increment;
			nudTourE.Value = Math.Max(CModeTournamentE.modeValue.GetValue(), nudTourE.Minimum);
			toolTip1.SetToolTip(nudTourE, CModeTournamentE.modeValue.GetTip());
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetMode((CGameMode)tabControl1.SelectedIndex);
		}

		private void lvEngine_SelectedIndexChanged(object sender, EventArgs e)
		{
			TournamentEShowHistory();
		}

		private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView lv = sender as ListView;
			lv.Tag = lv.Tag == null ? new Object() : null;
			(sender as ListView).ListViewItemSorter = new ListViewComparer(e.Column, lv.Tag == null ? SortOrder.Ascending : SortOrder.Descending);
		}

		private void butForward_Click(object sender, EventArgs e)
		{
			SetUnranked();
			GamerList.Rotate(GamerList.curIndex);
		}

		private void labPromoQ_Click(object sender, EventArgs e)
		{
			CBoard.MakeMove(CPromotion.des, CPromotion.sou);
			MakeMove(CPromotion.umo + (sender as Label).Text);
			tlpPromotion.Hide();
		}

		private void FormChess_Resize(object sender, EventArgs e)
		{
			lvMoves_Resize(lvMoves, null);
			LinesResize(lvMovesW);
			LinesResize(lvMovesB);
			SplitLoadFromIni();
		}

		private void lvEngine_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = lv.Width - 32;
			w = Convert.ToInt32(w / 4);
			lv.Columns[0].Width = w * 2;
			lv.Columns[1].Width = w;
			lv.Columns[2].Width = w;
		}

		private void lvEngineH_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = lv.Width - 32;
			w = Convert.ToInt32(w / 6);
			lv.Columns[0].Width = w * 3;
			lv.Columns[1].Width = w;
			lv.Columns[2].Width = w;
			lv.Columns[3].Width = w;
		}

		private void lvPlayer_SelectedIndexChanged(object sender, EventArgs e)
		{
			TournamentPShowHistory();
		}

		private void butEditStart_Click(object sender, EventArgs e)
		{
			LoadFen(Chess.GetFen());
		}

		private void labEngine_Click(object sender, EventArgs e)
		{
			TournamentESelect();
		}

		private void labPlayer_Click(object sender, EventArgs e)
		{
			TournamentPSelect();
		}

		private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
		{
			splitContainerBoard.SplitterDistance = panBoard.Height;
		}

		private void timerAnimation_Tick(object sender, EventArgs e)
		{
			GameLoop();
		}

		private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
		{
			UpdateEngineList();
		}

		private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
		{
			UpdateEngineList();
		}

		private void splitContainerBoard_Panel1_Resize(object sender, EventArgs e)
		{
			SquareBoard();
		}

		private void butBackward_Click(object sender, EventArgs e)
		{
			if (CHistory.Back(1))
				LoadFromHistory();
		}

		private void lvMoves_Click(object sender, EventArgs e)
		{
			if ((CData.gameMode != CGameMode.game) || (lvMoves.SelectedItems.Count == 0))
				return;
			int index = lvMoves.SelectedItems[0].Index;
			if (CHistory.BackTo(index, GamerList.GamerHuman().isWhite))
				LoadFromHistory();
		}

		#endregion
	}
}
