using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapChessGui
{


	class CPlayer
	{
		public bool isWhite;
		public CPlayerEng PlayerEng;

		public CPlayer(bool iw)
		{
			isWhite = iw;
		}

		public bool IsHuman()
		{
			return PlayerEng == null;
		}

		public void MakeMove()
		{
			if (IsHuman())
				return;
			string position = CHistory.GetPosition();
			PlayerEng.streamWriter.WriteLine(position);
			PlayerEng.streamWriter.WriteLine("go movetime 1");
		}
	}
}
