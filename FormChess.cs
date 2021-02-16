using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
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
		public const int WM_GAME_MESSAGE = 1025;
		public static IntPtr handle;

		bool showInfo = false;
		public static FormChess This;
		public static bool boardRotate;
		string lastEco = "";
		List<int> moves = new List<int>();
		public CRapIni RapIni = new CRapIni();
		readonly CBoard Board = new CBoard();
		readonly CEcoList EcoList = new CEcoList();
		public CChess Chess = new CChess();
		readonly CGamerList GamerList = new CGamerList();
		readonly CUci Uci = new CUci();
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
				case WM_GAME_MESSAGE:
					GetMessage();
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
			CreateDir("Engines//Uci");
			CreateDir("Engines//Winboard");
			CreateDir("History");
			CData.UpdateFileEngine();
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
			CMessageList.Init(WM_GAME_MESSAGE);
			Chess.Initialize();
			BoardPrepare();
			combMainMode.SelectedIndex = 0;
			GameStart();
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
				b.file = "BookReaderBru.exe";
				b.name = "Auto";
				b.parameters = "[engine] -lw 10";
				bookList.Add(b);
				b = new CBook();
				b.file = "BookReaderBru.exe";
				b.parameters = "Eco";
				bookList.Add(b);
				b = new CBook();
				b.file = "BookReaderBru.exe";
				b.parameters = "Tiny";
				bookList.Add(b);
				b = new CBook();
				b.file = "BookReaderBru.exe";
				b.parameters = "Random1";
				bookList.Add(b);
				b = new CBook();
				b.file = "BookReaderBru.exe";
				b.parameters = "Random2";
				bookList.Add(b);
				b = new CBook("ChessDb");
				b.file = "BookReaderCdb.exe";
				bookList.Add(b);
				for (int n = 1; n < 10; n++)
				{
					int v = n * 10;
					b = new CBook();
					b.file = "BookReaderRnd.exe";
					b.parameters = v.ToString();
					bookList.Add(b);
				}
				bookList.SaveToIni();
			}
			playerList.LoadFromIni();
			if (playerList.GetPlayerHuman() == null)
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
				p.book = "BRU Eco";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "500";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapSimpleCs";
				p.book = "BRU Eco";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "1000";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChessCs";
				p.book = "ChessDb";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "1200";
				playerList.Add(p);
				playerList.SaveToIni();
			}
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

		void Clear()
		{
			Text = $"RapChessGui Games {CData.gamesPlayed} Draws {CData.gamesDraw} Time out {CData.gamesTime} Errors {CData.gamesError}";
			CData.gameState = CGameState.normal;
			labEloD.BackColor = Color.LightGray;
			labEloD.ForeColor = Color.Black;
			labEloT.BackColor = Color.LightGray;
			labEloT.ForeColor = Color.Black;
			labEco.Text = "";
			tssMove.Text = "Move 1 0";
			ShowInfo("Good luck", Color.Gainsboro, true);
			labResult.Hide();
			chartMain.Series[0].Points.Clear();
			chartMain.Series[1].Points.Clear();
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			PrepareFen();
			PrepareGamers();
		}

		public void SetColor()
		{
			Color l = CBoard.GetColor(CBoard.colorMedium, Color.White, 0.5);
			Color d = CBoard.GetColor(CBoard.colorMedium, Color.Black, 0.5);
			labPlayerW.BackColor = d;
			labPlayerB.BackColor = d;
			labEngineW.BackColor = d;
			labEngineB.BackColor = d;
			labBookNW.BackColor = d;
			labBookNB.BackColor = d;
			labModeW.BackColor = d;
			labModeB.BackColor = d;
			labProtocolW.BackColor = d;
			labProtocolB.BackColor = d;
			labMemoryW.BackColor = d;
			labMemoryB.BackColor = d;
			labScoreW.BackColor = l;
			labScoreB.BackColor = l;
			labDepthW.BackColor = l;
			labDepthB.BackColor = l;
			labNodesW.BackColor = l;
			labNodesB.BackColor = l;
			labNpsW.BackColor = l;
			labNpsB.BackColor = l;
			labBookCW.BackColor = l;
			labBookCB.BackColor = l;
			labPonderW.BackColor = l;
			labPonderB.BackColor = l;
			chartMain.PaletteCustomColors[0] = CBoard.colorMediumW;
			chartMain.PaletteCustomColors[1] = CBoard.colorMediumB;
			chartGame.PaletteCustomColors[0] = CBoard.colorDark;
			chartMatch.PaletteCustomColors[0] = CBoard.colorDark;
			chartTournamentE.PaletteCustomColors[0] = CBoard.colorMedium;
			chartTournamentE.PaletteCustomColors[1] = CBoard.colorDark;
			chartTournamentE.PaletteCustomColors[2] = CBoard.colorBright;
			chartTournamentP.PaletteCustomColors[0] = CBoard.colorMedium;
			chartTournamentP.PaletteCustomColors[1] = CBoard.colorDark;
			chartTournamentP.PaletteCustomColors[2] = CBoard.colorBright;
			BackColor = CBoard.colorDark;
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
			CHistory.SetFen(fen);
			Board.ClearArrows();
			Board.ClearColors();
			Board.Fill();
		}

		void PrepareGamers()
		{
			CGamer gw = GamerList.gamer[0];
			CGamer gb = GamerList.gamer[1];
			formLogEngines.NewGame(gw, gb);
			GamerList.Init();
			ShowGamers();
			ShowInfo(gw);
			ShowInfo(gb);
			SetBoardRotate();
			CMessageList.Clear();
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
			splitContainerMoves.Panel1Collapsed = gw.player.IsHuman();
			splitContainerMoves.Panel2Collapsed = gb.player.IsHuman();
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
						labTimeD.BackColor = low ? CBoard.colorRed : CBoard.colorDark;
						labTimeD.ForeColor = CBoard.colorBrighter;
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
						labTimeT.BackColor = low ? CBoard.colorRed : CBoard.colorDark;
						labTimeT.ForeColor = CBoard.colorBrighter;
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
					ShowInfo(pw.name + " win", Color.Lime);
					break;
				case CGameState.stalemate:
					isDraw = true;
					ShowInfo("Stalemate", Color.Yellow);
					break;
				case CGameState.repetition:
					isDraw = true;
					ShowInfo("Threefold repetition", Color.Yellow);
					break;
				case CGameState.move50:
					isDraw = true;
					ShowInfo("Fifty-move rule", Color.Yellow);
					break;
				case CGameState.material:
					isDraw = true;
					ShowInfo("Insufficient material", Color.Yellow);
					break;
				case CGameState.resignation:
					ShowInfo($"{pl.name} resign", Color.Red);
					break;
				case CGameState.time:
					CData.gamesTime++;
					ShowInfo($"{pl.name} time out", Color.Red);
					CRapLog.Add($"Time out {pl.name}");
					break;
				case CGameState.error:
					CData.gamesError++;
					labError.Show();
					ShowInfo($"{pl.name} make wrong move", Color.Red);
					CRapLog.Add($"Wrong move {pl.name} ({umo}) {Chess.GetFen()}");
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
			CreateRtf();
			CreatePgn();
			if (CData.gameMode == CGameMode.game)
				GaemEnd(pw, pl, isDraw);
			if (CData.gameMode == CGameMode.match)
				MatchEnd(pw, isDraw);
			if (CData.gameMode == CGameMode.tourE)
				TournamentEEnd(gw, gl, isDraw);
			if (CData.gameMode == CGameMode.tourP)
				TournamentPEnd(pw, pl, isDraw);
			if (CData.gameMode == CGameMode.training)
				TrainingEnd(gw, gl, isDraw);
			GamerList.Terminate();
			if (isDraw)
				CData.gamesDraw++;
			CData.gamesPlayed++;
			Task.Delay(FormOptions.gameBreak * 1000).ContinueWith(t => CWinMessage.Message(WM_GAME_NEXT));
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
				lvi.BackColor = CBoard.colorBrighter;
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
					g.uciok = true;
					foreach (string op in g.engine.options)
						g.SendMessage($"setoption {op}");
					g.SendMessage("ucinewgame");
					g.SendMessage("isready");
					break;
				case "readyok":
					g.readyok = true;
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
							if ((g.engine != null) && g.engine.IsXb())
								g.isEngPrepared = false;
						}
						MakeMove(umo);
						if ((g.ponder != "") && FormOptions.This.rbSan.Checked)
							g.ponder = Chess.UmoToSan(g.ponder);
					}
					break;
				case "info":
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
						SetPv(i, g);
					break;
			}
		}

		bool GetMoveXb(string xmo, out string umo)
		{
			umo = xmo.ToLower();
			if (xmo == "o-o")
				umo = Chess.whiteTurn ? "e1g1" : "e8g8";
			if (xmo == "o-o-o")
				umo = Chess.whiteTurn ? "e1c1" : "e8c8";
			if (Chess.IsValidMoveUmo(umo, out _))
				return true;
			else
			{
				umo += "q";
				if (Chess.IsValidMoveUmo(umo, out _))
					return true;
				else
				{
					umo = xmo;
					return false;
				}
			}
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
					else if (g.wbok && Char.IsDigit(Uci.tokens[0][0]) && (Uci.tokens.Length > 4))
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

		public void GetMessage()
		{
			while (CMessageList.MessageGet(out CMessage m))
			{
				CGamer gamer = GamerList.GetGamerPid(m.pid, out string protocol);
				if (gamer == null)
					CRapLog.Add($"Unknown pid ({GamerList.GamerCur().player.engine} - {GamerList.GamerSec().player.engine})");
				else
				{
					string book = protocol == "Book" ? "book " : "";
					Color col = gamer.isWhite ? Color.DimGray : Color.Black;
					FormLogEngines.AppendTimeText($"{book}{gamer.player.name}", col);
					FormLogEngines.AppendText($" > {m.msg}\n", Color.DarkBlue);
					if ((protocol == "Uci") || (protocol == "Book"))
						GetMessageUci(gamer, m.msg);
					if (protocol == "Winboard")
						GetMessageXb(gamer, m.msg);
				}
			}
		}

		void CreateRtf()
		{
			string fn = CData.gameState == CGameState.error ? "Error" : combMainMode.Text;
			fn = $"History\\{fn}.rtf";
			try
			{
				FormLogEngines.This.richTextBox1.SaveFile(fn);
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
			list.Add($"[Date \"{DateTime.Now:yyyy.MM.dd}\"]");
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
			Clear();
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
				CPlayer ph = playerList.GetPlayerHuman();
				ph.elo = ph.eloOrg;
				ph.SaveToIni();
			}
			ShowAutoElo();
		}

		void ShowInfo(string info, Color color, bool si = false)
		{
			if (si || !showInfo)
			{
				tssInfo.Text = info;
				tssInfo.ForeColor = color;
				showInfo = si;
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
				if (GamerD().player.IsHuman())
				{
					labEloD.BackColor = CBoard.colorDark;
					labEloD.ForeColor = CBoard.colorBrighter;
				}
				if (GamerT().player.IsHuman())
				{
					labEloT.BackColor = CBoard.colorDark;
					labEloT.ForeColor = CBoard.colorBrighter;
				}
			}
		}

		bool ShowLastGame(bool changeProgress = false)
		{
			bool result = false;
			CPlayer hu = playerList.GetPlayerHuman();
			int eloCur = Convert.ToInt32(hu.elo);
			int eloOld = Convert.ToInt32(hu.eloOrg);
			int eloDel = eloCur - eloOld;
			if (eloDel > 0)
			{
				result = true;
				ShowInfo($"Last game you win new elo is {hu.elo} (+{eloDel})", Color.FromArgb(0, 0xff, 0), true);
			}
			if (eloDel < 0)
			{
				result = true;
				ShowInfo($"Last game you loose new elo is {hu.elo} ({eloDel})", Color.FromArgb(0xff, 0, 0), true);
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
			Reset(true);
		}

		void Reset(bool auto = false)
		{
			CBoard.SetColor(FormOptions.colorBoard);
			BackColor = CBoard.colorDark;
			if (!auto && !CData.reset)
				return;
			CData.reset = false;
			cbEngine.Items.Clear();
			cbTeacherEngine.Items.Clear();
			cbTrainedEngine.Items.Clear();
			cbEngine1.Items.Clear();
			cbEngine2.Items.Clear();
			foreach (CEngine e in engineList.list)
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
			TournamentEReset();
			TournamentPReset();
			lvPlayer.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			lvEngine.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			MatchShow();
			TournamentEShow();
			TrainingShow();
		}

		public bool MakeMove(string umo)
		{
			if (CData.gameState != CGameState.normal)
				return false;
			Board.arrowCur.Clear();
			CGamer cg = GamerList.GamerCur();
			cg.timer.Stop();
			umo = umo.ToLower();
			double m = GamerList.curIndex == 0 ? 0.01 : -0.01;
			chartMain.Series[GamerList.curIndex].Points.Add(cg.iScore * m);
			if (GetRanked() && CModeGame.ranked && (cg.engine == null) && ((Chess.g_moveNumber >> 1) == 4))
			{
				cg.player.eloOrg = cg.player.elo;
				cg.player.elo = cg.player.GetEloLess().ToString();
				cg.player.SaveToIni();
			}
			if (!Chess.IsValidMoveUmo(umo, out int gmo))
				if (Chess.IsValidMoveUmo($"{umo}q", out gmo))
					umo = $"{umo}q";
			if (gmo == 0)
			{
				FormLogEngines.AppendText($"Wrong move: ({umo})\n", Color.Red);
				FormLogEngines.AppendText($"Fen: {Chess.GetFen()}\n", Color.Black);
				SetGameState(CGameState.error, cg, umo);
				return false;
			}
			cg.countMoves++;
			string san = Chess.UmoToSan(umo);
			CChess.UmoToSD(umo, out CDrag.lastSou, out CDrag.lastDes);
			Board.MakeMove(gmo);
			Chess.MakeMove(umo, out int piece);
			CHistory.AddMove(piece, gmo, umo, san);
			MoveToLvMoves(CHistory.moveList.Count - 1, piece, CHistory.LastNotation(), cg.score);
			CEco eco = EcoList.GetEcoFen(Chess.GetEpd());
			showInfo = false;
			if (cg.player.IsHuman())
			{
				tssInfo.Text = "";
				Board.ClearArrows();
				if (eco != null)
					ShowInfo(eco.name, Color.Lime, true);
				else if ((lastEco != "") && (!lastEco.Contains(umo)))
				{
					ShowInfo("You missed the opening moves", Color.Pink, true);
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
				labEco.Text = eco.name;
				lastEco = eco.continuations;
			}
			else
			{
				labEco.ForeColor = Color.Black;
				lastEco = "";
			}
			int moveNumber = (Chess.g_moveNumber >> 1) + 1;
			tssMove.Text = $"Move {moveNumber} {Chess.g_move50}";
			SetGameState(Chess.GetGameState());
			if (CData.gameState == CGameState.normal)
			{
				GamerList.Next();
				if (GamerList.GamerCur().player.IsHuman())
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
			boardRotate = (GamerList.gamer[1].player.IsHuman() && GamerList.gamer[0].player.IsComputer()) ^ CData.rotateBoard;
			if ((GamerList.gamer[1].player.IsHuman()) && (GamerList.gamer[0].player.IsHuman()))
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
			Board.RenderArrow(pg, FormOptions.This.cbArrow.Checked);
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
					int piece = CChess.g_board[((y + 4) << 4) + x + 4];
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
			GamerList.curIndex = Chess.g_moveNumber & 1;
			cbColor.SelectedIndex = GamerList.curIndex == 0 ? 1 : 2;
			GamePrepare();
			if (GamerList.GamerCur().player.IsComputer())
				GamerList.Rotate();
			SetBoardRotate();
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			CHistory.SetFen(fen);
			Board.Fill();
			RenderBoard();
			CGamer gw = GamerList.gamer[0];
			CGamer gb = GamerList.gamer[1];
			FormLogEngines.WriteHeader(gw, gb);
			FormLogEngines.AppendTimeText($"Fen {Chess.GetFen()}\n", Color.Gray);
			tssInfo.ForeColor = Color.Lime;
			tssInfo.Text = $"Load fen {Chess.GetFen()}";
			CData.gameState = Chess.GetGameState();
			ShowInfo(gw);
			ShowInfo(gb);
			moves = Chess.GenerateValidMoves(out _);
			SetUnranked();
		}

		void LoadPgn(string pgn)
		{
			SetMode((int)CGameMode.game);
			string[] ml = pgn.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			Chess.SetFen();
			CHistory.SetFen();
			foreach (string san in ml)
			{
				if (Char.IsDigit(san, 0))
					continue;
				string umo2 = Chess.SanToUmo(san);
				string san2 = Chess.UmoToSan(umo2);
				int gmo = Chess.MakeMove(umo2, out int piece);
				if (gmo > 0)
					CHistory.AddMove(piece, gmo, umo2, san2);
				else break;
			}
			GamerList.curIndex = Chess.g_moveNumber & 1;
			cbColor.SelectedIndex = GamerList.curIndex == 0 ? 1 : 2;
			GamePrepare();
			if (GamerList.GamerCur().player.IsComputer())
				GamerList.Rotate();
			GamerList.gamer[0].Init(true);
			GamerList.gamer[1].Init(false);
			string umo = CHistory.LastUmo();
			CChess.UmoToSD(umo, out CDrag.lastSou, out CDrag.lastDes);
			ShowHistory();
			SetBoardRotate();
			Board.Fill();
			Board.SetPosition();
			Board.RenderBoard();
			RenderBoard();
			CGamer gw = GamerList.gamer[0];
			CGamer gb = GamerList.gamer[1];
			FormLogEngines.WriteHeader(gw, gb);
			FormLogEngines.AppendTimeText($"Pgn {CHistory.GetPgn()}\n", Color.Gray);
			ShowInfo($"Load pgn {CHistory.GetPgn()}", Color.Gainsboro);
			CData.gameState = Chess.GetGameState();
			ShowInfo(gw);
			ShowInfo(gb);
			moves = Chess.GenerateValidMoves(out _);
			SetUnranked();
		}

		private void MoveToLvMoves(int count, int piece, string umo, string score)
		{
			string[] p = { "", "\u2659", "\u2658", "\u2657", "\u2656", "\u2655", "\u2654", "", "", "\u265F", "\u265E", "\u265D", "\u265C", "\u265B", "\u265A", "" };
			string m = $"{p[piece]} {umo}";
			if ((count & 1) == 0)
			{
				var items = lvMoves.Items;
				bool last = items.Count <= 0 || items[items.Count - 1].Selected;
				int moveNumber = (count >> 1) + 1;
				ListViewItem lvItem = new ListViewItem(new[] { moveNumber.ToString(), m, score, "", "" });
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

		void ShowHistory()
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

		void RenderHistory()
		{
			Chess.SetFen(CHistory.fen);
			foreach (CHisMove m in CHistory.moveList)
				Chess.MakeMove(m.umo);
			CChess.UmoToSD(CHistory.LastUmo(), out CDrag.lastSou, out CDrag.lastDes);
			Board.Fill();
			ShowHistory();
		}

		bool TryMove(int s, int d)
		{
			bool result = Chess.IsValidMove(s, d, out string emo, out bool promo);
			if (result)
				if (promo)
				{
					CPromotion.emo = emo;
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
				}
				else
					MakeMove(emo);
			return result;
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
				CBoard.list[i].color = Color.Yellow;
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
					CBoard.list[i].color = Color.Yellow;
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

		void GamePrepare()
		{
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			GamerList.gamer[0].SetPlayer(playerList.GetPlayerHuman());
			CPlayer pc = new CPlayer(cbComputer.Text);
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
			GameSet();
			SetMode(CGameMode.game);
			lastEco = "";
			if (ShowLastGame())
				CModeGame.rotate = !CModeGame.rotate;
			if ((CModeGame.rotate && (cbColor.Text == "Auto")) || (cbColor.Text == "Black"))
				GamerList.Rotate();
			if (GamerList.GamerCur().player.IsHuman())
				moves = Chess.GenerateValidMoves(out _);
			CModeGame.SaveToIni();
			SetBoardRotate();
			Board.Fill();
			Board.SetPosition();
			Board.RenderBoard();
			RenderBoard();
			Clear();
			GameShow();
		}

		void GameShow()
		{
			GameGet();
			CPlayer hu = playerList.GetPlayerHuman();
			CData.HisToPoints(hu.hisElo, chartGame.Series[0].Points);
			GamePrepare();
			CModeGame.ranked = GetRanked();
			ShowAutoElo();
		}

		void GaemEnd(CPlayer pw, CPlayer pl, bool isDraw)
		{
			if (GetRanked() && CModeGame.ranked)
			{
				if (pw.IsHuman())
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
				GamerList.Rotate();
			CModeMatch.rotate = !CModeMatch.rotate;
			moves = Chess.GenerateValidMoves(out _);
			CModeMatch.SaveToIni();
			Clear();
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
						lvi.BackColor = CBoard.colorBrighterW;
					if (elo < 0)
						lvi.BackColor = CBoard.colorBrighterB;
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
			Clear();
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
			int optW = engList.GetOptElo(indexW);
			int optL = engList.GetOptElo(indexL);
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
			newW = ew.hisElo.Add(newW, 1, 2999);
			newL = el.hisElo.Add(newL, 1, 2999);
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
			ListViewItem item = lvPlayer.SelectedItems[0];
			string name = item.Text;
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
							lvi.BackColor = CBoard.colorBrighterW;
						if (elo < 0)
							lvi.BackColor = CBoard.colorBrighterB;
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
			TournamentPUpdate(CModeTournamentP.plaWin);
			TournamentPUpdate(CModeTournamentP.plaLoose);
			SetMode(CGameMode.tourP);
			CPlayer p1 = CModeTournamentP.SelectPlayer();
			CPlayer p2 = CModeTournamentP.SelectOpponent(p1);
			CModeTournamentP.SetRepeition(p1, p2);
			GamerList.gamer[CModeTournamentP.rotate ? 1 : 0].SetPlayer(p1);
			GamerList.gamer[CModeTournamentP.rotate ? 0 : 1].SetPlayer(p2);
			TournamentPSelect();
			Clear();
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
			int optW = plaList.GetOptElo(indexW);
			int optL = plaList.GetOptElo(indexL);
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
			newW = pw.hisElo.Add(newW, 1, 2999);
			newL = pl.hisElo.Add(newL, 1, 2999);
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
			TrainingUpdate();

		}

		void TrainingUpdate()
		{
			nudTeacher.Value = CModeTraining.modeValueTeacher.GetValue();
			nudTeacher.Increment = CModeTraining.modeValueTeacher.GetValueIncrement();
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
				GamerList.Rotate();
			CModeTraining.rotate = !CModeTraining.rotate;
			chartTraining.Series[0].Points.Add((double)nudTeacher.Value);
			CModeTraining.SaveToIni();
			Clear();
		}

		void TrainingEnd(CGamer gw, CGamer gl, bool isDraw)
		{
			CModeTraining.games++;
			if (!isDraw)
			{
				if (gw.player.name == "Teacher")
				{
					CModeTraining.win++;
					if (--CModeTraining.modeValueTeacher.value < 1)
						CModeTraining.modeValueTeacher.value = 1;
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
			if ((gl.player.name == "Trained") && ((CData.gameState == CGameState.time) || (CData.gameState == CGameState.error) || gl.timeOut))
				CModeTraining.errors++;
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
			CBoard.SetColor(FormOptions.colorBoard);
			CBoard.ClearAttack();
			CBoard.animated = true;
			Board.arrowCur.Clear();
			Board.arrowEco.Clear();
			BoardPrepare();
			ShowAutoElo();
			ShowHistory();
			toolTip1.Active = FormOptions.ShowTips();
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
				int f = CChess.g_board[i];
				int r = f & 7;
				if (e.Button == MouseButtons.Left)
				{
					if ((CChess.g_board[i] & CChess.colorWhite) == 0)
						CChess.g_board[i] = CChess.colorWhite | CChess.piecePawn;
					else
					{
						if (++r == CChess.pieceKing + 1)
							CChess.g_board[i] = CChess.colorEmpty;
						else
							CChess.g_board[i] = CChess.colorWhite | r;
					}
				}
				if (e.Button == MouseButtons.Right)
				{
					if ((CChess.g_board[i] & CChess.colorBlack) == 0)
						CChess.g_board[i] = CChess.colorBlack | CChess.piecePawn;
					else
					{
						if (++r == CChess.pieceKing + 1)
							CChess.g_board[i] = CChess.colorEmpty;
						else
							CChess.g_board[i] = CChess.colorBlack | r;
					}
				}
				if (e.Button == MouseButtons.Middle)
				{
					CChess.g_board[i] = CChess.colorEmpty;
				}
				Board.Fill();
				RenderBoard(true);
			}
			if (CData.gameMode == (int)CGameMode.game)
			{
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
				CChess.g_board[i] = CChess.colorEmpty;
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
			FormLogGames.This.textBox1.Text = "";
			tabControl1.SelectedIndex = combMainMode.SelectedIndex;
			Board.Fill();
			RenderBoard();
			SetMode((CGameMode)combMainMode.SelectedIndex);
		}

		private void butResignation_Click(object sender, EventArgs e)
		{
			if (GetRanked() && IsGameLong() && IsGameProgress())
			{
				CPlayer hu = playerList.GetPlayerHuman();
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

		private void butBackward_Click(object sender, EventArgs e)
		{
			if (CHistory.Back())
			{
				RenderHistory();
				moves = Chess.GenerateValidMoves(out _);
				SetGameState(Chess.GetGameState());
				ShowLastGame();
				GamerList.GamerCur().player.elo = GamerList.GamerCur().player.GetEloLess().ToString();
				GamerList.GamerSec().Undo();
				RenderBoard();
				SetUnranked();
			}
		}

		private void butForward_Click(object sender, EventArgs e)
		{
			SetUnranked();
			GamerList.Rotate();
		}

		private void labPromoQ_Click(object sender, EventArgs e)
		{
			CBoard.MakeMove(CPromotion.des, CPromotion.sou);
			MakeMove(CPromotion.emo + (sender as Label).Text);
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

		#endregion

	}
}
