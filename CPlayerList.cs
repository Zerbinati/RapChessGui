using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace RapChessGui
{

	public class CPlayer
	{
		public bool computer = false;
		public bool started = false;
		public bool uciok = false;
		public bool wbok = false;
		public bool readyok = false;
		public bool go = false;
		public bool white = true;
		public int usedBook;
		public ulong nodes;
		public ulong nps;
		public ulong totalNps;
		public ulong totalNpsSum;
		public double timeTotal;
		public string score;
		public string depth;
		public string seldepth;
		public string ponder;
		public string mode;
		public string value;
		public Stopwatch timer = new Stopwatch();
		public CBook book = new CBook();
		public CPlayerEng PlayerEng = new CPlayerEng();
		public CUser user;

		public CPlayer()
		{
			Init(true);
		}

		public void EngineStop()
		{
			if (user.protocol == "Uci")
				SendMessage("stop");
			else
				SendMessage("?");
		}

		public void EngineClose()
		{
			SendMessage("quit");
		}

		public void Init(bool w)
		{
			white = w;
			started = false;
			go = false;
			usedBook = 0;
			nodes = 0;
			nps = 0;
			totalNps = 0;
			totalNpsSum = 0;
			score = "0";
			depth = "0";
			seldepth = "0";
			ponder = "";
			timeTotal = 0;
			timer.Reset();
			book.Reset();
		}

		public void Start()
		{
			mode = user.mode;
			value = user.value;
			if (user.protocol == "Uci")
			{
				SendMessage("uci");
				uciok = false;
				readyok = false;
				wbok = true;
			}
			else
			{
				SendMessage("xboard");
				uciok = true;
				readyok = false;
				wbok = false;
				switch (mode)
				{
					case "depth":
						mode = "sd";
						break;
					case "movetime":
						mode = "st";
						int v = Convert.ToInt32(user.value) / 1000;
						if (v < 1)
							v = 1;
						value = v.ToString();
						break;
				}
			}
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
				if (user.protocol == "Uci")
				{
					SendMessage(CHistory.GetPosition());
					SendMessage($"go {mode} {value}");
				}
				else
				{
					if (wbok)
					{
						SendMessage(CHistory.LastMove());
					}
						else {
								SendMessage("new");
								SendMessage($"{mode} {value}");
								SendMessage("post");
								if (CHistory.fen != CEngine.defFen)
								{
									SendMessage($"setboard {CHistory.fen}");
								}
								SendMessage("force");
								foreach (CHisMove m in CHistory.moveList)
									SendMessage(m.emo);
								SendMessage("go"); }
					wbok = true;
				}
				go = true;
				timer.Restart() ;
			}
		}

		public void SendMessage(string msg)
		{
			if (computer)
			{
				FormLog.This.richTextBox1.AppendText($"{user.name} < {msg}\n", Color.Brown);
				PlayerEng.streamWriter.WriteLine(msg);
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

		public string GetProtocol()
		{
			if (computer)
				return user.protocol;
			else
				return "Protocol";
		}

		public string GetTime()
		{
			DateTime dt1 = new DateTime();
			DateTime dt2 = dt1.AddMilliseconds(timeTotal + timer.Elapsed.TotalMilliseconds);
			return dt2.ToString("HH:mm:ss");
		}

		public string GetElo()
		{
			if (user == null)
				return "Elo";
			else
				return $"Elo {user.elo}";
		}

		public void SetUser(CUser u)
		{
			user = u;
			computer = user.engine != "Human";
			PlayerEng.SetPlayer(this);
			book.Load(user.book);
		}

		public void SetUser()
		{
			SetUser(user);
		}

		public void SetUser(string name)
		{
			CUser u = CUserList.GetUser(name);
			SetUser(u);
		}

		public void UpdateTime()
		{
			timeTotal += timer.Elapsed.TotalMilliseconds;
			timer.Reset();
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
			CPlayer cp = CurPlayer();
			cp.UpdateTime();
			cp.go = false;
			curIndex ^= 1;
			CurPlayer().timer.Restart();
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
			player[0].white = true;
			player[1].white = false;
		}

		public CPlayer SecPlayer()
		{
			return player[curIndex ^ 1];
		}

		public void Terminate()
		{
			player[0].PlayerEng.Terminate();
			player[1].PlayerEng.Terminate();
		}

	}
}