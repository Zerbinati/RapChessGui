using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RapChessGui
{

	public partial class FormLog : Form
	{
		public static FormLog This;

		public FormLog()
		{
			This = this;
			InitializeComponent();
		}

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
			string fn = $"{FormChess.This.cbMainMode.Text} {DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}.rtf";
			richTextBox1.SaveFile(fn);
			MessageBox.Show($"File {fn} has been saved");
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.LinkText);
		}
	}
}
