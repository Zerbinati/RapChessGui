using System;
using System.Collections.Generic;
using System.IO;
using NSUci;

namespace RapChessGui
{
	public class CEngine
	{
		public bool modeStandard = true;
		public int distance = 0;
		public int position = 0;
		public int tournament = 1;
		public string name = "";
		public string file = "";
		public string parameters = "";
		public string elo = "1500";
		public List<string> options = new List<string>();
		public CProtocol protocol = CProtocol.uci;
		public CHisElo hisElo = new CHisElo();

		public CEngine()
		{
		}

		public CEngine(string n)
		{
			name = n;
		}

		public void LoadFromIni()
		{
			tournament = FormChess.RapIni.ReadInt($"engine>{name}>tournament", tournament);
			modeStandard = FormChess.RapIni.ReadBool($"engine>{name}>modeStandard", modeStandard);
			file = FormChess.RapIni.Read($"engine>{name}>file", "Human");
			protocol = CData.StrToProtocol(FormChess.RapIni.Read($"engine>{name}>protocol", "Uci"));
			parameters = FormChess.RapIni.Read($"engine>{name}>parameters", "");
			options = FormChess.RapIni.ReadList($"engine>{name}>options");
			elo = FormChess.RapIni.Read($"engine>{name}>elo", elo);
			hisElo.LoadFromStr(FormChess.RapIni.Read($"engine>{name}>history", ""));
		}

		public void SaveToIni()
		{
			name = GetName();
			if (hisElo.list.Count == 0)
			{
				int e = GetElo();
				hisElo.Add(e);
				hisElo.Add(e);
			}
			FormChess.RapIni.Write($"engine>{name}>tournament", tournament);
			FormChess.RapIni.Write($"engine>{name}>modeStandard", modeStandard);
			FormChess.RapIni.Write($"engine>{name}>file", file);
			FormChess.RapIni.Write($"engine>{name}>protocol", CData.ProtocolToStr(protocol));
			FormChess.RapIni.Write($"engine>{name}>parameters", parameters);
			FormChess.RapIni.Write($"engine>{name}>options", options);
			FormChess.RapIni.Write($"engine>{name}>elo", elo);
			FormChess.RapIni.Write($"engine>{name}>history", hisElo.SaveToStr());
		}

		public string GetOption(string name, string def)
		{
			CUci uci = new CUci();
			foreach (string o in options)
			{
				uci.SetMsg(o);
				if (o.IndexOf($"name {name} value ") == 0)
					return uci.Last();
			}
			return def;
		}

		public void SetElo(int e)
		{
			elo = e.ToString();
		}

		public bool IsAuto()
		{
			return file.Contains(@"\");
		}

		public bool FileExists()
		{
			return File.Exists($@"Engines\{file}");
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

		public string GetFile()
		{
			if (FileExists())
				return file;
			return "none";
		}

		public string GetName()
		{
			if (name != "")
				return name;
			return Path.GetFileNameWithoutExtension(file);
		}

		public bool SetTournament(bool tb)
		{
			int t = tb ? 1 : 0;
			if (tb && (tournament > 0))
				t = tournament;
			if (tournament != t)
			{
				tournament = t;
				SaveToIni();
				return true;
			}
			return false;
		}

	}

	public class CEngineList
	{
		public const string def = "RapChessCs";
		public List<CEngine> list = new List<CEngine>();

		public void Add(CEngine e)
		{
			e.name = e.GetName();
			int index = GetIndex(e.name);
			if (index >= 0)
				list[index] = e;
			else
				list.Add(e);
		}

		public void DeleteEngine(string name)
		{
			FormChess.RapIni.DeleteKey($"engine>{name}");
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

		public CEngine GetEngineByFile(string file)
		{
			foreach (CEngine e in list)
				if (e.file == file)
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
				if (e.GetElo() > elo)
					result++;
			return result;
		}

		public int GetOptElo(double index)
		{
			if (index < 0)
				index = 0;
			if (index >= list.Count)
				index = list.Count - 1;
			return Convert.ToInt32((3000 * (list.Count - index)) / list.Count);
		}

		public int GetOptElo(double index, int min, int max)
		{
			if (index < 0)
				index = 0;
			if (index >= list.Count)
				index = list.Count - 1;
			int range = max - min;
			index = list.Count - index;
			return min + Convert.ToInt32((range * index) / (list.Count + 1));
		}

		public void AutoUpdate()
		{
			foreach (string fn in CData.fileEngineUci)
			{
				string name = Path.GetFileNameWithoutExtension(fn);
				string file = $@"Uci\{fn}";
				CEngine engine = GetEngineByFile(file);
				if (engine == null)
				{
					engine = GetEngine(name);
					if (engine == null)
					{
						engine = new CEngine(name);
						engine.protocol = CProtocol.uci;
						list.Add(engine);
					}
					engine.file = file;
					engine.SaveToIni();
				}
			}
			foreach (string fn in CData.fileEngineWb)
			{
				string name = Path.GetFileNameWithoutExtension(fn);
				string file = $@"Winboard\{fn}";
				CEngine engine = GetEngineByFile(file);
				if (engine == null)
				{
					engine = GetEngine(name);
					if (engine == null)
					{
						engine = new CEngine(name);
						engine.protocol = CProtocol.winboard;
						list.Add(engine);
					}
					engine.file = file;
					engine.SaveToIni();
				}
			}
			for (int n = list.Count - 1; n >= 0; n--)
			{
				CEngine e = list[n];
				if (e.IsAuto() && !e.FileExists())
					DeleteEngine(e.name);
			}
		}

		public int LoadFromIni()
		{
			list.Clear();
			List<string> en = FormChess.RapIni.ReadKeyList("engine");
			foreach (string name in en)
			{
				CEngine engine = new CEngine(name);
				engine.LoadFromIni();
				list.Add(engine);
			}
			AutoUpdate();
			return en.Count;
		}

		public CEngine NextTournament(CEngine e, bool rotate = true, bool back = false)
		{
			SortElo();
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
				if (e.tournament > 0)
					break;
			}
			return e;
		}

		public void SaveToIni()
		{
			FormChess.RapIni.DeleteKey("engine");
			foreach (CEngine e in list)
				e.SaveToIni();
		}

		public void SortElo()
		{
			list.Sort(delegate (CEngine e1, CEngine e2)
			{
				int result = e2.GetElo() - e1.GetElo();
				if (result == 0)
					result = e2.hisElo.EloAvg() - e1.hisElo.EloAvg();
				return result;
			});
		}

		public void SortDistance(CEngine engine)
		{
			SortElo();
			FillPosition();
			foreach (CEngine e in list)
				e.distance = Math.Abs(engine.position - e.position);
			list.Sort(delegate (CEngine e1, CEngine e2)
			{
				return e1.distance - e2.distance;
			});
		}

		public void SetElo(string name)
		{
			CEngine engine = GetEngine(name);
			if (engine != null)
			{
				engine.SetElo(0);
				SetElo();
			}
		}

		public void SetElo()
		{
			SortElo();
			for (int n = 0; n < list.Count; n++)
			{
				CEngine e = list[n];
				e.SetElo(GetOptElo(n));
			}
		}

		public void FillPosition()
		{
			int position = 1;
			for (int n = 0; n < list.Count; n++)
				list[n].position = position++;
		}

	}

}
