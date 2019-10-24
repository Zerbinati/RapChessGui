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
	public partial class FormBook : Form
	{
		public static FormBook This;
		CBook book = new CBook();

		public FormBook()
		{
			InitializeComponent();
			This = this;
		}

		private void bSort_Click(object sender, EventArgs e)
		{
			book.Load(cbBookList.Text);
			book.Sort();
			MessageBox.Show("Book is sorted");
		}

		private void FormBook_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

	}
}
