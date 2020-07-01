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
				string name = Assembly.GetExecutingAssembly().GetName().Name;
				string path = new FileInfo(name + ".log").FullName.ToString();
				if (File.Exists(path))
				{
					textBox1.Text = File.ReadAllText(path);
					textBox1.Select(0, 0);
				}
			}
		}
	}
}
