using RapIni;

namespace RapChessGui
{
	static class CModeTraining
	{
		public static bool rotate = false;
		public static int games = 0;
		public static int win = 0;
		public static int draw = 0;
		public static int loose = 0;
		public static string teacher = "";
		public static string trained = "";
		public static string teacherBook = "Small";
		public static string trainedBook = "Small";
		public static string teacherMode = "Time";
		public static string trainedMode = "Time";
		public static int teacherValue = 10;
		public static int trainedValue = 10;

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
			CRapIni.This.Write("mode>training>teacher", teacher);
			CRapIni.This.Write("mode>training>trained", trained);
			CRapIni.This.Write("mode>training>teacherBook", teacherBook);
			CRapIni.This.Write("mode>training>trainedBook", trainedBook);
			CRapIni.This.Write("mode>training>teacherValue", teacherValue.ToString());
			CRapIni.This.Write("mode>training>trainedValue", trainedValue.ToString());
			CRapIni.This.Write("mode>training>teacherMode", teacherMode);
			CRapIni.This.Write("mode>training>trainedMode", trainedMode);
		}

		public static void LoadFromIni()
		{
			teacher = CRapIni.This.Read("mode>training>teacher", CEngineList.def);
			trained = CRapIni.This.Read("mode>training>trained", CEngineList.def);
			teacherBook = CRapIni.This.Read("mode>training>teacherBook", teacherBook);
			trainedBook = CRapIni.This.Read("mode>training>trainedBook", trainedBook);
			teacherValue =CRapIni.This.ReadInt("mode>training>teacherValue", teacherValue);
			trainedValue = CRapIni.This.ReadInt("mode>training>trainedValue", trainedValue);
			teacherMode = CRapIni.This.Read("mode>training>teacherMode", teacherMode);
			trainedMode = CRapIni.This.Read("mode>training>trainedMode", trainedMode);
		}

	}
}
