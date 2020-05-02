using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormPgn : Form
	{
		public static FormPgn This;

		public FormPgn()
		{
			This = this;
			InitializeComponent();
		}

		private void FormPgn_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}
	}
}
