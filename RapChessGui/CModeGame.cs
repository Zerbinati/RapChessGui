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
			FormChess.RapIni.Write("mode>game>rotate", rotate.ToString());
			FormChess.RapIni.Write("mode>game>color", color);
			FormChess.RapIni.Write("mode>game>computer",computer);
			FormChess.RapIni.Write("mode>game>engine", engine);
			FormChess.RapIni.Write("mode>game>book", book);
			FormChess.RapIni.Write("mode>game>mode", modeValue.mode);
			FormChess.RapIni.Write("mode>game>value", modeValue.value);
		}

		public static void LoadFromIni()
		{
			rotate = FormChess.RapIni.ReadBool("mode>game>rotate");
			color = FormChess.RapIni.Read("mode>game>color", color);
			computer = FormChess.RapIni.Read("mode>game>computer", computer);
			engine = FormChess.RapIni.Read("mode>game>engine", engine);
			book = FormChess.RapIni.Read("mode>game>book", book);
			modeValue.mode = FormChess.RapIni.Read("mode>game>mode",modeValue.mode);
			modeValue.value = FormChess.RapIni.ReadInt("mode>game>value", modeValue.value);
		}

	}
}
