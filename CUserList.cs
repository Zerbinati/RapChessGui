using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CUser
	{
		public string name = "Human";
		public string engine = "Human";
		public string protocol = "Uci";
		public string parameters = "";
		public string mode = "movetime";
		public string value = "1000";
		public string book = "None";
		public string elo = "1000";
		public double eloOld = 1000;
		public int eloNew = 1000;
		public int eloLess = 0;
		public int eloMore = 0;
		public List<string> options = new List<string>();

		public CUser(string n)
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
			CUser u = CUserList.GetUser(name);
			engine = u.engine;
			protocol = u.protocol;
			parameters = u.parameters;
			mode = u.mode;
			value = u.value;
			book = u.book;
			elo = u.elo;
			options.Clear();
			foreach (string op in u.options)
				options.Add(op);
		}

		public void LoadFromIni()
		{
			engine = CRapIni.This.Read($"player>{name}>engine", "Human");
			protocol = CRapIni.This.Read($"player>{name}>protocol", "Uci");
			parameters = CRapIni.This.Read($"player>{name}>parameters", "");
			mode = CRapIni.This.Read($"player>{name}>mode", "movetime");
			value = CRapIni.This.Read($"player>{name}>value", "1000");
			book = CRapIni.This.Read($"player>{name}>book", "None");
			elo = CRapIni.This.Read($"player>{name}>elo", "1000");
			eloNew = CRapIni.This.ReadInt($"player>{name}>eloNew", 1000);
			eloOld = CRapIni.This.ReadDouble($"player>{name}>eloOld",1000);
			options = CRapIni.This.ReadList($"player>{name}>options");
		}

		public void SaveToIni()
		{
			CRapIni.This.Write($"player>{name}>engine", engine);
			CRapIni.This.Write($"player>{name}>protocol", protocol);
			CRapIni.This.Write($"player>{name}>parameters", parameters);
			CRapIni.This.Write($"player>{name}>mode", mode);
			CRapIni.This.Write($"player>{name}>value", value);
			CRapIni.This.Write($"player>{name}>book", book);
			CRapIni.This.Write($"player>{name}>elo", elo);
			CRapIni.This.Write($"player>{name}>eloNew", Convert.ToString(eloNew));
			CRapIni.This.Write($"player>{name}>eloOld", Convert.ToString(eloOld));
			CRapIni.This.WriteList($"player>{name}>options", options);
		}
	}

	static public class CUserList
	{
		public const string defUser = "RapChessCs XT1";
		public static List<CUser> list = new List<CUser>();

		public static void Add(CUser u)
		{
			if (GetIndex(u.name) < 0)
				list.Add(u);
		}

		public static int GetIndex(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				CUser user = list[n];
				if (user.name == name)
					return n;
			}
			return -1;
		}

		static CUser GetUserAuto()
		{
			CUser uh = GetUser("Human");
			CUser ue = GetUserElo(uh);
			CUser uc = new CUser(ue.name);
			uc.SetUser(ue.name);
			return uc;
		}

		static CUser GetUserElo(CUser user)
		{
			CUser u = null;
			int bstDel = 10000;
			int elo = Convert.ToInt32(user.elo);
			foreach (CUser cu in list)
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
			list.Sort(delegate (CUser u1, CUser u2)
			{
				int result = Convert.ToInt32(u1.elo) - Convert.ToInt32(u2.elo);
				if(result == 0)
					result = Convert.ToInt32(u1.eloOld) - Convert.ToInt32(u2.eloOld);
				return result;
			});
		}

		public static CUser GetUserEloHL(CUser user)
		{
			List<CUser> lu = new List<CUser>();
			Sort();
			int i = GetIndex(user.name);
			int na = i - 2;
			int nb = i + 2;
			int n = na;
			while (n <= nb)
			{
				if ((n >= 0) && (n < list.Count) && (n != i))
				{
					CUser u = list[n];
					if (u.engine == "Human")
						nb++;
					else
						lu.Add(u);
				}
				n++;
			}
			if (lu.Count == 0)
				return user;
			int r = CEngine.random.Next(lu.Count);
			return lu[r];
		}

		static CUser GetUserHuman()
		{
			CUser uh = new CUser("Human");
			return uh;
		}

		public static CUser GetUser(string name)
		{
			foreach (CUser u in  list)
			if (u.name == name)
					return u;
			if (name == "Auto")
				return GetUserAuto();
			return GetUserHuman();
		}

		static int CountComputer()
		{
			int result = 0;
			foreach (CUser cu in list)
				if (cu.engine != "Human")
					result++;
			return result;
		}

		static bool IsHuman()
		{
			foreach (CUser cu in list)
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
				var u = new CUser(name);
				u.LoadFromIni();
				list.Add(u);
			}
			if (!IsHuman())
				list.Add(GetUserHuman());
			if (CountComputer() < 3)
			{
				CBookReader br;
				br = new CBookReader("small");
				br.file = "BookReaderRap.exe";
				br.parameters = "small.rap";
				CBookReaderList.Add(br);
				br = new CBookReader("rand1");
				br.file = "BookReaderRap.exe";
				br.parameters = "rand1.rap";
				CBookReaderList.Add(br);
				br = new CBookReader("rand2");
				br.file = "BookReaderRap.exe";
				br.parameters = "rand2.rap";
				CBookReaderList.Add(br);
				CBookReaderList.SaveToIni();
				CUser uc;
				uc = new CUser("RapChessCs RD1");
				uc.engine = "RapChessCs.exe";
				uc.mode = "depth";
				uc.value = "1";
				uc.book = "rand2";
				uc.elo = "200";
				Add(uc);
				uc = new CUser("RapChessCs RD2");
				uc.engine = "RapChessCs.exe";
				uc.mode = "depth";
				uc.value = "2";
				uc.book = "rand1";
				uc.elo = "400";
				Add(uc);
				uc = new CUser("RapChessCs XD3");
				uc.engine = "RapChessCs.exe";
				uc.mode = "depth";
				uc.value = "3";
				uc.book = "small";
				uc.elo = "600";
				Add(uc);
				uc = new CUser("RapShortCs XT1");
				uc.engine = "RapShortCs.exe";
				uc.mode = "movetime";
				uc.value = "1000";
				uc.book = "small";
				uc.elo = "800";
				Add(uc);
				uc = new CUser("RapSimpleCs XT1");
				uc.engine = "RapSimpleCs.exe";
				uc.mode = "movetime";
				uc.value = "1000";
				uc.book = "small";
				uc.elo = "1000";
				Add(uc);
				uc = new CUser(defUser);
				uc.engine = "RapChessCs.exe";
				uc.mode = "movetime";
				uc.value = "1000";
				uc.book = "small";
				uc.elo = "1200";
				Add(uc);
			}
			SaveToIni();
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
			List<string> names = new List<string>();
			for (int n = 0; n < list.Count; n++)
			{
				var user = list[n];
				names.Add(user.name);
				user.SaveToIni();
			}
			names.Sort();
		}

		public static int GetIndexElo(int elo)
		{
			int result = 0;
			foreach (CUser u in list)
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
