using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace RapChessGui
{
	enum CMode { game,match, training }

	public static class CData
	{
		public static bool rotateBoard = false;
		public static int gameState = 0;
		public static int gameMode = 0;
		public static int back = 0;
		public static int book = 0;
		public static string[] arrModeNames = new string[] { "depth","movetime" };
		public static List<string> bookNames = new List<string>();
		public static List<string> engineNames = new List<string>();
		public static List<string> playerNames = new List<string>();
		public static FormLog FLog = null;
		public static List<string> messages = new List<string>();

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

		public static void KillProcess()
		{
			Process cp = Process.GetCurrentProcess();
			string fn = cp.MainModule.FileName;
			string eDir = AppDomain.CurrentDomain.BaseDirectory + "Engines";
			Process[] processlist = Process.GetProcesses();
			foreach (Process process in processlist)
			{
				try
				{
					String fileName = process.MainModule.FileName;
					if (fileName == fn)
						continue;
					if (fileName.IndexOf(eDir) == 0)
					{
						process.Kill();
					}

				}
				catch
				{
				}

			}
			Thread.Sleep(10);
		}

	}
}
