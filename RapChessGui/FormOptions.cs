using System;
using System.Drawing;
using System.Windows.Forms;

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
			colorDialog1.Color = FormChess.RapIni.ReadColor("options>interface>color", Color.Yellow);
			if (FormChess.RapIni.ReadBool("options>interface>san", true))
				rbSan.Checked = true;
			else
				rbUci.Checked = true;
			cbShowPonder.Checked = FormChess.RapIni.ReadBool("options>interface>showponder", cbShowPonder.Checked);
			cbRotateBoard.Checked = FormChess.RapIni.ReadBool("options>interface>rotate", cbRotateBoard.Checked);
			cbAttack.Checked = FormChess.RapIni.ReadBool("options>interface>attack", cbAttack.Checked);
			cbArrow.Checked = FormChess.RapIni.ReadBool("options>interface>arrow", cbArrow.Checked);
			cbTips.Checked = FormChess.RapIni.ReadBool("options>interface>tips", cbTips.Checked);
			cbSound.Checked = FormChess.RapIni.ReadBool("options>interface>sound", cbSound.Checked);
			nudBreak.Value = FormChess.RapIni.ReadDecimal("options>mode>game>brak", nudBreak.Value);
			nudHistory.Value = FormChess.RapIni.ReadDecimal("options>interface>history", nudHistory.Value);
			nudSpeed.Value = FormChess.RapIni.ReadDecimal("options>interface>speed", nudSpeed.Value);
			cbGameAutoElo.Checked = FormChess.RapIni.ReadBool("options>game>autoelo", cbGameAutoElo.Checked);
			combModeStandard.SelectedIndex = FormChess.RapIni.ReadInt("options>margin>standard", 1);
			combModeTime.SelectedIndex = FormChess.RapIni.ReadInt("options>margin>time", 0);
			priority = FormChess.RapIni.Read("options>priority", "Normal");
			combPriority.SelectedIndex = combPriority.FindStringExact(priority);
			gameBreak = (int)nudBreak.Value;
			colorBoard = colorDialog1.Color;
			marginStandard = CbToMargin(combModeStandard.SelectedIndex);
			marginTime = CbToMargin(combModeTime.SelectedIndex);
			CHisElo.count = (int)nudHistory.Value;
		}

		public void SaveToIni()
		{
			FormChess.RapIni.Write("options>interface>color", colorDialog1.Color);
			FormChess.RapIni.Write("options>interface>san", rbSan.Checked);
			FormChess.RapIni.Write("options>interface>showponder", cbShowPonder.Checked);
			FormChess.RapIni.Write("options>interface>rotate", cbRotateBoard.Checked);
			FormChess.RapIni.Write("options>interface>attack", cbAttack.Checked);
			FormChess.RapIni.Write("options>interface>arrow", cbArrow.Checked);
			FormChess.RapIni.Write("options>interface>tips", cbTips.Checked);
			FormChess.RapIni.Write("options>interface>sound", cbSound.Checked);
			FormChess.RapIni.Write("options>mode>game>brak", nudBreak.Value);
			FormChess.RapIni.Write("options>interface>history", nudHistory.Value);
			FormChess.RapIni.Write("options>interface>speed", nudSpeed.Value);
			FormChess.RapIni.Write("options>game>autoelo", cbGameAutoElo.Checked);
			FormChess.RapIni.Write("options>margin>standard", combModeStandard.SelectedIndex);
			FormChess.RapIni.Write("options>margin>time", combModeTime.SelectedIndex);
			FormChess.RapIni.Write("options>priority", priority);
			gameBreak = (int)nudBreak.Value;
			colorBoard = colorDialog1.Color;
			marginStandard = CbToMargin(combModeStandard.SelectedIndex);
			marginTime = CbToMargin(combModeTime.SelectedIndex);
			CHisElo.count = (int)nudHistory.Value;
		}

		void FormLoad()
		{
			lvBooks.Items.Clear();
			FormChess.DirBookList.LoadFromIni();
			foreach (CDirBook db in FormChess.DirBookList)
			{
				ListViewItem lvi = new ListViewItem(new[] { db.dir, db.book });
				lvBooks.Items.Add(lvi);
			}
			cbBookReader.Items.Clear();
			cbBookReader.Items.Add("none");
			foreach (string book in CData.fileBook)
				cbBookReader.Items.Add(book);
			cbBookReader.SelectedIndex = 0;
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
			FormChess.DirBookList.Clear();
			foreach (ListViewItem lvi in lvBooks.Items)
			{
				CDirBook db = new CDirBook();
				db.dir = lvi.SubItems[0].Text;
				db.book = lvi.SubItems[1].Text;
				FormChess.DirBookList.Add(db);
			}
			FormChess.DirBookList.SaveToIni();
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
			return new int[] { -1, 0, 1000, 2000, 5000,10000 }[i];
		}

		public static bool ShowTips()
		{
			return This.cbTips.Checked;
		}

		private void CbRotateBoard_CheckedChanged(object sender, EventArgs e)
		{
			CData.rotateBoard = cbRotateBoard.Checked;
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
			combModeTime.SelectedIndex = 0;
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

		private void cbBookReader_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvBooks.SelectedItems.Count > 0)
			{
				lvBooks.SelectedItems[0].SubItems[1].Text = cbBookReader.Text;
				CData.reset = true;
			}
		}

		private void lvBooks_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvBooks.SelectedItems.Count > 0)
				cbBookReader.Text = lvBooks.SelectedItems[0].SubItems[1].Text;
		}
	}
}
