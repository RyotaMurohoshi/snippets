using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class MemoizeExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Buffering.cs#L323
		[Test ()]
		public void TestMemoize ()
		{
			var num = -1;
			var list = new List<int>{ 0, 1, 2 };
			var buffer = list.Do (n => num = n).Memoize ();
			var enumeratorA = buffer.GetEnumerator ();

			enumeratorA.MoveNext ();
			Assert.AreEqual (0, enumeratorA.Current);
			Assert.AreEqual (0, num);

			enumeratorA.MoveNext ();
			Assert.AreEqual (1, enumeratorA.Current);
			Assert.AreEqual (1, num);

			enumeratorA.MoveNext ();
			Assert.AreEqual (2, enumeratorA.Current);
			Assert.AreEqual (2, num);

			list [1] = -1;

			var enumeratorB = buffer.GetEnumerator ();

			enumeratorB.MoveNext ();
			Assert.AreEqual (0, enumeratorB.Current);
			Assert.AreEqual (2, num);

			enumeratorB.MoveNext ();
			Assert.AreEqual (1, enumeratorB.Current);
			Assert.AreEqual (2, num);

			enumeratorB.MoveNext ();
			Assert.AreEqual (2, enumeratorB.Current);
			Assert.AreEqual (2, num);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Buffering.cs#L323
		[Test ()]
		public void TestMemoizeThrow ()
		{
			var buffer = new List<int>{ 0, 1, 2 }.Memoize (2);
			buffer.GetEnumerator ().MoveNext ();
			buffer.GetEnumerator ().MoveNext ();

			Assert.Throws<InvalidOperationException> (() => {
				buffer.GetEnumerator ().MoveNext ();	
			});
		}

		[Test ()]
		public void MemoizeLambda ()
		{
			var num = 0;
			var sequencce = Enumerable
				.Range (0, int.MaxValue)
				.Do (_ => num++)
				.Memoize (xs => xs.Zip (xs, Tuple.Create).Take (3));
			var result = sequencce.SequenceEqual (new [] {
				Tuple.Create (0, 0),
				Tuple.Create (1, 1),
				Tuple.Create (2, 2)
			});
			Assert.True (result);
			Assert.AreEqual (3, num);
		}
	}
}
