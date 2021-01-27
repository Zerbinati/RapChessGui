using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
		readonly static List<CMessage> list = new List<CMessage>();
		readonly static List<CMessage> buffer = new List<CMessage>();

		public static void Init(int m)
		{
			winMessage = m;
		}

		static void MsgSet(CMessage m)
		{
			lock (locker)
			{
				list.Add(m);
			}
			CWinMessage.Message(winMessage);
		}

		static List<CMessage> MsgGet()
		{
			List<CMessage> result;
			lock (locker)
			{
				result = list.GetRange(0, list.Count);
				list.Clear();
			}
			return result;
		}

		static void MsgClear()
		{
			lock (locker)
			{
				list.Clear();
			}
		}

		public static void Clear()
		{
			MsgClear();
			buffer.Clear();
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
					bool bm = false;
					if (protocol == "Uci")
					{
						bm = m.msg.Contains("bestmove");
						if (bm || (buffer.Count < 0x1f) || !gamer.isEngRunning)
							buffer.Add(m);
					}
					else if(protocol == "Winboard")
					{
						bm = m.msg.Contains("move");
						if (bm || (buffer.Count < 0x1f) || !gamer.isEngRunning)
							buffer.Add(m);
					}
					else
						buffer.Add(m);
					if (bm)
						gamer.timer.Stop();
				}
			}
			if (buffer.Count > 0)
			{
				message = buffer[0];
				buffer.RemoveAt(0);
			}
			return message != null;
		}

	}

}
