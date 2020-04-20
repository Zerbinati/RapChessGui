using System.Collections.Generic;
using System.Drawing;
using RapLog;

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
		static List<CMessage> list = new List<CMessage>();
		static List<CMessage> buffer = new List<CMessage>();

		static void MsgSet(CMessage m)
		{
			lock (list)
				list.Add(m);
		}

		static List<CMessage> MsgGet()
		{
			List<CMessage> result;
			lock (list)
			{
				result = list.GetRange(0, list.Count);
				list.Clear();
			}
			return result;
		}

		public static void Clear()
		{
			lock (list)
			{
				list.Clear();
				buffer.Clear();
			}
		}


		public static void MessageAdd(int pid,string msg)
		{
			MsgSet(new CMessage(pid,msg));
		}

		public static bool MessageGet(out CMessage message)
		{
			message = null;
			List<CMessage> last = MsgGet();
			foreach (CMessage m in last) { 
				CGamer gamer = CGamerList.This.GetGamerPid(m.pid);
				if (gamer != null) {
					string protocol = gamer.GetProtocol();
					if (protocol == "Uci") {
						if (m.msg.Contains("bestmove"))
							gamer.timer.Stop();
					}
					else
						if (m.msg.Contains("move"))
						gamer.timer.Stop();
				}
			}
			buffer.AddRange(last);
			if(buffer.Count >0)
			{
				message = buffer[0];
				buffer.RemoveAt(0);
			}
			return message != null;
		}

	}

}
