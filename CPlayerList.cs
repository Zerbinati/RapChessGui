using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CPlayer
	{
		public int tournament = 1;
		public int eloNew = 1000;
		public int distance = 0;
		public int position = 0;
		public double eloOld = 1000;
		public string name = "";
		public string engine = "Human";
		public string book = "None";
		public string elo = "1000";
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
			int result = Convert.ToInt32(elo) - levelDif;
			if (result < 0)
				result = 0;
			return result;
		}

		public int GetEloMore()
		{
			int levelDif = 2000 / FormChess.playerList.list.Count;
			if (levelDif < 10)
				levelDif = 10;
			return Convert.ToInt32(elo) + levelDif;
		}

		public int GetElo()
		{
			return Convert.ToInt32(elo);
		}

		public int GetDeltaElo()
		{
			return Convert.ToInt32(elo) - Convert.ToInt32(eloOld);
		}

		public bool IsComputer()
		{
			return engine != "Human";
		}

		public bool IsHuman()
		{
			return engine == "Human";
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
			tournament = CRapIni.This.ReadInt($"player>{name}>tournament",tournament);
			engine = CRapIni.This.Read($"player>{name}>engine", "Human");
			modeValue.mode = CRapIni.This.Read($"player>{name}>mode", modeValue.mode);
			modeValue.value = CRapIni.This.ReadInt($"player>{name}>value", modeValue.value);
			book = CRapIni.This.Read($"player>{name}>book", "None");
			elo = CRapIni.This.Read($"player>{name}>elo",elo);
			eloNew = CRapIni.This.ReadInt($"player>{name}>eloNew", eloNew);
			eloOld = CRapIni.This.ReadDouble($"player>{name}>eloOld", eloOld);
			hisElo.LoadFromStr(CRapIni.This.Read($"player>{name}>history", ""));
			if (hisElo.list.Count == 0)
			{
				hisElo.Add(Convert.ToDouble(elo));
				hisElo.Add(Convert.ToDouble(elo));
			}
		}

		public void SaveToIni()
		{
			if (name == "")
				name = GetName();
			CRapIni.This.Write($"player>{name}>tournament", tournament);
			CRapIni.This.Write($"player>{name}>engine", engine);
			CRapIni.This.Write($"player>{name}>mode", modeValue.mode);
			CRapIni.This.Write($"player>{name}>value", modeValue.value);
			CRapIni.This.Write($"player>{name}>book", book);
			CRapIni.This.Write($"player>{name}>elo", elo);
			CRapIni.This.Write($"player>{name}>eloNew", eloNew);
			CRapIni.This.Write($"player>{name}>eloOld", eloOld);
			CRapIni.This.Write($"player>{name}>history", hisElo.SaveToStr());
		}

		string MakeShort(string name)
		{
			string result = "";
			for (int n = 0; n < name.Length; n++)
			{
				char c = name[n];
				if ((n == 0) || char.IsUpper(c) || char.IsNumber(c))
					result += c;
			}
			return result;
		}

		public string GetName()
		{
			string n = "Human";
			string b = "";
			string m = "";
			if (engine != "Human")
			{
				n = engine;
				m = modeValue.ShortName();
			}
			if (book != "None")
				b = $" {MakeShort(book)}";
			return $"{n}{b}{m}";
		}

	}

	public class CPlayerList
	{
		public List<CPlayer> list = new List<CPlayer>();

		public void Add(CPlayer p)
		{
			if (p.name == "")
				p.name = p.GetName();
			if (GetIndex(p.name) < 0)
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

		public CPlayer GetPlayerAuto(string name="")
		{
			if (name == "Human")
				return GetPlayerHuman();
			CPlayer ph = GetPlayerHuman();
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
			int elo = Convert.ToInt32(player.elo);
			foreach (CPlayer cp in list)
			{
				if (cp == player)
					continue;
				if (cp.engine == "Human")
					continue;
				int curE = Convert.ToInt32(cp.elo);
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
			list.Sort(delegate (CPlayer u1, CPlayer u2)
			{
				int result = Convert.ToInt32(u2.elo) - Convert.ToInt32(u1.elo);
				if (result == 0)
					result = Convert.ToInt32(u2.eloOld) - Convert.ToInt32(u1.eloOld);
				return result;
			});
		}

		public void SortDistance()
		{
			list.Sort(delegate (CPlayer u1, CPlayer u2)
			{
				return u1.distance - u2.distance;
			});
		}

		public void LoadFromIni()
		{
			list.Clear();
			List<string> pn = CRapIni.This.ReadList("player");
			foreach (string name in pn)
			{
				var p = new CPlayer(name);
				p.LoadFromIni();
				list.Add(p);
			}
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
				if (Convert.ToInt32(u.elo) < elo)
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
