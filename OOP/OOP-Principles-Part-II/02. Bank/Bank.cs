using System;
using System.Collections.Generic;

namespace Bank
{
	public class Bank
	{
		public string Name {get; private set;}
		public List<Account> Accounts {get; set;}
		public Bank(string name)
		{
			this.Name = name;
			this.Accounts = new List<Account>();
		}
	}
}