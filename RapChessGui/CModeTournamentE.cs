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
		public static string engine = String.Empty;
		public static string opponent = String.Empty;
		public static string book = "BRU Eco";
		public static CTourList tourList = new CTourList("Tour-engines");
		public static CModeValue modeValue = new CModeValue();
		public static CEngineList engineList = new CEngineList();
		public static CEngine engWin = null;
		public static CEngine engLoose = null;

		public static void SaveToIni()
		{
			FormChess.RapIni.Write("mode>tournamentE>book", book);
			FormChess.RapIni.Write("mode>tournamentE>engine", engine);
			FormChess.RapIni.Write("mode>tournamentE>mode", modeValue.mode);
			FormChess.RapIni.Write("mode>tournamentE>value", modeValue.value);
			FormChess.RapIni.Write("mode>tournamentE>records", records);
			FormChess.RapIni.Write("mode>tournamentE>rmaxElo", maxElo);
			FormChess.RapIni.Write("mode>tournamentE>minElo", minElo);
		}

		public static void LoadFromIni()
		{
			book = FormChess.RapIni.Read("mode>tournamentE>book", book);
			engine = FormChess.RapIni.Read("mode>tournamentE>engine", engine);
			modeValue.mode = FormChess.RapIni.Read("mode>tournamentE>mode", modeValue.mode);
			modeValue.value = FormChess.RapIni.ReadInt("mode>tournamentE>value", modeValue.value);
			records = FormChess.RapIni.ReadInt("mode>tournamentE>records", records);
			maxElo = FormChess.RapIni.ReadInt("mode>tournamentE>maxElo", maxElo);
			minElo = FormChess.RapIni.ReadInt("mode>tournamentE>minElo", minElo);
			tourList.SetLimit(records);
		}

		public static void NewGame()
		{
			rotate = true;
			games = 0;
			repetition = 0;
			opponent = String.Empty;
		}

		public static CEngineList FillList()
		{
			engineList.list.Clear();
			foreach (CEngine e in FormChess.engineList.list)
				if ((e.tournament > 0) && ((modeValue.mode != "Standard") || e.modeStandard))
					if ((e.GetElo() >= minElo) && (e.GetElo() <= maxElo))
						engineList.Add(e);
			return engineList;
		}

		public static CEngine ChooseOpponent(CEngine engine, CEngine engine1, CEngine engine2)
		{
			tourList.CountGames(engine.name, engine1.name, out int rw1, out int rl1, out int rd1);
			tourList.CountGames(engine.name, engine2.name, out int rw2, out int rl2, out int rd2);
			if ((engine.GetElo() > engine1.GetElo()) != (rw1 > rl1))
				return engine1;
			if ((engine.GetElo() > engine2.GetElo()) != (rw2 > rl2))
				return engine2;
			int count1 = (rw1 + rl1 + rd1);
			int count2 = (rw2 + rl2 + rd2);
			if (count1 * 1.1 <= count2 << 1)
				return engine1;
			if (count2 * 1.1 <= count1 >> 1)
				return engine2;
			return null;
		}

		public static CEngine SelectRare()
		{
			int count = 0;
			CEngine result = null;
			foreach (CEngine e in engineList.list)
			{
				int c = tourList.CountGames(e.name);
				if (count <= c)
				{
					count = c;
					result = e;
				}
			}
			return result;
		}

		public static CEngine SelectEngine()
		{
			CEngine e = engineList.GetEngine(engine);
			if (e == null)
				e = SelectRare();
			if ((games >= repetition) && (games > 0))
			{
				e = engineList.NextTournament(e);
				games = 0;
			}
			return e;
		}

		public static CEngine SelectOpponent(CEngine engine)
		{
			engineList.SortPosition(engine);
			List<CEngine> el = new List<CEngine>();
			foreach (CEngine e in engineList.list)
				if (e != engine)
					el.Add(e);
			if (el.Count == 0)
				return engine;
			for (int n = 0; n < el.Count - 1; n++)
			{
				CEngine e = ChooseOpponent(engine, el[n], el[n + 1]);
				if (e != null)
					return e;
			}
			return el[0];
		}

		public static void SetRepeition(CEngine e, CEngine o)
		{
			if ((engine != e.name) || (opponent != o.name))
			{
				engine = e.name;
				opponent = o.name;
				SaveToIni();
				tourList.CountGames(e.name, o.name, out int rw, out int rl, out _);
				if (games == 0)
				{
					repetition = e.tournament;
					if ((e.GetElo() > o.GetElo()) != (rw > rl))
						repetition++;
					rotate = true;
				}
			}
			games++;
			rotate ^= true;
		}

	}

}
