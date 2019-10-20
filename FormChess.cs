using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;


namespace RapChessGui
{
	public partial class FormChessGui : Form
	{
		[DllImport("user32.dll")]
		private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);

		[DllImport("gdi32.dll")]
		private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

		bool boardRotate;
		int lastDes = -1;
		CEngine Engine = new CEngine();
		CPlayerList PlayerList = new CPlayerList();
		CPieceList PieceList = new CPieceList();
		CTrainer Trainer = new CTrainer();
		CUci Uci = new CUci();
		FormOptions FOptions = new FormOptions();
		FormPlayer FPlayer = new FormPlayer();
		PrivateFontCollection pfc = new PrivateFontCollection();
		Font fontChess;

		public FormChessGui()
		{
			KillApplication();
			InitializeComponent();
			richTextBox1.AddContextMenu();
			Reset();
			IniRead();
			CPieceBoard.Prepare();
			pictureBox1.Size = new Size(CPieceBoard.size, CPieceBoard.size);
			CData.FLog = new FormLog();
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
			ShowTraining();
			Engine.Initialize();
			NewGame();
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
					MakeMove(em);
					break;
				case "info":
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

		void ShowTraining()
		{
			labGames.Text = $"Games {Trainer.games}";
			nudTime.Value = Trainer.time;
			label12.Text = Trainer.win.ToString();
			label13.Text = Trainer.draw.ToString();
			label14.Text = Trainer.loose.ToString();
			label15.Text = $"{Trainer.Result()}%";
			label7.Text = Trainer.loose.ToString();
			label8.Text = Trainer.draw.ToString();
			label9.Text = Trainer.win.ToString();
			label10.Text = $"{100 - Trainer.Result()}%";
		}

		void IniRead()
		{
			comboBoxW.SelectedIndex = comboBoxW.FindStringExact(CIniFile.Read("white", "Human"));
			comboBoxB.SelectedIndex = comboBoxB.FindStringExact(CIniFile.Read("black", "Computer"));
			comboBoxTrained.SelectedIndex = comboBoxTrained.FindStringExact(CIniFile.Read("trained", "Computer"));
			comboBoxTeacher.SelectedIndex = comboBoxTeacher.FindStringExact(CIniFile.Read("teacher", "RapChessCs.exe"));
			Trainer.time = Convert.ToInt32(CIniFile.Read("time", "1000"));
			CPieceBoard.LoadFromIni();

		}

		void IniSave()
		{
			CIniFile.Write("white", comboBoxW.Text);
			CIniFile.Write("black", comboBoxB.Text);
			CIniFile.Write("trained", comboBoxTrained.Text);
			CIniFile.Write("teacher", comboBoxTeacher.Text);
			CIniFile.Write("time", Trainer.time.ToString());
			CPieceBoard.SaveToIni();
		}

		void Reset()
		{
			comboBoxW.Items.Clear();
			comboBoxB.Items.Clear();
			comboBoxTrained.Items.Clear();
			comboBoxTeacher.Items.Clear();
			for (int n = 0; n < CUserList.list.Count; n++)
			{
				CUser u = CUserList.list[n];
				comboBoxW.Items.Add(u.name);
				comboBoxB.Items.Add(u.name);
				comboBoxTrained.Items.Add(u.name);
			}
			foreach (string en in CData.engineNames)
				comboBoxTeacher.Items.Add(en);
		}

		bool MakeMove(string emo)
		{
			emo = emo.ToLower();
			string cpName = PlayerList.CurPlayer().user.name;
			if (Engine.IsValidMove(emo) == 0)
			{
				labLast.Text = "Move error " + emo;
				labLast.ForeColor = Color.Red;
				CData.FLog.richTextBox1.AppendText($" error {emo}\n", Color.Red);
				CData.FLog.richTextBox1.SaveFile("last error.rtf");
				MessageBox.Show($"{cpName} do wrong move {emo}");
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
				labLast.ForeColor = Color.Yellow;
				switch (CData.gameState)
				{
					case (int)CGameState.mate:
						labLast.Text = cpName + " win";
						break;
					case (int)CGameState.drawn:
						labLast.Text = "Stalemate";
						break;
					case (int)CGameState.repetition:
						labLast.Text = "Threefold repetition";
						break;
					case (int)CGameState.move50:
						labLast.Text = "Fifty-move rule";
						break;
					case (int)CGameState.material:
						labLast.Text = "Insufficient material";
						break;
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
					CData.FLog.richTextBox1.SaveFile("last game.rtf");
					timerStart.Start();
				}
			}
			return true;
		}

		void Clear()
		{
			labTimeT.Text = "00:00:00";
			labTimeB.Text = "00:00:00";
			labScoreT.Text = "Score 0";
			labScoreB.Text = "Score 0";
			labDepthT.Text = "Depth 0";
			labDepthB.Text = "Depth 0";
			labNpsT.Text = "Nps 0";
			labNpsB.Text = "Nps 0";
			richTextBox1.Clear();
			labMove.Text = "Move 1 0";
			labLast.ForeColor = Color.Gainsboro;
			labLast.Text = "Good luck";
			lastDes = -1;
			Engine.InitializeFromFen();
			CData.gameState = 0;
			CHistory.NewGame(Engine.GetFen());
			PieceList.Fill();
			PlayerList.NewGame();
			timer1.Enabled = true;
			CPlayer pw = PlayerList.player[0];
			CPlayer pb = PlayerList.player[1];
			CData.FLog.richTextBox1.Clear();
			CData.FLog.richTextBox1.AppendText($"White {pw.user.name} {pw.user.engine} {pw.user.parameters}\n");
			CData.FLog.richTextBox1.AppendText($"Black {pb.user.name} {pb.user.engine} {pb.user.parameters}\n");
		}

		void NewGame()
		{
			PlayerList.KillProcess();
			CData.gameMode = (int)CMode.normal;
			PlayerList.player[0].SetUser(comboBoxW.Text);
			PlayerList.player[1].SetUser(comboBoxB.Text);
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
					if (i == lastDes)
						g.FillRectangle(brush3, rec);
					CPiece piece = CPieceBoard.list[i];
					if (piece == null)
						continue;
					GraphicsPath gp1 = null;
					int image = 0;
					if (piece.desImage >= 0)
					{
						gp1 = piece.desImage > 5 ? gpB : gpW;
						image = piece.desImage % 6;
						gp1.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
					}
					piece.SetDes(i, x2, y2);
					rec.X = piece.curXY.X;
					rec.Y = piece.curXY.Y;
					gp1 = piece.image > 5 ? gpB : gpW;
					image = piece.image % 6;
					gp1.AddString("pnbrqk"[image].ToString(), fontPiece.FontFamily, (int)fontPiece.Style, fontPiece.Size, rec, sf);
				}
			}
			g.DrawPath(outline, gp);
			g.FillPath(foreBrush, gp);
			g.DrawPath(penW, gpW);
			g.FillPath(brushW, gpW);
			g.DrawPath(penB, gpB);
			g.FillPath(brushB, gpB);
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
			if ((CData.gameState > 0) && (!CPieceBoard.animated))
			{
				timer1.Enabled = false;
				PieceList.Fill();
			}
			CPieceBoard.Render();
			if (!CPieceBoard.animated)
				RenderTaken();
		}

		void RenderHistory()
		{
			Engine.InitializeFromFen();
			for (int n = 0; n < CHistory.moves.Count; n++)
			{
				string emo = CHistory.moves[n];
				int gmo = Engine.GetMoveFromString(emo);
				Engine.MakeMove(gmo);
			}
			PieceList.Fill();
			ShowHistory();
		}

		void RenderTaken()
		{
			int[] arrPiece = { 0, 0, 0, 0, 0, 0, 0, 0 };
			for (int y = 0; y < 8; y++)
			{
				for (int x = 0; x < 8; x++)
				{
					int piece = CEngine.g_board[((y + 4) << 4) + x + 4];
					if ((piece & CEngine.colorWhite)>0)
						arrPiece[piece & 7]++;
					if ((piece & CEngine.colorBlack) > 0)
						arrPiece[piece & 7]--;
				}
			}
			string w = "";
			string b = "";
			for(int n = 5; n > 0; n--)
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
			lastDes = CEngine.EmoToIndex(lm);
		}

		void TrainerStart()
		{
			PlayerList.KillProcess();
			CData.gameMode = (int)CMode.training;
			Trainer.user.engine = comboBoxTeacher.Text;
			Trainer.user.mode = "movetime";
			Trainer.user.value = Trainer.time.ToString();
			var nw = comboBoxTrained.Text;
			PlayerList.player[0].SetUser(nw);
			PlayerList.player[1].SetUser(Trainer.user);
			if (Trainer.rotate == 1)
				PlayerList.Rotate();
			Trainer.rotate ^= 1;
			Clear();
		}

		bool TryMove(int s, int d)
		{
			int m = Engine.IsValidMove(s, d, "q");
			if (m == 0)
				return false;
			string em = Engine.FormatMove(m);
			return MakeMove(em);
		}

		private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (PlayerList.CurPlayer().computer)
				return;
			CPieceBoard.animated = true;
			int sou = lastDes;
			int x = (e.Location.X - CPieceBoard.margin) / CPieceBoard.field;
			int y = (e.Location.Y - CPieceBoard.margin) / CPieceBoard.field;
			if (boardRotate)
			{
				x = 7 - x;
				y = 7 - y;
			}
			lastDes = y * 8 + x;
			TryMove(sou, lastDes);
		}

		private void FormChess_FormClosed(object sender, FormClosedEventArgs e)
		{
			IniSave();
			PlayerList.KillProcess();
		}

		private void Timer1_Tick_1(object sender, EventArgs e)
		{
			if (CPieceBoard.animated)
			{
				RenderBoard();
				return;
			}
			var cp = PlayerList.CurPlayer();
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
			NewGame();
		}

		private void ButStart_Click(object sender, EventArgs e)
		{
			NewGame();
		}

		private void PlayersToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IniSave();
			FPlayer.ShowDialog(this);
			Reset();
			IniRead();
		}

		private void ButStop_Click(object sender, EventArgs e)
		{
			PlayerList.CurPlayer().SendMessage("stop");
		}

		private void BackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CHistory.Back();
			RenderHistory();
		}

		private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FOptions.ShowDialog(this);
			CPieceBoard.Prepare();
			RenderBoard();
		}

		private void ButTraining_Click(object sender, EventArgs e)
		{
			TrainerStart();
		}

		private void TimerStart_Tick(object sender, EventArgs e)
		{
			timerStart.Stop();
			if (CData.gameMode == (int)CMode.training)
			{
				TrainerStart();
			}
		}

		private void saveToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(Engine.GetFen());
		}

		private void loadFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fen = Clipboard.GetText();
			if (!Engine.InitializeFromFen(fen))
			{
				MessageBox.Show("Wrong fen");
				return;
			}
			CHistory.NewGame(fen);
			lastDes = -1;
			PieceList.Fill();
			RenderBoard();
		}

		private void logToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!CData.FLog.Visible)
				CData.FLog.Show(this);
		}
	}
}
