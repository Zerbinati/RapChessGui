using RapIni;

namespace RapChessGui
{
	static class CModeGame
	{
		public static bool ranked = false;
		public static bool rotate = false;

		public static void SaveToIni()
		{
			CRapIni.This.Write("mode>game>rotate", rotate.ToString());
		}

		public static void LoadFromIni()
		{
			rotate = CRapIni.This.ReadBool("mode>game>rotate");
		}

	}
}
