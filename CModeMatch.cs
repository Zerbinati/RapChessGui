using RapIni;

namespace RapChessGui
{
	static class CModeMatch
	{
		public static bool rotate = false;
		public static int games = 0;
		public static int win = 0;
		public static int draw = 0;
		public static int loose = 0;

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

		public static void LoadFromIni()
		{
			rotate = CRapIni.This.ReadBool("mode>match>rotate");
			games = CRapIni.This.ReadInt("mode>match>games");
			win = CRapIni.This.ReadInt("mode>match>win");
			draw = CRapIni.This.ReadInt("mode>match>draw");
			loose = CRapIni.This.ReadInt("mode>match>loose");
		}

		public static void SaveToIni()
		{
			CRapIni.This.Write("mode>match>rotate", rotate.ToString());
			CRapIni.This.Write("mode>match>games", games.ToString());
			CRapIni.This.Write("mode>match>win", win.ToString());
			CRapIni.This.Write("mode>match>draw", draw.ToString());
			CRapIni.This.Write("mode>match>loose", loose.ToString());
		}

	}
}
