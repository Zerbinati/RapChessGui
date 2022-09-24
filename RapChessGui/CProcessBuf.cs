using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace RapChessGui
{

	public class CProcessBuf
	{
		bool spamOff = true;
		int msgStop = 0;
		public Process process = new Process();
		private readonly List<string> bufWrite = new List<string>();
		private readonly List<string> bufRead = new List<string>();


		void SetMessage(string msg, bool clear)
		{
			try
			{
				if (clear)
					bufWrite.Clear();
				bufWrite.Add(msg);
			}
			catch { }
		}

		public string GetMessage()
		{
			string msg = String.Empty;
			if (bufRead.Count > 0)
			{
				msg = bufRead[0];
				bufRead.RemoveAt(0);
				return msg;
			}
			try
			{
				if (bufWrite.Count > 0)
				{
					bufRead.AddRange(bufWrite);
					bufWrite.Clear();
				}
			}
			catch { }
			if (bufRead.Count > 0)
			{
				msg = bufRead[0];
				bufRead.RemoveAt(0);
			}
			return msg;
		}

		public void Clear()
		{
			try
			{
				bufWrite.Clear();
				bufRead.Clear();
				process.StartInfo.FileName = String.Empty;
			}
			catch { }
		}

		public int GetPid()
		{
			if (process.StartInfo.FileName == String.Empty)
				return 0;
			return process.Id;
		}

		private void OnDataReceived(object sender, DataReceivedEventArgs e)
		{
			try
			{
				if (!String.IsNullOrEmpty(e.Data))
				{
					string msg = e.Data.Trim();
					bool clear = false;
					if (msg.Contains("bestmove "))
					{
						clear = spamOff;
						CWinMessage.Message(msgStop);
					}
					SetMessage(msg, clear);
				}
			}
			catch { }
		}

		public int SetProgram(string path, string param = "", bool so = false)
		{
			Terminate();
			spamOff = so;
			if (File.Exists(path))
			{
				process = new Process();
				process.StartInfo.FileName = path;
				process.StartInfo.Arguments = param;
				process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = false;
				process.StartInfo.UseShellExecute = false;
				process.OutputDataReceived += OnDataReceived;
				process.Start();
				process.BeginOutputReadLine();
				process.PriorityClass = FormOptions.priority;
				return process.Id;
			}
			return 0;
		}

		public void Restart()
		{
			SetProgram(process.StartInfo.FileName, process.StartInfo.Arguments);
		}

		public void Stop()
		{
			WriteLine("stop");
		}

		public void Quit()
		{
			WriteLine("quit");
		}

		public void Close()
		{
			if (process.StartInfo.FileName != String.Empty)
			{
				Quit();
				process.OutputDataReceived -= OnDataReceived;
				Clear();
			}
		}

		public void Terminate()
		{
			try
			{
				if (process.StartInfo.FileName != String.Empty)
				{
					process.OutputDataReceived -= OnDataReceived;
					process.Kill();
					Clear();
				}
			}
			catch { }
		}

		public void WriteLine(string c, int stop = 0)
		{
			if (!process.HasExited)
			{
				if (stop != 0)
					msgStop = stop;
				process.StandardInput.WriteLine(c);
				process.StandardInput.Flush();
			}
		}

	}
}
