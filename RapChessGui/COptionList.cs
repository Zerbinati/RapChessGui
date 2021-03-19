using System;
using System.Collections.Generic;
using NSUci;

namespace RapChessGui
{

	class COption
	{
		public string name = "";
		public string type = "";
		public string def = "";
		public string min = "";
		public string max = "";
	}

	class COptionList
	{
		readonly CUci uci = new CUci();
		public List<COption> list = new List<COption>();

		public COption GetOption(string name)
		{
			foreach (COption o in list)
				if (o.name == name)
					return o;
			return null;
		}

		public void Add(string msg)
		{
			uci.SetMsg(msg);
			if (uci.command == "option")
			{
				COption op = new COption();
				op.name = uci.GetValue("name", "type");
				if (GetOption(op.name) == null)
				{
					uci.GetValue("type", out op.type);
					uci.GetValue("default", out op.def);
					uci.GetValue("min", out op.min);
					uci.GetValue("max", out op.max);
					list.Add(op);
				}
			}
		}

		public void Sort()
		{
			list.Sort(delegate (COption o1, COption o2)
			{
				return String.Compare($"{o1.type} {o1.name}", $"{o2.type} {o2.name}");
			});
		}

	}
}
