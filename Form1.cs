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
		const int margin = 16;
		int field = 0;
		CEngine Engine = new CEngine();
		CPlayerEng PlayerEng = new CPlayerEng();
		CPlayerList PlayerList = new CPlayerList();
		CUci Uci = new CUci();

		public FormChess()
		{
			InitializeComponent();
			PlayerEng.SetEngine("RapChessCs.exe","");
		}

		private void FormChess_Load(object sender, EventArgs e)
		{
			Engine.Initialize();
			comboBoxW.SelectedIndex = 1;
			comboBoxB.SelectedIndex = 0;
			NewGame();
		}

		void MakeMove(string em)
		{
			int gm = Engine.GetMoveFromString(em);
			Engine.MakeMove(gm);
			CHistory.moves.Add(em);
			int x = "abcdefgh".IndexOf(em[2]);
			int y = 8 - Int32.Parse(em[3].ToString());
			lastDes = y * 8 + x;
			RenderBoard();
			int state = Engine.GetGameState();
			if (state == 0)
				PlayerList.MakeMove();
			else
			{
				timer1.Enabled = false;
				panel1.BackColor = Color.Yellow;
				switch (state)
				{
					case (int)CGameState.mate:
						label1.Text = "Mate";
						break;
					case (int)CGameState.drawn:
						label1.Text = "Stalemate";
						break;
					case (int)CGameState.repetition:
						label1.Text = "Threefold repetition";
						break;
					case (int)CGameState.move50:
						label1.Text = "'Fifty-move rule";
						break;
					case (int)CGameState.material:
						label1.Text = "Insufficient material";
						break;
				}
			}
		}

		void NewGame()
		{
			panel1.BackColor = Color.WhiteSmoke;
			label1.Text = "Good luck";
			lastDes = -1;
			Engine.InitializeFromFen("");
			CHistory.NewGame(Engine.GetFen());
			if(comboBoxW.Text == "Computer" )
				PlayerList.player[0].PlayerEng = PlayerEng;
			else
				PlayerList.player[0].PlayerEng = null;
			if (comboBoxB.Text == "Computer")
				PlayerList.player[1].PlayerEng = PlayerEng;
			else
				PlayerList.player[1].PlayerEng = null;
			RenderBoard();
			PlayerList.NewGame();
			timer1.Enabled = true;
		}

		void RenderBoard()
		{
			string abc = "ABCDEFGH";
			boardRotate = PlayerList.player[1].IsHuman() && !PlayerList.player[0].IsHuman();
			field = (pictureBox1.Width - margin * 2) / 8;
			pictureBox1.Image = RapChessGui.Properties.Resources.black;
			Graphics g = Graphics.FromImage(pictureBox1.Image);
			Brush brush1 = new SolidBrush(Color.FromArgb(0x30, 0xff, 0xff, 0xff));
			Brush brush2 = new SolidBrush(Color.FromArgb(0x70, 0xff, 0xff, 0xff));
			Brush brush3 = new SolidBrush(Color.FromArgb(0x80, 0xff, 0xff, 0x00));
			Font font = new Font(FontFamily.GenericSansSerif,12, FontStyle.Regular);
			for (int y = 0; y < 8; y++)
			{
				int y2 = margin + y * field;
				if(boardRotate)
					y2 = y2 = margin + (7 - y) * field;
				string letter = (8-y).ToString();
				SizeF size = g.MeasureString(letter, font);
				g.DrawString(letter, font, new SolidBrush(Color.White),0, y2 + (field - size.Height) / 2);
				g.DrawString(letter, font, new SolidBrush(Color.White), pictureBox1.Width - size.Width - 4, y2 + (field - size.Height) / 2);
				for (int x = 0; x < 8; x++)
				{
					int x2 = margin + x * field;
					if(boardRotate)
						x2 = margin + (7 -x) * field;
					letter = abc[x].ToString() ;
					size = g.MeasureString(letter, font);
					g.DrawString(letter, font, new SolidBrush(Color.White), x2 + (field - size.Width) / 2, 0);
					g.DrawString(letter, font, new SolidBrush(Color.White), x2 + (field - size.Width) / 2, pictureBox1.Height - size.Height - 4);
					int i = y * 8 + x;
					bool bgColor = ((y ^ x) & 1) == 1;
					if (bgColor)
					{
						g.FillRectangle(brush1, x2, y2, field, field);
					}
					else
					{
						g.FillRectangle(brush2, x2, y2, field, field);
					}
					if (i == lastDes)
						g.FillRectangle(brush3, x2, y2, field, field);
					i = Engine.arrField[i];
					i = Engine.g_board[i];
					if ((i & CEngine.colorEmpty) > 0)
						continue;
					int p = (i & 7) - 1;
					if ((i & CEngine.colorBlack) > 0)
						p += 6;
					imageList1.Draw(g, new Point(x2, y2), p);
				}
			}
			brush1.Dispose();
			brush2.Dispose();
			brush3.Dispose();
			g.Dispose();
			pictureBox1.Refresh();
		}

		bool TryMove(int s, int d)
		{
			int m = Engine.TryMove(s, d, "q");
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
			int sou = lastDes;
			int x = (e.Location.X - margin) / field;
			int y = (e.Location.Y - margin) / field;
			if (boardRotate)
			{
				x = 7 - x;
				y = 7 - y;
			}
			lastDes = y * 8 + x;
			TryMove(sou, lastDes);
			RenderBoard();
		}

		private void FormChess_FormClosed(object sender, FormClosedEventArgs e)
		{
			PlayerEng.Kill();
		}

		private void Timer1_Tick_1(object sender, EventArgs e)
		{
			string msg = PlayerEng.Reader.ReadLine(false);
			if (msg == "") return;
			Uci.SetMsg(msg);
			if (Uci.tokens[0] == "bestmove")
			{
				string em = Uci.tokens[1];
				MakeMove(em);
			}
			else
			{
				int i = Uci.GetIndex("pv",0);
				if(i > 0)
				{
					string pv = "";
					for (int n = i; n < Uci.tokens.Length; n++)
						pv += Uci.tokens[n] + " ";
					label1.Text = pv;
				}
			}
		}

		private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewGame();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			NewGame();
		}
	}
}
