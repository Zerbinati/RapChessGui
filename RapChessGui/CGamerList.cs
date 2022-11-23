﻿using System;
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
		public bool isPositionXb = false;
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
		public int depthTotal;
		public int depthCount;
		public int depthMax;
		public int msgPriority = 0;
		public int scoreI;
		public ulong infMs;
		public ulong nodes;
		public ulong nps;
		public ulong npsTotal;
		public ulong npsCount;
		public string scoreS;
		public int depth;
		public int seldepth;
		int hash;
		public string ponder;
		public string ponderFormated;
		public string pv;
		public string lastMove;
		public double timerStart;
		public Stopwatch timer = new Stopwatch();
		public CProcessBuf curProcess = null;
		public CProcessBuf bookPro = new CProcessBuf();
		public CProcessBuf enginePro = new CProcessBuf();
		public CBook book = null;
		public CEngine engine = null;
		public CPlayer player = new CPlayer();


		public int Hash
		{
			get
			{
				return hash;
			}
			set
			{
				if (hash < 0)
					hash = 0;
				if (hash > 1000)
					hash = 1000;
				hash = value;
			}
		}

		public CGamer()
		{
			InitNextGame(true);
		}

		public string GetMessage(out int pid)
		{
			string msg = String.Empty;
			if (curProcess == enginePro)
			{
				pid = enginePro.process.Id;
				msg = enginePro.GetMessage(out bool stop);
				if (stop)
					timer.Stop();
				return msg;
			}
			if (curProcess == bookPro)
			{
				pid = bookPro.process.Id;
				return bookPro.GetMessage(out _);
			}
			pid = 0;
			return msg;
		}

		public void UciNextPhase()
		{
			switch (++uciPhase)
			{
				case 1:
					SendMessageToEngine("uci");
					break;
				case 2:
					foreach (string op in engine.options)
						SendMessageToEngine($"setoption {op}");
					SendMessageToEngine("isready");
					break;
				case 3:
					SendMessageToEngine("ucinewgame");
					SendMessageToEngine("isready");
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
				SendMessageToEngine("stop");
			else
				SendMessageToEngine("?");
		}

		public void EngineTerminate()
		{
			enginePro.Terminate();
		}

		public void EngineClose()
		{
			SendMessageToEngine("quit");
		}

		public void InitNextGame(bool white)
		{
			curProcess = null;
			isWhite = white;
			isBookStarted = false;
			isBookFail = false;
			isEngRunning = false;
			isPrepareStarted = false;
			isPrepareFinished = false;
			isPositionXb = false;
			hash = 0;
			uciPhase = 0;
			infMs = 0;
			countMovesBook = 0;
			countMovesEngine = 0;
			countMoves = 0;
			nodes = 0;
			nps = 0;
			npsTotal = 0;
			npsCount = 0;
			depthTotal = 0;
			depthCount = 0;
			timerStart = 0;
			timer.Reset();
			InitNextMove();
		}

		void InitNextMove()
		{
			if (depth > 0)
			{
				depthCount++;
				depthTotal += depth;
			}
			if (nps > 0)
			{
				npsCount++;
				npsTotal += nps;
				if ((npsTotal > (ulong.MaxValue >> 1)) && ((npsCount & 1) == 0))
				{
					npsTotal >>= 1;
					npsCount >>= 1;
				}
			}
			depth = 0;
			msgPriority = 0;
			seldepth = 0;
			scoreI = 0;
			lastMove = String.Empty;
			ponder = String.Empty;
			ponderFormated = String.Empty;
			pv = String.Empty;
			scoreS = String.Empty;
		}

		public string GetName()
		{
			if (player.name == "")
				return isWhite ? "White" : "Black";
			else
				return player.name;
		}

		public int GetDepthAvg()
		{
			return (depthTotal + depth) / (depthCount + 1);
		}

		public ulong GetNpsAvg()
		{
			return (npsTotal + nps) / (npsCount + 1);
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
			return engine == null ? "None" : engine.name;
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
				if (enginePro.process.StartInfo.FileName != String.Empty)
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
						SendMessageToBook(CHistory.GetPosition());
						SendMessageToBook("go");
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
					isPositionXb = false;
		}

		/// <summary>
		/// Prepare engine.
		/// </summary>
		void EngPrepare()
		{
			isPrepareStarted = true;
			lastMove = String.Empty;
			if (engine.protocol == CProtocol.uci)
				UciNextPhase();
			else
			{
				SendMessageToEngine("xboard");
				isPrepareFinished = true;
				XbGo();
			}
		}

		public int GetRemainingMs()
		{
			int v = Convert.ToInt32(player.modeValue.GetUciValue());
			int t = Convert.ToInt32(v - timer.Elapsed.TotalMilliseconds);
			return t < 1 ? 1 : t;
		}

		public string GetTimeXB(long ms)
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(ms);
			return dt.ToString("mm:ss");
		}

		void UciGo()
		{
			SendMessageToEngine(CHistory.GetPosition());
			if (player.modeValue.level == CLevel.standard)
			{
				CGamer gw = CGamerList.This.GamerWhite();
				CGamer gb = CGamerList.This.GamerBlack();
				SendMessageToEngine($"go wtime {gw.GetRemainingMs()} btime {gb.GetRemainingMs()} winc 0 binc 0");
			}
			else
				SendMessageToEngine($"go {player.modeValue.GetUci()} {player.modeValue.GetUciValue()}");
			TimerStart();
		}

		void XbGoTournament()
		{
			int ms = GetRemainingMs();
			SendMessageToEngine($"level 0 {GetTimeXB(ms)} 0");
		}

		void XbGoStandard()
		{
			if (engine.modeStandard)
			{
				CGamer gs = CGamerList.This.GamerSec();
				SendMessageToEngine($"time {GetRemainingMs() / 10}");
				SendMessageToEngine($"otim {gs.GetRemainingMs() / 10}");
			}
			else
				XbGoTournament();
		}

		void XbGoTime()
		{
			int ms = player.modeValue.GetUciValue();
			if (engine.modeTime)
				SendMessageToEngine($"st {ms / 1000}");
			else
				SendMessageToEngine($"level 0 0 {ms / 1000}");
		}

		void XbGoDepth()
		{
			int d = player.modeValue.GetUciValue();
			SendMessageToEngine($"sd {d}");
		}

		void XbGo()
		{
			switch (player.modeValue.level)
			{
				case CLevel.standard:
					XbGoStandard();
					break;
				case CLevel.depth:
					XbGoDepth();
					break;
				case CLevel.time:
					XbGoTime();
					break;
			}
		}

		/// <summary>
		/// Prepare or start engine when is his turn.
		/// </summary>
		public void EngMakeMove()
		{
			InitNextMove();
			if (engine.protocol == CProtocol.uci)
				UciGo();
			else
			{
				if (isPositionXb)
				{
					XbGo();
					SendMessageToEngine(CHistory.LastUmo());
				}
				else
				{
					SendMessageToEngine("new");
					XbGo();
					SendMessageToEngine("post");
					if (CHistory.fen != CChess.defFen)
					{
						SendMessageToEngine($"setboard {CHistory.fen}");
					}
					SendMessageToEngine("force");
					foreach (CHisMove m in CHistory.moveList)
						SendMessageToEngine(m.umo);
					if ((CHistory.moveList.Count & 1) == 0)
						SendMessageToEngine("white");
					else
						SendMessageToEngine("black");
					SendMessageToEngine("go");
					isPositionXb = true;
				}
				TimerStart();
			}
			isEngRunning = true;
		}

		public void SendMessageToBook(string msg)
		{
			if (bookPro.process != null)
			{
				Color col = isWhite ? Color.DimGray : Color.Black;
				FormLogEngines.AppendTimeText($"book {player.name}", col);
				FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
				bookPro.WriteLine(msg);
				curProcess = bookPro;
			}
		}

		public void SendMessageToEngine(string msg)
		{
			if (enginePro.process != null)
			{
				Color col = isWhite ? Color.DimGray : Color.Black;
				FormLogEngines.AppendTimeText($"{player.name}", col);
				FormLogEngines.AppendText($" < {msg}\n", Color.Brown);
				enginePro.WriteLine(msg);
				curProcess = enginePro;
			}
		}

		public string GetBook()
		{
			if (player == null)
				return "Book";
			return player.book;
		}

		public string GetMode()
		{
			if (player == null)
				return "Mode";
			return player.modeValue.LongName();
		}

		public string GetProtocol()
		{
			if (engine == null)
				return "Protocol";
			return CData.ProtocolToStr(engine.protocol);
		}

		public string GetDepth()
		{
			if (depth > 0)
				return $"{depth} / {seldepth} / {GetDepthAvg()}";
			return String.Empty;
		}

		public Color GetScoreColor()
		{
			double dr = 1.0;
			double dg = 1.0;
			if (scoreI > 0)
				dr = 1.0 - scoreI / 500.0;
			if (scoreI < 0)
				dg = 1.0 + scoreI / 500.0;
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
			CLevel level = CLevel.standard;
			int value = 0;
			if (player != null)
			{
				level = player.modeValue.level;
				value = player.modeValue.GetUciValue();
			}
			if (level == CLevel.standard)
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
			else if (level == CLevel.time)
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
				return Global.human;
			else
				return player.GetName();
		}

		public void SetPlayer(CPlayer p)
		{
			player = p;
			book = FormChess.bookList.GetBookByName(p.book);
			engine = FormChess.engineList.GetEngineByName(p.engine);
			bookPro.Terminate();
			enginePro.Terminate();
			if (book == null)
				p.book = Global.none;
			else
				bookPro.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Books\{book.file}", book.GetParameters(engine));
			if (engine == null)
				p.engine = Global.none;
			else
				enginePro.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{engine.file}", engine.parameters, FormOptions.spamOff);
		}

		public void SetPlayer()
		{
			SetPlayer(player);
		}

		public void SetPlayer(string name)
		{
			CPlayer p = FormChess.playerList.GetPlayerByName(name);
			SetPlayer(p);
		}

	}

	class CGamerList
	{
		/// <summary>
		/// Index of current gammer
		/// </summary>
		public int curIndex = 0;
		public CGamer[] gamers = new CGamer[2];
		public static CGamerList This;

		public CGamerList()
		{
			This = this;
			gamers[0] = new CGamer();
			gamers[1] = new CGamer();
		}

		public bool Check(out string msg)
		{
			msg = String.Empty;
			foreach(CGamer g in gamers)
				if (!g.player.Check(out msg))
					return false;
			return true;
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
			if (FormChess.chess.WhiteTurn)
				FormLogEngines.AddMove(FormChess.chess.MoveNumber);
		}

		public void Init(int index = 0)
		{
			gamers[0].InitNextGame(true);
			gamers[1].InitNextGame(false);
			curIndex = index;
		}

		public void Rotate(int index = 0)
		{
			(gamers[1], gamers[0]) = (gamers[0], gamers[1]);
			Init(index);
		}

		public CGamer GetGamer(string name)
		{
			foreach (CGamer p in gamers)
				if (p.player.name == name)
					return p;
			return null;
		}

		public int GetMsgPriority()
		{
			return gamers[0].msgPriority > gamers[1].msgPriority ? gamers[0].msgPriority : gamers[1].msgPriority;
		}

		public CGamer GetGamerPid(int pid, out string protocol)
		{
			foreach (CGamer g in gamers)
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
			protocol = String.Empty;
			return null;
		}

		public CGamer GamerWhite()
		{
			return gamers[0];
		}

		public CGamer GamerBlack()
		{
			return gamers[1];
		}

		public CGamer GamerWinner()
		{
			return gamers[(FormChess.chess.halfMove & 1) ^ 1];
		}

		public CGamer GamerLoser()
		{
			return gamers[FormChess.chess.halfMove & 1];
		}

		public CGamer GamerHuman()
		{
			if (gamers[0].player.IsHuman())
				return gamers[0];
			if (gamers[1].player.IsHuman())
				return gamers[1];
			return null;
		}

		public CGamer GamerComputer()
		{
			if (gamers[0].player.IsComputer())
				return gamers[0];
			if (gamers[1].player.IsComputer())
				return gamers[1];
			return null;
		}

		public CGamer GamerCur()
		{
			return gamers[curIndex];
		}

		public CGamer GamerSec()
		{
			return gamers[curIndex ^ 1];
		}

		public void Restart()
		{
			foreach (CGamer g in gamers)
				g.Restart();
		}

		public void Terminate()
		{
			foreach (CGamer g in gamers)
			{
				g.timer.Stop();
				g.bookPro.Close();
				g.enginePro.Terminate();
			}
		}

		public void Undo()
		{
			foreach (CGamer g in gamers)
				g.Undo();
		}

	}
}