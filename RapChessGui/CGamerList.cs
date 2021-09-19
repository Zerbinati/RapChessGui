using System;
using System.Drawing;
using System.Diagnostics;
using NSChess;

namespace RapChessGui
{

	public class CGamer
	{
		/// <summary>
		/// Ceation of the protocol header has started.
		/// </summary>
		public bool isPrepareStarted = false;
		/// <summary>
		/// Creation of the protocol header is complete.
		/// </summary>
		public bool isPrepareFinished = false;
		/// <summary>
		/// The position of the chess pieces has been sent to the winboard chess engine.
		/// </summary>
		public bool isPositionWb = false;
		/// <summary>
		/// The book is already started.
		/// </summary>
		public bool isBookStarted = false;
		/// <summary>
		/// Is no move int the open book.
		/// </summary>
		public bool isBookFail = false;
		/// <summary>
		/// The engine is already running.
		/// </summary>
		public bool isEngRunning = false;
		/// <summary>
		/// The gamer is white.
		/// </summary>
		public bool isWhite = true;
		/// <summary>
		/// Phase of prepare uci engine.
		/// </summary>
		public int uciPhase = 0;
		/// <summary>
		/// Count moves maked by book.
		/// </summary>
		public int countMovesBook;
		/// <summary>
		/// Count moves maked by engine.
		/// </summary>
		public int countMovesEngine;
		/// <summary>
		/// Count moves makes by engine or book.
		/// </summary>
		public int countMoves;
		public int iScore;
		public ulong infMs;
		public ulong nodes;
		public ulong nps;
		public ulong npsSum;
		public ulong npsCount;
		public string score;
		public int depth;
		public int seldepth;
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

		public void UciNextPhase()
		{
			switch (++uciPhase)
			{
				case 1:
					SendMessage("uci");
					break;
				case 2:
					foreach (string op in engine.options)
						SendMessage($"setoption {op}");
					SendMessage("isready");
					break;
				case 3:
					SendMessage("ucinewgame");
					SendMessage("isready");
					break;
				case 4:
					isPrepareFinished = true;
					break;
			}
		}

		public void Restart()
		{
			bookPro.Restart();
			enginePro.Restart();
		}

		public void EngineRestart()
		{
			isPrepareStarted = false;
			enginePro.Restart();
		}

