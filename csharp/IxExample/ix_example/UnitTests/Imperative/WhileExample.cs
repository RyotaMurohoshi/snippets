using NUnit.Framework;
using System.Linq;
using System;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class WhileExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L18
		[Test ()]
		public void TestWhile ()
		{
			var result = EnumerableEx
				.While (CountTrue (3), new int[]{ 1, 2, 3 })
				.SequenceEqual (new int[]{ 1, 2, 3, 1, 2, 3, 1, 2, 3 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L18
		[Test ()]
		public void TestWhileEmptySequence ()
		{
			var result = EnumerableEx
				.While (CountTrue (3), new int[]{ })
				.SequenceEqual (new int[]{ });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L18
		[Test ()]
		public void TestWhileEmptyFunc ()
		{
			var result = EnumerableEx
				.While (CountTrue (0), new int[]{ 1, 2, 3 })
				.SequenceEqual (new int[]{ });
			Assert.True (result);
		}

		Func<bool> CountTrue(int count)
		{
			int counter = 0;
			return () => counter++ < count;
		}
	}
}
