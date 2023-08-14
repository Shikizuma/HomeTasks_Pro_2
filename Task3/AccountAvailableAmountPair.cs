using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class AccountAvailableAmountPair
	{
		private int enterpriseAccount;
		public int EnterpriseAccount
		{
			get 
			{ 
				return enterpriseAccount; 
			}
			set 
			{ 
				enterpriseAccount = value; 
				CheckAvailableAmount(); 
			}
		}

		private double availableAmount;
		public double AvailableAmount
		{
			get 
			{ 
				return availableAmount; 
			}
			set
			{
				availableAmount = value;
				CheckAvailableAmount();
			}
		}

		private void CheckAvailableAmount()
		{
			if (availableAmount > enterpriseAccount)
			{
				throw new ArgumentException("Available amount cannot be greater than enterprise account.");
			}
		}
    }
}
