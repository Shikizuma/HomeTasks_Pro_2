using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	internal class BalanceCollection : IEnumerator, IEnumerable
	{
		CompanyAccount[] accounts;
		int count = 0;
		int position = -1;
		public BalanceCollection()
		{
			accounts = new CompanyAccount[count];
		}

		public int Count => count;

		public object Current => accounts[position];


		public CompanyAccount this[string nameCompany]
		{
			get
			{
				int index = IndexOfCompany(nameCompany);
				if (index != -1)
					return accounts[index];
				else
					throw new ArgumentException();
			}
			set
			{
				int index = IndexOfCompany(nameCompany);
				if (index != -1)
					accounts[index] = value;
				else
					throw new ArgumentException();
			}
		}

		public int IndexOfCompany(string nameCompany)
		{
			int index = -1;

			for (int i = 0; i < accounts.Length; i++)
			{
				if (nameCompany == accounts[i].NameCompany)
				{
					index = i;
					break;
				}
			}

			return index;
		}


		public void Add(CompanyAccount company)
		{
			if (IndexOfCompany(company.NameCompany) == -1)
			{
				Array.Resize(ref accounts, count + 1);
				accounts[count] = new CompanyAccount(company.NameCompany, company.Balance);
				count++;
			}
			else
			{
				throw new ArgumentException("Company already exists.");
			}
		}

		public void Remove(string nameCompany)
		{
			RemoveAt(IndexOfCompany(nameCompany));
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= count)
			{
				CompanyAccount[] temp = new CompanyAccount[accounts.Length - 1];
				for (int i = 0; i < accounts.Length; i++)
				{
					if (index == i)
						continue;
					temp[i] = accounts[i];
				}
				accounts = temp;
			}
			else
				throw new IndexOutOfRangeException();
		}

		public void Clear()
		{
			count = 0;
			accounts = new CompanyAccount[count];
		}

		public IEnumerator GetEnumerator()
		{
			return this;
		}

		public bool MoveNext()
		{
			if (position < accounts.Length - 1)
			{
				position++;
				return true;
			}
			Reset();
			return false;
		}

		public void Reset()
		{
			position = -1;
		}
	}
}
