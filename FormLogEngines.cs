using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RapChessGui
{

	public partial class FormLogEngines : Form
	{
		public static FormLogEngines This;
		static readonly Stopwatch timer = new Stopwatch();

		public FormLogEngines()
		{
			This = this;
			InitializeComponent();
			richTextBox1.AddContextMenu();
		}

		public static void AppendText(string txt,Color col)
		{
			This.richTextBox1.SelectionColor = col;
			This.richTextBox1.SelectedText = txt;
		}

		public static void AppendTime()
		{
			This.richTextBox1.SelectionColor = Color.Green;
			This.richTextBox1.SelectedText = GetTimeElapsed();
		}

		public void NewGame(CGamer gw,CGamer gb)
		{
			cbPlayerList.Items.Clear();
			richTextBox1.Clear();
			timer.Restart();
			AppendTime();
			AppendText($"Date {DateTime.Now:yyyy-MM-dd HH:mm}\n", Color.Gray);
			AppendTime();
			AppendText($"White {gw.player.name} {gw.player.engine}\n", Color.Gray);
			AppendTime();
			AppendText($"Black {gb.player.name} {gb.player.engine}\n", Color.Gray);
			if (gw.engine != null)
				cbPlayerList.Items.Add(gw.player.name);
			if (gb.engine != null)
				cbPlayerList.Items.Add(gb.player.name);
			if (cbPlayerList.Items.Count > 0)
				cbPlayerList.SelectedIndex = 0;
		}

		static string GetTimeElapsed()
		{
			DateTime dt = new DateTime();
			dt = dt.AddMilliseconds(timer.Elapsed.TotalMilliseconds);
			return dt.ToString("HH:mm:ss.fff ");
		}

		#region events

		private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void butSend_Click(object sender, EventArgs e)
		{
			CGamer p = CGamerList.This.GetGamer(cbPlayerList.Text);
			if (p != null)
				foreach (string c in rtbCommand.Lines)
					p.SendMessage(c);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fn = $"{FormChess.This.combMainMode.Text} {DateTime.Now:yyyy-MM-dd hh-mm-ss}.rtf";
			richTextBox1.SaveFile(fn);
			MessageBox.Show($"File {fn} has been saved");
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}

		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CGamer g = CGamerList.This.GetGamer(cbPlayerList.Text);
			if (g != null)
				g.EngineStop();
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CGamer g = CGamerList.This.GetGamer(cbPlayerList.Text);
			if (g != null)
				g.EngineReset();
		}

		private void terminateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CGamer g = CGamerList.This.GetGamer(cbPlayerList.Text);
			if (g != null)
				g.EngineTerminate() ;
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CGamer g = CGamerList.This.GetGamer(cbPlayerList.Text);
			if (g != null)
				g.EngineClose();
		}

		#endregion
	}

}
