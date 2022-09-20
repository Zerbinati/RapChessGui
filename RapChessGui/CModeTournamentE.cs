using System;
using System.Collections.Generic;

namespace RapChessGui
{
	static class CModeTournamentE
	{
		public static bool rotate = true;
		public static int games = 0;
		public static int repetition = 0;
		public static int records = 10000;
		public static int maxElo = 3000;
		public static int minElo = 0;
		public static string first = String.Empty;
		public static string opponent = String.Empty;
		public static string book = "BRU Eco";
		static CLevel level = CLevel.standard;
		public static CTourList tourList = new CTourList("Tour-engines");
		public static CModeValue modeValue = new CModeValue();
		public static CEngineList engineList = new CEngineList();
		public static CEngine engWin = null;
		public static CEngine engLoose = null;

		public static void SaveToIni()
		{
			FormChess.iniFile.Write("mode>tournamentE>book", book);
			FormChess.iniFile.Write("mode>tournamentE>engine", first);
			FormChess.iniFile.Write("mode>tournamentE>mode", modeValue.GetLevel());
			FormChess.iniFile.Write("mode>tournamentE>value", modeValue.value);
			FormChess.iniFile.Write("mode>tournamentE>records", records);
			FormChess.iniFile.Write("mode>tournamentE>rmaxElo", maxElo);
			FormChess.iniFile.Write("mode>tournamentE>minElo", minElo);
		}

		public static void LoadFromIni()
		{
			book = FormChess.iniFile.Read("mode>tournamentE>book", book);
			first = FormChess.iniFile.Read("mode>tournamentE>engine", first);
			modeValue.SetLevel(FormChess.iniFile.Read("mode>tournamentE>mode", modeValue.GetLevel()));
			modeValue.value = FormChess.iniFile.ReadInt("mode>tournamentE>value", modeValue.value);
			records = FormChess.iniFile.ReadInt("mode>tournamentE>records", records);
			maxElo = FormChess.iniFile.ReadInt("mode>tournamentE>maxElo", maxElo);
			minElo = FormChess.iniFile.ReadInt("mode>tournamentE>minElo", minElo);
			tourList.SetLimit(records);
		}

		public static void NewGame()
		{
			rotate = true;
			games = 0;
			repetition = 0;
			opponent = String.Empty;
		}

		public static void ListFill()
		{
			level = modeValue.level;
			engineList.list.Clear();
			foreach (CEngine e in FormChess.engineList.list)
				if (e.FileExists() && (e.tournament > 0) && e.SupportLevel(level))
					if ((e.GetElo() >= minElo) && (e.GetElo() <= maxElo))
						engineList.Add(e);
		}

		public static bool ListUpdate()
		{
			if (level != modeValue.level)
			{
				ListFill();
				return true;
			}
			return false;
		}

		public static CEngine SelectLast()
		{
			int count = 0;
			CEngine result = null;
			foreach (CEngine e in engineList.list)
			{
				int c = tourList.LastGame(e.name);
				if (count <= c)
				{
					count = c;
					result = e;
				}
			}
			return result;
		}

		public static CEngine SelectFirst()
		{
			CEngine e = engineList.GetEngineByName(FormOptions.tourESelected);
			if (e != null)
				return e;
			e = engineList.GetEngineByName(first);
			if ((e == null) || ((games >= repetition) && (games > 0)))
			{
				e = SelectLast();
				games = 0;
			}
			return e;
		}

		public static CEngine SelectSecond(CEngine engine)
		{
			if (engineList.list.Count == 0)
				return engine;
			engineList.SetEloDistance(engine);
			double bstScore = 0.0;
			CEngine bstEngine = engine;
			for (int n = 1; n < engineList.list.Count - 1; n++)
			{
				CEngine e = engineList.list[n];
				double curScore = EvaluateOpponent(engine, e);
				if (bstScore < curScore)
				{
					bstScore = curScore;
					bstEngine = e;
				}

			}
			return bstEngine;
		}

		public static double EvaluateOpponent(CEngine first, CEngine second)
		{
			int fElo = first.GetElo();
			int sElo = second.GetElo();
			double ratioDistance = (engineList.list.Count - second.position) / (double)engineList.list.Count;
			int allGames = tourList.CountGames(second.name);
			tourList.CountGames(first.name, second.name, out int rw, out int rl, out int rd);
			int curGames = rw + rl + rd;
			double r = ((rw * 2.0 + rd) - curGames) / (curGames + 1.0);
			double ratioElo = (3000.0 - Math.Abs(sElo - fElo)) / 3000.0;
			if ((r > 0) && (fElo < sElo))
				ratioElo += r;
			if ((r < 0) && (fElo > sElo))
				ratioElo -= r;
			double ratioGames = (allGames - curGames) / (double)allGames;
			return ratioElo + ratioGames + ratioDistance;
		}

		public static void SetRepeition(CEngine e, CEngine o)
		{
			if ((first != e.name) || (opponent != o.name))
			{
				first = e.name;
				opponent = o.name;
				SaveToIni();
				int cg = tourList.CountGames(e.name, o.name, out int rw, out int rl, out _);
				if (games == 0)
				{
					repetition = e.tournament;
					if (cg == 0)
						repetition++;
					if ((e.GetElo() > o.GetElo()) != (rw > rl))
						repetition++;
					if (e.hisElo.list.Count < o.hisElo.list.Count)
						repetition += 2;
					rotate = true;
				}
			}
			games++;
			rotate ^= true;
		}

	}

}
