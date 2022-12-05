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
	public partial class FormListE : Form
	{
		public FormListE()
		{
			InitializeComponent();
		}

		private void FormListE_VisibleChanged(object sender, EventArgs e)
		{
			lvEngines.Items.Clear();
			FormChess.engineList.SortElo();
			foreach (CEngine engine in FormChess.engineList)
			{
				ListViewItem lvi = new ListViewItem(new[] { engine.name, engine.elo,engine.hisElo.Change().ToString()});
				lvEngines.Items.Add(lvi);
			}
		}

		private void lvEngines_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView lv = sender as ListView;
			lv.Tag = lv.Tag == null ? new Object() : null;
			(sender as ListView).ListViewItemSorter = new ListViewComparer(e.Column, lv.Tag == null ? SortOrder.Ascending : SortOrder.Descending);
		}
	}
}
