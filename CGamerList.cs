using System;
using System.Drawing;
using System.Diagnostics;
using RapLog;

namespace RapChessGui
{

	public class CGamer
	{
		public bool started = false;
		public bool uciok = false;
		public bool wbok = false;
		public bool readyok = false;
		public bool go = false;
		public bool white = true;
		public int usedBook;
		public int iScore = 0;
		public ulong nodes;
		public ulong nps;
		public string score;
		public string depth;
		public string seldepth;
		public string ponder;
		public string mode;
		public string value;
		public string pv;
		public double timerStart;
		public Stopwatch timer = new Stopwatch();
		public CEnginePro enginePro = new CEnginePro();
		public CBook book = null;
		public CEngine engine = null;
		public CPlayer player = null;

		public CGamer()
		{
			Init(true);
		}

		public void EngineStop()
		{
			if (engine.protocol == "Uci")
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
			score = "0";
			depth = "0";
			seldepth = "0";
			ponder = "";
			pv = "";
			iScore = 0;
			timerStart = 0;
			timer.Reset();
		}

		public void TimerStart()
		{
			timerStart = timer.Elapsed.TotalMilliseconds;
			timer.Start();
		}

		public bool IsHuman()
		{
			return engine == null;
		}

		public void Undo()
		{
			if (engine.protocol == "Winboard")
				wbok = false;
		}

		public void Start()
		{
			mode = player.modeValue.GetUci();
			value = player.modeValue.GetUciValue().ToString();
			if (engine.protocol == "Uci")
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
				readyok = true;
				wbok = false;
				switch (mode)
				{
					case "depth":
						mode = "sd";
						break;
					case "movetime":
						mode = "st";
						int v = Convert.ToInt32(player.modeValue.GetUciValue()) / 1000;
						if (v < 1)
							v = 1;
						value = v.ToString();
						break;
				}
			}
			started = true;
		}

		void UciGo()
		{
			SendMessage(CHistory.GetPosition());
			if (player.modeValue.mode == "Blitz")
			{
				Int64 v = Convert.ToInt64(player.modeValue.GetUciValue());
				Int64 t = Convert.ToInt64(v - timer.Elapsed.TotalMilliseconds);
				if (t < 1)
					t = 1;
				SendMessage($"go wtime {t} btime {t} winc 0 binc 0");
			}
			else
				SendMessage($"go {player.modeValue.GetUci()} {player.modeValue.GetUciValue()}");
			TimerStart();
		}

		void XbGo()
		{
			if (player.modeValue.mode == "Blitz")
			{
				int v = Convert.ToInt32(player.modeValue.GetUciValue());
				int t = Convert.ToInt32(v - timer.Elapsed.TotalMilliseconds);
				if (t < 1)
					t = 1;
				SendMessage($"time {t}");
				SendMessage($"otim {t}");
			}
			SendMessage(CHistory.LastMove());
		}

		public void CompMakeMove()
		{
			if (engine.protocol == "Uci")
				UciGo();
			else
			{
				if (wbok)
					XbGo();
				else
				{
					SendMessage("new");
					SendMessage($"{mode} {value}");
					SendMessage("post");
					if (CHistory.fen != CChess.defFen)
					{
						SendMessage($"setboard {CHistory.fen}");
					}
					SendMessage("easy");
					foreach (CHisMove m in CHistory.moveList)
						SendMessage(m.emo);
					if (CHistory.moveList.Count == 0)
					{
						SendMessage("white");
						SendMessage("go");
					}
					wbok = true;
				}
				TimerStart();
			}
			go = true;
		}

		public void SendMessage(string msg)
		{
			if (engine != null)
			{
				FormLog.This.richTextBox1.AppendText($"{player.name} < {msg}\n", Color.Brown);
				enginePro.streamWriter.WriteLine(msg);
			}
		}

		public string GetBook()
		{
			if (player == null)
				return "Book";
			else
				return player.book;
		}

		public string GetEngine()
		{
			if (engine == null)
				return "Engine";
			else
				return engine.name;
		}

		public string GetMode()
		{
			if (player == null)
				return "Mode";
			else
				return player.modeValue.LongName();
		}

