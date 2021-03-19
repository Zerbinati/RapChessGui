using System.Collections.Generic;
using NSChess;

namespace RapChessGui
{
	public class CHisMove
	{
		public int piece;
		public int emo;
		public string umo;
		public string san;

		public CHisMove(int piece, int emo, string umo, string san)
		{
			this.piece = piece;
			this.emo = emo;
			this.umo = umo;
			this.san = san;
		}

		public string GetNotation()
		{
			if (FormOptions.This.rbSan.Checked)
				return san;
			else
				return umo;
		}

	}

	public static class CHistory
	{
		public static string fen = CChess.defFen;
		public static List<CHisMove> moveList = new List<CHisMove>();

		public static void AddMove(int piece, int emo, string umo, string san)
		{
			moveList.Add(new CHisMove(piece, emo, umo, san));
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

		public static CHisMove Last()
		{
			if (moveList.Count == 0)
				return null;
			return moveList[moveList.Count - 1];
		}

		public static string LastNotation()
		{
			if (moveList.Count == 0)
				return "";
			return moveList[moveList.Count - 1].GetNotation();
		}

		public static string LastUmo()
		{
			if (moveList.Count == 0)
				return "";
			return moveList[moveList.Count - 1].umo;
		}

		public static void SetFen(string f = CChess.defFen)
		{
			fen = f;
			moveList.Clear();
		}

		public static string GetMovesUci()
		{
			string result = string.Empty;
			foreach (CHisMove m in moveList)
				result += $" {m.umo}";
			return result.Trim();
		}

		public static string GetMovesNotation(int maxCount)
		{
			string result = string.Empty;
			foreach (CHisMove hm in moveList)
			{
				if (maxCount-- <= 0)
					return result;
				result += $" {hm.GetNotation()}";
			}
			return result.Trim();
		}

		public static string GetPgn()
		{
			string result = string.Empty;
			int c = 0;
			for (int n = 0; n < moveList.Count; n++)
			{
				if ((++c & 1) > 0)
					result += $" {(c >> 1) + 1}.";
				CHisMove hm = moveList[n];
				result += $" {hm.san}";
			}
			return result.Trim();
		}

		public static string GetPosition()
		{
			string result = "position ";
			result += (fen == CChess.defFen) ? "startpos" : "fen " + fen;
			if (moveList.Count > 0)
				return result + " moves " + GetMovesUci();
			else
				return result;
		}

	}
}
