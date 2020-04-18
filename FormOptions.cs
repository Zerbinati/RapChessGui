using System;
using System.Drawing;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormOptions : Form
	{
		public static FormOptions This;
		public static int marginStandard = 0;
		public static int marginTime = 5000;

		public FormOptions()
		{
			This = this;
			InitializeComponent();
			LoadFromIni();
		}

		public void LoadFromIni()
		{
			cbShowPonder.Checked = CRapIni.This.ReadBool("options>interface>showponder", cbShowPonder.Checked);
			cbRotateBoard.Checked = CRapIni.This.ReadBool("options>interface>rotate", cbRotateBoard.Checked);
			cbAttack.Checked = CRapIni.This.ReadBool("options>interface>attack", cbAttack.Checked);
			cbArrow.Checked = CRapIni.This.ReadBool("options>interface>arrow", cbArrow.Checked);
			cbTips.Checked = CRapIni.This.ReadBool("options>interface>tips", cbTips.Checked);
			nudSpeed.Value = CRapIni.This.ReadInt("options>interface>speed", 200);
			CBoard.color = ColorTranslator.FromHtml(CRapIni.This.Read("options>interface>color", "#400000"));
			cbGameAutoElo.Checked = CRapIni.This.ReadBool("options>game>autoelo");
			nudTourE.Value = CRapIni.This.ReadInt("options>tournamentE>records",10000);
			nudTourP.Value = CRapIni.This.ReadInt("options>tournamentP>records", 10000);
			cbModeStandard.SelectedIndex = CRapIni.This.ReadInt("options>margin>standard", 1);
			cbModeTime.SelectedIndex = CRapIni.This.ReadInt("options>margin>time", 4);
			CModeTournamentE.tourList.maxRecords = (int)nudTourE.Value;
			CModeTournamentP.tourList.maxRecords = (int)nudTourP.Value;
			CBoard.showArrow = cbArrow.Checked;
			marginStandard = CbToMargin(cbModeStandard.SelectedIndex);
			marginTime = CbToMargin(cbModeTime.SelectedIndex);
		}

		public void SaveToIni()
		{
			CRapIni.This.Write("options>interface>showponder", cbShowPonder.Checked);
			CRapIni.This.Write("options>interface>rotate", cbRotateBoard.Checked);
			CRapIni.This.Write("options>interface>attack", cbAttack.Checked);
			CRapIni.This.Write("options>interface>arrow", cbArrow.Checked);
			CRapIni.This.Write("options>interface>tips", cbTips.Checked);
			CRapIni.This.Write("options>interface>speed", nudSpeed.Value);
			CRapIni.This.Write("options>interface>color", ColorTranslator.ToHtml(CBoard.color));
			CRapIni.This.Write("options>game>autoelo", cbGameAutoElo.Checked);
			CRapIni.This.Write("options>tournamentE>records", nudTourE.Value);
			CRapIni.This.Write("options>tournamentP>records", nudTourP.Value);
			CRapIni.This.Write("options>margin>standard", cbModeStandard.SelectedIndex);
			CRapIni.This.Write("options>margin>time", cbModeTime.SelectedIndex);
			CModeTournamentE.tourList.maxRecords = (int)nudTourE.Value;
			CModeTournamentP.tourList.maxRecords = (int)nudTourP.Value;
			CBoard.showArrow = cbArrow.Checked;
			marginStandard = CbToMargin(cbModeStandard.SelectedIndex);
			marginTime = CbToMargin(cbModeTime.SelectedIndex);
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

		private void butDefault_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = Color.FromArgb(64, 8, 8);
			cbShowPonder.Checked = true;
			cbArrow.Checked = true;
			cbTips.Checked = true;
			CData.rotateBoard = cbRotateBoard.Checked = false;
			CBoard.color = colorDialog1.Color;
			FormChess.This.RenderBoard();
		}

		private void butColor_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = CBoard.color;
			if (colorDialog1.ShowDialog() != DialogResult.Cancel)
			{
				CBoard.color = colorDialog1.Color;
				FormChess.This.BoardPrepare();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SaveToIni();
		}

		private void FormOptions_Shown(object sender, EventArgs e)
		{
			CModeTournamentE.SelectEngine();
			CModeTournamentP.SelectPlayer();
			labTourE.Text = $"Fill {(CModeTournamentE.tourList.list.Count * 100) / CModeTournamentE.tourList.maxRecords}%";
			labTourP.Text = $"Fill {(CModeTournamentP.tourList.list.Count * 100) / CModeTournamentP.tourList.maxRecords}%";
		}

	}
}
