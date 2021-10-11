using System;
using System.Drawing;
using System.Windows.Forms;
using RapIni;

namespace RapChessGui
{
	public partial class FormPlayer : Form
	{
		int indexFirst = -1;
		int tournament = -1;
		CPlayer player = null;
		readonly CModeValue modeValue = new CModeValue();

		public FormPlayer()
		{
			InitializeComponent();
		}

		void SelectPlayer()
		{
			tbPlayerName.Text = player.name;
			if (FormChess.engineList.GetIndex(player.engine) >= 0)
				cbEngineList.Text = player.engine;
			else
				cbEngineList.Text = "Human";
			if (cbBookList.Items.IndexOf(player.book) >= 0)
				cbBookList.Text = player.book;
			else
				cbBookList.Text = "None";
			nudTournament.Value = player.tournament;
			nudElo.Value = Convert.ToInt32(player.elo);
			nudValue.Value = player.modeValue.GetValue();
			modeValue.mode = player.modeValue.mode;
			modeValue.value = player.modeValue.value;
			combMode.SelectedIndex = combMode.FindStringExact(modeValue.mode);
		}

		void SelectPlayer(CPlayer p)
		{
			player = p;
			SelectPlayer();
		}

		void SelectPlayer(string name)
		{
			player = FormChess.playerList.GetPlayer(name);
			if (player != null)
				SelectPlayer(player);
		}

		void SelectPlayers(int first, int last, bool t)
		{
			int f = first < last ? first : last;
			int l = first < last ? last : first;
			bool r = false;
			for (int n = f; n <= l; n++)
			{
				var item = listBox1.Items[n];
				string name = item.ToString();
				CPlayer pla = FormChess.playerList.GetPlayer(name);
				if (pla.SetTournament(t))
					r = true;
			}
			if (r)
			{
				listBox1.Refresh();
				SelectPlayer();
			}
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach (CPlayer u in FormChess.playerList.list)
				listBox1.Items.Add(u.name);
			gbPlayers.Text = $"Players {listBox1.Items.Count}";
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
			p.SetTournament((int)nudTournament.Value);
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
			FormChess.iniFile.DeleteKey($"player>{player.name}");
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
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, CBoard.colorMessage, CBoard.colorChartD);
				b = Brushes.White;
			}
			else if (FormChess.engineList.GetEngine(pla.engine) == null)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.White, CBoard.colorRed);
				b = Brushes.White;
			}
			else if (pla.tournament > 0)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.Black, CBoard.colorMessage);
			}
			e.DrawBackground();
			e.Graphics.DrawString(name, e.Font, b, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}

		private void listBox1_MouseUp(object sender, MouseEventArgs e)
		{
			tournament = -1;
			listBox1.Capture = false;
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
					CPlayer pla = FormChess.playerList.GetPlayer(name);
					indexFirst = index;
					tournament = pla.tournament > 0 ? 0 : 1;
					if (pla.SetTournament(tournament == 1))
					{
						listBox1.Refresh();
						if (player == pla)
							SelectPlayer();
					}

				}
			}
		}

		private void listBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int index = listBox1.IndexFromPoint(e.Location);
				if ((index >= 0) && (index < listBox1.Items.Count) && (tournament >= 0))
					SelectPlayers(indexFirst, index, tournament > 0);
			}
		}
	}
}
