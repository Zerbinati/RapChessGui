using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CPlayer
	{
		public int tournament = 1;
		public int position = 0;
		public string name = "";
		public string engine = "Human";
		public string book = CData.none;
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

		public void Check(CEngineList el)
		{
			CEngine e = el.GetEngine(engine);
			if (e == null)
			{
				engine = "Human";
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
			tournament = IsRealHuman() ? 0 : t;
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
			return engine != "Human";
		}

		public bool IsRealHuman()
		{
			return (engine == "Human") && (modeValue.mode == "Infinite");
		}

		public void SetPlayer(string name)
		{
			CPlayer p = FormChess.playerList.GetPlayer(name);
			if (p != null)
			{
				tournament = p.tournament;
				engine = p.engine;
				book = p.book;
				elo = p.elo;
				modeValue.mode = p.modeValue.mode;
				modeValue.value = p.modeValue.value;
				hisElo.Assign(p.hisElo);
			}
		}

		public void LoadFromIni()
		{
			tournament = FormChess.RapIni.ReadInt($"player>{name}>tournament", tournament);
			engine = FormChess.RapIni.Read($"player>{name}>engine", "Human");
			modeValue.mode = FormChess.RapIni.Read($"player>{name}>mode", modeValue.mode);
			modeValue.value = FormChess.RapIni.ReadInt($"player>{name}>value", modeValue.value);
			book = FormChess.RapIni.Read($"player>{name}>book", "None");
			elo = FormChess.RapIni.Read($"player>{name}>elo", elo);
			eloOrg = FormChess.RapIni.Read($"player>{name}>eloOrg", eloOrg);
			hisElo.LoadFromStr(FormChess.RapIni.Read($"player>{name}>history"));
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
			FormChess.RapIni.Write($"player>{name}>tournament", tournament);
			FormChess.RapIni.Write($"player>{name}>engine", engine);
			FormChess.RapIni.Write($"player>{name}>mode", modeValue.mode);
			FormChess.RapIni.Write($"player>{name}>value", modeValue.value);
			FormChess.RapIni.Write($"player>{name}>book", book);
			FormChess.RapIni.Write($"player>{name}>elo", elo);
			FormChess.RapIni.Write($"player>{name}>eloOrg", eloOrg);
			FormChess.RapIni.Write($"player>{name}>history", hisElo.SaveToStr());
		}

		public string GetName()
		{
			if (name == String.Empty)
			{
				string n = "Human";
				string b = String.Empty;
				string m = String.Empty;
				if (engine != "Human")
				{
					n = engine;
					m = modeValue.ShortName();
				}
				if (book != "None")
					b = $" {CData.MakeShort(book)}";
				name = $"{n}{b}{m}";
			}
			return name;
		}

	}

	public class CPlayerList
	{
		public List<CPlayer> list = new List<CPlayer>();

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

		public CPlayer GetPlayer(string name)
		{
			foreach (CPlayer p in list)
				if (p.name == name)
					return p;
			return null;
		}

		public CPlayer GetPlayerAuto(string name = "")
		{
			CPlayer ph = GetPlayerRealHuman();
			if (name == "Human")
				return ph;
			return GetPlayerElo(ph);
		}

		public CPlayer GetPlayerComputer()
		{
			SortElo();
			foreach (CPlayer p in list)
				if (p.IsComputer())
					return p;
			return null;
		}

		public CPlayer GetPlayerRealHuman()
		{
			SortElo();
			foreach (CPlayer p in list)
				if (p.IsRealHuman())
					return p;
			return null;
		}

		CPlayer GetPlayerElo(CPlayer player)
		{
			CPlayer p = null;
			int bstDel = 10000;
			int elo = player.GetElo();
			foreach (CPlayer cp in list)
			{
				if (cp == player)
					continue;
				if (cp.engine == "Human")
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
			List<string> pl = FormChess.RapIni.ReadKeyList("player");
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
			FormChess.RapIni.DeleteKey($"player>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				list.RemoveAt(i);
		}

		public void SaveToIni()
		{
			FormChess.RapIni.DeleteKey("player");
			foreach (CPlayer u in list)
				u.SaveToIni();
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
