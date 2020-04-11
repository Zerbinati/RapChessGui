
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

		public string ShortName()
		{
			string n = name[0].ToString();
			return n.ToUpper();
		}

	}

	public static class CBookList
	{
		public static List<CBook> list = new List<CBook>();

		public static void Add(CBook br)
		{
			if (GetIndex(br.name) < 0)
				list.Add(br);
		}

		public static int GetIndex(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				CBook br = list[n];
				if (br.name == name)
					return n;
			}
			return -1;
		}

		public static void LoadFromIni()
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

		public static CBook GetBook(string name)
		{
			foreach (CBook br in list)
			if (br.name == name)
					return br;
			return null;
		}

		public static void SaveToIni()
		{
			CRapIni.This.DeleteKey("book");
			foreach (CBook br in list)
				br.SaveToIni();
		}

	}

}
