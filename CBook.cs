using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RapChessGui
{
	public class CBook
	{
		int indexL = 0;
		int indexH = 0;
		string path = "";
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
			string[] mo = m.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			string[] mr = moves[index].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (mr.Length > mo.Length)
			{
				string emo = mr[mo.Length];
				if (CEngine.This.IsValidMove(emo) == 0)
				{
					indexL = moves.Count;
					return "";
				}
				else
					return emo;
			}
			return "";
		}

		public void Load(string book)
		{
			moves.Clear();
			path = "Books/" + book;
			if (File.Exists(path))
				moves = File.ReadAllLines(path).ToList();
			Reset();
		}

		public void Reset()
		{
			indexL = 0;
			indexH = moves.Count - 1;
		}

		public void Sort()
		{
			moves.Sort();
			File.WriteAllLines(path, moves);
		}

	}
}
