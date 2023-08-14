using System.Collections.Specialized;

namespace HomeTasks_Pro_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CustomerCollection customerCollection = new CustomerCollection
			{
				{ "Oleg", "Electronics", "Clothing", "Furniture" },
				{ "Vlad", "Electronics" },
				{ "Ivan", "Furniture", "Electronics"}
			};

			foreach (CustomerCategoryProductPair item in customerCollection)
			{
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 30));
            foreach (string item in customerCollection.GetCategoriesByCustomer("Ivan"))
			{
                Console.WriteLine(item);
            }

			Console.WriteLine(new string('-', 30));
			foreach (string item in customerCollection.GetCustomersByCategory("Electronics"))
			{
				Console.WriteLine(item);
			}
		}
	}
}