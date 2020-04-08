using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{
	class CPiece
	{
		bool animated = false;
		public int desImage = -1;
		public int image = -1;
		public Point curXY = new Point();
		public Point souXY = new Point();
		public Point desXY = new Point();
		public DateTime dt;

		public bool Render()
		{
			if ((curXY.X == desXY.X) && (curXY.Y == desXY.Y))
				return false;
			int speed = Convert.ToInt32(FormOptions.This.nudSpeed.Value);
			double dif = (DateTime.Now - dt).TotalMilliseconds / speed;
			if (dif >= 1)
			{
				curXY.X = desXY.X;
				curXY.Y = desXY.Y;
				desImage = -1;
			}
			else
			{
				curXY.X = Convert.ToInt32(souXY.X * (1 - dif) + desXY.X * dif);
				curXY.Y = Convert.ToInt32(souXY.Y * (1 - dif) + desXY.Y * dif);
			}
			return true;
		}

		public void SetImage(int index)
		{
			desImage = -1;
			int i = CChess.arrField[index];
			int f = CChess.g_board[i];
			image = (f & 7) - 1;
			if ((f & CChess.colorBlack) > 0)
				image += 6;
		}

		public void SetDes(int x, int y)
		{
			if (!animated)
			{
				animated = true;
				curXY.X = x;
				curXY.Y = y;
			}
			if ((x == desXY.X) && (y == desXY.Y))
				return;
			souXY.X = curXY.X;
			souXY.Y = curXY.Y;
			dt = DateTime.Now;
			desXY.X = x;
			desXY.Y = y;
		}
	}

	class CField
	{
		public bool attacked = false;
		public Color color = Color.Empty;
		public CPiece piece = null;
	}

	static class CArrow
	{
		public static bool visible = false;
		public static Point a;
		public static Point b;

		public static void Hide()
		{
			visible = false;
		}

		public static void SetAB(int ax, int ay, int bx, int by)
		{
			visible = true;
			a.X = ax;
			a.Y = ay;
			b.X = bx;
			b.Y = by;
		}

		public static void SetAB(int a, int b)
		{
			int ax = a & 7;
			int ay = a >> 3;
			int bx = b & 7;
			int by = b >> 3;
			SetAB(ax, ay, bx, by);
		}

		public static bool Visible()
		{
			return visible && ((a.X != b.X) || (a.Y != b.Y));
		}

	}

	static class CBoard
	{
		public static bool animated = true;
		public static bool finished = true;
		public static bool showArrow = false;
		public static CField[] list = new CField[64];
		public static int field = 64;
		public static int marginW = 32;
		public static int marginH = 32;
		public static int sizeW = field * 8 + marginW * 2;
		public static int sizeH = field * 8 + marginH * 2;
		public static Bitmap[] bitmap = new Bitmap[2];
		public static Bitmap board;
		public static Color color;

		public static void Init()
		{
			for (int n = 0; n < 64; n++)
				list[n] = new CField();
		}

		public static void Clear()
		{
			for (int n = 0; n < 64; n++)
				list[n].color = Color.Empty;
		}

		public static Point GetMiddle(int x, int y)
		{
			int xr = FormChess.boardRotate ? 7 - x : x;
			int yr = FormChess.boardRotate ? 7 - y : y;
			x = marginW + xr * field + (field >> 1);
			y = marginH + yr * field + (field >> 1);
			return new Point(x, y);
		}

		public static Point GetMiddle(Point p)
		{
			return GetMiddle(p.X, p.Y);
		}

		public static void UpdateField(int index)
		{
			int i = CChess.arrField[index];
			int f = CChess.g_board[i];
			if ((f & CChess.colorEmpty) > 0)
				list[index].piece = null;
			else
			{
				CPiece piece = new CPiece();
				list[index].piece = piece;
				piece.SetImage(index);
			}
		}

		public static void Fill()
		{
			for (int n = 0; n < 64; n++)
				UpdateField(n);
			animated = true;
		}

		public static void Prepare(int index)
		{
			string abc = "ABCDEFGH";
			Rectangle rec = new Rectangle();
			Bitmap bmp = new Bitmap(sizeW, sizeH);
			Graphics g = Graphics.FromImage(bmp);
			SolidBrush brush1 = new SolidBrush(color);
			SolidBrush brush2 = new SolidBrush(Color.FromArgb(0x60, 0x00, 0x00, 0x00));
			SolidBrush brush3 = new SolidBrush(Color.FromArgb(0x60, 0xff, 0xff, 0xff));
			Font font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold);
			GraphicsPath gp = new GraphicsPath();
			StringFormat sf = new StringFormat();
			Brush foreBrush = new SolidBrush(Color.White);
			Pen outline = new Pen(Color.Black, 4);
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.FillRectangle(brush1, 0, 0, sizeW, sizeH);
			for (int y = 0; y < 8; y++)
			{
				int y2 = marginH + y * field;
				for (int x = 0; x < 8; x++)
				{
					int x2 = marginW + x * field;
					bool bgColor = ((y ^ x) & 1) == 1;
					if (bgColor)
					{
						g.FillRectangle(brush2, x2, y2, field, field);
					}
					else
					{
						g.FillRectangle(brush3, x2, y2, field, field);
					}
				}
			}
			for (int n = 0; n < 8; n++)
			{
				int xr = index == 1 ? 7 - n : n;
				int yr = index == 1 ? 7 - n : n;
				int x2 = marginW + xr * field;
				int y2 = marginH + yr * field;
				rec.X = 0;
				rec.Y = y2;
				rec.Width = marginW;
				rec.Height = field;
				string letter = (8 - n).ToString();
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.X = bmp.Width - marginW;
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.X = x2;
				rec.Y = 0;
				rec.Width = field;
				rec.Height = marginH;
				letter = abc[n].ToString();
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
				rec.Y = bmp.Height - marginH;
				gp.AddString(letter, font.FontFamily, (int)font.Style, font.Size, rec, sf);
			}
			g.DrawPath(outline, gp);
			g.FillPath(foreBrush, gp);
			bitmap[index] = new Bitmap(bmp);
			brush1.Dispose();
			brush2.Dispose();
			brush3.Dispose();
			bmp.Dispose();
			g.Dispose();
			gp.Dispose();
			sf.Dispose();
			font.Dispose();
			foreBrush.Dispose();
			outline.Dispose();
		}

		public static void Prepare(int w, int h)
		{
			int min = Math.Min(w, h);
			field = min / 9;
			marginW = (w - (field * 8)) >> 1;
			marginH = (h - (field * 8)) >> 1;
			sizeW = w;
			sizeH = h;
			Prepare(0);
			Prepare(1);
		}

		static void MakeMove(int sou, int des)
		{
			list[des].piece = list[sou].piece;
			list[sou].piece = null;
		}

		public static void MakeMove(int gm)
		{
			animated = true;
			int flags = gm & 0xFF0000;
			int sou = gm & 0xFF;
			int des = (gm >> 8) & 0xFF;
			int xs = (sou & 0xf) - 4;
			int ys = (sou >> 4) - 4;
			int xd = (des & 0xf) - 4;
			int yd = (des >> 4) - 4;
			sou = ys * 8 + xs;
			des = yd * 8 + xd;
			CPiece pd = list[des].piece;
			if (pd != null)
				list[sou].piece.desImage = pd.image;
			MakeMove(sou, des);
			if ((flags & CChess.moveflagCastleKing) > 0)
			{
				MakeMove(sou + 3, sou + 1);
			}
			if ((flags & CChess.moveflagCastleQueen) > 0)
			{
				MakeMove(sou - 4, sou - 1);
			}
			Clear();
		}

		public static void Render()
		{
			animated = false;
			for (int n = 0; n < 64; n++)
			{
				CPiece p = list[n].piece;
				if (p != null)
					if (p.Render())
						animated = true;
			}
		}

		public static void SetImage()
		{
			for (int n = 0; n < 64; n++)
			{
				int i = CChess.arrField[n];
				int f = CChess.g_board[i];
				if ((f & CChess.colorEmpty) > 0)
					list[n].piece = null;
				else
					list[n].piece.SetImage(n);
			}
		}

		public static void ShowAttack(bool show, bool white)
		{
			List<int> ml = CChess.This.GenerateAllMoves(white, false);
			foreach (int m in ml)
			{
				int d = (m >> 8) & 0xff;
				int r = CChess.g_board[d] & 7;
				if (r > 0)
					if (show || (r == CChess.pieceKing))
					{
						int i = CChess.Con256To64(d);
						list[i].attacked = true;
					}
			}
		}

		public static void ClearAttack()
		{
			for (int n = 0; n < 64; n++)
				list[n].attacked = false;
		}

		public static void ShowAttack(bool show)
		{
			ClearAttack();
			if (show)
				ShowAttack(show, CChess.whiteTurn);
			ShowAttack(show, !CChess.whiteTurn);
		}

	}

}
