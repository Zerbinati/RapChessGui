using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RapChessGui
{
	enum CMode { game, match, tournament, training ,edit}

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
		public static bool rotateBoard = false;
		public static int gameState = 0;
		public static int gameMode = 0;
		public static int back = 0;
		public static double fps = 0;
		public static string modeName = "Game";
		public static string[] arrModeNames = new string[] { "depth", "movetime" };
		public static List<string> bookNames = new List<string>();
		public static List<string> engineNames = new List<string>();
		public static List<string> playerNames = new List<string>();
		public static List<string> bookReaderNames = new List<string>();

		public static int ModeStoi(string s)
		{
			for (int i = 0; i < arrModeNames.Length; i++)
				if (s == arrModeNames[i])
					return i;
			return 0;
		}

	}

	public class ListViewComparer : System.Collections.IComparer
	{
		private int ColumnNumber;
		private SortOrder SortOrder;

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
