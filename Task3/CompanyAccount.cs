using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class CompanyAccount
	{
        public string NameCompany { get; set; }
        public AccountAvailableAmountPair Balance { get; set; }

        public CompanyAccount(string nameCompany, AccountAvailableAmountPair balance)
        {
			NameCompany = nameCompany;
            Balance = balance;
		}

		public override string ToString()
		{
			return $"Company: {NameCompany} has a balance: {Balance.EnterpriseAccount} - {Balance.AvailableAmount}";
		}
	}
}
