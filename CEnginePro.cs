using System;
using System.IO;
using System.Diagnostics;
using System.Management;

namespace RapChessGui
{
	public class CEnginePro
	{
		public StreamWriter streamWriter;
		private Process process = null;
		private CPlayer player;

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

		private static void ProEvent(object sender, DataReceivedEventArgs e)
		{
			if (!String.IsNullOrEmpty(e.Data))
			{
			lock (CMessageList.list)
				{
					CMessageList.Add((sender as Process).Id, e.Data);
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
			CBookReader br = CBookReaderList.GetReader(player.user.book);
			string pathE = AppDomain.CurrentDomain.BaseDirectory + "Engines\\" + player.user.engine;
			string argsE = player.user.parameters;
			string pathB = "";
			string argsB = "";
			string pathPro = "";
			string argsPro = "";
			if (br != null)
			{
				pathB = AppDomain.CurrentDomain.BaseDirectory + "Books\\" + br.file;
				argsB = br.parameters;
				pathPro = pathB;
				argsPro = $"\"{pathE}\" \"{argsE}\" \"{argsB}\"";
			}
			else
			{
				pathPro = pathE;
				argsPro = argsE;
			}
			process = new Process();
			process.StartInfo.FileName = pathPro;
			process.StartInfo.Arguments = argsPro;
			process.StartInfo.WorkingDirectory = Path.GetDirectoryName(pathPro);
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
