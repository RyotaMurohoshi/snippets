using System;
using System.Linq;
using System.Collections.Generic;

namespace YieldExample
{
	class MainClass
	{
		static int ShowAndReturn (int num)
		{
			Console.WriteLine ($"  in ShowAndReturn:{num}");
			return num;
		}

		public static void Main (string[] args)
		{
			IEnumerable<int> intEnumerable = new int[]{ 3, 1, 4, 1, 5, 9, 2 }.Select (ShowAndReturn);
			Console.WriteLine ("after select");
			foreach (int num in intEnumerable) {
				Console.WriteLine ($"    in foreach loop:{num}");
			}
		}
	}
}
