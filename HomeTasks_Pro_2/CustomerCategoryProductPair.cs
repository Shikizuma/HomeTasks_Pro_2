using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTasks_Pro_2
{
	internal class CustomerCategoryProductPair
	{
		public string? Customer { get; set; }
		public string[] CategoryProduct { get; set; }

		public CustomerCategoryProductPair(string customer, string[] categoryProduct)
		{
			Customer = customer;
			CategoryProduct = categoryProduct;
		}

		public override string ToString()
		{
            string result = "Customer: " + Customer + " have these categories of products: ";
			foreach (string item in CategoryProduct)
			{
				result += item;
				result += " | ";
			}
            return result;
		}
	}
}
