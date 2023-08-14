using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	internal class MyOrderedDictionary<TKey, TValue>
	{
		private List<KeyValuePair<TKey, TValue>> data = new List<KeyValuePair<TKey, TValue>>();

		public void Add(TKey key, TValue value)
		{
			var newItem = new KeyValuePair<TKey, TValue>(key, value);
			int index = data.BinarySearch(newItem, new KeyValuePairComparer());

			if (index < 0)
				index = ~index;

			data.Insert(index, newItem);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return data.GetEnumerator();
		}

		private class KeyValuePairComparer : IComparer<KeyValuePair<TKey, TValue>>
		{
			public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
			{
				return Comparer<TKey>.Default.Compare(x.Key, y.Key);
			}
		}

		public TValue GetValueByKey(TKey key)
		{
			foreach (var pair in data)
			{
				if (EqualityComparer<TKey>.Default.Equals(pair.Key, key))
				{
					return pair.Value;
				}
			}
			throw new KeyNotFoundException();
		}

		public List<TKey> GetKeysByValue(TValue value)
		{
			var keys = new List<TKey>();
			foreach (var pair in data)
			{
				if (EqualityComparer<TValue>.Default.Equals(pair.Value, value))
				{
					keys.Add(pair.Key);
				}
			}
			return keys;
		}
	}

}
