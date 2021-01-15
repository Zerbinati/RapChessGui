using System;
using System.Drawing;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormPlayer : Form
	{
		public static FormPlayer This;
		int tournament = -1;
		CPlayer player = null;
		readonly CModeValue modeValue = new CModeValue();

		public FormPlayer()
		{
			This = this;
			InitializeComponent();
		}

		void SelectPlayer(CPlayer p)
		{
			tbPlayerName.Text = p.name;
			if (FormChess.engineList.GetIndex(p.engine) >= 0)
				cbEngineList.Text = p.engine;
			else
				cbEngineList.Text = "Human";
			if (cbBookList.Items.IndexOf(p.book) >= 0)
				cbBookList.Text = p.book;
			else
				cbBookList.Text = "None";
			nudTournament.Value = p.tournament;
			nudElo.Value = Convert.ToInt32(p.elo);
			nudValue.Value = p.modeValue.GetValue();
			modeValue.mode = p.modeValue.mode;
			modeValue.value = p.modeValue.value;
			combMode.SelectedIndex = combMode.FindStringExact(modeValue.mode);
		}

		void SelectPlayer(string name)
		{
			player = FormChess.playerList.GetPlayer(name);
			if (player != null)
				SelectPlayer(player);
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
			UpdateListBox();
			int index = listBox1.FindString(p.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			modeValue.mode = combMode.Text;
			modeValue.SetValue((int)nudValue.Value);
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
			if (player != null)
			{
				player.hisElo.list.Clear();
				player.SaveToIni();
				int count = CModeTournamentP.tourList.DeletePlayer(player.name);
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
			nudValue.Increment = modeValue.GetValueIncrement();
			nudValue.Value = modeValue.GetValue();
			toolTip1.SetToolTip(nudValue, modeValue.GetTip());
		}

		private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;
			string name = listBox1.Items[e.Index].ToString();
			CPlayer pla = FormChess.playerList.GetPlayer(name);
			bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			Brush b = Brushes.Black;
			if (selected)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, CBoard.colorBrighter, CBoard.colorDark);
				b = Brushes.White;
			}
			else if (pla.tournament > 0)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, CBoard.colorBrighter);
			}
			e.DrawBackground();
			e.Graphics.DrawString(name, e.Font, b, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}
	}
}
