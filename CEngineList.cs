using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{
	public class CEngine
	{
		public string name = "Human";
		public string file = "";
		public string protocol = "Uci";
		public string parameters = "";
		public List<string> options = new List<string>();

		public CEngine(string n)
		{
			name = n;
		}

		public void LoadFromIni()
		{
			file = CRapIni.This.Read($"engine>{name}>file", "Human");
			protocol = CRapIni.This.Read($"engine>{name}>protocol", "Uci");
			parameters = CRapIni.This.Read($"engine>{name}>parameters", "");
			options = CRapIni.This.ReadList($"engine>{name}>options");
		}

		public void SaveToIni()
		{
			CRapIni.This.Write($"engine>{name}>file", file);
			CRapIni.This.Write($"engine>{name}>protocol", protocol);
			CRapIni.This.Write($"engine>{name}>parameters", parameters);
			CRapIni.This.WriteList($"engine>{name}>options", options);
		}
	}

	static class CEngineList
	{
		public static List<CEngine> list = new List<CEngine>();

		public static void Add(CEngine e)
		{
			if (GetIndex(e.name) < 0)
				list.Add(e);
		}

		public static void DeleteEngine(string name)
		{
			CRapIni.This.DeleteKey($"engine>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				list.RemoveAt(i);
		}

		public static CEngine GetEngine(string name)
		{
			foreach (CEngine e in list)
				if (e.name == name)
					return e;
			return null;
		}

		public static int GetIndex(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				CEngine engine = list[n];
				if (engine.name == name)
					return n;
			}
			return -1;
		}

		public static void LoadFromIni()
		{
			list.Clear();
			List<string> en = CRapIni.This.ReadList("engine");
			foreach (string name in en)
			{
				CEngine engine = new CEngine(name);
				engine.LoadFromIni();
				list.Add(engine);
			}
		}

		public static void SaveToIni()
		{
			CRapIni.This.DeleteKey("engine");
			foreach (CEngine e in list)
				e.SaveToIni();
		}

	}

}
