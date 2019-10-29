using System;
using System.Collections.Generic;

namespace RapChessGui
{

	public class CUser
	{
		public string name = "Human";
		public string engine = "Human";
		public string parameters = "";
		public string mode = "movetime";
		public string value = "1000";
		public string book = "None";
		public string elo = "1000";

		public CUser(string n)
		{
			name = n;
		}

		public bool SetCommand(string command)
		{
			string[] t = command.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			string c1 = "";
			string c2 = "";
			int v = 0;
			if (t.Length > 0)
				c1 = t[0].ToLower();
			if (t.Length > 1)
				if (int.TryParse(t[1], out v))
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
			if (value == "")
				return mode;
			else
				return $"{mode} {value}";
		}

		public void SetUser(string name)
		{
			CUser u = CUserList.GetUser(name);
			engine = u.engine;
			parameters = u.parameters;
			mode = u.mode;
			value = u.value;
			book = u.book;
			elo = u.elo;
		}

		public void LoadFromIni()
		{
			engine = CIniFile.Read("engine", "Human", "player " + name);
			parameters = CIniFile.Read("parameters", "", "player " + name);
			mode = CIniFile.Read("mode", "movetime", "player " + name);
			value = CIniFile.Read("value", "1000", "player " + name);
			book = CIniFile.Read("book", "None", "player " + name);
			elo = CIniFile.Read("elo", "1000", "player " + name);
		}

		public void SaveToIni()
		{
			CIniFile.Write("engine", engine, "player " + name);
			CIniFile.Write("parameters", parameters, "player " + name);
			CIniFile.Write("mode", mode, "player " + name);
			CIniFile.Write("value", value, "player " + name);
			CIniFile.Write("book", book, "player " + name);
			CIniFile.Write("elo", elo, "player " + name);
		}
	}

	public class CUserList
	{
		public static List<CUser> list = new List<CUser>();

		public static int GetIndex(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				var user = list[n];
				if (user.name == name)
					return n;
			}
			return -1;
		}

		static CUser GetUserAuto()
		{
			CUser uh = GetUser("Human");
			int elo = Convert.ToInt32(uh.elo);
			CUser ue = GetUserElo(elo);
			CUser uc = new CUser("Auto");
			uc.SetUser(ue.name);
			return uc;
		}

		static CUser GetUserComputer()
		{
			CUser uc = new CUser("Computer");
			uc.engine = "RapChessCs.exe";
			uc.mode = "movetime";
			uc.value = "1000";
			uc.book = "small.txt";
			return uc;
		}

		static CUser GetUserElo(int elo)
		{
			CUser u = null;
			int del = 10000;
			foreach (CUser cu in list)
			{
				if (cu.engine == "Human")
					continue;
				int curDel = Math.Abs(elo - Convert.ToInt32(cu.elo));
				if (curDel < del)
				{
					del = curDel;
					u = cu;
				}
			}
			return u;
		}

		static CUser GetUserHuman()
		{
			CUser uh = new CUser("Human");
			return uh;
		}

		public static CUser GetUser(string name)
		{
			for (int n = 0; n < list.Count; n++)
			{
				CUser user = list[n];
				if (user.name == name)
					return user;
			}
			if (name == "Auto")
				return GetUserAuto();
			return null;
		}

		static bool IsComputer()
		{
			foreach (CUser cu in list)
				if (cu.engine != "Human")
					return true;
			return false;
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
			string player = CIniFile.Read("playerNames");
			var apn = player.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			for (int n = 0; n < apn.Length; n++)
			{
				string name = apn[n];
				var u = new CUser(name);
				u.LoadFromIni();
				list.Add(u);
			}
			if(!IsHuman())
				list.Add(GetUserHuman());
			if (!IsComputer())
				list.Add(GetUserComputer());
			SaveToIni();
		}

		public static void SaveToIni()
		{
			List<string> names = new List<string>();
			for (int n = 0; n < list.Count; n++)
			{
				var user = list[n];
				names.Add(user.name);
				user.SaveToIni();
			}
			names.Sort();
			CIniFile.Write("playerNames", String.Join("|", names.ToArray()));
		}
	}
}
