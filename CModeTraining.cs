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
		public static int errors;
		public static string teacher = "";
		public static string trained = "";
		public static string teacherBook = "Eco";
		public static string trainedBook = "Eco";
		public static CModeValue modeValueTeacher = new CModeValue();
		public static CModeValue modeValueTrained = new CModeValue();

		public static void Reset()
		{
			rotate = false;
			games = 0;
			win = 0;
			draw = 0;
			loose = 0;
			errors = 0;
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
			CRapIni.This.Write("mode>training>teacherValue", modeValueTeacher.value);
			CRapIni.This.Write("mode>training>trainedValue", modeValueTrained.value);
			CRapIni.This.Write("mode>training>teacherMode", modeValueTeacher.mode);
			CRapIni.This.Write("mode>training>trainedMode", modeValueTrained.mode);
		}

		public static void LoadFromIni()
		{
			teacher = CRapIni.This.Read("mode>training>teacher", CEngineList.def);
			trained = CRapIni.This.Read("mode>training>trained", CEngineList.def);
			teacherBook = CRapIni.This.Read("mode>training>teacherBook", teacherBook);
			trainedBook = CRapIni.This.Read("mode>training>trainedBook", trainedBook);
			modeValueTeacher.value = CRapIni.This.ReadInt("mode>training>teacherValue", modeValueTeacher.value);
			modeValueTrained.value = CRapIni.This.ReadInt("mode>training>trainedValue", modeValueTrained.value);
			modeValueTeacher.mode = CRapIni.This.Read("mode>training>teacherMode", modeValueTeacher.mode);
			modeValueTrained.mode = CRapIni.This.Read("mode>training>trainedMode", modeValueTrained.mode);
		}

	}
}
