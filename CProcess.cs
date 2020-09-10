using System;
using System.IO;
using System.Diagnostics;
using System.Management;
using RapLog;

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
			if (!String.IsNullOrEmpty(e.Data))
				CMessageList.MessageAdd(process.Id, e.Data);
		}

		public void SetProgram(string program, string param)
		{
			Terminate();
			string path = AppDomain.CurrentDomain.BaseDirectory + program;
			if (!File.Exists(path))
				throw new ArgumentException("Missing file ", program);
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
