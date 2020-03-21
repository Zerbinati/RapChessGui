using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapChessGui
{
	public class CEco
	{
		public string eco;
		public string name;
		public string fen;
		public string moves;
	}

	class CEcoList
	{
		public List<CEco> list = new List<CEco>();

		public CEcoList()
		{
			LoadFromFile("a.tsv");
			LoadFromFile("b.tsv");
			LoadFromFile("c.tsv");
			LoadFromFile("d.tsv");
			LoadFromFile("e.tsv");
		}

		void LoadFromFile(string fn)
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + "Eco\\" + fn;
			String[] content = File.ReadAllLines(path);
			for (int n = 1; n < content.Length; n++)
			{
				List<string> r = content[n].Split('\t').ToList();
				CEco eco = new CEco();
				eco.eco = r[0];
				eco.name = r[1];
				eco.fen = r[2];
				eco.moves = r[3];
				list.Add(eco);
			}
		}

		public CEco GetEco(string fen)
		{
			foreach (CEco e in list)
				if (e.fen == fen)
					return e;
			return null;
		}

		public void SaveToFile()
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + "Books\\eco.rap";
			List<string> moves = new List<string>();
			foreach (CEco eco in list)
				moves.Add(eco.moves);
			File.WriteAllLines(path, moves);
		}

	}
}
