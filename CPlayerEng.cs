using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	class CPlayerEng
	{
		public CReader Reader = new CReader();
		Process process = new Process();
		public StreamWriter streamWriter;

		public void Kill()
		{
			streamWriter.Close();
			process.Kill();
		}

		public void MakeMove()
		{
			if (!process.HasExited)
			{
				string position = CHistory.GetPosition();
				streamWriter.WriteLine(position);
				Console.WriteLine(position);
				streamWriter.WriteLine("go movetime 1");
			}
		}

		public void SetEngine(string eng, string arg)
		{
			process.StartInfo.FileName = eng;
			process.StartInfo.Arguments = arg;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.Start();
			streamWriter = process.StandardInput;
			Reader.SetStream(process.StandardOutput);
		}
	}
}
