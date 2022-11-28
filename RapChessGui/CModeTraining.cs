using System;

namespace RapChessGui
{
	static class CModeTraining
	{
		public static bool rotate = false;
		public static int games;
		public static int win;
		public static int draw;
		public static int loose;
		public static int winInRow = 0;
		public static string trainer = String.Empty;
		public static string trained = String.Empty;
		public static string trainerBook = CBookList.def;
		public static string trainedBook = CBookList.def;
		public static CModeValue modeValueTrainer = new CModeValue();
		public static CModeValue modeValueTrained = new CModeValue();
		public static CHisElo his = new CHisElo();

		public static void Reset()
		{
			rotate = false;
			games = 0;
			win = 0;
			draw = 0;
			loose = 0;
			winInRow = 0;
			his.Clear();
			SaveToIni();
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

		public static void SaveToIni()
		{
			FormChess.iniFile.Write("mode>training>win", win);
			FormChess.iniFile.Write("mode>training>draw", draw);
			FormChess.iniFile.Write("mode>training>loose", loose);
			FormChess.iniFile.Write("mode>training>trainer", trainer);
			FormChess.iniFile.Write("mode>training>trained", trained);
			FormChess.iniFile.Write("mode>training>trainerBook", trainerBook);
			FormChess.iniFile.Write("mode>training>trainedBook", trainedBook);
			FormChess.iniFile.Write("mode>training>trainerValue", modeValueTrainer.value);
			FormChess.iniFile.Write("mode>training>trainedValue", modeValueTrained.value);
			FormChess.iniFile.Write("mode>training>trainerMode", modeValueTrainer.GetLevel());
			FormChess.iniFile.Write("mode>training>trainedMode", modeValueTrained.GetLevel());
			FormChess.iniFile.Write("mode>training>his", his.SaveToStr());
		}

		public static void LoadFromIni()
		{
			win = FormChess.iniFile.ReadInt("mode>training>win");
			draw = FormChess.iniFile.ReadInt("mode>training>draw");
			loose = FormChess.iniFile.ReadInt("mode>training>loose");
			trainer = FormChess.iniFile.Read("mode>training>trainer", CEngineList.def);
			trained = FormChess.iniFile.Read("mode>training>trained", CEngineList.def);
			trainerBook = FormChess.iniFile.Read("mode>training>trainerBook", trainerBook);
			trainedBook = FormChess.iniFile.Read("mode>training>trainedBook", trainedBook);
			modeValueTrainer.value = FormChess.iniFile.ReadInt("mode>training>trainerValue", modeValueTrainer.value);
			modeValueTrained.value = FormChess.iniFile.ReadInt("mode>training>trainedValue", modeValueTrained.value);
			modeValueTrainer.SetLevel(FormChess.iniFile.Read("mode>training>trainerMode", modeValueTrainer.GetLevel()));
			modeValueTrained.SetLevel(FormChess.iniFile.Read("mode>training>trainedMode", modeValueTrained.GetLevel()));
			his.LoadFromStr(FormChess.iniFile.Read("mode>training>his", string.Empty));
		}

	}
}
