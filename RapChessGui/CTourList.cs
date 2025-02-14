﻿using System;
using System.IO;
using System.Collections.Generic;

namespace RapChessGui
{
	class CTour
	{
		public string w;
		public string b;
		public string r = "d";
		public bool first;

		public CTour(string tw, string tb, string tr, bool tf)
		{
			w = tw;
			b = tb;
			r = tr;
			first = tf;
		}

		public CTour(string s)
		{
			LoadFromString(s);
		}

		public void LoadFromString(string s)
		{
			string[] a = s.Split('#');
			w = a[0];
			b = a[1];
			if (a.Length > 2)
				r = a[2];
			if (a.Length > 3)
				first = a[3] == "f";
		}

		public string SaveToString()
		{
			string sf = first ? "f" : "s";
			return $"{w}#{b}#{r}#{sf}";
		}

	}

	class CTourList
	{
		readonly string path;
		public List<CTour> list = new List<CTour>();

		public CTourList(string name)
		{
			path = $"{AppDomain.CurrentDomain.BaseDirectory}History\\{name}.his";
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

		public int LastGame(string p)
		{
			int f = list.Count;
			int s = list.Count;
			int c = 0;
			for (int n = list.Count - 1; n >= 0; n--)
			{
				c++;
				CTour t = list[n];
				if (t.w == p)
				{
					if (t.first)
					{
						if (f == list.Count)
						{
							f = c;
							if (s == list.Count)
								s = c;
						}
					}
					else if (s == list.Count)
						s = c;
				}
				if (t.b == p)
				{
					if (t.first)
					{
						if (s == list.Count)
							s = c;
					}
					else if (f == list.Count)
					{
						f = c;
						if (s == list.Count)
							s = c;
					}
				}
				if ((f < list.Count) && (s < list.Count))
					break;
			}
			return f + s >> 1;
		}

		public int CountGames(string p1, string p2, out int gw, out int gl, out int gd)
		{
			gw = 0;
			gl = 0;
			gd = 0;
			foreach (CTour t in list)
			{
				if ((t.w == p1) && (t.b == p2))
				{
					if (t.r == "d")
						gd++;
					if (t.r == "w")
						gw++;
					if (t.r == "b")
						gl++;
				}
				if ((t.w == p2) && (t.b == p1))
				{
					if (t.r == "d")
						gd++;
					if (t.r == "b")
						gw++;
					if (t.r == "w")
						gl++;
				}
			}
			return gw + gl + gd;
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
			string n = String.Empty;
			if (list.Count > 0)
				n = list[list.Count - 1].w;
			return FormChess.engineList.GetEngineByName(n);
		}

		public CPlayer LastPlayer()
		{
			string n = String.Empty;
			if (list.Count > 0)
				n = list[list.Count - 1].w;
			return FormChess.playerList.GetPlayerByName(n);
		}

		public void Write(string w, string b, string r, bool f)
		{
			if (w == b)
				return;
			CTour t = new CTour(w, b, r, f);
			list.Add(t);
			using (StreamWriter file = new StreamWriter(path, true))
				file.WriteLine(t.SaveToString());
		}

	}

}
