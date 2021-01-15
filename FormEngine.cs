using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormEngine : Form
	{
		public static FormEngine This;
		int indexFirst = -1;
		int tournament = -1;
		CEngine engine = null;

		public FormEngine()
		{
			This = this;
			InitializeComponent();
		}

		void SelectEngine(){
			tbEngineName.Text = engine.name;
			tbParameters.Text = engine.parameters;
			cbFileList.Text = engine.GetFile();
			cbProtocol.Text = engine.protocol;
			cbModeStandard.Checked = engine.modeStandard;
			nudElo.Value = Convert.ToInt32(engine.elo);
			nudTournament.Value = engine.tournament;
			rtbOptions.Lines = engine.options.ToArray();
		}

		void SelectEngine(CEngine e)
		{
			engine = e;
			SelectEngine();
		}

		void SelectEngine(string name)
		{
			engine = FormChess.engineList.GetEngine(name);
			if (engine != null)
				SelectEngine(engine);
		}

		void SelectEngines(int first, int last, bool t)
		{
			int f = first < last ? first : last;
			int l = first < last ? last : first;
			bool r = false;
			for (int n = f; n <= l; n++)
			{
				var item = listBox1.Items[n];
				string name = item.ToString();
				CEngine eng = FormChess.engineList.GetEngine(name);
				if (eng.SetTournament(t))
					r = true;
			}
			if (r)
			{
				listBox1.Refresh();
				SelectEngine();
			}
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach (CEngine e in FormChess.engineList.list)
				listBox1.Items.Add(e.name);
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectEngine(listBox1.SelectedItem.ToString());
		}

		void SaveToIni(CEngine e)
		{
			e.name = tbEngineName.Text;
			e.file = cbFileList.Text;
			e.protocol = cbProtocol.Text;
			e.parameters = tbParameters.Text;
			e.modeStandard = cbModeStandard.Checked;
			e.elo = nudElo.Value.ToString();
			e.tournament = (int)nudTournament.Value;
			e.options = rtbOptions.Lines.Cast<String>().ToList();
			e.SaveToIni();
			UpdateListBox();
			int index = listBox1.FindString(e.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbEngineName.Text;
			CEngine engine = new CEngine(name);
			FormChess.engineList.list.Add(engine);
			SaveToIni(engine);
			MessageBox.Show($"Chess {engine.name} has been created");
			CData.reset = true;
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			if (engine == null)
				return;
			CRapIni.This.DeleteKey($"engine>{engine.name}");
			SaveToIni(engine);
			MessageBox.Show($"Chess {engine.name} has been modified");
			CData.reset = true;
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string engineName = tbEngineName.Text;
			FormChess.engineList.DeleteEngine(engineName);
			UpdateListBox();
			MessageBox.Show($"Chess {engineName} has been removed");
			CData.reset = true;
		}

		private void FormEngine_Shown(object sender, EventArgs e)
		{
			CData.UpdateFileEngine();
			cbFileList.Items.Clear();
			foreach (string engine in CData.fileEngine)
				cbFileList.Items.Add(engine);
			UpdateListBox();
			if (listBox1.Items.Count > 0)
				listBox1.SetSelected(0, true);
		}

		private void butClearHistory_Click(object sender, EventArgs e)
		{
			if (engine != null)
			{
				engine.hisElo.list.Clear();
				engine.SaveToIni();
				int count = CModeTournamentE.tourList.DeletePlayer(engine.name);
				MessageBox.Show($"{count} records have been deleted");
			}
		}

		private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;
			string name = listBox1.Items[e.Index].ToString();
			CEngine eng = FormChess.engineList.GetEngine(name);
			bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			Brush b = Brushes.Black;
			if (selected)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, CBoard.colorBrighter, CBoard.colorDark);
				b = Brushes.White;
			}
			else if (!eng.FileExists())
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.White, CBoard.colorRed);
				b = Brushes.White;
			}
			else if (eng.tournament > 0)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, CBoard.colorBrighter);
			}
			e.DrawBackground();
			e.Graphics.DrawString(name, e.Font, b, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}

		private void listBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				indexFirst = -1;
				tournament = -1;
				listBox1.Capture = true;
				int index = listBox1.IndexFromPoint(e.Location);
				if ((index >= 0) && (index < listBox1.Items.Count))
				{
					var item = listBox1.Items[index];
					string name = item.ToString();
					CEngine eng = FormChess.engineList.GetEngine(name);
					indexFirst = index;
					tournament = eng.tournament > 0 ? 0 : 1;
					if (eng.SetTournament(tournament == 1))
					{
						listBox1.Refresh();
						if (engine == eng)
							SelectEngine();
					}

				}
			}
		}

		private void listBox1_MouseUp(object sender, MouseEventArgs e)
		{
			tournament = -1;
			listBox1.Capture = false;
		}

		private void listBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int index = listBox1.IndexFromPoint(e.Location);
				if ((index >= 0) && (index < listBox1.Items.Count) && (tournament >= 0))
					SelectEngines(indexFirst, index, tournament > 0);
			}
		}
	}
}