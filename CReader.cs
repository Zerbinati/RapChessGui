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
		private StreamReader stream;

		private void Reader()
		{
			while (true)
			{
				getInput.WaitOne();
				input = "";
				input = stream.ReadLine();
				gotInput.Set();
				getInput.Reset();
			}
		}

		public string ReadLine(bool wait = false)
		{
			string s = input;
			getInput.Set();
			if (s == "")
			{
				if (wait)
					gotInput.WaitOne();
				return input;
			}
			else
				return s;
		}

		public void SetStream(StreamReader sr)
		{
			stream = sr;
			getInput = new AutoResetEvent(false);
			gotInput = new AutoResetEvent(false);
			inputThread = new Thread(Reader);
			inputThread.IsBackground = true;
			inputThread.Start();
		}
	}
}

