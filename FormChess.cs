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
			CBoard.Prepare();
			pictureBox1.Size = new Size(CBoard.size, CBoard.size);
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
			labTakenB.Font = fontChess;
			Chess.Initialize();
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
			CEngineList.LoadFromIni();
			CBookList.LoadFromIni();
			CPlayerList.LoadFromIni();
			CModeGame.LoadFromIni();
			CModeMatch.LoadFromIni();
			CModeTournament.LoadFromIni();
			CModeTraining.LoadFromIni();
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
					labLast.ForeColor = Color.Gainsboro;
					string s = Uci.GetValue("cp");
					if (s != "")
						g.score = s;
					s = Uci.GetValue("mate");
					if (s != "")
					{
						if (Int32.Parse(s) > 0)
							g.score = $"+{s}M";
						else
							g.score = $"{s}M";
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
						labLast.Text = pv;
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
					if (msg.Contains("resign"))
						XBGameOver(msg);
					else if (g.wbok && (Uci.tokens.Length > 4))
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
							labLast.ForeColor = Color.Gainsboro;
							labLast.Text = pv;
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
			labLast.ForeColor = Color.Aquamarine;
			labLast.Text = $"book {emo}";
		}

		void SetMode(int mode)
		{
			moveToolStripMenuItem.Visible = false;
			labEloB.Visible = true;
			labEloT.Visible = true;
			labProtocolB.Visible = true;
			labProtocolT.Visible = true;
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
					labProtocolB.Visible = false;
					labProtocolT.Visible = false;
					GameShow();
					break;
				case (int)CMode.match:
					MatchShow();
					break;
				case (int)CMode.training:
					labEloB.Visible = false;
					labEloT.Visible = false;
					labProtocolB.Visible = false;
					labProtocolT.Visible = false;
					TrainingShow();
					break;
				case (int)CMode.edit:
					labEloB.Visible = false;
					labEloT.Visible = false;
					labProtocolB.Visible = false;
					labProtocolT.Visible = false;
					EditShow();
					break;
			}
		}

		bool IsAutoElo()
		{
			return (cbComputer.Text == "Auto") && FormOptions.This.cbGameAutoElo.Checked && (CData.gameMode == (int)CMode.game);
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
				labLast.ForeColor = Color.FromArgb(0, 0xff, 0);
				labLast.Text = $"Last game you win new elo is {hu.eloNew} ({eloCur})";
				CRapLog.Add(labLast.Text);
			}
			if (hu.eloNew < eloCur)
			{
				result = true;
				labLast.ForeColor = Color.FromArgb(0xff, 0, 0);
				labLast.Text = $"Last game you loose new elo is {hu.eloNew} ({eloCur})";
				CRapLog.Add(labLast.Text);
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
						pc.value = Convert.ToString(CModeMatch.value1 * 60000);
						break;
					case "Depth":
						pc.mode = "depth";
						pc.value = Convert.ToString(CModeMatch.value1);
						break;
					case "Nodes":
						pc.mode = "nodes";
						pc.value = Convert.ToString(CModeMatch.value1 * 1000000);
						break;
					case "Infinite":
						pc.mode = "infinite";
						pc.value = "";
						break;
					default:
						pc.mode = "movetime";
						pc.value = Convert.ToString(CModeMatch.value1 * 1000);
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
			SetMode((int)CMode.game);
			Clear();
			bool lg = ShowLastGame();
			GamePrepare();
			if ((!lg && CModeGame.rotate && (cbColor.Text == "Auto")) || (cbColor.Text == "Black"))
			{
				CModeGame.rotate = false;
				GamerList.Rotate();
			}
			else
				CModeGame.rotate = true;
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
			cbMode1.SelectedIndex = cbMode1.FindStringExact(CModeMatch.mode1);
			cbMode2.SelectedIndex = cbMode2.FindStringExact(CModeMatch.mode2);
			cbBook1.SelectedIndex = cbBook1.FindStringExact(CModeMatch.book1);
			cbBook2.SelectedIndex = cbBook2.FindStringExact(CModeMatch.book2);
			cbValue1.SelectedIndex = CModeMatch.value1 - 1;
			cbValue2.SelectedIndex = CModeMatch.value2 - 1;
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
			CModeMatch.mode1 = cbMode1.Text;
			CModeMatch.mode2 = cbMode2.Text;
			CModeMatch.value1 = cbValue1.SelectedIndex + 1;
			CModeMatch.value2 = cbValue2.SelectedIndex + 1;
			CModeMatch.book1 = cbBook1.Text;
			CModeMatch.book2 = cbBook2.Text;
			SetMode((int)CMode.match);
			CPlayer p1 = new CPlayer("Player 1");
			p1.engine = CModeMatch.engine1;
			p1.book = CModeMatch.book1;
			switch (CModeMatch.mode1)
			{
				case "Blitz":
					p1.mode = "blitz";
					p1.value = Convert.ToString(CModeMatch.value1 * 60000);
					break;
				case "Depth":
					p1.mode = "depth";
					p1.value = Convert.ToString(CModeMatch.value1);
					break;
				case "Nodes":
					p1.mode = "nodes";
					p1.value = Convert.ToString(CModeMatch.value1 * 1000000);
					break;
				default:
					p1.mode = "movetime";
					p1.value = Convert.ToString(CModeMatch.value1 * 1000);
					break;
			}
			CPlayer p2 = new CPlayer("Player 2");
			p2.engine = CModeMatch.engine2;
			p2.book = CModeMatch.book2;
			switch (CModeMatch.mode2)
			{
				case "Blitz":
					p2.mode = "blitz";
					p2.value = Convert.ToString(CModeMatch.value2 * 60000);
					break;
				case "Depth":
					p2.mode = "depth";
					p2.value = Convert.ToString(CModeMatch.value2);
					break;
				case "Nodes":
					p2.mode = "nodes";
					p2.value = Convert.ToString(CModeMatch.value2 * 1000000);
					break;
				default:
					p2.mode = "movetime";
					p2.value = Convert.ToString(CModeMatch.value2 * 1000);
					break;
			}
			tbCommand1.Text = p1.GetCommand();
			tbCommand2.Text = p2.GetCommand();
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
			if (CModeTournament.rotate)
				GamerList.Rotate();
			else
			{
				CPlayer p1 = CModeTournament.SelectPlayer();
				CPlayer p2 = CModeTournament.SelectOpponent(p1);
				GamerList.gamer[0].SetPlayer(p1);
				GamerList.gamer[1].SetPlayer(p2);
			}
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
			cbTeacherMode.SelectedIndex = cbTeacherMode.FindStringExact(CModeTraining.teacherMode);
			cbTrainedMode.SelectedIndex = cbTrainedMode.FindStringExact(CModeTraining.trainedMode);
			cbTeacherBook.SelectedIndex = cbTeacherBook.FindStringExact(CModeTraining.teacherBook);
			cbTrainedBook.SelectedIndex = cbTrainedBook.FindStringExact(CModeTraining.trainedBook);
			nudTeacher.Value = CModeTraining.teacherValue;
			nudTrained.Value = CModeTraining.trainedValue;
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
			CModeTraining.teacherMode = cbTeacherMode.Text;
			CModeTraining.trainedMode = cbTrainedMode.Text;
			CModeTraining.teacherBook = cbTeacherBook.Text;
			CModeTraining.trainedBook = cbTrainedBook.Text;
			CModeTraining.teacherValue = (int)nudTeacher.Value;
			CModeTraining.trainedValue = (int)nudTrained.Value;
			SetMode((int)CMode.training);
			CPlayer uw = new CPlayer("Trained");
			uw.engine = CModeTraining.trained;
			uw.book = CModeTraining.trainedBook;
			switch (CModeTraining.trainedMode)
			{
				case "Blitz":
					uw.mode = "blitz";
					uw.value = Convert.ToString(CModeTraining.trainedValue * 10000);
					break;
				case "Depth":
					uw.mode = "depth";
					uw.value = Convert.ToString(CModeTraining.trainedValue);
					break;
				case "Nodes":
					uw.mode = "nodes";
					uw.value = Convert.ToString(CModeTraining.trainedValue * 100000);
					break;
				default:
					uw.mode = "movetime";
					uw.value = Convert.ToString(CModeTraining.trainedValue * 100);
					break;
			}
			CPlayer ub = new CPlayer("Teacher");
			ub.engine = CModeTraining.teacher;
			ub.book = CModeTraining.teacherBook;
			switch (CModeTraining.teacherMode)
			{
				case "Blitz":
					ub.mode = "blitz";
					ub.value = Convert.ToString(CModeTraining.teacherValue * 10000);
					break;
				case "Depth":
					ub.mode = "depth";
					ub.value = Convert.ToString(CModeTraining.teacherValue);
					break;
				case "Nodes":
					ub.mode = "nodes";
					ub.value = Convert.ToString(CModeTraining.teacherValue * 100000);
					break;
				default:
					ub.mode = "movetime";
					ub.value = Convert.ToString(CModeTraining.teacherValue * 100);
					break;
			}
			GamerList.gamer[0].SetPlayer(uw);
			GamerList.gamer[1].SetPlayer(ub);
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
				labLast.ForeColor = Color.Red;
				labLast.Text = "Move error " + emo;
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
			labMove.Text = "Move " + moveNumber.ToString() + " " + Chess.g_move50.ToString();
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
					labLast.ForeColor = Color.Lime;
					labLast.Text = uw.name + " win";
					break;
				case (int)CGameState.stalemate:
					labLast.ForeColor = Color.Yellow;
					labLast.Text = "Stalemate";
					break;
				case (int)CGameState.repetition:
					labLast.ForeColor = Color.Yellow;
					labLast.Text = "Threefold repetition";
					break;
				case (int)CGameState.move50:
					labLast.ForeColor = Color.Yellow;
					labLast.Text = "Fifty-move rule";
					break;
				case (int)CGameState.material:
					labLast.ForeColor = Color.Yellow;
					labLast.Text = "Insufficient material";
					break;
			}
			FormLog.This.richTextBox1.AppendText($"Finish {labLast.Text}\n", Color.Gray);
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
						if (--CModeTraining.teacherValue < 1)
							CModeTraining.teacherValue = 1;
					}
					else
					{
						CModeTraining.loose++;
						CModeTraining.teacherValue++;
					}
				}
				else
				{
					CModeTraining.draw++;
					CModeTraining.teacherValue++;
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
			labMove.Text = "Move 1 0";
			labLast.ForeColor = Color.Gainsboro;
			labLast.Text = "Good luck";
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			Chess.InitializeFromFen(CData.fen);
			CHistory.NewGame(Chess.GetFen());
			CBoard.Clear();
			CBoard.Fill();
			GamerList.Init();
			lvMoves.Items.Clear();
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
		}

		public void RenderBoard()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			boardRotate = ((GamerList.gamer[1].engine == null) && (GamerList.gamer[0].engine != null)) ^ CData.rotateBoard;
			if ((GamerList.gamer[1].engine == null) && (GamerList.gamer[0].engine == null))
				boardRotate = !CChess.whiteTurn;
			if (boardRotate)
			{
				labNameT.Text = GamerList.gamer[0].player.name;
				labNameB.Text = GamerList.gamer[1].player.name;
				panTop.BackColor = Color.White;
				panBottom.BackColor = Color.Black;
				labTakenT.ForeColor = Color.White;
				labTakenB.ForeColor = Color.Black;
			}
			else
			{
				labNameT.Text = GamerList.gamer[1].player.name;
				labNameB.Text = GamerList.gamer[0].player.name;
				panTop.BackColor = Color.Black;
				panBottom.BackColor = Color.White;
				labTakenT.ForeColor = Color.Black;
				labTakenB.ForeColor = Color.White;
			}
			if ((boardRotate ^ CChess.whiteTurn) ^ (CData.gameState != 0))
			{
				labTimeT.BackColor = Color.LightGray;
				labTimeB.BackColor = Color.Yellow;
			}
			else
			{
				labTimeT.BackColor = Color.Yellow;
				labTimeB.BackColor = Color.LightGray;
			}
			pictureBox1.Image = new Bitmap(CBoard.bitmap[boardRotate ? 1 : 0]);
			Graphics g = Graphics.FromImage(pictureBox1.Image);
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
				int y2 = CBoard.margin + yr * CBoard.field;
				for (int x = 0; x < 8; x++)
				{
					int i = y * 8 + x;
					int xr = boardRotate ? 7 - x : x;
					int x2 = CBoard.margin + xr * CBoard.field;
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

			sf.Dispose();
			penW.Dispose();
			penB.Dispose();
			brushRed.Dispose();
			brushYellow.Dispose();
			brushW.Dispose();
			brushB.Dispose();
			fontPiece.Dispose();
			g.Dispose();
			pictureBox1.Refresh();
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
				labTimeB.Text = cp.GetTime();
				labEloB.Text = cp.GetElo();
				labProtocolB.Text = cp.GetProtocol();
				labScoreB.Text = $"Score {cp.score}";
				labNodesB.Text = $"Nodes {cp.nodes.ToString("N0")}";
				labNpsB.Text = $"Nps {nps.ToString("N0")}";
				labPonderB.Text = $"Ponder {cp.ponder}";
				labBookB.Text = $"Book {cp.usedBook}";
				if (cp.seldepth != "0")
					labDepthB.Text = $"Depth {cp.depth} / {cp.seldepth}";
				else
					labDepthB.Text = $"Depth {cp.depth}";
			}
			else
			{
				labTimeT.Text = cp.GetTime();
				labEloT.Text = cp.GetElo();
				labProtocolT.Text = cp.GetProtocol();
				labScoreT.Text = $"Score {cp.score}";
				labNodesT.Text = $"Nodes {cp.nodes.ToString("N0")}";
				labNpsT.Text = $"Nps {nps.ToString("N0")}";
				labPonderT.Text = $"Ponder {cp.ponder}";
				labBookT.Text = $"Book {cp.usedBook}";
				if (cp.seldepth != "0")
					labDepthT.Text = $"Depth {cp.depth} / {cp.seldepth}";
				else
					labDepthT.Text = $"Depth {cp.depth}";
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
			mw = $"Material {mw}";
			string mb = (-material).ToString();
			if (-material > 0)
				mb = $"+{mb}";
			mb = $"Material {mb}";
			if (boardRotate)
			{
				labTakenT.Text = w;
				labTakenB.Text = b;
				labMaterialT.Text = mw;
				labMaterialB.Text = mb;
			}
			else
			{
				labTakenT.Text = b;
				labTakenB.Text = w;
				labMaterialT.Text = mb;
				labMaterialB.Text = mw;
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
			labLast.ForeColor = Color.Lime;
			labLast.Text = $"Load fen {Chess.GetFen()}";
			labBack.Text = $"Back {CData.back}";
			lvMoves.Items.Clear();
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

		private void FormChess_FormClosed(object sender, FormClosedEventArgs e)
		{
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
			CBoard.Prepare();
			CBoard.animated = true;
			CArrow.Hide();
			RenderBoard();
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
			labLast.ForeColor = Color.Gainsboro;
			labLast.Text = $"Pgn {CHistory.GetMoves()}";
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
			int x = (e.X - CBoard.margin) / CBoard.field;
			int y = (e.Y - CBoard.margin) / CBoard.field;
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
			if (CModeGame.ranked)
			{
				CPlayer p = CPlayerList.GetPlayerAuto();
				cbEngine.SelectedIndex = cbEngine.FindStringExact(p.engine);
				cbMode.SelectedIndex = cbMode.FindStringExact(p.GetMode());
				cbBook.SelectedIndex = cbBook.FindStringExact(p.book);
				nudValue.Value = Convert.ToInt32(p.value);
			}
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

		private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbComputer.Text != "Auto")
			{
				CModeGame.mode = cbMode.Text;
				nudValue.Value = CModeGame.GetValue(out int increment);
				nudValue.Increment = increment;
			}
		}

		private void nudValue_ValueChanged(object sender, EventArgs e)
		{
			if (cbComputer.Text != "Auto")
				CModeGame.SetValue((int)nudValue.Value);
		}
	}
}
