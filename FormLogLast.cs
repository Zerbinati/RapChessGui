using System;
using System.IO;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormLogLast : Form
	{

		public static FormLogLast This;

		public FormLogLast()
		{
			This = this;
			InitializeComponent();
		}

		private void FormLogLast_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormLogLast_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible == true)
			{
				string name = FormChess.This.cbMainMode.Text;
				string path = $"{name}.rtf";
				Text = $"Last {name}";
				if (File.Exists(path))
					richTextBox1.LoadFile(path);
				else
					richTextBox1.Clear();
			}
		}

		private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.LinkText);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fn = $"{FormChess.This.cbMainMode.Text} {DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")}.rtf";
			richTextBox1.SaveFile(fn);
			MessageBox.Show($"File {fn} has been saved");
		}
	}
}
