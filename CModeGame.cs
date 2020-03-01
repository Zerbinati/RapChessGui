using RapIni;

namespace RapChessGui
{
	static class CModeGame
	{
		public static bool ranked = false;
		public static bool rotate = false;
		public static string color = "Auto";
		public static string computer = "Auto";

		public static void SaveToIni()
		{
			CRapIni.This.Write("mode>game>rotate", rotate.ToString());
			CRapIni.This.Write("mode>game>color", color);
			CRapIni.This.Write("mode>game>computer",computer);
		}

		public static void LoadFromIni()
		{
			rotate = CRapIni.This.ReadBool("mode>game>rotate");
			color = CRapIni.This.Read("mode>game>color", color);
			computer = CRapIni.This.Read("mode>game>computer", computer);
		}

	}
}
