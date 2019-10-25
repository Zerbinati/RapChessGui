using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace RapChessGui
{
	public partial class FormChess : Form
	{
		[DllImport("user32.dll")]
		private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);

		[DllImport("gdi32.dll")]
		private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

		public static FormChess This;
		bool boardRotate;
		int level = 1000;
		int levelOrg = 1000;
		int levelDif = 10;
		CEngine Engine = new CEngine();
		CPlayerList PlayerList = new CPlayerList();
		CMatch Match = new CMatch();
		CTrainer Trainer = new CTrainer();
		CUci Uci = new CUci();
		FormOptions FOptions = new FormOptions();
		FormPlayer FPlayer = new FormPlayer();
		PrivateFontCollection pfc = new PrivateFontCollection();
		Font fontChess;

		public FormChess()
		{
			KillApplication();
			InitializeComponent();
			This = this;
			richTextBox1.AddContextMenu();
			FormBook.This = new FormBook();
			FormLog.This = new FormLog();
			Reset();
			IniLoad();
			CPieceBoard.Prepare();
			pictureBox1.Size = new Size(CPieceBoard.size, CPieceBoard.size);
		}

		private void FormChess_Load(object sender, EventArgs e)
		{
			int fontLength = Properties.Resources.ChessPiece.Length;
			byte[] fontData = Properties.Resources.ChessPiece;
			System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
			Marshal.Copy(fontData, 0, data, fontLength);
			uint cFonts = 0;
			AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);
			pfc.AddMemoryFont(data, fontLength);
			Marshal.FreeCoTaskMem(data);
			fontChess = new Font(pfc.Families[0], 16);
			labTakenT.Font = fontChess;
			labTakenB.Font = fontChess;
			ShowMatch();
			ShowTraining();
			Engine.Initialize();
			StartGame();
		}

		void IniLoad()
		{
			cbColor.SelectedIndex = cbColor.FindStringExact(CIniFile.Read("color", "White"));
			cbComputer.SelectedIndex = cbComputer.FindStringExact(CIniFile.Read("black", "Computer"));
			cbPlayer1.SelectedIndex = cbPlayer1.FindStringExact(CIniFile.Read("player1", "Computer"));
			cbPlayer2.SelectedIndex = cbPlayer2.FindStringExact(CIniFile.Read("player2", "Computer"));
			comboBoxTrained.SelectedIndex = comboBoxTrained.FindStringExact(CIniFile.Read("trained", "Computer"));
			comboBoxTeacher.SelectedIndex = comboBoxTeacher.FindStringExact(CIniFile.Read("teacher", "RapChessCs.exe"));
			nudTeacher.Value = Convert.ToInt32(CIniFile.Read("timeTeacher", "1000"));
			nudTrained.Value = Convert.ToInt32(CIniFile.Read("timeTrained", "1000"));
			level = Convert.ToInt32(CIniFile.Read("level", "1000"));
			Trainer.time = (int)nudTeacher.Value;
			CPieceBoard.LoadFromIni();

		}

		void IniSave()
		{
			CIniFile.Write("color", cbColor.Text);
			CIniFile.Write("black", cbComputer.Text);
			CIniFile.Write("player1", cbPlayer1.Text);
			CIniFile.Write("player2", cbPlayer2.Text);
			CIniFile.Write("trained", comboBoxTrained.Text);
			CIniFile.Write("teacher", comboBoxTeacher.Text);
			CIniFile.Write("timeTeacher", nudTeacher.Value.ToString());
			CIniFile.Write("timeTrained", nudTrained.Value.ToString());
			CIniFile.Write("level", level.ToString());
			CPieceBoard.SaveToIni();
		}

		public void GetMessage(CPlayer p)
		{
			string msg = p.GetMessage();
			if (msg == "")
				return;
			Uci.SetMsg(msg);
			switch (Uci.command)
			{
				case "uciok":
					p.uciok = true;
					p.SendMessage("ucinewgame");
					p.SendMessage("isready");
					break;
				case "readyok":
					p.readyok = true;
					break;
				case "bestmove":
					p.ponder = Uci.GetValue("ponder");
					string em = Uci.tokens[1];
					if (Uci.GetIndex("book", 0) > 0)
						AddBook(em);
					MakeMove(em);
					break;
				case "info":
					labLast.ForeColor = Color.Gainsboro;
					string s = Uci.GetValue("cp");
					if (s != "")
						p.score = s;
					s = Uci.GetValue("mate");
					if (s != "")
					{
						if (Int32.Parse(s) > 0)
							p.score = $"+{s}M";
						else
							p.score = $"{s}M";
					}
					s = Uci.GetValue("depth");
					if (s != "")
						p.depth = s;
					s = Uci.GetValue("seldepth");
					if (s != "")
						p.seldepth = s;
					s = Uci.GetValue("nps");
					if (s != "")
						p.nps = s;
					string pv = "";
					int i = Uci.GetIndex("pv", 0);
					if (i > 0)
					{
						for (int n = i; n < Uci.tokens.Length; n++)
							pv += Uci.tokens[n] + " ";
						labLast.Text = pv;
					}
					break;
			}
		}

		void KillApplication()
		{
			Process cp = Process.GetCurrentProcess();
			string fn = cp.MainModule.FileName;
			Process[] processlist = Process.GetProcesses();
			foreach (Process process in processlist)
			{
				try
				{
					String fileName = process.MainModule.FileName;
					if (fileName == fn)
						if (process.MainWindowHandle != cp.MainWindowHandle)
						{
							ShowWindow(process.MainWindowHandle, 9);
							SetForegroundWindow(process.MainWindowHandle);
							cp.Kill();
						}
				}
				catch
				{
				}

			}
		}

		public void AddBook(string emo)
		{
			labBook.Text = $"Book {++CData.book}";
			labLast.ForeColor = Color.Aquamarine;
			labLast.Text = $"book {emo}";
		}

		void SetMode(CMode mode)
		{
			CData.KillProcess();
			CData.gameMode = (int)mode;
			lock (CData.messages)
				CData.messages.Clear();
		}

		void ShowMatch()
		{
			labMatchGames.Text = $"Games {Match.games}";
			labMatch10.Text = cbPlayer1.Text;
			labMatch11.Text = Match.win.ToString();
			labMatch12.Text = Match.loose.ToString();
			labMatch13.Text = Match.draw.ToString();
			labMatch14.Text = $"{Match.Result(false)}%";
			labMatch20.Text = cbPlayer2.Text;
			labMatch21.Text = Match.loose.ToString();
			labMatch22.Text = Match.win.ToString();
			labMatch23.Text = Match.draw.ToString();
			labMatch24.Text = $"{Match.Result(true)}%";
		}

		void ShowTraining()
		{
			labGames.Text = $"Games {Trainer.games}";
			nudTeacher.Value = Trainer.time;
			label12.Text = Trainer.win.ToString();
			label13.Text = Trainer.loose.ToString();
			label14.Text = Trainer.draw.ToString();
			label15.Text = $"{Trainer.Result(false)}%";
			label7.Text = Trainer.loose.ToString();
			label8.Text = Trainer.win.ToString();
			label9.Text = Trainer.draw.ToString();
			label10.Text = $"{Trainer.Result(true)}%";
		}

		void Reset()
		{
			cbComputer.Items.Clear();
			cbPlayer1.Items.Clear();
			cbPlayer2.Items.Clear();
			comboBoxTrained.Items.Clear();
			comboBoxTeacher.Items.Clear();
			for (int n = 0; n < CUserList.list.Count; n++)
			{
				CUser u = CUserList.list[n];
				cbComputer.Items.Add(u.name);
				cbPlayer1.Items.Add(u.name);
				cbPlayer2.Items.Add(u.name);
				comboBoxTrained.Items.Add(u.name);
			}
			foreach (string en in CData.engineNames)
				comboBoxTeacher.Items.Add(en);
			FormBook.This.cbBookList.Items.Clear();
			foreach (string b in CData.bookNames)
				FormBook.This.cbBookList.Items.Add(b);
			FormBook.This.cbBookList.SelectedIndex = 0;
		}

		public bool MakeMove(string emo)
		{
			emo = emo.ToLower();
			string cpName = PlayerList.CurPlayer().user.name;
			if ((CData.gameMode == (int)CMode.game) && (cpName == "Human") && (PlayerList.SecPlayer().user.name != "Human") && (PlayerList.SecPlayer().user.mode == "movetime") && ((Engine.g_moveNumber >> 1) == 10))
			{
				level = levelOrg - levelDif;
				if (level < 0)
					level = 0;
				CIniFile.Write("level", level.ToString());
			}
			if (Engine.IsValidMove(emo) == 0)
			{
				labLast.ForeColor = Color.Red;
				labLast.Text = "Move error " + emo;
				FormLog.This.richTextBox1.AppendText($" error {emo}\n", Color.Red);
				FormLog.This.richTextBox1.SaveFile("last error.rtf");
				return false;
			}
			double t = (DateTime.Now - PlayerList.CurPlayer().timeStart).TotalMilliseconds;
			PlayerList.CurPlayer().timeTotal += t;
			int gm = Engine.GetMoveFromString(emo);
			CPieceBoard.MakeMove(gm);
			Engine.MakeMove(gm);
			int moveNumber = (Engine.g_moveNumber >> 1) + 1;
			labMove.Text = "Move " + moveNumber.ToString() + " " + Engine.g_move50.ToString();
			CHistory.moves.Add(emo);
			ShowHistory();
			CData.gameState = Engine.GetGameState();
			if (CData.gameState == 0)
				PlayerList.Next();
			else
			{
				switch (CData.gameState)
				{
					case (int)CGameState.mate:
						labLast.ForeColor = Color.Lime;
						labLast.Text = cpName + " win";
						break;
					case (int)CGameState.drawn:
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
				if (CData.gameMode == (int)CMode.game)
				{
					if (CData.gameState == (int)CGameState.mate)
					{
						if (cpName == "Human")
						{
							level = levelOrg + levelDif;
							CIniFile.Write("level", level.ToString());
						}
					}
				}
				if (CData.gameMode == (int)CMode.match)
				{
					Match.games++;
					if (CData.gameState == (int)CGameState.mate)
					{
						if (cpName == labMatch10.Text)
						{
							Match.win++;
						}
						else
						{
							Match.loose++;
						}
					}
					else
					{
						Match.draw++;
					}
					ShowMatch();
				}
				if (CData.gameMode == (int)CMode.training)
				{
					Trainer.games++;
					if (CData.gameState == (int)CGameState.mate)
					{
						if (cpName == "Teacher")
						{
							Trainer.win++;
							Trainer.time -= 100;
							if (Trainer.time < 100)
								Trainer.time = 100;
						}
						else
						{
							Trainer.loose++;
							Trainer.time += 100;
						}
					}
					else
					{
						Trainer.draw++;
						Trainer.time += 100;
					}
					ShowTraining();
				}
				FormLog.This.richTextBox1.SaveFile("last game.rtf");
				timerStart.Start();
			}
			return true;
		}

		void Clear()
		{
			levelOrg = level;
			labMove.Text = "Move 1 0";
			labLast.ForeColor = Color.Gainsboro;
			labLast.Text = "Good luck";
			CDrag.index = -1;
			Engine.InitializeFromFen();
			CData.gameState = 0;
			CHistory.NewGame(Engine.GetFen());
			CPieceBoard.Fill();
			PlayerList.NewGame();
			timer1.Enabled = true;
			CPlayer pw = PlayerList.player[0];
			CPlayer pb = PlayerList.player[1];
			richTextBox1.Clear();
			CData.back = 0;
			CData.book = 0;
			FormLog.This.richTextBox1.Clear();
			FormLog.This.richTextBox1.AppendText($"White {pw.user.name} {pw.user.engine} {pw.user.parameters}\n");
			FormLog.This.richTextBox1.AppendText($"Black {pb.user.name} {pb.user.engine} {pb.user.parameters}\n");
			labBack.Text = $"Back {CData.back}";
			labBook.Text = $"Book {CData.book}";
			RenderInfo(pw);
			RenderInfo(pb);
		}

		void StartGame()
		{
			levelDif = Convert.ToInt32(level * 0.1);
			if (levelDif < 10)
				levelDif = 10;
			SetMode(CMode.game);
			PlayerList.player[0].SetUser("Human");
			CUser u = new CUser(cbComputer.Text);
			u.SetUser(cbComputer.Text);
			u.SetCommand(cbCommand.Text);
			if (u.mode == "movetime")
				u.value = level.ToString();
			cbCommand.Text = u.GetCommand();
			PlayerList.player[1].SetUser(u);
			if (cbColor.Text != "White")
				PlayerList.Rotate();
			Clear();
		}

		void StartMatch()
		{
			SetMode(CMode.match);
			ShowMatch();
			PlayerList.player[0].SetUser(cbPlayer1.Text);
			PlayerList.player[1].SetUser(cbPlayer2.Text);
			if (Match.rotate == 1)
				PlayerList.Rotate();
			Match.rotate ^= 1;
			Clear();
		}

		void StartTraing()
		{
			SetMode(CMode.training);
			ShowTraining();
			CUser uw = new CUser("Trained");
			uw.SetUser(comboBoxTrained.Text);
			uw.mode = "movetime";
			uw.value = nudTrained.Value.ToString();
			CUser ub = new CUser("Teacher");
			ub.engine = comboBoxTeacher.Text;
			ub.mode = "movetime";
			ub.value = nudTeacher.Value.ToString();
			PlayerList.player[0].SetUser(uw);
			PlayerList.player[1].SetUser(ub);
			if (Trainer.rotate == 1)
				PlayerList.Rotate();
			Trainer.rotate ^= 1;
			Clear();
		}

		public void RenderBoard()
		{
			string abc = "ABCDEFGH";
			boardRotate = (!PlayerList.player[1].computer && PlayerList.player[0].computer) ^ CData.rotateBoard;
			if (!PlayerList.player[1].computer && !PlayerList.player[0].computer)
				boardRotate = !Engine.whiteTurn;
			if (boardRotate)
			{
				labNameT.Text = PlayerList.player[0].user.name;
				labNameB.Text = PlayerList.player[1].user.name;
				panTop.BackColor = Color.White;
				panBottom.BackColor = Color.Black;
				labTakenT.ForeColor = Color.White;
				labTakenB.ForeColor = Color.Black;
			}
			else
			{
				labNameT.Text = PlayerList.player[1].user.name;
				labNameB.Text = PlayerList.player[0].user.name;
				panTop.BackColor = Color.Black;
				panBottom.BackColor = Color.White;
				labTakenT.ForeColor = Color.Black;
				labTakenB.ForeColor = Color.White;
			}
			if (boardRotate ^ Engine.whiteTurn)
			{
				labTimeT.BackColor = Color.LightGray;
				labTimeB.BackColor = Color.Yellow;
			}
			else
			{
				labTimeT.BackColor = Color.Yellow;
				labTimeB.BackColor = Color.LightGray;
			}
			pictureBox1.Image = new Bitmap(CPieceBoard.bitmap);
			Graphics g = Graphics.FromImage(pictureBox1.Image);
			Brush brush3 = new SolidBrush(Color.FromArgb(0x80, 0xff, 0xff, 0x00));
			Font font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
			Font fontPiece = new Font(pfc.Families[0], CPieceBoard.field);
			Brush foreBrush = new SolidBrush(Color.White);
			Brush brushW = new SolidBrush(Color.White);
			Brush brushB = new SolidBrush(Color.Black);
			Pen outline = new Pen(Color.Black, 4);
			Pen penW = new Pen(Color.Black, 4);
			Pen penB = new Pen(Color.White, 4);
			GraphicsPath gp = new GraphicsPath();
			GraphicsPath gpW = new GraphicsPath();
			GraphicsPath gpB = new GraphicsPath();
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			g.SmoothingMode = SmoothingMode.HighQuality;
			Rectangle rec = new Rectangle();
			for (int n = 0; n < 8; n++)
			{
				int x = boardRotate ? 7 - n : n;
				int y = boardRotate ? 7 - n : n;
				int x2 = CPieceBoard.margin + x * CPieceBoard.field;
				int y2 = CPieceBoard.margin + y * CPieceBoard.field;
				rec.X = 0;
				rec.Y = y2;
				rec.Width = CPieceBoard.margin;
				rec.Height = CPieceBoard.field;
				string letter = (8 - y).ToString();
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.X = pictureBox1.Width - CPieceBoard.margin;
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.X = x2;
				rec.Y = 0;
				rec.Width = CPieceBoard.field;
				rec.Height = CPieceBoard.margin;
				letter = abc[x].ToString();
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.Y = pictureBox1.Height - CPieceBoard.margin;
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
			}
			for (int y = 0; y < 8; y++)
			{
				int yr = boardRotate ? 7 - y : y;
				int y2 = CPieceBoard.margin + yr * CPieceBoard.field;
				for (int x = 0; x < 8; x++)
				{
					int i = y * 8 + x;
					int xr = boardRotate ? 7 - x : x;
					int x2 = CPieceBoard.margin + xr * CPieceBoard.field;
					rec.X = x2;
					rec.Y = y2;
					rec.Width = CPieceBoard.field;
					rec.Height = CPieceBoard.field;
					if (i == CDrag.index)
						g.FillRectangle(brush3, rec);
					CPiece piece = CPieceBoard.list[i];
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
					if ((i == CDrag.index) && CDrag.dragged)
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
			g.DrawPath(outline, gp);
			g.FillPath(foreBrush, gp);
			if (Engine.whiteTurn)
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
			sf.Dispose();
			outline.Dispose();
			penW.Dispose();
			penB.Dispose();
			brush3.Dispose();
			foreBrush.Dispose();
			brushW.Dispose();
			brushB.Dispose();
			font.Dispose();
			fontPiece.Dispose();
			g.Dispose();
			pictureBox1.Refresh();
			CPieceBoard.finished = CPieceBoard.animated;
			CPieceBoard.Render();
			if (!CPieceBoard.animated)
			{
				CPieceBoard.SetImage();
				RenderTaken();
			}
		}

		void RenderHistory()
		{
			Engine.InitializeFromFen();
			for (int n = 0; n < CHistory.moves.Count; n++)
			{
				string emo = CHistory.moves[n];
				if (!Engine.MakeMove(emo))
					break;
			}
			CPieceBoard.Fill();
			ShowHistory();
		}

		void RenderInfo(CPlayer cp)
		{
			double dif = CData.gameState > 0 ? 0 : (DateTime.Now - cp.timeStart).TotalMilliseconds;
			DateTime tot = new DateTime().AddMilliseconds(cp.timeTotal + dif);
			if (CData.gameState == 0)
				if (boardRotate ^ Engine.whiteTurn)
				{
					labTimeB.Text = tot.ToString("HH:mm:ss");
					labScoreB.Text = $"Score {cp.score}";
					labNpsB.Text = $"Nps {cp.nps}";
					if (cp.seldepth != "0")
						labDepthB.Text = $"Depth {cp.depth} / {cp.seldepth}";
					else
						labDepthB.Text = $"Depth {cp.depth}";
				}
				else
				{
					labTimeT.Text = tot.ToString("HH:mm:ss");
					labScoreT.Text = $"Score {cp.score}";
					labNpsT.Text = $"Nps {cp.nps}";
					if (cp.seldepth != "0")
						labDepthT.Text = $"Depth {cp.depth} / {cp.seldepth}";
					else
						labDepthT.Text = $"Depth {cp.depth}";
				}
		}

		void RenderTaken()
		{
			int[] arrPiece = { 0, 0, 0, 0, 0, 0, 0, 0 };
			for (int y = 0; y < 8; y++)
			{
				for (int x = 0; x < 8; x++)
				{
					int piece = CEngine.g_board[((y + 4) << 4) + x + 4];
					if ((piece & CEngine.colorWhite) > 0)
						arrPiece[piece & 7]++;
					if ((piece & CEngine.colorBlack) > 0)
						arrPiece[piece & 7]--;
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
			if (boardRotate)
			{
				labTakenT.Text = w;
				labTakenB.Text = b;
			}
			else
			{
				labTakenT.Text = b;
				labTakenB.Text = w;
			}
		}

		void ShowHistory()
		{
			richTextBox1.Clear();
			for (int n = 0; n < CHistory.moves.Count; n++)
			{
				if ((n & 1) == 0)
				{
					int moveNumber = (n >> 1) + 1;
					richTextBox1.AppendText($"{moveNumber} ", Color.Red);
				}
				string emo = CHistory.moves[n];
				richTextBox1.AppendText($"{emo} ");
			}
			string lm = CHistory.LastMove();
			CDrag.index = CEngine.EmoToIndex(lm);
		}

		bool TryMove(int s, int d)
		{
			int m = Engine.IsValidMove(s, d, "q");
			if (m == 0)
				return false;
			string em = Engine.FormatMove(m);
			return MakeMove(em);
		}

		private void FormChess_FormClosed(object sender, FormClosedEventArgs e)
		{
			IniSave();
			CData.KillProcess();
		}

		private void Timer1_Tick_1(object sender, EventArgs e)
		{
			if (CPieceBoard.animated || CPieceBoard.finished || CDrag.dragged)
			{
				RenderBoard();
			}
			var cp = PlayerList.CurPlayer();
			RenderInfo(cp);
			if (cp.computer)
				if (!cp.started)
					cp.Start();
				else if (cp.readyok && !cp.go)
				{
					cp.CompMakeMove();
				}
				else
					GetMessage(cp);
		}

		private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StartGame();
		}

		private void ButStart_Click(object sender, EventArgs e)
		{
			StartGame();
		}

		private void PlayersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IniSave();
			FPlayer.ShowDialog(this);
			Reset();
			IniLoad();
		}

		private void ButStop_Click(object sender, EventArgs e)
		{
			PlayerList.CurPlayer().SendMessage("stop");
		}

		private void BackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CHistory.Back())
			{
				labBack.Text = $"Back {++CData.back}";
				RenderHistory();
			}
		}

		private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FOptions.ShowDialog(this);
		}

		private void ButTraining_Click(object sender, EventArgs e)
		{
			Trainer.Reset();
			StartTraing();
		}

		private void TimerStart_Tick(object sender, EventArgs e)
		{
			timerStart.Stop();
			if (CData.gameMode == (int)CMode.match)
			{
				StartMatch();
			}
			if (CData.gameMode == (int)CMode.training)
			{
				StartTraing();
			}
		}

		private void saveToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Engine.GetFen());
		}

		private void loadFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetMode(CMode.game);
			string fen = Clipboard.GetText().Trim();
			if (!Engine.InitializeFromFen(fen))
			{
				MessageBox.Show("Wrong fen");
				return;
			}
			CHistory.NewGame(fen);
			CDrag.index = -1;
			CPieceBoard.Fill();
			RenderBoard();
		}

		private void logToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!FormLog.This.Visible)
				FormLog.This.Show(this);
		}

		private void bStartMatch_Click(object sender, EventArgs e)
		{
			Match.Reset();
			StartMatch();
		}

		private void bookToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!FormBook.This.Visible)
				FormBook.This.ShowDialog(this);
		}

		private void saveToClipboardToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(CHistory.GetMoves());
		}

		private void loadFromClipboardToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SetMode(CMode.game);
			string pgn = Clipboard.GetText().Trim();
			string[] moves = pgn.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			Engine.InitializeFromFen();
			CHistory.NewGame();
			foreach (string emo in moves)
			{
				if (Engine.MakeMove(emo))
					CHistory.moves.Add(emo);
			}
			CDrag.index = -1;
			ShowHistory();
			CPieceBoard.Fill();
			RenderBoard();
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			CDrag.mouseX = e.X;
			CDrag.mouseY = e.Y;
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (PlayerList.CurPlayer().computer)
				return;
			int sou = CDrag.index;
			int x = (e.Location.X - CPieceBoard.margin) / CPieceBoard.field;
			int y = (e.Location.Y - CPieceBoard.margin) / CPieceBoard.field;
			if (boardRotate)
			{
				x = 7 - x;
				y = 7 - y;
			}
			CDrag.last = CDrag.index;
			CDrag.index = y * 8 + x;
			CDrag.dragged = true;
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			int x = (e.Location.X - CPieceBoard.margin) / CPieceBoard.field;
			int y = (e.Location.Y - CPieceBoard.margin) / CPieceBoard.field;
			if (boardRotate)
			{
				x = 7 - x;
				y = 7 - y;
			}
			int des = y * 8 + x;
			if (CDrag.index == des)
				TryMove(CDrag.last, des);
			else
				TryMove(CDrag.index, des);
			CDrag.dragged = false;
			CPieceBoard.animated = true;
		}
	}
}
