using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormLib : Form
	{
		public static FormLib This;
		string curReaderName;

		public FormLib()
		{
			This = this;
			InitializeComponent();
			string[] filePaths = Directory.GetFiles("Books", "*.exe");
			for (int n = 0; n < filePaths.Length; n++)
			{
				string fn = Path.GetFileName(filePaths[n]);
				cbBookReaderList.Items.Add(fn);
				CData.bookReaderNames.Add(fn);
			}
			CBookReaderList.LoadFromIni();
			UpdateListBox();
			if(listBox1.Items.Count > 0)
			listBox1.SetSelected(0, true);
		}

		public void SelectReader()
		{
			SelectReader(curReaderName);
		}

		void SelectReader(string name)
		{
			CBookReader reader = CBookReaderList.GetReader(name);
			if (reader == null)
				return;
			tbReaderName.Text = reader.name;
			cbBookReaderList.Text = reader.file;
			tbParameters.Text = reader.parameters;
			curReaderName = reader.name;
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach(CBookReader br in CBookReaderList.list)
				listBox1.Items.Add(br.name);
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectReader(listBox1.SelectedItem.ToString());
		}

		void SaveToIni(CBookReader reader)
		{
			reader.name = tbReaderName.Text;
			reader.file = cbBookReaderList.Text;
			reader.parameters = tbParameters.Text;
			reader.SaveToIni();
			curReaderName = reader.name;
			UpdateListBox();
			int index = listBox1.FindString(reader.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			CBookReader reader = CBookReaderList.GetReader(curReaderName);
			if (reader == null)
				return;
			CRapIni.This.DeleteKey($"reader>{reader.name}");
			SaveToIni(reader);
			MessageBox.Show($"Reader {reader.name} has been modified");
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbReaderName.Text;
			CBookReader reader = new CBookReader(name);
			reader.file = cbBookReaderList.Text;
			CBookReaderList.list.Add(reader);
			SaveToIni(reader);
			MessageBox.Show($"Book reader {reader.name} has been created");
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string userName = tbReaderName.Text;
			CUserList.DeletePlayer(userName);
			UpdateListBox();
			MessageBox.Show($"Player {userName} has been removed");
		}
	}
}
