
using System;
using System.Collections.Generic;
using System.IO;
using RapIni;

namespace RapChessGui
{

	public class CBook
	{
		public int position = 0;
		public int tournament = 1;
		public string name = "";
		public string file = "";
		public string parameters = "";
		public string elo = "1500";
		public CHisElo hisElo = new CHisElo();

		public CBook()
		{
		}

		public CBook(string n)
		{
			name = n;
		}

		public bool FileExists()
		{
			return File.Exists($@"Books\{file}");
		}

		public bool ParametersExists()
		{
			return File.Exists($@"Books\{parameters}");
		}

		public bool ParametersExists(string p)
		{
			return parameters.IndexOf(p) == 0;
		}

		public string GetFileName()
		{
			return $@"{AppDomain.CurrentDomain.BaseDirectory}Books\{file}";
		}

		public string GetParameters(CEngine e = null)
		{
			string p = parameters;
			if (e != null)
				p = p.Replace("[engine]", e.name);
			p = p.Replace("[uci]", $@"{Directory.GetCurrentDirectory()}\engines\uci\");
			return p;
		}

		public void LoadFromIni()
		{
			file = CBookList.iniFile.Read($"book>{name}>exe", "");
			parameters = CBookList.iniFile.Read($"book>{name}>parameters", "");
			elo = CBookList.iniFile.Read($"book>{name}>elo", elo);
			hisElo.LoadFromStr(CBookList.iniFile.Read($"book>{name}>history"));
			tournament = CBookList.iniFile.ReadInt($"book>{name}>tournament", tournament);
		}

		public void SaveToIni()
		{
			name = GetName();
			CBookList.iniFile.Write($"book>{name}>exe", file);
			CBookList.iniFile.Write($"book>{name}>parameters", parameters);
			CBookList.iniFile.Write($"book>{name}>elo", elo);
			CBookList.iniFile.Write($"book>{name}>history", hisElo.SaveToStr());
			CBookList.iniFile.Write($"book>{name}>tournament", tournament);
		}


		public int GetDeltaElo()
		{
			int e = GetElo();
			return e - hisElo.EloAvg(e);
		}

		public int GetElo()
		{
			return Convert.ToInt32(elo);
		}

		public string CreateName()
		{
			string n = CData.MakeShort(Path.GetFileNameWithoutExtension(file));
			string[] tokens = parameters.Split(' ');
			if (tokens.Length > 0)
			{
				string p = tokens[0];
				p = Path.GetFileNameWithoutExtension(p);
				return $"{n} {p}";
			}
			return n;
		}

		public string GetName()
		{
			if (name == "")
				return CreateName();
			return name;
		}

	}

	public class CBookList
	{
		public static string def = "Eco";
		public List<CBook> list = new List<CBook>();
		public static CRapIni iniFile = new CRapIni(@"Ini\books.ini");

		public void Add(CBook b)
		{
			b.name = b.GetName();
			int index = GetIndex(b.name);
			if (index >= 0)
				list[index] = b;
			else
				list.Add(b);
		}

		public void DeleteBook(string name)
		{
			iniFile.DeleteKey($"book>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				list.RemoveAt(i);
		}

		public void FillPosition()
		{
			for (int n = 0; n < list.Count; n++)
				list[n].position = n;
		}

		public int GetIndex(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				CBook br = list[n];
				if (br.name == name)
					return n;
			}
			return -1;
		}

		public int GetOptElo(double index)
		{
			int min = CModeTournamentB.minElo;
			int max = CModeTournamentB.maxElo;
			if (index < 0)
				index = 0;
			if (index >= list.Count)
				index = list.Count - 1;
			int range = max - min;
			index = list.Count - index;
			return min + Convert.ToInt32((range * (index + 1)) / (list.Count + 2));
		}

		public int LoadFromIni()
		{
			list.Clear();
			List<string> bl = CBookList.iniFile.ReadKeyList("book");
			foreach (string name in bl)
			{
				CBook br = new CBook(name);
				br.LoadFromIni();
				list.Add(br);
			}
			return bl.Count;
		}

		public CBook GetBook(string name)
		{
			foreach (CBook br in list)
				if (br.name == name)
					return br;
			return null;
		}

		public void SaveToIni()
		{
			iniFile.DeleteKey("book");
			foreach (CBook b in list)
				b.SaveToIni();
		}

		public CBook NextTournament(CBook b, bool rotate = true, bool back = false)
		{
			SortElo();
			int i = GetIndex(b.name);
			for (int n = 0; n < list.Count - 1; n++)
			{
				if (back)
					i--;
				else
					i++;
				if (rotate)
					i = (i + list.Count) % list.Count;
				else
					if ((i < 0) || (i >= list.Count))
					return null;
				b = list[i];
				if (b.tournament > 0)
					break;
			}
			return b;
		}

		void TryDel(string dir)
		{
			for (int n = list.Count - 1; n >= 0; n--)
			{
				CBook book = list[n];
				if (book.parameters.IndexOf(dir) == 0)
					if (!book.FileExists() || !book.ParametersExists())
						DeleteBook(book.name);
			}
		}

		bool ParametersExists(string p)
		{
			foreach (CBook book in list)
				if (book.ParametersExists(p))
					return true;
			return false;
		}

		public void SortPosition(CBook book)
		{
			SortElo();
			FillPosition();
			int position = book.position;
			foreach (CBook b in list)
				b.position = Math.Abs(position - b.position);
			list.Sort(delegate (CBook b1, CBook b2)
			{
				return b1.position - b2.position;
			});
		}

		public void SortElo()
		{
			list.Sort(delegate (CBook b1, CBook b2)
			{
				int result = b2.GetElo() - b1.GetElo();
				if (result != 0)
					return result;
				result = b2.hisElo.EloAvg() - b1.hisElo.EloAvg();
				if (result != 0)
					return result;
				return String.Compare(b1.name, b2.name, comparisonType: StringComparison.OrdinalIgnoreCase);
			});
		}

		void TryAdd(string bf, string bp)
		{
			if ((bf != "None") && !ParametersExists(bp))
			{
					CBook b = new CBook();
					b.file = bf;
					b.parameters = bp;
					b.name = b.GetName();
					list.Add(b);
			}
		}

		void Update(string dir, string br)
		{
			TryDel(dir);
			string path = $@"Books\{dir}";
			string[] arrBooks = Directory.GetFiles(path);
			foreach (string b in arrBooks)
			{
				string fn = Path.GetFileName(b);
				TryAdd(br, $@"{dir}\{fn}");
			}
		}

		public void Update()
		{
			foreach (CDirBook db in FormChess.dirBookList)
				Update(db.dir, db.book);
			SaveToIni();
		}

	}

}
