using System.Collections;
using System.Collections.Specialized;

namespace Task4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MyOrderedDictionary<string, string> dictionary = new MyOrderedDictionary<string, string>();
			dictionary.Add("one", "A");
			dictionary.Add("two", "a");
			dictionary.Add("three", "B");

			int comparisonResult = dictionary.CompareValuesByIndex(2, 0);
			if (comparisonResult < 0)
			{
				Console.WriteLine("Value at index 0 is less than value at index 1.");
			}
			else if (comparisonResult > 0)
			{
				Console.WriteLine("Value at index 0 is greater than value at index 1.");
			}
			else
			{
				Console.WriteLine("Value at index 0 is equal to value at index 1.");
			}
		}
	}
}