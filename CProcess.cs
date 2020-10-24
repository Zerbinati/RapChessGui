using System;
using System.IO;
using System.Diagnostics;

namespace RapChessGui
{
	public class CProcess
	{
		public Process process = null;

		public int GetPid()
		{
			if (process == null)
				return 0;
			return process.Id;
		}

		private void ProEvent(object sender, DataReceivedEventArgs e)
		{
			if ((process != null) && !String.IsNullOrEmpty(e.Data))
				CMessageList.MessageAdd(process.Id, e.Data);
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

		public void SetProgram(string program, string param)
		{
			Terminate();
			string path = AppDomain.CurrentDomain.BaseDirectory + program;
			if (File.Exists(path))
			{
				process = new Process();
				process.StartInfo.FileName = path;
				process.StartInfo.Arguments = param;
				process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.OutputDataReceived += ProEvent;
				process.Start();
				process.BeginOutputReadLine();
				SetPriority(FormOptions.priority);
			}
		}

		public void Terminate()
		{
			try
			{
				if (process != null)
				{
					process.Kill();
					process = null;
				}
			}
			catch
			{
			}
		}

	}
}
