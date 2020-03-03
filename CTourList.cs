using System;
using System.IO;
using System.Collections.Generic;

namespace RapChessGui
{
	class CTour
	{
		public string w;
		public string b;
		public string r;

		public CTour()
		{

		}

		public CTour(string tw,string tb,string tr)
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
			w = a[0];
			b = a[1];
			r = a[2];
		}

		public string SaveToString()
		{
			return $"{w}#{b}#{r}";
		}

	}

	class CTourList
	{
		string path = $"{AppDomain.CurrentDomain.BaseDirectory}tournament.txt";
		public List<CTour> list = new List<CTour>();

		public CTourList()
		{
			LoadFromFile();
		}

		public int CountGames(string p1,string p2,ref double r)
		{
			int result = 0;
			int rw = 0;
			int rd = 0;
			foreach (CTour t in list)
			{
				if ((t.w == p1) && (t.b == p2))
				{
					if (t.r == "d")
						rd++;
					if (t.r == "w")
						rw++;
					result++;
				}
				if ((t.w == p2) && (t.b == p1))
				{
					if (t.r == "d")
						rd++;
					if (t.r == "b")
						rw++;
					result++;
				}
			}
			r = 0;
			if(result >0)
			r = (rw + rd * 0.5)/ result;
			return result;
		}

		public void LoadFromFile()
		{
			list.Clear();
			if(File.Exists(path))
			using (StreamReader file = new StreamReader(path))
			{
				string line;
				while ((line = file.ReadLine()) != null)
				{
					CTour t = new CTour(line);
					list.Add(t);
				}
			}
			if(list.Count > 10000)
			{
				int remove = Math.Max(0, list.Count - 10000);
				list.RemoveRange(0, remove);
				SaveToFile();
			}
		}

		public void SaveToFile()
		{
			using (StreamWriter file =new StreamWriter(path))
			{
				foreach (CTour t in list)
				file.WriteLine(t.SaveToString());
			}
		}

		public void Write(string w,string b,string r)
		{
			CTour t = new CTour(w,b,r);
			list.Add(t);
			using (StreamWriter file = new StreamWriter(path,true))
				file.WriteLine($"{w}#{b}#{r}");
		}

	}

}
