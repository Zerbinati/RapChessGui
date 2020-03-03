using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormBook : Form
	{
		public static FormBook This;
		string curBookName;

		public FormBook()
		{
			This = this;
			InitializeComponent();
		}

		public void SelectReader()
		{
			SelectReader(curBookName);
		}

		void SelectReader(string name)
		{
			CBook reader = CBookList.GetBook(name);
			if (reader == null)
				return;
			tbReaderName.Text = reader.name;
			cbBookReaderList.Text = reader.file;
			tbParameters.Text = reader.parameters;
			curBookName = reader.name;
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach (CBook br in CBookList.list)
				listBox1.Items.Add(br.name);
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectReader(listBox1.SelectedItem.ToString());
		}

		void SaveToIni(CBook reader)
		{
			reader.name = tbReaderName.Text;
			reader.file = cbBookReaderList.Text;
			reader.parameters = tbParameters.Text;
			reader.SaveToIni();
			curBookName = reader.name;
			UpdateListBox();
			int index = listBox1.FindString(reader.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			CBook reader = CBookList.GetBook(curBookName);
			if (reader == null)
				return;
			CRapIni.This.DeleteKey($"book>{reader.name}");
			SaveToIni(reader);
			MessageBox.Show($"Reader {reader.name} has been modified");
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbReaderName.Text;
			CBook reader = new CBook(name);
			reader.file = cbBookReaderList.Text;
			CBookList.list.Add(reader);
			SaveToIni(reader);
			MessageBox.Show($"Book reader {reader.name} has been created");
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string userName = tbReaderName.Text;
			CPlayerList.DeletePlayer(userName);
			UpdateListBox();
			MessageBox.Show($"Player {userName} has been removed");
		}

		private void FormBook_Shown(object sender, EventArgs e)
		{
			foreach (string book in CData.fileBook)
				cbBookReaderList.Items.Add(book);
			UpdateListBox();
			if (listBox1.Items.Count > 0)
				listBox1.SetSelected(0, true);
		}
	}
}
