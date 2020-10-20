using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;
using RapIni;
using RapLog;

namespace RapChessGui
{
	public partial class FormChess : Form
	{
		[DllImport("gdi32.dll")]
		private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
		bool showInfo = false;
		public static FormChess This;
		public static bool boardRotate;
		List<int> moves = new List<int>();
		public CRapIni RapIni = new CRapIni();
		string lastEco = "";
		readonly CEcoList EcoList = new CEcoList();
		readonly CChess Chess = new CChess();
		readonly CGamerList GamerList = new CGamerList();
		readonly CUci Uci = new CUci();
		readonly CBoard Board = new CBoard();
		public static PrivateFontCollection pfc = new PrivateFontCollection();
		public static Stopwatch timer = new Stopwatch();
		public static CBookList bookList = new CBookList();
		public static CEngineList engineList = new CEngineList();
		public static CPlayerList playerList = new CPlayerList();
		readonly FormLogProgram formLogProgram = new FormLogProgram();
		readonly FormLogGames formLogGames = new FormLogGames();
		readonly FormLogEngines formLogEngines = new FormLogEngines();
		readonly FormLogLast formLogLast = new FormLogLast();
		readonly FormHisP formHisP = new FormHisP();
		readonly FormHisE formHisE = new FormHisE();

		#region initiation

		public FormChess()
		{
			This = this;
			int fontLength = Properties.Resources.ChessPiece.Length;
			byte[] fontData = Properties.Resources.ChessPiece;
			IntPtr data = Marshal.AllocCoTaskMem(fontLength);
			Marshal.Copy(fontData, 0, data, fontLength);
			uint cFonts = 0;
			AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);
			pfc.AddMemoryFont(data, fontLength);
			Marshal.FreeCoTaskMem(data);
			InitializeComponent();
			IniCreate();
			IniLoad();
			FormOptions.This = new FormOptions();
			FormEngine.This = new FormEngine();
			FormBook.This = new FormBook();
			FormPlayer.This = new FormPlayer();
			Reset();
			cbColor.SelectedIndex = cbColor.FindStringExact(CModeGame.color);
			cbEngine.SelectedIndex = cbEngine.FindStringExact(CModeGame.engine);
			if ((cbEngine.SelectedIndex == -1) || (cbBook.SelectedIndex == -1) || (cbMode.SelectedIndex == -1))
				CModeGame.computer = "Auto";
			cbComputer.SelectedIndex = cbComputer.FindStringExact(CModeGame.computer);
			Font fontChess = new Font(pfc.Families[0], 16);
			Font fontChessPromo = new Font(pfc.Families[0], 32);
			labTakenT.Font = fontChess;
			labTakenD.Font = fontChess;
			labPromoQ.Font = fontChessPromo;
			labPromoR.Font = fontChessPromo;
			labPromoB.Font = fontChessPromo;
			labPromoN.Font = fontChessPromo;
			toolTip1.Active = FormOptions.ShowTips();
			lvMoves_Resize(lvMoves, null);
			Chess.Initialize();
			BoardPrepare();
			cbMainMode.SelectedIndex = 0;
			GameStart();
		}

		void IniCreate()
		{
			engineList.LoadFromIni();
			if (engineList.list.Count == 0)
			{
				CEngine e;
				e = new CEngine(CEngineList.def);
				e.file = "RapChessCs.exe";
				e.elo = "1100";
				engineList.Add(e);
				e = new CEngine("RapSimple CS");
				e.file = "RapSimpleCs.exe";
				e.elo = "1000";
				engineList.Add(e);
				e = new CEngine("RapShort CS");
				e.file = "RapShortCs.exe";
				e.elo = "900";
				engineList.Add(e);
				engineList.SaveToIni();
			}
			bookList.LoadFromIni();
			if (bookList.list.Count == 0)
			{
				CBook b;
				b = new CBook("Eco");
				b.file = "BookReaderUci.exe";
				b.parameters = "eco.uci";
				bookList.Add(b);
				b = new CBook("Tiny");
				b.file = "BookReaderUci.exe";
				b.parameters = "tiny.uci";
				bookList.Add(b);
				b = new CBook("Random1");
				b.file = "BookReaderUci.exe";
				b.parameters = "random1.uci";
				bookList.Add(b);
				b = new CBook("Random2");
				b.file = "BookReaderUci.exe";
				b.parameters = "random2.uci";
				bookList.Add(b);
				for (int n = 1; n < 10; n++)
				{
					int v = n * 10;
					b = new CBook($"Rand{v}");
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
				p.tournament = false;
				p.modeValue.value = 0;
				p.eloNew = 500;
				p.elo = p.eloNew.ToString();
				playerList.Add(p);
			}
			if (playerList.GetPlayerComputer() == null)
			{
				CPlayer p = new CPlayer();
				p.engine = "RapChess CS";
				p.book = "Rand90";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "200";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChess CS";
				p.book = "Rand70";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "400";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChess CS";
				p.book = "Rand50";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "600";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChess CS";
				p.book = "Rand30";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "800";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChess CS";
				p.book = "Rand10";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "1000";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapShort CS";
				p.book = "Eco";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "500";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapSimple CS";
				p.book = "Eco";
				p.modeValue.mode = "Time";
				p.modeValue.value = 10;
				p.elo = "1000";
				playerList.Add(p);
				p = new CPlayer();
				p.engine = "RapChess CS";
				p.book = "Eco";
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
			SplitLoadFromIni(splitContainerMain);
			SplitLoadFromIni(splitContainerBoard);
			SplitLoadFromIni(splitContainerChart);
			SplitLoadFromIni(splitContainerTourE);
			SplitLoadFromIni(splitContainerTourP);
			SplitLoadFromIni(scTournamentEList);
			SplitLoadFromIni(scTournamentPList);
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
			RapIni.Write("position>maximized", maximized.ToString());
			RapIni.Write("position>width", width.ToString());
			RapIni.Write("position>height", height.ToString());
			RapIni.Write("position>x", x.ToString());
			RapIni.Write("position>y", y.ToString());
			SplitSaveToIni(splitContainerMain);
			SplitSaveToIni(splitContainerBoard);
			SplitSaveToIni(splitContainerChart);
			SplitSaveToIni(splitContainerTourE);
			SplitSaveToIni(splitContainerTourP);
			SplitSaveToIni(scTournamentEList);
			SplitSaveToIni(scTournamentPList);
		}

		void SplitSaveToIni(SplitContainer sc)
		{
			int size = sc.Orientation == Orientation.Horizontal ? sc.Size.Height : sc.Size.Width;
			double p = (double)sc.SplitterDistance / size;
			RapIni.Write($"position>split>{sc.Name}", p.ToString());
		}

		void SplitLoadFromIni(SplitContainer sc)
		{
			int size = sc.Orientation == Orientation.Horizontal ? sc.Size.Height : sc.Size.Width;
			double p = (double)sc.SplitterDistance / size;
			p = RapIni.ReadDouble($"position>split>{sc.Name}", p) * size;
			if (p > 0) sc.SplitterDistance = Convert.ToInt32(p);
		}

		#endregion

		#region main

		public void SetGameState(CGameState gs, bool rotate = false)
		{
			if (gs == CGameState.normal)
			{
				CData.gameState = CGameState.normal;
				return;
			}
			if (CData.gameState != CGameState.normal)
				return;
			CData.gameState = gs;
			CGamer gw = rotate ? GamerList.GamerLoser() : GamerList.GamerWinner();
			CGamer gl = rotate ? GamerList.GamerWinner() : GamerList.GamerLoser();
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
					ShowInfo($"{pl.name} time out", Color.Red);
					break;
				case CGameState.error:
					ShowInfo($"{pl.name} make wrong move", Color.Red);
					break;
			}
			labResult.Text = tssInfo.Text;
			labResult.ForeColor = tssInfo.ForeColor;
			labResult.Show();
			FormLogEngines.AppendText($"Finish {tssInfo.Text}\n", Color.Gray);
			CreateRtf();
			CreatePgn();
			if (CData.gameMode == CMode.game)
				GaemEnd(pw, pl, isDraw);
			if (CData.gameMode == CMode.match)
				MatchEnd(pw, isDraw);
			if (CData.gameMode == CMode.tourE)
				TournamentEEnd(gw, gl, isDraw);
			if (CData.gameMode == CMode.tourP)
				TournamentPEnd(pw, pl, isDraw);
			if (CData.gameMode == CMode.training)
				TrainingEnd(gw, gl, isDraw);
			GamerList.Terminate();
			timerStart.Start();
		}

		public void BoardPrepare()
		{
			SetBoardRotate();
			Board.Resize(panBoard.Width, panBoard.Height);
			RenderBoard();
		}

		void AddLines(CGamer g)
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(g.infMs);
			ListViewItem lvi = new ListViewItem(new[] { dt.ToString("mm:ss.ff"), g.score, g.GetDepth(), g.nodes.ToString("N0"), g.nps.ToString("N0"), g.pv });
			ListView lv = g.white ? lvMovesW : lvMovesB;
			if ((lv.Items.Count & 1) > 0)
				lvi.BackColor = Color.LemonChiffon;
			lv.Items.Insert(0, lvi);
		}

