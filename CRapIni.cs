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
		string path;
		List<string> list = new List<string>();

		public CRapIni()
		{
			string name = Assembly.GetExecutingAssembly().GetName().Name;
			This = this;
			path = new FileInfo(name + ".ini").FullName.ToString();
		}

		public CRapIni(string name)
		{
			This = this;
			path = new FileInfo(name + ".ini").FullName.ToString();
		}

		public void Write(string key, string value)
		{
			if (Load())
			{
				DeleteKey(key);
				list.Add($"{key}>{value}");
				Save();
			}
		}

		public void WriteList(string key, List<string> value)
		{
			if (Load())
			{
				DeleteKey(key);
				foreach (string e in value)
					list.Add($"{key}>{e}");
				Save();
			}
		}

		public string Read(string key, string def = "")
		{
			if (Load())
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
			}
			return def;
		}

		public List<string> ReadList(string key)
		{
			List<string> result = new List<string>();
			if (Load())
			{
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
			}
			return result;
		}

		public void DeleteKey(string key)
		{
			if (Load())
			{
				for (int n = list.Count - 1; n >= 0; n--)
				{

					if (list[n].IndexOf($"{key}>") == 0)
						list.RemoveAt(n);
				}
				Save();
			}
		}

		public bool Save()
		{
			list.Sort();
			try
			{
				File.WriteAllLines(path, list);
			}
			catch
			{
				return false;
			}
			return true;
		}

		public bool Load()
		{
			if (File.Exists(path))
			{
				try
				{
					list = File.ReadAllLines(path).ToList();
				}
				catch
				{
					return false;
				}
			}
			else
				list.Clear();
			return true;
		}

	}

}
