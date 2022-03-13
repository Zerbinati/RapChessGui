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
			FormChess.iniFile.Write("mode>game>rotate", rotate.ToString());
			FormChess.iniFile.Write("mode>game>color", color);
			FormChess.iniFile.Write("mode>game>computer",computer);
			FormChess.iniFile.Write("mode>game>engine", engine);
			FormChess.iniFile.Write("mode>game>book", book);
			FormChess.iniFile.Write("mode>game>mode", modeValue.GetLevel());
			FormChess.iniFile.Write("mode>game>value", modeValue.value);
		}

		public static void LoadFromIni()
		{
			rotate = FormChess.iniFile.ReadBool("mode>game>rotate");
			color = FormChess.iniFile.Read("mode>game>color", color);
			computer = FormChess.iniFile.Read("mode>game>computer", computer);
			engine = FormChess.iniFile.Read("mode>game>engine", engine);
			book = FormChess.iniFile.Read("mode>game>book", book);
			modeValue.SetLevel(FormChess.iniFile.Read("mode>game>mode",modeValue.GetLevel()));
			modeValue.value = FormChess.iniFile.ReadInt("mode>game>value", modeValue.value);
		}

	}
}