		void SetPv(int i, CGamer g)
		{
			string pv = "";
			List<int> moves = new List<int>();
			for (int n = i; n < Uci.tokens.Length; n++)
			{
				string emo = Uci.tokens[n];
				int gmo = Chess.IsValidMove(emo);
				if (gmo > 0)
				{
					if (moves.Count == 0)
					{
						g.lastMove = emo;
						Board.arrowCur.AddMoves(emo);
						RenderBoard();
					}
					string san = Chess.UmoToSan(emo);
					Chess.MakeMove(gmo);
					moves.Add(gmo);
					if (FormOptions.This.rbSan.Checked)
						pv += $" {san}";
					else
						pv += $" {emo}";
				}
				else break;
			}
			for (int n = moves.Count - 1; n >= 0; n--)
				Chess.UnmakeMove(moves[n]);
			if (pv != "")
				g.pv = pv;
			if (!showInfo)
			{
				tssInfo.ForeColor = Color.Gainsboro;
				tssInfo.Text = pv;
			}
			AddLines(g);
		}

		public void GetMessageUci(CGamer g, string msg)
		{
			string emo;
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
					g.isBookFinished = true;
					break;
				case "bestmove":
					if (GamerList.GamerCur() == g)
					{
						g.ponder = Uci.GetValue("ponder");
						emo = (Uci.tokens[1]).ToLower();
						if (g.isBookStarted && !g.isBookFinished)
						{
							AddBook(emo);
							if (g.engine.IsXb())
								g.isPrepared = false;
						}
						MakeMove(emo);
						if ((g.ponder != "") && FormOptions.This.rbSan.Checked)
							g.ponder = Chess.UmoToSan(g.ponder);
					}
					break;
				case "info":
					ulong nps = 0;
					string s = Uci.GetValue("cp");
					if (s != "")
					{
						g.score = s;
						g.iScore = Int32.Parse(s);
					}
					s = Uci.GetValue("mate");
					if (s != "")
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
					s = Uci.GetValue("depth");
					if (s != "")
						g.depth = s;
					s = Uci.GetValue("seldepth");
					if (s != "")
						g.seldepth = s;
					s = Uci.GetValue("nodes");
					if (s != "")
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
					s = Uci.GetValue("nps");
					if (s != "")
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
					s = Uci.GetValue("time");
					if (s != "")
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
							g.nps = g.infMs > 0 ? (g.nodes * 1000) / g.infMs : 0;
					}
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
				umo = CChess.whiteTurn ? "e1g1" : "e8g8";
			if (xmo == "o-o-o")
				umo = CChess.whiteTurn ? "e1c1" : "e8c8";
			if (Chess.IsValidMove(umo) > 0)
				return true;
			else
			{
				umo += "q";
				if (Chess.IsValidMove(umo) > 0)
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
					SetGameState(CGameState.resignation, GamerList.GamerCur() == g);
					break;
				case "move":
					g.ponder = Uci.GetValue("ponder");
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
						SetGameState(CGameState.resignation, GamerList.GamerCur() == g);
					else if (g.wbok && Char.IsDigit(Uci.tokens[0][0]) && (Uci.tokens.Length > 4))
					{
						try
						{
							g.depth = Uci.tokens[0];
							g.score = Uci.tokens[1];
							g.iScore = Convert.ToInt32(g.score);
							g.infMs = (ulong)Convert.ToInt64(Uci.tokens[2]) * 10;
							g.nodes = (ulong)Convert.ToInt64(Uci.tokens[3]);
							g.nps = g.infMs > 0 ? (g.nodes * 1000) / g.infMs : 0;
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

		public static string GetTimeElapsed()
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(timer.Elapsed.TotalMilliseconds);
			return dt.ToString("HH:mm:ss.fff");
		}

		public void GetMessage()
		{
			while (CMessageList.MessageGet(out CMessage m, GamerList.GamerCur().timer.IsRunning))
			{
				CGamer gamer = GamerList.GetGamerPid(m.pid, out string protocol);
				if (gamer == null)
					CRapLog.Add($"Unknown pid ({GamerList.GamerCur().player.name} - {GamerList.GamerSec().player.name}) ({m.pid})-({GamerList.GamerCur().bookPro.GetPid()} {GamerList.GamerCur().enginePro.GetPid()})-({GamerList.GamerSec().bookPro.GetPid()} {GamerList.GamerSec().enginePro.GetPid()}) ({m.msg})");
				else
				{
					string book = protocol == "Book" ? "book " : "";
					Color col = gamer.white ? Color.DimGray : Color.Black;
					FormLogEngines.AppendText($"{GetTimeElapsed()} ", Color.Green);
					FormLogEngines.AppendText($"{book}{gamer.player.name}", col);
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
			string fn = $"{cbMainMode.Text}.rtf";
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
			list.Add($"[Date \"{DateTime.Now.ToString("yyyy.MM.dd")}\"]");
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
			File.WriteAllText($"{cbMainMode.Text}.pgn", formLogGames.textBox1.Text);
		}

		public void AddBook(string emo)
		{
			GamerList.GamerCur().usedBook++;
			if (!showInfo)
				ShowInfo($"book {emo}", Color.Aquamarine);
		}

		void SetMode(CMode mode)
		{
			timer1.Enabled = false;
			timerStart.Enabled = false;
			GamerList.Terminate();
			CData.gameMode = mode;
			switch (mode)
			{
				case CMode.game:
					Clear();
					GameShow();
					break;
				case CMode.match:
					Clear();
					MatchShow();
					break;
				case CMode.tourE:
					Clear();
					TournamentEShow();
					break;
				case CMode.training:
					Clear();
					TrainingShow();
					break;
				case CMode.edit:
					Clear(Chess.GetFen());
					EditShow();
					break;
			}
		}

		bool IsGameLong()
		{
			return (CChess.g_moveNumber >> 1) > 4;
		}

		bool IsGameProgress()
		{
			return CData.gameState == CGameState.normal;
		}

		bool IsGameRanked()
		{
			return (cbComputer.Text == "Auto") && FormOptions.This.cbGameAutoElo.Checked && (CData.gameMode == CMode.game);
		}

		void ShowAuto(bool first = false)
		{
			if (CModeGame.ranked || first)
			{
				CPlayer p = playerList.GetPlayerAuto();
				cbEngine.SelectedIndex = cbEngine.FindStringExact(p.engine);
				cbMode.SelectedIndex = cbMode.FindStringExact(p.modeValue.mode);
				cbBook.SelectedIndex = cbBook.FindStringExact(p.book);
				nudValue.Value = p.modeValue.GetValue();
			}
		}

		void ShowAutoElo()
		{
			if (IsGameRanked() && CModeGame.ranked)
			{
				labAutoElo.Text = $"Auto Elo On";
				labAutoElo.BackColor = Color.FromArgb(0, 0x80, 0);
			}
			else
			{
				labAutoElo.Text = "Auto Elo Off";
				labAutoElo.BackColor = Color.FromArgb(0x80, 0, 0);
			}
		}

		void ShowInfo(string info, Color color, bool si = false)
		{
			tssInfo.Text = info;
			tssInfo.ForeColor = color;
			showInfo = si;
		}

		bool ShowLastGame(bool changeProgress = false)
		{
			bool result = false;
			CPlayer hu = playerList.GetPlayerHuman();
			int eloCur = Convert.ToInt32(hu.elo);
			int eloDel = hu.eloNew - eloCur;
			if (hu.eloNew > eloCur)
			{
				result = true;
				ShowInfo($"Last game you win new elo is {hu.eloNew} (+{eloDel})", Color.FromArgb(0, 0xff, 0), true);
			}
			if (hu.eloNew < eloCur)
			{
				result = true;
				ShowInfo($"Last game you loose new elo is {hu.eloNew} ({eloDel})", Color.FromArgb(0xff, 0, 0), true);
			}
			if (result || changeProgress)
			{
				hu.hisElo.Add(hu.eloNew);
				CData.HisToPoints(hu.hisElo, chartGame.Series[0].Points);
				CRapLog.Add($"Your new elo {hu.eloNew}");
			}
			hu.elo = hu.eloNew.ToString();
			hu.SaveToIni();
			return result;
		}

		void ShowHistoryTourE()
		{
			if (lvEngine.SelectedItems.Count == 0)
				return;
			ListViewItem top2 = null;
			ListViewItem item = lvEngine.SelectedItems[0];
			string name = item.SubItems[0].Text;
			CEngine engine = engineList.GetEngine(name);
			labEngine.Text = $"{engine.name} - {engine.elo}";
			lvEngineH.Items.Clear();
			engineList.Sort();
			engineList.FillPosition();
			foreach (CEngine e in engineList.list)
			{
				int rw = 0;
				int rl = 0;
				int rd = 0;
				CModeTournamentE.tourList.CountGames(name, e.name, ref rw, ref rl, ref rd);
				int count = rw + rl + rd;
				if (count > 0)
				{
					int pro = (rw * 200 + rd * 100) / count - 100;
					int elo = Convert.ToInt32(engine.elo) - Convert.ToInt32(e.elo);
					ListViewItem lvi = new ListViewItem(new[] { e.name, elo.ToString(), count.ToString(), pro.ToString() });
					if (elo > 0)
						lvi.BackColor = Color.FromArgb(0xe0, 0xff, 0xe0);
					if (elo < 0)
						lvi.BackColor = Color.FromArgb(0xff, 0xe0, 0xe0);
					if (elo == 0)
						lvi.BackColor = Color.FromArgb(0xff, 0xff, 0xff);
					lvEngineH.Items.Add(lvi);
					int up = (lvEngineH.ClientRectangle.Height / lvi.Bounds.Height) >> 1;
					int del = engine.position - e.position;
					if (del >= up)
						top2 = lvi;
				}
			}
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

		void ShowHistoryTourP()
		{
			if (lvPlayer.SelectedItems.Count == 0)
				return;
			ListViewItem top2 = null;
			ListViewItem item = lvPlayer.SelectedItems[0];
			string name = item.SubItems[0].Text;
			CPlayer player = playerList.GetPlayer(name);
			labPlayer.Text = $"{player.name} - {player.elo}";
			lvPlayerH.Items.Clear();
			playerList.Sort();
			playerList.FillPosition();
			foreach (CPlayer p in playerList.list)
				if (p.engine != "Human")
				{
					int rw = 0;
					int rl = 0;
					int rd = 0;
					CModeTournamentP.tourList.CountGames(name, p.name, ref rw, ref rl, ref rd);
					int count = rw + rl + rd;
					if (count > 0)
					{
						int pro = (rw * 200 + rd * 100) / count - 100;
						int elo = Convert.ToInt32(player.elo) - Convert.ToInt32(p.elo);
						ListViewItem lvi = new ListViewItem(new[] { p.name, elo.ToString(), count.ToString(), pro.ToString() });
						if (elo > 0)
							lvi.BackColor = Color.FromArgb(0xe0, 0xff, 0xe0);
						if (elo < 0)
							lvi.BackColor = Color.FromArgb(0xff, 0xe0, 0xe0);
						if (elo == 0)
							lvi.BackColor = Color.FromArgb(0xff, 0xff, 0xff);
						lvPlayerH.Items.Add(lvi);
						int up = (lvPlayerH.ClientRectangle.Height / lvi.Bounds.Height) >> 1;
						int del = player.position - p.position;
						if (del >= up)
							top2 = lvi;
					}
				}
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

		void Reset()
		{
			BackColor = CBoard.color;
			if (!CData.reset)
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
			cbTourEBook.Items.Clear();
			cbTeacherBook.Items.Clear();
			cbTrainedBook.Items.Clear();
			cbBook.Items.Clear();
			cbBook1.Items.Clear();
			cbBook2.Items.Clear();
			cbTourEBook.Items.Add("None");
			cbTeacherBook.Items.Add("None");
			cbTrainedBook.Items.Add("None");
			cbBook.Items.Add("None");
			cbBook1.Items.Add("None");
			cbBook2.Items.Add("None");
			foreach (CBook b in bookList.list)
			{
				cbTourEBook.Items.Add(b.name);
				cbTeacherBook.Items.Add(b.name);
				cbTrainedBook.Items.Add(b.name);
				cbBook.Items.Add(b.name);
				cbBook1.Items.Add(b.name);
				cbBook2.Items.Add(b.name);
			}
			cbTourEBook.SelectedIndex = 0;
			cbTeacherBook.SelectedIndex = 0;
			cbTrainedBook.SelectedIndex = 0;
			cbBook.SelectedIndex = 0;
			cbBook1.SelectedIndex = 0;
			cbBook2.SelectedIndex = 0;
			cbEngine.SelectedIndex = 0;
			TournamentEReset();
			TournamentPReset();
			lvPlayer.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			lvEngine.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			ShowAuto(true);
			MatchShow();
		}

		public bool MakeMove(string emo)
		{
			if (CData.gameState != CGameState.normal)
				return false;
			Board.arrowCur.Clear();
			CGamer cg = GamerList.GamerCur();
			CPlayer cp = cg.player;
			cg.timer.Stop();
			emo = emo.ToLower();
			double m = GamerList.curIndex == 0 ? 0.01 : -0.01;
			chartMain.Series[GamerList.curIndex].Points.Add(cg.iScore * m);
			cg.iScore = 0;
			if (IsGameRanked() && CModeGame.ranked && (cg.engine == null) && ((CChess.g_moveNumber >> 1) == 4))
			{
				cg.player.eloOld = Convert.ToDouble(cg.player.elo);
				cg.player.eloNew = cg.player.GetEloLess();
				cg.player.SaveToIni();
			}
			int gmo = Chess.IsValidMove(emo);
			if (gmo == 0)
			{
				gmo = Chess.IsValidMove($"{emo}q");
				if (gmo != 0)
					emo = $"{emo}q";
			}
			if (gmo == 0)
			{
				List<int> gMoves = Chess.GenerateValidMoves();
				List<string> eMoves = new List<string>();
				foreach (int gm in gMoves)
					eMoves.Add(Chess.GmoToUmo(gm));
				FormLogEngines.AppendText($"Wrong move {emo}\n", Color.Red);
				FormLogEngines.AppendText($"{Chess.GetFen()}\n", Color.Black);
				FormLogEngines.AppendText($"{string.Join(" ", eMoves)}\n", Color.Black);
				FormLogEngines.This.richTextBox1.SaveFile("Error.rtf");
				CRapLog.Add($"Wrong move {cp.engine} {emo} {Chess.GetFen()}");
				SetGameState(CGameState.error);
				return false;
			}
			string san = Chess.UmoToSan(emo);
			CChess.UmoToSD(emo, out CDrag.lastSou, out CDrag.lastDes);
			Board.MakeMove(gmo);
			Chess.MakeMove(emo, out int piece);
			CHistory.AddMove(piece, gmo, emo, san);
			MoveToLvMoves(CHistory.moveList.Count - 1, piece, CHistory.LastNotation());
			CEco eco = EcoList.GetEcoFen(Chess.GetEpd());
			showInfo = false;
			if (cg.player.IsHuman())
			{
				showInfo = false;
				tssInfo.Text = "";
				Board.Clear();
				if (eco != null)
				{
					showInfo = true;
					tssInfo.ForeColor = Color.Lime;
					tssInfo.Text = eco.name;
				}
				else if ((lastEco != "") && (!lastEco.Contains(emo)))
				{
					ShowInfo("You missed the opening moves", Color.Pink, true);
					Board.arrowEco.AddMoves(lastEco);
				}
			}
			if (cg.white)
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
			int moveNumber = (CChess.g_moveNumber >> 1) + 1;
			tssMove.Text = "Move " + moveNumber.ToString() + " " + Chess.g_move50.ToString();
			SetGameState(Chess.GetGameState());
			if (CData.gameState == CGameState.normal)
			{
				GamerList.Next();
				if (GamerList.GamerCur().player.IsHuman())
					moves = Chess.GenerateValidMoves();
				else
					if (GamerList.GamerCur().white)
					lvMovesW.Items.Clear();
				else
					lvMovesB.Items.Clear();
			}
			SetBoardRotate();
			return true;
		}

		void Clear(string fen = CChess.defFen)
		{
			labEco.Text = "";
			tssMove.Text = "Move 1 0";
			ShowInfo("Good luck", Color.Gainsboro, true);
			labResult.Hide();
			chartMain.Series[0].Points.Clear();
			chartMain.Series[1].Points.Clear();
			SetBoardRotate();
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			Chess.SetFen(fen);
			CHistory.NewGame(fen);
			Board.ColorClear();
			Board.Fill();
			GamerList.Init();
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			CData.back = 0;
			CGamer pw = GamerList.gamer[0];
			CGamer pb = GamerList.gamer[1];
			FormLogEngines.This.richTextBox1.Clear();
			FormLogEngines.AppendText($"Time {DateTime.Now.ToString("yyyy-MM-dd HH:mm")}\n", Color.Gray);
			if (pw.engine != null)
				FormLogEngines.AppendText($"White {pw.player.name} {pw.player.engine} {pw.engine.parameters}\n", Color.Gray);
			if (pb.engine != null)
				FormLogEngines.AppendText($"Black {pb.player.name} {pb.player.engine} {pb.engine.parameters}\n", Color.Gray);
			labBack.Text = $"Back {CData.back}";
			CData.gameState = (int)CGameState.normal;
			RenderInfo(pw);
			RenderInfo(pb);
			Board.Clear();
			CMessageList.Clear();
			timer1.Enabled = CData.gameMode != CMode.edit;
			ShowGamers();
			timer.Restart();
		}

		void SetBoardRotate()
		{
			boardRotate = (GamerList.gamer[1].player.IsHuman() && GamerList.gamer[0].player.IsComputer()) ^ CData.rotateBoard;
			if ((GamerList.gamer[1].player.IsHuman()) && (GamerList.gamer[0].player.IsHuman()))
				boardRotate = !CChess.whiteTurn;
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
			Board.Render(pg);
			pg.Dispose();
			stopwatch.Stop();
			CData.fps = stopwatch.ElapsedMilliseconds > 0 ? CData.fps * 0.9 + 100 / stopwatch.ElapsedMilliseconds : 0;
			labFPS.Text = $"FPS {Convert.ToInt32(CData.fps)}";
		}

		void RenderInfo(CGamer g)
		{
			if (!FormOptions.This.cbShowPonder.Checked)
				g.ponder = "";
			if (boardRotate ^ g.white)
			{
				if (CData.gameState == CGameState.normal)
				{
					labTimeD.Text = g.GetTime();
					if ((g.timer.IsRunning) || (CData.gameState != CGameState.normal))
						labTimeD.BackColor = labTimeD.Text.Contains('.') ? Color.Pink : Color.Yellow;
					else
						labTimeD.BackColor = Color.LightGray;
				}
				labEloD.Text = g.GetElo();
				labScoreD.Text = $"Score {g.score}";
				labNodesD.Text = $"Nodes {g.nodes.ToString("N0")}";
				labNpsD.Text = $"Nps {g.nps.ToString("N0")}";
				labPonderD.Text = $"Ponder {g.ponder}";
				labBookD.Text = $"Book {g.usedBook}";
				labDepthD.Text = $"Depth {g.GetDepth()}";
			}
			else
			{
				if (CData.gameState == CGameState.normal)
				{
					labTimeT.Text = g.GetTime();
					if ((g.timer.IsRunning) || (CData.gameState != CGameState.normal))
						labTimeT.BackColor = labTimeT.Text.Contains('.') ? Color.Pink : Color.Yellow;
					else if (CData.gameState == CGameState.normal)
						labTimeT.BackColor = Color.LightGray;
				}
				labEloT.Text = g.GetElo();
				labScoreT.Text = $"Score {g.score}";
				labNodesT.Text = $"Nodes {g.nodes.ToString("N0")}";
				labNpsT.Text = $"Nps {g.nps.ToString("N0")}";
				labPonderT.Text = $"Ponder {g.ponder}";
				labBookT.Text = $"Book {g.usedBook}";
				labDepthT.Text = $"Depth {g.GetDepth()}";
			}
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
			SetMode((int)CMode.game);
			CModeGame.ranked = false;
			if (!Chess.SetFen(fen))
			{
				MessageBox.Show("Wrong fen");
				return;
			}
			GamerList.curIndex = CChess.g_moveNumber & 1;
			cbColor.SelectedIndex = GamerList.curIndex == 0 ? 1 : 2;
			GamePrepare();
			if (GamerList.GamerCur().player.IsComputer())
				GamerList.Rotate();
			GamerList.gamer[0].Init(true);
			GamerList.gamer[1].Init(false);
			SetBoardRotate();
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			CHistory.NewGame(fen);
			Board.Fill();
			RenderBoard();
			CGamer pw = GamerList.gamer[0];
			CGamer pb = GamerList.gamer[1];
			FormLogEngines.This.richTextBox1.Clear();
			FormLogEngines.AppendText($"Fen {Chess.GetFen()}\n", Color.Gray);
			if (pw.engine == null)
				FormLogEngines.AppendText($"White {pw.player.name}\n", Color.Gray);
			else
				FormLogEngines.AppendText($"White {pw.player.name} {pw.player.engine} {pw.engine.parameters}\n", Color.Gray);
			if (pb.engine == null)
				FormLogEngines.AppendText($"White {pb.player.name}\n", Color.Gray);
			else
				FormLogEngines.AppendText($"Black {pb.player.name} {pb.player.engine} {pb.engine.parameters}\n", Color.Gray);
			tssInfo.ForeColor = Color.Lime;
			tssInfo.Text = $"Load fen {Chess.GetFen()}";
			labBack.Text = $"Back {CData.back}";
			CData.gameState = Chess.GetGameState();
			RenderInfo(pw);
			RenderInfo(pb);
			moves = Chess.GenerateValidMoves();
			timer1.Enabled = true;
		}

		void LoadPgn(string pgn)
		{
			SetMode((int)CMode.game);
			CModeGame.ranked = false;
			string[] ml = pgn.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			Chess.SetFen();
			CHistory.NewGame();
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
			GamerList.curIndex = CChess.g_moveNumber & 1;
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
			CGamer pw = GamerList.gamer[0];
			CGamer pb = GamerList.gamer[1];
			FormLogEngines.This.richTextBox1.Clear();
			FormLogEngines.AppendText($"Pgn {CHistory.GetPgn()}\n", Color.Gray);
			FormLogEngines.AppendText($"White {pw.player.name} {pw.player.engine}\n", Color.Gray);
			FormLogEngines.AppendText($"Black {pb.player.name} {pb.player.engine}\n", Color.Gray);
			ShowInfo($"Load pgn {CHistory.GetPgn()}", Color.Gainsboro);
			labBack.Text = $"Back {CData.back}";
			CData.gameState = Chess.GetGameState();
			RenderInfo(pw);
			RenderInfo(pb);
			moves = Chess.GenerateValidMoves();
			timer1.Enabled = true;
		}

		private void MoveToLvMoves(int count, int piece, string emo)
		{
			string[] p = { "", "\u2659", "\u2658", "\u2657", "\u2656", "\u2655", "\u2654", "", "", "\u265F", "\u265E", "\u265D", "\u265C", "\u265B", "\u265A", "" };
			string m = $"{p[piece]} {emo}";
			if ((count & 1) == 0)
			{
				int moveNumber = (count >> 1) + 1;
				lvMoves.Items.Add(new ListViewItem(new[] { moveNumber.ToString(), m, "" }));
			}
			else
				lvMoves.Items[lvMoves.Items.Count - 1].SubItems[2].Text = m;
		}

		void ShowHistory()
		{
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			for (int n = 0; n < CHistory.moveList.Count; n++)
			{
				CHisMove m = CHistory.moveList[n];
				MoveToLvMoves(n, m.piece, m.GetNotation());
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
					tlpPromotion.Dock = boardRotate ^ CChess.whiteTurn ? DockStyle.Bottom : DockStyle.Top;
					tlpPromotion.BackColor = CChess.whiteTurn ? Color.Black : Color.White;
					Color color = CChess.whiteTurn ? Color.White : Color.Black;
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
				int s = Chess.MakeSquare(y, x);
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
			int sa = Chess.MakeSquare(sy, sx);
			int dx = des & 7;
			int dy = des >> 3;
			int da = Chess.MakeSquare(dy, dx);
			int a = (da << 8) | sa;
			foreach (int c in moves)
				if ((c & 0xffff) == a)
					return true;
			return false;
		}

		void ShowGamers()
		{
			CGamer gw = GamerList.gamer[0];
			CGamer gb = GamerList.gamer[1];
			labPlayerW.Text = gw.GetPlayerName();
			labPlayerB.Text = gb.GetPlayerName();
			labEngineW.Text = gw.GetEngine();
			labEngineB.Text = gb.GetEngine();
			labBookW.Text = gw.GetBook();
			labBookB.Text = gb.GetBook();
			labModeW.Text = gw.GetMode();
			labModeB.Text = gb.GetMode();
			labProtocolW.Text = gw.GetProtocol();
			labProtocolB.Text = gb.GetProtocol();
			labMemoryW.Text = gw.GetMemory();
			labMemoryB.Text = gb.GetMemory();
			splitContainerMoves.Panel1Collapsed = gw.player.IsHuman();
			splitContainerMoves.Panel2Collapsed = gb.player.IsHuman();
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
			int sa = Chess.MakeSquare(may, max);
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
			Board.ColorClear();
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
			lastEco = "";
			GameShow();
			CData.fen = CChess.defFen;
			CModeGame.color = cbColor.Text;
			CModeGame.computer = cbComputer.Text;
			CModeGame.engine = cbEngine.Text;
			ShowAuto();
			SetMode(CMode.game);
			GamePrepare();
			CPlayer ph = playerList.GetPlayerHuman();
			if (ShowLastGame())
				CModeGame.rotate = !CModeGame.rotate;
			if ((CModeGame.rotate && (cbColor.Text == "Auto")) || (cbColor.Text == "Black"))
				GamerList.Rotate();
			if (GamerList.GamerCur().player.IsHuman())
				moves = Chess.GenerateValidMoves();
			Clear();
			int elo = Convert.ToInt32(ph.elo);
			ph.eloNew = elo;
			ph.eloOld = elo;
			CModeGame.SaveToIni();
			SetBoardRotate();
			Board.Fill();
			Board.SetPosition();
			Board.RenderBoard();
			RenderBoard();
		}

		void GameShow()
		{
			CPlayer hu = playerList.GetPlayerHuman();
			CData.HisToPoints(hu.hisElo, chartGame.Series[0].Points);
			CModeGame.ranked = IsGameRanked();
			ShowAutoElo();
		}

		void GaemEnd(CPlayer pw, CPlayer pl, bool isDraw)
		{
			if (IsGameRanked())
			{
				if (pw.IsHuman())
				{
					if (!isDraw)
						pw.eloNew = pw.GetEloMore();
					else
						pw.eloNew = Convert.ToInt32(pw.eloOld);
				}
				else
				{
					if (!isDraw)
						pl.eloNew = pl.GetEloLess();
					else
						pl.eloNew = Convert.ToInt32(pl.eloOld);
				}
			}
			ShowLastGame(IsGameRanked());
		}

		void MatchShow()
		{
			cbEngine1.SelectedIndex = cbEngine1.FindStringExact(CModeMatch.engine1);
			cbEngine2.SelectedIndex = cbEngine2.FindStringExact(CModeMatch.engine2);
			cbMode1.SelectedIndex = cbMode1.FindStringExact(CModeMatch.modeValue1.mode);
			cbMode2.SelectedIndex = cbMode2.FindStringExact(CModeMatch.modeValue2.mode);
			cbBook1.SelectedIndex = cbBook1.FindStringExact(CModeMatch.book1);
			cbBook2.SelectedIndex = cbBook2.FindStringExact(CModeMatch.book2);
			nudValue1.Value = CModeMatch.modeValue1.GetValue();
			nudValue1.Increment = CModeMatch.modeValue1.GetIncrement();
			nudValue2.Value = CModeMatch.modeValue2.GetValue();
			nudValue2.Increment = CModeMatch.modeValue2.GetIncrement();
			labMatchGames.Text = $"Games {CModeMatch.games}";
			labMatch11.Text = CModeMatch.win.ToString();
			labMatch12.Text = CModeMatch.loose.ToString();
			labMatch13.Text = CModeMatch.draw.ToString();
			labMatch14.Text = $"{Math.Round(CModeMatch.Result(false))}%";
			labMatch21.Text = CModeMatch.loose.ToString();
			labMatch22.Text = CModeMatch.win.ToString();
			labMatch23.Text = CModeMatch.draw.ToString();
			labMatch24.Text = $"{Math.Round(CModeMatch.Result(true))}%";
			CHisElo his1 = CModeMatch.his1;
			CHisElo his2 = CModeMatch.his2;
			if (CModeMatch.rotate)
			{
				his1 = CModeMatch.his2;
				his2 = CModeMatch.his1;
			}
			CData.HisToPoints(his1, chartMatch.Series[0].Points);
			CData.HisToPoints(his2, chartMatch.Series[1].Points);
		}

		void MatchStart(bool add)
		{
			if (add)
			{
				CModeMatch.his1.Add(CModeMatch.Result(false));
				CModeMatch.his2.Add(CModeMatch.Result(true));
			}
			CData.fen = CChess.defFen;
			CModeMatch.engine1 = cbEngine1.Text;
			CModeMatch.engine2 = cbEngine2.Text;
			CModeMatch.modeValue1.mode = cbMode1.Text;
			CModeMatch.modeValue1.SetValue((int)nudValue1.Value);
			CModeMatch.modeValue2.mode = cbMode2.Text;
			CModeMatch.modeValue2.SetValue((int)nudValue2.Value);
			CModeMatch.book1 = cbBook1.Text;
			CModeMatch.book2 = cbBook2.Text;
			SetMode(CMode.match);
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
			Clear();
			moves = Chess.GenerateValidMoves();
			CModeMatch.SaveToIni();
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
			CModeTournamentE.FillList();
			foreach (CEngine e in CModeTournamentE.engineList.list)
			{
				int del = e.GetDeltaElo();
				ListViewItem lvi = new ListViewItem(new[] { e.name, e.elo, del.ToString() });
				if (del > 0)
					lvi.BackColor = Color.FromArgb(0xe0, 0xff, 0xe0);
				if (del < 0)
					lvi.BackColor = Color.FromArgb(0xff, 0xe0, 0xe0);
				if (del == 0)
					lvi.BackColor = Color.FromArgb(0xff, 0xff, 0xff);
				lvEngine.Items.Add(lvi);
			}
		}

		void TournamentEUpdate(CEngine e)
		{
			if (e != null)
				foreach (ListViewItem lvi in lvEngine.Items)
					if (lvi.Text == e.name)
					{
						int del = e.GetDeltaElo();
						lvi.SubItems[1].Text = e.elo;
						lvi.SubItems[2].Text = del.ToString();
						if (del > 0)
							lvi.BackColor = Color.FromArgb(0xe0, 0xff, 0xe0);
						if (del < 0)
							lvi.BackColor = Color.FromArgb(0xff, 0xe0, 0xe0);
						if (del == 0)
							lvi.BackColor = Color.FromArgb(0xff, 0xff, 0xff);
					}
		}

		void TournamentEStart()
		{
			TournamentEUpdate(GamerList.gamer[0].engine);
			TournamentEUpdate(GamerList.gamer[1].engine);
			CModeTournamentE.modeValue.mode = cbTourEMode.Text;
			CModeTournamentE.modeValue.SetValue((int)nudTourE.Value);
			CModeTournamentE.book = cbTourEBook.Text;
			CModeTournamentE.SaveToIni();
			CData.fen = CChess.defFen;
			SetMode(CMode.tourE);
			CPlayer p1;
			CPlayer p2;
			CEngine e1;
			CEngine e2;
			if (CModeTournamentE.rotate)
			{
				p1 = GamerList.gamer[1].player;
				p2 = GamerList.gamer[0].player;
			}
			else
			{
				e1 = CModeTournamentE.SelectEngine();
				e2 = CModeTournamentE.SelectOpponent(e1);
				p1 = new CPlayer(e1.name);
				p2 = new CPlayer(e2.name);
				p1.engine = e1.name;
				p2.engine = e2.name;
				p1.elo = e1.elo;
				p2.elo = e2.elo;
			}
			p1.book = CModeTournamentE.book;
			p1.modeValue.mode = CModeTournamentE.modeValue.mode;
			p1.modeValue.value = CModeTournamentE.modeValue.value;
			p2.book = CModeTournamentE.book;
			p2.modeValue.mode = CModeTournamentE.modeValue.mode;
			p2.modeValue.value = CModeTournamentE.modeValue.value;
			GamerList.gamer[0].SetPlayer(p1);
			GamerList.gamer[1].SetPlayer(p2);
			foreach (ListViewItem lvi in lvEngine.Items)
				if (lvi.Text == CModeTournamentE.engine)
				{
					int top = lvi.Index - ((lvEngine.ClientRectangle.Height / lvi.Bounds.Height) >> 1);
					if (top < 0)
						top = 0;
					lvi.Selected = true;
					lvEngine.TopItem = lvEngine.Items[top];
					lvEngine.Sort();
					lvEngine.Focus();
					ShowHistoryTourE();
					break;
				}
			Clear();
		}

		void TournamentEEnd(CGamer gw, CGamer gl, bool isDraw)
		{
			CEngine ew = gw.engine;
			CEngine el = gl.engine;
			int eloW = Convert.ToInt32(gw.engine.elo);
			int eloL = Convert.ToInt32(gl.engine.elo);
			int indexW = engineList.GetIndexElo(eloW);
			int indexL = engineList.GetIndexElo(eloL);
			int optW = engineList.GetOptElo(indexW);
			int optL = engineList.GetOptElo(indexL);
			int OW = optW;
			int OL = optL;
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
					OW = engineList.GetOptElo(indexW + 1);
				string r = gw == This.GamerList.gamer[0] ? "w" : "b";
				CModeTournamentE.tourList.Write(This.GamerList.gamer[0].engine.name, This.GamerList.gamer[1].engine.name, r);
			}
			else
			{
				int opt = (OW + OL) >> 1;
				OW = opt;
				OL = opt;
				CModeTournamentE.tourList.Write(This.GamerList.gamer[0].engine.name, This.GamerList.gamer[1].engine.name, "d");
			}
			int newW = Convert.ToInt32(eloW * 0.9 + Math.Max(OW, eloL) * 0.1);
			int newL = Convert.ToInt32(eloL * 0.9 + Math.Min(OL, eloW) * 0.1);
			ew.hisElo.Add(newW);
			el.hisElo.Add(newL);
			ew.elo = newW.ToString();
			el.elo = newL.ToString();
			ew.eloOld = ew.eloOld * .9 + newW * .1;
			el.eloOld = el.eloOld * .9 + newL * .1;
			ew.SaveToIni();
			el.SaveToIni();
			CModeTournamentE.rotate = (OW != OL) && (newW < newL);
		}

		void TournamentPReset()
		{
			lvPlayer.Items.Clear();
			CModeTournamentP.FillList();
			foreach (CPlayer p in CModeTournamentP.playerList.list)
				if (p.IsComputer())
				{
					int del = p.GetDeltaElo();
					ListViewItem lvi = new ListViewItem(new[] { p.name, p.elo, del.ToString().ToString() });
					if (del > 0)
						lvi.BackColor = Color.FromArgb(0xe0, 0xff, 0xe0);
					if (del < 0)
						lvi.BackColor = Color.FromArgb(0xff, 0xe0, 0xe0);
					if (del == 0)
						lvi.BackColor = Color.FromArgb(0xff, 0xff, 0xff);
					lvPlayer.Items.Add(lvi);
				}
		}

		void TournamentPUpdate(CPlayer p)
		{
			foreach (ListViewItem lvi in lvPlayer.Items)
				if (lvi.Text == p.name)
				{
					int del = p.GetDeltaElo();
					lvi.SubItems[1].Text = p.elo;
					lvi.SubItems[2].Text = del.ToString();
					if (del > 0)
						lvi.BackColor = Color.FromArgb(0xe0, 0xff, 0xe0);
					if (del < 0)
						lvi.BackColor = Color.FromArgb(0xff, 0xe0, 0xe0);
					if (del == 0)
						lvi.BackColor = Color.FromArgb(0xff, 0xff, 0xff);
				}
		}

		void TournamentPStart()
		{
			TournamentPUpdate(GamerList.gamer[0].player);
			TournamentPUpdate(GamerList.gamer[1].player);
			CData.fen = CChess.defFen;
			SetMode(CMode.tourP);
			CPlayer p1;
			CPlayer p2;
			if (CModeTournamentP.rotate)
			{
				p1 = GamerList.gamer[1].player;
				p2 = GamerList.gamer[0].player;
			}
			else
			{
				p1 = CModeTournamentP.SelectPlayer();
				p2 = CModeTournamentP.SelectOpponent(p1);
			}
			GamerList.gamer[0].SetPlayer(p1);
			GamerList.gamer[1].SetPlayer(p2);
			foreach (ListViewItem lvi in lvPlayer.Items)
				if (lvi.Text == CModeTournamentP.player)
				{
					int top = lvi.Index - ((lvPlayer.ClientRectangle.Height / lvi.Bounds.Height) >> 1);
					if (top < 0)
						top = 0;
					lvi.Selected = true;
					lvPlayer.TopItem = lvPlayer.Items[top];
					lvPlayer.Sort();
					lvPlayer.Focus();
					ShowHistoryTourP();
					break;
				}
			Clear();
		}

		void TournamentPEnd(CPlayer pw, CPlayer pl, bool isDraw)
		{
			int eloW = Convert.ToInt32(pw.elo);
			int eloL = Convert.ToInt32(pl.elo);
			int indexW = playerList.GetIndexElo(eloW);
			int indexL = playerList.GetIndexElo(eloL);
			int optW = playerList.GetOptElo(indexW);
			int optL = playerList.GetOptElo(indexL);
			int OW = optW;
			int OL = optL;
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
					OW = engineList.GetOptElo(indexW + 1);
				string r = pw == This.GamerList.gamer[0].player ? "w" : "b";
				CModeTournamentP.tourList.Write(This.GamerList.gamer[0].player.name, This.GamerList.gamer[1].player.name, r);
			}
			else
			{
				int opt = (OW + OL) >> 1;
				OW = opt;
				OL = opt;
				CModeTournamentP.tourList.Write(This.GamerList.gamer[0].player.name, This.GamerList.gamer[1].player.name, "d");
			}
			int newW = Convert.ToInt32(eloW * 0.9 + Math.Max(OW, eloL) * 0.1);
			int newL = Convert.ToInt32(eloL * 0.9 + Math.Min(OL, eloW) * 0.1);
			pw.hisElo.Add(newW);
			pl.hisElo.Add(newL);
			pw.elo = newW.ToString();
			pl.elo = newL.ToString();
			pw.eloOld = pw.eloOld * .9 + newW * .1;
			pl.eloOld = pl.eloOld * .9 + newL * .1; ;
			pw.SaveToIni();
			pl.SaveToIni();
			CModeTournamentP.rotate = (OW != OL) && (newW < newL);
		}

		void TrainingShow()
		{
			double procent = CModeTraining.games > 0 ? (CModeTraining.errors * 100.0) / CModeTraining.games : 0;
			labGames.Text = $"Games {CModeTraining.games}";
			labErrors.Text = string.Format("Errors {0} ({1:N2}%)", CModeTraining.errors, procent);
			cbTeacherEngine.SelectedIndex = cbTeacherEngine.FindStringExact(CModeTraining.teacher);
			cbTrainedEngine.SelectedIndex = cbTrainedEngine.FindStringExact(CModeTraining.trained);
			cbTeacherMode.SelectedIndex = cbTeacherMode.FindStringExact(CModeTraining.modeValueTeacher.mode);
			cbTrainedMode.SelectedIndex = cbTrainedMode.FindStringExact(CModeTraining.modeValueTrained.mode);
			cbTeacherBook.SelectedIndex = cbTeacherBook.FindStringExact(CModeTraining.teacherBook);
			cbTrainedBook.SelectedIndex = cbTrainedBook.FindStringExact(CModeTraining.trainedBook);
			nudTeacher.Value = CModeTraining.modeValueTeacher.GetValue();
			nudTeacher.Increment = CModeTraining.modeValueTeacher.GetIncrement();
			nudTrained.Value = CModeTraining.modeValueTrained.GetValue();
			nudTrained.Increment = CModeTraining.modeValueTrained.GetIncrement();
			label12.Text = CModeTraining.win.ToString();
			label13.Text = CModeTraining.loose.ToString();
			label14.Text = CModeTraining.draw.ToString();
			label15.Text = $"{CModeTraining.Result(false)}%";
			label7.Text = CModeTraining.loose.ToString();
			label8.Text = CModeTraining.win.ToString();
			label9.Text = CModeTraining.draw.ToString();
			label10.Text = $"{CModeTraining.Result(true)}%";
		}

		void TraingStart()
		{
			CData.fen = CChess.defFen;
			CModeTraining.teacher = cbTeacherEngine.Text;
			CModeTraining.trained = cbTrainedEngine.Text;
			CModeTraining.modeValueTeacher.mode = cbTeacherMode.Text;
			CModeTraining.modeValueTrained.mode = cbTrainedMode.Text;
			CModeTraining.teacherBook = cbTeacherBook.Text;
			CModeTraining.trainedBook = cbTrainedBook.Text;
			CModeTraining.modeValueTeacher.SetValue((int)nudTeacher.Value);
			CModeTraining.modeValueTrained.SetValue((int)nudTrained.Value);
			SetMode(CMode.training);
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
			Clear();
			chartTraining.Series[0].Points.Add((double)nudTeacher.Value);
			CModeTraining.SaveToIni();
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
			if (CData.gameState == CGameState.time)
				CRapLog.Add($"Training time {gl.player.name} {CChess.whiteTurn}");
			if ((gl.player.name == "Trained") && ((CData.gameState == CGameState.time) || (CData.gameState == CGameState.error) || gl.timeOut))
				CModeTraining.errors++;
			TrainingShow();
		}

		void EditShow()
		{
			List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
			int i = CChess.whiteTurn ? 1 : 0;
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
			if (formLogLast.Visible)
				formLogLast.Focus();
			else
				formLogLast.Show(this);
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

		#endregion

		#region events

		private void FormChess_FormClosed(object sender, FormClosedEventArgs e)
		{
			IniSave();
			GamerList.Terminate();
		}

		private void Timer1_Tick_1(object sender, EventArgs e)
		{
			GetMessage();
			if (CBoard.animated || CDrag.dragged)
			{
				RenderBoard();
			}
			else
			{
				RenderInfo(GamerList.GamerCur());
				RenderInfo(GamerList.GamerSec());
				if (CData.gameState == CGameState.normal)
					GamerList.GamerCur().TryStart();
			}
		}

		private void TimerStart_Tick(object sender, EventArgs e)
		{
			timerStart.Stop();
			switch (CData.gameMode)
			{
				case CMode.match:
					MatchStart(true);
					break;
				case CMode.tourE:
					TournamentEStart();
					break;
				case CMode.tourP:
					TournamentPStart();
					break;
				case CMode.training:
					TraingStart();
					break;
			}
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
			TraingStart();
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
			MatchStart(true);
		}

		private void butStartTournament_Click(object sender, EventArgs e)
		{
			TournamentPStart();
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
			if (CData.gameMode == CMode.edit)
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
			if (CData.gameMode == (int)CMode.game)
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
			if (CData.gameMode == (int)CMode.game)
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
			CChess.whiteTurn = i == 1;
			boardRotate = !CChess.whiteTurn;
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
			MatchStart(false);
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
			ShowAuto();
		}

		private void nudValue_ValueChanged(object sender, EventArgs e)
		{
			CModeGame.modeValue.SetValue((int)nudValue.Value);
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
			lv.Columns[lv.Columns.Count - 1].Width = lv.Width - 32 - w * (lv.Columns.Count - 1);
		}

		private void lvMoves_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = lv.Width - 32;
			w = Convert.ToInt32(w / 5);
			lv.Columns[0].Width = w;
			lv.Columns[1].Width = w * 2;
			lv.Columns[2].Width = w * 2;
		}

		private void panBoard_Paint(object sender, PaintEventArgs e)
		{
			RenderBoard();
		}

		private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeGame.modeValue.mode = cbMode.Text;
			nudValue.Increment = CModeGame.modeValue.GetIncrement();
			nudValue.Minimum = nudValue.Increment;
			nudValue.Value = CModeGame.modeValue.GetValue();
			toolTip1.SetToolTip(nudValue, CModeGame.modeValue.GetTip());
		}

		private void cbMode1_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeMatch.modeValue1.mode = cbMode1.Text;
			nudValue1.Increment = CModeMatch.modeValue1.GetIncrement();
			nudValue1.Minimum = nudValue1.Increment;
			nudValue1.Value = CModeMatch.modeValue1.GetValue();
			toolTip1.SetToolTip(nudValue1, CModeMatch.modeValue1.GetTip());
		}

		private void cbMode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeMatch.modeValue2.mode = cbMode2.Text;
			nudValue2.Increment = CModeMatch.modeValue2.GetIncrement();
			nudValue2.Minimum = nudValue2.Increment;
			nudValue2.Value = CModeMatch.modeValue2.GetValue();
			toolTip1.SetToolTip(nudValue2, CModeMatch.modeValue2.GetTip());
		}

		private void cbTrainedMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTraining.modeValueTrained.mode = cbTrainedMode.Text;
			nudTrained.Increment = CModeTraining.modeValueTrained.GetIncrement();
			nudTrained.Minimum = nudTrained.Increment;
			nudTrained.Value = CModeTraining.modeValueTrained.GetValue();
			toolTip1.SetToolTip(nudTrained, CModeTraining.modeValueTrained.GetTip());
		}

		private void cbTeacherMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTraining.modeValueTeacher.mode = cbTeacherMode.Text;
			nudTeacher.Increment = CModeTraining.modeValueTeacher.GetIncrement();
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
			FormLogGames.This.textBox1.Text = "";
			tabControl1.SelectedIndex = cbMainMode.SelectedIndex;
			CData.fen = Chess.GetFen();
			Board.Fill();
			RenderBoard();
			SetMode((CMode)cbMainMode.SelectedIndex);
		}

