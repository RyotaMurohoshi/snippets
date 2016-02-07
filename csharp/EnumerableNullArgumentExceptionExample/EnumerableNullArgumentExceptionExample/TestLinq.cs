using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EnumerableNullArgumentExceptionExample
{
	[TestFixture ()]
	public class TestLinq
	{
		[Test ()]
		public void TestSelect ()
		{
			IEnumerable<int> intEnumerable = new int[]{ 3, 1, 4, 1, 5, 9, 2 };
			Func<int, int> nullSelector = null;

			Assert.Catch<ArgumentNullException> (() => {
				intEnumerable.Select (nullSelector);
			});

			Assert.Catch<ArgumentNullException> (() => {
				foreach (int num in intEnumerable.Select (nullSelector)) {
					;
				}
			});
		}

		[Test ()]
		public void TestWhere ()
		{
			IEnumerable<int> intEnumerable = new int[]{ 3, 1, 4, 1, 5, 9, 2 };
			Func<int, bool> nullPredicate = null;

			Assert.Catch<ArgumentNullException> (() => {
				intEnumerable.Where (nullPredicate);
			});

			Assert.Catch<ArgumentNullException> (() => {
				foreach (int num in intEnumerable.Where (nullPredicate)) {
					;
				}
			});
		}
	}
}

