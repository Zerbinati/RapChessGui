using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormPlayer : Form
	{
		public static FormPlayer This;
		string curUserName;

		public FormPlayer()
		{
			This = this;
			InitializeComponent();
			string[] filePaths = Directory.GetFiles("Engines", "*.exe");
			for (int n = 0; n < filePaths.Length; n++)
			{
				string fn = Path.GetFileName(filePaths[n]);
				cbEngList.Items.Add(fn);
				CData.engineNames.Add(fn);
			}
			string[] arrBooks = Directory.GetFiles("Books", "*.txt");
			for (int n = 0; n < arrBooks.Length; n++)
			{
				string fn = Path.GetFileName(arrBooks[n]);
				CData.bookNames.Add(fn);
			}
			CUserList.LoadFromIni();
			UpdateListBox();
			listBox1.SetSelected(0, true);
			cbProtocol.SelectedIndex = 0;
		}

		void SelectUser(string name)
		{
			var user = CUserList.GetUser(name);
			if (user == null)
				return;
			tbUserName.Text = user.name;
			tbParameters.Text = user.parameters;
			cbEngList.Text = user.engine;
			cbProtocol.Text = user.protocol;
			cbBookList.Text = user.book;
			curUserName = user.name;
			nudElo.Value = Int32.Parse(user.elo);
			switch (user.mode)
			{
				case "movetime":
					nudTime.Value = Int32.Parse(user.value);
					break;
				case "depth":
					nudDepth.Value = Int32.Parse(user.value);
					break;
			}
			List<RadioButton> list = gbMode.Controls.OfType<RadioButton>().ToList();
			list[CData.ModeStoi(user.mode)].Select();
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			for (int n = 0; n < CUserList.list.Count; n++)
				listBox1.Items.Add(CUserList.list[n].name);
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectUser(listBox1.SelectedItem.ToString());
		}

		void SaveToIni(CUser user)
		{
			user.name = tbUserName.Text;
			user.engine = cbEngList.Text;
			user.protocol = cbProtocol.Text;
			user.book = cbBookList.Text;
			user.parameters = tbParameters.Text;
			user.elo = nudElo.Value.ToString();
			curUserName = user.name;
			var checkedButton = gbMode.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			List<RadioButton> list = gbMode.Controls.OfType<RadioButton>().ToList();
			int mode = list.IndexOf(checkedButton);
			user.mode = list[mode].Text;
			switch (mode)
			{
				case 1:
					user.mode = "movetime";
					user.value = nudTime.Value.ToString();
					break;
				case 0:
					user.mode = "depth";
					user.value = nudDepth.Value.ToString();
					break;
			}
			CUserList.SaveToIni();
			UpdateListBox();
			int index = listBox1.FindString(curUserName);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			CUser user = CUserList.GetUser(curUserName);
			if (user == null)
				return;
			CRapIni.This.DeleteKey($"player>{curUserName}");
			SaveToIni(user);
			MessageBox.Show("Player data has been updated successfully");
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbUserName.Text;
			CUser user = new CUser(name);
			user.engine = cbEngList.Text;
			CUserList.list.Add(user);
			CUserList.SaveToIni();
			SaveToIni(user);
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string userName = tbUserName.Text;
			int i = CUserList.GetIndex(userName);
			if (i == -1)
				return;
			CUserList.list.RemoveAt(i);
			CUserList.SaveToIni();
			UpdateListBox();
		}
	}
}