		public string GetProtocol()
		{
			if (engine == null)
				return "Protocol";
			else
				return engine.protocol;
		}

		public string GetDepth()
		{
			if (seldepth != "0")
				return $"{depth} / {seldepth}";
			else
				return depth;
		}

		public string GetTime()
		{
			DateTime dt = new DateTime();
			if ((player != null) && (player.modeValue.mode == "Blitz"))
			{
				double v = Convert.ToDouble(player.modeValue.GetUciValue());
				double t = v - timer.Elapsed.TotalMilliseconds;
				if (t < 0)
				{
					FormChess.SetGameState(CGameState.time);
					if (engine != null)
						CRapLog.Add($"{engine.name} time out");
					return "Time out";
				}
				dt = dt.AddMilliseconds(t);
				if (t < 10000)
					return dt.ToString("ss.ff");
			}
			else
				dt = dt.AddMilliseconds(timer.Elapsed.TotalMilliseconds);
			return dt.ToString("HH:mm:ss");
		}

		public string GetTimeElapsed()
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(timer.Elapsed.TotalMilliseconds - timerStart);
			return dt.ToString("HH:mm:ss.ff");
		}

		public string GetElo()
		{
			if (player == null)
				return "Elo";
			else
				return $"Elo {player.elo}";
		}

		public string GetName()
		{
			if (player == null)
				return "Human";
			else
				return player.GetName();
		}

		public void SetPlayer(CPlayer p)
		{
			player = p;
			book = CBookList.GetBook(p.book);
			engine = CEngineList.GetEngine(p.engine);
			enginePro.SetPlayer(this);
		}

		public void SetPlayer()
		{
			SetPlayer(player);
		}

		public void SetPlayer(string name)
		{
			CPlayer p = CPlayerList.GetPlayerAuto(name);
			SetPlayer(p);
		}

	}

	class CGamerList
	{
		public int curIndex = 0;
		public CGamer[] gamer = new CGamer[2];
		public static CGamerList This;

		public CGamerList()
		{
			This = this;
			gamer[0] = new CGamer();
			gamer[1] = new CGamer();
		}

		public void Next()
		{
			CGamer cg = GamerCur();
			cg.go = false;
			curIndex ^= 1;
			cg = GamerCur();
			if (cg.IsHuman())
				cg.TimerStart();
		}

		public void Init()
		{
			gamer[0].Init(true);
			gamer[1].Init(false);
			curIndex = 0;
			FormLog.This.cbPlayerList.Items.Clear();
			if (gamer[0].engine != null)
				FormLog.This.cbPlayerList.Items.Add(gamer[0].player.name);
			if (gamer[1].engine != null)
				FormLog.This.cbPlayerList.Items.Add(gamer[1].player.name);
			if (FormLog.This.cbPlayerList.Items.Count > 0)
				FormLog.This.cbPlayerList.SelectedIndex = 0;
		}

		public void Rotate()
		{
			CGamer p = gamer[0];
			gamer[0] = gamer[1];
			gamer[1] = p;
			gamer[0].Init(true);
			gamer[1].Init(false);
		}

		public CGamer GetGamer(string name)
		{
			foreach (CGamer p in gamer)
				if (p.player.name == name)
					return p;
			return null;
		}

		public CGamer GetGamerPid(int pid)
		{
			foreach (CGamer p in gamer)
				if (p.enginePro.GetPid() == pid)
					return p;
			return null;
		}

		public CGamer GamerWinner()
		{
			return gamer[(CChess.g_moveNumber & 1) ^ 1];
		}

		public CGamer GamerLoser()
		{
			return gamer[CChess.g_moveNumber & 1];
		}

		public CGamer PlayerHum()
		{
			if (gamer[0].IsHuman())
				return gamer[0];
			if (gamer[1].IsHuman())
				return gamer[1];
			return null;
		}

		public CGamer GamerCur()
		{
			return gamer[curIndex];
		}

		public CGamer GamerSec()
		{
			return gamer[curIndex ^ 1];
		}

		public void Terminate()
		{
			gamer[0].enginePro.Terminate();
			gamer[1].enginePro.Terminate();
		}

	}
}