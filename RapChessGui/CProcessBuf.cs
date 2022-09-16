using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace RapChessGui
{

	public class CProcessBuf
	{
		bool spamOff = true;
		bool timerStop = false;
		private readonly object locker = new object();
		public Process process = new Process();
		private readonly Queue<string> messages = new Queue<string>();

		public string GetMessage()
		{
			lock (locker)
			{
				if (timerStop)
				{
					timerStop = false;
					return "timerstop";
				}
				return messages.Count > 0 ? messages.Dequeue() : String.Empty;
			}

		}

		public void Clear()
		{
			lock (locker)
			{
				timerStop = false;
				messages.Clear();
				process.StartInfo.FileName = String.Empty;
			}
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
					lock (locker)
					{
						string msg = e.Data.Trim();
						if (msg.Contains("bestmove "))
							if (spamOff)
								messages.Clear();
							else if(messages.Count > 0)
								timerStop = true;
						messages.Enqueue(msg);
					}
				}
			}
			catch { }
		}

		public int SetProgram(string path, string param = "",bool so = false)
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

		public void WriteLine(string c)
		{
			if (!process.HasExited)
			{
				process.StandardInput.WriteLine(c);
				process.StandardInput.Flush();
			}
		}

	}
}
