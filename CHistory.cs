using System;
using System.Collections.Generic;

namespace RapChessGui
{
	public static class CHistory
	{
		public static string fen = CEngine.defFen;
		public static List<string> moves = new List<string>();

		public static bool Back()
		{
			if (moves.Count > 1)
			{
				moves.RemoveRange(moves.Count - 2, 2);
				return true;
			}
			return false;
		}

		public static string LastMove()
		{
			if (moves.Count == 0)
				return "";
			return moves[moves.Count - 1];
		}

		public static void NewGame(string f = CEngine.defFen)
		{
			fen = f;
			moves.Clear();
		}

		public static string GetMoves()
		{
			return String.Join(" ", moves);
		}

		public static string GetPosition()
		{
			string result = "position ";
			result += fen == CEngine.defFen ? "startpos" : "fen " + fen;
			if (moves.Count > 0)
				return result + " moves " + String.Join(" ", moves);
			else
				return result;
		}
	}
}
