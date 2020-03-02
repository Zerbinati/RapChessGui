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
		public static int timeTeacher = 1000;
		public static int timeTrained = 1000;
		public static string bookTeacher = "";

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
			CRapIni.This.Write("mode>training>book", bookTeacher);
			CRapIni.This.Write("mode>training>timeTeacher", timeTeacher.ToString());
			CRapIni.This.Write("mode>training>timeTrained", timeTrained.ToString());
		}

		public static void LoadFromIni()
		{
			teacher = CRapIni.This.Read("mode>training>teacher", "RapChessCs.exe");
			trained = CRapIni.This.Read("mode>training>trained", CPlayerList.def);
			bookTeacher = CRapIni.This.Read("mode>training>book", "small");
			timeTeacher = Convert.ToInt32(CRapIni.This.Read("mode>training>timeTeacher", "1000"));
			timeTrained = Convert.ToInt32(CRapIni.This.Read("mode>training>timeTrained", "1000"));
		}

	}
}
