using System.Collections.Generic;
using System.Drawing;
using RapLog;

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
		private readonly static object locker = new object();
		readonly static List<CMessage> list = new List<CMessage>();
		readonly static List<CMessage> buffer = new List<CMessage>();

		static void MsgSet(CMessage m)
		{
			lock (locker)
			{
				list.Add(m);
			}
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
			buffer.AddRange(last);
			foreach (CMessage m in last)
			{
				CGamer gamer = CGamerList.This.GetGamerPid(m.pid, out string protocol);
				if (gamer != null)
				{
					if ((protocol == "Uci") || (protocol == "Book"))
					{
						if (m.msg.Contains("bestmove"))
						{
							gamer.timer.Stop();
							buffer.Clear();
							buffer.Add(m);
						}
					}
					else
						if (m.msg.Contains("move"))
					{
						gamer.timer.Stop();
						buffer.Clear();
						buffer.Add(m);
					}
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
