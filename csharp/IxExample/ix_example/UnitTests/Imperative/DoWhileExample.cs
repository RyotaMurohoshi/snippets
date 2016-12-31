using NUnit.Framework;
using System.Linq;
using System;

namespace IxExample
{
	[TestFixture ()]
	public class DoWhileExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L78
		[Test ()]
		public void TestDoWhile ()
		{
			var result = EnumerableEx
				.DoWhile (new int[]{ 1, 2, 3 }, CountTrue (3))
				.SequenceEqual (new int[]{ 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L78
		[Test ()]
		public void TestDoWhileEmptySequence ()
		{
			var result = EnumerableEx
				.DoWhile (new int[]{ }, CountTrue (3))
				.SequenceEqual (new int[]{ });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L78
		[Test ()]
		public void TestWhileEmptyFunc ()
		{
			var result = EnumerableEx
				.DoWhile (new int[]{ 1, 2, 3 }, CountTrue (0))
				.SequenceEqual (new []{ 1, 2, 3 });
			Assert.True (result);
		}

		Func<bool> CountTrue(int count)
		{
			int counter = 0;
			return () => counter++ < count;
		}
	}
}
