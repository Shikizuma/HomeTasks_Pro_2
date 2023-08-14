namespace Task3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//System Collection || List
			List<AccountAvailableAmountPair> accountPairs = new List<AccountAvailableAmountPair>();
			accountPairs.Add(new AccountAvailableAmountPair { EnterpriseAccount = 1000, AvailableAmount = 500 });
			accountPairs.Add(new AccountAvailableAmountPair { EnterpriseAccount = 2000, AvailableAmount = 1500 });

			//System Collection || Dictionary
			Dictionary<string, AccountAvailableAmountPair> accountPairsD = new Dictionary<string, AccountAvailableAmountPair>();
			accountPairsD.Add("Company A", new AccountAvailableAmountPair { EnterpriseAccount = 1000, AvailableAmount = 500 });
			accountPairsD.Add("Company B", new AccountAvailableAmountPair { EnterpriseAccount = 2000, AvailableAmount = 2000 });

			//Custom Collection
			BalanceCollection balanceCollection = new BalanceCollection();
			balanceCollection.Add(new CompanyAccount("Company A", new AccountAvailableAmountPair { EnterpriseAccount = 1000, AvailableAmount = 500.5 }));
			balanceCollection.Add(new CompanyAccount("Company B", new AccountAvailableAmountPair { EnterpriseAccount = 2000, AvailableAmount = 1999.9 }));
			foreach (CompanyAccount item in balanceCollection)
			{
                Console.WriteLine(item);
            }
		}
	}
}