using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CPlayer
	{
		public int tournament = 1;
		public int distance = 0;
		public int position = 0;
		public string name = "";
		public string engine = "Human";
		public string book = "None";
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
			return engine != "Human";
		}

		public bool IsHuman()
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
			tournament = CRapIni.This.ReadInt($"player>{name}>tournament", tournament);
			engine = CRapIni.This.Read($"player>{name}>engine", "Human");
			modeValue.mode = CRapIni.This.Read($"player>{name}>mode", modeValue.mode);
			modeValue.value = CRapIni.This.ReadInt($"player>{name}>value", modeValue.value);
			book = CRapIni.This.Read($"player>{name}>book", "None");
			elo = CRapIni.This.Read($"player>{name}>elo", elo);
			eloOrg = CRapIni.This.Read($"player>{name}>eloOrg", eloOrg);
			hisElo.LoadFromStr(CRapIni.This.Read($"player>{name}>history", ""));
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
			CRapIni.This.Write($"player>{name}>tournament", tournament);
			CRapIni.This.Write($"player>{name}>engine", engine);
			CRapIni.This.Write($"player>{name}>mode", modeValue.mode);
			CRapIni.This.Write($"player>{name}>value", modeValue.value);
			CRapIni.This.Write($"player>{name}>book", book);
			CRapIni.This.Write($"player>{name}>elo", elo);
			CRapIni.This.Write($"player>{name}>eloOrg", eloOrg);
			CRapIni.This.Write($"player>{name}>history", hisElo.SaveToStr());
		}

		public string GetName()
		{
			if (name != "")
				return name;
			string n = "Human";
			string b = "";
			string m = "";
			if (engine != "Human")
			{
				n = engine;
				m = modeValue.ShortName();
			}
			if (book != "None")
				b = $" {CData.MakeShort(book)}";
			return $"{n}{b}{m}";
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
			CPlayer ph = GetPlayerHuman();
			if (name == "Human")
				return ph;
			return GetPlayerElo(ph);
		}

		public CPlayer GetPlayerComputer()
		{
			Sort();
			foreach (CPlayer p in list)
				if (p.IsComputer())
					return p;
			return null;
		}

		public CPlayer GetPlayerHuman()
		{
			Sort();
			foreach (CPlayer p in list)
				if (p.IsHuman())
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

		public void Sort()
		{
			list.Sort(delegate (CPlayer p1, CPlayer p2)
			{
				int result = p2.GetElo() - p1.GetElo();
				if (result == 0)
					result = p2.hisElo.EloAvg() - p1.hisElo.EloAvg();
				return result;
			});
		}

		public void SortDistance(CPlayer player)
		{
			Sort();
			FillPosition();
			foreach (CPlayer p in list)
				p.distance = Math.Abs(player.position - p.position);
			list.Sort(delegate (CPlayer p1, CPlayer p2)
			{
				return p1.distance - p2.distance;
			});
		}

		public int LoadFromIni()
		{
			list.Clear();
			List<string> pl = CRapIni.This.ReadList("player");
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
			CRapIni.This.DeleteKey($"player>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				list.RemoveAt(i);
		}

		public void SaveToIni()
		{
			CRapIni.This.DeleteKey("player");
			foreach (CPlayer u in list)
				u.SaveToIni();
		}

		public int GetIndexElo(int elo)
		{
			int result = 0;
			foreach (CPlayer u in list)
				if (u.GetElo() < elo)
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

		public CPlayer NextTournament(CPlayer p, bool rotate = true, bool back = false)
		{
			Sort();
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
			int position = 1;
			for (int n = 0; n < list.Count; n++)
			{
				CPlayer p = list[n];
				p.position = p.engine == "Human" ? 0 : position++;
			}
		}


	}
}
