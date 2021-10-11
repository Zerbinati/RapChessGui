using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapIni;

namespace RapChessGui
{
	public class CDirBook
	{
		public string dir = "";
		public string book = "none";
	}

	public class CDirBookList : List<CDirBook>
	{

		public CDirBookList()
		{
		}

		public void LoadFromIni()
		{
			Clear();
			string[] dirs = Directory.GetDirectories("Books");
			foreach (string dir in dirs)
			{
				CDirBook db = new CDirBook();
				db.dir = Path.GetFileName(dir);
				db.book = FormChess.iniFile.Read($"options>dir>{db.dir}", db.book);
				Add(db);
			}
		}

		public void SaveToIni()
		{
			FormChess.iniFile.DeleteKey("options>dir");
			foreach (CDirBook db in this)
				FormChess.iniFile.Write($"options>dir>{db.dir}",db.book);
		}

	}
}
