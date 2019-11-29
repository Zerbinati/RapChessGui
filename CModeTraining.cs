namespace RapChessGui
{
	class CModeTraining
	{
		public int rotate = 0;
		public int games = 0;
		public int win = 0;
		public int draw = 0;
		public int loose = 0;
		public int time = 1000;

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

	}
}
