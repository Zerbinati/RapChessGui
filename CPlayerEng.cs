using System;
using System.IO;
using System.Diagnostics;
using System.Management;

namespace RapChessGui
{
	public class CPlayerEng
	{
		public StreamWriter streamWriter;
		private Process process = null;
		private CPlayer player;

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
			catch (ArgumentException)
			{
			}
		}

		private static void ProEvent(object sender, DataReceivedEventArgs e)
		{
			if (!String.IsNullOrEmpty(e.Data))
			{
			lock (CData.messages)
				{
					CData.messages.Add(e.Data);
				}
			}
		}

		public void SetPlayer(CPlayer p)
		{
			player = p;
			SetEngine();
		}

		void SetEngine()
		{
			Terminate();
			if (!player.computer)
				return;
			process = new Process();
			process.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "Engines\\" + player.user.engine;
			process.StartInfo.Arguments = player.user.parameters;
			process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "Engines\\";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.OutputDataReceived += ProEvent;
			process.Start();
			streamWriter = process.StandardInput;
			process.BeginOutputReadLine();
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
				}
			}
			catch
			{
			}
		}

	}
}
