using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormOptions : Form
	{
		public static bool autoElo = true;
		public static bool isSan = true;
		public static bool showArrow = true;
		public static bool showAttack = false;
		public static bool showPonder = true;
		public static bool showTips = true;
		public static bool spamOff = true;
		public static bool soundOn = true;
		public static int animationSpeed = 200;
		public static int fontSize = 10;
		public static int gameBreak = 8;
		public static int historyLength = 100;
		public static int marginStandard = 0;
		public static int marginTime = 5000;
		public static int winLimit = 1;
		public static string tourBSelected = "None";
		public static string tourESelected = "None";
		public static string tourPSelected = "None";
		public static ProcessPriorityClass priority = ProcessPriorityClass.Normal;
		public static Color colorBoard;

		public FormOptions()
		{
			InitializeComponent();
			LoadFromIni();
			listBox1.SelectedIndex = 0;
		}

		public void LoadFromIni()
		{
			tourBSelected = FormChess.iniFile.Read("options>mode>tourB>Selected", tourBSelected);
			tourESelected = FormChess.iniFile.Read("options>mode>tourE>Selected", tourESelected);
			tourPSelected = FormChess.iniFile.Read("options>mode>tourP>Selected", tourPSelected);
			colorDialog1.Color = FormChess.iniFile.ReadColor("options>interface>color", Color.Yellow);
			rbSan.Checked = FormChess.iniFile.ReadBool("options>interface>san", rbSan.Checked);
			cbShowPonder.Checked = FormChess.iniFile.ReadBool("options>interface>showponder", cbShowPonder.Checked);
			cbRotateBoard.Checked = FormChess.iniFile.ReadBool("options>interface>rotate", cbRotateBoard.Checked);
			cbAttack.Checked = FormChess.iniFile.ReadBool("options>interface>attack", cbAttack.Checked);
			cbArrow.Checked = FormChess.iniFile.ReadBool("options>interface>arrow", cbArrow.Checked);
			cbTips.Checked = FormChess.iniFile.ReadBool("options>interface>tips", cbTips.Checked);
			cbSound.Checked = FormChess.iniFile.ReadBool("options>interface>sound", cbSound.Checked);
			cbSpam.Checked = FormChess.iniFile.ReadBool("options>interface>spam", cbSpam.Checked);
			nudBreak.Value = FormChess.iniFile.ReadDecimal("options>mode>game>brak", nudBreak.Value);
			nudTraining.Value = FormChess.iniFile.ReadDecimal("options>mode>training>strength", nudTraining.Value);
			nudHistory.Value = FormChess.iniFile.ReadDecimal("options>interface>history", nudHistory.Value);
			nudSpeed.Value = FormChess.iniFile.ReadDecimal("options>interface>speed", nudSpeed.Value);
			nudFontSize.Value = FormChess.iniFile.ReadDecimal("options>interface>font", nudFontSize.Value);
			cbGameAutoElo.Checked = FormChess.iniFile.ReadBool("options>game>autoelo", cbGameAutoElo.Checked);
			combModeStandard.SelectedIndex = FormChess.iniFile.ReadInt("options>margin>standard", 1);
			combModeTime.SelectedIndex = FormChess.iniFile.ReadInt("options>margin>time", 0);
			combPriority.SelectedIndex = FormChess.iniFile.ReadInt("options>priority", 2);
			colorBoard = colorDialog1.Color;
			if(!rbSan.Checked)
				rbUci.Checked = true;
		}

		public void SaveToIni()
		{
			FormChess.iniFile.Write("options>mode>tourB>Selected", tourBSelected);
			FormChess.iniFile.Write("options>mode>tourE>Selected", tourESelected);
			FormChess.iniFile.Write("options>mode>tourP>Selected", tourPSelected);
			FormChess.iniFile.Write("options>interface>color", colorDialog1.Color);
			FormChess.iniFile.Write("options>interface>san", rbSan.Checked);
			FormChess.iniFile.Write("options>interface>showponder", cbShowPonder.Checked);
			FormChess.iniFile.Write("options>interface>rotate", cbRotateBoard.Checked);
			FormChess.iniFile.Write("options>interface>attack", cbAttack.Checked);
			FormChess.iniFile.Write("options>interface>arrow", cbArrow.Checked);
			FormChess.iniFile.Write("options>interface>tips", cbTips.Checked);
			FormChess.iniFile.Write("options>interface>sound", cbSound.Checked);
			FormChess.iniFile.Write("options>interface>spam", cbSpam.Checked);
			FormChess.iniFile.Write("options>mode>game>brak", nudBreak.Value);
			FormChess.iniFile.Write("options>mode>training>strength", nudTraining.Value);
			FormChess.iniFile.Write("options>interface>history", nudHistory.Value);
			FormChess.iniFile.Write("options>interface>speed", nudSpeed.Value);
			FormChess.iniFile.Write("options>interface>font", nudFontSize.Value);
			FormChess.iniFile.Write("options>game>autoelo", cbGameAutoElo.Checked);
			FormChess.iniFile.Write("options>margin>standard", combModeStandard.SelectedIndex);
			FormChess.iniFile.Write("options>margin>time", combModeTime.SelectedIndex);
			FormChess.iniFile.Write("options>priority", combPriority.SelectedIndex);
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
			cbBookReader.Items.Add("None");
			foreach (string book in CData.fileBook)
				cbBookReader.Items.Add(book);
			cbBookReader.SelectedIndex = 0;

			cbTourBSelected.Items.Clear();
			cbTourBSelected.Sorted = true;
			foreach (CBook b in FormChess.bookList.list)
				cbTourBSelected.Items.Add(b.name);
			cbTourBSelected.Sorted = false;
			cbTourBSelected.Items.Insert(0,"None");
			cbTourBSelected.SelectedIndex = 0;

			cbTourESelected.Items.Clear();
			cbTourESelected.Sorted = true;
			foreach (CEngine e in FormChess.engineList.list)
				cbTourESelected.Items.Add(e.name);
			cbTourESelected.Sorted = false;
			cbTourESelected.Items.Insert(0,"None");
			cbTourESelected.SelectedIndex = 0;

			cbTourPSelected.Items.Clear();
			cbTourPSelected.Sorted = true;
			foreach (CPlayer p in FormChess.playerList.list)
				cbTourPSelected.Items.Add(p.name);
			cbTourPSelected.Sorted = false;
			cbTourPSelected.Items.Insert(0,"None");
			cbTourPSelected.SelectedIndex = 0;

			LoadFromIni();

			CData.ComboSelect(cbTourBSelected,tourBSelected);
			CData.ComboSelect(cbTourESelected, tourESelected);
			CData.ComboSelect(cbTourPSelected, tourPSelected);
			nudTourBRec.Value = CModeTournamentB.records;
			nudTourBMax.Value = CModeTournamentB.maxElo;
			nudTourBMin.Value = CModeTournamentB.minElo;
			nudTourERec.Value = CModeTournamentE.records;
			nudTourEMax.Value = CModeTournamentE.maxElo;
			nudTourEMin.Value = CModeTournamentE.minElo;
			nudTourPRec.Value = CModeTournamentP.records;
			nudTourPMax.Value = CModeTournamentP.maxElo;
			nudTourPMin.Value = CModeTournamentP.minElo;
			labTourB.Text = $"Fill {(CModeTournamentB.tourList.list.Count * 100) / CModeTournamentB.records}%";
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
			CModeTournamentB.records = (int)nudTourBRec.Value;
			CModeTournamentB.maxElo = (int)Math.Max(nudTourBMin.Value, nudTourBMax.Value);
			CModeTournamentB.minElo = (int)Math.Min(nudTourBMin.Value, nudTourBMax.Value);
			CModeTournamentE.records = (int)nudTourERec.Value;
			CModeTournamentE.maxElo = (int)Math.Max(nudTourEMin.Value, nudTourEMax.Value);
			CModeTournamentE.minElo = (int)Math.Min(nudTourEMin.Value, nudTourEMax.Value);
			CModeTournamentP.records = (int)nudTourPRec.Value;
			CModeTournamentP.maxElo = (int)Math.Max(nudTourPMin.Value, nudTourPMax.Value);
			CModeTournamentP.minElo = (int)Math.Min(nudTourPMin.Value, nudTourPMax.Value);
			CModeTournamentB.SaveToIni();
			CModeTournamentE.SaveToIni();
			CModeTournamentP.SaveToIni();
			SaveToIni();
		}

		public static void SetFontSize(Form form)
		{
			foreach (Control ctrl in form.Controls)
				ctrl.Font = new Font(ctrl.Font.Name,fontSize, ctrl.Font.Style, ctrl.Font.Unit);
		}

		int CbToMargin(int i)
		{
			return new int[] { -1, 0, 1000, 2000, 5000,10000 }[i];
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
				colorBoard = colorDialog1.Color;
				(Owner as FormChess).BoardPrepare();
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
			nudTourERec.Value = 10000;
			nudTourPRec.Value = 10000;
			nudSpeed.Value = 200;
			nudTourEMax.Value = 3000;
			nudTourEMin.Value = 0;
			nudTourPMax.Value = 3000;
			nudTourPMin.Value = 0;
			nudHistory.Value = 100;
			colorDialog1.Color = Color.Yellow;
			colorBoard = colorDialog1.Color;
			(Owner as FormChess).BoardPrepare();
		}

		private void FormOptions_Shown(object sender, EventArgs e)
		{
			FormLoad();
		}

		private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (combPriority.Text)
			{
				case "Idle":
					priority = ProcessPriorityClass.Idle;
					break;
				case "Below normal":
					priority = ProcessPriorityClass.BelowNormal;
					break;
				case "Normal":
					priority = ProcessPriorityClass.Normal;
					break;
				case "Above normal":
					priority = ProcessPriorityClass.AboveNormal;
					break;
				case "High":
					priority = ProcessPriorityClass.High;
					break;
			}
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

		private void nudTraining_ValueChanged(object sender, EventArgs e)
		{
			winLimit = (int)nudTraining.Value;
		}

		private void rbSan_CheckedChanged(object sender, EventArgs e)
		{
			isSan = rbSan.Checked;
		}

		private void cbShowPonder_CheckedChanged(object sender, EventArgs e)
		{
			showPonder = cbShowPonder.Checked;
		}

		private void cbSpam_CheckedChanged(object sender, EventArgs e)
		{
			spamOff = cbSpam.Checked;
		}

		private void cbArrow_CheckedChanged(object sender, EventArgs e)
		{
			showArrow = cbArrow.Checked;
		}

		private void cbSound_CheckedChanged(object sender, EventArgs e)
		{
			soundOn = cbSound.Checked;
		}

		private void cbAttack_CheckedChanged(object sender, EventArgs e)
		{
			showAttack = cbAttack.Checked;
		}

		private void cbTips_CheckedChanged(object sender, EventArgs e)
		{
			showTips = cbTips.Checked;
		}

		private void nudSpeed_ValueChanged(object sender, EventArgs e)
		{
			animationSpeed = (int)nudSpeed.Value;
		}

		private void nudHistory_ValueChanged(object sender, EventArgs e)
		{
			historyLength = (int)nudHistory.Value;
		}

		private void cbGameAutoElo_CheckedChanged(object sender, EventArgs e)
		{
			autoElo = cbGameAutoElo.Checked;
		}

		private void nudMatch_ValueChanged(object sender, EventArgs e)
		{
			gameBreak = (int)nudBreak.Value;
		}

		private void combModeStandard_SelectedIndexChanged(object sender, EventArgs e)
		{
			marginStandard = CbToMargin(combModeStandard.SelectedIndex);
		}

		private void combModeTime_SelectedIndexChanged(object sender, EventArgs e)
		{
			marginTime = CbToMargin(combModeTime.SelectedIndex);
		}

		private void nudFontSize_ValueChanged(object sender, EventArgs e)
		{
			fontSize = (int)nudFontSize.Value;
		}

		private void cbTourESelected_SelectedIndexChanged(object sender, EventArgs e)
		{
			tourESelected = cbTourESelected.Text;
		}

		private void cbTourBSelected_SelectedIndexChanged(object sender, EventArgs e)
		{
			tourBSelected = cbTourBSelected.Text;
		}

		private void cbTourPSelected_SelectedIndexChanged(object sender, EventArgs e)
		{
			tourPSelected = cbTourPSelected.Text;
		}
	}
}
