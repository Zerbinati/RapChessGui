using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{

	static class CModeTournamentB
	{
		public static bool rotate = true;
		public static int games = 0;
		public static int maxElo = 3000;
		public static int minElo = 0;
		public static int records = 10000;
		public static int repetition = 0;
		public static string book = String.Empty;
		public static string opponent = String.Empty;
		public static string engine = String.Empty;
		public static CTourList tourList = new CTourList("Tour-books");
		public static CModeValue modeValue = new CModeValue();
		public static CBookList bookList = new CBookList();
		public static CBook bookWin = null;
		public static CBook bookLoose = null;

		public static void SaveToIni()
		{
			FormChess.iniFile.Write("mode>tournamentB>book", book);
			FormChess.iniFile.Write("mode>tournamentB>engine", engine);
			FormChess.iniFile.Write("mode>tournamentB>mode", modeValue.mode);
			FormChess.iniFile.Write("mode>tournamentB>value", modeValue.value);
			FormChess.iniFile.Write("mode>tournamentB>records", records);
			FormChess.iniFile.Write("mode>tournamentB>rmaxElo", maxElo);
			FormChess.iniFile.Write("mode>tournamentB>minElo", minElo);
		}

		public static void LoadFromIni()
		{
			book = FormChess.iniFile.Read("mode>tournamentB>book", book);
			engine = FormChess.iniFile.Read("mode>tournamentB>engine", engine);
			modeValue.mode = FormChess.iniFile.Read("mode>tournamentB>mode", modeValue.mode);
			modeValue.value = FormChess.iniFile.ReadInt("mode>tournamentB>value", modeValue.value);
			records = FormChess.iniFile.ReadInt("mode>tournamentB>records", records);
			maxElo = FormChess.iniFile.ReadInt("mode>tournamentB>maxElo", maxElo);
			minElo = FormChess.iniFile.ReadInt("mode>tournamentB>minElo", minElo);
			tourList.SetLimit(records);
		}

		public static CBook ChooseOpponent(CBook book, CBook book1, CBook book2)
		{
			tourList.CountGames(book.name, book1.name, out int rw1, out int rl1, out int rd1);
			tourList.CountGames(book.name, book2.name, out int rw2, out int rl2, out int rd2);
			if ((book.GetElo() > book1.GetElo()) != (rw1 > rl1))
				return book1;
			if ((book.GetElo() > book2.GetElo()) != (rw2 > rl2))
				return book2;
			int count1 = (rw1 + rl1 + rd1);
			int count2 = (rw2 + rl2 + rd2);
			if (count1 * 1.1 <= count2 << 1)
				return book1;
			if (count2 * 1.1 <= count1 >> 1)
				return book2;
			return null;
		}

		public static int CountGames()
		{
			return tourList.CountGames(book, opponent, out _, out _, out _);
		}

		public static CBookList FillList()
		{
			bookList.list.Clear();
			foreach (CBook b in FormChess.bookList.list)
				if (b.tournament > 0)
					if ((b.GetElo() >= minElo) && (b.GetElo() <= maxElo))
						bookList.Add(b);
			return bookList;
		}

		public static void NewGame()
		{
			rotate = true;
			games = 0;
			repetition = 0;
			opponent = String.Empty;
		}

		public static CBook SelectBook()
		{
			CBook b = bookList.GetBook(book);
			if (b == null)
				b = SelectRare();
			if ((games >= repetition) && (games > 0))
			{
				b = bookList.NextTournament(b);
				games = 0;
			}
			return b;
		}

		public static CBook SelectOpponent(CBook book)
		{
			bookList.SortPosition(book);
			List<CBook> bl = new List<CBook>();
			foreach (CBook b in bookList.list)
				if (b != book)
					bl.Add(b);
			if (bl.Count == 0)
				return book;
			for (int n = 0; n < bl.Count - 1; n++)
			{
				CBook b = ChooseOpponent(book, bl[n], bl[n + 1]);
				if (b != null)
					return b;
			}
			return bl[0];
		}

		public static CBook SelectRare()
		{
			int count = 0;
			CBook result = null;
			foreach (CBook b in bookList.list)
			{
				int c = tourList.CountGames(b.name);
				if (count <= c)
				{
					count = c;
					result = b;
				}
			}
			return result;
		}

		public static void SetRepeition(CBook b, CBook o)
		{
			if ((book != b.name) || (opponent != o.name))
			{
				book = b.name;
				opponent = o.name;
				SaveToIni();
				tourList.CountGames(b.name, o.name, out int rw, out int rl, out _);
				if (games == 0)
				{
					repetition = b.tournament;
					if ((b.GetElo() > o.GetElo()) != (rw > rl))
						repetition++;
					rotate = true;
				}
			}
			games++;
			rotate ^= true;
		}

	}
}
