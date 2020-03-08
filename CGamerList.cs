using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

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
			if (engine.protocol == "Winboard")
				wbok = false;
		}

		public void Start()
		{
			mode = player.mode;
			value = player.value;
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
				readyok = false;
				wbok = false;
				switch (mode)
				{
					case "depth":
						mode = "sd";
						break;
					case "movetime":
						mode = "st";
						int v = Convert.ToInt32(player.value) / 1000;
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
			if (engine.protocol == "Uci")
			{
				SendMessage(CHistory.GetPosition());
				Thread.Sleep(1 << 5);
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
					if (CHistory.fen != CChess.defFen)
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
			if (engine != null)
			{
				FormLog.This.richTextBox1.AppendText($"{player.name} < {msg}\n", Color.Brown);
				PlayerEng.streamWriter.WriteLine(msg);
			}
		}

		public string GetProtocol()
		{
			if (engine == null)
				return "Protocol";
			else
				return engine.protocol;
		}

		public string GetTime()
		{
			DateTime dt1 = new DateTime();
			DateTime dt2 = dt1.AddMilliseconds(timeTotal + timer.Elapsed.TotalMilliseconds);
			return dt2.ToString("HH:mm:ss");
		}

		public string GetElo()
		{
			if (player == null)
				return "Elo";
			else
				return $"Elo {player.elo}";
		}

		public void SetPlayer(CPlayer p)
		{
			player = p;
			book = CBookList.GetBook(p.book);
			engine = CEngineList.GetEngine(p.engine);
			PlayerEng.SetPlayer(this);
		}

		public void SetPlayer()
		{
			SetPlayer(player);
		}

		public void SetPlayer(string name)
		{
			CPlayer p = CPlayerList.GetPlayer(name);
			SetPlayer(p);
		}

		public void UpdateTime()
		{
			timeTotal += timer.Elapsed.TotalMilliseconds;
			timer.Reset();
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
			string[] filePaths = Directory.GetFiles("Engines", "*.exe");
			for (int n = 0; n < filePaths.Length; n++)
			{
				string fn = Path.GetFileName(filePaths[n]);
				CData.fileEngine.Add(fn);
			}
			string[] arrBooks = Directory.GetFiles("Books", "*.exe");
			for (int n = 0; n < arrBooks.Length; n++)
			{
				string fn = Path.GetFileName(arrBooks[n]);
				CData.fileBook.Add(fn);
			}
		}

		public void Next()
		{
			CGamer cp = PlayerCur();
			cp.UpdateTime();
			cp.go = false;
			curIndex ^= 1;
			PlayerCur().timer.Restart();
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
			gamer[0].white = true;
			gamer[1].white = false;
		}

		public CGamer GetPlayer(string name)
		{
			foreach (CGamer p in gamer)
				if (p.player.name == name)
					return p;
			return null;
		}

		public CGamer PlayerHum()
		{
			if (gamer[0].engine == null)
				return gamer[0];
			if (gamer[1].engine == null)
				return gamer[1];
			return null;
		}

		public CGamer PlayerCur()
		{
			return gamer[curIndex];
		}

		public CGamer PlayerSec()
		{
			return gamer[curIndex ^ 1];
		}

		public CGamer PlayerPid(int pid)
		{
			foreach (CGamer p in gamer)
				if (p.PlayerEng.GetPid() == pid)
					return p;
			return null;
		}

		public void Terminate()
		{
			gamer[0].PlayerEng.Terminate();
			gamer[1].PlayerEng.Terminate();
		}

	}
}