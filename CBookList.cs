
using System.Collections.Generic;
using System.IO;
using RapIni;

namespace RapChessGui
{

	public class CBook
	{
		public string name = "";
		public string file = "";
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
			return File.Exists("Books\\" + file);
		}

		public string GetParameters(CEngine e)
		{
			if (e == null)
				return "";
			return parameters.Replace("[engine]",e.name);
		}

		public void LoadFromIni()
		{
			file = CRapIni.This.Read($"book>{name}>file", "");
			parameters = CRapIni.This.Read($"book>{name}>parameters", "");
		}

		public void SaveToIni()
		{
			name = GetName();
			CRapIni.This.Write($"book>{name}>file", file);
			CRapIni.This.Write($"book>{name}>parameters", parameters);
		}

		public string GetName()
		{
			if (name != "")
				return name;
			string n = CData.MakeShort(Path.GetFileNameWithoutExtension(file));
			if (parameters.Length < 0xf)
				n = $"{n} {parameters}";
			return n;
		}

	}

	public class CBookList
	{
		public static string def = "BRU Eco";
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
			List<string> bl = CRapIni.This.ReadList("book");
			foreach (string name in bl)
			{
				var br = new CBook(name);
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
			CRapIni.This.DeleteKey("book");
			foreach (CBook br in list)
				br.SaveToIni();
		}

	}

}
