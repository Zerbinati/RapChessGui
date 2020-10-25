using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{
	public class CEngine
	{
		public bool tournament = true;
		public bool modeStandard = true;
		public int distance = 0;
		public int position = 0;
		public double eloOld = 1000;
		public string name = "Human";
		public string file = "";
		public string protocol = "Uci";
		public string parameters = "";
		public string elo = "1000";
		public List<string> options = new List<string>();
		public CHisElo hisElo = new CHisElo();

		public CEngine(string n)
		{
			name = n;
		}

		public void LoadFromIni()
		{
			tournament = CRapIni.This.ReadBool($"engine>{name}>tournament", tournament);
			modeStandard = CRapIni.This.ReadBool($"engine>{name}>modeStandard", modeStandard);
			file = CRapIni.This.Read($"engine>{name}>file", "Human");
			protocol = CRapIni.This.Read($"engine>{name}>protocol", "Uci");
			parameters = CRapIni.This.Read($"engine>{name}>parameters", "");
			options = CRapIni.This.ReadList($"engine>{name}>options");
			elo = CRapIni.This.Read($"engine>{name}>elo", "1000");
			eloOld = CRapIni.This.ReadDouble($"engine>{name}>eloOld",eloOld);
			hisElo.LoadFromStr(CRapIni.This.Read($"engine>{name}>history", ""));
			if (hisElo.list.Count == 0)
			{
				hisElo.Add(Convert.ToDouble(elo));
				hisElo.Add(Convert.ToDouble(elo));
			}
		}

		public void SaveToIni()
		{
			CRapIni.This.Write($"engine>{name}>tournament", tournament);
			CRapIni.This.Write($"engine>{name}>modeStandard", modeStandard);
			CRapIni.This.Write($"engine>{name}>file", file);
			CRapIni.This.Write($"engine>{name}>protocol", protocol);
			CRapIni.This.Write($"engine>{name}>parameters", parameters);
			CRapIni.This.WriteList($"engine>{name}>options", options);
			CRapIni.This.Write($"engine>{name}>elo", elo);
			CRapIni.This.Write($"engine>{name}>eloOld", eloOld);
			CRapIni.This.Write($"engine>{name}>history", hisElo.SaveToStr());
		}

		public int GetDeltaElo()
		{
			return Convert.ToInt32(elo) - Convert.ToInt32(eloOld);
		}

		public int GetElo()
		{
			return Convert.ToInt32(elo);
		}

		public bool IsXb()
		{
			return protocol == "Winboard";
		}

	}

	public class CEngineList
	{
		public const string def = "RapChess CS";
		public List<CEngine> list = new List<CEngine>();

		public void Add(CEngine e)
		{
			if (GetIndex(e.name) < 0)
				list.Add(e);
		}

		public void DeleteEngine(string name)
		{
			CRapIni.This.DeleteKey($"engine>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				list.RemoveAt(i);
		}

		public CEngine GetEngine(string name)
		{
			foreach (CEngine e in list)
				if (e.name == name)
					return e;
			return null;
		}

		public int GetIndex(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				CEngine engine = list[n];
				if (engine.name == name)
					return n;
			}
			return -1;
		}

		public int GetIndexElo(int elo)
		{
			int result = 0;
			foreach (CEngine e in list)
				if (Convert.ToInt32(e.elo) < elo)
					result++;
			return result;
		}

		public int GetOptElo(double index)
		{
			if (index < 0)
				index = 0;
			if (index >= list.Count)
				index = list.Count - 1;
			return Convert.ToInt32((3000 * (index + 1)) / list.Count);
		}

		public void LoadFromIni()
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

		public CEngine NextTournament(CEngine e, bool rotate = true,bool back = false)
		{
			Sort();
			int i = GetIndex(e.name);
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
				e = list[i];
				if (e.tournament)
					break;
			}
			return e;
		}

		public void SaveToIni()
		{
			CRapIni.This.DeleteKey("engine");
			foreach (CEngine e in list)
				e.SaveToIni();
		}

		public void Sort()
		{
			list.Sort(delegate (CEngine e1, CEngine e2)
			{
				int result = Convert.ToInt32(e2.elo) - Convert.ToInt32(e1.elo);
				if (result == 0)
					result = Convert.ToInt32(e2.eloOld) - Convert.ToInt32(e1.eloOld);
				return result;
			});
		}

		public void SortDistance()
		{
			list.Sort(delegate (CEngine e1, CEngine e2)
			{
				return e1.distance - e2.distance;
			});
		}

		public void FillPosition()
		{
			int position = 1;
			for (int n = 0; n < list.Count; n++)
				list[n].position = position++;
		}

	}

}
