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

		public FormHisE()
		{
			InitializeComponent();
			This = this;
		}

		private void FormHisE_Shown(object sender, EventArgs e)
		{
			chart1.Series.Clear();
			CData.engineList.Sort();
			foreach (CEngine engine in CData.engineList.list)
				if (engine.tournament)
				{
					string en = $"{engine.name} ({engine.elo}) {engine.hisElo.Last()}";
					chart1.Series.Add(en);
					chart1.Series[en].ChartType = SeriesChartType.Line;
					chart1.Series[en].BorderWidth = 2;
					CData.HisToPoints(engine.hisElo, chart1.Series[en].Points);
				}
		}

		private void FormHisE_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				Hide();
				e.Cancel = true;
			}
		}

	}
}
