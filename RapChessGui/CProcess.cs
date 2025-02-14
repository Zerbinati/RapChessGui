﻿using System;
using System.IO;
using System.Diagnostics;

namespace RapChessGui
{

	public class CProcess
	{
		private readonly DataReceivedEventHandler dataR = null;
		public Process process = new Process();

		public CProcess(DataReceivedEventHandler drh)
		{
			dataR = drh;
		}

		public int GetPid()
		{
			if (process.StartInfo.FileName == String.Empty)
				return 0;
			return process.Id;
		}

		public int SetProgram(string path, string param = "")
		{
			Terminate();
			if (File.Exists(path))
			{
				process = new Process();
				process.StartInfo.FileName = path;
				process.StartInfo.Arguments = param;
				process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.UseShellExecute = false;
				process.OutputDataReceived += dataR;
				process.Start();
				process.BeginOutputReadLine();
				process.PriorityClass = FormOptions.priority;
				//process.StandardInput.AutoFlush = true;
				return process.Id;
			}
			return 0;
		}

		public void Restart()
		{
			SetProgram(process.StartInfo.FileName, process.StartInfo.Arguments);
		}

		public void Stop()
		{
			WriteLine("stop");
		}

		public void Quit()
		{
			WriteLine("quit");
		}

		public void Close()
		{
			if (process.StartInfo.FileName != String.Empty)
			{
				Quit();
				process.OutputDataReceived -= dataR;
				process.StartInfo.FileName = String.Empty;
			}
		}

		public void Terminate()
		{
			try
			{
				if (process.StartInfo.FileName != String.Empty)
				{
					process.OutputDataReceived -= dataR;
					process.Kill();
					process.StartInfo.FileName = String.Empty;
				}
			}
			catch { }
		}


		public async void WriteLineAsync(string c)
		{
			if (process.StartInfo.FileName != String.Empty)
			{
				await process.StandardInput.WriteLineAsync(c);
			}
		}

		public void WriteLine(string c)
		{
			if (process.StartInfo.FileName != String.Empty)
			{
				//process.StandardInput.WriteLine(c);
				//process.StandardInput.WriteLineAsync();
				//await process.StandardInput.WriteLineAsync(c);
				//process.StandardInput.FlushAsync();
				//process.StandardInput.
				process.StandardInput.WriteLine(c);
				//process.StandardInput.WriteLine();
				//process.StandardInput.Flush();
				System.Threading.Thread.Sleep(8);
			}
		}

	}
}
