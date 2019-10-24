using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	public class CPlayerEng
	{
		public StreamWriter streamWriter;
		private Process process = new Process();
		private CPlayer player;

		private static void ProEvent(object sender, DataReceivedEventArgs e)
		{

			if (!String.IsNullOrEmpty(e.Data))
				lock (CData.messages)
				{
					CData.messages.Add(e.Data);
				}
		}

		public void SetPlayer(CPlayer p)
		{
			//process.CancelOutputRead();
			//process.Close();
			process.Dispose();
			player = p;
			SetEngine();
		}

		void SetEngine()
		{
			process = new Process();
			if (!player.computer)
				return;
			process.StartInfo.FileName = "Engines/" + player.user.engine;
			process.StartInfo.Arguments = player.user.parameters;
			process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "Engines";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.OutputDataReceived += ProEvent;
			process.Start();
			streamWriter = process.StandardInput;
			process.BeginOutputReadLine();
		}
	}
}
