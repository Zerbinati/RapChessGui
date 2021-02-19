using System;

namespace NSUci
{
	class CUci
	{
		public string command;
		public string[] tokens;

		public int GetIndex(string key, int def)
		{
			for (int n = 0; n < tokens.Length; n++)
			{
				if (tokens[n] == key)
				{
					return n + 1;
				}
			}
			return def;
		}

		public int GetInt(string key, int def)
		{
			for (int n = 0; n < tokens.Length - 1; n++)
			{
				if (tokens[n] == key)
				{
					return Int32.Parse(tokens[n + 1]);
				}
			}
			return def;
		}

		public bool GetValue(string name, out string value)
		{
			int i = GetIndex(name, tokens.Length);
			if (i < tokens.Length)
			{
				value = tokens[i];
				return true;
			}
			value = "";
			return false;
		}

		public bool GetValue(string name, string end,out string value)
		{
			value = "";
			int i = GetIndex(name, tokens.Length);
			for(int n = i; n < tokens.Length; n++)
			{
				string t = tokens[n];
				if (t == end)
					break;
				value += $" {t}";
			}
			value = value.Trim();
			return value != "";
		}

		public string Last()
		{
			if (tokens.Length > 0)
				return tokens[tokens.Length - 1];
			return "";
		}

		public void SetMsg(string msg)
		{
			if (msg == null)
				msg = "";
			tokens = msg.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			command = tokens.Length > 0 ? tokens[0] : "";
		}
	}
}
