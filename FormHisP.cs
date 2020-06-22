using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace RapChessGui
{
	public partial class FormHisP : Form
	{
		public static FormHisP This;

		public FormHisP()
		{
			InitializeComponent();
			This = this;
		}

		private void FormHisP_Shown(object sender, EventArgs e)
		{
			chart1.Series.Clear();
			CData.playerList.Sort();
			foreach (CPlayer player in CData.playerList.list)
				if (player.tournament)
				{
					string pn = $"{player.name} ({player.elo})";
					chart1.Series.Add(pn);
					chart1.Series[pn].ChartType = SeriesChartType.Line;
					chart1.Series[pn].BorderWidth = 2;
					CData.HisToPoints(player.hisElo, chart1.Series[pn].Points);
				}
		}

		private void FormHisP_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}
	}
}
