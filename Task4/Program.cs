using System.Collections.Specialized;

namespace Task4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MyOrderedDictionary<int, string> orderedDict = new MyOrderedDictionary<int, string>();
			orderedDict.Add(3, "Three");
			orderedDict.Add(1, "One");
			orderedDict.Add(2, "Two");

			foreach (var kvp in orderedDict)
			{
				Console.WriteLine($"{kvp.Key}: {kvp.Value}");
			}
		}
	}
}