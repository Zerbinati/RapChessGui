using System;
using System.IO;
using System.Collections.Generic;
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
			CEngine engine = CEngineList.GetEngine(name);
			if (engine == null)
				return;
			tbEngineName.Text = engine.name;
			tbParameters.Text = engine.parameters;
			cbFileList.Text = engine.file;
			cbProtocol.Text = engine.protocol;
			curEngineName = engine.name;
			rtbOptions.Lines = engine.options.ToArray();
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach(CEngine e in CEngineList.list)
				listBox1.Items.Add(e.name);
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectEngine(listBox1.SelectedItem.ToString());
		}

		void SaveToIni(CEngine engine)
		{
			engine.name = tbEngineName.Text;
			engine.file = cbFileList.Text;
			engine.protocol = cbProtocol.Text;
			engine.parameters = tbParameters.Text;
			engine.options = rtbOptions.Lines.Cast<String>().ToList();
			engine.SaveToIni();
			curEngineName = engine.name;
			UpdateListBox();
			int index = listBox1.FindString(engine.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbEngineName.Text;
			CEngine engine = new CEngine(name);
			CEngineList.list.Add(engine);
			SaveToIni(engine);
			MessageBox.Show($"Chess {engine.name} has been created");
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			CEngine engine = CEngineList.GetEngine(curEngineName);
			if (engine == null)
				return;
			CRapIni.This.DeleteKey($"engine>{engine.name}");
			SaveToIni(engine);
			MessageBox.Show($"Chess {engine.name} has been modified");
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string engineName = tbEngineName.Text;
			CEngineList.DeleteEngine(engineName);
			UpdateListBox();
			MessageBox.Show($"Chess {engineName} has been removed");
		}

		private void FormEngine_Shown(object sender, EventArgs e)
		{
			foreach (string engine in CData.fileEngine)
				cbFileList.Items.Add(engine);
			UpdateListBox();
			if (listBox1.Items.Count > 0)
				listBox1.SetSelected(0, true);
		}
	}
}
