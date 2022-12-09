﻿using System;
using System.Collections.Generic;
using RapIni;

namespace RapChessGui
{

	public class CPlayer
	{
		public CBook book = null;
		public CEngine engine = null;
		public int tournament = 1;
		public int position = 0;
		public string name = String.Empty;
		public string elo = "1000";
		public CModeValue modeValue = new CModeValue();
		public CHisElo hisElo = new CHisElo();

		public string Book
		{
			get
			{
				if (book == null)
					return Global.none;
				return book.name;
			}
			set
			{
				book = FormChess.bookList.GetBookByName(value);
			}
		}

		public string Engine
		{
			get
			{
				if (engine == null)
					return Global.none;
				return engine.name;
			}
			set
			{
				engine = FormChess.engineList.GetEngineByName(value);
			}
		}

		public CPlayer()
		{
		}

		public CPlayer(string n)
		{
			name = n;
		}

		public void NewElo(int e)
		{
			hisElo.AddValue(e);
			elo = e.ToString();
			if (IsComputer())
				SaveToIni();
		}

		public string Check()
		{
			if (name == Global.human)
				return string.Empty;
			if (engine == null)
				return $"Please select {name} engine";
			if (!engine.FileExists())
				return $"Engine file {engine.file} not exists";
			if (!engine.SupportProtocol())
				return $"Please setup engine {engine.name} protocol";
			if (book == null)
				return String.Empty;
			if (!book.FileExists())
				return $"Book file {book.file} not exists";
			return string.Empty;
		}

		public bool Check(out string msg)
		{
			msg = Check();
			return msg == String.Empty;
		}

		public int GetEloLess()
		{
			if (FormChess.playerList.Count == 0)
				return 0;
			int levelDif = 2000 / FormChess.playerList.Count;
			if (levelDif < 10)
				levelDif = 10;
			int result = Convert.ToInt32(elo) - levelDif;
			if (result < CElo.eloMin)
				result = CElo.eloMin;
			return result;
		}

		public int GetEloMore()
		{
			int levelDif = 2000 / FormChess.playerList.Count;
			if (levelDif < 10)
				levelDif = 10;
			int result = Convert.ToInt32(elo) + levelDif;
			if (result > CElo.eloMax)
				result = CElo.eloMax;
			return result;
		}

		public int GetElo()
		{
			return Convert.ToInt32(elo);
		}

		public int GetDeltaElo()
		{
			int e = GetElo();
			return e - hisElo.EloAvg(e);
		}

		public void SetTournament(int t)
		{
			tournament = IsHuman() ? 0 : t;
		}

		public bool SetTournament(bool tb)
		{
			tb = IsComputer() & tb;
			int t = tb ? 1 : 0;
			if (tb && (tournament > 0))
				t = tournament;
			if (tournament != t)
			{
				tournament = t;
				SaveToIni();
				return true;
			}
			return false;
		}

		public bool IsComputer()
		{
			return engine != null;
		}

		public bool IsHuman()
		{
			return (engine == null) && (modeValue.level == CLevel.infinite);
		}

		public bool IsPlayable()
		{
			if (engine == null)
				return false;
			if (!engine.SupportProtocol())
				return false;
			return true;
		}

		public void SetPlayer(string name)
		{
			CPlayer p = FormChess.playerList.GetPlayerByName(name);
			if (p != null)
			{
				tournament = p.tournament;
				Engine = p.Engine;
				Book = p.Book;
				elo = p.elo;
				modeValue.level = p.modeValue.level;
				modeValue.value = p.modeValue.value;
				hisElo.Assign(p.hisElo);
			}
		}

		public void LoadFromIni()
		{
			tournament = CPlayerList.iniFile.ReadInt($"player>{name}>tournament", tournament);
			Engine = CPlayerList.iniFile.Read($"player>{name}>engine", Global.none);
			modeValue.SetLevel(CPlayerList.iniFile.Read($"player>{name}>mode", modeValue.GetLevel()));
			modeValue.value = CPlayerList.iniFile.ReadInt($"player>{name}>value", modeValue.value);
			Book = CPlayerList.iniFile.Read($"player>{name}>book", Global.none);
			elo = CPlayerList.iniFile.Read($"player>{name}>elo", elo);
			hisElo.LoadFromStr(CPlayerList.iniFile.Read($"player>{name}>history"));
		}

		public void SaveToIni()
		{
			name = GetName();
			if (hisElo.Count == 0)
			{
				int e = GetElo();
				hisElo.AddValue(e);
				hisElo.AddValue(e);
			}
			CPlayerList.iniFile.Write($"player>{name}>tournament", tournament);
			CPlayerList.iniFile.Write($"player>{name}>engine", Engine);
			CPlayerList.iniFile.Write($"player>{name}>mode", modeValue.GetLevel());
			CPlayerList.iniFile.Write($"player>{name}>value", modeValue.value);
			CPlayerList.iniFile.Write($"player>{name}>book", Book);
			CPlayerList.iniFile.Write($"player>{name}>elo", elo);
			CPlayerList.iniFile.Write($"player>{name}>history", hisElo.SaveToStr());
		}

