using System;
using System.Drawing;
using System.Threading;

namespace RapChessGui
{

	public class CPlayer
	{
		public bool computer = false;
		public bool started = false;
		public bool uciok = false;
		public bool readyok = false;
		public bool go = false;
		public bool white = true;
		public double timeTotal;
		public string score;
		public string depth;
		public string seldepth;
		public string nps;
		public string ponder;
		public DateTime timeStart;
		public CBook book = new CBook();
		public CPlayerEng PlayerEng = new CPlayerEng();
		public CUser user;

		public CPlayer()
		{
			Init(true);
		}

		public void Init(bool w)
		{
			white = w;
			started = false;
			go = false;
			timeTotal = 0;
			score = "0";
			depth = "0";
			seldepth = "0";
			nps = "0";
			ponder = "";
			timeStart = DateTime.Now;
			book.Reset();
		}

		public void Start()
		{
			SendMessage("uci");
			started = true;
		}

		public void CompMakeMove()
		{
			string emo = book.GetMove(CHistory.GetMoves());
			if (emo != "")
			{
				FormChess.This.AddBook(emo);
				FormChess.This.MakeMove(emo);
			}
			else
			{
				string position = CHistory.GetPosition();
				SendMessage(position);
				SendMessage($"go {user.mode} {user.value}");
				go = true;
				timeStart = DateTime.Now;
			}
		}

		public void SendMessage(string msg)
		{
			if (computer)
			{
				FormLog.This.richTextBox1.AppendText($"{user.name} < {msg}\n", Color.Brown);
				PlayerEng.streamWriter.WriteLine(msg);
				Thread.Sleep(10);
			}
		}

		public string GetMessage()
		{
			string msg = "";
			if (computer)
			{
				lock (CData.messages)
				{
					if (CData.messages.Count > 0)
					{
						msg = CData.messages[0];
						CData.messages.RemoveAt(0);
						FormLog.This.richTextBox1.AppendText($"{user.name} > {msg}\n");
					}
				}
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
			book.Load(user.book);
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

		public void Init()
		{
			player[0].Init(true);
			player[1].Init(false);
			curIndex = 0;
		}

		public void Rotate()
		{
			CPlayer p = player[0];
			player[0] = player[1];
			player[1] = p;
		}

		public CPlayer SecPlayer()
		{
			return player[curIndex ^1];
		}

	}
}