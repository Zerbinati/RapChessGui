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
		Series lastSeries = null;

		public FormHisP()
		{
			InitializeComponent();
			This = this;
		}

		private void FormHisP_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormHisP_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible == true)
			{
				chart1.Series.Clear();
				FormChess.playerList.Sort();
				foreach (CPlayer player in CModeTournamentP.playerList.list)
					{
						string pn = player.name;
						chart1.Series.Add(pn);
						chart1.Series[pn].ChartType = SeriesChartType.Line;
						chart1.Series[pn].BorderWidth = 2;
						CData.HisToPoints(player.hisElo, chart1.Series[pn].Points);
					}
			}
		}

		private void chart1_MouseDown(object sender, MouseEventArgs e)
		{
			if (lastSeries != null)
			{
				lastSeries.BorderWidth = 2;
				lastSeries = null;
			}
			Chart plot = sender as Chart;
			HitTestResult result = plot.HitTest(e.X, e.Y);
			if (result != null && result.Object != null && result.ChartElementType == ChartElementType.LegendItem)
			{
				string name = result.Series.Name;
				lastSeries = plot.Series[name];
				lastSeries.BorderWidth = 4;
			}
		}
	}
}
