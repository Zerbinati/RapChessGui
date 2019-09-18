using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RapChessGui
{
	class CReader
	{
		private static Thread inputThread;
		private static AutoResetEvent getInput;
		private static AutoResetEvent gotInput;
		private static string input;
		private static bool inputReady;
		private static StreamReader stream;

		private static void reader()
		{
			while (true)
			{
				getInput.WaitOne();
				if (!inputReady)
				{
					input = stream.ReadLine();
					inputReady = true;
					gotInput.Set();
				}
			}
		}

		public string ReadLine(bool wait)
		{
			if (inputReady)
			{
				inputReady = false;
				return input;
			}
			else
			{
				getInput.Set();
				if (wait)
				{
					gotInput.WaitOne();
					inputReady = false;
					return input;
				}
				else
					return "";
			}
		}

		public void SetStream(StreamReader sr)
		{
			stream = sr;
			inputReady = false;
			getInput = new AutoResetEvent(false);
			gotInput = new AutoResetEvent(false);
			inputThread = new Thread(reader);
			inputThread.IsBackground = true;
			inputThread.Start();
		}
	}
}

