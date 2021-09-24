
using System.Collections.Generic;
using System.IO;

namespace RapChessGui
{

	public class CBook
	{
		public string name = "";
		public string exe = "";
		public string parameters = "";

		public CBook()
		{
		}

		public CBook(string n)
		{
			name = n;
		}

		public bool FileExists()
		{
			return File.Exists($@"Books\{exe}");
		}

		public bool ParametersExists()
		{
			string[] tokens = parameters.Split(' ');
			if (tokens.Length > 0)
				return File.Exists($@"Books\{tokens[0]}");
			return false;
		}

		public bool ParametersExists(string p)
		{
			return parameters.IndexOf(p) == 0;
		}

		public string GetParameters(CEngine e)
		{
			if (e == null)
				return "";
			return parameters.Replace("[engine]", e.name);
		}

		public void LoadFromIni()
		{
			exe = FormChess.RapIni.Read($"book>{name}>exe", "");
			parameters = FormChess.RapIni.Read($"book>{name}>parameters", "");
		}

		public void SaveToIni()
		{
			name = GetName();
			FormChess.RapIni.Write($"book>{name}>exe", exe);
			FormChess.RapIni.Write($"book>{name}>parameters", parameters);
		}

		public string GetName()
		{
			if (name != "")
				return name;
			string n = CData.MakeShort(Path.GetFileNameWithoutExtension(exe));
			string[] tokens = parameters.Split(' ');
			if (tokens.Length > 0) {
				string p = tokens[0];
				p = Path.GetFileNameWithoutExtension(p);
				return $"{n} {p}";
			}
			return n;
		}

	}

	public class CBookList
	{
		public static string def = "Eco";
		public List<CBook> list = new List<CBook>();

		public void Add(CBook b)
		{
			b.name = b.GetName();
			int index = GetIndex(b.name);
			if (index >= 0)
				list[index] = b;
			else
				list.Add(b);
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

		public int LoadFromIni()
		{
			list.Clear();
			List<string> bl = FormChess.RapIni.ReadKeyList("book");
			foreach (string name in bl)
			{
				var br = new CBook(name);
				br.LoadFromIni();
				list.Add(br);
			}
			SaveToIni();
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
			FormChess.RapIni.DeleteKey("book");
			foreach (CBook br in list)
				br.SaveToIni();
		}

		void TryDel(string dir)
		{
			for (int n = list.Count - 1; n >= 0; n--)
			{
				CBook book = list[n];
				if (book.parameters.IndexOf(dir) == 0)
					if (!book.FileExists() || !book.ParametersExists())
						list.RemoveAt(n);
			}
		}

		bool ParametersExists(string p)
		{
			foreach (CBook book in list)
				if (book.ParametersExists(p))
					return true;
			return false;
		}

		void TryAdd(string br, string p)
		{
			if ((br != "none")&&!ParametersExists(p))
			{
				string fn = Path.GetFileName(p);
				CBook b = new CBook();
				//b.name = fn;
				b.exe = br;
				b.parameters = p;
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
			foreach (CDirBook db in FormChess.DirBookList)
				Update(db.dir, db.book);
			SaveToIni();
		}

	}

}
