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
	public partial class FormPgn : Form
	{
		public static FormPgn This;

		public FormPgn()
		{
			This = this;
			InitializeComponent();
		}
	}
}
