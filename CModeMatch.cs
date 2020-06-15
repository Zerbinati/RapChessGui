using RapIni;

namespace RapChessGui
{
	static class CModeMatch
	{
		public static bool rotate = false;
		public static int games = 0;
		public static int win = 0;
		public static int draw = 0;
		public static int loose = 0;
		public static string engine1;
		public static string engine2;
		public static string book1 = "Eco";
		public static string book2 = "Eco";
		public static CModeValue modeValue1 = new CModeValue();
		public static CModeValue modeValue2 = new CModeValue();
		public static CHisElo his1 = new CHisElo();
		public static CHisElo his2 = new CHisElo();

		public static void Reset()
		{
			rotate = false;
			games = 0;
			win = 0;
			draw = 0;
			loose = 0;
			his1.list.Clear();
			his2.list.Clear();
		}

		public static int Total()
		{
			return win + draw + loose;
		}

		public static int Result(bool rev)
		{
			int t = Total();
			if (t == 0)
				return 50;
			if (rev)
				return ((loose * 2 + draw) * 100) / (t * 2);
			else
				return ((win * 2 + draw) * 100) / (t * 2);
		}

		public static void LoadFromIni()
		{
			rotate = CRapIni.This.ReadBool("mode>match>rotate");
			games = CRapIni.This.ReadInt("mode>match>games");
			win = CRapIni.This.ReadInt("mode>match>win");
			draw = CRapIni.This.ReadInt("mode>match>draw");
			loose = CRapIni.This.ReadInt("mode>match>loose");
			book1 = CRapIni.This.Read("mode>match>book1", book1);
			book2 = CRapIni.This.Read("mode>match>book2", book2);
			engine1 = CRapIni.This.Read("mode>match>engine1", CEngineList.def);
			engine2 = CRapIni.This.Read("mode>match>engine2", CEngineList.def);
			modeValue1.mode = CRapIni.This.Read("mode>match>mode1", "Time");
			modeValue2.mode = CRapIni.This.Read("mode>match>mode2", "Time");
			modeValue1.value = CRapIni.This.ReadInt("mode>match>value1", 1);
			modeValue2.value = CRapIni.This.ReadInt("mode>match>value2", 1);
			his1.LoadFromStr(CRapIni.This.Read("mode>match>his1", ""));
			his2.LoadFromStr(CRapIni.This.Read("mode>match>his2", ""));
		}

		public static void SaveToIni()
		{
			CRapIni.This.Write("mode>match>rotate", rotate.ToString());
			CRapIni.This.Write("mode>match>games", games.ToString());
			CRapIni.This.Write("mode>match>win", win.ToString());
			CRapIni.This.Write("mode>match>draw", draw.ToString());
			CRapIni.This.Write("mode>match>loose", loose.ToString());
			CRapIni.This.Write("mode>match>book1", book1);
			CRapIni.This.Write("mode>match>book2", book2);
			CRapIni.This.Write("mode>match>engine1", engine1);
			CRapIni.This.Write("mode>match>engine2", engine2);
			CRapIni.This.Write("mode>match>mode1", modeValue1.mode);
			CRapIni.This.Write("mode>match>mode2", modeValue2.mode);
			CRapIni.This.Write("mode>match>value1", modeValue1.value);
			CRapIni.This.Write("mode>match>value2", modeValue2.value);
			CRapIni.This.Write("mode>match>his1", his1.SaveToStr());
			CRapIni.This.Write("mode>match>his2", his2.SaveToStr());
		}

	}
}
