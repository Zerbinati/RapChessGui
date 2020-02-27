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
		public CEnginePro PlayerEng = new CEnginePro();
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
		}

		public void Undo()
		{
			if (user.protocol == "Winboard")
				wbok = false;
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
				if (user.protocol == "Uci")
				{
					SendMessage(CHistory.GetPosition());
					Thread.Sleep(1<<5);
					SendMessage($"go {mode} {value}");
				}
				else
				{
					if (wbok)
					{
						SendMessage(CHistory.LastMove());
					}
					else
					{
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
						SendMessage("go");
					}
					wbok = true;
				}
				go = true;
				timer.Restart();
		}

		public void SendMessage(string msg)
		{
			if (computer)
			{
				FormLog.This.richTextBox1.AppendText($"{user.name} < {msg}\n", Color.Brown);
				PlayerEng.streamWriter.WriteLine(msg);
			}
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
		public static CPlayerList This;

		public CPlayerList()
		{
			This = this;
			player[0] = new CPlayer();
			player[1] = new CPlayer();
		}

		public void Next()
		{
			CPlayer cp = PlayerCur();
			cp.UpdateTime();
			cp.go = false;
			curIndex ^= 1;
			PlayerCur().timer.Restart();
		}

		public void Init()
		{
			player[0].Init(true);
			player[1].Init(false);
			curIndex = 0;
			FormLog.This.cbPlayerList.Items.Clear();
			if (player[0].computer)
				FormLog.This.cbPlayerList.Items.Add(player[0].user.name);
			if (player[1].computer)
				FormLog.This.cbPlayerList.Items.Add(player[1].user.name);
			if (FormLog.This.cbPlayerList.Items.Count > 0)
				FormLog.This.cbPlayerList.SelectedIndex = 0;
		}

		public void Rotate()
		{
			CPlayer p = player[0];
			player[0] = player[1];
			player[1] = p;
			player[0].white = true;
			player[1].white = false;
		}

		public CPlayer GetPlayer(string name)
		{
			foreach(CPlayer p in player)
			if (p.user.name == name)
				return p;
			return null;
		}

		public CPlayer PlayerHum()
		{
			if (!player[0].computer)
				return player[0];
			if (!player[1].computer)
				return player[1];
			return null;
		}

		public CPlayer PlayerCur()
		{
			return player[curIndex];
		}

		public CPlayer PlayerSec()
		{
			return player[curIndex ^ 1];
		}

		public CPlayer PlayerPid(int pid)
		{
			foreach(CPlayer p in player)
			if (p.PlayerEng.GetPid() == pid)
				return p;
			return null;
		}

		public void Terminate()
		{
			player[0].PlayerEng.Terminate();
			player[1].PlayerEng.Terminate();
		}

	}
}