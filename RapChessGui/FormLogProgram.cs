using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormLogProgram : Form
	{

		public static FormLogProgram This;

		public FormLogProgram()
		{
			This = this;
			InitializeComponent();
			FormOptions.SetFontSize(this);
		}

		private void FormLogProgram_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormLogProgram_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible == true)
			{
				string path = FormChess.log.path;
				if (File.Exists(path))
				{
					textBox1.Text = File.ReadAllText(path);
					textBox1.Select(0, 0);
				}
			}
		}
	}
}
