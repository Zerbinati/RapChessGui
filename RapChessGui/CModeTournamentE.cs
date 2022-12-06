﻿using System;
using System.Collections.Generic;

namespace RapChessGui
{
	static class CModeTournamentE
	{
		public static bool rotate = true;
		public static int games = 0;
		public static int repetition = 0;
		public static int records = 10000;
		public static int eloAvg = 0;
		public static int eloRange = 0;
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
			FormChess.iniFile.Write("mode>tournamentE>eloAvg", eloAvg);
			FormChess.iniFile.Write("mode>tournamentE>eloRange", eloRange);
		}

		public static void LoadFromIni()
		{
			book = FormChess.iniFile.Read("mode>tournamentE>book", book);
			first = FormChess.iniFile.Read("mode>tournamentE>engine", first);
			modeValue.SetLevel(FormChess.iniFile.Read("mode>tournamentE>mode", modeValue.GetLevel()));
			modeValue.value = FormChess.iniFile.ReadInt("mode>tournamentE>value", modeValue.value);
			records = FormChess.iniFile.ReadInt("mode>tournamentE>records", records);
			eloAvg = FormChess.iniFile.ReadInt("mode>tournamentE>eloAvg", eloAvg);
			eloRange = FormChess.iniFile.ReadInt("mode>tournamentE>eloRange", eloRange);
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
			int avg = eloAvg;
			CEngine eng = FormChess.engineList.GetEngineByName(FormOptions.tourESelected);
			if (eng != null)
				avg = eng.GetElo();
			int eloMin = avg - eloRange;
			int eloMax = avg + eloRange;
			if ((eloRange == 0) || (avg == 0))
			{
				eloMin = 0;
				eloMax = 3000;
			}
			level = modeValue.level;
			engineList.Clear();
			foreach (CEngine e in FormChess.engineList)
				if (e.FileExists() && (e.tournament > 0) && e.SupportLevel(level))
					if ((e.GetElo() >= eloMin) && (e.GetElo() <= eloMax))
						engineList.AddEngine(e);
		}

		public static CEngine SelectLast()
		{
			int count = 0;
			CEngine result = null;
			foreach (CEngine e in engineList)
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
			ListFill();
			CEngine e = engineList.GetEngineByName(FormOptions.tourESelected);
			if ((e != null) && (eloRange == 0))
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
			if (engineList.Count < 2)
				return engine;
			engineList.SetEloDistance(engine);
			double bstScore = double.MinValue;
			CEngine bstEngine = engine;
			foreach (CEngine e in engineList)
				if (e != engine)
				{
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
			int allGames = tourList.CountGames(first.name);
			int curGames = tourList.CountGames(second.name, first.name, out int rw, out _, out int rd);
			double ratioScore = 0;
			double r = ((rw * 2.0 + rd) - curGames) / (curGames + 1.0);
			double ar = Math.Abs(r);
			double nElo = fElo;
			if (r < 0)
				nElo -= ar * fElo;
			if (r > 0)
				nElo += ar * (CElo.eloMax - fElo);
			double ratioElo = (Math.Abs(sElo - nElo) / CElo.eloRange) * (1.0 - ar);
			if (curGames == 0)
				ratioElo = 0;
			if ((r > 0) && (sElo < fElo))
				ratioScore = 1;
			if ((r < 0) && (sElo > fElo))
				ratioScore = 1;
			double avgCount = allGames / engineList.Count;
			double maxCount = avgCount * 2 + 1;
			double optCount = (maxCount * (engineList.Count - second.position)) / engineList.Count;
			double ratioDistance = (optCount - curGames) / maxCount;
			return ratioDistance + ratioElo + ratioScore;
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
					if (e.hisElo.Count < o.hisElo.Count)
						repetition += 2;
					rotate = true;
				}
			}
			games++;
			rotate ^= true;
		}

	}

}
