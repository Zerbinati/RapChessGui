using System;
using System.Collections.Generic;

namespace RapChessGui
{
	static class CModeTournamentP
	{
		public static bool rotate = false;
		public static int games = 0;
		public static int repetition = 0;
		public static int records = 10000;
		public static int maxElo = 3000;
		public static int minElo = 0;
		public static string player = "";
		public static string opponent = "";
		public static CTourList tourList = new CTourList("Tour-players");
		public static CPlayerList playerList = new CPlayerList();
		public static CPlayer plaWin = null;
		public static CPlayer plaLoose = null;

		public static void SaveToIni()
		{
			FormChess.iniFile.Write("mode>tournamentP>player", player);
			FormChess.iniFile.Write("mode>tournamentP>records", records);
			FormChess.iniFile.Write("mode>tournamentP>rmaxElo", maxElo);
			FormChess.iniFile.Write("mode>tournamentP>minElo", minElo);
		}

		public static void LoadFromIni()
		{
			player = FormChess.iniFile.Read("mode>tournamentP>player", player);
			records = FormChess.iniFile.ReadInt("mode>tournamentP>records", records);
			maxElo = FormChess.iniFile.ReadInt("mode>tournamentP>maxElo", maxElo);
			minElo = FormChess.iniFile.ReadInt("mode>tournamentP>minElo", minElo);
			tourList.SetLimit(records);
		}

		public static void NewGame()
		{
			rotate = true;
			games = 0;
			repetition = 0;
			opponent = String.Empty;
		}

		public static CPlayer ChooseOpponent(CPlayer player, CPlayer player1, CPlayer player2)
		{
			tourList.CountGames(player.name, player1.name, out int rw1, out int rl1, out int rd1);
			tourList.CountGames(player.name, player2.name, out int rw2, out int rl2, out int rd2);
			if ((player.GetElo() > player1.GetElo()) != (rw1 > rl1))
				return player1;
			if ((player.GetElo() > player2.GetElo()) != (rw2 > rl2))
				return player2;
			int count1 = (rw1 + rl1 + rd1);
			int count2 = (rw2 + rl2 + rd2);
			if (count1 * 1.1 <= count2 << 1)
				return player1;
			if (count2 * 1.1 <= count1 >> 1)
				return player2;
			return null;
		}

		public static CPlayerList FillList()
		{
			playerList.list.Clear();
			foreach (CPlayer p in FormChess.playerList.list)
				if ((p.tournament > 0) && p.IsComputer())
					if ((p.GetElo() >= minElo) && (p.GetElo() <= maxElo))
						playerList.Add(p);
			return playerList;
		}

		public static CPlayer SelectRare()
		{
			int count = 0;
			CPlayer result = null;
			foreach (CPlayer p in playerList.list)
			{
				int c = tourList.CountGames(p.name);
				if (count <= c)
				{
					count = c;
					result = p;
				}
			}
			return result;
		}

		public static CPlayer SelectPlayer()
		{
			CPlayer p = playerList.GetPlayer(player);
			if (p == null)
				p = SelectRare();
			if ((games >= repetition) && (games > 0))
			{
				p = playerList.NextTournament(p);
				games = 0;
			}
			return p;
		}

		public static CPlayer SelectOpponent(CPlayer player)
		{
			playerList.SortPosition(player);
			List<CPlayer> pl = new List<CPlayer>();
			foreach (CPlayer p in playerList.list)
				if ((p != player) && (p.engine != "Human"))
					pl.Add(p);
			if (pl.Count == 0)
				return player;
			for (int n = 0; n < pl.Count - 1; n++)
			{
				CPlayer p = ChooseOpponent(player, pl[n], pl[n + 1]);
				if (p != null)
					return p;
			}
			return pl[0];
		}

		public static void SetRepeition(CPlayer p, CPlayer o)
		{
			if ((player != p.name) || (opponent != o.name))
			{
				player = p.name;
				opponent = o.name;
				SaveToIni();
				tourList.CountGames(p.name, o.name, out int rw, out int rl, out _);
				if (games == 0)
				{
					repetition = p.tournament;
					if ((p.GetElo() > o.GetElo()) != (rw > rl))
						repetition++;
					if (p.hisElo.list.Count < o.hisElo.list.Count)
						repetition++;
					rotate = true;
				}
			}
			games++;
			rotate ^= true;
		}
	}

}
