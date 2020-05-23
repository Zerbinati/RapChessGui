using System.Collections.Generic;

namespace RapChessGui
{
	public class CHisMove
	{
		public int piece;
		public int gmo;
		public string emo;
		public string san;

		public CHisMove(int piece, int gmo, string emo, string san)
		{
			this.piece = piece;
			this.gmo = gmo;
			this.emo = emo;
			this.san = san;
		}

		public string GetNotation()
		{
			if (FormOptions.This.rbSan.Checked)
				return san;
			else
				return emo;
		}

	}

	public static class CHistory
	{
		public static string fen = CChess.defFen;
		public static List<CHisMove> moveList = new List<CHisMove>();

		public static void AddMove(int piece, int gmo, string emo, string san)
		{
			moveList.Add(new CHisMove(piece, gmo, emo, san));
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

		public static string LastMove()
		{
			if (moveList.Count == 0)
				return "";
			return moveList[moveList.Count - 1].GetNotation();
		}

		public static void NewGame(string f = CChess.defFen)
		{
			fen = f;
			moveList.Clear();
		}

		public static string GetMoves()
		{
			string result = "";
			foreach (CHisMove m in moveList)
				result += $" {m.emo}";
			return result.Trim();
		}

		public static string GetPgn()
		{
			string result = "";
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
				return result + " moves " + GetMoves();
			else
				return result;
		}
	}
}
