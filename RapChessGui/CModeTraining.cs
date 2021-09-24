using RapIni;

namespace RapChessGui
{
	static class CModeTraining
	{
		public static bool rotate = false;
		public static int games;
		public static int win;
		public static int draw;
		public static int loose;
		public static string teacher = "";
		public static string trained = "";
		public static string teacherBook = CBookList.def;
		public static string trainedBook = CBookList.def;
		public static CModeValue modeValueTeacher = new CModeValue();
		public static CModeValue modeValueTrained = new CModeValue();

		public static void Reset()
		{
			rotate = false;
			games = 0;
			win = 0;
			draw = 0;
			loose = 0;
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
			FormChess.RapIni.Write("mode>training>teacher", teacher);
			FormChess.RapIni.Write("mode>training>trained", trained);
			FormChess.RapIni.Write("mode>training>teacherBook", teacherBook);
			FormChess.RapIni.Write("mode>training>trainedBook", trainedBook);
			FormChess.RapIni.Write("mode>training>teacherValue", modeValueTeacher.value);
			FormChess.RapIni.Write("mode>training>trainedValue", modeValueTrained.value);
			FormChess.RapIni.Write("mode>training>teacherMode", modeValueTeacher.mode);
			FormChess.RapIni.Write("mode>training>trainedMode", modeValueTrained.mode);
		}

		public static void LoadFromIni()
		{
			teacher = FormChess.RapIni.Read("mode>training>teacher", CEngineList.def);
			trained = FormChess.RapIni.Read("mode>training>trained", CEngineList.def);
			teacherBook = FormChess.RapIni.Read("mode>training>teacherBook", teacherBook);
			trainedBook = FormChess.RapIni.Read("mode>training>trainedBook", trainedBook);
			modeValueTeacher.value = FormChess.RapIni.ReadInt("mode>training>teacherValue", modeValueTeacher.value);
			modeValueTrained.value = FormChess.RapIni.ReadInt("mode>training>trainedValue", modeValueTrained.value);
			modeValueTeacher.mode = FormChess.RapIni.Read("mode>training>teacherMode", modeValueTeacher.mode);
			modeValueTrained.mode = FormChess.RapIni.Read("mode>training>trainedMode", modeValueTrained.mode);
		}

	}
}
