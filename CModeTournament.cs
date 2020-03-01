using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{
	static class CModeTournament
	{
		private static int playerIndex = 0;

		public static void LoadFromIni()
		{
			playerIndex = Convert.ToInt32(CRapIni.This.Read("mode>tournament>tournament", "0"));
		}

		private static void SaveToIni()
		{
			CRapIni.This.Write("mode>tournament>tournament", playerIndex.ToString());
		}

		public static CPlayer GetUser()
		{
			CPlayerList.Sort();
			List<CPlayer> list = new List<CPlayer>();
			foreach (CPlayer u in CPlayerList.list)
				if (u.engine != "Human")
					list.Add(u);
			if (--playerIndex < 0)
				playerIndex = list.Count - 1;
			playerIndex %= list.Count;
			SaveToIni();
			return list[playerIndex];
		}

	}

}
