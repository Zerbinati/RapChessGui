using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	class CPlayerList
	{
		public int curIndex = 0;
		public CPlayer[] player = new CPlayer[2];

		public CPlayerList()
		{
			player[0] = new CPlayer(true);
			player[1] = new CPlayer(false);
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