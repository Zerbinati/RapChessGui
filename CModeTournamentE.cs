using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{
	static class CModeTournamentE
	{
		static bool next = false;
		public static bool rotate = false;
		public static int repetition = 1;
		public static int records = 10000;
		public static string engine;
		public static string book = "Eco";
		public static CTourList tourList = new CTourList("Tour-engines");
		public static CModeValue modeValue = new CModeValue();
		public static CEngineList engineList = new CEngineList();

		public static void SaveToIni()
		{
			CRapIni.This.Write("mode>tournamentE>book", book);
			CRapIni.This.Write("mode>tournamentE>engine", engine);
			CRapIni.This.Write("mode>tournamentE>mode", modeValue.mode);
			CRapIni.This.Write("mode>tournamentE>value", modeValue.value);
			CRapIni.This.Write("mode>tournamentE>records", records);
		}

		public static void LoadFromIni()
		{
			book = CRapIni.This.Read("mode>tournamentE>book", book);
			engine = CRapIni.This.Read("mode>tournamentE>engine", "");
			modeValue.mode = CRapIni.This.Read("mode>tournamentE>mode", modeValue.mode);
			modeValue.value = CRapIni.This.ReadInt("mode>tournamentE>value", modeValue.value);
			records = CRapIni.This.ReadInt("mode>tournamentE>records", records);
			tourList.SetLimit(records);
		}

		public static void NewGame()
		{
			next = false;
		}

		public static void FillList()
		{
			engineList.list.Clear();
			foreach (CEngine e in FormChess.engineList.list)
				if ((e.tournament > 0) && ((modeValue.mode != "Standard")||e.modeStandard))
					engineList.Add(e);
		}

		public static CEngine ChooseOpponent(CEngine engine, CEngine engine1, CEngine engine2)
		{
			tourList.CountGames(engine.name, engine1.name, out int rw1, out int rl1, out int rd1);
			tourList.CountGames(engine.name, engine2.name, out int rw2, out int rl2, out int rd2);
			if ((engine.GetElo() > engine1.GetElo()) != (rw1 > rl1))
				return engine1;
			if ((engine.GetElo() > engine2.GetElo()) != (rw2 > rl2))
				return engine2;
			int count1 = (rw1 + rl1 + rd1) << Math.Abs(engine1.position - engine.position);
			int count2 = (rw2 + rl2 + rd2) << Math.Abs(engine2.position - engine.position);
			if (count1 == 0)
				return engine1;
			if (count2 == 0)
				return engine2;
			if (count1 > count2)
				return engine2;
			if (count2 > count1)
				return engine1;
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
			if(next)
				e = engineList.NextTournament(e);
			next = true;
			engine = e.name;
			SaveToIni();
			return e;
		}

		public static CEngine SelectOpponent(CEngine engine)
		{
			engineList.Sort();
			engineList.FillPosition();
			foreach (CEngine e in engineList.list)
				e.distance = Math.Abs(engine.position - e.position);
			engineList.SortDistance();
			List<CEngine> el = new List<CEngine>();
			foreach (CEngine e in engineList.list)
				if (e != engine)
					el.Add(e);
			if (el.Count == 0)
				return engine;
			engineList.Sort();
			for (int n = 0; n < el.Count - 1; n++)
			{
				CEngine e = ChooseOpponent(engine, el[n], el[n + 1]);
				if (e != null)
					return e;
			}
			return el[0];
		}

		public static void SetRepeition(CEngine e,CEngine o)
		{
			tourList.CountGames(e.name, o.name, out int rw, out int rl, out _);
			repetition = e.tournament;
			if ((e.GetElo() > o.GetElo()) != (rw>rl))
				repetition++;
		}

	}

}
