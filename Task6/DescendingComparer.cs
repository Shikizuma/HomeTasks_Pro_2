using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
	internal class DescendingComparer : IComparer<object>
	{

		public int Compare(object? x, object? y)
		{
			return Comparer.Default.Compare(y, x);
		}
	}
}
