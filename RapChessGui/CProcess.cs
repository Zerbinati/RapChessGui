using System;
using System.IO;
using System.Diagnostics;

namespace RapChessGui
{

	public class CProcess
	{
		public Process process = new Process();

		public int GetPid()
		{
			if (process.StartInfo.FileName == "")
				return 0;
			return process.Id;
		}

		private void OnDataReceived(object sender, DataReceivedEventArgs e)
		{
			try
			{
				if (!String.IsNullOrEmpty(e.Data))
				{
					FormChess.SetMessage(process.Id, e.Data.Trim());
				}
			}
			catch { }
		}

		void SetPriority(string priority)
		{
			switch (priority)
			{
				case "Idle":
					process.PriorityClass = ProcessPriorityClass.Idle;
					break;
				case "Below normal":
					process.PriorityClass = ProcessPriorityClass.BelowNormal;
					break;
				case "Normal":
					process.PriorityClass = ProcessPriorityClass.Normal;
					break;
				case "Above normal":
					process.PriorityClass = ProcessPriorityClass.AboveNormal;
					break;
				case "High":
					process.PriorityClass = ProcessPriorityClass.High;
					break;

			}
		}

		public int SetProgram(string path, string param = "")
		{
			Terminate();
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
				SetPriority(FormOptions.priority);
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

		public void Terminate()
		{
			try
			{
				process.OutputDataReceived -= OnDataReceived;
				process.Kill();
				process.StartInfo.FileName = "";
			}
			catch { }
		}

		public void WriteLine(string c)
		{
			if (!process.HasExited)
				process.StandardInput.WriteLine(c);
		}

	}
}
