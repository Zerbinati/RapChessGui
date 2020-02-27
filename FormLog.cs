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

		private void FormLog_Shown(object sender, EventArgs e)
		{
		}

		private void butSend_Click(object sender, EventArgs e)
		{
			CPlayer p = CPlayerList.This.GetPlayer(cbPlayerList.Text);
			if (p != null)
	//p.SendMessage(tbMessage.Text);
			foreach(string c in rtbCommand.Lines)
				p.SendMessage(c);
		}
	}
}
