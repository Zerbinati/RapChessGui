using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RapChessGui
{
	public enum CGameMode { game, match,tourE, tourP, training, edit }

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
		public static CGameMode gameMode = CGameMode.game;
		public static int back = 0;
		public static double fps = 0;
		public static List<string> fileBook = new List<string>();
		public static List<string> fileEngine = new List<string>();

		public static void HisToPoints(CHisElo he, DataPointCollection po)
		{
			po.Clear();
			int x = 100 - he.list.Count;
			foreach (double v in he.list)
				po.AddXY(x++,v);
		}

		public static string MakeShort(string name)
		{
			string result = "";
			for (int n = 0; n < name.Length; n++)
			{
				char c = name[n];
				if ((n == 0) || Char.IsUpper(c) || Char.IsNumber(c))
					result += Char.ToUpper(c);
			}
			return result;
		}

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

	public class CHisElo
	{
		public List<double> list = new List<double>(100);

		public void Assign(CHisElo he)
		{
			list = new List<double>(he.list);
		}

		public int EloAvg(int def = 0) {
			int sum = 0;
			foreach (int i in list)
				sum += i;
			return list.Count == 0 ? def : sum / list.Count;
		}

		public Color GetColor()
		{
			double elo =Last();
			MinMax(out double min, out double max);
			double q = (max - min) / 10;
			if (elo > max - q)
				return Color.FromArgb(0xe0, 0xff, 0xe0);
			if (elo < min + q)
				return Color.FromArgb(0xff, 0xe0, 0xe0);
			return Color.White;
		}

		public void LoadFromStr(string elo)
		{
			list.Clear();
			string[] his = elo.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string e in his)
				Add(Convert.ToDouble(e));
		}

		public string SaveToStr()
		{
			string elo = "";
			foreach (double e in list)
				elo += $" {e}";
			return elo.Trim(' ');
		}

		public void Add(double value)
		{
			list.Add(value);
			int c = list.Count - 100;
			if (c > 0)
				list.RemoveRange(0,c);
		}

		public int Add(int value,int min,int max)
		{
			if (value < min)
				value = min;
			if (value > max)
				value = max;
			Add(value);
			return value;
		}

		public double Last()
		{
			if (list.Count > 0)
				return list[list.Count - 1];
			else
				return 0;
		}

		public void MinMax(out double min,out double max)
		{
			min = list.Count > 0 ? list[0] : 0;
			max = min;
			foreach(double d in list)
			{
				if (min > d)
					min = d;
				if (max < d)
					max = d;
			}
		}

	}

	public class CModeValue
	{
		public string mode = "Time";
		public int value = 10;
		public int increment = 100;
		public int inc = 0;

		public void SetValue(int v)
		{
			int inc = GetValueIncrement();
			if (inc > 0)
				value = v / inc;
			else
				value = 0;
		}

		public int GetValue()
		{
			int inc = GetValueIncrement();
			return value > 0 ? value * inc : inc;
		}

		public int GetUciValue()
		{
			int result = value * GetValueIncrement();
			if (mode == "Standard")
				result *= 1000;
			return result;
		}

		public int GetValueIncrement()
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
				int t = value * 15 + inc * 60;
				int m = value / 4;
				string min = m > 0 ? m.ToString() : "";
				string sec = new string[4] {"", "¼", "½", "¾"}[value % 4];
				string tim = $"{min}{sec}+{inc}";
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
