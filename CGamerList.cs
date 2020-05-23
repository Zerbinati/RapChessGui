using System;
using System.Drawing;
using System.Diagnostics;
using RapLog;

namespace RapChessGui
{

	public class CGamer
	{
		public bool timeOut = false;
		public bool uciok = false;
		public bool wbok = false;
		public bool readyok = false;
		/// <summary>
		/// The book is already started.
		/// </summary>
		public bool isBookStarted = false;
		/// <summary>
		/// The book is already finished.
		/// </summary>
		public bool isBookFinished = false;
		/// <summary>
		/// The engine is already prepared.
		/// </summary>
		public bool isPrepared = false;
		/// <summary>
		/// The engine is already running.
		/// </summary>
		public bool isRunning = false;
		public bool white = true;
		public int usedBook;
		public int iScore;
		public ulong infMs;
		public ulong nodes;
		public ulong nps;
		public string score;
		public string depth;
		public string seldepth;
		public string ponder;
		public string mode;
		public string value;
		public string pv;
		public string lastMove;
		public double timerStart;
		public Stopwatch timer = new Stopwatch();
		public CProcess bookPro = new CProcess();
		public CProcess enginePro = new CProcess();
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
			timeOut = false;
			white = w;
			isBookStarted = false;
			isBookFinished = false;
			isPrepared = false;
			isRunning = false;
			infMs = 0;
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
			lastMove = "";
			timer.Reset();
		}

		/// <summary>
		/// The engine starts if needed.
		/// </summary>
		public void TryStart()
		{
			if ((book != null) && (!isBookFinished))
			{
				if (!isBookStarted)
				{
					SendMessageBook(CHistory.GetPosition());
					SendMessageBook("go");
					isBookStarted = true;
				}
			}
			else
				TryEngine();
		}

		public void TryEngine()
		{
			if (engine != null)
			{
				if (!isPrepared)
				{
					SetPlayer();
					Prepare();
				}
				else if (readyok && !isRunning)
					CompMakeMove();
			}
		}

		public void TimerStart()
		{
			timer.Start();
			timerStart = timer.Elapsed.TotalMilliseconds;
		}

		public bool IsComputer()
		{
			return engine != null;
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

		void Prepare()
		{
			lastMove = "";
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
			isPrepared = true;
		}

		void UciGo()
		{
			SendMessage(CHistory.GetPosition());
			if (player.modeValue.mode == "Standard")
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
			if (player.modeValue.mode == "Standard")
			{
				int v = Convert.ToInt32(player.modeValue.GetUciValue());
				int t = Convert.ToInt32(v - timer.Elapsed.TotalMilliseconds);
				if (t < 1)
					t = 1;
				SendMessage($"time {t / 10}");
				SendMessage($"otim {t / 10}");
			}
			SendMessage(CHistory.Last().emo);
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
					SendMessage("post");
					if (CHistory.fen != CChess.defFen)
					{
						SendMessage($"setboard {CHistory.fen}");
					}
					SendMessage("easy");
					SendMessage("force");
					foreach (CHisMove m in CHistory.moveList)
						SendMessage(m.emo);
					if (player.modeValue.mode == "Standard")
					{
						int v = Convert.ToInt32(player.modeValue.GetUciValue());
						int t = Convert.ToInt32(v - timer.Elapsed.TotalMilliseconds);
						if (t < 1)
							t = 1;
						SendMessage($"time {t / 10}");
						SendMessage($"otim {t / 10}");
					}else
						SendMessage($"{mode} {value}");
					if ((CHistory.moveList.Count & 1) == 0)
						SendMessage("white");
					else
						SendMessage("black");
					SendMessage("go");
					wbok = true;
				}
				TimerStart();
			}
			isRunning = true;
		}

		public void SendMessageBook(string msg)
		{
			if (bookPro.process != null)
			{
				FormLog.This.richTextBox1.AppendText($"book {player.name} < {msg}\n", Color.Brown);
				bookPro.process.StandardInput.WriteLine(msg);
			}
		}

		public void SendMessage(string msg)
		{
			if (enginePro.process != null)
			{
				FormLog.This.richTextBox1.AppendText($"{player.name} < {msg}\n", Color.Brown);
				enginePro.process.StandardInput.WriteLine(msg);
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

		string SetTimeOut()
		{
			FormChess.SetGameState(CGameState.time);
			if (engine != null)
				CRapLog.Add($"Time out {engine.name}");
			return "Time out";
		}

		public string GetTime()
		{
			double ms = timer.Elapsed.TotalMilliseconds;
			DateTime dt = new DateTime();
			string mode = "";
			int value = 0;
			if (player != null)
			{
				mode = player.modeValue.mode;
				value = player.modeValue.GetUciValue();
			}
			if (mode == "Standard")
			{
				double v = Convert.ToDouble(value);
				double t = v - ms;
				if ((t < -FormOptions.marginStandard) && (FormOptions.marginStandard >= 0) && timer.IsRunning)
					return SetTimeOut();
				if (t < 0)
					t = 0;
				dt = dt.AddMilliseconds(t);
				if (t < 10000)
					return dt.ToString("ss.ff");
			}
			else if (mode == "Time")
			{
				double v = Convert.ToDouble(value);
				if (((ms - timerStart) > (v + FormOptions.marginTime)) && (FormOptions.marginTime >= 0) && (value > 0) && timer.IsRunning)
				{
					if (CChess.This.IsValidMove(lastMove) > 0)
					{
						isPrepared = false;
						enginePro.Terminate();
						FormChess.This.MakeMove(lastMove);
						FormLog.This.richTextBox1.AppendText($"{player.name} forced move {lastMove}\n", Color.Orange);
					}
					else
						return SetTimeOut();
					timeOut = true;
				}
				dt = dt.AddMilliseconds(ms);
			}
			else
				dt = dt.AddMilliseconds(ms);
			return dt.ToString("HH:mm:ss");
		}

		public string GetTimeElapsed()
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(timer.Elapsed.TotalMilliseconds - timerStart);
			return dt.ToString("HH:mm:ss.fff");
		}

		public string GetElo()
		{
			if (player == null)
				return "Elo";
			else
				return $"Elo {player.elo}";
		}

		public string GetPlayerName()
		{
			if (player == null)
				return "Human";
			else
				return player.name;
		}

		public void SetPlayer(CPlayer p)
		{
			player = p;
			book = CBookList.GetBook(p.book);
			engine = CEngineList.GetEngine(p.engine);
			if (book != null)
				bookPro.SetProgram("Books\\" + book.file, book.parameters);
			if (engine != null)
				enginePro.SetProgram("Engines\\" + engine.file, engine.parameters);
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
			cg.timer.Stop();
			cg.isBookStarted = false;
			cg.isBookFinished = false;
			cg.isRunning = false;
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

		public CGamer GetGamerPid(int pid, out string protocol)
		{
			protocol = "Uci";
			foreach (CGamer g in gamer)
			{
				if (g.bookPro.GetPid() == pid)
					return g;
				if (g.enginePro.GetPid() == pid)
				{
					protocol = g.engine.protocol;
					return g;
				}
			}
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
			foreach (CGamer g in gamer)
			{
				g.bookPro.Terminate();
				g.enginePro.Terminate();
			}
		}

	}
}