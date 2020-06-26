using System;
using System.Linq;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormEngine : Form
	{
		public static FormEngine This;
		string curEngineName;

		public FormEngine()
		{
			This = this;
			InitializeComponent();
		}

		void SelectEngine(string name)
		{
			CEngine e = FormChess.engineList.GetEngine(name);
			if (e == null)
				return;
			tbEngineName.Text = e.name;
			tbParameters.Text = e.parameters;
			cbFileList.Text = e.file;
			cbProtocol.Text = e.protocol;
			curEngineName = e.name;
			cbTournament.Checked = e.tournament;
			nudElo.Value = Convert.ToInt32(e.elo);
			rtbOptions.Lines = e.options.ToArray();
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach(CEngine e in FormChess.engineList.list)
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
			e.tournament = cbTournament.Checked;
			e.elo = nudElo.Value.ToString();
			e.eloOld = Convert.ToDouble(e.elo);
			e.options = rtbOptions.Lines.Cast<String>().ToList();
			e.SaveToIni();
			curEngineName = e.name;
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
			CEngine engine = FormChess.engineList.GetEngine(curEngineName);
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
			CEngine engine = FormChess.engineList.GetEngine(curEngineName);
			if (engine != null)
			{
				engine.hisElo.list.Clear();
				engine.SaveToIni();
				int count = CModeTournamentE.tourList.DeletePlayer(curEngineName);
				MessageBox.Show($"{count} records have been deleted");
			}
		}
	}
}
