using System;
using System.Drawing;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormOptions : Form
	{
		public static FormOptions This;

		public FormOptions()
		{
			This = this;
			InitializeComponent();
			LoadFromIni();
		}

		public void LoadFromIni()
		{
			cbShowPonder.Checked = Convert.ToInt32(CRapIni.This.Read("options>interface>showponder", "1")) == 1;
			cbRotateBoard.Checked = Convert.ToInt32(CRapIni.This.Read("options>interface>rotate", "0")) == 1;
			cbAttack.Checked = Convert.ToInt32(CRapIni.This.Read("options>interface>attack", "0")) == 1;
			cbArrow.Checked = Convert.ToInt32(CRapIni.This.Read("options>interface>arrow", "0")) == 1;
			nudSpeed.Value = Convert.ToInt32(CRapIni.This.Read("options>interface>speed", "200"));
			CBoard.color = ColorTranslator.FromHtml(CRapIni.This.Read("options>interface>color", "#400000"));
			cbGameAutoElo.Checked = Convert.ToInt32(CRapIni.This.Read("options>game>autoelo", "1")) == 1;
			nudTournament.Value = Convert.ToInt32(CRapIni.This.Read("options>tournament>records", "10000"));
			CTourList.maxRecords = (int)nudTournament.Value;
			CBoard.showArrow = cbArrow.Checked;
		}

		public void SaveToIni()
		{
			CRapIni.This.Write("options>interface>showponder", cbShowPonder.Checked ? "1" : "0");
			CRapIni.This.Write("options>interface>rotate", cbRotateBoard.Checked ? "1" : "0");
			CRapIni.This.Write("options>interface>attack", cbAttack.Checked ? "1" : "0");
			CRapIni.This.Write("options>interface>arrow", cbArrow.Checked ? "1" : "0");
			CRapIni.This.Write("options>interface>speed", nudSpeed.Value.ToString());
			CRapIni.This.Write("options>interface>color", ColorTranslator.ToHtml(CBoard.color));
			CRapIni.This.Write("options>game>autoelo", cbGameAutoElo.Checked ? "1" : "0");
			CRapIni.This.Write("options>tournament>records", nudTournament.Value.ToString());
			CBoard.showArrow = cbArrow.Checked;
		}

		private void CbRotateBoard_CheckedChanged(object sender, EventArgs e)
		{
			CData.rotateBoard = cbRotateBoard.Checked;
			FormChess.This.RenderBoard();
		}

		private void butDefault_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = Color.FromArgb(64,8,8);
			cbShowPonder.Checked = true;
			cbArrow.Checked = false;
			CData.rotateBoard = cbRotateBoard.Checked = false;
			CBoard.color = colorDialog1.Color;
			CBoard.Prepare();
			FormChess.This.RenderBoard();
		}

		private void butColor_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = CBoard.color;
			if (colorDialog1.ShowDialog() != DialogResult.Cancel)
			{
				CBoard.color = colorDialog1.Color;
				CBoard.Prepare();
				FormChess.This.RenderBoard();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SaveToIni();
		}

		private void FormOptions_Shown(object sender, EventArgs e)
		{
			CModeTournament.SelectPlayer();
			labFill.Text = $"Fill {(CTourList.list.Count * 100)/CTourList.maxRecords}%";
		}

	}
}
