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
		}

		public void SelectUser()
		{
			SelectUser(curUserName);
		}

		void SelectUser(string name)
		{
			var user = CPlayerList.GetUser(name);
			if (user == null)
				return;
			tbUserName.Text = user.name;
			if (CEngineList.GetIndex(user.engine) >= 0)
				cbEngineList.Text = user.engine;
			else
				cbEngineList.Text = "Human";
			if (cbBookList.Items.IndexOf(user.book) >= 0)
				cbBookList.Text = user.book;
			else
				cbBookList.Text = "None";
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
			foreach (CPlayer u in CPlayerList.list)
				listBox1.Items.Add(u.name);
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectUser(listBox1.SelectedItem.ToString());
		}

		void SaveToIni(CPlayer user)
		{
			user.name = tbUserName.Text;
			user.engine = cbEngineList.Text;
			user.book = cbBookList.Text;
			user.elo = nudElo.Value.ToString();
			user.eloOld = Convert.ToDouble(user.elo);
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
			user.SaveToIni();
			UpdateListBox();
			int index = listBox1.FindString(user.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			CPlayer user = CPlayerList.GetUser(curUserName);
			if (user == null)
				return;
			CRapIni.This.DeleteKey($"gamer>{user.name}");
			SaveToIni(user);
			MessageBox.Show($"Player {user.name} has been modified");
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbUserName.Text;
			CPlayer user = new CPlayer(name);
			user.engine = cbEngineList.Text;
			CPlayerList.list.Add(user);
			SaveToIni(user);
			MessageBox.Show($"Player {user.name} has been created");
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string userName = tbUserName.Text;
			CPlayerList.DeletePlayer(userName);
			UpdateListBox();
			MessageBox.Show($"Player {userName} has been removed");
		}

		private void FormPlayer_Shown(object sender, EventArgs e)
		{
			cbEngineList.Items.Clear();
			foreach (CEngine engine in CEngineList.list)
				cbEngineList.Items.Add(engine.name);
			cbBookList.Items.Clear();
			cbBookList.Items.Add("None");
			foreach (CBook book in CBookList.list)
				cbBookList.Items.Add(book.name);
			UpdateListBox();
			if (listBox1.Items.Count > 0)
				listBox1.SetSelected(0, true);
		}
	}
}
