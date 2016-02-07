using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EnumerableNullArgumentExceptionExample
{
	[TestFixture ()]
	public class TestMyLinq
	{
		[Test ()]
		public void TestMap ()
		{
			IEnumerable<int> intEnumerable = new int[]{ 3, 1, 4, 1, 5, 9, 2 };
			Func<int, int> nullSelector = null;

			Assert.Catch<ArgumentNullException> (() => {
				intEnumerable.Map (nullSelector);
			});

			Assert.Catch<ArgumentNullException> (() => {
				foreach (int num in intEnumerable.Map (nullSelector)) {
					;
				}
			});
		}

		[Test ()]
		public void TestFilter ()
		{
			IEnumerable<int> intEnumerable = new int[]{ 3, 1, 4, 1, 5, 9, 2 };
			Func<int, bool> nullPredicate = null;

			Assert.Catch<ArgumentNullException> (() => {
				intEnumerable.Filter (nullPredicate);
			});

			Assert.Catch<ArgumentNullException> (() => {
				foreach (int num in intEnumerable.Filter (nullPredicate)) {
					;
				}
			});
		}
	}

	public static class MyEnumerableBad
	{
		public static IEnumerable<TSource> Filter<TSource> (this IEnumerable<TSource> source, Func<TSource,bool> predicate)
		{
			if (source == null)
				throw new ArgumentNullException ("source");
			if (predicate == null)
				throw new ArgumentNullException ("predicate");

			return source.Filter_ (predicate);
		}

		private static  IEnumerable<TSource> Filter_<TSource> (this IEnumerable<TSource> source, Func<TSource,bool> predicate)
		{
			foreach (TSource element in source) {
				if (predicate (element)) {
					yield return element;
				}
			}
		}

		public static IEnumerable<TResult> Map<TSource, TResult> (this IEnumerable<TSource> source, Func<TSource,TResult> selector)
		{
			if (source == null)
				throw new ArgumentNullException ("source");
			if (selector == null)
				throw new ArgumentNullException ("selector");

			return source.Map_ (selector);
		}

		public static IEnumerable<TResult> Map_<TSource, TResult> (this IEnumerable<TSource> source, Func<TSource,TResult> selector)
		{
			foreach (TSource element in source) {
				yield return selector (element);
			}
		}
	}
}



