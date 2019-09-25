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

		public CPlayer(int i)
		{
			index = i;
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
			curIndex = 0;
			CurPlayer().MakeMove();
		}

		public bool WhiteTurn()
		{
			return curIndex == 0;
		}
	}
}