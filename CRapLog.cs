using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

namespace RapLog
{
	public class CRapLog
	{

		public static void Add(string m)
		{
			List<string> list = new List<string>();
			string name = Assembly.GetExecutingAssembly().GetName().Name;
			string path = new FileInfo(name + ".log").FullName.ToString();
			if (File.Exists(path))
				list = File.ReadAllLines(path).ToList();
			list.Add($"{DateTime.Now.ToString()} {m}");
			int remove = Math.Max(0, list.Count - 100);
			list.RemoveRange(0, remove);
			File.WriteAllLines(path, list);
		}

	}
}