		public void EngineStop()
		{
			if (engine.protocol == CProtocol.uci)
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

		public void Init(bool white)
		{
			isWhite = white;
			isBookStarted = false;
			isBookFail = false;
			isEngRunning = false;
			isPrepareStarted = false;
			isPrepareFinished = false;
			isPositionWb = false;
			uciPhase = 0;
			infMs = 0;
			countMovesBook = 0;
			countMovesEngine = 0;
			countMoves = 0;
			iScore = 0;
			nodes = 0;
			nps = 0;
			npsSum = 0;
			npsCount = 0;
			timerStart = 0;
			timer.Reset();
			Clear();
		}

		void Clear()
		{
			depth = 0;
			seldepth = 0;
			lastMove = "";
			ponder = "";
			pv = "";
			score = "";
		}

		public string GetName()
		{
			if (player.name == "")
				return isWhite ? "White" : "Black";
			else
				return player.name;
		}

		public void SetNps(ulong n)
		{
			nps = n;
			npsSum += n;
			npsCount++;
			if ((npsSum > (ulong.MaxValue >> 1)) && ((npsCount & 1) == 0))
			{
				npsSum >>= 1;
				npsCount >>= 1;
			}
		}

		public string GetEngineFile()
		{
			if (engine == null)
				return "";
			else
				return engine.file;
		}

		public string GetEngineName()
		{
			return engine == null ? "Human" : engine.name;
		}

		public ulong GetNps()
		{
			if (npsCount > 0)
				return npsSum / npsCount;
			else
				return 0;
		}

		/// <summary>
		/// Get emgome memory usage.
		/// </summary>
		public string GetMemory()
		{
			string result = "Memory";
			enginePro.process.Refresh();
			try
			{
				result = enginePro.process.PrivateMemorySize64.ToString("N0");
			}
			catch { }
			return result;
		}

		/// <summary>
		/// Start or prepare engine or book.
		/// </summary>
		public void TryStart()
		{
			if (player.IsComputer())
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
					if (!isPrepareStarted)
						EngPrepare();
					else if (isPrepareFinished && !isEngRunning)
						EngMakeMove();
		}

		public void TimerStart()
		{
			timer.Start();
			timerStart = timer.Elapsed.TotalMilliseconds;
		}

		public void Undo()
		{
			if (engine != null)
				if (engine.protocol == CProtocol.winboard)
					isPositionWb = false;
		}

		/// <summary>
		/// Prepare engine.
		/// </summary>
		void EngPrepare()
		{
			isPrepareStarted = true;
			lastMove = "";
			mode = player.modeValue.GetUci();
			value = player.modeValue.GetUciValue().ToString();
			if (engine.protocol == CProtocol.uci)
				UciNextPhase();
			else
			{
				SendMessage("xboard");
				isPrepareFinished = true;
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
			Clear();
			if (engine.protocol == CProtocol.uci)
				UciGo();
			else
			{
				if (isPositionWb)
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
					isPositionWb = true;
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
				FormLogEngines.AppendTimeText($"book {player.name}", col);
				FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
				bookPro.WriteLine(msg);
			}
		}

		public void SendMessage(string msg)
		{
			if (enginePro.process != null)
			{
				Color col = isWhite ? Color.DimGray : Color.Black;
				FormLogEngines.AppendTimeText($"{player.name}", col);
				FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
				enginePro.WriteLine(msg);
			}
		}

		public string GetBook()
		{
			if (player == null)
				return "Book";
			else
				return player.book;
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
				return CData.ProtocolToStr(engine.protocol);
		}

		public string GetDepth()
		{
			if (seldepth > 0)
				return $"{depth} / {seldepth}";
			else if (depth > 0)
				return $"{depth}";
			else return "";
		}

		public Color GetScoreColor()
		{
			double dr = 1.0;
			double dg = 1.0;
			if (iScore > 0)
				dr = 1.0 - iScore / 500.0;
			if (iScore < 0)
				dg = 1.0 + iScore / 500.0;
			if (dr < 0)
				dr = 0;
			if (dg < 0)
				dg = 0;
			return Color.FromArgb(200, Convert.ToInt32(dr * 0xff), Convert.ToInt32(dg * 0xff), 0);
		}

		public string GetTime(out bool low)
		{
			low = false;
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
				{
					FormChess.This.SetGameState(CGameState.time);
					return "Time out";
				}
				if (t > 0)
					dt = dt.AddMilliseconds(t);
				if (t < 10000)
				{
					low = true;
					return dt.ToString("ss.ff");
				}
			}
			else if (mode == "Time")
			{
				double v = Convert.ToDouble(value);
				if (((ms - timerStart) > (v + FormOptions.marginTime)) && (FormOptions.marginTime >= 0) && (value > 0) && timer.IsRunning)
				{
					FormChess.This.SetGameState(CGameState.time);
					return "Time out";
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
				return player.GetName();
		}

		public void SetPlayer(CPlayer p)
		{
			player = p;
			book = FormChess.bookList.GetBook(p.book);
			engine = FormChess.engineList.GetEngine(p.engine);
			bookPro.Terminate();
			enginePro.Terminate();
			if (book == null)
				p.book = "None";
			else
				bookPro.SetProgram(AppDomain.CurrentDomain.BaseDirectory + "Books\\" + book.file, book.GetParameters(engine));
			if (engine == null)
				p.engine = "Human";
			else
				enginePro.SetProgram(AppDomain.CurrentDomain.BaseDirectory + "Engines\\" + engine.file, engine.parameters);
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
		/// <summary>
		/// Index of current gammer
		/// </summary>
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

		public void Init(int index = 0)
		{
			gamer[0].Init(true);
			gamer[1].Init(false);
			curIndex = index;
		}

		public void Rotate(int index = 0)
		{
			CGamer p = gamer[0];
			gamer[0] = gamer[1];
			gamer[1] = p;
			Init(index);
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
					protocol = CData.ProtocolToStr(g.engine.protocol);
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
			return gamer[(FormChess.Chess.g_moveNumber & 1) ^ 1];
		}

		public CGamer GamerLoser()
		{
			return gamer[FormChess.Chess.g_moveNumber & 1];
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

		public void Restart()
		{
			foreach (CGamer g in gamer)
				g.Restart();
		}

		public void Terminate()
		{
			foreach (CGamer g in gamer)
			{
				g.timer.Stop();
				g.bookPro.Terminate();
				g.enginePro.Terminate();
			}
		}

		public void Undo()
		{
			foreach (CGamer g in gamer)
				g.Undo();
		}

	}
}