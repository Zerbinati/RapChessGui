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
		public Process process = new Process();
		readonly private object locker = new object();
		private readonly List<string> list = new List<string>();


		void SetMessage(string msg)
		{
			lock (locker)
			{
				list.Add(msg);
			}
		}

		public string GetMessage(out bool stop)
		{
			stop = false;
			string msg = String.Empty;
			lock (locker)
			{
				foreach (string m in list)
					if (m.Contains("bestmove"))
					{
						stop = true;
						if (spamOff)
						{
							list.Clear();
							return m;
						}
					}
				if (list.Count > 0)
				{

					msg = list[0];
					list.RemoveAt(0);
				}
			}
			return msg;
		}

		public void Clear()
		{
			lock (locker)
			{
				list.Clear();
			}
			process.StartInfo.FileName = String.Empty;
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
					SetMessage(msg);
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
				process.StartInfo.RedirectStandardError = true;
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
			}
		}

	}
}
