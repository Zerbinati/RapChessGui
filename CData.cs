using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	public static class CData
	{
		public static string[] arrModeNames = new string[] { "depth","movetime" };
		public static List<string> playerNames = new List<string>();
		public static CIniFile Inifile = new CIniFile();

		public static int ModeStoi(string s)
		{
			for (int i = 0; i < arrModeNames.Length; i++)
				if (s == arrModeNames[i])
					return i;
			return 0;
		}

		public static string ModeItos(int i)
		{
			return arrModeNames[i];
		}
	}
}
