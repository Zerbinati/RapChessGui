using System;
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
			SelectPlayer(curPlayerName);
		}

		void SelectPlayer(string name)
		{
			CPlayer p = FormChess.playerList.GetPlayer(name);
			if (p == null)
				return;
			tbPlayerName.Text = p.name;
			if (FormChess.engineList.GetIndex(p.engine) >= 0)
				cbEngineList.Text = p.engine;
			else
				cbEngineList.Text = "Human";
			if (cbBookList.Items.IndexOf(p.book) >= 0)
				cbBookList.Text = p.book;
			else
				cbBookList.Text = "None";
			curPlayerName = p.name;
			nudTournament.Value = p.tournament;
			nudElo.Value = Convert.ToInt32(p.elo);
			nudValue.Value = p.modeValue.GetValue();
			modeValue.mode = p.modeValue.mode;
			modeValue.value = p.modeValue.value;
			combMode.SelectedIndex = combMode.FindStringExact(modeValue.mode);
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach (CPlayer u in FormChess.playerList.list)
				listBox1.Items.Add(u.name);
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectPlayer(listBox1.SelectedItem.ToString());
		}

		void SaveToIni(CPlayer p)
		{
			p.name = tbPlayerName.Text;
			p.engine = cbEngineList.Text;
			p.book = cbBookList.Text;
			p.tournament = (int)nudTournament.Value;
			p.elo = nudElo.Value.ToString();
			p.eloOrg = p.elo;
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
			modeValue.mode = combMode.Text;
			modeValue.SetValue((int)nudValue.Value);
			CPlayer player = FormChess.playerList.GetPlayer(curPlayerName);
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
			if (FormChess.playerList.GetPlayer(name) == null)
			{
				modeValue.mode = combMode.Text;
				modeValue.SetValue((int)nudValue.Value);
				CPlayer player = new CPlayer(name);
				player.engine = cbEngineList.Text;
				FormChess.playerList.list.Add(player);
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
			DialogResult dr = MessageBox.Show($"Are you sure to delete player {playerName}?", "Confirm Delete", MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				FormChess.playerList.DeletePlayer(playerName);
				UpdateListBox();
				MessageBox.Show($"Player {playerName} has been removed");
				CData.reset = true;
			}
		}

		private void butClearHistory_Click(object sender, EventArgs e)
		{
			CPlayer player = FormChess.playerList.GetPlayer(curPlayerName);
			if (player != null)
			{
				player.hisElo.list.Clear();
				player.SaveToIni();
				int count = CModeTournamentP.tourList.DeletePlayer(curPlayerName);
				MessageBox.Show($"{count} records have been deleted");
			}
		}

		private void FormPlayer_Shown(object sender, EventArgs e)
		{
			cbEngineList.Items.Clear();
			cbEngineList.Items.Add("Human");
			foreach (CEngine engine in FormChess.engineList.list)
				cbEngineList.Items.Add(engine.name);
			cbBookList.Items.Clear();
			cbBookList.Items.Add("None");
			foreach (CBook book in FormChess.bookList.list)
				cbBookList.Items.Add(book.name);
			UpdateListBox();
			if (listBox1.Items.Count > 0)
				listBox1.SetSelected(0, true);
		}

		private void combMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			modeValue.mode = combMode.Text;
			nudValue.Increment = modeValue.GetValueInc();
			nudValue.Value = modeValue.GetValue();
			toolTip1.SetToolTip(nudValue, modeValue.GetTip());
		}
	}
}
