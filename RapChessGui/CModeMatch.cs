using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{
	static class CModeMatch
	{
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
		static CColor color;

		public static bool Rotate
		{
			get { return (Games & 1) > 0; }
		}

		public static int Games
		{
			get { return win + loose + draw; }
		}

		public static void Reset()
		{
			win = 0;
			draw = 0;
			loose = 0;
			his.list.Clear();
			SaveToIni();
		}

		public static void GameStart()
		{
			color = Rotate ? CColor.black : CColor.white;
		}

		public static void GameEnd(CColor winColor)
		{
			if (winColor == CColor.none)
				draw++;
			else if (winColor == color)
				win++;
			else
				loose++;
			his.Add(win - loose);
			if(his.list.Count==1)
				his.Add(win - loose);
			SaveToIni();
		}

		public static double Result(bool rev)
		{
			int t = Games;
			if (t == 0)
				return 50;
			if (rev)
				return ((loose * 2 + draw) * 100.0) / (t * 2);
			else
				return ((win * 2 + draw) * 100.0) / (t * 2);
		}

		public static void LoadFromIni()
		{
			win = FormChess.iniFile.ReadInt("mode>match>win");
			draw = FormChess.iniFile.ReadInt("mode>match>draw");
			loose = FormChess.iniFile.ReadInt("mode>match>loose");
			book1 = FormChess.iniFile.Read("mode>match>book1", book1);
			book2 = FormChess.iniFile.Read("mode>match>book2", book2);
			engine1 = FormChess.iniFile.Read("mode>match>engine1", engine1);
			engine2 = FormChess.iniFile.Read("mode>match>engine2", engine2);
			modeValue1.SetLevel(FormChess.iniFile.Read("mode>match>mode1", modeValue1.GetLevel()));
			modeValue2.SetLevel(FormChess.iniFile.Read("mode>match>mode2", modeValue2.GetLevel()));
			modeValue1.value = FormChess.iniFile.ReadInt("mode>match>value1", modeValue1.value);
			modeValue2.value = FormChess.iniFile.ReadInt("mode>match>value2", modeValue2.value);
			his.LoadFromStr(FormChess.iniFile.Read("mode>match>his", string.Empty));
		}

		public static void SaveToIni()
		{
			FormChess.iniFile.Write("mode>match>win", win.ToString());
			FormChess.iniFile.Write("mode>match>draw", draw.ToString());
			FormChess.iniFile.Write("mode>match>loose", loose.ToString());
			FormChess.iniFile.Write("mode>match>book1", book1);
			FormChess.iniFile.Write("mode>match>book2", book2);
			FormChess.iniFile.Write("mode>match>engine1", engine1);
			FormChess.iniFile.Write("mode>match>engine2", engine2);
			FormChess.iniFile.Write("mode>match>mode1", modeValue1.GetLevel());
			FormChess.iniFile.Write("mode>match>mode2", modeValue2.GetLevel());
			FormChess.iniFile.Write("mode>match>value1", modeValue1.value);
			FormChess.iniFile.Write("mode>match>value2", modeValue2.value);
			FormChess.iniFile.Write("mode>match>his", his.SaveToStr());
		}

	}
}
