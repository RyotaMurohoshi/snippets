using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class ShareExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Buffering.cs#L150
		[Test ()]
		public void TestShare ()
		{
			IBuffer<int> buffer = new List<int>{ 0, 1, 2, 3, 4, 5 }.Share ();
			var enumeratorA = buffer.GetEnumerator ();

			enumeratorA.MoveNext ();
			Assert.AreEqual (0, enumeratorA.Current);

			enumeratorA.MoveNext ();
			Assert.AreEqual (1, enumeratorA.Current);

			enumeratorA.MoveNext ();
			var enumeratorB = buffer.GetEnumerator ();
			enumeratorB.MoveNext ();
			Assert.AreEqual (2, enumeratorA.Current);
			Assert.AreEqual (3, enumeratorB.Current);

			enumeratorA.MoveNext ();
			enumeratorB.MoveNext ();
			Assert.AreEqual (4, enumeratorA.Current);
			Assert.AreEqual (5, enumeratorB.Current);

			Assert.False (enumeratorA.MoveNext ());
			Assert.False (enumeratorB.MoveNext ());
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Buffering.cs#L150
		[Test ()]
		public void TestShareLikeBuffer ()
		{
			var sequence = Enumerable
				.Range (0, 10)
				.Share (xs => xs.Zip (xs, System.Tuple.Create));

			var result = sequence.SequenceEqual (new [] {
				Tuple.Create (0, 1),
				Tuple.Create (2, 3),
				Tuple.Create (4, 5),
				Tuple.Create (6, 7),
				Tuple.Create (8, 9)
			});

			Assert.True (result);
		}
	}
}
