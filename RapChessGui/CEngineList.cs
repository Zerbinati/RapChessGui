using System;
using System.Collections.Generic;
using System.IO;
using NSUci;
using RapIni;

namespace RapChessGui
{
	public class CEngine
	{
		public bool modeStandard = true;
		public bool modeTime = true;
		public bool modeDepth = true;
		public int position = 0;
		public int tournament = 1;
		public string name = "";
		public string file = "";
		public string parameters = "";
		public string elo = "1500";
		public List<string> options = new List<string>();
		public CProtocol protocol = CProtocol.auto;
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
			tournament = CEngineList.iniFile.ReadInt($"engine>{name}>tournament", tournament);
			modeStandard = CEngineList.iniFile.ReadBool($"engine>{name}>modeStandard", modeStandard);
			modeTime = CEngineList.iniFile.ReadBool($"engine>{name}>modeTime", modeTime);
			modeDepth = CEngineList.iniFile.ReadBool($"engine>{name}>modeDepth", modeDepth);
			file = CEngineList.iniFile.Read($"engine>{name}>file", "None");
			protocol = CData.StrToProtocol(CEngineList.iniFile.Read($"engine>{name}>protocol", "Uci"));
			parameters = CEngineList.iniFile.Read($"engine>{name}>parameters", "");
			options = CEngineList.iniFile.ReadList($"engine>{name}>options");
			elo = CEngineList.iniFile.Read($"engine>{name}>elo", elo);
			hisElo.LoadFromStr(CEngineList.iniFile.Read($"engine>{name}>history"));
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
			CEngineList.iniFile.Write($"engine>{name}>tournament", tournament);
			CEngineList.iniFile.Write($"engine>{name}>modeStandard",  modeStandard);
			CEngineList.iniFile.Write($"engine>{name}>modeTime", modeTime);
			CEngineList.iniFile.Write($"engine>{name}>modeDepth", modeDepth);
			CEngineList.iniFile.Write($"engine>{name}>file", file);
			CEngineList.iniFile.Write($"engine>{name}>protocol", CData.ProtocolToStr(protocol));
			CEngineList.iniFile.Write($"engine>{name}>parameters", parameters);
			CEngineList.iniFile.Write($"engine>{name}>options", options);
			CEngineList.iniFile.Write($"engine>{name}>elo", elo);
			CEngineList.iniFile.Write($"engine>{name}>history", hisElo.SaveToStr());
		}

		public bool SupportLevel(CLevel l)
		{
			if ((protocol != CProtocol.uci) && (protocol != CProtocol.winboard))
				return false;
			switch (l)
			{
				case CLevel.standard:
					return modeStandard;
				case CLevel.depth:
					return modeDepth;
				default:
					return modeTime;
			}
		}

		public string CreateName()
		{
			return Path.GetFileNameWithoutExtension(file);
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
			return "None";
		}

		public string GetFileName()
		{
			return $@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{file}";
		}

		public string GetName()
		{
			if (name == "")
				return CreateName();
			return name;
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

	public class CEngineList: List<CEngine>
	{
		public const string def = "RapChessCs";
		public static CRapIni iniFile = new CRapIni(@"Ini\engines.ini");

		public void AddEngine(CEngine e)
		{
			e.name = e.GetName();
			int index = GetIndex(e.name);
			if (index >= 0)
				this[index] = e;
			else
				Add(e);
		}

		public void DeleteEngine(string name)
		{
			iniFile.DeleteKey($"engine>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				RemoveAt(i);
		}

		public CEngine GetEngineByName(string name)
		{
			foreach (CEngine e in this)
				if (e.name == name)
					return e;
			return null;
		}

		public CEngine GetEngineByFile(string file)
		{
			foreach (CEngine e in this)
				if (e.file == file)
					return e;
			return null;
		}

		public CEngine GetEngineByIndex(int index)
		{
			if ((index < 0) || (index >= Count))
				return null;
			return this[index];
		}

		public int GetIndex(string name)
		{
			for (int n = 0; n < Count; n++)
			{
				CEngine engine = this[n];
				if (engine.name == name)
					return n;
			}
			return -1;
		}

		public int GetOptElo(double index)
		{
			int min = CModeTournamentE.minElo;
			int max = CModeTournamentE.maxElo;
			if (index < 0)
				index = 0;
			if (index >= Count)
				index = Count - 1;
			int range = max - min;
			index = Count - index;
			return min + Convert.ToInt32((range * index) / (Count + 1));
		}

		public void AutoUpdate()
		{
			foreach (string fn in CData.fileEngineAuto)
			{
				string name = Path.GetFileNameWithoutExtension(fn);
				string file = $@"Auto\{fn}";
				CEngine engine = GetEngineByFile(file);
				if (engine == null)
				{
					engine = GetEngineByName(name);
					if (engine == null)
					{
						engine = new CEngine(name);
						engine.protocol = CProtocol.auto;
						Add(engine);
					}
					engine.file = file;
					engine.SaveToIni();
				}
			}
			for (int n =Count - 1; n >= 0; n--)
			{
				CEngine e = this[n];
				if (e.IsAuto() && !e.FileExists())
					DeleteEngine(e.name);
			}
		}

		public int LoadFromIni()
		{
			Clear();
			List<string> en = CEngineList.iniFile.ReadKeyList("engine");
			foreach (string name in en)
			{
				CEngine engine = new CEngine(name);
				engine.LoadFromIni();
				Add(engine);
			}
			AutoUpdate();
			return en.Count;
		}

		public CEngine NextTournament(CEngine e, bool rotate = true, bool back = false)
		{
			SortElo();
			int i = GetIndex(e.name);
			for (int n = 0; n < Count - 1; n++)
			{
				if (back)
					i--;
				else
					i++;
				if (rotate)
					i = (i + Count) % Count;
				else
					if ((i < 0) || (i >= Count))
					return null;
				e = this[i];
				if (e.tournament > 0)
					break;
			}
			return e;
		}

		public void SaveToIni()
		{
			iniFile.DeleteKey("engine");
			foreach (CEngine e in this)
				e.SaveToIni();
		}

		public void SortElo()
		{
			Sort(delegate (CEngine e1, CEngine e2)
			{
				int result = e2.GetElo() - e1.GetElo();
				if (result == 0)
					result = e2.hisElo.EloAvg() - e1.hisElo.EloAvg();
				return result;
			});
		}

		public void SetEloDistance(CEngine engine)
		{
			SortElo();
			int elo = engine.GetElo();
			for (int n = 0; n < Count; n++)
				this[n].position = Math.Abs(elo - this[n].GetElo());
			Sort(delegate (CEngine e1, CEngine e2)
			{
				return e1.position - e2.position;
			});
			FillPosition();
		}

		public void FillPosition()
		{
			for (int n = 0; n < Count; n++)
				this[n].position = n;
		}

	}

}
