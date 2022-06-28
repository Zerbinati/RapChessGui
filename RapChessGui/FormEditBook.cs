using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace RapChessGui
{
	public partial class FormEditBook : Form
	{
		string curBookName;

		public FormEditBook()
		{
			InitializeComponent();
		}

		void ClickUpdate()
		{
			CBook book = FormChess.bookList.GetBook(curBookName);
			if (book == null)
				return;
			CBookList.iniFile.DeleteKey($"book>{book.name}");
			SaveToIni(book);
			MessageBox.Show($"Reader {book.name} has been modified");
			CData.reset = true;
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
			cbBookreaderList.Text = book.exe;
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

		void UpdateBook(CBook b)
		{
			b.name = tbReaderName.Text;
			b.exe = cbBookreaderList.Text;
			b.parameters = tbParameters.Text;
			b.elo = nudElo.Value.ToString();
			b.tournament = (int)nudTournament.Value;
		}

		void SaveToIni(CBook b)
		{
			UpdateBook(b);
			b.SaveToIni();
			curBookName = b.name;
			UpdateListBox();
			int index = listBox1.FindString(b.name);
			if (index == -1) return;
			listBox1.SetSelected(index, true);
		}

		private void ButUpdate_Click(object sender, EventArgs e)
		{
			ClickUpdate();
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbReaderName.Text;
			CBook reader = new CBook(name);
			reader.exe = cbBookreaderList.Text;
			FormChess.bookList.list.Add(reader);
			SaveToIni(reader);
			MessageBox.Show($"Book reader {reader.name} has been created");
			CData.reset = true;
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string name = tbReaderName.Text;
			var dr = MessageBox.Show($"Are you sure that you would like to delete {name}?", "Delete engine", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				FormChess.bookList.DeleteBook(name);
				UpdateListBox();
				MessageBox.Show($"Book {name} has been removed");
				CData.reset = true;
			}
		}

		private void FormBook_Shown(object sender, EventArgs e)
		{
			FormOptions.SetFontSize(this);
			cbBookreaderList.Items.Clear();
			cbBookreaderList.Sorted = true;
			foreach (string book in CData.fileBook)
				cbBookreaderList.Items.Add(book);
			cbBookreaderList.Sorted = false;
			cbBookreaderList.Items.Insert(0, "None");
			cbBookreaderList.SelectedIndex = 0;
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

		private void button1_Click(object sender, EventArgs e)
		{
			CBook b = new CBook();
			UpdateBook(b);
			tbReaderName.Text = b.CreateName();
		}

		private void bConsole_Click(object sender, EventArgs e)
		{
			CBook book = FormChess.bookList.GetBook(curBookName);
			ProcessStartInfo psi = new ProcessStartInfo();
			psi.FileName = book.GetFileName();
			psi.Arguments = book.GetParameters();
			psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);
			Process.Start(psi);
		}
	}
}
