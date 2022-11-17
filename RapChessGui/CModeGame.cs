﻿using RapIni;

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
		public static CPlayer humanPlayer = new CPlayer();

		public static void SaveToIni()
		{
			if (humanPlayer.hisElo.list.Count == 0)
			{
				int e = humanPlayer.GetElo();
				humanPlayer.hisElo.Add(e);
				humanPlayer.hisElo.Add(e);
			}
			FormChess.iniFile.Write("mode>game>rotate", rotate.ToString());
			FormChess.iniFile.Write("mode>game>color", color);
			FormChess.iniFile.Write("mode>game>computer",computer);
			FormChess.iniFile.Write("mode>game>engine", engine);
			FormChess.iniFile.Write("mode>game>book", book);
			FormChess.iniFile.Write("mode>game>mode", modeValue.GetLevel());
			FormChess.iniFile.Write("mode>game>value", modeValue.value);
			FormChess.iniFile.Write("mode>game>player>elo", humanPlayer.elo);
			FormChess.iniFile.Write("mode>game>player>history", humanPlayer.hisElo.SaveToStr());
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
			humanPlayer.elo = FormChess.iniFile.Read("mode>game>player>elo", "500");
			humanPlayer.hisElo.LoadFromStr(FormChess.iniFile.Read("mode>game>player>history"));
			humanPlayer.name = Global.human;
			humanPlayer.eloOrg = humanPlayer.elo;
			humanPlayer.modeValue.level = CLevel.infinite;
		}

	}
}
