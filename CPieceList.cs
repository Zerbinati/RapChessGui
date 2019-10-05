using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RapChessGui
{
	static class CPieceBoard
	{
		public static bool animated = true;
		public static CPiece[] list = new CPiece[64];
		public const int field = 64;
		public const int margin = 32;
		public const int size = field * 8 + margin * 2;
		public static Bitmap bitmap = new Bitmap(size,size);

		public static void Prepare()
		{
			Graphics g = Graphics.FromImage(bitmap);
			g.DrawImage(RapChessGui.Properties.Resources.black, 0, 0, size, size);
			Brush brush1 = new SolidBrush(Color.FromArgb(0x30, 0xff, 0xff, 0xff));
			Brush brush2 = new SolidBrush(Color.FromArgb(0x70, 0xff, 0xff, 0xff));
			Font font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
			for (int y = 0; y < 8; y++)
			{
				int y2 = margin + y * field;
				for (int x = 0; x < 8; x++)
				{
					int i = y * 8 + x;
					int x2 = margin + x * field;
					bool bgColor = ((y ^ x) & 1) == 1;
					if (bgColor)
					{
						g.FillRectangle(brush1, x2, y2, field, field);
					}
					else
					{
						g.FillRectangle(brush2, x2, y2, field, field);
					}
				}
			}
		}

		static void MakeMove(int sou,int des)
		{
			list[des] = list[sou];
			list[sou] = null;
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
			MakeMove(sou,des);
			if ((flags & CEngine.moveflagCastleKing) > 0)
			{
				MakeMove(sou + 3,sou+1);
			}
			if ((flags & CEngine.moveflagCastleQueen) > 0)
			{
				MakeMove(sou -4, sou - 1);
			}
		}

		public static void Render()
		{
			animated = false;
			for(int n = 0; n < 64; n++)
			{
				var p = list[n];
				if (p != null)
					if (p.Render())
						animated = true;
			}
		}
	}

	class CPiece{
		bool visible = false;
		public int image = 0;
		public Point curXY = new Point();
		Point souXY = new Point();
		Point desXY = new Point();
		DateTime dt;
		double time = 200;

		public bool Render()
		{
			if ((curXY.X == desXY.X) && (curXY.Y == desXY.Y))
				return false;
			double dif = (DateTime.Now - dt).TotalMilliseconds / time;
			if(dif >= 1)
			{
				curXY.X = desXY.X;
				curXY.Y = desXY.Y;
			}
			else
			{
				curXY.X = Convert.ToInt32(souXY.X * (1 - dif) + desXY.X * dif);
				curXY.Y = Convert.ToInt32(souXY.Y * (1 - dif) + desXY.Y * dif);
			}
			return true;
		}

		public void SetDes(int x,int y)
		{
			if (!visible)
			{
				visible = true;
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

	class CPieceList
	{
		public void Fill()
		{
			for (int n = 0; n < 64; n++)
			{
				CPieceBoard.list[n] = null;
				int i = CEngine.arrField[n];
				int f = CEngine.g_board[i];
				if ((f & CEngine.colorEmpty) > 0)
					continue;
				int image = (f & 7) - 1;
				if ((f & CEngine.colorBlack) > 0)
					image += 6;
				CPiece piece = new CPiece();
				piece.image = image;
				CPieceBoard.list[n] = piece;
			}
			CPieceBoard.animated = true;
		}

	}
}
