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

		public void SetPlayer(CPlayer p)
		{
			process.Dispose();
			player = p;
			SetEngine();
		}

		private void SetEngine()
		{
			if (!player.computer)
				return;
			process = new Process();
			process.StartInfo.FileName = "Engines/" + player.user.engine;
			process.StartInfo.Arguments = player.user.parameters;
			process.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "Engines";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.OutputDataReceived += new DataReceivedEventHandler(delegate (object sender, DataReceivedEventArgs e)
			{
				player.messages.Add(e.Data);
			});
			process.Start();
			process.BeginOutputReadLine();
			streamWriter = process.StandardInput;
		}
	}
}
