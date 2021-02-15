using System;
using System.Drawing;
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
			CBook book = FormChess.bookList.GetBook(name);
			if (book == null)
				return;
			tbReaderName.Text = book.name;
			cbBookReaderList.Text = book.file;
			tbParameters.Text = book.parameters;
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
			CBook book = FormChess.bookList.GetBook(curBookName);
			if (book == null)
				return;
			CRapIni.This.DeleteKey($"book>{book.name}");
			SaveToIni(book);
			MessageBox.Show($"Reader {book.name} has been modified");
			CData.reset = true;
		}

		private void ButCreate_Click(object sender, EventArgs e)
		{
			string name = tbReaderName.Text;
			CBook reader = new CBook(name);
			reader.file = cbBookReaderList.Text;
			FormChess.bookList.list.Add(reader);
			SaveToIni(reader);
			MessageBox.Show($"Book reader {reader.name} has been created");
			CData.reset = true;
		}

		private void ButDelete_Click(object sender, EventArgs e)
		{
			string userName = tbReaderName.Text;
			FormChess.playerList.DeletePlayer(userName);
			UpdateListBox();
			MessageBox.Show($"Player {userName} has been removed");
			CData.reset = true;
		}

		private void FormBook_Shown(object sender, EventArgs e)
		{
			CData.UpdateFileBook();
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
				e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, CBoard.colorBrighter, CBoard.colorDark);
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
	}
}
