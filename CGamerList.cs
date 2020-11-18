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
		/// Is no move int the open book.
		/// </summary>
		public bool isBookFail = false;
		/// <summary>
		/// The engine is already prepared.
		/// </summary>
		public bool isEngPrepared = false;
		/// <summary>
		/// The engine is already running.
		/// </summary>
		public bool isEngRunning = false;
		/// <summary>
		/// The gamer is white.
		/// </summary>
		public bool isWhite = true;
		/// <summary>
		/// Count moves maked by book.
		/// </summary>
		public int countMovesBook;
		/// <summary>
		/// Count moves makes by engine or book.
		/// </summary>
		public int countMoves;
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
		public CPlayer player = new CPlayer();

		public CGamer()
		{
			Init(true);
		}

		public void EngineReset()
		{
			isEngPrepared = false;
			enginePro.SetProgram("Engines\\" + engine.file, engine.parameters);
		}

		public void EngineStop()
		{
			if (engine.protocol == "Uci")
				SendMessage("stop");
			else
				SendMessage("?");
		}

		public void EngineTerminate()
		{
			enginePro.Terminate();
		}

		public void EngineClose()
		{
			SendMessage("quit");
		}

		public void Init(bool w)
		{
			isWhite = w;
			timeOut = false;
			isBookStarted = false;
			isBookFail = false;
			isEngPrepared = false;
			isEngRunning = false;
			infMs = 0;
			countMovesBook = 0;
			countMoves = 0;
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
		/// Get emgome memory usage.
		/// </summary>
		public string GetMemory()
		{
			string result = "Memory";
			if (enginePro.process != null)
			{
				enginePro.process.Refresh();
				result = enginePro.process.PrivateMemorySize64.ToString("N0");
			}
			return result;
		}

		/// <summary>
		/// Start or prepare engine or book.
		/// </summary>
		public void TryStart()
		{
			if ((book != null) && (!isBookFail))
			{
				if (!isBookStarted)
				{
					SendMessageBook(CHistory.GetPosition());
					SendMessageBook("go");
					isBookStarted = true;
				}
			}
			else if (engine != null)
				if (!isEngPrepared)
					EngPrepare();
				else if (readyok && !isEngRunning)
					EngMakeMove();
		}

		public void TimerStart()
		{
			timer.Start();
			timerStart = timer.Elapsed.TotalMilliseconds;
		}

		public void Undo()
		{
			if (engine.protocol == "Winboard")
				wbok = false;
		}

		/// <summary>
		/// Prepare engine.
		/// </summary>
		void EngPrepare()
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
			isEngPrepared = true;
		}

		public Int64 GetIntTime()
		{
			Int64 v = Convert.ToInt64(player.modeValue.GetUciValue());
			Int64 t = Convert.ToInt64(v - timer.Elapsed.TotalMilliseconds);
			return t < 1 ? 1 : t;
		}

		void UciGo()
		{
			SendMessage(CHistory.GetPosition());
			if (player.modeValue.mode == "Standard")
			{
				CGamer gw = CGamerList.This.GamerWhite();
				CGamer gb = CGamerList.This.GamerBlack();
				SendMessage($"go wtime {gw.GetIntTime()} btime {gb.GetIntTime()} winc 0 binc 0");
			}
			else
				SendMessage($"go {player.modeValue.GetUci()} {player.modeValue.GetUciValue()}");
			TimerStart();
		}

		void XbGo()
		{
			if (player.modeValue.mode == "Standard")
			{
				CGamer gc = CGamerList.This.GamerCur();
				CGamer gs = CGamerList.This.GamerSec();
				SendMessage($"time {gc.GetIntTime() / 10}");
				SendMessage($"otim {gs.GetIntTime() / 10}");
			}
			SendMessage(CHistory.LastUmo());
		}

		/// <summary>
		/// Prepare or start engine.
		/// </summary>
		public void EngMakeMove()
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
					if (player.modeValue.mode == "Standard")
					{
						int v = Convert.ToInt32(player.modeValue.GetUciValue());
						int t = Convert.ToInt32(v - timer.Elapsed.TotalMilliseconds);
						if (t < 1)
							t = 1;
						SendMessage($"time {t / 10}");
						SendMessage($"otim {t / 10}");
					}
					else
						SendMessage($"{mode} {value}");
					SendMessage("post");
					if (CHistory.fen != CChess.defFen)
					{
						SendMessage($"setboard {CHistory.fen}");
					}
					SendMessage("easy");
					SendMessage("force");
					foreach (CHisMove m in CHistory.moveList)
						SendMessage(m.umo);
					if ((CHistory.moveList.Count & 1) == 0)
						SendMessage("white");
					else
						SendMessage("black");
					SendMessage("go");
					wbok = true;
				}
				TimerStart();
			}
			isEngRunning = true;
		}

		public void SendMessageBook(string msg)
		{
			if (bookPro.process != null)
			{
				Color col = isWhite ? Color.DimGray : Color.Black;
				FormLogEngines.AppendTime();
				FormLogEngines.AppendText($"book {player.name}", col);
				FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
				bookPro.process.StandardInput.WriteLine(msg);
			}
		}

		public void SendMessage(string msg)
		{
			if (enginePro.process != null)
			{
				Color col = isWhite ? Color.DimGray : Color.Black;
				FormLogEngines.AppendTime();
				FormLogEngines.AppendText($"{player.name}", col);
				FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
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
			FormChess.This.SetGameState(CGameState.time);
			if (engine != null)
				CRapLog.Add($"Time out {engine.name}");
			return "Time out";
		}

		public Color GetScoreColor() {
			if (iScore > 300)
				return Color.Green;
			else if (iScore < -300)
				return Color.Brown;
			return Color.DarkGray;
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
				if (t > 0)
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
						EngineReset();
						FormChess.This.MakeMove(lastMove);
						FormLogEngines.AppendTime();
						FormLogEngines.AppendText($"{player.name} forced move {lastMove}\n", Color.Orange);

					}
					else
						return SetTimeOut();
					timeOut = true;
				}
				if (ms > 0)
					dt = dt.AddMilliseconds(ms);
			}
			else
				if (ms > 0)
				dt = dt.AddMilliseconds(ms);
			return dt.ToString("HH:mm:ss");
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
			book = FormChess.bookList.GetBook(p.book);
			engine = FormChess.engineList.GetEngine(p.engine);
			if (book == null)
				p.book = "None";
			else
				bookPro.SetProgram("Books\\" + book.file, book.parameters);
			if (engine == null)
				p.engine = "Human";
			else
				enginePro.SetProgram("Engines\\" + engine.file, engine.parameters);
		}

		public void SetPlayer()
		{
			SetPlayer(player);
		}

		public void SetPlayer(string name)
		{
			CPlayer p = FormChess.playerList.GetPlayer(name);
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
			cg.isBookFail = false;
			cg.isEngRunning = false;
			curIndex ^= 1;
			cg = GamerCur();
			if (cg.player.IsHuman())
				cg.TimerStart();
		}

		public void Init()
		{
			gamer[0].Init(true);
			gamer[1].Init(false);
			curIndex = 0;
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
			foreach (CGamer g in gamer)
			{
				if (g.bookPro.GetPid() == pid)
				{
					protocol = "Book";
					return g;
				}
				if (g.enginePro.GetPid() == pid)
				{
					protocol = g.engine.protocol;
					return g;
				}
			}
			protocol = "";
			return null;
		}

		public CGamer GamerWhite()
		{
			return gamer[0];
		}

		public CGamer GamerBlack()
		{
			return gamer[1];
		}

		public CGamer GamerWinner()
		{
			return gamer[(CChess.g_moveNumber & 1) ^ 1];
		}

		public CGamer GamerLoser()
		{
			return gamer[CChess.g_moveNumber & 1];
		}

		public CGamer GamerHuman()
		{
			if (gamer[0].player.IsHuman())
				return gamer[0];
			if (gamer[1].player.IsHuman())
				return gamer[1];
			return null;
		}

		public CGamer GamerComputer()
		{
			if (gamer[0].player.IsComputer())
				return gamer[0];
			if (gamer[1].player.IsComputer())
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
				g.timer.Stop();
				g.bookPro.Terminate();
				g.enginePro.Terminate();
			}
			CMessageList.Clear();
		}

	}
}