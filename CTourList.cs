using System;
using System.IO;
using System.Collections.Generic;

namespace RapChessGui
{
	class CTour
	{
		public string w = "";
		public string b = "";
		public string r = "";

		public CTour(string tw, string tb, string tr)
		{
			w = tw;
			b = tb;
			r = tr;
		}

		public CTour(string s)
		{
			LoadFromString(s);
		}

		public void LoadFromString(string s)
		{
			string[] a = s.Split('#');
			if (a.Length == 3)
			{
				w = a[0];
				b = a[1];
				r = a[2];
			}
		}

		public string SaveToString()
		{
			return $"{w}#{b}#{r}";
		}

	}

	class CTourList
	{
		readonly string path;
		public List<CTour> list = new List<CTour>();

		public CTourList(string name)
		{
			path = $"{AppDomain.CurrentDomain.BaseDirectory}{name}.his";
			LoadFromFile();
		}

		public int CountGames(string p)
		{
			int result = 0;
			foreach (CTour t in list)
				if ((t.w == p) || (t.b == p))
					result++;
			return result;
		}

		public void CountGames(string p1, string p2, out int rw, out int rl, out int rd)
		{
			rw = 0;
			rl = 0;
			rd = 0;
			foreach (CTour t in list)
			{
				if ((t.w == p1) && (t.b == p2))
				{
					if (t.r == "d")
						rd++;
					if (t.r == "w")
						rw++;
					if (t.r == "b")
						rl++;
				}
				if ((t.w == p2) && (t.b == p1))
				{
					if (t.r == "d")
						rd++;
					if (t.r == "b")
						rw++;
					if (t.r == "w")
						rl++;
				}
			}
		}

		public int DeletePlayer(string p)
		{
			int c = list.Count;
			for (int n = list.Count - 1; n >= 0; n--)
			{
				CTour t = list[n];
				if ((t.w == p) || (t.b == p))
					list.RemoveAt(n);
			}
			SaveToFile();
			return c - list.Count;
		}

		public void LoadFromFile()
		{
			list.Clear();
			if (File.Exists(path))
				using (StreamReader file = new StreamReader(path))
				{
					string line;
					while ((line = file.ReadLine()) != null)
					{
						CTour t = new CTour(line);
						if (t.r != "")
							list.Add(t);
					}
				}
		}

		public void SetLimit(int limit)
		{
			if (list.Count > limit)
			{
				int remove = Math.Max(0, list.Count - limit);
				list.RemoveRange(0, remove);
				SaveToFile();
			}
		}

		public void SaveToFile()
		{
			using (StreamWriter file = new StreamWriter(path))
			{
				foreach (CTour t in list)
					file.WriteLine(t.SaveToString());
			}
		}

		public CEngine LastEngine()
		{
			string n = "";
			if (list.Count > 0)
				n = list[list.Count - 1].w;
			return FormChess.engineList.GetEngine(n);
		}

		public CPlayer LastPlayer()
		{
			string n = "";
			if (list.Count > 0)
				n = list[list.Count - 1].w;
			return FormChess.playerList.GetPlayer(n);
		}

		public void Write(string w, string b, string r)
		{
			CTour t = new CTour(w, b, r);
			list.Add(t);
			using (StreamWriter file = new StreamWriter(path, true))
				file.WriteLine(t.SaveToString());
		}

	}

}
