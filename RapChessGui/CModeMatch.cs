using System.Collections.Generic;
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
		public static string engine1 = CEngineList.def;
		public static string engine2 = CEngineList.def;
		public static string book1 = CBookList.def;
		public static string book2 = CBookList.def;
		public static CModeValue modeValue1 = new CModeValue();
		public static CModeValue modeValue2 = new CModeValue();
		public static CHisElo his = new CHisElo();

		public static void Reset()
		{
			rotate = false;
			games = 0;
			win = 0;
			draw = 0;
			loose = 0;
			his.list.Clear();
			his.Add(0);
		}

		public static int Total()
		{
			return win + draw + loose;
		}

		public static double Point(bool rev)
		{
			if (rev)
				return loose + draw * .5;
			else
				return win + draw * .5;
		}

		public static double Result(bool rev)
		{
			int t = Total();
			if (t == 0)
				return 50;
			if (rev)
				return ((loose * 2 + draw) * 100.0) / (t * 2);
			else
				return ((win * 2 + draw) * 100.0) / (t * 2);
		}

		public static void LoadFromIni()
		{
			rotate = FormChess.RapIni.ReadBool("mode>match>rotate");
			games = FormChess.RapIni.ReadInt("mode>match>games");
			win = FormChess.RapIni.ReadInt("mode>match>win");
			draw = FormChess.RapIni.ReadInt("mode>match>draw");
			loose = FormChess.RapIni.ReadInt("mode>match>loose");
			book1 = FormChess.RapIni.Read("mode>match>book1", book1);
			book2 = FormChess.RapIni.Read("mode>match>book2", book2);
			engine1 = FormChess.RapIni.Read("mode>match>engine1", engine1);
			engine2 = FormChess.RapIni.Read("mode>match>engine2", engine2);
			modeValue1.mode = FormChess.RapIni.Read("mode>match>mode1", modeValue1.mode);
			modeValue2.mode = FormChess.RapIni.Read("mode>match>mode2", modeValue2.mode);
			modeValue1.value = FormChess.RapIni.ReadInt("mode>match>value1", modeValue1.value);
			modeValue2.value = FormChess.RapIni.ReadInt("mode>match>value2", modeValue2.value);
			his.LoadFromStr(FormChess.RapIni.Read("mode>match>his", ""));
		}

		public static void SaveToIni()
		{
			FormChess.RapIni.Write("mode>match>rotate", rotate.ToString());
			FormChess.RapIni.Write("mode>match>games", games.ToString());
			FormChess.RapIni.Write("mode>match>win", win.ToString());
			FormChess.RapIni.Write("mode>match>draw", draw.ToString());
			FormChess.RapIni.Write("mode>match>loose", loose.ToString());
			FormChess.RapIni.Write("mode>match>book1", book1);
			FormChess.RapIni.Write("mode>match>book2", book2);
			FormChess.RapIni.Write("mode>match>engine1", engine1);
			FormChess.RapIni.Write("mode>match>engine2", engine2);
			FormChess.RapIni.Write("mode>match>mode1", modeValue1.mode);
			FormChess.RapIni.Write("mode>match>mode2", modeValue2.mode);
			FormChess.RapIni.Write("mode>match>value1", modeValue1.value);
			FormChess.RapIni.Write("mode>match>value2", modeValue2.value);
			FormChess.RapIni.Write("mode>match>his", his.SaveToStr());
		}

	}
}
