using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

		public static FormChess This;
		public static bool boardRotate;
		bool isBook = false;
		ColumnHeader SortingColumn = null;
		List<int> moves = new List<int>();
		public CRapIni RapIni = new CRapIni();
		readonly CEcoList EcoList = new CEcoList();
		readonly CChess Chess = new CChess();
		readonly CGamerList GamerList = new CGamerList();
		readonly CUci Uci = new CUci();
		readonly PrivateFontCollection pfc = new PrivateFontCollection();
		readonly Font fontChess;

		public FormChess()
		{
			This = this;
			InitializeComponent();
			if (!CRapIni.This.Exists())
				CreateIni();
			IniLoad();
			FormLog.This = new FormLog();
			FormOptions.This = new FormOptions();
			FormEngine.This = new FormEngine();
			FormBook.This = new FormBook();
			FormPlayer.This = new FormPlayer();
			Reset();
			cbColor.SelectedIndex = cbColor.FindStringExact(CModeGame.color);
			cbComputer.SelectedIndex = cbComputer.FindStringExact(CModeGame.computer);
			CBoard.Init();
			int fontLength = Properties.Resources.ChessPiece.Length;
			byte[] fontData = Properties.Resources.ChessPiece;
			IntPtr data = Marshal.AllocCoTaskMem(fontLength);
			Marshal.Copy(fontData, 0, data, fontLength);
			uint cFonts = 0;
			AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);
			pfc.AddMemoryFont(data, fontLength);
			Marshal.FreeCoTaskMem(data);
			fontChess = new Font(pfc.Families[0], 16);
			labTakenT.Font = fontChess;
			labTakenD.Font = fontChess;
			Chess.Initialize();
			listView1_Resize(listView1, null);
			listView2_Resize(listView2, null);
			lvMoves_Resize(lvMoves, null);
			BoardPrepare();
			GameStart();
		}

		void CreateIni()
		{
			CEngineList.LoadFromIni();
			CEngine e;
			e = new CEngine(CEngineList.def);
			e.file = "RapChessCs.exe";
			CEngineList.Add(e);
			e = new CEngine("RapSimple CS");
			e.file = "RapSimpleCs.exe";
			CEngineList.Add(e);
			e = new CEngine("RapShort CS");
			e.file = "RapShortCs.exe";
			CEngineList.Add(e);
			CEngineList.SaveToIni();
			CBookList.LoadFromIni();
			CBook b;
			b = new CBook("Eco");
			b.file = "BookReaderUci.exe";
			b.parameters = "eco.uci";
			CBookList.Add(b);
			b = new CBook("Small");
			b.file = "BookReaderUci.exe";
			b.parameters = "small.uci";
			CBookList.Add(b);
			b = new CBook("Random1");
			b.file = "BookReaderUci.exe";
			b.parameters = "random1.uci";
			CBookList.Add(b);
			b = new CBook("Random2");
			b.file = "BookReaderUci.exe";
			b.parameters = "random2.uci";
			CBookList.Add(b);
			for (int n = 1; n < 10; n++)
			{
				int v = n * 10;
				b = new CBook($"Rand{v}");
				b.file = "BookReaderRnd.exe";
				b.parameters = v.ToString();
				CBookList.Add(b);
			}
			CBookList.SaveToIni();
			CPlayer p;
			p = new CPlayer("Human");
			CPlayerList.Add(p);
			p = new CPlayer("RapChess CS R90");
			p.engine = "RapChess CS";
			p.book = "Rand90";
			p.mode = "movetime";
			p.value = "1";
			p.elo = "200";
			CPlayerList.Add(p);
			p = new CPlayer("RapChess CS R70");
			p.engine = "RapChess CS";
			p.book = "Rand70";
			p.mode = "movetime";
			p.value = "1";
			p.elo = "400";
			CPlayerList.Add(p);
			p = new CPlayer("RapChess CS R50");
			p.engine = "RapChess CS";
			p.book = "Rand50";
			p.mode = "movetime";
			p.value = "1";
			p.elo = "600";
			CPlayerList.Add(p);
			p = new CPlayer("RapChess CS R30");
			p.engine = "RapChess CS";
			p.book = "Rand30";
			p.mode = "movetime";
			p.value = "1";
			p.elo = "800";
			CPlayerList.Add(p);
			p = new CPlayer("RapChess CS R10");
			p.engine = "RapChess CS";
			p.book = "Rand10";
			p.mode = "movetime";
			p.value = "1";
			p.elo = "1000";
			CPlayerList.Add(p);
			p = new CPlayer("RapShort CS");
			p.engine = "RapShort CS";
			p.book = "Eco";
			p.mode = "movetime";
			p.value = "1000";
			p.elo = "500";
			CPlayerList.Add(p);
			p = new CPlayer("RapSimple CS");
			p.engine = "RapSimple CS";
			p.book = "Eco";
			p.mode = "movetime";
			p.value = "1000";
			p.elo = "1000";
			CPlayerList.Add(p);
			p = new CPlayer(CPlayerList.def);
			p.engine = "RapChess CS";
			p.book = "Eco";
			p.mode = "movetime";
			p.value = "1000";
			p.elo = "1200";
			CPlayerList.Add(p);
			CPlayerList.SaveToIni();
		}

		void IniLoad()
		{
			Width = RapIni.ReadInt("position>width", Width);
			Height = RapIni.ReadInt("position>height", Height);
			int x = RapIni.ReadInt("position>x", Location.X);
			int y = RapIni.ReadInt("position>y", Location.Y);
			Location = new Point(x, y);
			if (RapIni.ReadBool("position>maximized", false))
				WindowState = FormWindowState.Maximized;
			CEngineList.LoadFromIni();
			CBookList.LoadFromIni();
			CPlayerList.LoadFromIni();
			CModeGame.LoadFromIni();
			CModeMatch.LoadFromIni();
			CModeTournament.LoadFromIni();
			CModeTraining.LoadFromIni();
		}

		public void BoardPrepare()
		{
			CBoard.Prepare(panBoard.Width, panBoard.Height);
			RenderBoard();
		}

		void AddLines(CGamer g)
		{
			if (GamerList.GamerCur().white)
				lvMovesW.Items.Insert(0, new ListViewItem(new[] { g.GetTimeElapsed(), g.GetDepth(), g.nodes.ToString("N0"), g.nps.ToString("N0"), g.score, g.pv }));
			else
				lvMovesB.Items.Insert(0, new ListViewItem(new[] { g.GetTimeElapsed(), g.GetDepth(), g.nodes.ToString("N0"), g.nps.ToString("N0"), g.score, g.pv }));
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
				case "bestmove":
					g.ponder = Uci.GetValue("ponder");
					emo = Uci.tokens[1];
					if (isBook)
						AddBook(emo);
					MakeMove(emo);
					break;
				case "info":
					tssMoves.ForeColor = Color.Gainsboro;
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
					}
					string pv = "";
					int i = Uci.GetIndex("pv", 0);
					if (i > 0)
					{
						List<int> moves = new List<int>();
						for (int n = i; n < Uci.tokens.Length; n++)
						{
							emo = Uci.tokens[n];
							int gmo = Chess.IsValidMove(emo);
							if (gmo > 0)
							{
								if (moves.Count == 0)
								{
									CChess.EmoToSD(emo, out int sou, out int des);
									CArrow.SetAB(sou, des);
									RenderBoard();
								}
								Chess.MakeMove(gmo);
								moves.Add(gmo);
								pv = $"{pv} {emo}";
							}
							else break;
						}
						for (int n = moves.Count - 1; n >= 0; n--)
							Chess.UnmakeMove(moves[n]);
						g.pv = pv;
						tssMoves.Text = pv;
						AddLines(g);
					}
					isBook = Uci.GetIndex("book", 0) > 0;
					break;
			}
		}

		public void GetMessageXb(CGamer g, string msg)
		{
			Uci.SetMsg(msg);
			switch (Uci.command)
			{
				case "0-1":
				case "1-0":
				case "1/2-1/2":
					XBGameOver(msg);
					break;
				case "move":
					g.ponder = Uci.GetValue("ponder");
					string em = Uci.tokens[1];
					if (em == "o-o")
						em = CChess.whiteTurn ? "e1g1" : "e8g8";
					if (em == "o-o-o")
						em = CChess.whiteTurn ? "e1c1" : "e8c8";
					if (isBook)
						AddBook(em);
					MakeMove(em);
					break;
				default:
					string s = msg.ToLower();
					if (s.Contains("resign") || s.Contains("illegal"))
						XBGameOver(msg);
					else if (g.wbok && Char.IsDigit(Uci.tokens[0][0]) && (Uci.tokens.Length > 4))
					{
						try
						{
							g.depth = Uci.tokens[0];
							g.score = Uci.tokens[1];
							ulong ms = (ulong)Convert.ToInt64(Uci.tokens[2]);
							g.nodes = (ulong)Convert.ToInt64(Uci.tokens[3]);
							g.nps = ms > 0 ? (g.nodes * 100) / ms : 0;
							string pv = "";
							for (int n = 4; n < Uci.tokens.Length; n++)
								pv += Uci.tokens[n] + " ";
							tssMoves.ForeColor = Color.Gainsboro;
							g.pv = pv;
							tssMoves.Text = pv;
							AddLines(g);
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
			while (CMessageList.GetMessage(out CGamer g, out string msg))
			{
				if (g.engine.protocol == "Uci")
					GetMessageUci(g, msg);
				if (g.engine.protocol == "Winboard")
					GetMessageXb(g, msg);
			}
		}

		void CreatePgn()
		{
			List<string> list = new List<string>();
			string result = "1/2-1/2";
			if (CData.gameState == (int)CGameState.mate)
				if ((CHistory.moveList.Count & 1) > 0)
					result = "1-0";
				else
					result = "0-1";
			list.Add($"[Date \"{DateTime.Now.ToString("yyyy.MM.dd")}\"]");
			list.Add($"[White \"{GamerList.gamer[0].player.name}\"]");
			list.Add($"[Black \"{GamerList.gamer[1].player.name}\"]");
			list.Add($"[Result \"{result}\"]");
			list.Add("");
			list.Add(CHistory.GetPgn());
			TextWriter tw = new StreamWriter($"{CData.modeName}.pgn");
			foreach (String s in list)
				tw.WriteLine(s);
			tw.Close();
		}

		public void AddBook(string emo)
		{
			isBook = false;
			GamerList.GamerCur().usedBook++;
			tssMoves.ForeColor = Color.Aquamarine;
			tssMoves.Text = $"book {emo}";
		}

		void SetMode(int mode)
		{
			moveToolStripMenuItem.Visible = false;
			timer1.Enabled = false;
			timerStart.Enabled = false;
			GamerList.Terminate();
			CData.gameMode = (int)mode;
			CMessageList.list.Clear();
			moveToolStripMenuItem.Visible = mode == (int)CMode.game;
			Clear();
			switch (mode)
			{
				case (int)CMode.game:
					moveToolStripMenuItem.Visible = true;
					GameShow();
					break;
				case (int)CMode.match:
					MatchShow();
					break;
				case (int)CMode.training:
					TrainingShow();
					break;
				case (int)CMode.edit:
					EditShow();
					break;
			}
		}

		bool IsAutoElo()
		{
			return (cbComputer.Text == "Auto") && FormOptions.This.cbGameAutoElo.Checked && (CData.gameMode == (int)CMode.game);
		}


		void ShowAuto()
		{
			if (CModeGame.ranked)
			{
				CPlayer p = CPlayerList.GetPlayerAuto();
				cbEngine.SelectedIndex = cbEngine.FindStringExact(p.engine);
				cbMode.SelectedIndex = cbMode.FindStringExact(p.GetMode());
				cbBook.SelectedIndex = cbBook.FindStringExact(p.book);
				int v = Convert.ToInt32(p.value);
				if (v >= nudValue.Minimum)
					nudValue.Value = v;
			}
		}

		void ShowAutoElo()
		{
			if (IsAutoElo() && CModeGame.ranked)
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

		bool ShowLastGame()
		{
			bool result = false;
			CPlayer hu = CPlayerList.GetPlayerAuto("Human");
			int eloCur = Convert.ToInt32(hu.elo);
			if (hu.eloNew > eloCur)
			{
				result = true;
				tssMoves.ForeColor = Color.FromArgb(0, 0xff, 0);
				tssMoves.Text = $"Last game you win new elo is {hu.eloNew} ({eloCur})";
				CRapLog.Add(tssMoves.Text);
			}
			if (hu.eloNew < eloCur)
			{
				result = true;
				tssMoves.ForeColor = Color.FromArgb(0xff, 0, 0);
				tssMoves.Text = $"Last game you loose new elo is {hu.eloNew} ({eloCur})";
				CRapLog.Add(tssMoves.Text);
			}
			hu.elo = hu.eloNew.ToString();
			hu.SaveToIni();
			return result;
		}

		void GameShow()
		{
			ShowAutoElo();
		}

		void GamePrepare()
		{
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			GamerList.gamer[0].SetPlayer("Human");
			CPlayer pc = new CPlayer(cbComputer.Text);
			if (cbComputer.Text == "Custom")
			{
				pc.engine = cbEngine.Text;
				pc.book = cbBook.Text;
				switch (cbMode.Text)
				{
					case "Blitz":
						pc.mode = "blitz";
						pc.value = Convert.ToString(nudValue.Value * 1000);
						break;
					case "Depth":
						pc.mode = "depth";
						pc.value = Convert.ToString(nudValue.Value);
						break;
					case "Nodes":
						pc.mode = "nodes";
						pc.value = Convert.ToString(nudValue.Value);
						break;
					case "Infinite":
						pc.mode = "infinite";
						pc.value = "";
						break;
					default:
						pc.mode = "movetime";
						pc.value = Convert.ToString(nudValue.Value);
						break;
				}
			}
			else
				pc = CPlayerList.GetPlayer(cbComputer.Text);
			if (pc == null)
				pc = CPlayerList.GetPlayerAuto();
			GamerList.gamer[1].SetPlayer(pc);
		}

		void GameStart()
		{
			CData.fen = CChess.defFen;
			CModeGame.color = cbColor.Text;
			CModeGame.computer = cbComputer.Text;
			CModeGame.ranked = IsAutoElo();
			ShowAutoElo();
			ShowAuto();
			SetMode((int)CMode.game);
			GamePrepare();
			bool lg = ShowLastGame();
			if ((!lg && CModeGame.rotate && (cbColor.Text == "Auto")) || (cbColor.Text == "Black"))
			{
				CModeGame.rotate = false;
				GamerList.Rotate();
			}
			else
				CModeGame.rotate = true;
			Clear();
			if (GamerList.GamerCur().player.engine == "Human")
				moves = Chess.GenerateValidMoves();
			CPlayer uh = CPlayerList.GetPlayerAuto("Human");
			int levelDif = 2000 / listView1.Items.Count;
			if (levelDif < 10)
				levelDif = 10;
			int elo = Convert.ToInt32(uh.elo);
			uh.eloNew = elo;
			uh.eloOld = elo;
			uh.eloLess = elo - levelDif;
			uh.eloMore = elo + levelDif;
			if (uh.eloLess < 0)
				uh.eloLess = 0;
			CModeGame.SaveToIni();
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
			labMatch14.Text = $"{CModeMatch.Result(false)}%";
			labMatch21.Text = CModeMatch.loose.ToString();
			labMatch22.Text = CModeMatch.win.ToString();
			labMatch23.Text = CModeMatch.draw.ToString();
			labMatch24.Text = $"{CModeMatch.Result(true)}%";
		}

		void MatchStart()
		{
			CData.fen = CChess.defFen;
			CModeMatch.engine1 = cbEngine1.Text;
			CModeMatch.engine2 = cbEngine2.Text;
			CModeMatch.modeValue1.mode = cbMode1.Text;
			CModeMatch.modeValue2.mode = cbMode2.Text;
			CModeMatch.book1 = cbBook1.Text;
			CModeMatch.book2 = cbBook2.Text;
			SetMode((int)CMode.match);
			CPlayer p1 = new CPlayer("Player 1");
			p1.engine = CModeMatch.engine1;
			p1.book = CModeMatch.book1;
			switch (CModeMatch.modeValue1.mode)
			{
				case "Blitz":
					p1.mode = "blitz";
					break;
				case "Depth":
					p1.mode = "depth";
					break;
				case "Nodes":
					p1.mode = "nodes";
					break;
				default:
					p1.mode = "movetime";
					break;
			}
			p1.value = Convert.ToString(CModeMatch.modeValue1.GetValue());
			CPlayer p2 = new CPlayer("Player 2");
			p2.engine = CModeMatch.engine2;
			p2.book = CModeMatch.book2;
			switch (CModeMatch.modeValue1.mode)
			{
				case "Blitz":
					p2.mode = "blitz";
					break;
				case "Depth":
					p2.mode = "depth";
					break;
				case "Nodes":
					p2.mode = "nodes";
					break;
				default:
					p2.mode = "movetime";
					break;
			}
			p2.value = Convert.ToString(CModeMatch.modeValue2.GetValue());
			GamerList.gamer[0].SetPlayer(p1);
			GamerList.gamer[1].SetPlayer(p2);
			if (CModeMatch.rotate)
				GamerList.Rotate();
			CModeMatch.rotate = !CModeMatch.rotate;
			Clear();
			moves = Chess.GenerateValidMoves();
			CModeMatch.SaveToIni();
		}

		void TournamentReset()
		{
			listView1.Items.Clear();
			foreach (CPlayer p in CPlayerList.list)
				if (p.engine != "Human")
				{
					int del = p.GetDeltaElo();
					ListViewItem lvi = new ListViewItem(new[] { p.name, p.elo, del.ToString().ToString() });
					if (del > 0)
						lvi.BackColor = Color.FromArgb(0xe0, 0xff, 0xe0);
					if (del < 0)
						lvi.BackColor = Color.FromArgb(0xff, 0xe0, 0xe0);
					if (del == 0)
						lvi.BackColor = Color.FromArgb(0xff, 0xff, 0xff);
					listView1.Items.Add(lvi);
				}
		}

		void TournamentUpdate(CPlayer p)
		{
			foreach (ListViewItem lvi in listView1.Items)
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

		void TournamentStart()
		{
			CData.fen = CChess.defFen;
			SetMode((int)CMode.tournament);
			CPlayer p1;
			CPlayer p2;
			if (CModeTournament.rotate)
			{
				p1 = GamerList.gamer[1].player;
				p2 = GamerList.gamer[0].player;
			}
			else
			{
				p1 = CModeTournament.SelectPlayer();
				p2 = CModeTournament.SelectOpponent(p1);
			}
			GamerList.gamer[0].SetPlayer(p1);
			GamerList.gamer[1].SetPlayer(p2);
			foreach (ListViewItem lvi in listView1.Items)
				if (lvi.Text == CModeTournament.player)
				{
					int top = lvi.Index;
					top -= 4;
					if (top < 0)
						top = 0;
					lvi.Selected = true;
					listView1.TopItem = listView1.Items[top];
					listView1.Sort();
					listView1.Focus();
					ShowHistoryList();
					break;
				}
			Clear();
		}

		void TrainingShow()
		{
			labGames.Text = $"Games {CModeTraining.games}";
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
			SetMode((int)CMode.training);
			CPlayer pw = new CPlayer("Trained");
			pw.engine = CModeTraining.trained;
			pw.book = CModeTraining.trainedBook;
			switch (CModeTraining.modeValueTrained.mode)
			{
				case "Blitz":
					pw.mode = "blitz";
					break;
				case "Depth":
					pw.mode = "depth";
					break;
				case "Nodes":
					pw.mode = "nodes";
					break;
				default:
					pw.mode = "movetime";
					break;
			}
			pw.value = Convert.ToString(CModeTraining.modeValueTrained.GetValue());
			CPlayer pb = new CPlayer("Teacher");
			pb.engine = CModeTraining.teacher;
			pb.book = CModeTraining.teacherBook;
			switch (CModeTraining.modeValueTeacher.mode)
			{
				case "Blitz":
					pb.mode = "blitz";
					break;
				case "Depth":
					pb.mode = "depth";
					break;
				case "Nodes":
					pb.mode = "nodes";
					break;
				default:
					pb.mode = "movetime";
					break;
			}
			pb.value = Convert.ToString(CModeTraining.modeValueTeacher.GetValue());
			GamerList.gamer[0].SetPlayer(pw);
			GamerList.gamer[1].SetPlayer(pb);
			if (CModeTraining.rotate)
				GamerList.Rotate();
			CModeTraining.rotate = !CModeTraining.rotate;
			Clear();
			CModeTraining.SaveToIni();
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

		void ShowHistoryList()
		{
			if (listView1.SelectedItems.Count > 0)
			{
				ListViewItem top2 = null;
				ListViewItem item = listView1.SelectedItems[0];
				string name = item.SubItems[0].Text;
				CPlayer player = CPlayerList.GetPlayerAuto(name);
				lPlayer.Text = $"{player.name} - {player.elo}";
				listView2.Items.Clear();
				CPlayerList.Sort();
				CPlayerList.FillPosition();
				foreach (CPlayer p in CPlayerList.list)
					if (p.engine != "Human")
					{
						int rw = 0;
						int rl = 0;
						int rd = 0;
						CModeTournament.tourList.CountGames(name, p.name, ref rw, ref rl, ref rd);
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
							listView2.Items.Add(lvi);
							if ((player.position - p.position) == 4)
								top2 = lvi;
						}
					}
				if (top2 != null)
					listView2.TopItem = top2;
			}
		}

		void Reset()
		{
			if (!CData.reset)
				return;
			CData.reset = false;
			cbEngine.Items.Clear();
			cbTeacherEngine.Items.Clear();
			cbTrainedEngine.Items.Clear();
			cbEngine1.Items.Clear();
			cbEngine2.Items.Clear();
			foreach (CEngine e in CEngineList.list)
			{
				cbEngine.Items.Add(e.name);
				cbEngine1.Items.Add(e.name);
				cbEngine2.Items.Add(e.name);
				cbTeacherEngine.Items.Add(e.name);
				cbTrainedEngine.Items.Add(e.name);
			}
			cbTeacherBook.Items.Clear();
			cbTrainedBook.Items.Clear();
			cbBook.Items.Clear();
			cbBook1.Items.Clear();
			cbBook2.Items.Clear();
			cbTeacherBook.Items.Add("None");
			cbTrainedBook.Items.Add("None");
			cbBook.Items.Add("None");
			cbBook1.Items.Add("None");
			cbBook2.Items.Add("None");
			foreach (CBook b in CBookList.list)
			{
				cbTeacherBook.Items.Add(b.name);
				cbTrainedBook.Items.Add(b.name);
				cbBook.Items.Add(b.name);
				cbBook1.Items.Add(b.name);
				cbBook2.Items.Add(b.name);
			}
			cbMode.SelectedIndex = 0;
			cbTeacherBook.SelectedIndex = 0;
			cbTrainedBook.SelectedIndex = 0;
			cbBook.SelectedIndex = 0;
			cbBook1.SelectedIndex = 0;
			cbBook2.SelectedIndex = 0;
			cbEngine.SelectedIndex = 0;
			TournamentReset();
			if (SortingColumn != null)
				SortingColumn.Text = SortingColumn.Text.Substring(2);
			SortingColumn = listView1.Columns[1];
			listView1.Columns[1].Text = $"▼ {listView1.Columns[1].Text}";
			listView1.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			listView1.Sort();
		}

		public bool MakeMove(string emo)
		{
			CArrow.Hide();
			CGamer cp = GamerList.GamerCur();
			cp.UpdateTime();
			cp.timer.Stop();
			emo = emo.ToLower();
			CPlayer uw = GamerList.GamerCur().player;
			CPlayer ul = GamerList.GamerSec().player;
			double m = GamerList.curIndex == 0 ? 0.01 : -0.01;
			chart1.Series[GamerList.curIndex].Points.Add(GamerList.GamerCur().iScore * m);
			GamerList.GamerCur().iScore = 0;
			if (IsAutoElo() && CModeGame.ranked && (cp.engine == null) && ((Chess.g_moveNumber >> 1) == 4))
			{
				cp.player.eloOld = Convert.ToDouble(cp.player.elo);
				cp.player.eloNew = cp.player.eloLess;
				cp.player.SaveToIni();
			}
			bool ivm = Chess.IsValidMove(emo) != 0;
			if (!ivm)
			{
				string emo2 = $"{emo}q";
				ivm = Chess.IsValidMove(emo2) != 0;
				if (ivm)
					emo = emo2;
			}
			if (!ivm)
			{
				tssMoves.ForeColor = Color.Red;
				tssMoves.Text = "Move error " + emo;
				FormLog.This.richTextBox1.AppendText($" error {emo}\n", Color.Red);
				FormLog.This.richTextBox1.AppendText($"{Chess.GetFen()}\n");
				List<int> gMoves = Chess.GenerateValidMoves();
				List<string> eMoves = new List<string>();
				foreach (int gm in gMoves)
					eMoves.Add(Chess.FormatMove(gm));
				FormLog.This.richTextBox1.AppendText($"{string.Join(" ", eMoves)}\n");
				FormLog.This.richTextBox1.SaveFile("Error.rtf");
				return false;
			}

			int gmo = Chess.EmoToGmo(emo);
			AddMove(gmo, emo);
			CBoard.MakeMove(gmo);
			Chess.MakeMove(gmo);
			CEco eco = EcoList.GetEco(Chess.GetEpd());
			if (eco != null)
			{
				labEco.Text = eco.name;
				labEco.ForeColor = Color.Brown;
			}
			else
				labEco.ForeColor = Color.Black;
			int moveNumber = (Chess.g_moveNumber >> 1) + 1;
			tssMove.Text = "Move " + moveNumber.ToString() + " " + Chess.g_move50.ToString();
			if (cp.timeTotal > 100)
			{
				cp.totalNpsSum += cp.nodes;
				cp.totalNps = (ulong)Convert.ToInt64((cp.totalNpsSum * 1000) / cp.timeTotal);
			}
			CData.gameState = Chess.GetGameState();
			if (CData.gameState == 0)
			{
				GamerList.Next();
				if (GamerList.GamerCur().player.engine == "Human")
					moves = Chess.GenerateValidMoves();
				else
					if (GamerList.GamerCur().white)
					lvMovesW.Items.Clear();
				else
					lvMovesB.Items.Clear();
			}
			else
				GameOver(uw, ul);
			return true;
		}

		void GameOver(CPlayer uw, CPlayer ul)
		{
			int eloW = Convert.ToInt32(uw.elo);
			int eloL = Convert.ToInt32(ul.elo);
			switch (CData.gameState)
			{
				case (int)CGameState.mate:
					tssMoves.ForeColor = Color.Lime;
					tssMoves.Text = uw.name + " win";
					break;
				case (int)CGameState.stalemate:
					tssMoves.ForeColor = Color.Yellow;
					tssMoves.Text = "Stalemate";
					break;
				case (int)CGameState.repetition:
					tssMoves.ForeColor = Color.Yellow;
					tssMoves.Text = "Threefold repetition";
					break;
				case (int)CGameState.move50:
					tssMoves.ForeColor = Color.Yellow;
					tssMoves.Text = "Fifty-move rule";
					break;
				case (int)CGameState.material:
					tssMoves.ForeColor = Color.Yellow;
					tssMoves.Text = "Insufficient material";
					break;
			}
			FormLog.This.richTextBox1.AppendText($"Finish {tssMoves.Text}\n", Color.Gray);
			if (CData.gameMode == (int)CMode.game)
			{
				if (IsAutoElo())
					if (uw.name == "Human")
					{
						if (CData.gameState == (int)CGameState.mate)
							uw.eloNew = uw.eloMore;
						else
							uw.eloNew = Convert.ToInt32(uw.eloOld);
					}
					else
					{
						if (CData.gameState == (int)CGameState.mate)
							ul.eloNew = ul.eloLess;
						else
							ul.eloNew = Convert.ToInt32(ul.eloOld);
					}
				ShowLastGame();
			}
			if (CData.gameMode == (int)CMode.match)
			{
				CModeMatch.games++;
				if (CData.gameState == (int)CGameState.mate)
				{
					if (uw.name == labMatch10.Text)
					{
						CModeMatch.win++;
					}
					else
					{
						CModeMatch.loose++;
					}
				}
				else
				{
					CModeMatch.draw++;
				}
				CModeMatch.SaveToIni();
				MatchShow();
			}
			if (CData.gameMode == (int)CMode.tournament)
			{
				int indexW = CPlayerList.GetIndexElo(eloW);
				int indexL = CPlayerList.GetIndexElo(eloL);
				int optW = CPlayerList.GetOptElo(indexW);
				int optL = CPlayerList.GetOptElo(indexL);
				int OW = optW;
				int OL = optL;
				if (CData.gameState == (int)CGameState.mate)
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
					string r = uw == GamerList.gamer[0].player ? "w" : "b";
					CModeTournament.tourList.Write(GamerList.gamer[0].player.name, GamerList.gamer[1].player.name, r);
				}
				else
				{
					int opt = (OW + OL) >> 1;
					OW = opt;
					OL = opt;
					CModeTournament.tourList.Write(GamerList.gamer[0].player.name, GamerList.gamer[1].player.name, "d");
				}
				int newW = Convert.ToInt32(eloW * 0.9 + Math.Max(OW, eloL) * 0.1);
				int newL = Convert.ToInt32(eloL * 0.9 + Math.Min(OL, eloW) * 0.1);
				uw.elo = newW.ToString();
				ul.elo = newL.ToString();
				uw.eloOld = uw.eloOld * .9 + newW * .1;
				ul.eloOld = ul.eloOld * .9 + newL * .1; ;
				uw.SaveToIni();
				ul.SaveToIni();
				TournamentUpdate(uw);
				TournamentUpdate(ul);
				CModeTournament.rotate = (OW != OL) && (newW < newL);
			}
			if (CData.gameMode == (int)CMode.training)
			{
				CModeTraining.games++;
				if (CData.gameState == (int)CGameState.mate)
				{
					if (uw.name == "Teacher")
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
				TrainingShow();
			}
			FormLog.This.richTextBox1.SaveFile($"{CData.modeName}.rtf");
			CreatePgn();
			timerStart.Start();
		}

		void XBGameOver(string msg)
		{
			if (CData.gameState == (int)CGameState.normal)
			{
				CPlayer ul = GamerList.GamerCur().player;
				CPlayer uw = GamerList.GamerSec().player;
				CData.gameState = (int)CGameState.mate;
				FormLog.This.richTextBox1.AppendText($"Game over {ul.name} {msg}\n", Color.Gray);
				GameOver(uw, ul);
			}
		}

		void Clear()
		{
			isBook = false;
			labEco.Text = "";
			tssMove.Text = "Move 1 0";
			tssMoves.ForeColor = Color.Gainsboro;
			tssMoves.Text = "Good luck";
			chart1.Series[0].Points.Clear();
			chart1.Series[1].Points.Clear();
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			Chess.InitializeFromFen(CData.fen);
			CHistory.NewGame(Chess.GetFen());
			CBoard.Clear();
			CBoard.Fill();
			GamerList.Init();
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			CData.back = 0;
			CGamer pw = GamerList.gamer[0];
			CGamer pb = GamerList.gamer[1];
			FormLog.This.richTextBox1.Clear();
			if (pw.engine != null)
				FormLog.This.richTextBox1.AppendText($"White {pw.player.name} {pw.player.engine} {pw.engine.parameters}\n", Color.Gray);
			if (pb.engine != null)
				FormLog.This.richTextBox1.AppendText($"Black {pb.player.name} {pb.player.engine} {pb.engine.parameters}\n", Color.Gray);
			labBack.Text = $"Back {CData.back}";
			RenderInfo(pw);
			RenderInfo(pb);
			CData.gameState = (int)CGameState.normal;
			CArrow.Hide();
			timer1.Enabled = CData.gameMode != (int)CMode.edit;
			ShowGamers();
		}

		public void RenderBoard()
		{
			if ((GamerList.gamer[0].player == null) || (GamerList.gamer[1].player == null))
				return;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			boardRotate = ((GamerList.gamer[1].engine == null) && (GamerList.gamer[0].engine != null)) ^ CData.rotateBoard;
			if ((GamerList.gamer[1].engine == null) && (GamerList.gamer[0].engine == null))
				boardRotate = !CChess.whiteTurn;
			if (boardRotate)
			{
				labNameT.Text = GamerList.gamer[0].player.name;
				labNameD.Text = GamerList.gamer[1].player.name;
				labColorT.BackColor = Color.White;
				labColorD.BackColor = Color.Black;
				labTakenT.ForeColor = Color.White;
				labTakenD.ForeColor = Color.Black;
			}
			else
			{
				labNameT.Text = GamerList.gamer[1].player.name;
				labNameD.Text = GamerList.gamer[0].player.name;
				labColorT.BackColor = Color.Black;
				labColorD.BackColor = Color.White;
				labTakenT.ForeColor = Color.Black;
				labTakenD.ForeColor = Color.White;
			}
			if ((boardRotate ^ CChess.whiteTurn) ^ (CData.gameState != 0))
			{
				labTimeT.BackColor = Color.LightGray;
				labTimeD.BackColor = Color.Yellow;
			}
			else
			{
				labTimeT.BackColor = Color.Yellow;
				labTimeD.BackColor = Color.LightGray;
			}
			CBoard.board = new Bitmap(CBoard.bitmap[boardRotate ? 1 : 0]);
			Graphics g = Graphics.FromImage(CBoard.board);
			Brush brushRed = new SolidBrush(Color.FromArgb(0x80, 0xff, 0x00, 0x00));
			Brush brushYellow = new SolidBrush(Color.FromArgb(0x80, 0xff, 0xff, 0x00));
			Font fontPiece = new Font(pfc.Families[0], CBoard.field);
			Brush brushW = new SolidBrush(Color.White);
			Brush brushB = new SolidBrush(Color.Black);
			Pen penW = new Pen(Color.Black, 4);
			Pen penB = new Pen(Color.White, 4);
			GraphicsPath gpW = new GraphicsPath();
			GraphicsPath gpB = new GraphicsPath();
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			g.SmoothingMode = SmoothingMode.HighQuality;
			Rectangle rec = new Rectangle();
			for (int y = 0; y < 8; y++)
			{
				int yr = boardRotate ? 7 - y : y;
				int y2 = CBoard.marginH + yr * CBoard.field;
				for (int x = 0; x < 8; x++)
				{
					int i = y * 8 + x;
					int xr = boardRotate ? 7 - x : x;
					int x2 = CBoard.marginW + xr * CBoard.field;
					rec.X = x2;
					rec.Y = y2;
					rec.Width = CBoard.field;
					rec.Height = CBoard.field;
					if ((i == CDrag.lastSou) || (i == CDrag.lastDes) || (CBoard.list[i].color != Color.Empty))
						g.FillRectangle(brushYellow, rec);
					else if (CBoard.list[i].attacked && (CData.gameMode != (int)CMode.edit))
						g.FillRectangle(brushRed, rec);
					CPiece piece = CBoard.list[i].piece;
					if (piece == null)
						continue;
					GraphicsPath gp1;
					int image;
					if (piece.desImage >= 0)
					{
						gp1 = piece.desImage > 5 ? gpB : gpW;
						image = piece.desImage % 6;
						gp1.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
					}
					piece.SetDes(x2, y2);
					if ((i == CDrag.lastDes) && CDrag.dragged)
					{
						piece.dt = DateTime.Now;
						piece.curXY.X = CDrag.mouseX - 32;
						piece.curXY.Y = CDrag.mouseY - 32;
						piece.souXY.X = piece.curXY.X;
						piece.souXY.Y = piece.curXY.Y;
					}
					rec.X = piece.curXY.X;
					rec.Y = piece.curXY.Y;
					gp1 = piece.image > 5 ? gpB : gpW;
					image = piece.image % 6;
					gp1.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
				}
			}
			if (CChess.whiteTurn)
			{
				g.DrawPath(penB, gpB);
				g.FillPath(brushB, gpB);
				g.DrawPath(penW, gpW);
				g.FillPath(brushW, gpW);

			}
			else
			{
				g.DrawPath(penW, gpW);
				g.FillPath(brushW, gpW);
				g.DrawPath(penB, gpB);
				g.FillPath(brushB, gpB);

			}

			if ((CBoard.showArrow) && (CArrow.visible))
			{
				Pen pen = new Pen(Color.FromArgb(0x90, 0x10, 0xff, 0x10), 8);
				pen.StartCap = LineCap.RoundAnchor;
				pen.EndCap = LineCap.ArrowAnchor;
				g.DrawLine(pen, CBoard.GetMiddle(CArrow.a), CBoard.GetMiddle(CArrow.b));
			}
			Graphics pg = panBoard.CreateGraphics();
			pg.DrawImage(CBoard.board, 0, 0);
			pg.Dispose();
			sf.Dispose();
			penW.Dispose();
			penB.Dispose();
			brushRed.Dispose();
			brushYellow.Dispose();
			brushW.Dispose();
			brushB.Dispose();
			fontPiece.Dispose();
			g.Dispose();
			CBoard.finished = CBoard.animated;
			CBoard.Render();
			if (!CBoard.animated)
			{
				CBoard.ShowAttack(FormOptions.This.cbAttack.Checked);
				CBoard.SetImage();
				RenderTaken();
			}
			stopwatch.Stop();
			CData.fps = CData.fps * 0.9 + 100 / stopwatch.ElapsedMilliseconds;
			labFPS.Text = $"FPS {Convert.ToInt32(CData.fps)}";
		}

		void RenderInfo(CGamer cp)
		{
			if (!FormOptions.This.cbShowPonder.Checked)
				cp.ponder = "";
			ulong nps = cp.totalNps > 0 ? cp.totalNps : cp.nps;
			if (boardRotate ^ cp.white)
			{
				labTimeD.Text = cp.GetTime();
				labEloD.Text = cp.GetElo();
				labScoreB.Text = $"Score {cp.score}";
				labNodesB.Text = $"Nodes {cp.nodes.ToString("N0")}";
				labNpsB.Text = $"Nps {nps.ToString("N0")}";
				labPonderB.Text = $"Ponder {cp.ponder}";
				labBookB.Text = $"Book {cp.usedBook}";
				labDepthB.Text = $"Depth {cp.GetDepth()}";
			}
			else
			{
				labTimeT.Text = cp.GetTime();
				labEloT.Text = cp.GetElo();
				labScoreT.Text = $"Score {cp.score}";
				labNodesT.Text = $"Nodes {cp.nodes.ToString("N0")}";
				labNpsT.Text = $"Nps {nps.ToString("N0")}";
				labPonderT.Text = $"Ponder {cp.ponder}";
				labBookT.Text = $"Book {cp.usedBook}";
				labDepthT.Text = $"Depth {cp.GetDepth()}";
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
			mw = $"DPV {mw}";
			string mb = (-material).ToString();
			if (-material > 0)
				mb = $"+{mb}";
			mb = $"DPV {mb}";
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
			CModeGame.ranked = false;
			SetMode((int)CMode.game);
			if (!Chess.InitializeFromFen(fen))
			{
				MessageBox.Show("Wrong fen");
				return;
			}
			GamerList.curIndex = Chess.g_moveNumber & 1;
			GamePrepare();
			int w = CChess.whiteTurn ? 0 : 1;
			if (!GamerList.gamer[w].IsHuman())
				GamerList.Rotate();
			GamerList.gamer[0].Init(true);
			GamerList.gamer[1].Init(false);
			cbColor.SelectedIndex = GamerList.curIndex;
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			CHistory.NewGame(fen);
			CBoard.Fill();
			RenderBoard();
			CGamer pw = GamerList.gamer[0];
			CGamer pb = GamerList.gamer[1];
			FormLog.This.richTextBox1.Clear();
			FormLog.This.richTextBox1.AppendText($"Fen {Chess.GetFen()}\n", Color.Gray);
			if (pw.engine == null)
				FormLog.This.richTextBox1.AppendText($"White {pw.player.name}\n", Color.Gray);
			else
				FormLog.This.richTextBox1.AppendText($"White {pw.player.name} {pw.player.engine} {pw.engine.parameters}\n", Color.Gray);
			if (pb.engine == null)
				FormLog.This.richTextBox1.AppendText($"White {pb.player.name}\n", Color.Gray);
			else
				FormLog.This.richTextBox1.AppendText($"Black {pb.player.name} {pb.player.engine} {pb.engine.parameters}\n", Color.Gray);
			tssMoves.ForeColor = Color.Lime;
			tssMoves.Text = $"Load fen {Chess.GetFen()}";
			labBack.Text = $"Back {CData.back}";
			RenderInfo(pw);
			RenderInfo(pb);
			CData.gameState = 0;
			moves = Chess.GenerateValidMoves();
			timer1.Enabled = true;
		}

		private void MoveToRtb(int count, int gmo, string emo)
		{
			int piece = CChess.g_board[gmo & 0xff] & 7;
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

		private void AddMove(int gmo, string emo)
		{
			MoveToRtb(CHistory.moveList.Count, gmo, emo);
			string san = Chess.EmoToSan(emo);
			CHistory.AddMove(gmo, emo, san);
			CChess.EmoToSD(emo, out CDrag.lastSou, out CDrag.lastDes);
		}

		void ShowHistory()
		{
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			for (int n = 0; n < CHistory.moveList.Count; n++)
			{
				CHisMove m = CHistory.moveList[n];
				MoveToRtb(n, m.gmo, m.emo);
			}
		}

		void RenderHistory()
		{
			Chess.InitializeFromFen(CHistory.fen);
			foreach (CHisMove m in CHistory.moveList)
			{
				Chess.MakeMove(m.emo);
			}
			CChess.EmoToSD(CHistory.LastMove(), out CDrag.lastSou, out CDrag.lastDes);
			CBoard.Fill();
			ShowHistory();
		}

		bool TryMove(int s, int d)
		{
			int m = Chess.IsValidMove(s, d, "q");
			if (m == 0)
				return false;
			string em = Chess.FormatMove(m);
			return MakeMove(em);
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
			labMovesW.Text = gw.GetName();
			labMovesB.Text = gb.GetName();
			labProtocolW.Text = gw.GetProtocol();
			labProtocolB.Text = gb.GetProtocol();
			splitContainerMoves.Panel1Collapsed = gw.IsHuman();
			splitContainerMoves.Panel2Collapsed = gb.IsHuman();
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
			CBoard.Clear();
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

		private void FormChess_FormClosed(object sender, FormClosedEventArgs e)
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
			GamerList.Terminate();
			SortingColumn.Dispose();

		}

		private void Timer1_Tick_1(object sender, EventArgs e)
		{
			lock (CMessageList.list)
			{
				GetMessage();
			}
			if (CBoard.animated || CBoard.finished || CDrag.dragged)
			{
				RenderBoard();
			}
			else
			{
				CGamer cp = GamerList.GamerCur();
				CGamer sp = GamerList.GamerSec();
				RenderInfo(cp);
				RenderInfo(sp);
				if (cp.engine != null)
				{
					if (!cp.started)
						cp.Start();
					else if (cp.readyok && !cp.go)
						cp.CompMakeMove();
				}
				else
					cp.go = true;
			}
		}

		private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedTab = tabPageGame;
			GameStart();
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
			CArrow.Hide();
			BoardPrepare();
			ShowAutoElo();
		}

		private void ButTraining_Click(object sender, EventArgs e)
		{
			CModeTraining.Reset();
			TraingStart();
		}

		private void TimerStart_Tick(object sender, EventArgs e)
		{
			timerStart.Stop();
			if (CData.gameMode == (int)CMode.match)
			{
				MatchStart();
			}
			if (CData.gameMode == (int)CMode.tournament)
			{
				TournamentStart();
			}
			if (CData.gameMode == (int)CMode.training)
			{
				TraingStart();
			}
		}

		private void saveToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Chess.GetFen());
		}

		private void loadFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadFen(Clipboard.GetText().Trim());
		}

		private void loadFromClipboardToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SetMode((int)CMode.game);
			string pgn = Clipboard.GetText().Trim();
			string[] ml = pgn.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			Chess.InitializeFromFen();
			CHistory.NewGame();
			foreach (string emo in ml)
			{
				int gmo = Chess.MakeMove(emo);
				if (gmo > 0)
				{
					string san = Chess.EmoToSan(emo);
					CHistory.AddMove(gmo, emo, san);
				}
				else break;
			}
			GamerList.curIndex = Chess.g_moveNumber & 1;
			GamePrepare();
			GamerList.gamer[0].Init(true);
			GamerList.gamer[1].Init(false);
			cbColor.SelectedIndex = GamerList.curIndex;
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			ShowHistory();
			CBoard.Fill();
			RenderBoard();
			CGamer pw = GamerList.gamer[0];
			CGamer pb = GamerList.gamer[1];
			FormLog.This.richTextBox1.Clear();
			FormLog.This.richTextBox1.AppendText($"Pgn {CHistory.GetMoves()}\n", Color.Gray);
			FormLog.This.richTextBox1.AppendText($"White {pw.player.name} {pw.player.engine}\n", Color.Gray);
			FormLog.This.richTextBox1.AppendText($"Black {pb.player.name} {pb.player.engine}\n", Color.Gray);
			tssMoves.ForeColor = Color.Gainsboro;
			tssMoves.Text = $"Pgn {CHistory.GetMoves()}";
			labBack.Text = $"Back {CData.back}";
			RenderInfo(pw);
			RenderInfo(pb);
			CData.gameState = 0;
			moves = Chess.GenerateValidMoves();
			timer1.Enabled = true;
		}

		private void logToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!FormLog.This.Visible)
				FormLog.This.Show(this);
		}

		private void bStartMatch_Click(object sender, EventArgs e)
		{
			CModeMatch.Reset();
			MatchStart();
		}

		private void butStartTournament_Click(object sender, EventArgs e)
		{
			TournamentStart();
		}

		private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ColumnHeader new_sorting_column = listView1.Columns[e.Column];
			SortOrder sort_order;
			if (SortingColumn == null)
			{
				sort_order = SortOrder.Ascending;
			}
			else
			{
				if (new_sorting_column == SortingColumn)
				{
					if (SortingColumn.Text.StartsWith("▼ "))
					{
						sort_order = SortOrder.Descending;
					}
					else
					{
						sort_order = SortOrder.Ascending;
					}
				}
				else
				{
					sort_order = SortOrder.Ascending;
				}
				SortingColumn.Text = SortingColumn.Text.Substring(2);
			}
			SortingColumn = new_sorting_column;
			if (sort_order == SortOrder.Ascending)
			{
				SortingColumn.Text = "▼ " + SortingColumn.Text;
			}
			else
			{
				SortingColumn.Text = "▲ " + SortingColumn.Text;
			}
			listView1.ListViewItemSorter = new ListViewComparer(e.Column, sort_order);
			listView1.Sort();
		}

		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GamerList.GamerCur().EngineStop();
		}

		private void restartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GamerList.GamerCur().SetPlayer();
		}

		private void terminateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GamerList.GamerCur().enginePro.Terminate();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GamerList.GamerCur().EngineClose();
		}

		private void tabControl1_Selected(object sender, TabControlEventArgs e)
		{
			CData.fen = Chess.GetFen();
			CData.modeName = tabControl1.SelectedTab.Text;
			CBoard.Fill();
			RenderBoard();
			SetMode(tabControl1.SelectedIndex);
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			CDrag.mouseX = e.X;
			CDrag.mouseY = e.Y;
			int x = (e.X - CBoard.marginW) / CBoard.field;
			int y = (e.Y - CBoard.marginH) / CBoard.field;
			if (boardRotate)
			{
				x = 7 - x;
				y = 7 - y;
			}
			CDrag.mouseIndex = y * 8 + x;
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (CData.gameMode == (int)CMode.edit)
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
				CBoard.UpdateField(CDrag.mouseIndex);
				RenderBoard();
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
			if (CData.gameMode == (int)CMode.game)
			{
				if (CDrag.lastDes == CDrag.mouseIndex)
				{
					TryMove(CDrag.last, CDrag.mouseIndex);
				}
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
			RenderBoard();
		}

		private void rbColorChanged(object sender, EventArgs e)
		{
			var checkedButton = gbToMove.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
			int i = list.IndexOf(checkedButton);
			CChess.whiteTurn = i == 1;
		}

		private void butContinueGame_Click(object sender, EventArgs e)
		{
			LoadFen(Chess.GetFen());
		}

		private void backToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (CHistory.Back())
			{
				labBack.Text = $"Back {++CData.back}";
				RenderHistory();
				moves = Chess.GenerateValidMoves();
				CData.gameState = Chess.GetGameState();
				ShowLastGame();
				CModeGame.ranked = false;
				ShowAutoElo();
				GamerList.GamerCur().player.elo = GamerList.GamerCur().player.eloLess.ToString();
				GamerList.GamerSec().Undo();
			}
		}

		private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GamerList.Rotate();
		}

		private void SaveToClipboardToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(CHistory.GetMoves());
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
			Chess.InitializeFromFen();
			CBoard.Fill();
			RenderBoard();
		}

		private void cbColor_SelectedValueChanged(object sender, EventArgs e)
		{
			ShowAutoElo();
		}

		private void cbComputer_SelectedValueChanged(object sender, EventArgs e)
		{
			CModeGame.ranked = cbComputer.Text == "Auto";
			ShowAutoElo();
			ShowAuto();
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

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowHistoryList();
		}

		private void nudValue_ValueChanged(object sender, EventArgs e)
		{
			CModeGame.modeValue.SetValue((int)nudValue.Value);
		}

		private void panBoard_Resize(object sender, EventArgs e)
		{
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

		private void listView1_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = lv.Width - 32;
			w = Convert.ToInt32(w / 4);
			lv.Columns[0].Width = w * 2;
			lv.Columns[1].Width = w;
			lv.Columns[2].Width = w;
		}

		private void listView2_Resize(object sender, EventArgs e)
		{
			ListView lv = (ListView)sender;
			int w = lv.Width - 32;
			w = Convert.ToInt32(w / 6);
			lv.Columns[0].Width = w * 3;
			lv.Columns[1].Width = w;
			lv.Columns[2].Width = w;
			lv.Columns[3].Width = w;
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

		private void FormChess_Resize(object sender, EventArgs e)
		{
			LinesResize(lvMovesW);
			LinesResize(lvMovesB);
		}

		private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeGame.modeValue.mode = cbMode.Text;
			nudValue.Increment = CModeGame.modeValue.GetIncrement();
			nudValue.Minimum = nudValue.Increment;
			nudValue.Value = CModeGame.modeValue.GetValue();
			toolTip1.SetToolTip(nudValue,CModeGame.modeValue.GetTip());
		}

		private void cbMode1_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeMatch.modeValue1.mode = cbMode1.Text;
			nudValue1.Increment = CModeMatch.modeValue1.GetIncrement();
			nudValue1.Minimum = nudValue1.Increment;
			nudValue1.Value = CModeMatch.modeValue1.GetValue();
		}

		private void cbMode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeMatch.modeValue2.mode = cbMode2.Text;
			nudValue2.Increment = CModeMatch.modeValue2.GetIncrement();
			nudValue2.Minimum = nudValue2.Increment;
			nudValue2.Value = CModeMatch.modeValue2.GetValue();
		}

		private void cbTrainedMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTraining.modeValueTrained.mode = cbTrainedMode.Text;
			nudTrained.Increment = CModeTraining.modeValueTrained.GetIncrement();
			nudTrained.Minimum = nudTrained.Increment;
			nudTrained.Value = CModeTraining.modeValueTrained.GetValue();
		}

		private void cbTeacherMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			CModeTraining.modeValueTeacher.mode = cbTeacherMode.Text;
			nudTeacher.Increment = CModeTraining.modeValueTeacher.GetIncrement();
			nudTeacher.Minimum = nudTeacher.Increment;
			nudTeacher.Value = CModeTraining.modeValueTeacher.GetValue();
		}
	}
}
