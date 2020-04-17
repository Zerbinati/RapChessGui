using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace RapIni
{
	public class CRapIni
	{
		public static CRapIni This;
		readonly string name = "";
		readonly string path = "";
		readonly string script ="";
		List<string> list = new List<string>();

		public CRapIni()
		{
			This = this;
			name = Assembly.GetExecutingAssembly().GetName().Name;
			path = new FileInfo(name + ".ini").FullName.ToString();
			script = Read("script", "");
		}

		public CRapIni(string name)
		{
			This = this;
			this.name = name;
			path = new FileInfo(name + ".ini").FullName.ToString();
			script = Read("script", "");
		}

		public void WriteToFile(string key, string value)
		{
			if (script != "")
				WriteToServer(key, value);
			if (Load())
			{
				DeleteKey(key);
				list.Add($"{key}>{value}");
				Save();
			}
		}

		public void WriteToServer(string key, string value)
		{
			var reqparm = new NameValueCollection();
			reqparm.Add("action", "write");
			reqparm.Add("name", name);
			reqparm.Add("key", key);
			reqparm.Add("value", value);
			byte[] data;
			try
			{
				data = new WebClient().UploadValues(script, "POST", reqparm);
			}
			catch
			{
			}
		}

		public void Write(string key, string value)
		{
			if (script == "")
				WriteToFile(key, value);
			else
				WriteToServer(key, value);

		}

		public void Write(string key, double value)
		{
			Write(key,value.ToString());
		}

		public string ReadFromFile(string key, string def = "")
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

		public string ReadFromServer(string key, string def = "")
		{
			var reqparm = new NameValueCollection();
			reqparm.Add("action", "read");
			reqparm.Add("name", name);
			reqparm.Add("key", key);
			byte[] data;
			try
			{
				data = new WebClient().UploadValues(script, "POST", reqparm);
			}
			catch
			{
				return def;
			}
			string result = Encoding.ASCII.GetString(data);
			if (result == "")
				return def;
			else
				return result;
		}

		public string Read(string key, string def = "")
		{
			if (script == "")
				return ReadFromFile(key, def);
			else
				return ReadFromServer(key, def);
		}

		public double ReadDouble(string key, double def = 0)
		{
			string s = Read(key, Convert.ToString(def));
			Double.TryParse(s, out def);
			return def;
		}

		public int ReadInt(string key, int def = 0)
		{
			string s = Read(key, Convert.ToString(def));
			return Convert.ToInt32(s);
		}

		public bool ReadBool(string key, bool def = false)
		{
			string s = Read(key, Convert.ToString(def));
			bool.TryParse(s,out bool result);
			return result;
		}

		public void WriteList(string key, List<string> value)
		{
			DeleteKey(key);
			foreach (string e in value)
				Write(key,e);
		}


		public List<string> ReadListFromFile(string key)
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

		public List<string> ReadListFromServer(string key)
		{
			var reqparm = new NameValueCollection();
			reqparm.Add("action", "readList");
			reqparm.Add("name", name);
			reqparm.Add("key", key);
			byte[] data;
			try
			{
				data = new WebClient().UploadValues(script, "POST", reqparm);
			}
			catch
			{
				return new List<string>();
			}
			string s = Encoding.ASCII.GetString(data);
			string[] result = s.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			return result.ToList();
		}

		public List<string> ReadList(string key)
		{
			if (script == "")
				return ReadListFromFile(key);
			else
				return ReadListFromServer(key);
		}


			private void DeleteKeyFromFile(string key)
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

		private void DeleteKeyFromServer(string key)
		{
			var reqparm = new NameValueCollection();
			reqparm.Add("action", "delete");
			reqparm.Add("name", name);
			reqparm.Add("key", key);
			byte[] data;
			try
			{
				data = new WebClient().UploadValues(script, "POST", reqparm);
			}
			catch
			{
			}
		}

		public void DeleteKey(string key)
		{
			if (script == "")
				DeleteKeyFromFile(key);
			else
				DeleteKeyFromServer(key);
		}

		private bool Save()
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

		private bool Load()
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

		public bool Exists()
		{
			return File.Exists(path);
		}

	}
}
