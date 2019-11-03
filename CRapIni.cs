using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;


namespace RapIni
{
	class CRapIni
	{
		public static CRapIni This;
		string name = Assembly.GetExecutingAssembly().GetName().Name;
		string path;
		List<string> list = new List<string>();

		public CRapIni()
		{
			This = this;
			path = new FileInfo(name + ".ini").FullName.ToString();
			Load();
		}

		public CRapIni(string p)
		{
			This = this;
			path = p;
			Load();
		}

		public void Write(string key, string value)
		{
			DeleteKey(key);
			list.Add($"{key}>{value}");
		}

		public void WriteList(string key, List<string> value)
		{
			DeleteKey(key);
			foreach (string e in value)
				list.Add($"{key}>{e}");
		}

		public string Read(string key, string def = "")
		{
			string[] ak = key.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string e in list)
			{
				if (e.IndexOf($"{key}>") == 0)
				{
					string[] ae = e.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
					if (ae.Length > ak.Length)
						return ae[ak.Length];
					else
						return "";
				}
			}
			return def;
		}

		public List<string> ReadList(string key)
		{
			List<string> result = new List<string>();
			string[] ak = key.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string e in list)
			{
				if (e.IndexOf($"{key}>") == 0)
				{
					string[] ae = e.Split(new[] { '>' }, StringSplitOptions.RemoveEmptyEntries);
					string s = "";
					if (ae.Length > ak.Length)
						s = ae[ak.Length];
					if (!result.Contains(s))
					result.Add(s);
				}
			}
			return result;
		}

		public void DeleteKey(string key)
		{
			for (int n = list.Count - 1; n >= 0; n--)
			{

				if (list[n].IndexOf($"{key}>") == 0)
					list.RemoveAt(n);
			}
		}

		public void Save()
		{
			list.Sort();
			File.WriteAllLines(path, list);
		}

		public void Load()
		{
			if (File.Exists(path))
				list = File.ReadAllLines(path).ToList();
			else
				list.Clear();
		}

	}

}
