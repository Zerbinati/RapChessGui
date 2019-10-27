using System;
using System.Drawing;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormOptions : Form
	{
		public FormOptions()
		{
			InitializeComponent();
		}

		private void CbRotateBoard_CheckedChanged(object sender, EventArgs e)
		{
			CData.rotateBoard = cbRotateBoard.Checked;
			FormChess.This.RenderBoard();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = CBoard.color;
			if(colorDialog1.ShowDialog() != DialogResult.Cancel)
			{
				CBoard.color = colorDialog1.Color;
				CBoard.Prepare();
				FormChess.This.RenderBoard();
			}
		}

		private void butDefault_Click(object sender, EventArgs e)
		{
			colorDialog1.Color = Color.FromArgb(64,8,8);
			CData.rotateBoard = cbRotateBoard.Checked = false;
			CBoard.color = colorDialog1.Color;
			CBoard.Prepare();
			FormChess.This.RenderBoard();
		}
	}
}
