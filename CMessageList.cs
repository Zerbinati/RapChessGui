using System.Collections.Generic;

namespace RapChessGui
{
	class CMessage
	{
		public int pid = 0;
		public string msg = "";

		public CMessage(int p, string m)
		{
			pid = p;
			msg = m;
		}

	}

	static class CMessageList
	{
		static int winMessage;
		private readonly static object locker = new object();
		readonly static List<CMessage> listPri = new List<CMessage>();
		readonly static List<CMessage> listSec = new List<CMessage>();

		public static void Init(int m)
		{
			winMessage = m;
		}

		static void MsgSet(CMessage m)
		{
			lock (locker)
			{
				listPri.Add(m);
			}
			CWinMessage.Message(winMessage);
		}

		static List<CMessage> MsgGet()
		{
			List<CMessage> result;
			lock (locker)
			{
				result = listPri.GetRange(0, listPri.Count);
				listPri.Clear();
			}
			return result;
		}

		static void MsgClear()
		{
			lock (locker)
			{
				listPri.Clear();
			}
		}

		public static void Clear()
		{
			MsgClear();
			listSec.Clear();
		}


		public static void MessageAdd(int pid, string msg)
		{
			MsgSet(new CMessage(pid, msg));
		}

		public static bool MessageGet(out CMessage message)
		{
			message = null;
			List<CMessage> last = MsgGet();
			foreach (CMessage m in last)
			{
				CGamer gamer = CGamerList.This.GetGamerPid(m.pid, out string protocol);
				if (gamer != null)
				{
					if (protocol == "Uci")
					{
						bool bm = m.msg.Contains("bestmove");
						if (bm)
							gamer.timer.Stop();
						if (bm || (listSec.Count < 0x1f) || !gamer.isEngRunning)
							listSec.Add(m);
					}
					else if(protocol == "Winboard")
					{
						bool bm = m.msg.Contains("move");
						if (bm)
							gamer.timer.Stop();
						if (bm || (listSec.Count < 0x1f) || !gamer.isEngRunning)
							listSec.Add(m);
					}
					else
						listSec.Add(m);
				}else
					listSec.Add(m);
			}
			if (listSec.Count > 0)
			{
				message = listSec[0];
				listSec.RemoveAt(0);
			}
			return message != null;
		}

	}

}