		private void tlp_Resize(object sender, EventArgs e)
		{
			TableLayoutPanel tlp = sender as TableLayoutPanel;
			foreach (Control ctrl in tlp.Controls)
			{
				float size = (float)(tlp.Width * 0.028);
				ctrl.Font = new Font(ctrl.Font.Name, size);
			}
		}

		private void butResignation_Click(object sender, EventArgs e)
		{
			if (IsGameRanked() && IsGameLong() && IsGameProgress())
			{
				CPlayer hu = playerList.GetPlayerHuman();
				hu.eloNew = hu.GetEloLess();
			}
			SetGameState(CGameState.resignation);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			TournamentEStart();
		}

		private void cbTourEMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTournamentE.modeValue.mode = (sender as ComboBox).Text;
			nudTourE.Increment = CModeTournamentE.modeValue.GetIncrement();
			nudTourE.Minimum = nudTourE.Increment;
			nudTourE.Value = Math.Max(CModeTournamentE.modeValue.GetValue(), nudTourE.Minimum);
			toolTip1.SetToolTip(nudTourE, CModeTournamentE.modeValue.GetTip());
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetMode((CMode)tabControl1.SelectedIndex);
		}

		private void lvEngine_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowHistoryTourE();
		}

		private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView lv = sender as ListView;
			lv.Tag = lv.Tag == null ? new Object() : null;
			(sender as ListView).ListViewItemSorter = new ListViewComparer(e.Column, lv.Tag == null ? SortOrder.Ascending : SortOrder.Descending);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (CHistory.Back())
			{
				labBack.Text = $"Back {++CData.back}";
				RenderHistory();
				moves = Chess.GenerateValidMoves();
				SetGameState(Chess.GetGameState());
				ShowLastGame();
				CModeGame.ranked = false;
				ShowAutoElo();
				GamerList.GamerCur().player.elo = GamerList.GamerCur().player.GetEloLess().ToString();
				GamerList.GamerSec().Undo();
				RenderBoard();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			CModeGame.ranked = false;
			ShowAutoElo();
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
			LinesResize(lvMovesW);
			LinesResize(lvMovesB);
		}

		private void nudValue_Click(object sender, EventArgs e)
		{
			cbComputer.Text = "Custom";
		}

		private void cbEngine_Click(object sender, EventArgs e)
		{
			cbComputer.Text = "Custom";
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
			ShowHistoryTourP();
		}

		private void butEditStart_Click(object sender, EventArgs e)
		{
			LoadFen(Chess.GetFen());
		}

		#endregion
	}
}
