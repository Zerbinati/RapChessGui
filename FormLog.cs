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

		private void FormLog_Leave(object sender, EventArgs e)
		{

		}
	}
}
