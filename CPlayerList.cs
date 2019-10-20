using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	public class MessageEventArgs : EventArgs
	{
		public MessageEventArgs(string s)
		{ Message = s; }
		public string Message { get; set; }
	}

	public class CPlayer
	{
		public bool computer = false;
		public bool started = false;
		public bool uciok = false;
		public bool readyok = false;
		public bool go = false;
		public CPlayerEng PlayerEng;
		public CUser user;
		public DateTime timeStart;
		public double timeTotal;
		public string score;
		public string depth;
		public string seldepth;
		public string nps;
		public string ponder;
		public List<string> messages = new List<string>();

		public CPlayer()
		{
			PlayerEng = new CPlayerEng();
			Init();
		}

		public void Init()
		{
			started = false;
			go = false;
			timeTotal = 0;
			score = "0";
			depth = "0";
			seldepth = "0";
			nps = "0";
			ponder = "";
			timeStart = DateTime.Now;
		}

		public void Start()
		{
			SendMessage("uci");
			started = true;
		}

		public void CompMakeMove()
		{
			messages.Clear();
				string position = CHistory.GetPosition();
				//PlayerEng.streamWriter.Flush();
				//stream.DiscardBufferedData();
				SendMessage(position);
				SendMessage($"go {user.mode} {user.value}");
			go = true;
		}

		public void SendMessage(string msg)
		{
			if (computer)
			{
				CData.FLog.richTextBox1.AppendText($"{user.name} < {msg}\n");
				PlayerEng.streamWriter.WriteLine(msg);
			}
		}

		public string GetMessage()
		{
			string msg = "";
			if (computer)
			{
				if (messages.Count > 0)
				{
					msg = messages[0];
					messages.RemoveAt(0);
				}
				if (msg != "")
					CData.FLog.richTextBox1.AppendText($"{user.name} > {msg}\n");
			}
			return msg;
		}

		public void SetUser(CUser u)
		{
			uciok = false;
			readyok = false;
			user = u;
			computer = user.engine != "Human";
			PlayerEng.SetPlayer(this);
		}

		public void SetUser(string name)
		{
			CUser u = CUserList.GetUser(name);
			SetUser(u);
		}
	}

	class CPlayerList
	{
		public int curIndex = 0;
		public CPlayer[] player = new CPlayer[2];

		public CPlayerList()
		{
			player[0] = new CPlayer();
			player[1] = new CPlayer();
		}

		public void KillProcess()
		{
			string eDir = AppDomain.CurrentDomain.BaseDirectory + "Engines";
			Process[] processlist = Process.GetProcesses();
			foreach (Process process in processlist)
			{
				try
				{
					String fileName = process.MainModule.FileName;
					if (fileName.IndexOf(eDir) == 0)
					{
						process.Kill();
					}

				}
				catch
				{
				}

			}
		}

		public CPlayer CurPlayer()
		{
			return player[curIndex];
		}

		public void Next()
		{
			CurPlayer().go = false;
			curIndex ^= 1;
			CurPlayer().timeStart = DateTime.Now;
		}

		public void NewGame()
		{
			player[0].Init();
			player[1].Init();
			curIndex = 0;
		}

		public void Rotate()
		{
			KillProcess();
			CUser u1 = player[0].user;
			CUser u2 = player[1].user;
			player[0].SetUser(u2);
			player[1].SetUser(u1);
			/*CPlayer p = player[0];
			player[0] = player[1];
			player[1] = p;
			player[0].index = 0;
			player[1].index = 1;*/
		}

	}
}