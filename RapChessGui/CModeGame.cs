using RapIni;

namespace RapChessGui
{
	static class CModeGame
	{
		public static bool ranked = false;
		public static bool rotate = false;
		public static string color = "Auto";
		public static string computer = "Auto";
		public static string engine = CEngineList.def;
		public static string book = CBookList.def;
		public static CModeValue modeValue = new CModeValue();

		public static void SaveToIni()
		{
			CRapIni.This.Write("mode>game>rotate", rotate.ToString());
			CRapIni.This.Write("mode>game>color", color);
			CRapIni.This.Write("mode>game>computer",computer);
			CRapIni.This.Write("mode>game>engine", engine);
			CRapIni.This.Write("mode>game>book", book);
			CRapIni.This.Write("mode>game>mode", modeValue.mode);
			CRapIni.This.Write("mode>game>value", modeValue.value);
		}

		public static void LoadFromIni()
		{
			rotate = CRapIni.This.ReadBool("mode>game>rotate");
			color = CRapIni.This.Read("mode>game>color", color);
			computer = CRapIni.This.Read("mode>game>computer", computer);
			engine = CRapIni.This.Read("mode>game>engine", engine);
			book = CRapIni.This.Read("mode>game>book", book);
			modeValue.mode = CRapIni.This.Read("mode>game>mode",modeValue.mode);
			modeValue.value = CRapIni.This.ReadInt("mode>game>value", modeValue.value);
		}

	}
}
