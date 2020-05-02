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

		public static FormChess This;
		public static bool boardRotate;
		bool isBook = false;
		List<int> moves = new List<int>();
		public CRapIni RapIni = new CRapIni();
		readonly CEcoList EcoList = new CEcoList();
		readonly CChess Chess = new CChess();
		readonly CGamerList GamerList = new CGamerList();
		readonly CUci Uci = new CUci();
		readonly CBoard Board = new CBoard();
		public static PrivateFontCollection pfc = new PrivateFontCollection();
		public static Stopwatch timer = new Stopwatch();
		FormLog formLog = new FormLog();
		FormPgn formPgn = new FormPgn();

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
			if (!CRapIni.This.Exists())
				CreateIni();
			IniLoad();
			FormOptions.This = new FormOptions();
			FormEngine.This = new FormEngine();
			FormBook.This = new FormBook();
			FormPlayer.This = new FormPlayer();
			Reset();
			cbColor.SelectedIndex = cbColor.FindStringExact(CModeGame.color);
			cbComputer.SelectedIndex = cbComputer.FindStringExact(CModeGame.computer);
			Font fontChess = new Font(pfc.Families[0], 16);
			Font fontChessPromo = new Font(pfc.Families[0], 32);
			labTakenT.Font = fontChess;
			labTakenD.Font = fontChess;
			labPromoQ.Font = fontChessPromo;
			labPromoR.Font = fontChessPromo;
			labPromoB.Font = fontChessPromo;
			labPromoN.Font = fontChessPromo;
			Chess.Initialize();
			listView1_Resize(lvPlayer, null);
			listView2_Resize(lvPlayerH, null);
			listView1_Resize(lvEngine, null);
			listView2_Resize(lvEngineH, null);
			lvMoves_Resize(lvMoves, null);
			cbMainMode.SelectedIndex = 0;
			BoardPrepare();
			GameStart();
			toolTip1.Active = FormOptions.ShowTips();
		}

		public static void SetGameState(CGameState gs)
		{
			if (gs == CGameState.normal)
			{
				CData.gameState = CGameState.normal;
				return;
			}
			if (CData.gameState != CGameState.normal)
				return;
			CData.gameState = gs;
			CGamer gw = This.GamerList.GamerWinner();
			CGamer gl = This.GamerList.GamerLoser();
			CPlayer pw = gw.player;
			CPlayer pl = gl.player;
			int eloW = Convert.ToInt32(pw.elo);
			int eloL = Convert.ToInt32(pl.elo);
			bool isDraw = false;
			switch (CData.gameState)
			{
				case CGameState.mate:
					This.tssMoves.ForeColor = Color.Lime;
					This.tssMoves.Text = pw.name + " win";
					break;
				case CGameState.stalemate:
					isDraw = true;
					This.tssMoves.ForeColor = Color.Yellow;
					This.tssMoves.Text = "Stalemate";
					break;
				case CGameState.repetition:
					isDraw = true;
					This.tssMoves.ForeColor = Color.Yellow;
					This.tssMoves.Text = "Threefold repetition";
					break;
				case CGameState.move50:
					isDraw = true;
					This.tssMoves.ForeColor = Color.Yellow;
					This.tssMoves.Text = "Fifty-move rule";
					break;
				case CGameState.material:
					isDraw = true;
					This.tssMoves.ForeColor = Color.Yellow;
					This.tssMoves.Text = "Insufficient material";
					break;
				case CGameState.resignation:
					This.tssMoves.ForeColor = Color.Yellow;
					This.tssMoves.Text = $"{pl.name} resign";
					break;
				case CGameState.time:
					This.tssMoves.ForeColor = Color.Red;
					This.tssMoves.Text = $"{pl.name}Time out";
					break;
				case CGameState.error:
					This.tssMoves.ForeColor = Color.Red;
					This.tssMoves.Text = $"{pl.name} make Wrong move";
					break;
			}
			FormLog.This.richTextBox1.AppendText($"Finish {This.tssMoves.Text}\n", Color.Gray);
			if (CData.gameState != CGameState.error)
			{
				This.CreateRtf();
				This.CreatePgn();
			}
			if (CData.gameMode == CMode.game)
			{
				if (This.IsAutoElo())
					if (pw.name == "Human")
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
				This.ShowLastGame();
			}
			if (CData.gameMode == CMode.match)
			{
				CModeMatch.games++;
				if (!isDraw)
				{
					if (pw.name == This.labMatch10.Text)
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
				This.MatchShow();
			}
			if (CData.gameMode == CMode.tourE)
			{
				CEngine ew = gw.engine;
				CEngine el = gl.engine;
				eloW = Convert.ToInt32(gw.engine.elo);
				eloL = Convert.ToInt32(gl.engine.elo);
				int indexW = CEngineList.GetIndexElo(eloW);
				int indexL = CEngineList.GetIndexElo(eloL);
				int optW = CEngineList.GetOptElo(indexW);
				int optL = CEngineList.GetOptElo(indexL);
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
						OW = CEngineList.GetOptElo(indexW + 1);
					string r = pw == This.GamerList.gamer[0].player ? "w" : "b";
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
				ew.elo = newW.ToString();
				el.elo = newL.ToString();
				ew.eloOld = pw.eloOld * .9 + newW * .1;
				el.eloOld = pl.eloOld * .9 + newL * .1; ;
				ew.SaveToIni();
				el.SaveToIni();
				CModeTournamentE.rotate = (OW != OL) && (newW < newL);
			}
			if (CData.gameMode == CMode.tourP)
			{
				int indexW = CPlayerList.GetIndexElo(eloW);
				int indexL = CPlayerList.GetIndexElo(eloL);
				int optW = CPlayerList.GetOptElo(indexW);
				int optL = CPlayerList.GetOptElo(indexL);
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
						OW = CEngineList.GetOptElo(indexW + 1);
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
				pw.elo = newW.ToString();
				pl.elo = newL.ToString();
				pw.eloOld = pw.eloOld * .9 + newW * .1;
				pl.eloOld = pl.eloOld * .9 + newL * .1; ;
				pw.SaveToIni();
				pl.SaveToIni();
				CModeTournamentP.rotate = (OW != OL) && (newW < newL);
			}
			if (CData.gameMode == CMode.training)
			{
				CModeTraining.games++;
				if (!isDraw)
				{
					if (pw.name == "Teacher")
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
					CRapLog.Add($"Training time {pl.name} {CChess.whiteTurn}");
				if ((gl.player.name == "Trained") && ((CData.gameState == CGameState.time) || (CData.gameState == CGameState.error) || gl.timeOut))
					CModeTraining.errors++;
				This.TrainingShow();
			}
			This.timerStart.Start();
		}

		void SplitSaveToIni(SplitContainer sc)
		{
			int size = sc.Orientation == Orientation.Horizontal ? sc.ClientSize.Height : sc.ClientSize.Width;
			double p = (double)sc.SplitterDistance / size;
			RapIni.Write($"position>split>{sc.Name}", p.ToString());
		}

		void SplitLoadFromIni(SplitContainer sc)
		{
			int size = sc.Orientation == Orientation.Horizontal ? sc.ClientSize.Height : sc.ClientSize.Width;
			double p = (double)sc.SplitterDistance / size;
			p = RapIni.ReadDouble($"position>split>{sc.Name}", p) * size;
			if (p > 0)
				sc.SplitterDistance = Convert.ToInt32(p);
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
			SplitSaveToIni(splitContainerMain);
			SplitSaveToIni(splitContainerBoard);
			SplitSaveToIni(splitContainerChart);
			SplitSaveToIni(splitContainerTourE);
			SplitSaveToIni(splitContainerTourP);
			GamerList.Terminate();

		}

		void CreateIni()
		{
			CEngineList.LoadFromIni();
			CEngine e;
			e = new CEngine(CEngineList.def);
			e.file = "RapChessCs.exe";
			e.elo = "1100";
			CEngineList.Add(e);
			e = new CEngine("RapSimple CS");
			e.file = "RapSimpleCs.exe";
			e.elo = "1000";
			CEngineList.Add(e);
			e = new CEngine("RapShort CS");
			e.file = "RapShortCs.exe";
			e.elo = "900";
			CEngineList.Add(e);
			CEngineList.SaveToIni();
			CBookList.LoadFromIni();
			CBook b;
			b = new CBook("Eco");
			b.file = "BookReaderUci.exe";
			b.parameters = "eco.uci";
			CBookList.Add(b);
			b = new CBook("Tiny");
			b.file = "BookReaderUci.exe";
			b.parameters = "tiny.uci";
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
			p.modeValue.value = 0;
			CPlayerList.Add(p);
			p = new CPlayer();
			p.engine = "RapChess CS";
			p.book = "Rand90";
			p.modeValue.mode = "Time";
			p.modeValue.value = 10;
			p.elo = "200";
			CPlayerList.Add(p);
			p = new CPlayer();
			p.engine = "RapChess CS";
			p.book = "Rand70";
			p.modeValue.mode = "Time";
			p.modeValue.value = 10;
			p.elo = "400";
			CPlayerList.Add(p);
			p = new CPlayer();
			p.engine = "RapChess CS";
			p.book = "Rand50";
			p.modeValue.mode = "Time";
			p.modeValue.value = 10;
			p.elo = "600";
			CPlayerList.Add(p);
			p = new CPlayer();
			p.engine = "RapChess CS";
			p.book = "Rand30";
			p.modeValue.mode = "Time";
			p.modeValue.value = 10;
			p.elo = "800";
			CPlayerList.Add(p);
			p = new CPlayer();
			p.engine = "RapChess CS";
			p.book = "Rand10";
			p.modeValue.mode = "Time";
			p.modeValue.value = 10;
			p.elo = "1000";
			CPlayerList.Add(p);
			p = new CPlayer();
			p.engine = "RapShort CS";
			p.book = "Eco";
			p.modeValue.mode = "Time";
			p.modeValue.value = 10;
			p.elo = "500";
			CPlayerList.Add(p);
			p = new CPlayer();
			p.engine = "RapSimple CS";
			p.book = "Eco";
			p.modeValue.mode = "Time";
			p.modeValue.value = 10;
			p.elo = "1000";
			CPlayerList.Add(p);
			p = new CPlayer();
			p.engine = "RapChess CS";
			p.book = "Eco";
			p.modeValue.mode = "Time";
			p.modeValue.value = 10;
			p.elo = "1200";
			CPlayerList.Add(p);
			CPlayerList.SaveToIni();
		}

		void IniLoad()
		{
			Width = RapIni.ReadInt("position>width", Width);
			Height = RapIni.ReadInt("position>height", Height);
			if (Width < 600)
				Width = 600;
			if (Height < 400)
				Height = 400;
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
			CEngineList.LoadFromIni();
			CBookList.LoadFromIni();
			CPlayerList.LoadFromIni();
			CModeGame.LoadFromIni();
			CModeMatch.LoadFromIni();
			CModeTournamentE.LoadFromIni();
			CModeTournamentP.LoadFromIni();
			CModeTraining.LoadFromIni();
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
				pc.modeValue.mode = CModeGame.modeValue.mode;
				pc.modeValue.value = CModeGame.modeValue.value;
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
			int elo = Convert.ToInt32(uh.elo);
			uh.eloNew = elo;
			uh.eloOld = elo;
			CModeGame.SaveToIni();
		}

		void GameShow()
		{
			ShowAutoElo();
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

		void TournamentEShow()
		{
			cbTourEMode.SelectedIndex = cbTourEMode.FindStringExact(CModeTournamentE.modeValue.mode);
			cbTourEBook.SelectedIndex = cbTourEBook.FindStringExact(CModeTournamentE.book);
		}

		void TournamentEReset()
		{
			lvEngine.Items.Clear();
			foreach (CEngine e in CEngineList.list)
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
				CGamer g1 = GamerList.gamer[1];
				CGamer g2 = GamerList.gamer[0];
				p1 = g1.player;
				p2 = g2.player;
				e1 = g1.engine;
				e2 = g2.engine;
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
			p1.book = e1.protocol == "Uci" ? CModeTournamentE.book : "None";
			p1.modeValue.mode = CModeTournamentE.modeValue.mode;
			p1.modeValue.value = CModeTournamentE.modeValue.value;
			p2.book = e2.protocol == "Uci" ? CModeTournamentE.book : "None";
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

		void TournamentPReset()
		{
			lvPlayer.Items.Clear();
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

		public void BoardPrepare()
		{
			SetBoardRotate();
			CBoard.Resize(panBoard.Width, panBoard.Height);
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
						CChess.EmoToSD(emo, out int sou, out int des);
						CArrow.SetAB(sou, des);
						RenderBoard();
					}
					Chess.MakeMove(gmo);
					moves.Add(gmo);
					pv += $" {emo}";
				}
				else break;
			}
			for (int n = moves.Count - 1; n >= 0; n--)
				Chess.UnmakeMove(moves[n]);
			if (pv != "")
				g.pv = pv;
			tssMoves.Text = pv;
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
				case "bestmove":
					g.ponder = Uci.GetValue("ponder");
					emo = Uci.tokens[1];
					if (isBook)
						AddBook(emo);
					MakeMove(emo);
					break;
				case "info":
					ulong nps = 0;
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
					SetGameState(CGameState.resignation);
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
						SetGameState(CGameState.resignation);
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

		public string GetTimeElapsed()
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(timer.Elapsed.TotalMilliseconds);
			return dt.ToString("HH:mm:ss.fff");
		}

		public void GetMessage()
		{
			while(CMessageList.MessageGet(out CMessage m))
			{
				CGamer gamer = GamerList.GetGamerPid(m.pid);
				if (gamer == null)
					CRapLog.Add($"Unknown pid ({m.msg})");
				else
				{
					FormLog.This.richTextBox1.AppendText($"{GetTimeElapsed()} ", Color.Green);
					if (gamer.white)
					{
						FormLog.This.richTextBox1.AppendText($"{gamer.player.name}", Color.DimGray);
						FormLog.This.richTextBox1.AppendText($" > {m.msg}\n");
					}
					else
						FormLog.This.richTextBox1.AppendText($"{gamer.player.name} > {m.msg}\n");
					if (gamer.engine.protocol == "Uci")
						GetMessageUci(gamer, m.msg);
					if (gamer.engine.protocol == "Winboard")
						GetMessageXb(gamer, m.msg);
				}
			}
		}

		void CreateRtf()
		{
			FormLog.This.richTextBox1.SaveFile($"{cbMainMode.Text}.rtf");
		}

		void CreatePgn()
		{
			List<string> list = new List<string>();
			string result = "1/2-1/2";
			if (CData.gameState == CGameState.mate)
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
			list.Add(CHistory.GetPgn());
			foreach (String s in list)
				FormPgn.This.textBox1.Text += $"{s}\r\n";
			File.WriteAllText($"{cbMainMode.Text}.pgn", FormPgn.This.textBox1.Text);
		}

		public void AddBook(string emo)
		{
			isBook = false;
			GamerList.GamerCur().usedBook++;
			tssMoves.ForeColor = Color.Aquamarine;
			tssMoves.Text = $"book {emo}";
		}

		void SetMode(CMode mode)
		{
			timer1.Enabled = false;
			timerStart.Enabled = false;
			GamerList.Terminate();
			CData.gameMode = mode;
			Clear();
			switch (mode)
			{
				case CMode.game:
					GameShow();
					break;
				case CMode.match:
					MatchShow();
					break;
				case CMode.tourE:
					TournamentEShow();
					break;
				case CMode.training:
					TrainingShow();
					break;
				case CMode.edit:
					EditShow();
					break;
			}
		}

		bool IsAutoElo()
		{
			return (cbComputer.Text == "Auto") && FormOptions.This.cbGameAutoElo.Checked && (CData.gameMode == (int)CMode.game);
		}


		void ShowAuto(bool first = false)
		{
			if (CModeGame.ranked || first)
			{
				CPlayer p = CPlayerList.GetPlayerAuto();
				cbEngine.SelectedIndex = cbEngine.FindStringExact(p.engine);
				cbMode.SelectedIndex = cbMode.FindStringExact(p.modeValue.mode);
				cbBook.SelectedIndex = cbBook.FindStringExact(p.book);
				nudValue.Value = p.modeValue.GetValue();
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
			int eloDel = hu.eloNew - eloCur;
			if (hu.eloNew > eloCur)
			{
				result = true;
				tssMoves.ForeColor = Color.FromArgb(0, 0xff, 0);
				tssMoves.Text = $"Last game you win new elo is {hu.eloNew} (+{eloDel})";
				CRapLog.Add(tssMoves.Text);
			}
			if (hu.eloNew < eloCur)
			{
				result = true;
				tssMoves.ForeColor = Color.FromArgb(0xff, 0, 0);
				tssMoves.Text = $"Last game you loose new elo is {hu.eloNew} ({eloDel})";
				CRapLog.Add(tssMoves.Text);
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
			CEngine engine = CEngineList.GetEngine(name);
			labEngine.Text = $"{engine.name} - {engine.elo}";
			lvEngineH.Items.Clear();
			CEngineList.Sort();
			CEngineList.FillPosition();
			foreach (CEngine e in CEngineList.list)
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
		}

		void ShowHistoryTourP()
		{
			if (lvPlayer.SelectedItems.Count == 0)
				return;
			ListViewItem top2 = null;
			ListViewItem item = lvPlayer.SelectedItems[0];
			string name = item.SubItems[0].Text;
			CPlayer player = CPlayerList.GetPlayerAuto(name);
			labPlayer.Text = $"{player.name} - {player.elo}";
			lvPlayerH.Items.Clear();
			CPlayerList.Sort();
			CPlayerList.FillPosition();
			foreach (CPlayer p in CPlayerList.list)
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
			foreach (CBook b in CBookList.list)
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
		}

		public bool MakeMove(string emo)
		{
			if (CData.gameState != CGameState.normal)
				return false;
			CArrow.Hide();
			CGamer cg = GamerList.GamerCur();
			CPlayer cp = cg.player;
			cg.timer.Stop();
			emo = emo.ToLower();
			double m = GamerList.curIndex == 0 ? 0.01 : -0.01;
			chart1.Series[GamerList.curIndex].Points.Add(cg.iScore * m);
			cg.iScore = 0;
			if (IsAutoElo() && CModeGame.ranked && (cg.engine == null) && ((CChess.g_moveNumber >> 1) == 4))
			{
				cg.player.eloOld = Convert.ToDouble(cg.player.elo);
				cg.player.eloNew = cg.player.GetEloLess();
				cg.player.SaveToIni();
			}
			bool ivm = Chess.IsValidMove(emo) != 0;
			if (!ivm)
			{
				List<int> gMoves = Chess.GenerateValidMoves();
				List<string> eMoves = new List<string>();
				foreach (int gm in gMoves)
					eMoves.Add(Chess.FormatMove(gm));
				FormLog.This.richTextBox1.AppendText($"Wrong move {emo}\n", Color.Red);
				FormLog.This.richTextBox1.AppendText($"{Chess.GetFen()}\n");
				FormLog.This.richTextBox1.AppendText($"{string.Join(" ", eMoves)}\n");
				FormLog.This.richTextBox1.SaveFile("Error.rtf");
				CRapLog.Add($"Wrong move {cp.engine} {emo} {Chess.GetFen()}");
				SetGameState(CGameState.error);
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
			int moveNumber = (CChess.g_moveNumber >> 1) + 1;
			tssMove.Text = "Move " + moveNumber.ToString() + " " + Chess.g_move50.ToString();
			SetGameState(Chess.GetGameState());
			if (CData.gameState == CGameState.normal)
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
			return true;
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
			SetBoardRotate();
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			Chess.InitializeFromFen(CData.fen);
			CHistory.NewGame(Chess.GetFen());
			CBoard.ColorClear();
			CBoard.Fill();
			GamerList.Init();
			lvMoves.Items.Clear();
			lvMovesW.Items.Clear();
			lvMovesB.Items.Clear();
			CData.back = 0;
			CGamer pw = GamerList.gamer[0];
			CGamer pb = GamerList.gamer[1];
			FormLog.This.richTextBox1.Clear();
			FormLog.This.richTextBox1.AppendText($"Time {DateTime.Now.ToString("yyyy-MM-dd HH:mm")}\n", Color.Gray);
			if (pw.engine != null)
				FormLog.This.richTextBox1.AppendText($"White {pw.player.name} {pw.player.engine} {pw.engine.parameters}\n", Color.Gray);
			if (pb.engine != null)
				FormLog.This.richTextBox1.AppendText($"Black {pb.player.name} {pb.player.engine} {pb.engine.parameters}\n", Color.Gray);
			labBack.Text = $"Back {CData.back}";
			CData.gameState = (int)CGameState.normal;
			RenderInfo(pw);
			RenderInfo(pb);
			CArrow.Hide();
			CMessageList.Clear();
			timer1.Enabled = CData.gameMode != CMode.edit;
			ShowGamers();
			timer.Restart();
		}

		void SetBoardRotate()
		{
			boardRotate = ((GamerList.gamer[1].engine == null) && (GamerList.gamer[0].engine != null)) ^ CData.rotateBoard;
			if ((GamerList.gamer[1].engine == null) && (GamerList.gamer[0].engine == null))
				boardRotate = !CChess.whiteTurn;
		}

		public void RenderBoard()
		{
			if ((GamerList.gamer[0].player == null) || (GamerList.gamer[1].player == null))
				return;
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
			if (CBoard.animated || CDrag.dragged)
				CBoard.RenderBoard();
			if (CBoard.animated)
				CBoard.finished = false;
			CBoard.UpdatePosition();
			if (!CBoard.animated && !CBoard.finished)
			{
				CBoard.finished = true;
				if (!tlpPromotion.Visible)
				{
					CBoard.Fill();
					RenderTaken();
				}
			}
			Graphics pg = panBoard.CreateGraphics();
			CBoard.RenderArrow(pg);
			pg.Dispose();
			stopwatch.Stop();
			CData.fps = CData.fps * 0.9 + 100 / stopwatch.ElapsedMilliseconds;
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
			CModeGame.ranked = false;
			SetMode((int)CMode.game);
			if (!Chess.InitializeFromFen(fen))
			{
				MessageBox.Show("Wrong fen");
				return;
			}
			GamerList.curIndex = CChess.g_moveNumber & 1;
			GamePrepare();
			int w = CChess.whiteTurn ? 0 : 1;
			if (!GamerList.gamer[w].IsHuman())
				GamerList.Rotate();
			GamerList.gamer[0].Init(true);
			GamerList.gamer[1].Init(false);
			cbColor.SelectedIndex = GamerList.curIndex + 1;
			SetBoardRotate();
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
			CData.gameState = CGameState.normal;
			RenderInfo(pw);
			RenderInfo(pb);
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
			bool result = Chess.IsValidMove(s, d, out string emo, out bool promo);
			if (result)
				if (promo)
				{
					CPromotion.emo = emo;
					CPromotion.sou = s;
					CPromotion.des = d;
					CBoard.MakeMove(s,d);
					CBoard.RenderBoard();
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
			CBoard.ColorClear();
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

		private void Timer1_Tick_1(object sender, EventArgs e)
		{
			GetMessage();
			if (CBoard.animated || CDrag.dragged)
			{
				RenderBoard();
			}
			else
			{
				CGamer cg = GamerList.GamerCur();
				CGamer sg = GamerList.GamerSec();
				RenderInfo(cg);
				RenderInfo(sg);
				if (cg.engine != null)
				{
					if (!cg.started)
						cg.Start();
					else if (cg.readyok && !cg.go)
						cg.CompMakeMove();
				}
				else
					cg.go = true;
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
			CArrow.Hide();
			BoardPrepare();
			ShowAutoElo();
			toolTip1.Active = FormOptions.ShowTips();
		}

		private void ButTraining_Click(object sender, EventArgs e)
		{
			CModeTraining.Reset();
			TraingStart();
		}

		private void TimerStart_Tick(object sender, EventArgs e)
		{
			timerStart.Stop();
			switch (CData.gameMode)
			{
				case CMode.match:
					MatchStart();
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
			GamerList.curIndex = CChess.g_moveNumber & 1;
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
			CData.gameState = CGameState.normal;
			RenderInfo(pw);
			RenderInfo(pb);
			moves = Chess.GenerateValidMoves();
			timer1.Enabled = true;
		}

		private void bStartMatch_Click(object sender, EventArgs e)
		{
			CModeMatch.Reset();
			MatchStart();
		}

		private void butStartTournament_Click(object sender, EventArgs e)
		{
			TournamentPStart();
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
			ShowHistoryTourP();
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
			FormPgn.This.textBox1.Text = "";
			tabControl1.SelectedIndex = cbMainMode.SelectedIndex;
			CData.fen = Chess.GetFen();
			CBoard.Fill();
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
			CPlayer hu = CPlayerList.GetPlayerAuto("Human");
			hu.eloNew = hu.GetEloLess();
			GameStart();
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
			CBoard.MakeMove(CPromotion.des,CPromotion.sou);
			MakeMove(CPromotion.emo + (sender as Label).Text);
			tlpPromotion.Hide();
		}

		private void enginesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			formLog.Focus();
			formLog.Show();
		}

		private void gamesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			formPgn.Focus();
			formPgn.Show();
		}
	}
}
