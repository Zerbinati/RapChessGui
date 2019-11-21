using System;
using System.Collections.Generic;

namespace RapChessGui
{
	public class CHisMove
	{
		public int piece;
		public string emo;

		public CHisMove(int piece,string emo)
		{
			this.piece = piece;
			this.emo = emo;
		}

	}

	public static class CHistory
	{
		public static string fen = CEngine.defFen;
		public static List<CHisMove> moveList = new List<CHisMove>();

		public static void AddMove(int piece,string emo)
		{
			moveList.Add(new CHisMove(piece,emo));
		}

		public static bool Back()
		{
			if (moveList.Count > 1)
			{
				moveList.RemoveRange(moveList.Count - 2, 2);
				return true;
			}
			return false;
		}

		public static string LastMove()
		{
			if (moveList.Count == 0)
				return "";
			return moveList[moveList.Count - 1].emo;
		}

		public static void NewGame(string f = CEngine.defFen)
		{
			fen = f;
			moveList.Clear();
		}

		public static string GetMoves()
		{
			string result = "";
			foreach (CHisMove m in moveList)
				result += $" {m.emo}";
			return result;
		}

		public static string GetPosition()
		{
			string result = "position ";
			result += (fen == CEngine.defFen) ? "startpos" : "fen " + fen;
			if (moveList.Count > 0)
				return result + " moves" + GetMoves();
			else
				return result;
		}
	}
}
