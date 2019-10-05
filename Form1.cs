using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace RapChessGui
{
	public partial class FormChess : Form
	{
		bool boardRotate;
		int lastDes = -1;
		int field = 0;
		CIniFile IniFile = new CIniFile();
		CEngine Engine = new CEngine();
		CPlayerList PlayerList = new CPlayerList();
		CPieceList PieceList = new CPieceList();
		CUci Uci = new CUci();
		FrmPlayer FPlayer = new FrmPlayer();

		public FormChess()
		{
			InitializeComponent();
			richTextBox1.AddContextMenu();
			CPieceBoard.Prepare();
			pictureBox1.Size = new Size(CPieceBoard.size, CPieceBoard.size);
			Reset();
		}

		private void FormChess_Load(object sender, EventArgs e)
		{
			Engine.Initialize();
			NewGame();
		}

		void Reset()
		{
			comboBoxW.Items.Clear();
			comboBoxB.Items.Clear();
			for (int n = 0; n < CUserList.list.Count; n++)
			{
				comboBoxW.Items.Add(CUserList.list[n].name);
				comboBoxB.Items.Add(CUserList.list[n].name);
			}
			string nw = IniFile.Read("white", "Human");
			string nb = IniFile.Read("black", "Computer");
			comboBoxW.SelectedIndex = comboBoxW.FindStringExact(nw);
			comboBoxB.SelectedIndex = comboBoxB.FindStringExact(nb);
		}

		void MakeMove(string em)
		{
			if (Engine.IsValidMove(em) == 0)
			{
				labLast.Text = "Move error " + em;
				labLast.ForeColor = Color.Red;
				return;
			}
			double t = (DateTime.Now - PlayerList.CurPlayer().timeStart).TotalMilliseconds;
			PlayerList.CurPlayer().timeTotal += t;
			int moveNumber = (Engine.g_moveNumber >> 1) + 1;
			if ((Engine.g_moveNumber & 1) == 0)
			{
				int i = (Engine.g_moveNumber >> 1) + 1;
				richTextBox1.AppendText($"{i} ", Color.Red);
			}
			richTextBox1.AppendText($"{em} ");
			int gm = Engine.GetMoveFromString(em);
			CPieceBoard.MakeMove(gm);
			Engine.MakeMove(gm);
			labMove.Text = "Move " + moveNumber.ToString() + " " + Engine.g_move50.ToString();
			CHistory.moves.Add(em);
			int x = "abcdefgh".IndexOf(em[2]);
			int y = 8 - Int32.Parse(em[3].ToString());
			lastDes = y * 8 + x;
			//RenderBoard();
			CData.gameState = Engine.GetGameState();
			if (CData.gameState == 0)
				PlayerList.MakeMove();
			else
			{
				labLast.ForeColor = Color.Yellow;
				switch (CData.gameState)
				{
					case (int)CGameState.mate:
						labLast.Text = "Mate";
						break;
					case (int)CGameState.drawn:
						labLast.Text = "Stalemate";
						break;
					case (int)CGameState.repetition:
						labLast.Text = "Threefold repetition";
						break;
					case (int)CGameState.move50:
						labLast.Text = "'Fifty-move rule";
						break;
					case (int)CGameState.material:
						labLast.Text = "Insufficient material";
						break;
				}
			}
		}

		void NewGame()
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
			Engine.InitializeFromFen("");
			CData.gameState = 0;
			CHistory.NewGame(Engine.GetFen());
			var nw = comboBoxW.Text;
			PlayerList.player[0].SetUser(nw);
			var nb = comboBoxB.Text;
			PlayerList.player[1].SetUser(nb);
			IniFile.Write("white", nw);
			IniFile.Write("black", nb);
			PieceList.Fill();
			PlayerList.NewGame();
			timer1.Enabled = true;
		}

		void RenderBoard()
		{
			Color curColor = Engine.whiteTurn ? Color.White : Color.Black;
			string abc = "ABCDEFGH";
			boardRotate = PlayerList.player[1].IsHuman() && !PlayerList.player[0].IsHuman();
			if (PlayerList.player[1].IsHuman() && PlayerList.player[0].IsHuman())
				boardRotate = !PlayerList.CurPlayer().IsWhite();
			if (boardRotate)
			{
				labNameT.Text = PlayerList.player[0].user.name;
				labNameB.Text = PlayerList.player[1].user.name;
			}
			else
			{
				labNameT.Text = PlayerList.player[1].user.name;
				labNameB.Text = PlayerList.player[0].user.name;
			}
			if (boardRotate ^ Engine.whiteTurn)
			{
				panBottom.BackColor = curColor;
				panTop.BackColor = Color.Silver;
			}
			else
			{
				panTop.BackColor = curColor;
				panBottom.BackColor = Color.Silver;
			}
			field = (pictureBox1.Width - CPieceBoard.margin * 2) / 8;
			pictureBox1.Image = new Bitmap(CPieceBoard.bitmap);
			Graphics g = Graphics.FromImage(pictureBox1.Image);
			Brush brush3 = new SolidBrush(Color.FromArgb(0x80, 0xff, 0xff, 0x00));
			Font font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
			for (int y = 0; y < 8; y++)
			{
				int y2 = CPieceBoard.margin + y * field;
				if (boardRotate)
					y2 = y2 = CPieceBoard.margin + (7 - y) * field;
				string letter = (8 - y).ToString();
				SizeF size = g.MeasureString(letter, font);
				g.DrawString(letter, font, new SolidBrush(Color.White), (CPieceBoard.margin - size.Width) / 2, y2 + (field - size.Height) / 2);
				g.DrawString(letter, font, new SolidBrush(Color.White), pictureBox1.Width - size.Width - (CPieceBoard.margin - size.Width) / 2, y2 + (field - size.Height) / 2);
				for (int x = 0; x < 8; x++)
				{
					int i = y * 8 + x;
					int x2 = CPieceBoard.margin + x * field;
					if (boardRotate)
						x2 = CPieceBoard.margin + (7 - x) * field;
					letter = abc[x].ToString();
					size = g.MeasureString(letter, font);
					g.DrawString(letter, font, new SolidBrush(Color.White), x2 + (field - size.Width) / 2, (CPieceBoard.margin - size.Height) / 2);
					g.DrawString(letter, font, new SolidBrush(Color.White), x2 + (field - size.Width) / 2, pictureBox1.Height - size.Height - (CPieceBoard.margin - size.Height) / 2);
					if (i == lastDes)
						g.FillRectangle(brush3, x2, y2, field, field);
					CPiece piece = CPieceBoard.list[i];
					if (piece == null)
						continue;
					piece.SetDes(x2, y2);
					imageList1.Draw(g, piece.curXY, piece.image);
				}
			}
			brush3.Dispose();
			g.Dispose();
			pictureBox1.Refresh();
			if((CData.gameState > 0)&&(!CPieceBoard.animated))
				timer1.Enabled = false;
			CPieceBoard.Render();
		}

		bool TryMove(int s, int d)
		{
			int m = Engine.IsValidMove(s, d, "q");
			if (m == 0)
				return false;
			string em = Engine.FormatMove(m);
			MakeMove(em);
			return true;
		}

		private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			if (!PlayerList.CurPlayer().IsHuman())
				return;
			CPieceBoard.animated = true;
			int sou = lastDes;
			int x = (e.Location.X - CPieceBoard.margin) / field;
			int y = (e.Location.Y - CPieceBoard.margin) / field;
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
			PlayerList.player[0].PlayerEng.Kill();
			PlayerList.player[1].PlayerEng.Kill();
		}

		private void Timer1_Tick_1(object sender, EventArgs e)
		{
			if(CPieceBoard.animated)
				RenderBoard();
			var cp = PlayerList.CurPlayer();
			double dif = CData.gameState > 0 ? 0 : (DateTime.Now - cp.timeStart).TotalMilliseconds;
			if (!cp.IsHuman())
			{
				string msg = cp.PlayerEng.Reader.ReadLine();
				Uci.SetMsg(msg);
				if (Uci.command != "")
				{
					string s = Uci.GetValue("cp");
					if (s != "")
						cp.score = s;
					s = Uci.GetValue("mate");
					if (s != "")
					{
						if (Int32.Parse(s) > 0)
							cp.score = $"+{s}M";
						else
							cp.score = $"{s}M";
					}
					s = Uci.GetValue("depth");
					if (s != "")
						cp.depth = s;
					s = Uci.GetValue("seldepth");
					if (s != "")
						cp.seldepth = s;
					s = Uci.GetValue("nps");
					if (s != "")
						cp.nps = s;
					s = Uci.GetValue("ponder");
					if (s != "")
						cp.ponder = s;
					if (Uci.tokens[0] == "bestmove")
					{
						string em = Uci.tokens[1];
						MakeMove(em);
						dif = 0;
					}
					else
					{
						int i = Uci.GetIndex("pv", 0);
						if (i > 0)
						{
							string pv = "";
							for (int n = i; n < Uci.tokens.Length; n++)
								pv += Uci.tokens[n] + " ";
							labLast.Text = pv;
						}
					}
				}
			}
			DateTime tot = new DateTime().AddMilliseconds(cp.timeTotal + dif);
			if (boardRotate ^ cp.IsWhite())
			{
				labTimeB.Text = tot.ToString("HH:mm:ss");
				labScoreB.Text = $"Score {cp.score}";
				labNpsB.Text = $"Nps {cp.nps}";
				labPonderB.Text = $"Ponder {cp.ponder}";
				if (cp.seldepth != "0")
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
				labPonderT.Text = $"Ponder {cp.ponder}";
				if (cp.seldepth != "0")
					labDepthT.Text = $"Depth {cp.depth} / {cp.seldepth}";
				else
					labDepthT.Text = $"Depth {cp.depth}";
			}
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
			FPlayer.ShowDialog(this);
			Reset();
		}

		private void ButStop_Click(object sender, EventArgs e)
		{
			PlayerList.CurPlayer().SendMessage("stop");
		}

		private void PictureBox1_Click(object sender, EventArgs e)
		{

		}
	}

	public static class RichTextBoxExtensions
	{
		public static void AppendText(this RichTextBox box, string text, Color color)
		{
			box.SelectionStart = box.TextLength;
			box.SelectionLength = 0;

			box.SelectionColor = color;
			box.AppendText(text);
			box.SelectionColor = box.ForeColor;
		}

		public static void AddContextMenu(this RichTextBox rtb)
		{
			if (rtb.ContextMenuStrip == null)
			{
				ContextMenuStrip cms = new ContextMenuStrip()
				{
					ShowImageMargin = false
				};

				ToolStripMenuItem tsmiUndo = new ToolStripMenuItem("Undo");
				tsmiUndo.Click += (sender, e) => rtb.Undo();
				cms.Items.Add(tsmiUndo);

				ToolStripMenuItem tsmiRedo = new ToolStripMenuItem("Redo");
				tsmiRedo.Click += (sender, e) => rtb.Redo();
				cms.Items.Add(tsmiRedo);

				cms.Items.Add(new ToolStripSeparator());

				ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
				tsmiCut.Click += (sender, e) => rtb.Cut();
				cms.Items.Add(tsmiCut);

				ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
				tsmiCopy.Click += (sender, e) => rtb.Copy();
				cms.Items.Add(tsmiCopy);

				ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
				tsmiPaste.Click += (sender, e) => rtb.Paste();
				cms.Items.Add(tsmiPaste);

				ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Delete");
				tsmiDelete.Click += (sender, e) => rtb.SelectedText = "";
				cms.Items.Add(tsmiDelete);

				cms.Items.Add(new ToolStripSeparator());

				ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Select All");
				tsmiSelectAll.Click += (sender, e) => rtb.SelectAll();
				cms.Items.Add(tsmiSelectAll);

				cms.Opening += (sender, e) =>
				{
					tsmiUndo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
					tsmiRedo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
					tsmiCut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
					tsmiCopy.Enabled = rtb.SelectionLength > 0;
					tsmiPaste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
					tsmiDelete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
					tsmiSelectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
				};

				rtb.ContextMenuStrip = cms;
			}
		}
	}
}
