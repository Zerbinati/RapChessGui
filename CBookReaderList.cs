
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CBookReader
	{
		public string name = "";
		public string file = "";
		public string parameters = "";

		public CBookReader(string n)
		{
			name = n;
		}

		public void LoadFromIni()
		{
			file = CRapIni.This.Read($"reader>{name}>file", "");
			parameters = CRapIni.This.Read($"reader>{name}>parameters", "");
		}

		public void SaveToIni()
		{
			CRapIni.This.Write($"reader>{name}>file", file);
			CRapIni.This.Write($"reader>{name}>parameters", parameters);
		}

	}

	public static class CBookReaderList
	{
		public static List<CBookReader> list = new List<CBookReader>();

		public static void Add(CBookReader br)
		{
			if (GetIndex(br.name) < 0)
				list.Add(br);
		}

		public static int GetIndex(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				CBookReader br = list[n];
				if (br.name == name)
					return n;
			}
			return -1;
		}

		public static void LoadFromIni()
		{
			list.Clear();
			List<string> pn = CRapIni.This.ReadList("reader");
			foreach (string name in pn)
			{
				var br = new CBookReader(name);
				br.LoadFromIni();
				list.Add(br);
			}
		}

		public static CBookReader GetReader(string name)
		{
			foreach (CBookReader br in list)
			if (br.name == name)
					return br;
			return null;
		}

		public static void SaveToIni()
		{
			foreach (CBookReader br in list)
				br.SaveToIni();
		}

	}

}
