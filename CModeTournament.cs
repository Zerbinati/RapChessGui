using System;
using System.Collections.Generic;

namespace RapChessGui
{
	static class CModeTournament
	{
		public static CTourList tourList = new CTourList();

		public static CPlayer ChooseOpponent(CPlayer player, CPlayer player1, CPlayer player2)
		{
			int p = CPlayerList.GetIndex(player.name);
			int p1 = CPlayerList.GetIndex(player1.name);
			int p2 = CPlayerList.GetIndex(player2.name);
			int elo = Convert.ToInt32(player.elo);
			int elo1 = Convert.ToInt32(player1.elo);
			int elo2 = Convert.ToInt32(player2.elo);
			double r1 = 0;
			double r2 = 0;
			int count1 = tourList.CountGames(player.name, player1.name, ref r1);
			int count2 = tourList.CountGames(player.name, player2.name, ref r2);
			count1 <<= (Math.Abs(p - p1) - 1);
			if (count1 == 0)
				return player1;
			count2 <<= (Math.Abs(p - p2) - 1);
			if (count2 == 0)
				return player2;
			if ((elo > elo1) && (r1 < 0.5))
				count1 >>= 1;
			if ((elo < elo1) && (r1 > 0.5))
				count1 >>= 1;
			if ((elo > elo2) && (r2 < 0.5))
				count2 >>= 1;
			if ((elo < elo2) && (r2 > 0.5))
				count2 >>= 1;
			if (count1 > count2)
				return player2;
			if (count2 > count1)
				return player1;
			return null;
		}

		public static CPlayer SelectPlayer()
		{
			List<string> pl = new List<string>();
			foreach (CPlayer p in CPlayerList.list)
				if (p.engine != "Human")
					pl.Add(p.name);
			if (pl.Count == 0)
				return null;
			for(int n = tourList.list.Count - 1; n >= 0; n--)
			{
				CTour t = tourList.list[n];
				if (pl.Count == 1)
					break;
				int i;
				i = pl.IndexOf(t.w);
				if(i >= 0)
				pl.RemoveAt(i);

			}
			return CPlayerList.GetPlayer(pl[0]);
		}

		public static CPlayer SelectOpponent(CPlayer player)
		{
			CPlayerList.SortElo(Convert.ToInt32(player.elo));
			List<CPlayer> pl = new List<CPlayer>();
			foreach (CPlayer p in CPlayerList.list)
				if ((p != player) && (p.engine != "Human"))
					pl.Add(p);
			if (pl.Count == 0)
				return player;
			CPlayerList.Sort();
			for (int n = 0; n < pl.Count - 1; n++)
			{
				CPlayer p = ChooseOpponent(player, pl[n], pl[n + 1]);
				if (p != null)
					return p;
			}
			return pl[0];
		}

	}

}