		public string CreateName()
		{
			string n = Global.human;
			string b = string.Empty;
			string m = string.Empty;
			if (engine != null)
			{
				n = Engine;
				m = modeValue.ShortName();
			}
			if (book != null)
				b = $" {CData.MakeShort(Book)}";
			return $"{n}{b}{m}";
		}

		public string GetName()
		{
			if (name == string.Empty)
				return CreateName();
			return name;
		}

	}

	public class CPlayerList : List<CPlayer>
	{
		public static CRapIni iniFile = new CRapIni(@"Ini\players.ini");

		public void AddPlayer(CPlayer p)
		{
			p.name = p.GetName();
			int index = GetIndex(p.name);
			if (index >= 0)
				this[index] = p;
			else
				Add(p);
		}

		public int GetIndex(string name)
		{
			for (int n = 0; n < Count; n++)
			{
				CPlayer user = this[n];
				if (user.name == name)
					return n;
			}
			return -1;
		}

		public CPlayer GetPlayerByName(string name)
		{
			foreach (CPlayer p in this)
				if (p.name.ToLower() == name.ToLower())
					return p;
			return null;
		}

		public CPlayer GetPlayerComputer()
		{
			SortElo();
			foreach (CPlayer p in this)
				if (p.IsComputer())
					return p;
			return null;
		}

		public CPlayer GetPlayerByElo(int elo)
		{
			CPlayer p = CModeGame.humanPlayer;
			int bstDel = 10000;
			foreach (CPlayer cp in this)
			{
				if (cp.Engine == Global.none)
					continue;
				int curE = cp.GetElo();
				int curDel = Math.Abs(elo - curE);
				if (bstDel > curDel)
				{
					bstDel = curDel;
					p = cp;
				}
			}
			return p;
		}

		public void SortElo()
		{
			Sort(delegate (CPlayer p1, CPlayer p2)
			{
				int result = p2.GetElo() - p1.GetElo();
				if (result == 0)
					result = p2.hisElo.EloAvg() - p1.hisElo.EloAvg();
				return result;
			});
		}

		public void SortPosition(CPlayer player)
		{
			SortElo();
			FillPosition();
			int position = player.position;
			foreach (CPlayer p in this)
				p.position = Math.Abs(position - p.position);
			Sort(delegate (CPlayer p1, CPlayer p2)
			{
				return p1.position - p2.position;
			});
		}

		void CreateIni()
		{
			foreach (CEngine e in FormChess.engineList)
			{
				CPlayer p = new CPlayer();
				p.Engine = e.name;
				p.elo = e.elo;
				p.Book = CBookList.def;
				AddPlayer(p);
			}
			SaveToIni();
		}

		public int LoadFromIni()
		{
			Clear();
			List<string> pl = iniFile.ReadKeyList("player");
			foreach (string name in pl)
			{
				CPlayer p = new CPlayer(name);
				p.LoadFromIni();
				if (p.Engine != Global.none)
					Add(p);
			}
			if (Count == 0)
				CreateIni();
			return Count;
		}

		public void DeletePlayer(string name)
		{
			iniFile.DeleteKey($"player>{name}");
			int i = GetIndex(name);
			if (i >= 0)
				RemoveAt(i);
		}

		public void SaveToIni()
		{
			iniFile.DeleteKey("player");
			for (int n = Count - 1; n >= 0; n--)
			{
				CPlayer p = this[n];
				if ((p.engine == null)||!p.engine.Exists())
					RemoveAt(n);
				else
					p.SaveToIni();
			}
		}

		public void SaveToIni(CBook book)
		{
			foreach (CPlayer p in this)
				if (p.book == book)
					p.SaveToIni();
		}

		public void SaveToIni(CEngine engine)
		{
			foreach (CPlayer p in this)
				if (p.engine == engine)
					p.SaveToIni();
		}

		public int GetOptElo(double index)
		{
			int min = CModeTournamentP.minElo;
			int max = CModeTournamentP.maxElo;
			if (index < 0)
				index = 0;
			if (index >= Count)
				index = Count - 1;
			int range = max - min;
			index = Count - index;
			return min + Convert.ToInt32((range * index) / (Count + 1));
		}

		public CPlayer NextTournament(CPlayer p, bool rotate = true, bool back = false)
		{
			SortElo();
			int i = GetIndex(p.name);
			for (int n = 0; n < Count - 1; n++)
			{
				if (back)
					i--;
				else
					i++;
				if (rotate)
					i = (i + Count) % Count;
				else
					if ((i < 0) || (i >= Count))
					return null;
				p = this[i];
				if (p.tournament > 0)
					break;
			}
			return p;
		}

		public void SetEloDistance(CPlayer player)
		{
			SortElo();
			int elo = player.GetElo();
			for (int n = 0; n < Count; n++)
				this[n].position = Math.Abs(elo - this[n].GetElo());
			Sort(delegate (CPlayer p1, CPlayer p2)
			{
				return p1.position - p2.position;
			});
			FillPosition();
		}

		public void FillPosition()
		{
			for (int n = 0; n < Count; n++)
				this[n].position = n;
		}


	}
}
