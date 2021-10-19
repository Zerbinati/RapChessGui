using System;
using System.Drawing;
using System.Windows.Forms;

namespace RapChessGui
{
	public partial class FormBook : Form
	{
		string curBookName;

		public FormBook()
		{
			InitializeComponent();
		}

		public void SelectReader()
		{
			SelectReader(curBookName);
		}

		void SelectReader(string name)
		{
			CBook book = FormChess.bookList.GetBook(name);
			if (book == null)
				return;
			tbReaderName.Text = book.name;
			cbBookReaderList.Text = book.exe;
			tbParameters.Text = book.parameters;
			nudElo.Value = Convert.ToInt32(book.elo);
			nudTournament.Value = book.tournament;
			curBookName = book.name;
		}

		void UpdateListBox()
		{
			listBox1.Items.Clear();
			foreach (CBook b in FormChess.bookList.list)
				listBox1.Items.Add(b.name);
			gbBooks.Text = $"Books {listBox1.Items.Count}";
		}

		private void ListBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			SelectReader(listBox1.SelectedItem.ToString());
		}

		void SaveToIni(CBook book)
		{
			book.name = tbReaderName.Text;
			book.exe = cbBookReaderList.Text;
			book.parameters = tbParameters.Text;
			book.elo = nudElo.Value.ToString();
			book.tournament = (int)nudTournament.Value;
			book.SaveToIni();
			curBookName = book.name;
			UpdateListBox();
			int index = listBox1.FindString(book.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			CBook book = FormChess.bookList.GetBook(curBookName);
			if (book == null)
				return;
			FormChess.iniFile.DeleteKey($"book>{book.name}");
			SaveToIni(book);
			MessageBox.Show($"Reader {book.name} has been modified");
			CData.reset = true;
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbReaderName.Text;
			CBook reader = new CBook(name);
			reader.exe = cbBookReaderList.Text;
			FormChess.bookList.list.Add(reader);
			SaveToIni(reader);
			MessageBox.Show($"Book reader {reader.name} has been created");
			CData.reset = true;
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string name = tbReaderName.Text;
			FormChess.bookList.DeleteBook(name);
			UpdateListBox();
			MessageBox.Show($"Book {name} has been removed");
			CData.reset = true;
		}

		private void FormBook_Shown(object sender, EventArgs e)
		{
			FormOptions.SetFontSize(this);
			cbBookReaderList.Items.Clear();
			foreach (string book in CData.fileBook)
				cbBookReaderList.Items.Add(book);
			UpdateListBox();
			if (listBox1.Items.Count > 0)
				listBox1.SetSelected(0, true);
		}

		private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index < 0)
				return;
			string name = listBox1.Items[e.Index].ToString();
			CBook book = FormChess.bookList.GetBook(name);
			bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
			Brush b = Brushes.Black;
			if (selected)
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, CBoard.colorMessage, CBoard.colorChartD);
				b = Brushes.White;
			}
			else if (!book.FileExists())
			{
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State, Color.White, CBoard.colorRed);
				b = Brushes.White;
			}
			e.DrawBackground();
			e.Graphics.DrawString(name, e.Font, b, e.Bounds, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}

		private void FormBook_FormClosing(object sender, FormClosingEventArgs e)
		{
		}
	}
}
