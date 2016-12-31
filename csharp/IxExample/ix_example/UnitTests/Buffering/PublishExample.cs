using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class PublishExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Buffering.cs#L150
		[Test ()]
		public void TestPublish ()
		{
			IBuffer<int> buffer = new List<int>{ 0, 1, 2, 3, 4, 5 }.Publish ();
			var enumeratorA = buffer.GetEnumerator ();

			enumeratorA.MoveNext ();
			Assert.AreEqual (0, enumeratorA.Current);

			enumeratorA.MoveNext ();
			Assert.AreEqual (1, enumeratorA.Current);

			enumeratorA.MoveNext ();
			Assert.AreEqual (2, enumeratorA.Current);
			var enumeratorB = buffer.GetEnumerator ();

			enumeratorA.MoveNext ();
			enumeratorB.MoveNext ();
			Assert.AreEqual (3, enumeratorA.Current);
			Assert.AreEqual (3, enumeratorB.Current);

			enumeratorA.MoveNext ();
			enumeratorB.MoveNext ();
			Assert.AreEqual (4, enumeratorA.Current);
			Assert.AreEqual (4, enumeratorB.Current);

			enumeratorA.MoveNext ();
			enumeratorB.MoveNext ();
			Assert.AreEqual (5, enumeratorA.Current);
			Assert.AreEqual (5, enumeratorB.Current);

			Assert.False (enumeratorA.MoveNext ());
			Assert.False (enumeratorB.MoveNext ());
		}
	}
}
