using System;
using System.IO;
using System.Diagnostics;
using System.Management;

namespace RapChessGui
{
	public class CProcess
	{
		private int pid;
		public Process process = null;

		public int GetPid()
		{
			if (process == null)
				return 0;
			return process.Id;
		}

		private void KillProcessAndChildren(int pid)
		{
			if (pid == 0)
			{
				return;
			}
			ManagementObjectSearcher searcher = new ManagementObjectSearcher
					("Select * From Win32_Process Where ParentProcessID=" + pid);
			ManagementObjectCollection moc = searcher.Get();
			foreach (ManagementObject mo in moc)
			{
				KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
			}
			try
			{
				Process proc = Process.GetProcessById(pid);
				proc.Kill();
			}
			catch
			{
			}
		}

		private void ProEvent(object sender, DataReceivedEventArgs e)
		{
			if (!String.IsNullOrEmpty(e.Data))
				CMessageList.MessageAdd(pid, e.Data);
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
			pid = process.Id;
		}

		public void Terminate()
		{
			try
			{
				if (process != null)
				{
					KillProcessAndChildren(process.Id);
					process.Dispose();
					process = null;
					pid = 0;
				}
			}
			catch
			{
			}
		}

	}
}
