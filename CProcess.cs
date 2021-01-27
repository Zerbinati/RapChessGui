using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace RapChessGui
{
	public class CProcess
	{
		public Process process = new Process();

		public int GetPid()
		{
			try
			{
				return process.Id;
			}
			catch { }
			return 0;
		}

		private void ProEvent(object sender, DataReceivedEventArgs e)
		{
			try
			{
				if (!String.IsNullOrEmpty(e.Data))
					CMessageList.MessageAdd(process.Id, e.Data);
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

		public void SetProgram(string path, string param)
		{
			Terminate();
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
			else
				MessageBox.Show($"Missing engine {path}");
		}

		public void Restart()
		{
			SetProgram(process.StartInfo.FileName,process.StartInfo.Arguments);
		}

		public void Terminate()
		{
			try
			{
				process.OutputDataReceived -= ProEvent;
				process.Kill();
			}
			catch { }
		}

	}
}
