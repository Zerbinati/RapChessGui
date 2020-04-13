using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CPlayer
	{
		public string name = "";
		public string engine = "Human";
		public string book = "None";
		public string elo = "1000";
		public double eloOld = 1000;
		public int eloNew = 1000;
		public int eloLess = 0;
		public int eloMore = 0;
		public int distance = 0;
		public int position = 0;
		public CModeValue modeValue = new CModeValue();

		public CPlayer()
		{
		}

		public CPlayer(string n)
		{
			name = n;
		}

		public int GetDeltaElo()
		{
			return Convert.ToInt32(elo) - Convert.ToInt32(eloOld);
		}

		public void SetPlayer(string name)
		{
			CPlayer p = CPlayerList.GetPlayerAuto(name);
			engine = p.engine;
			modeValue.mode = p.modeValue.mode;
			modeValue.value = p.modeValue.value;
			book = p.book;
			elo = p.elo;
		}

		public void LoadFromIni()
		{
			engine = CRapIni.This.Read($"player>{name}>engine", "Human");
			modeValue.mode = CRapIni.This.Read($"player>{name}>mode", "movetime");
			modeValue.value = CRapIni.This.ReadInt($"player>{name}>value", modeValue.value);
			book = CRapIni.This.Read($"player>{name}>book", "None");
			elo = CRapIni.This.Read($"player>{name}>elo", "1000");
			eloNew = CRapIni.This.ReadInt($"player>{name}>eloNew", eloNew);
			eloOld = CRapIni.This.ReadDouble($"player>{name}>eloOld", eloOld);
		}

		public void SaveToIni()
		{
			if (name == "")
				name = GetName();
			CRapIni.This.Write($"player>{name}>engine", engine);
			CRapIni.This.Write($"player>{name}>mode", modeValue.mode);
			CRapIni.This.Write($"player>{name}>value", modeValue.value);
			CRapIni.This.Write($"player>{name}>book", book);
			CRapIni.This.Write($"player>{name}>elo", elo);
			CRapIni.This.Write($"player>{name}>eloNew", eloNew);
			CRapIni.This.Write($"player>{name}>eloOld", eloOld);
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

	static class CPlayerList
	{
		public static List<CPlayer> list = new List<CPlayer>();

		public static void Add(CPlayer p)
		{
			if (p.name == "")
				p.name = p.GetName();
			if (GetIndex(p.name) < 0)
				list.Add(p);
		}

		public static int GetIndex(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				CPlayer user = list[n];
				if (user.name == name)
					return n;
			}
			return -1;
		}

		public static CPlayer GetPlayer(string name)
		{
			foreach (CPlayer p in list)
				if (p.name == name)
					return p;
			return null;
		}

		public static CPlayer GetPlayerAuto()
		{
			CPlayer ph = GetPlayer("Human");
			if(ph == null)
				ph = new CPlayer("Human");
			CPlayer pe = GetPlayerElo(ph);
			CPlayer pc = new CPlayer(pe.name);
			pc.SetPlayer(pe.name);
			return pc;
		}

		public static CPlayer GetPlayerAuto(string name)
		{
			foreach (CPlayer p in list)
				if (p.name == name)
					return p;
			return GetPlayerAuto();
		}

		static CPlayer GetPlayerElo(CPlayer player)
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

		public static void Sort()
		{
			list.Sort(delegate (CPlayer u1, CPlayer u2)
			{
				int result = Convert.ToInt32(u2.elo) - Convert.ToInt32(u1.elo);
				if (result == 0)
					result = Convert.ToInt32(u2.eloOld) - Convert.ToInt32(u1.eloOld);
				return result;
			});
		}

		public static void SortDistance()
		{
			list.Sort(delegate (CPlayer u1, CPlayer u2)
			{
				return u1.distance - u2.distance;
			});
		}

		public static void LoadFromIni()
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

		public static void DeletePlayer(string name)
		{
			CRapIni.This.DeleteKey($"player>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				list.RemoveAt(i);
		}

		public static void SaveToIni()
		{
			CRapIni.This.DeleteKey("player");
			foreach (CPlayer u in list)
				u.SaveToIni();
		}

		public static int GetIndexElo(int elo)
		{
			int result = 0;
			foreach (CPlayer u in list)
				if (Convert.ToInt32(u.elo) < elo)
					result++;
			return result;
		}

		public static int GetOptElo(double index)
		{
			if (index < 0)
				index = 0;
			if (index >= list.Count)
				index = list.Count - 1;
			return Convert.ToInt32((3000 * (index + 1)) / list.Count);
		}

		public static CPlayer NextPlayer(CPlayer p)
		{
			Sort();
			int i = GetIndex(p.name);
			for (int n = 0; n < list.Count; n++)
			{
				i = ++i % list.Count;
				CPlayer cp = list[i];
				if (cp.name != "Human")
					return cp;
			}
			return GetPlayerAuto("Human");
		}

		public static void FillPosition()
		{
			int position = 1;
			for (int n = 0; n < CPlayerList.list.Count; n++)
			{
				CPlayer p = CPlayerList.list[n];
				p.position = p.engine == "Human" ? 0 : position++;
			}
		}


	}
}
