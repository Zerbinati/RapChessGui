using System;
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
		public static int teacherTime = 1000;
		public static int trainedTime = 1000;
		public static string teacherBook = "";
		public static string trainedBook = "";

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
			CRapIni.This.Write("mode>training>teacherTime", teacherTime.ToString());
			CRapIni.This.Write("mode>training>trainedTime", trainedTime.ToString());
		}

		public static void LoadFromIni()
		{
			teacher = CRapIni.This.Read("mode>training>teacher", CEngineList.def);
			trained = CRapIni.This.Read("mode>training>trained", CEngineList.def);
			teacherBook = CRapIni.This.Read("mode>training>teacherBook", "Small");
			trainedBook = CRapIni.This.Read("mode>training>trainedBook", "Small");
			teacherTime = Convert.ToInt32(CRapIni.This.Read("mode>training>teacherTime", "1000"));
			trainedTime = Convert.ToInt32(CRapIni.This.Read("mode>training>trainedTime", "1000"));
		}

	}
}
