using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	class CModeTournament
	{
		public static int playerIndex;

		public static CUser GetUser()
		{
			CUserList.Sort();
			List<CUser> list = new List<CUser>();
			foreach (CUser u in CUserList.list)
				if (u.engine != "Human")
					list.Add(u);
			if (--playerIndex < 0)
				playerIndex = list.Count - 1;
			playerIndex %= list.Count;
			return list[playerIndex];
		}

	}

}
