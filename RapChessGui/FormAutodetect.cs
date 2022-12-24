using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace RapChessGui
{
	public partial class FormAutodetect : Form
	{
		static int tick = 0;
		public static string engineName = String.Empty;
		public static CProtocol protocol = CProtocol.auto;
		public static bool testResult = false;
		public static int testMode = 0;
		public static CEngine testEngine = null;
		public static Task testTask = new Task(() => { });
		public static Stopwatch testWatch = new Stopwatch();
		public static CProcess testProcess = null;
		public static FormAutodetect This;

		public FormAutodetect()
		{
			InitializeComponent();
			This = this;
			testProcess = new CProcess(OnDataReceivedTest);
			FormOptions.SetFontSize(this);
		}

		#region process

		delegate void DeleMessageTest(string message);


		readonly static DeleMessageTest deleMessageTest = new DeleMessageTest(NewMessageTest);

		private void OnDataReceivedTest(object sender, DataReceivedEventArgs e)
		{
			try
			{
				if (!String.IsNullOrEmpty(e.Data))
				{
					Invoke(deleMessageTest, new object[] { e.Data.Trim() });
				}
			}
			catch { }
		}

		public static void NewMessageTest(string msg)
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(testWatch.Elapsed.TotalMilliseconds);
			string t = dt.ToString("ss.fff");
			bool con = msg.Contains(testEngine.protocol == CProtocol.uci ? "bestmove " : "move ");
			WriteLine($"{t} {msg}");
			switch (testMode)
			{
				case 0:
				case 1:
					if (msg == "uciok")
						testEngine.protocol = CProtocol.uci;
					break;
				case 2:
				case 3:
					if (con)
					{
						testEngine.modeTime = testResult;
						WriteLine("test time");
					}
					break;
				case 5:
				case 6:
					if (con)
					{
						testEngine.modeDepth = testResult;
						WriteLine("test depth");
					}
					break;
				case 8:
				case 9:
					if (con)
					{
						testEngine.modeStandard = testResult;
						WriteLine("test standard");
					}
					break;
				case 11:
				case 12:
					if (con)
					{
						testEngine.modeTournament = testResult;
						WriteLine("test tournament");
					}
					break;
			}
		}

		public static void TestStop()
		{
			if (testEngine.protocol == CProtocol.uci)
				testProcess.WriteLine("stop");
			else
				testProcess.WriteLine("?");
		}

		public static void TestRestart()
		{
			tick = 40;
			testProcess.Restart();
		}

		public static void TestUci(string command)
		{
			testProcess.WriteLine("uci");
			testProcess.WriteLine("ucinewgame");
			testProcess.WriteLine("position startpos");
			testProcess.WriteLine(command);
		}

		void TestXb(string command)
		{
			testProcess.WriteLine("new");
			testProcess.WriteLine(command);
			testProcess.WriteLine("post");
			testProcess.WriteLine("force");
			testProcess.WriteLine("g2g4");
			testProcess.WriteLine("black");
			testProcess.WriteLine("go");
		}

		void ShowProtocol()
		{
			if (testEngine.protocol == CProtocol.uci)
				WriteLine("protocol uci");
			else
				WriteLine("protocol xb");
		}

		void ShowTime()
		{
			if (testEngine.modeTime)
				WriteLine("mode time ok");
			else
				WriteLine("mode time fail");
		}

		void ShowDepth()
		{
			if (testEngine.modeDepth)
				WriteLine("mode depth ok");
			else
				WriteLine("mode depth fail");
		}

		void ShowStandard()
		{
			if (testEngine.modeStandard)
				WriteLine("mode standart ok");
			else
				WriteLine("mode standart fail");
		}

		void ShowTournament()
		{
			if ((testEngine.modeTournament) || (testEngine.protocol == CProtocol.uci))
				WriteLine("mode tournament ok");
			else
				WriteLine("mode tournament fail");
		}

		void NextPhase()
		{
			tick = 20;
			testWatch.Restart();
			testMode++;
			switch (testMode)
			{
				case 1:
					tick = 40;
					WriteLine("start test protocol");
					testProcess.WriteLine("uci");
					break;
				case 2:
					ShowProtocol();
					if (testEngine.protocol == CProtocol.winboard)
						testProcess.WriteLine("xboard");
					testEngine.modeTime = false;
					testResult = true;
					WriteLine("start test time 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go movetime 1000");
					else
						TestXb("st 1");
					break;
				case 3:
					if (testEngine.modeTime)
					{
						testResult = false;
						WriteLine("start test time 2");
						if (testEngine.protocol == CProtocol.uci)
							TestUci("go movetime 10000");
						else
							TestXb("st 10");
					}
					else
						NextPhase();
					break;
				case 4:
					TestRestart();
					break;
				case 5:
					ShowTime();
					testEngine.modeDepth = false;
					testResult = true;
					WriteLine("start test depth 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go depth 3");
					else
						TestXb("sd 3");
					break;
				case 6:
					if (testEngine.modeDepth)
					{
						testResult = false;
						WriteLine("start test depth 2");
						if (testEngine.protocol == CProtocol.uci)
							TestUci("go depth 60");
						else
							TestXb("sd 100");
					}
					else
						NextPhase();
					break;
				case 7:
					TestRestart();
					break;
				case 8:
					ShowDepth();
					testEngine.modeStandard = false;
					testResult = true;
					WriteLine("start test standard 1");
					if (testEngine.protocol == CProtocol.uci)
						TestUci("go wtime 500 btime 500 winc 0 binc 0");
					else
						TestXb("time 50");
					break;
				case 9:
					if (testEngine.modeStandard)
					{
						testResult = false;
						WriteLine("start test standard 2");
						if (testEngine.protocol == CProtocol.uci)
							TestUci("go wtime 1000000 btime 1000000 winc 0 binc 0");
						else
							TestXb("time 100000");
					}
					else
						NextPhase();
					break;
				case 10:
					TestStop();
					break;
				case 11:
					ShowStandard();
					testEngine.modeTournament = false;
					testResult = true;
					WriteLine("start test tournament 1");
					if(testEngine.protocol == CProtocol.uci)
						TestUci("go wtime 20000 btime 20000 winc 0 binc 0 movestogo 80");
					else
						TestXb("level 0 0:01 0");
					break;
				case 12:
					if (testEngine.modeTournament)
					{
						testResult = false;
						WriteLine("start test tournament 2");
						if (testEngine.protocol == CProtocol.uci)
							TestUci("go wtime 20000 btime 20000 winc 0 binc 0 movestogo 1");
						else
							TestXb("level 0 40:10 0");
					}
					else
						NextPhase();
					break;
				case 13:
					testTimer.Stop();
					testProcess.Terminate();
					testTimer.Enabled = false;
					if (testEngine.protocol == CProtocol.uci)
						testEngine.modeTournament = true;
					ShowProtocol();
					ShowTime();
					ShowDepth();
					ShowStandard();
					ShowTournament();
					WriteLine("finish");
					if (!testEngine.modeDepth && !testEngine.modeStandard && !testEngine.modeTime && !testEngine.modeTournament)
					{
						testEngine.modeDepth = true;
						testEngine.modeStandard = true;
						testEngine.modeTime = true;
						testEngine.modeTournament = true;
					}
					testEngine.SaveToIni();
					break;
			}
		}

		private void testTimer_Tick(object sender, EventArgs e)
		{
			if (--tick <= 0)
				NextPhase();
		}

		public void StartTestAuto()
		{
			testMode = 0;
			tbConsole.Clear();
			testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
			testTimer.Start();
		}

		#endregion

		static void WriteLine(string line, bool addTime = false)
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(testWatch.Elapsed.TotalMilliseconds);
			string t = dt.ToString("ss.fff");
			string msg = addTime ? $"{t} {line}\n" : $"{line}\n";
			This.tbConsole.AppendText(msg);
		}

		private void FormAutodetect_Shown(object sender, EventArgs e)
		{
			tbConsole.Clear();
			testEngine = FormChess.engineList.GetEngineByName(engineName);
			if (testEngine == null)
				WriteLine($"engine {engineName} not exist");
			else if (!testEngine.FileExists())
				WriteLine($"engine {engineName} file not exist");
			else
				WriteLine($"engine {engineName} ready");
		}

		private void FormAutodetect_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (testProcess != null)
				testProcess.Terminate();
		}

		private void bStart_Click(object sender, EventArgs e)
		{
			StartTestAuto();
		}

	}
}
