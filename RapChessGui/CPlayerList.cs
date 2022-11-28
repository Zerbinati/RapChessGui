using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CPlayer
	{
		public int tournament = 1;
		public int position = 0;
		public string name = String.Empty;
		public string engine = Global.none;
		public string book = Global.none;
		public string elo = "1000";
		public string eloOrg = "1000";
		public CModeValue modeValue = new CModeValue();
		public CHisElo hisElo = new CHisElo();

		public CPlayer()
		{
		}

		public CPlayer(string n)
		{
			name = n;
		}

		public string Check()
		{
			if (name == Global.human)
				return String.Empty;
			if (engine == Global.none)
				return $"Please select {name} engine";
			CEngine e = FormChess.engineList.GetEngineByName(engine);
			if (e != null)
			{
				if (!e.FileExists())
					return $"Engine file {e.file} not exists";
				if ((e.protocol != CProtocol.uci) && (e.protocol != CProtocol.winboard))
					return $"Please setup engine {e.name} protocol";
			}
			CBook b = FormChess.bookList.GetBookByName(book);
			if (b != null)
				if (!b.FileExists())
					return $"Book file {b.file} not exists";
			return String.Empty;
		}

		public bool Check(out string msg)
		{
			msg = Check();
			return msg == String.Empty;
		}

		public void Check(CEngineList el)
		{
			CEngine e = el.GetEngineByName(engine);
			if (e == null)
			{
				engine = Global.none;
				SaveToIni();
			}
		}

		public int GetEloLess()
		{
			int levelDif = 2000 / FormChess.playerList.list.Count;
			if (levelDif < 10)
				levelDif = 10;
			int result = Convert.ToInt32(eloOrg) - levelDif;
			if (result < 0)
				result = 0;
			return result;
		}

		public int GetEloMore()
		{
			int levelDif = 2000 / FormChess.playerList.list.Count;
			if (levelDif < 10)
				levelDif = 10;
			return Convert.ToInt32(eloOrg) + levelDif;
		}

		public int GetElo()
		{
			return Convert.ToInt32(elo);
		}

		public int GetDeltaElo()
		{
			int e = GetElo();
			return e - hisElo.EloAvg(e);
		}

		public void SetTournament(int t)
		{
			tournament = IsHuman() ? 0 : t;
		}

		public bool SetTournament(bool tb)
		{
			tb = IsComputer() & tb;
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

		public bool IsComputer()
		{
			return engine != Global.none;
		}

		public bool IsHuman()
		{
			return (engine == Global.none) && (modeValue.level == CLevel.infinite);
		}

		public void SetPlayer(string name)
		{
			CPlayer p = FormChess.playerList.GetPlayerByName(name);
			if (p != null)
			{
				tournament = p.tournament;
				engine = p.engine;
				book = p.book;
				elo = p.elo;
				modeValue.level = p.modeValue.level;
				modeValue.value = p.modeValue.value;
				hisElo.Assign(p.hisElo);
			}
		}

		public void LoadFromIni()
		{
			tournament = CPlayerList.iniFile.ReadInt($"player>{name}>tournament", tournament);
			engine = CPlayerList.iniFile.Read($"player>{name}>engine", Global.none);
			modeValue.SetLevel(CPlayerList.iniFile.Read($"player>{name}>mode", modeValue.GetLevel()));
			modeValue.value = CPlayerList.iniFile.ReadInt($"player>{name}>value", modeValue.value);
			book = CPlayerList.iniFile.Read($"player>{name}>book", Global.none);
			elo = CPlayerList.iniFile.Read($"player>{name}>elo", elo);
			eloOrg = CPlayerList.iniFile.Read($"player>{name}>eloOrg", eloOrg);
			hisElo.LoadFromStr(CPlayerList.iniFile.Read($"player>{name}>history"));
		}

		public void SaveToIni()
		{
			name = GetName();
			if (hisElo.Count == 0)
			{
				int e = GetElo();
				hisElo.AddValue(e);
				hisElo.AddValue(e);
			}
			CPlayerList.iniFile.Write($"player>{name}>tournament", tournament);
			CPlayerList.iniFile.Write($"player>{name}>engine", engine);
			CPlayerList.iniFile.Write($"player>{name}>mode", modeValue.GetLevel());
			CPlayerList.iniFile.Write($"player>{name}>value", modeValue.value);
			CPlayerList.iniFile.Write($"player>{name}>book", book);
			CPlayerList.iniFile.Write($"player>{name}>elo", elo);
			CPlayerList.iniFile.Write($"player>{name}>eloOrg", eloOrg);
			CPlayerList.iniFile.Write($"player>{name}>history", hisElo.SaveToStr());
		}

		public string CreateName()
		{
			string n = Global.human;
			string b = String.Empty;
			string m = String.Empty;
			if (engine != Global.none)
			{
				n = engine;
				m = modeValue.ShortName();
			}
			if (book != Global.none)
				b = $" {CData.MakeShort(book)}";
			return $"{n}{b}{m}";
		}

		public string GetName()
		{
			if (name == String.Empty)
				return CreateName();
			return name;
		}

	}

	public class CPlayerList
	{
		public List<CPlayer> list = new List<CPlayer>();
		public static CRapIni iniFile = new CRapIni(@"Ini\players.ini");

		public void Add(CPlayer p)
		{
			p.name = p.GetName();
			int index = GetIndex(p.name);
			if (index >= 0)
				list[index] = p;
			else
				list.Add(p);
		}

		public void Check(CEngineList el)
		{
			foreach (CPlayer p in list)
				p.Check(el);
		}

		public int GetIndex(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				CPlayer user = list[n];
				if (user.name == name)
					return n;
			}
			return -1;
		}

		public CPlayer GetPlayerByName(string name)
		{
			foreach (CPlayer p in list)
				if (p.name.ToLower() == name.ToLower())
					return p;
			return null;
		}

		public CPlayer GetPlayerComputer()
		{
			SortElo();
			foreach (CPlayer p in list)
				if (p.IsComputer())
					return p;
			return null;
		}

		public CPlayer GetPlayerByElo(int elo)
		{
			CPlayer p = CModeGame.humanPlayer;
			int bstDel = 10000;
			foreach (CPlayer cp in list)
			{
				if (cp.engine == "None")
					continue;
				int curE = cp.GetElo();
				int curDel = Math.Abs(elo - curE);
				if (bstDel > curDel)
				{
					bstDel = curDel;
					p = cp;
				}
			}
			return p;
		}

		public void SortElo()
		{
			list.Sort(delegate (CPlayer p1, CPlayer p2)
			{
				int result = p2.GetElo() - p1.GetElo();
				if (result == 0)
					result = p2.hisElo.EloAvg() - p1.hisElo.EloAvg();
				return result;
			});
		}

		public void SortPosition(CPlayer player)
		{
			SortElo();
			FillPosition();
			int position = player.position;
			foreach (CPlayer p in list)
				p.position = Math.Abs(position - p.position);
			list.Sort(delegate (CPlayer p1, CPlayer p2)
			{
				return p1.position - p2.position;
			});
		}

		public int LoadFromIni()
		{
			list.Clear();
			List<string> pl = iniFile.ReadKeyList("player");
			foreach (string name in pl)
			{
				var p = new CPlayer(name);
				p.LoadFromIni();
				list.Add(p);
			}
			return pl.Count;
		}

		public void DeletePlayer(string name)
		{
			iniFile.DeleteKey($"player>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				list.RemoveAt(i);
		}

		public void SaveToIni()
		{
			iniFile.DeleteKey("player");
			foreach (CPlayer p in list)
				p.SaveToIni();
		}

		public int GetOptElo(double index)
		{
			int min = CModeTournamentP.minElo;
			int max = CModeTournamentP.maxElo;
			if (index < 0)
				index = 0;
			if (index >= list.Count)
				index = list.Count - 1;
			int range = max - min;
			index = list.Count - index;
			return min + Convert.ToInt32((range * index) / (list.Count + 1));
		}

		public CPlayer NextTournament(CPlayer p, bool rotate = true, bool back = false)
		{
			SortElo();
			int i = GetIndex(p.name);
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
				p = list[i];
				if (p.tournament > 0)
					break;
			}
			return p;
		}

		public void FillPosition()
		{
			for (int n = 0; n < list.Count; n++)
				list[n].position = n;
		}


	}
}
