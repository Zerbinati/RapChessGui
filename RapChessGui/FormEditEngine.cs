using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormEditEngine : Form
	{
		public static FormEditEngine This;
		int indexFirst = -1;
		int tournament = -1;
		CEngine engine = null;
		public static CProcess process = null;
		readonly COptionList optionList = new COptionList();

		public FormEditEngine()
		{
			This = this;
			InitializeComponent();
			process = new CProcess(OnDataReceived);
		}

		public static void AddOption(string o)
		{
			if (o == "uciok")
				This.Uciok();
			else
				This.optionList.Add(o);
		}

		void ClickUpdate()
		{
			if (engine == null)
				return;
			FormChess.iniFile.DeleteKey($"engine>{engine.name}");
			SaveToIni(engine);
			MessageBox.Show($"Chess {engine.name} has been modified");
			CData.reset = true;
		}

		public void Uciok()
		{
			int y = 0;
			panOptions.Controls.Clear();
			optionList.Sort();
			for (int n = 0; n < optionList.list.Count; n++)
			{
				string oName = $"optionN{n}";
				string lName = $"optionN{n}";
				COption o = optionList.list[n];
				switch (o.type)
				{
					case "spin":
						var nud = new NumericUpDown();
						nud.Name = oName;
						nud.Minimum = Convert.ToInt32(o.min);
						nud.Maximum = Convert.ToInt32(o.max);
						nud.Value = Convert.ToInt32(engine.GetOption(o.name, o.def));
						nud.Location = new Point(3, y);
						nud.TextAlign = HorizontalAlignment.Right;
						panOptions.Controls.Add(nud);
						var lab = new Label();
						lab.Name = lName;
						lab.Text = o.name;
						lab.Location = new Point(128, y);
						panOptions.Controls.Add(lab);
						y += 24;
						break;
					case "check":
						var check = new CheckBox();
						check.Name = oName;
						check.Text = o.name;
						check.Checked = Convert.ToBoolean(engine.GetOption(o.name, o.def));
						check.Location = new Point(3, y);
						panOptions.Controls.Add(check);
						y += 24;
						break;
				}
			}
			process.Terminate();
		}

		delegate void DeleMessage(string message);

		readonly static DeleMessage deleMessage = new DeleMessage(NewMessage);

		private void OnDataReceived(object sender, DataReceivedEventArgs e)
		{
			try
			{
				if (!String.IsNullOrEmpty(e.Data))
				{
					Invoke(deleMessage, new object[] { e.Data.Trim() });
				}
			}
			catch { }
		}

		public static void NewMessage(string msg)
		{
			AddOption(msg);
		}

		void SelectEngine()
		{
			optionList.list.Clear();
			Uciok();
			tbEngineName.Text = engine.name;
			tbParameters.Text = engine.parameters;
			cbFileList.Text = engine.GetFile();
			cbProtocol.Text = CData.ProtocolToStr(engine.protocol);
			cbModeStandard.Checked = engine.modeStandard;
			nudElo.Value = Convert.ToInt32(engine.elo);
			nudTournament.Value = engine.tournament;
			if ((engine.protocol == CProtocol.uci) && engine.FileExists())
			{
				if (process.SetProgram($@"{AppDomain.CurrentDomain.BaseDirectory}Engines\{engine.file}", engine.parameters) > 0)
					process.WriteLine("uci");
			}
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
			gbEngines.Text = $"Engines {listBox1.Items.Count}";
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectEngine(listBox1.SelectedItem.ToString());
		}

		void SaveToIni(CEngine e)
		{
			e.name = tbEngineName.Text;
			e.file = cbFileList.Text;
			e.protocol = CData.StrToProtocol(cbProtocol.Text);
			e.parameters = tbParameters.Text;
			e.modeStandard = cbModeStandard.Checked;
			e.elo = nudElo.Value.ToString();
			e.tournament = (int)nudTournament.Value;
			e.options = GetOptions();
			e.SaveToIni();
			UpdateListBox();
			int index = listBox1.FindString(e.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		List<string> GetOptions()
		{
			List<string> list = new List<string>();
			for (int n = 0; n < optionList.list.Count; n++)
			{
				string oName = $"optionN{n}";
				var c = panOptions.Controls.Find(oName, false);
				if (c.Length == 0)
					continue;
				COption o = optionList.list[n];
				string value;
				switch (o.type)
				{
					case "spin":
						NumericUpDown nud = (c[0]) as NumericUpDown;
						value = nud.Value.ToString();
						if (o.def != value)
							list.Add($"name {o.name} value {value}");
						break;
					case "check":
						CheckBox check = (c[0]) as CheckBox;
						value = check.Checked ? "true" : "false";
						if (o.def != value)
							list.Add($"name {o.name} value {value}");
						break;
				}
			}
			return list;
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
			ClickUpdate();
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
			FormOptions.SetFontSize(this);
			CData.UpdateFileEngine();
			cbFileList.Items.Clear();
			foreach (string engine in CData.fileEngine)
				cbFileList.Items.Add(engine);
			foreach (string engine in CData.fileEngineUci)
				cbFileList.Items.Add($@"Uci\{engine}");
			foreach (string engine in CData.fileEngineWb)
				cbFileList.Items.Add($@"Winboard\{engine}");
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
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, CBoard.colorMessage, CBoard.colorChartD);
				b = Brushes.White;
			}
			else if (!eng.FileExists())
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.White, CBoard.colorRed);
				b = Brushes.White;
			}
			else if (eng.tournament > 0)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, CBoard.colorMessage);
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

		private void butReset_Click(object sender, EventArgs e)
		{
			engine.options.Clear();
			engine.SaveToIni();
			Uciok();
		}

		private void FormEngine_FormClosing(object sender, FormClosingEventArgs e)
		{
			process.Terminate();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			tbEngineName.Text = Path.GetFileNameWithoutExtension(engine.file);
		}
	}
}