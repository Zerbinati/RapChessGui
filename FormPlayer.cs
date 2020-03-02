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
		string curPlayerName;

		public FormPlayer()
		{
			This = this;
			InitializeComponent();
		}

		public void SelectUser()
		{
			SelectUser(curPlayerName);
		}

		void SelectUser(string name)
		{
			var user = CPlayerList.GetPlayer(name);
			if (user == null)
				return;
			tbPlayerName.Text = user.name;
			if (CEngineList.GetIndex(user.engine) >= 0)
				cbEngineList.Text = user.engine;
			else
				cbEngineList.Text = "Human";
			if (cbBookList.Items.IndexOf(user.book) >= 0)
				cbBookList.Text = user.book;
			else
				cbBookList.Text = "None";
			curPlayerName = user.name;
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
			user.name = tbPlayerName.Text;
			user.engine = cbEngineList.Text;
			user.book = cbBookList.Text;
			user.elo = nudElo.Value.ToString();
			user.eloOld = Convert.ToDouble(user.elo);
			curPlayerName = user.name;
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
			CPlayer player = CPlayerList.GetPlayer(curPlayerName);
			if (player == null)
				return;
			CRapIni.This.DeleteKey($"gamer>{player.name}");
			SaveToIni(player);
			MessageBox.Show($"Player {player.name} has been modified");
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbPlayerName.Text;
			CPlayer player = new CPlayer(name);
			player.engine = cbEngineList.Text;
			CPlayerList.list.Add(player);
			SaveToIni(player);
			MessageBox.Show($"Player {player.name} has been created");
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string userName = tbPlayerName.Text;
			CPlayerList.DeletePlayer(userName);
			UpdateListBox();
			MessageBox.Show($"Player {userName} has been removed");
		}

		private void FormPlayer_Shown(object sender, EventArgs e)
		{
			cbEngineList.Items.Clear();
			cbEngineList.Items.Add("Human");
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
