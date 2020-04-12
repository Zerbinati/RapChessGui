using System;
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
		readonly CModeValue modeValue = new CModeValue();

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
			CPlayer p = CPlayerList.GetPlayerAuto(name);
			if (p == null)
				return;
			tbPlayerName.Text = p.name;
			if (CEngineList.GetIndex(p.engine) >= 0)
				cbEngineList.Text = p.engine;
			else
				cbEngineList.Text = "Human";
			if (cbBookList.Items.IndexOf(p.book) >= 0)
				cbBookList.Text = p.book;
			else
				cbBookList.Text = "None";
			curPlayerName = p.name;
			nudElo.Value = Int32.Parse(p.elo);
			nudValue.Value = p.modeValue.GetValue();
			modeValue.mode = p.modeValue.mode;
			modeValue.value = p.modeValue.value;
			cbMode.SelectedIndex = cbMode.FindStringExact(modeValue.mode);
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

		void SaveToIni(CPlayer p)
		{
			p.name = tbPlayerName.Text;
			p.engine = cbEngineList.Text;
			p.book = cbBookList.Text;
			p.elo = nudElo.Value.ToString();
			p.eloOld = Convert.ToDouble(p.elo);
			p.modeValue.mode = modeValue.mode;
			p.modeValue.value = modeValue.value;
			p.SaveToIni();
			curPlayerName = p.name;
			UpdateListBox();
			int index = listBox1.FindString(p.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			modeValue.mode = cbMode.Text;
			modeValue.SetValue((int)nudValue.Value);
			CPlayer player = CPlayerList.GetPlayer(curPlayerName);
			if (player == null)
				return;
			CRapIni.This.DeleteKey($"player>{player.name}");
			SaveToIni(player);
			MessageBox.Show($"Player {player.name} has been modified");
			CData.reset = true;
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbPlayerName.Text;
			if (CPlayerList.GetPlayer(name) == null)
			{
				modeValue.mode = cbMode.Text;
				modeValue.SetValue((int)nudValue.Value);
				CPlayer player = new CPlayer(name);
				player.engine = cbEngineList.Text;
				CPlayerList.list.Add(player);
				SaveToIni(player);
				MessageBox.Show($"Player {player.name} has been created");
				CData.reset = true;
			}
			else
				MessageBox.Show($"Player {name} already exists");
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string playerName = tbPlayerName.Text;
			DialogResult dr = MessageBox.Show($"Are you sure to delete player {playerName}?","Confirm Delete",MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				CPlayerList.DeletePlayer(playerName);
				UpdateListBox();
				MessageBox.Show($"Player {playerName} has been removed");
				CData.reset = true;
			}
		}

		private void butClearHistory_Click(object sender, EventArgs e)
		{
			string playerName = tbPlayerName.Text;
			int count=CTourList.DeletePlayer(playerName);
			MessageBox.Show($"{count} records have been deleted");
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

		private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			modeValue.mode = cbMode.Text;
			nudValue.Increment = modeValue.GetIncrement();
			nudValue.Minimum = nudValue.Increment;
			nudValue.Value = modeValue.GetValue();
			toolTip1.SetToolTip(nudValue, modeValue.GetTip());
		}
	}
}
