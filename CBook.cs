using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	public class CBook
	{
		int indexL = 0;
		int indexH = 0;
		List<string> moves = new List<string>();

		public string GetMove(string m)
		{
			if (indexL > indexH)
				return "";
			if (m.Length > 0)
			{
				while (moves[indexL].IndexOf(m) != 0)
				{
					indexL++;
					if (indexL > indexH)
						return "";
				}
				while (moves[indexH].IndexOf(m) != 0)
				{
					indexH--;
					if (indexL > indexH)
						return "";
				}
			}
			int index = CEngine.random.Next(indexL, indexH + 1);
			string[] mo = m.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			string[] mr = moves[index].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (mr.Length > mo.Length)
				return mr[mo.Length];
			return "";
		}

		public void Load(string book)
		{
			moves.Clear();
			if (book == "None")
				return;
			moves = File.ReadAllLines("Books/" + book).ToList();
			Reset();
		}

		public void Reset()
		{
			indexL = 0;
			indexH = moves.Count - 1;
		}

	}
}
