using System;
using System.IO;
using System.Diagnostics;

namespace RapChessGui
{
	public class CPlayerEng
	{
		public StreamWriter streamWriter;
		private Process process = null;
		private CPlayer player;

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
			Terminate();
			player = p;
			SetEngine();
		}

		void SetEngine()
		{
			if(process != null)
				process.Dispose();
			process = null;
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
			if (process == null)
				return;
			try
			{
				process.Kill();
			}
			catch
			{
			}
		}

	}
}
