using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class DeferExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L99
		[Test ()]
		public void TestDefer ()
		{
			var result = EnumerableEx.Defer (() => new int[]{ 1, 2, 3 }).SequenceEqual (new int[]{ 1, 2, 3 });
			Assert.True (result);
		}

		[Test ()]
		public void TestDeferNoException ()
		{
			var result = EnumerableEx
				.Defer (() => new int[]{ 1, 2, 3 }.Concat(ThrowExceptionSequence()))
				.Take(4)
				.SequenceEqual (new int[]{ 1, 2, 3, 0 });
			Assert.True (result);
		}

		[Test ()]
		public void TestDeferException ()
		{
			Assert.Catch<System.Exception> (() => {
				EnumerableEx
					.Defer (() => ThrowExceptionSequence())
					.ForEach(num => {;});
			});
		}

		IEnumerable<int> ThrowExceptionSequence()
		{
			yield return 0;
			throw new System.Exception ();
		}
	}
}