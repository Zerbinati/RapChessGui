using System.IO;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormLogGames : Form
	{
		public static FormLogGames This;

		public FormLogGames()
		{
			This = this;
			InitializeComponent();
			FormOptions.SetFontSize(this);
		}

		private void FormPgn_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormLogGames_VisibleChanged(object sender, System.EventArgs e)
		{
			if ((Visible == true) && (textBox1.Text == string.Empty))
			{
				string name = FormChess.mode;
				string path = $@"History/{name}.pgn";
				Text = $"Log {name}";
				if (File.Exists(path))
				{
					textBox1.Text = File.ReadAllText(path);
					textBox1.Select(0, 0);
				}
			}
		}
	}
}
