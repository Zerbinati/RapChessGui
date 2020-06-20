
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CBook
	{
		public string name = "";
		public string file = "";
		public string parameters = "";

		public CBook(string n)
		{
			name = n;
		}

		public void LoadFromIni()
		{
			file = CRapIni.This.Read($"book>{name}>file", "");
			parameters = CRapIni.This.Read($"book>{name}>parameters", "");
		}

		public void SaveToIni()
		{
			CRapIni.This.Write($"book>{name}>file", file);
			CRapIni.This.Write($"book>{name}>parameters", parameters);
		}

	}

	public class CBookList
	{
		public List<CBook> list = new List<CBook>();

		public void Add(CBook br)
		{
			if (GetIndex(br.name) < 0)
				list.Add(br);
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

		public void LoadFromIni()
		{
			list.Clear();
			List<string> pn = CRapIni.This.ReadList("book");
			foreach (string name in pn)
			{
				var br = new CBook(name);
				br.LoadFromIni();
				list.Add(br);
			}
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
