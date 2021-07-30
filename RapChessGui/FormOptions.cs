using System;
using System.Drawing;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormOptions : Form
	{
		public static FormOptions This;
		public static int gameBreak = 8;
		public static int marginStandard = 0;
		public static int marginTime = 5000;
		public static string priority;
		public static Color colorBoard;

		public FormOptions()
		{
			This = this;
			InitializeComponent();
			LoadFromIni();
			listBox1.SelectedIndex = 0;
		}

		public void LoadFromIni()
		{
			colorDialog1.Color = CRapIni.This.ReadColor("options>interface>color", Color.Yellow);
			if (CRapIni.This.ReadBool("options>interface>san", true))
				rbSan.Checked = true;
			else
				rbUci.Checked = true;
			cbShowPonder.Checked = CRapIni.This.ReadBool("options>interface>showponder", cbShowPonder.Checked);
			cbRotateBoard.Checked = CRapIni.This.ReadBool("options>interface>rotate", cbRotateBoard.Checked);
			cbAttack.Checked = CRapIni.This.ReadBool("options>interface>attack", cbAttack.Checked);
			cbArrow.Checked = CRapIni.This.ReadBool("options>interface>arrow", cbArrow.Checked);
			cbTips.Checked = CRapIni.This.ReadBool("options>interface>tips", cbTips.Checked);
			cbSound.Checked = CRapIni.This.ReadBool("options>interface>sound", cbSound.Checked);
			nudBreak.Value = CRapIni.This.ReadDecimal("options>mode>game>brak", nudBreak.Value);
			nudHistory.Value = CRapIni.This.ReadDecimal("options>interface>history", nudHistory.Value);
			nudSpeed.Value = CRapIni.This.ReadDecimal("options>interface>speed", nudSpeed.Value);
			cbGameAutoElo.Checked = CRapIni.This.ReadBool("options>game>autoelo", cbGameAutoElo.Checked);
			combModeStandard.SelectedIndex = CRapIni.This.ReadInt("options>margin>standard", 1);
			combModeTime.SelectedIndex = CRapIni.This.ReadInt("options>margin>time", 4);
			priority = CRapIni.This.Read("options>priority", "Normal");
			combPriority.SelectedIndex = combPriority.FindStringExact(priority);
			gameBreak = (int)nudBreak.Value;
			colorBoard = colorDialog1.Color;
			marginStandard = CbToMargin(combModeStandard.SelectedIndex);
			marginTime = CbToMargin(combModeTime.SelectedIndex);
			CHisElo.count = (int)nudHistory.Value;
		}

		public void SaveToIni()
		{
			CRapIni.This.Write("options>interface>color", colorDialog1.Color);
			CRapIni.This.Write("options>interface>san", rbSan.Checked);
			CRapIni.This.Write("options>interface>showponder", cbShowPonder.Checked);
			CRapIni.This.Write("options>interface>rotate", cbRotateBoard.Checked);
			CRapIni.This.Write("options>interface>attack", cbAttack.Checked);
			CRapIni.This.Write("options>interface>arrow", cbArrow.Checked);
			CRapIni.This.Write("options>interface>tips", cbTips.Checked);
			CRapIni.This.Write("options>interface>sound", cbSound.Checked);
			CRapIni.This.Write("options>mode>game>brak", nudBreak.Value);
			CRapIni.This.Write("options>interface>history", nudHistory.Value);
			CRapIni.This.Write("options>interface>speed", nudSpeed.Value);
			CRapIni.This.Write("options>game>autoelo", cbGameAutoElo.Checked);
			CRapIni.This.Write("options>margin>standard", combModeStandard.SelectedIndex);
			CRapIni.This.Write("options>margin>time", combModeTime.SelectedIndex);
			CRapIni.This.Write("options>priority", priority);
			gameBreak = (int)nudBreak.Value;
			colorBoard = colorDialog1.Color;
			marginStandard = CbToMargin(combModeStandard.SelectedIndex);
			marginTime = CbToMargin(combModeTime.SelectedIndex);
		}

		void FormLoad()
		{
			LoadFromIni();
			nudTourE.Value = CModeTournamentE.records;
			nudMaxEloE.Value = CModeTournamentE.maxElo;
			nudMinEloE.Value = CModeTournamentE.minElo;
			nudTourP.Value = CModeTournamentP.records;
			nudMaxEloP.Value = CModeTournamentP.maxElo;
			nudMinEloP.Value = CModeTournamentP.minElo;
			labTourE.Text = $"Fill {(CModeTournamentE.tourList.list.Count * 100) / CModeTournamentE.records}%";
			labTourP.Text = $"Fill {(CModeTournamentP.tourList.list.Count * 100) / CModeTournamentP.records}%";
		}

		void FormSave()
		{
			CModeTournamentE.records = (int)nudTourE.Value;
			CModeTournamentE.maxElo = (int)Math.Max(nudMinEloE.Value, nudMaxEloE.Value);
			CModeTournamentE.minElo = (int)Math.Min(nudMinEloE.Value, nudMaxEloE.Value);
			CModeTournamentP.records = (int)nudTourP.Value;
			CModeTournamentP.maxElo = (int)Math.Max(nudMinEloP.Value, nudMaxEloP.Value);
			CModeTournamentP.minElo = (int)Math.Min(nudMinEloP.Value, nudMaxEloP.Value);
			CModeTournamentE.SaveToIni();
			CModeTournamentP.SaveToIni();
			SaveToIni();
		}

		int CbToMargin(int i)
		{
			return new int[5] { -1, 0, 1000, 2000, 5000 }[i];
		}

		public static bool ShowTips()
		{
			return This.cbTips.Checked;
		}

		private void CbRotateBoard_CheckedChanged(object sender, EventArgs e)
		{
			CData.rotateBoard = cbRotateBoard.Checked;
			FormChess.This.RenderBoard();
		}

		private void butColor_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = colorBoard;
			if (colorDialog1.ShowDialog() != DialogResult.Cancel)
			{
				CBoard.SetColor(colorDialog1.Color);
				FormChess.This.SetColor();
				FormChess.This.BoardPrepare();
			}
		}

		private void butDefault_Click(object sender, EventArgs e)
		{
			cbShowPonder.Checked = true;
			cbAttack.Checked = false;
			cbArrow.Checked = true;
			cbTips.Checked = true;
			cbGameAutoElo.Checked = true;
			cbRotateBoard.Checked = false;
			rbSan.Checked = true;
			combModeStandard.SelectedIndex = 1;
			combModeTime.SelectedIndex = 2;
			combPriority.SelectedIndex = 2;
			nudTourE.Value = 10000;
			nudTourP.Value = 10000;
			nudSpeed.Value = 200;
			nudMaxEloE.Value = 3000;
			nudMinEloE.Value = 0;
			nudMaxEloP.Value = 3000;
			nudMinEloP.Value = 0;
			nudHistory.Value = 100;
			CBoard.SetColor(CBoard.colorDefault);
			colorDialog1.Color = CBoard.colorDefault;
			FormChess.This.BackColor = CBoard.colorChartD;
			FormChess.This.BoardPrepare();
		}

		private void FormOptions_Shown(object sender, EventArgs e)
		{
			FormLoad();
		}

		private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
		{
			priority = combPriority.Text;
		}

		private void FormOptions_FormClosing(object sender, FormClosingEventArgs e)
		{
			FormSave();
		}

		private void listBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			tabControl1.SelectedIndex = listBox1.SelectedIndex;
		}
	}
}
