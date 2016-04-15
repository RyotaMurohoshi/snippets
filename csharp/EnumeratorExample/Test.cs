using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumeratorExample
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestEmptyArray ()
		{
			IEnumerable<int> enumerable = new int[0];
			IEnumerator<int> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);

			Assert.Throws<InvalidOperationException> (() => {
				var current = enumerator.Current;
			});
		}

		[Test ()]
		public void TestArray ()
		{
			IEnumerable<int> enumerable = new int[]{ 0, 1, 2 };
			IEnumerator<int> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);

			Assert.Throws<InvalidOperationException> (() => {
				var current = enumerator.Current;
			});
		}

		[Test ()]
		public void TestEmptyList ()
		{
			IEnumerable<int> enumerable = new List<int> ();
			IEnumerator<int> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);
			Assert.AreEqual (default(int), enumerator.Current);
		}

		[Test ()]
		public void TestList ()
		{
			IEnumerable<int> enumerable = new List<int> { 0, 1, 2 };
			IEnumerator<int> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);
			Assert.AreEqual (default(int), enumerator.Current);
		}

		[Test ()]
		public void TestEmptyDictionary ()
		{
			IEnumerable<KeyValuePair<string, int>> enumerable = new Dictionary<string, int> ();
			IEnumerator<KeyValuePair<string, int>> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);
			Assert.AreEqual (default(KeyValuePair<string, int>), enumerator.Current);
		}

		[Test ()]
		public void TestDictionary ()
		{
			IEnumerable<KeyValuePair<string, int>> enumerable = new Dictionary<string, int> {
				{ "a", 0 },
				{ "b", 1 },
				{ "c", 2 }
			};
			IEnumerator<KeyValuePair<string, int>> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);
			Assert.AreEqual (default(KeyValuePair<string, int>), enumerator.Current);
		}

		[Test ()]
		public void TestEmptySet ()
		{
			IEnumerable<int> enumerable = new HashSet<int> { };
			IEnumerator<int> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);
			Assert.AreEqual (default(int), enumerator.Current);
		}

		[Test ()]
		public void TestSet ()
		{
			IEnumerable<int> enumerable = new HashSet<int> { 0, 1, 2 };
			IEnumerator<int> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);
			Assert.AreEqual (default(int), enumerator.Current);
		}

		[Test ()]
		public void TestEmptyYield ()
		{
			IEnumerable<int> enumerable = YieldParams<int> ();
			IEnumerator<int> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);
			Assert.AreEqual (enumerable.LastOrDefault (), enumerator.Current);
		}

		[Test ()]
		public void TestYield ()
		{
			IEnumerable<int> enumerable = YieldParams<int> (0, 1, 2);
			IEnumerator<int> enumerator = enumerable.GetEnumerator ();
			MoveEnumeratorToNoNext (enumerator);
			Assert.AreEqual (enumerable.LastOrDefault (), enumerator.Current);
		}

		static void MoveEnumeratorToNoNext<T> (IEnumerator<T> enumerator)
		{
			while (enumerator.MoveNext ()) {
			}
		}

		static IEnumerable<T> YieldParams<T> (params T[] args)
		{
			foreach (T it in args) {
				yield return it;
			}
		}
	}
}

