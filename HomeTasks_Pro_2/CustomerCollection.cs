using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTasks_Pro_2
{
	internal class CustomerCollection : IEnumerable, IEnumerator
	{
		private CustomerCategoryProductPair[] pairs;
		private int count = 0;
		int position = -1;

        public int Count => count;

		public object Current => pairs[position];

		public CustomerCollection()
        {
			pairs = new CustomerCategoryProductPair[count];
		}

		public CustomerCategoryProductPair this[string key]
		{
			get
			{
				int index = IndexOfCustomer(key);
				if (index != -1)
					return pairs[index];
				else
					throw new ArgumentException();
			}
			set
			{
				int index = IndexOfCustomer(key);
				if (index != -1)
					pairs[index] = value;
				else
					throw new ArgumentException();
			}
		}

		public int IndexOfCustomer(string key)
		{
			int index = -1;

			for (int i = 0; i < pairs.Length; i++)
			{
				if (key == pairs[i].Customer)
				{
					index = i;
					break;
				}
			}

			return index;
		}

		public void Add(string customer, params string[] categoryProduct)
		{
			if (IndexOfCustomer(customer) == -1)
			{
				Array.Resize(ref pairs, count + 1);
				pairs[count] = new CustomerCategoryProductPair(customer, categoryProduct);
				count++;
			}
			else
			{
				throw new ArgumentException("Customer already exists.");
			}
		}

		public bool MoveNext()
		{
			if( position < pairs.Length - 1)
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

		public IEnumerator GetEnumerator()
		{
			return this;
		}

		public void Clear()
		{
			count = 0;
			pairs = new CustomerCategoryProductPair[count];	
		}

		public List<string> GetCategoriesByCustomer(string customer)
		{
			List<string> categories = new List<string>();

			foreach (var pair in pairs)
			{
				if (pair.Customer == customer)
				{
					categories.AddRange(pair.CategoryProduct);
				}
			}

			return categories;
		}

		public List<string> GetCustomersByCategory(string category)
		{
			List<string> customers = new List<string>();

			foreach (var pair in pairs)
			{
				if (Array.Exists(pair.CategoryProduct, c => c == category))
				{
					customers.Add(pair.Customer!);
				}
			}

			return customers;
		}

		public void Remove(string customer)
		{
			RemoveAt(IndexOfCustomer(customer));
		}

		public void RemoveAt(int index)
		{
			if(index < 0 || index >= count)
			{
				CustomerCategoryProductPair[] temp = new CustomerCategoryProductPair[pairs.Length - 1];
				for (int i = 0; i < pairs.Length; i++)
				{
					if (index == i)
						continue;
					temp[i] = pairs[i];
				}
				pairs = temp;
			}
			else
				throw new IndexOutOfRangeException();
		}

	}
}
