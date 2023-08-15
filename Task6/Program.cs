namespace Task6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			SortedList<string, string> sortedList = new SortedList<string, string>();

			sortedList.Add("apple", "яблуко");
			sortedList.Add("banana", "банан");
			sortedList.Add("orange", "апельсин");

			foreach (KeyValuePair<string, string> kvp in sortedList)
			{
				Console.WriteLine($"{kvp.Key}: {kvp.Value}");
			}
            Console.WriteLine(new string('-', 30));
            DescendingComparer descendingComparer = new DescendingComparer();
			SortedList<string, string> reversedSortedList = new SortedList<string, string>(sortedList, descendingComparer);

			foreach (KeyValuePair<string, string> kvp in reversedSortedList)
			{
				Console.WriteLine($"{kvp.Key}: {kvp.Value}");
			}
		}
	}
}