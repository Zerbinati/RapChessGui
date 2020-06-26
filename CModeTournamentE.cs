using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{
	static class CModeTournamentE
	{
		public static string engine;
		public static string book = "Eco";
		public static bool rotate = false;
		public static CTourList tourList = new CTourList("Tour-engines");
		public static CModeValue modeValue = new CModeValue();
		public static CEngineList engineList = new CEngineList();

		public static void SaveToIni()
		{
			CRapIni.This.Write("mode>tournamentE>book", book);
			CRapIni.This.Write("mode>tournamentE>engine", engine);
			CRapIni.This.Write("mode>tournamentE>mode", modeValue.mode);
			CRapIni.This.Write("mode>tournamentE>value", modeValue.value);
		}

		public static void LoadFromIni()
		{
			book = CRapIni.This.Read("mode>tournamentE>book", book);
			engine = CRapIni.This.Read("mode>tournamentE>engine","");
			modeValue.mode = CRapIni.This.Read("mode>tournamentE>mode",modeValue.mode);
			modeValue.value = CRapIni.This.ReadInt("mode>tournamentE>value",modeValue.value);
		}

		public static void FillList()
		{
			engineList.list.Clear();
			foreach (CEngine e in FormChess.engineList.list)
				if (e.tournament)
					engineList.Add(e);
		}

		public static CEngine ChooseOpponent(CEngine engine, CEngine engine1, CEngine engine2)
		{
			int elo = Convert.ToInt32(engine.elo);
			int elo1 = Convert.ToInt32(engine1.elo);
			int elo2 = Convert.ToInt32(engine2.elo);
			int rw1 = 0;
			int rl1 = 0;
			int rd1 = 0;
			int rw2 = 0;
			int rl2 = 0;
			int rd2 = 0;
			int r1 = 50;
			int r2 = 50;
			tourList.CountGames(engine.name, engine1.name, ref rw1, ref rl1, ref rd1);
			tourList.CountGames(engine.name, engine2.name, ref rw2, ref rl2, ref rd2);
			int count1 = rw1 + rl1 + rd1;
			int count2 = rw2 + rl2 + rd2;
			if (count1 > 0)
				r1 = (rw1 * 100 + rd1 * 50) / count1;
			if (count2 > 0)
				r2 = (rw2 * 100 + rd2 * 50) / count2;
			count1 <<= Math.Abs(engine1.position - engine.position);
			count2 <<= Math.Abs(engine2.position - engine.position);
			if (count1 == 0)
				return engine1;
			if (count2 == 0)
				return engine2;
			if ((elo > elo1) && (r1 < 50))
				count1 >>= 1;
			if ((elo < elo1) && (r1 > 50))
				count1 >>= 1;
			if ((elo > elo2) && (r2 < 50))
				count2 >>= 1;
			if ((elo < elo2) && (r2 > 50))
				count2 >>= 1;
			if (count1 > count2)
				return engine2;
			if (count2 > count1)
				return engine1;
			return null;
		}

		public static CEngine SelectEngine()
		{
			CEngine e = engineList.GetEngine(engine);
			if(e == null)
				e = tourList.LastEngine();
			if (e == null)
				e = engineList.list[0];
			CEngine n = engineList.NextEngine(e);
			int rw = 0;
			int rl = 0;
			int rd = 0;
			tourList.CountGames(e.name, n.name, ref rw, ref rl, ref rd);
			CEngine result = rw >= rl ? n : e;
			engine = result.name;
			SaveToIni();
			return result;
		}

		public static CEngine SelectOpponent(CEngine engine)
		{
			engineList.Sort();
			engineList.FillPosition();
			for (int n = 0; n < engineList.list.Count; n++)
			{
				CEngine e = engineList.list[n];
				e.distance = Math.Abs(engine.position - e.position);
			}
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

	}

}
