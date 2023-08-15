using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	internal class MyOrderedDictionary<TKey, TValue> : IEnumerable, IEnumerator where TValue : IComparable<TValue>
	{
		TKey[] keys;
		TValue[] values;

		int position = -1;
		int count = 0;

		public MyOrderedDictionary()
		{
			keys = new TKey[count];
			values = new TValue[count];
		}

		public void Add(TKey key, TValue value)
		{
			if (IndexOfKey(key) == -1)
			{
				Array.Resize(ref keys, count + 1);
				Array.Resize(ref values, count + 1);
				keys[count] = key;
				values[count] = value;
				count++;
			}
			else
				throw new ArgumentException();
		}

		public TValue this[int index]
		{
			get
			{
				if (index >= 0 && index < count)
					return values[index];
				else
					throw new IndexOutOfRangeException();
			}
			set
			{
				if (index >= 0 && index < count)
					values[index] = value;
				else
					throw new IndexOutOfRangeException();
			}
		}


		public TValue this[TKey key]
		{
			get
			{
				int index = IndexOfKey(key);
				if (index != -1)
					return values[index];
				else
					throw new IndexOutOfRangeException();
			}
			set
			{
				int index = IndexOfKey(key);
				if (index != -1)
					values[index] = value;
				else
					throw new IndexOutOfRangeException();
			}
		}

		public int IndexOfKey(TKey key)
		{
			int index = -1;

			for (int i = 0; i < keys.Length; i++)
			{
				if (EqualityComparer<TKey>.Default.Equals(key, keys[i]))
				{
					index = i;
					break;
				}
			}

			return index;
		}

		public int CompareValues(TValue value1, TValue value2)
		{
			return value1.CompareTo(value2);
		}

		public int CompareValuesByIndex(int index1, int index2)
		{
			if (index1 >= 0 && index1 < count && index2 >= 0 && index2 < count)
			{
				return CompareValues(values[index1], values[index2]);
			}
			throw new IndexOutOfRangeException();
		}


		public object Current => values[position]!;

		public bool IsFixedSize => false;

		public bool IsReadOnly => false;

		public bool IsSynchronized => false;

		public object SyncRoot => false;

		public ICollection Keys => keys;

		public ICollection Values => values;

		public int Count => count;

		public void Clear()
		{
			count = 0;
			keys = new TKey[count];
			values = new TValue[count];
		}

		public IEnumerator GetEnumerator()
		{
			return this;
		}

		public bool MoveNext()
		{
			if (position < keys.Length - 1)
			{
				position++;
				return true;
			}
			Reset();
			return false;
		}

		public void Remove(TKey key)
		{
			RemoveAt(IndexOfKey(key));
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= count)
			{
				TKey[] tempKyes = new TKey[keys.Length - 1];
				TValue[] tempValues = new TValue[values.Length - 1];
				for (int i = 0; i < keys.Length; i++)
				{
					if (index == i)
						continue;
					tempKyes[i] = keys[i];
					tempValues[i] = values[i];
				}
				count--;
				keys = tempKyes;
				values = tempValues;
			}
			else
				throw new IndexOutOfRangeException();
		}

		public void Reset()
		{
			position = -1;
		}
	}

}
