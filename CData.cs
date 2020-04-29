using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RapChessGui
{
	public enum CMode { game, match,tourE, tourP, training, edit }

	public static class CPromotion
	{
		public static string emo;
		public static int sou;
		public static int des;
	}

	public static class CDrag
	{
		public static bool dragged = false;
		public static int last = -1;
		public static int lastSou = -1;
		public static int lastDes = -1;
		public static int mouseX = 0;
		public static int mouseY = 0;
		public static int mouseIndex = 0;
	}

	public static class CData
	{
		public static bool reset = true;
		public static bool rotateBoard = false;
		public static CGameState gameState = CGameState.normal;
		public static CMode gameMode = CMode.game;
		public static int back = 0;
		public static double fps = 0;
		public static string fen = CChess.defFen;
		public static List<string> fileBook = new List<string>();
		public static List<string> fileEngine = new List<string>();

		public static void UpdateFileBook()
		{
			fileBook.Clear();
			string[] arrBooks = Directory.GetFiles("Books", "*.exe");
			for (int n = 0; n < arrBooks.Length; n++)
			{
				string fn = Path.GetFileName(arrBooks[n]);
				fileBook.Add(fn);
			}
		}

		public static void UpdateFileEngine()
		{
			fileEngine.Clear();
			string[] filePaths = Directory.GetFiles("Engines", "*.exe");
			for (int n = 0; n < filePaths.Length; n++)
			{
				string fn = Path.GetFileName(filePaths[n]);
				fileEngine.Add(fn);
			}
		}

	}

	public class CModeValue
	{
		public string mode = "Time";
		public int value = 0;
		public int increment = 0;

		public void SetValue(int v)
		{
			int increment = GetIncrement();
			if (increment > 0)
				value = v / increment;
		}

		public int GetValue()
		{
			return value * GetIncrement();
		}

		public int GetUciValue()
		{
			int result = value * GetIncrement();
			if (mode == "Standard")
				result *= 1000;
			return result;
		}

		public int GetIncrement()
		{
			switch (mode)
			{
				case "Standard":
					return 15;
				case "Depth":
					return 1;
				case "Nodes":
					return 100000;
				case "Infinite":
					return 0;
				default:
					return 100;
			}
		}

		public string GetUci()
		{
			switch (mode)
			{
				case "Standard":
					return "standard";
				case "Depth":
					return "depth";
				case "Nodes":
					return "nodes";
				case "Infinite":
					return "infinite";
				default:
					return "movetime";
			}
		}

		public void SetUci(string uci)
		{
			switch (uci)
			{
				case "standard":
					mode = "Standard";
					break;
				case "depth":
					mode = "Depth";
					break;
				case "nodes":
					mode = "Nodes";
					break;
				case "infinite":
					mode = "Infinite";
					break;
				default:
					mode = "Time";
					break;
			}
		}

		public string GetTip()
		{
			switch (mode)
			{
				case "Standard":
					return "Base for whole game in seconds";
				case "Depth":
					return "Depth in half-moves";
				case "Nodes":
					return "Maximum nodes per move";
				case "Infinite":
					return "Infinite mode until click stop";
				default:
					return "Time per move in miliseconds";
			}
		}

		public string ShortName()
		{
			string result = mode[0].ToString();
			if(mode !="Infinite")
				result = $"{result}{value}";
			return $" {result}";
		}

		public string LongName()
		{
			if(mode == "Standard")
			{
				int t = value * 15 + increment * 60;
				int m = value / 4;
				string min = m > 0 ? m.ToString() : "";
				string sec = new string[4] {"", "¼", "½", "¾"}[value % 4];
				string tim = $"{min}{sec}+{increment}";
				if (t > 21600)
					return $"Mail {tim}";
				if(t > 1800)
					return $"Classical {tim}";
				if (t > 600)
					return $"Rapid {tim}";
				if (t > 180)
					return $"Blitz {tim}";
				if (t > 30)
					return $"Bullet {tim}";
				return $"UltraBullet {tim}";
			}
			if (mode != "Infinite")
				return $"{mode} {value}";
			return mode;
		}

	} 

	public class ListViewComparer : System.Collections.IComparer
	{
		readonly private int ColumnNumber;
		readonly private SortOrder SortOrder;

		public ListViewComparer(int column_number,
			SortOrder sort_order)
		{
			ColumnNumber = column_number;
			SortOrder = sort_order;
		}

		public int Compare(object object_x, object object_y)
		{
			ListViewItem item_x = object_x as ListViewItem;
			ListViewItem item_y = object_y as ListViewItem;
			string string_x;
			if (item_x.SubItems.Count <= ColumnNumber)
			{
				string_x = "";
			}
			else
			{
				string_x = item_x.SubItems[ColumnNumber].Text;
			}

			string string_y;
			if (item_y.SubItems.Count <= ColumnNumber)
			{
				string_y = "";
			}
			else
			{
				string_y = item_y.SubItems[ColumnNumber].Text;
			}
			int result;
			if (double.TryParse(string_x, out double double_x) && double.TryParse(string_y, out double double_y))
			{
				result = double_x.CompareTo(double_y);
			}
			else
			{
				if (DateTime.TryParse(string_x, out DateTime date_x) &&
					DateTime.TryParse(string_y, out DateTime date_y))
				{
					result = date_x.CompareTo(date_y);
				}
				else
				{
					result = string_x.CompareTo(string_y);
				}
			}
			if (SortOrder == SortOrder.Ascending)
			{
				return result;
			}
			else
			{
				return -result;
			}
		}
	}
}
