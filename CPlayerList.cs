using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	class CPlayer
	{
		public int index;
		public CPlayerEng PlayerEng = new CPlayerEng();
		public CUser user;
		public DateTime timeStart;
		public double timeTotal;
		public string score;
		public string depth;
		public string seldepth;
		public string nps;
		public string ponder;

		public CPlayer(int i)
		{
			index = i;
			Init();
		}

		public void Init()
		{
			timeTotal = 0;
			score = "0";
			depth = "0";
			seldepth = "0";
			nps = "0";
			ponder = "";
		}

		public bool IsHuman()
		{
			return PlayerEng.process.StartInfo.FileName == "";
		}

		public bool IsWhite()
		{
			return index == 0;
		}

		public void MakeMove()
		{
			timeStart = DateTime.Now;
			if (IsHuman())
				return;
			string position = CHistory.GetPosition();
			PlayerEng.streamWriter.WriteLine(position);
			PlayerEng.streamWriter.WriteLine($"go {user.mode} {user.value}");
		}

		public void SendMessage(string msg)
		{
			if (!IsHuman())
				PlayerEng.streamWriter.WriteLine(msg);
		}

		public void SetUser(string name)
		{
			user = CUserList.GetUser(name);
			if (user.engine != "Human")
				PlayerEng.SetEngine(user.engine, "");
			else
				PlayerEng.Kill();
		}
	}

	class CPlayerList
	{
		public int curIndex = 0;
		public CPlayer[] player = new CPlayer[2];

		public CPlayerList()
		{
			player[0] = new CPlayer(0);
			player[1] = new CPlayer(1);
		}

		public CPlayer CurPlayer()
		{
			return player[curIndex];
		}

		public void MakeMove()
		{
			curIndex ^= 1;
			CurPlayer().MakeMove();
		}

		public void NewGame()
		{
			player[0].Init();
			player[1].Init();
			curIndex = 0;
			CurPlayer().MakeMove();
		}

		public bool WhiteTurn()
		{
			return curIndex == 0;
		}
	}
}