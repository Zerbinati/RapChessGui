using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	class CMessage
	{
		public int pid = 0;
		public string msg = "";

		public CMessage(int p,string m)
		{
			pid = p;
			msg = m;
		}

	}

	static class CMessageList
	{
		public static List<CMessage> list = new List<CMessage>();

		public static void Add(int pid,string msg)
		{
			list.Add(new CMessage(pid,msg));
		}

		public static bool GetMessage(out CPlayer player ,out string msg)
		{
			player = null;
			msg = "";
			if (list.Count > 0)
			{
				int pid = list[0].pid;
				msg = list[0].msg;
				list.RemoveAt(0);
				player = CPlayerList.This.PlayerPid(pid);
				string name = player == null ? "" : player.user.name;
				FormLog.This.richTextBox1.AppendText($"{name} > {msg}\n");
				return true;
			}
			return false;
		}

	}

}
