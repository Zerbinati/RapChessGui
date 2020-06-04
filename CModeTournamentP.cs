using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{
	static class CModeTournamentP
	{
		public static string player;
		public static bool rotate = false;
		public static CTourList tourList = new CTourList("Tour-players");
		public static CPlayerList playerList = new CPlayerList();

		public static void SaveToIni()
		{
			CRapIni.This.Write("mode>tournamentP>player", player);
		}

		public static void LoadFromIni()
		{
			player = CRapIni.This.Read("mode>tournamentP>player","");
		}

		public static CPlayer ChooseOpponent(CPlayer player, CPlayer player1, CPlayer player2)
		{
			int elo = Convert.ToInt32(player.elo);
			int elo1 = Convert.ToInt32(player1.elo);
			int elo2 = Convert.ToInt32(player2.elo);
			int rw1 = 0;
			int rl1 = 0;
			int rd1 = 0;
			int rw2 = 0;
			int rl2 = 0;
			int rd2 = 0;
			int r1 = 50;
			int r2 = 50;
			tourList.CountGames(player.name, player1.name, ref rw1, ref rl1, ref rd1);
			tourList.CountGames(player.name, player2.name, ref rw2, ref rl2, ref rd2);
			int count1 = rw1 + rl1 + rd1;
			int count2 = rw2 + rl2 + rd2;
			if (count1 > 0)
				r1 = (rw1 * 100 + rd1 * 50) / count1;
			if (count2 > 0)
				r2 = (rw2 * 100 + rd2 * 50) / count2;
			count1 <<= Math.Abs(player1.distance);
			count2 <<= Math.Abs(player2.distance);
			if (count1 == 0)
				return player1;
			if (count2 == 0)
				return player2;
			if ((elo > elo1) && (r1 < 50))
				count1 >>= 1;
			if ((elo < elo1) && (r1 > 50))
				count1 >>= 1;
			if ((elo > elo2) && (r2 < 50))
				count2 >>= 1;
			if ((elo < elo2) && (r2 > 50))
				count2 >>= 1;
			if (count1 > count2)
				return player2;
			if (count2 > count1)
				return player1;
			return null;
		}

		public static void FillList()
		{
			playerList.list.Clear();
			foreach (CPlayer p in CData.playerList.list)
				if (p.tournament)
					playerList.Add(p);
		}

		public static CPlayer SelectPlayer()
		{
			CPlayer p = playerList.GetPlayer(player);
			if(p == null)
				p = tourList.LastPlayer();
			if (p == null)
				p = playerList.list[0];
			CPlayer n = playerList.NextPlayer(p);
			int rw = 0;
			int rl = 0;
			int rd = 0;
			tourList.CountGames(p.name, n.name, ref rw, ref rl, ref rd);
			CPlayer result = rw >= rl ? n : p;
			player = result.name;
			SaveToIni();
			return result;
		}

		public static CPlayer SelectOpponent(CPlayer player)
		{
			playerList.Sort();
			playerList.FillPosition();
			for (int n = 0; n < playerList.list.Count; n++)
			{
				CPlayer p = playerList.list[n];
				p.distance = Math.Abs(player.position - p.position);
			}
			playerList.SortDistance();
			List<CPlayer> pl = new List<CPlayer>();
			foreach (CPlayer p in playerList.list)
				if ((p != player) && (p.engine != "Human"))
					pl.Add(p);
			if (pl.Count == 0)
				return player;
			playerList.Sort();
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
