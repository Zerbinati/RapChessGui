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
			list.Clear();
			buffer.Clear();
		}


		public static void MessageAdd(int pid,string msg)
		{
			MsgSet(new CMessage(pid,msg));
		}

		public static bool MessageGet(out CGamer gamer ,out string msg)
		{
			gamer = null;
			msg = "";
			if (buffer.Count == 0)
				buffer = MsgGet();
			else
			{
				int pid = buffer[0].pid;
				msg = buffer[0].msg;
				buffer.RemoveAt(0);
				gamer = CGamerList.This.GetGamerPid(pid);
				if (gamer == null)
				{
					CRapLog.Add($"CMessageList ({msg})");
					return false;
				}
				FormLog.This.richTextBox1.AppendText($"{gamer.GetTimeElapsed()} ",Color.Green);
				if (gamer.white)
				{
					FormLog.This.richTextBox1.AppendText($"{gamer.player.name}", Color.DimGray);
					FormLog.This.richTextBox1.AppendText($" > {msg}\n");
				}
				else
				FormLog.This.richTextBox1.AppendText($"{gamer.player.name} > {msg}\n");
				return true;
			}
			return false;
		}

	}

}
