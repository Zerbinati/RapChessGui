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
	public partial class FormHisE : Form
	{
		public static FormHisE This;
		Series lastSeries = null;

		public FormHisE()
		{
			InitializeComponent();
			This = this;
		}

		private void FormHisE_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

		private void FormHisE_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible == true)
			{
				chart1.Series.Clear();
				FormChess.engineList.Sort();
				foreach (CEngine engine in FormChess.engineList.list)
					if (engine.tournament)
					{
						string en = engine.name;
						chart1.Series.Add(en);
						chart1.Series[en].ChartType = SeriesChartType.Line;
						chart1.Series[en].BorderWidth = 2;
						CData.HisToPoints(engine.hisElo, chart1.Series[en].Points);
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
