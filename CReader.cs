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
		private Thread inputThread;
		private AutoResetEvent getInput;
		private AutoResetEvent gotInput;
		private string input;
		public bool inputReady;
		private StreamReader stream;

		private void Reader()
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

		public string ReadLine(bool wait = false)
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
			inputThread = new Thread(Reader);
			inputThread.IsBackground = true;
			inputThread.Start();
		}
	}
}

