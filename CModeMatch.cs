using RapIni;

namespace RapChessGui
{
	class CModeMatch
	{
		public int rotate = 0;
		public int games = 0;
		public int win = 0;
		public int draw = 0;
		public int loose = 0;

		public void Reset()
		{
			rotate = 0;
			games = 0;
			win = 0;
			draw = 0;
			loose = 0;
		}

		public int Total()
		{
			return win + draw + loose;
		}

		public int Result(bool rev)
		{
			int t = Total();
			if (t == 0)
				return 50;
			if (rev)
				return ((loose * 2 + draw) * 100) / (t * 2);
			else
				return ((win * 2 + draw) * 100) / (t * 2);
		}

		public void LoadFromIni()
		{
			rotate = CRapIni.This.ReadInt("mode>match>rotate>");
			games = CRapIni.This.ReadInt("mode>match>games>");
			win = CRapIni.This.ReadInt("mode>match>win>");
			draw = CRapIni.This.ReadInt("mode>match>draw>");
			loose = CRapIni.This.ReadInt("mode>match>loose>");
		}

		public void SaveToIni()
		{
			CRapIni.This.Write("mode>match>rotate>", rotate.ToString());
			CRapIni.This.Write("mode>match>games>", games.ToString());
			CRapIni.This.Write("mode>match>win>", win.ToString());
			CRapIni.This.Write("mode>match>draw>", draw.ToString());
			CRapIni.This.Write("mode>match>loose>", loose.ToString());
		}

	}
}
