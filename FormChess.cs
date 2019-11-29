using System;
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
		bool boardRotate;
		int levelOrg;
		int levelDif;
		int levelMD;
		int tournament;
		private ColumnHeader SortingColumn = null;
		List<int> moves = new List<int>();
		CRapIni RapIni = new CRapIni();
		CEngine Engine = new CEngine();
		CPlayerList PlayerList = new CPlayerList();
		CModeMatch Match = new CModeMatch();
		CModeTraining Trainer = new CModeTraining();
		CUci Uci = new CUci();
		FormOptions FOptions = new FormOptions();
		FormPlayer FPlayer = new FormPlayer();
		PrivateFontCollection pfc = new PrivateFontCollection();
		Font fontChess;

		public FormChess()
		{
			InitializeComponent();
			This = this;
			FormBook.This = new FormBook();
			FormLog.This = new FormLog();
			Reset();
			IniLoad();
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
			Engine.Initialize();
			ShowGame();
			ShowMatch();
			ShowTraining();
			StartGame();
		}

		void IniLoad()
		{
			cbColor.SelectedIndex = cbColor.FindStringExact(CRapIni.This.Read("game>color", "Auto"));
			cbComputer.SelectedIndex = cbComputer.FindStringExact(CRapIni.This.Read("game>black", "Auto"));
			cbPlayer1.SelectedIndex = cbPlayer1.FindStringExact(CRapIni.This.Read("match>player1", CUserList.defUser));
			cbPlayer2.SelectedIndex = cbPlayer2.FindStringExact(CRapIni.This.Read("match>player2", CUserList.defUser));
			tournament = Convert.ToInt32(CRapIni.This.Read("tournament>tournament", "0"));
			comboBoxTrained.SelectedIndex = comboBoxTrained.FindStringExact(CRapIni.This.Read("training>trained", CUserList.defUser));
			comboBoxTeacher.SelectedIndex = comboBoxTeacher.FindStringExact(CRapIni.This.Read("training>teacher", "RapChessCs.exe"));
			cbBookList.SelectedIndex = cbBookList.FindStringExact(CRapIni.This.Read("training>book", "small.txt"));
			nudTeacher.Value = Convert.ToInt32(CRapIni.This.Read("training>timeTeacher", "1000"));
			nudTrained.Value = Convert.ToInt32(CRapIni.This.Read("training>timeTrained", "1000"));
			Trainer.time = (int)nudTeacher.Value;
			FOptions.cbShowPonder.Checked = Convert.ToInt32(CRapIni.This.Read("options>interface>showponder", "1")) == 1;
			FOptions.cbGameAutoElo.Checked = Convert.ToInt32(CRapIni.This.Read("options>game>autoelo", "1")) == 1;
			FOptions.cbRotateBoard.Checked = Convert.ToInt32(CRapIni.This.Read("options>interface>rotate", "0")) == 1;
			FOptions.cbAttack.Checked = Convert.ToInt32(CRapIni.This.Read("options>interface>attack", "0")) == 1;
			CBoard.LoadFromIni();
		}

		void IniSave()
		{
			CRapIni.This.Write("game>color", cbColor.Text);
			CRapIni.This.Write("game>black", cbComputer.Text);
			CRapIni.This.Write("match>player1", cbPlayer1.Text);
			CRapIni.This.Write("match>player2", cbPlayer2.Text);
			CRapIni.This.Write("tournament>tournament", tournament.ToString());
			CRapIni.This.Write("training>trained", comboBoxTrained.Text);
			CRapIni.This.Write("training>teacher", comboBoxTeacher.Text);
			CRapIni.This.Write("training>book", cbBookList.Text);
			CRapIni.This.Write("training>timeTeacher", nudTeacher.Value.ToString());
			CRapIni.This.Write("training>timeTrained", nudTrained.Value.ToString());
			CRapIni.This.Write("options>interface>showponder", FOptions.cbShowPonder.Checked ? "1" : "0");
			CRapIni.This.Write("options>interface>rotate", FOptions.cbRotateBoard.Checked ? "1" : "0");
			CRapIni.This.Write("options>interface>attack", FOptions.cbAttack.Checked ? "1" : "0");
			CRapIni.This.Write("options>game>autoelo", FOptions.cbGameAutoElo.Checked ? "1" : "0");
			CBoard.SaveToIni();
			CUserList.SaveToIni();
			RapIni.Save();
		}

		public void GetMessage(CPlayer p)
		{
			string msg = p.GetMessage();
			while (msg != "")
			{
				Uci.SetMsg(msg);
				switch (Uci.command)
				{
					case "0-1":
					case "1-0":
						Resignation();
						break;
					case "uciok":
						p.uciok = true;
						p.SendMessage("ucinewgame");
						p.SendMessage("isready");
						break;
					case "readyok":
						p.readyok = true;
						break;
					case "move":
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
						s = Uci.GetValue("nodes");
						if (s != "")
						{
							try
							{
								p.nodes = Convert.ToInt32(s);
							}
							catch
							{
							}
						}
						s = Uci.GetValue("nps");
						if (s != "")
						{
							try
							{
								p.nps = Convert.ToInt32(s);
							}
							catch
							{
							}
						}
						string pv = "";
						int i = Uci.GetIndex("pv", 0);
						if (i > 0)
						{
							for (int n = i; n < Uci.tokens.Length; n++)
								pv += Uci.tokens[n] + " ";
							labLast.Text = pv;
						}
						break;
					default:
						if ((PlayerList.CurPlayer().user.protocol == "Winboard") && PlayerList.CurPlayer().wbok && (Uci.tokens.Length > 4))
						{
							try
							{
								p.depth = Uci.tokens[0];
								p.score = Uci.tokens[1];
								int ms = Convert.ToInt32(Uci.tokens[2]);
								p.nodes = Convert.ToInt32(Uci.tokens[3]);
								p.nps = ms > 0 ? (p.nodes * 100) / ms : 0;
								pv = "";
								for (int n = 4; n < Uci.tokens.Length; n++)
									pv += Uci.tokens[n] + " ";
								labLast.ForeColor = Color.Gainsboro;
								labLast.Text = pv;
							}
							catch
							{
								CRapLog.Add($"{p.user.name} {msg}");
							}
						}
						break;
				}
				msg = p.GetMessage();
			}
			if (PlayerList.CurPlayer().user.protocol == "Winboard")
				PlayerList.CurPlayer().readyok = true;
		}

		public void AddBook(string emo)
		{
			PlayerList.CurPlayer().usedBook++;
			labLast.ForeColor = Color.Aquamarine;
			labLast.Text = $"book {emo}";
		}

		void SetMode(int mode)
		{
			timer1.Enabled = false;
			timerStart.Enabled = false;
			PlayerList.Terminate();
			CData.gameMode = (int)mode;
			lock (CData.messages)
				CData.messages.Clear();
			moveToolStripMenuItem.Visible = mode == (int)CMode.game;
			Clear();
			if (mode == (int)CMode.edit)
			{
				ShowEdit();
			}
		}

		void ShowGame()
		{
			CUser uc = CUserList.GetUser(cbComputer.Text);
			if (uc.name == cbComputer.Text)
				labEngine.Text = uc.engine;
			else
				labEngine.Text = uc.name;
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

		void ShowTournament()
		{
			listView1.Items.Clear();
			foreach (CUser u in CUserList.list)
				if (u.engine != "Human")
					listView1.Items.Add(new ListViewItem(new[] { u.name, u.elo, u.GetDeltaElo().ToString() }));
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

		void ShowEdit()
		{
			List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
			int i = Engine.whiteTurn ? 1 : 0;
			list[i].Select();
		}

		void Reset()
		{
			cbComputer.Items.Clear();
			cbPlayer1.Items.Clear();
			cbPlayer2.Items.Clear();
			comboBoxTrained.Items.Clear();
			comboBoxTeacher.Items.Clear();
			cbComputer.Items.Add("Auto");
			for (int n = 0; n < CUserList.list.Count; n++)
			{
				CUser u = CUserList.list[n];
				cbComputer.Items.Add(u.name);
				cbPlayer1.Items.Add(u.name);
				cbPlayer2.Items.Add(u.name);
				comboBoxTrained.Items.Add(u.name);
			}
			foreach (string en in CData.engineNames)
			{
				comboBoxTeacher.Items.Add(en);
			}
			cbBookList.Items.Clear();
			FormBook.This.cbBookList.Items.Clear();
			FormPlayer.This.cbBookList.Items.Clear();
			cbBookList.Items.Add("None");
			FormPlayer.This.cbBookList.Items.Add("None");
			foreach (string b in CData.bookNames)
			{
				cbBookList.Items.Add(b);
				FormBook.This.cbBookList.Items.Add(b);
				FormPlayer.This.cbBookList.Items.Add(b);
			}
			cbBookList.SelectedIndex = 0;
			FormBook.This.cbBookList.SelectedIndex = 0;
			FormPlayer.This.SelectUser();
			ShowTournament();
			if (SortingColumn != null)
				SortingColumn.Text = SortingColumn.Text.Substring(2);
			SortingColumn = listView1.Columns[1];
			listView1.Columns[1].Text = $"▼ {listView1.Columns[1].Text}";
			listView1.ListViewItemSorter = new ListViewComparer(1, SortOrder.Descending);
			listView1.Sort();
		}

		public bool MakeMove(string emo)
		{
			emo = emo.ToLower();
			CUser uw = PlayerList.CurPlayer().user;
			CUser ul = PlayerList.SecPlayer().user;
			if ((CData.gameMode == (int)CMode.game) && (uw.name == "Human") && (ul.name != "Human") && (cbComputer.Text == "Auto") && ((Engine.g_moveNumber >> 1) == 10))
			{
				uw.elo = levelMD.ToString();
			}
			bool ivm = Engine.IsValidMove(emo) != 0;
			if (!ivm)
			{
				string emo2 = $"{emo}q";
				ivm = Engine.IsValidMove(emo2) != 0;
				if (ivm)
					emo = emo2;
			}
			if (!ivm)
			{
				labLast.ForeColor = Color.Red;
				labLast.Text = "Move error " + emo;
				FormLog.This.richTextBox1.AppendText($" error {emo}\n", Color.Red);
				FormLog.This.richTextBox1.SaveFile("Error.rtf");
				return false;
			}
			int gm = Engine.GetMoveFromString(emo);
			int fr = gm & 0xff;
			int piece = CEngine.g_board[fr] & 0xf;
			AddMove(piece, emo);
			CBoard.MakeMove(gm);
			Engine.MakeMove(gm);
			int moveNumber = (Engine.g_moveNumber >> 1) + 1;
			labMove.Text = "Move " + moveNumber.ToString() + " " + Engine.g_move50.ToString();
			CData.gameState = Engine.GetGameState();
			if (CData.gameState == 0)
			{
				PlayerList.Next();
				if (PlayerList.CurPlayer().user.engine == "Human")
					moves = Engine.GenerateValidMoves();
			}
			else
				GameOver(uw, ul);
			return true;
		}

		void GameOver(CUser uw, CUser ul)
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
				if (CData.gameState == (int)CGameState.mate)
				{
					if (CModeGame.ranked)
					{
						int newElo = levelOrg;
						if (uw.name == "Human")
						{
							newElo += levelDif;
							uw.elo = newElo.ToString();
						}
						else
						{
							newElo -= levelDif;
							if (newElo < 0)
								newElo = 0;
							ul.elo = newElo.ToString();
						}
						labLast.Text += $" new elo {newElo}";
					}
					CUserList.SaveToIni();
				}
			}
			if (CData.gameMode == (int)CMode.match)
			{
				Match.games++;
				if (CData.gameState == (int)CGameState.mate)
				{
					if (uw.name == labMatch10.Text)
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
			if (CData.gameMode == (int)CMode.tournament)
			{
				int indexW = CUserList.GetIndexElo(eloW);
				int indexL = CUserList.GetIndexElo(eloL);
				int optW = CUserList.GetOptElo(indexW);
				int optL = CUserList.GetOptElo(indexL);
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
				}
				else
				{
					int opt = (OW + OL) >> 1;
					OW = opt;
					OL = opt;
				}
				int newW = Convert.ToInt32(eloW * 0.9 + OW * 0.1);
				int newL = Convert.ToInt32(eloL * 0.9 + OL * 0.1);
				uw.elo = newW.ToString();
				ul.elo = newL.ToString();
				ShowTournament();
				CUserList.SaveToIni();
			}
			if (CData.gameMode == (int)CMode.training)
			{
				Trainer.games++;
				if (CData.gameState == (int)CGameState.mate)
				{
					if (uw.name == "Teacher")
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
			FormLog.This.richTextBox1.SaveFile($"{CData.modeName}.rtf");
			timerStart.Start();
		}

		void Resignation()
		{
			if (CData.gameState == (int)CGameState.normal)
			{
				CUser ul = PlayerList.CurPlayer().user;
				CUser uw = PlayerList.SecPlayer().user;
				CData.gameState = (int)CGameState.mate;
				FormLog.This.richTextBox1.AppendText($"Resignation {ul.name}\n", Color.Gray);
				GameOver(uw, ul);
			}
		}

		void Clear()
		{
			labMove.Text = "Move 1 0";
			labLast.ForeColor = Color.Gainsboro;
			labLast.Text = "Good luck";
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			Engine.InitializeFromFen();
			CHistory.NewGame(Engine.GetFen());
			CBoard.Clear();
			CBoard.Fill();
			PlayerList.Init();
			lvMoves.Items.Clear();
			CData.back = 0;
			CPlayer pw = PlayerList.player[0];
			CPlayer pb = PlayerList.player[1];
			FormLog.This.richTextBox1.Clear();
			if(pw.user!=null)
			FormLog.This.richTextBox1.AppendText($"White {pw.user.name} {pw.user.engine} {pw.user.parameters}\n", Color.Gray);
			if (pb.user != null)
				FormLog.This.richTextBox1.AppendText($"Black {pb.user.name} {pb.user.engine} {pb.user.parameters}\n", Color.Gray);
			labBack.Text = $"Back {CData.back}";
			RenderInfo(pw);
			RenderInfo(pb);
			CData.gameState = (int)CGameState.normal;
			timer1.Enabled = CData.gameMode != (int)CMode.edit;
		}

		CUser CommandToUser()
		{
			CUser u = new CUser(cbComputer.Text);
			u.SetUser(cbComputer.Text);
			u.SetCommand(cbCommand.Text);
			cbCommand.Text = u.GetCommand();
			return u;
		}

		void StartGame()
		{
			CModeGame.ranked = (cbComputer.Text == "Auto") && FOptions.cbGameAutoElo.Checked;
			levelOrg = Convert.ToInt32(CUserList.GetUser("Human").elo);
			levelDif = 2000 / listView1.Items.Count;
			if (levelDif < 10)
				levelDif = 10;
			levelMD = levelOrg - levelDif;
			if (levelMD < 0)
				levelMD = 0;
			SetMode((int)CMode.game);
			ShowGame();
			PlayerList.player[0].SetUser("Human");
			CUser u = CommandToUser();
			PlayerList.player[1].SetUser(u);
			bool r = cbColor.Text != "White";
			if (cbColor.Text == "Auto")
				r = CEngine.random.Next(2) > 0;
			if (r)
				PlayerList.Rotate();
			Clear();
			if (PlayerList.CurPlayer().user.engine == "Human")
				moves = Engine.GenerateValidMoves();
		}

		void StartMatch()
		{
			SetMode((int)CMode.match);
			ShowMatch();
			PlayerList.player[0].SetUser(cbPlayer1.Text);
			PlayerList.player[1].SetUser(cbPlayer2.Text);
			if (Match.rotate == 1)
				PlayerList.Rotate();
			Match.rotate ^= 1;
			Clear();
			if (PlayerList.CurPlayer().user.engine == "Human")
				moves = Engine.GenerateValidMoves();
		}

		void StartTournament()
		{
			SetMode((int)CMode.tournament);
			if (++tournament >= listView1.Items.Count)
				tournament = 0;
			CUser u = CUserList.GetUser(listView1.Items[tournament].SubItems[0].Text);
			PlayerList.player[0].SetUser(u);
			PlayerList.player[1].SetUser(CUserList.GetUserEloHL(u));
			Clear();
		}

		void StartTraing()
		{
			SetMode((int)CMode.training);
			ShowTraining();
			CUser uw = new CUser("Trained");
			uw.SetUser(comboBoxTrained.Text);
			uw.mode = "movetime";
			uw.value = nudTrained.Value.ToString();
			CUser ub = new CUser("Teacher");
			ub.engine = comboBoxTeacher.Text;
			ub.book = cbBookList.Text;
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
			pictureBox1.Image = new Bitmap(CBoard.bitmap);
			Graphics g = Graphics.FromImage(pictureBox1.Image);
			Brush brushRed = new SolidBrush(Color.FromArgb(0x80, 0xff, 0x00, 0x00));
			Brush brushYellow = new SolidBrush(Color.FromArgb(0x80, 0xff, 0xff, 0x00));
			Font font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
			Font fontPiece = new Font(pfc.Families[0], CBoard.field);
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
				int xr = boardRotate ? 7 - n : n;
				int yr = boardRotate ? 7 - n : n;
				int x2 = CBoard.margin + xr * CBoard.field;
				int y2 = CBoard.margin + yr * CBoard.field;
				rec.X = 0;
				rec.Y = y2;
				rec.Width = CBoard.margin;
				rec.Height = CBoard.field;
				string letter = (8 - n).ToString();
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.X = pictureBox1.Width - CBoard.margin;
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.X = x2;
				rec.Y = 0;
				rec.Width = CBoard.field;
				rec.Height = CBoard.margin;
				letter = abc[n].ToString();
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.Y = pictureBox1.Height - CBoard.margin;
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
			}
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
					else if (CBoard.list[i].attacked)
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
			brushRed.Dispose();
			brushYellow.Dispose();
			foreBrush.Dispose();
			brushW.Dispose();
			brushB.Dispose();
			font.Dispose();
			fontPiece.Dispose();
			g.Dispose();
			pictureBox1.Refresh();
			CBoard.finished = CBoard.animated;
			CBoard.Render();
			if (!CBoard.animated)
			{
				if(FOptions.cbAttack.Checked)
				CBoard.ShowAttack();
				CBoard.SetImage();
				RenderTaken();
			}
		}

		void RenderInfo(CPlayer cp)
		{
			if ((CData.gameState == 0) && (cp.go))
			{
				DateTime dt = DateTime.Now;
				double dif = (dt - cp.timeStart).TotalMilliseconds;
				cp.timeStart = dt;
				cp.timeTotal += dif;
			}
			if (!FOptions.cbShowPonder.Checked)
				cp.ponder = "";
			if (boardRotate ^ cp.white)
			{
				labTimeB.Text = cp.GetTime();
				labEloB.Text = cp.GetElo();
				labProtocolB.Text = cp.GetProtocol();
				labScoreB.Text = $"Score {cp.score}";
				labNodesB.Text = $"Nodes {cp.nodes.ToString("N0")}";
				labNpsB.Text = $"Nps {cp.nps.ToString("N0")}";
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
				labNpsT.Text = $"Nps {cp.nps.ToString("N0")}";
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

		void LoadFen(string fen)
		{
			SetMode((int)CMode.game);
			if (!Engine.InitializeFromFen(fen))
			{
				MessageBox.Show("Wrong fen");
				return;
			}
			PlayerList.curIndex = Engine.g_moveNumber & 1;
			CUser u = CommandToUser();
			PlayerList.CurPlayer().SetUser("Human");
			PlayerList.SecPlayer().SetUser(u);
			PlayerList.player[0].Init(true);
			PlayerList.player[1].Init(false);
			cbColor.SelectedIndex = PlayerList.curIndex;
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			CHistory.NewGame(fen);
			CBoard.Fill();
			RenderBoard();
			CPlayer pw = PlayerList.player[0];
			CPlayer pb = PlayerList.player[1];
			FormLog.This.richTextBox1.Clear();
			FormLog.This.richTextBox1.AppendText($"Fen {Engine.GetFen()}\n", Color.Gray);
			FormLog.This.richTextBox1.AppendText($"White {pw.user.name} {pw.user.engine} {pw.user.parameters}\n", Color.Gray);
			FormLog.This.richTextBox1.AppendText($"Black {pb.user.name} {pb.user.engine} {pb.user.parameters}\n", Color.Gray);
			labLast.ForeColor = Color.Lime;
			labLast.Text = $"Load fen {Engine.GetFen()}";
			labBack.Text = $"Back {CData.back}";
			lvMoves.Items.Clear();
			RenderInfo(pw);
			RenderInfo(pb);
			CData.gameState = 0;
			moves = Engine.GenerateValidMoves();
			timer1.Enabled = true;
		}

		private void MoveToRtb(int count, int piece, string emo)
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

		private void AddMove(int piece, string emo)
		{
			MoveToRtb(CHistory.moveList.Count, piece, emo);
			CHistory.AddMove(piece, emo);
			CEngine.EmoToSD(emo,out CDrag.lastSou,out CDrag.lastDes);
		}

		void ShowHistory()
		{
			lvMoves.Items.Clear();
			for (int n = 0; n < CHistory.moveList.Count; n++)
			{
				CHisMove m = CHistory.moveList[n];
				MoveToRtb(n, m.piece, m.emo);
			}
		}

		void RenderHistory()
		{
			Engine.InitializeFromFen(CHistory.fen);
			foreach (CHisMove m in CHistory.moveList)
			{
				Engine.MakeMove(m.emo);
			}
			CEngine.EmoToSD(CHistory.LastMove(),out CDrag.lastSou,out CDrag.lastDes);
			CBoard.Fill();
			ShowHistory();
		}

		bool TryMove(int s, int d)
		{
			int m = Engine.IsValidMove(s, d, "q");
			if (m == 0)
				return false;
			string em = Engine.FormatMove(m);
			return MakeMove(em);
		}

		bool IsValid(int i)
		{
			foreach (int c in moves)
			{
				int x = i & 7;
				int y = i >> 3;
				int s = Engine.MakeSquare(y, x);
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
			int sa = Engine.MakeSquare(sy, sx);
			int dx = des & 7;
			int dy = des >> 3;
			int da = Engine.MakeSquare(dy, dx);
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
				int i = CEngine.Con256To64(sou);
				CBoard.list[i].color = Color.Yellow;
			}
		}

		void ShowValid(int index)
		{
			int max = index & 7;
			int may = index >> 3;
			int sa = Engine.MakeSquare(may, max);
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
			IniSave();
			PlayerList.Terminate();
			SortingColumn.Dispose();

		}

		private void Timer1_Tick_1(object sender, EventArgs e)
		{
			if (CBoard.animated || CBoard.finished || CDrag.dragged)
			{
				RenderBoard();
			}
			else
			{
				CPlayer cp = PlayerList.CurPlayer();
				CPlayer sp = PlayerList.SecPlayer();
				RenderInfo(cp);
				RenderInfo(sp);
				if (cp.computer)
				{
					if (!cp.started)
						cp.Start();
					else if (cp.readyok && !cp.go)
					{
						cp.CompMakeMove();
					}
					else
					{
						GetMessage(cp);
					}
				}
				else
					cp.go = true;
			}
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
			PlayerList.CurPlayer().EngineStop();
		}

		private void BackToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FOptions.ShowDialog(this);
			CBoard.ClearAttack();
			CBoard.Prepare();
			CBoard.animated = true;
			RenderBoard();
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
			if (CData.gameMode == (int)CMode.tournament)
			{
				StartTournament();
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
			LoadFen(Clipboard.GetText().Trim());
		}

		private void loadFromClipboardToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			SetMode((int)CMode.game);
			string pgn = Clipboard.GetText().Trim();
			string[] ml = pgn.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			Engine.InitializeFromFen();
			CHistory.NewGame();
			foreach (string emo in ml)
			{
				int piece = Engine.MakeMove(emo);
				if (piece > 0)
					CHistory.AddMove(piece, emo);
			}
			PlayerList.curIndex = Engine.g_moveNumber & 1;
			CUser u = CommandToUser();
			PlayerList.CurPlayer().SetUser("Human");
			PlayerList.SecPlayer().SetUser(u);
			PlayerList.player[0].Init(true);
			PlayerList.player[1].Init(false);
			cbColor.SelectedIndex = PlayerList.curIndex;
			CDrag.lastSou = -1;
			CDrag.lastDes = -1;
			ShowHistory();
			CBoard.Fill();
			RenderBoard();
			CPlayer pw = PlayerList.player[0];
			CPlayer pb = PlayerList.player[1];
			FormLog.This.richTextBox1.Clear();
			FormLog.This.richTextBox1.AppendText($"Pgn {CHistory.GetMoves()}\n", Color.Gray);
			FormLog.This.richTextBox1.AppendText($"White {pw.user.name} {pw.user.engine} {pw.user.parameters}\n", Color.Gray);
			FormLog.This.richTextBox1.AppendText($"Black {pb.user.name} {pb.user.engine} {pb.user.parameters}\n", Color.Gray);
			labLast.ForeColor = Color.Gainsboro;
			labLast.Text = $"Pgn {CHistory.GetMoves()}";
			labBack.Text = $"Back {CData.back}";
			RenderInfo(pw);
			RenderInfo(pb);
			CData.gameState = 0;
			moves = Engine.GenerateValidMoves();
			timer1.Enabled = true;
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

		private void cbComputer_TextChanged(object sender, EventArgs e)
		{
			CUser uc = CUserList.GetUser(cbComputer.Text);
			labEngine.Text = uc.engine;
			cbCommand.Text = uc.GetCommand();
		}

		private void butStartTournament_Click(object sender, EventArgs e)
		{
			StartTournament();
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
			PlayerList.CurPlayer().EngineStop();
		}

		private void restartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayerList.CurPlayer().SetUser();
		}

		private void terminateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayerList.CurPlayer().PlayerEng.Terminate();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayerList.CurPlayer().EngineClose();
		}

		private void tabControl1_Selected(object sender, TabControlEventArgs e)
		{
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
				int i = CEngine.arrField[CDrag.mouseIndex];
				int f = CEngine.g_board[i];
				int r = f & 7;
				if (e.Button == MouseButtons.Left)
				{
					if ((CEngine.g_board[i] & CEngine.colorWhite) == 0)
						CEngine.g_board[i] = CEngine.colorWhite | CEngine.piecePawn;
					else
					{
						if (++r > CEngine.pieceKing)
							r = CEngine.piecePawn;
						CEngine.g_board[i] = CEngine.colorWhite | r;
					}
				}
				if (e.Button == MouseButtons.Right)
				{
					if ((CEngine.g_board[i] & CEngine.colorBlack) == 0)
						CEngine.g_board[i] = CEngine.colorBlack | CEngine.piecePawn;
					else
					{
						if (++r > CEngine.pieceKing)
							r = CEngine.piecePawn;
						CEngine.g_board[i] = CEngine.colorBlack | r;
					}
				}
				if (e.Button == MouseButtons.Middle)
				{
					CEngine.g_board[i] = CEngine.colorEmpty;
				}
				CBoard.UpdateField(CDrag.mouseIndex);
				RenderBoard();
			}
			if (CData.gameMode == (int)CMode.game)
			{
				if (PlayerList.CurPlayer().computer)
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

		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			if (CData.gameMode == (int)CMode.edit)
			{
				int i = CEngine.arrField[CDrag.mouseIndex];
				CEngine.g_board[i] = CEngine.colorEmpty;
				CBoard.UpdateField(CDrag.mouseIndex);
				RenderBoard();
			}
		}

		private void butClearBoard_Click(object sender, EventArgs e)
		{
			for (int n = 0; n < 64; n++)
			{
				int i = CEngine.arrField[n];
				CEngine.g_board[i] = CEngine.colorEmpty;
				CBoard.UpdateField(n);
			}
			RenderBoard();
		}

		private void rbColorChanged(object sender, EventArgs e)
		{
			var checkedButton = gbToMove.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			List<RadioButton> list = gbToMove.Controls.OfType<RadioButton>().ToList();
			int i = list.IndexOf(checkedButton);
			Engine.whiteTurn = i == 1;
		}

		private void butContinueGame_Click(object sender, EventArgs e)
		{
			LoadFen(Engine.GetFen());
		}

		private void backToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (CHistory.Back())
			{
				labBack.Text = $"Back {++CData.back}";
				RenderHistory();
				moves = Engine.GenerateValidMoves();
				CData.gameState = Engine.GetGameState();
				PlayerList.CurPlayer().user.elo = levelMD.ToString();
			}
		}

		private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayerList.Rotate();
		}

	}
}
