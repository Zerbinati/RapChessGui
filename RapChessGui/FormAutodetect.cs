using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace RapChessGui
{
	public partial class FormAutodetect : Form
	{
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

		public static void TestUci()
		{
			testProcess.WriteLine("uci");
			testProcess.WriteLine("ucinewgame");
			testProcess.WriteLine("position startpos");
		}

		public static void TestModeUci()
		{
			testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
			testProcess.WriteLine("uci");
			Thread.Sleep(1000);
			testProcess.Terminate();
		}

		public static void TestModeTime()
		{
			testEngine.modeTime = false;
			testResult = true;
			testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
			if (testEngine.protocol == CProtocol.uci)
			{
				TestUci();
				testProcess.WriteLine("go movetime 1000");
			}
			else
			{
				testProcess.WriteLine("xboard");
				testProcess.WriteLine("new");
				testProcess.WriteLine("st 1");
				testProcess.WriteLine("post");
				testProcess.WriteLine("white");
				testProcess.WriteLine("go");
			}
			Thread.Sleep(4000);
			testWatch.Start();
			testProcess.Terminate();
			if (testEngine.modeTime)
			{
				testResult = false;
				testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
				if (testEngine.protocol == CProtocol.uci)
				{
					TestUci();
					testProcess.WriteLine("go movetime 10000");
				}
				else
				{
					testProcess.WriteLine("xboard");
					testProcess.WriteLine("new");
					testProcess.WriteLine("st 10");
					testProcess.WriteLine("post");
					testProcess.WriteLine("white");
					testProcess.WriteLine("go");
				}
				Thread.Sleep(2000);
				testProcess.Terminate();
			}
		}

		public static void NewMessageTest(string msg)
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(testWatch.Elapsed.TotalMilliseconds);
			string t = dt.ToString("ss.fff ");
			bool con = msg.Contains(testEngine.protocol == CProtocol.uci ? "bestmove " : "move ");
			switch (testMode)
			{
				case 0:
				case 1:
					if (msg == "uciok")
					{
						testEngine.protocol = CProtocol.uci;
						WriteLine("test uci");
						WriteLine($"{t} {msg}");
					}
					break;
				case 2:
				case 3:
					if (con)
					{
						testEngine.modeTime = testResult;
						WriteLine("test time");
						WriteLine($"{t} {msg} {testResult}");
					}
					break;
				case 4:
				case 5:
					if (con)
					{
						testEngine.modeDepth = testResult;
						WriteLine("test depth");
						WriteLine($"{t} {msg} {testResult}");
					}
					break;
				case 6:
				case 7:
					if (con)
					{
						testEngine.modeStandard = testResult;
						WriteLine("test standard");
						WriteLine($"{t} {msg} {testResult}");
					}
					break;
				case 8:
				case 9:
					if (con)
					{
						testEngine.modeTournament = testResult;
						WriteLine("test tournament");
						WriteLine($"{t} {msg} {testResult}");
					}
					break;
			}
		}

		void NextPhase()
		{
			testWatch.Restart();
			switch (testMode++)
			{
				case 1:
					tbConsole.Clear();
					WriteLine("test started");
					testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
					testProcess.WriteLine("uci");
					break;
				case 2:
					if (testEngine.protocol == CProtocol.uci)
						WriteLine("protocol uci");
					else
						WriteLine("protocol xb");
					testEngine.modeTime = false;
					testResult = true;
					testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
					if (testEngine.protocol == CProtocol.uci)
					{
						TestUci();
						testProcess.WriteLine("go movetime 1000");
					}
					else
					{
						testProcess.WriteLine("xboard");
						testProcess.WriteLine("new");
						testProcess.WriteLine("st 1");
						testProcess.WriteLine("post");
						testProcess.WriteLine("white");
						testProcess.WriteLine("go");
					}
					break;
				case 3:
					if (testEngine.modeTime)
					{
						testResult = false;
						testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
						if (testEngine.protocol == CProtocol.uci)
						{
							TestUci();
							testProcess.WriteLine("go movetime 10000");
						}
						else
						{
							testProcess.WriteLine("xboard");
							testProcess.WriteLine("new");
							testProcess.WriteLine("st 10");
							testProcess.WriteLine("post");
							testProcess.WriteLine("white");
							testProcess.WriteLine("go");
						}
					}
					else
						NextPhase();
					break;
				case 4:
					if (testEngine.modeTime)
						WriteLine("mode time ok");
					else
						WriteLine("mode time fail");
					testEngine.modeDepth = false;
					testResult = true;
					testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
					if (testEngine.protocol == CProtocol.uci)
					{
						TestUci();
						testProcess.WriteLine("go depth 3");
					}
					else
					{
						testProcess.WriteLine("xboard");
						testProcess.WriteLine("new");
						testProcess.WriteLine("sd 3");
						testProcess.WriteLine("post");
						testProcess.WriteLine("white");
						testProcess.WriteLine("go");
					}
					break;
				case 5:
					if (testEngine.modeDepth)
					{
						testResult = false;
						testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
						if (testEngine.protocol == CProtocol.uci)
						{
							TestUci();
							testProcess.WriteLine("go depth 100");
						}
						else
						{
							testProcess.WriteLine("xboard");
							testProcess.WriteLine("new");
							testProcess.WriteLine("sd 100");
							testProcess.WriteLine("post");
							testProcess.WriteLine("white");
							testProcess.WriteLine("go");
						}
					}
					else
						NextPhase();
					break;
				case 6:
					if (testEngine.modeDepth)
						WriteLine("mode depth ok");
					else
						WriteLine("mode depth fail");
					testEngine.modeStandard = false;
					testResult = true;
					testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
					if (testEngine.protocol == CProtocol.uci)
					{
						TestUci();
						testProcess.WriteLine("go wtime 500 btime 500 winc 0 binc 0");
					}
					else
					{
						testProcess.WriteLine("xboard");
						testProcess.WriteLine("new");
						testProcess.WriteLine("time 50");
						testProcess.WriteLine("otim 50");
						testProcess.WriteLine("post");
						testProcess.WriteLine("white");
						testProcess.WriteLine("go");
					}
					break;
				case 7:
					if (testEngine.modeStandard)
					{
						testResult = false;
						testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
						if (testEngine.protocol == CProtocol.uci)
						{
							TestUci();
							testProcess.WriteLine("go wtime 1000000 btime 1000000 winc 0 binc 0");
						}
						else
						{
							testProcess.WriteLine("xboard");
							testProcess.WriteLine("new");
							testProcess.WriteLine("time 100000");
							testProcess.WriteLine("otim 100000");
							testProcess.WriteLine("post");
							testProcess.WriteLine("white");
							testProcess.WriteLine("go");
						}
					}else
						NextPhase();
						break;
				case 8:
					if (testEngine.modeStandard)
						WriteLine("mode standart ok");
					else
						WriteLine("mode standart fail");
					testEngine.modeTournament = false;
					testResult = true;
					if (testEngine.protocol == CProtocol.winboard)
					{
						testEngine.modeTournament = false;
						testResult = true;
						testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
						testProcess.WriteLine("xboard");
						testProcess.WriteLine("new");
						testProcess.WriteLine("level 0 0:01 0");
						testProcess.WriteLine("post");
						testProcess.WriteLine("white");
						testProcess.WriteLine("go");
					}
					else
						NextPhase();
					break;
				case 9:
					if ((testEngine.protocol == CProtocol.winboard) && (testEngine.modeTournament))
					{
						testResult = false;
						testProcess.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{testEngine.file}", testEngine.parameters);
						testProcess.WriteLine("xboard");
						testProcess.WriteLine("new");
						testProcess.WriteLine("level 0 60 0");
						testProcess.WriteLine("post");
						testProcess.WriteLine("white");
						testProcess.WriteLine("go");
					}
					else
						NextPhase();
					break;
				case 10:
					testProcess.Terminate();
					if ((testEngine.modeTournament) || (testEngine.protocol == CProtocol.uci))
						WriteLine("mode tournament ok");
					else
						WriteLine("mode tournament fail");
					testTimer.Enabled = false;
					if (!testEngine.modeDepth && !testEngine.modeStandard && !testEngine.modeTime && !testEngine.modeTournament)
					{
						testEngine.modeDepth = true;
						testEngine.modeStandard = true;
						testEngine.modeTime = true;
						testEngine.modeTournament = true;
					}
					if (testEngine.protocol == CProtocol.uci)
						testEngine.modeTournament = true;
					testEngine.SaveToIni();
					WriteLine("test finished");
					break;
			}

		}

		private void testTimer_Tick(object sender, EventArgs e)
		{
			NextPhase();
		}

		public void StartTestAuto()
		{
			testMode = 0;
			testTimer.Enabled = true;
		}

		#endregion

		static void WriteLine(string line)
		{
			This.tbConsole.AppendText($"{line}\n");
		}

		private void FormAutodetect_Shown(object sender, EventArgs e)
		{
			tbConsole.Clear();
			WriteLine($"engine {engineName}");
		}

		private void FormAutodetect_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (testProcess != null)
				testProcess.Terminate();
		}

		private void bStart_Click(object sender, EventArgs e)
		{
			testEngine = FormChess.engineList.GetEngineByName(engineName);
			if (testEngine == null)
			{
				WriteLine("engine not exist");
				return;
			}
			if (!testEngine.FileExists())
			{
				WriteLine("engine file not exist");
				return;
			}
			StartTestAuto();
		}

	}
}
