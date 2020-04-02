using RapIni;

namespace RapChessGui
{
	static class CModeGame
	{
		public static bool ranked = false;
		public static bool rotate = false;
		public static string color = "Auto";
		public static string computer = "Auto";
		public static string mode = "Time";
		public static int value = 1;

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

		public static void SetValue(int v)
		{
			switch (mode)
			{
				case "Blitz":
					value = v / 60000;
					break;
				case "Depth":
					value = v;
					break;
				case "Nodes":
					value = v / 1000000;
					break;
				case "Time":
					value = v / 1000;
					break;
			}
			if (value < 1)
				value = 1;
		}

		public static int GetValue(out int increment)
		{
			increment = 1;
			switch (mode)
			{
				case "Blitz":
					increment = 1000;
					return value * 60000;
				case "Depth":
					return value;
				case "Nodes":
					increment = 100000;
					return value * 1000000;
				case "Infinite":
					return 0;
				default:
					increment = 100;
					return value * 1000;
			}
		}

	}
}
