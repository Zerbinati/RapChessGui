using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CPlayer
	{
		public string name = "Human";
		public string engine = "Human";
		public string book = "None";
		public string mode = "movetime";
		public string value = "1000";
		public string elo = "1000";
		public double eloOld = 1000;
		public int eloNew = 1000;
		public int eloLess = 0;
		public int eloMore = 0;

		public CPlayer(string n)
		{
			name = n;
		}

		public int GetDeltaElo()
		{
			return Convert.ToInt32(elo) - Convert.ToInt32(eloOld);
		}

		public bool SetCommand(string command)
		{
			string[] t = command.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			string c1 = "";
			string c2 = "";
			if (t.Length > 0)
				c1 = t[0].ToLower();
			if (t.Length > 1)
				if (int.TryParse(t[1], out int v))
					c2 = v.ToString();
			switch (c1)
			{
				case "movetime":
					if (c2 == "")
						return false;
					break;
				case "depth":
					if (c2 == "")
						return false;
					break;
				case "nodes":
					if (c2 == "")
						return false;
					break;
				case "infinite":
					break;
				default:
					return false;
			}
			mode = c1;
			value = c2;
			return true;
		}

		public string GetCommand()
		{
			if (engine == "Human")
				return "";
			else if (value == "")
				return mode;
			else
				return $"{mode} {value}";
		}

		public void SetUser(string name)
		{
			CPlayer u = CPlayerList.GetUser(name);
			engine = u.engine;
			mode = u.mode;
			value = u.value;
			book = u.book;
			elo = u.elo;
		}

		public void LoadFromIni()
		{
			engine = CRapIni.This.Read($"player>{name}>engine", "Human");
			mode = CRapIni.This.Read($"player>{name}>mode", "movetime");
			value = CRapIni.This.Read($"player>{name}>value", "1000");
			book = CRapIni.This.Read($"player>{name}>book", "None");
			elo = CRapIni.This.Read($"player>{name}>elo", "1000");
			eloNew = CRapIni.This.ReadInt($"player>{name}>eloNew", 1000);
			eloOld = CRapIni.This.ReadDouble($"player>{name}>eloOld",1000);
		}

		public void SaveToIni()
		{
			CRapIni.This.Write($"player>{name}>engine", engine);
			CRapIni.This.Write($"player>{name}>mode", mode);
			CRapIni.This.Write($"player>{name}>value", value);
			CRapIni.This.Write($"player>{name}>book", book);
			CRapIni.This.Write($"player>{name}>elo", elo);
			CRapIni.This.Write($"player>{name}>eloNew", Convert.ToString(eloNew));
			CRapIni.This.Write($"player>{name}>eloOld", Convert.ToString(eloOld));
		}
	}

	static class CPlayerList
	{
		public const string def = "RapChess CS XT1";
		public static List<CPlayer> list = new List<CPlayer>();

		public static void Add(CPlayer u)
		{
			if (GetIndex(u.name) < 0)
				list.Add(u);
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

		static CPlayer GetUserAuto()
		{
			CPlayer uh = GetUser("Human");
			CPlayer ue = GetUserElo(uh);
			CPlayer uc = new CPlayer(ue.name);
			uc.SetUser(ue.name);
			return uc;
		}

		static CPlayer GetUserElo(CPlayer user)
		{
			CPlayer u = null;
			int bstDel = 10000;
			int elo = Convert.ToInt32(user.elo);
			foreach (CPlayer cu in list)
			{
				if (cu == user)
					continue;
				if (cu.engine == "Human")
					continue;
				int curE = Convert.ToInt32(cu.elo);
				int curDel = Math.Abs(elo - curE);
				if (bstDel > curDel)
				{
					bstDel = curDel;
					u = cu;
				}
			}
			return u;
		}

		public static void Sort()
		{
			list.Sort(delegate (CPlayer u1, CPlayer u2)
			{
				int result = Convert.ToInt32(u1.elo) - Convert.ToInt32(u2.elo);
				if(result == 0)
					result = Convert.ToInt32(u1.eloOld) - Convert.ToInt32(u2.eloOld);
				return result;
			});
		}

		public static CPlayer GetUserEloHL(CPlayer user)
		{
			List<CPlayer> lu = new List<CPlayer>();
			Sort();
			int i = GetIndex(user.name);
			int na = i - 2;
			int nb = i + 2;
			int n = na;
			while (n <= nb)
			{
				if ((n >= 0) && (n < list.Count) && (n != i))
				{
					CPlayer u = list[n];
					if (u.engine == "Human")
						nb++;
					else
						lu.Add(u);
				}
				n++;
			}
			if (lu.Count == 0)
				return user;
			int r = CChess.random.Next(lu.Count);
			return lu[r];
		}

		static CPlayer GetUserHuman()
		{
			CPlayer uh = new CPlayer("Human");
			return uh;
		}

		public static CPlayer GetUser(string name)
		{
			foreach (CPlayer u in  list)
			if (u.name == name)
					return u;
			if (name == "Auto")
				return GetUserAuto();
			return GetUserHuman();
		}

		static int CountComputer()
		{
			int result = 0;
			foreach (CPlayer cu in list)
				if (cu.engine != "Human")
					result++;
			return result;
		}

		static bool IsHuman()
		{
			foreach (CPlayer cu in list)
				if (cu.engine == "Human")
					return true;
			return false;
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


	}
}
