using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class IgnoreElementsxample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L260
		[Test ()]
		public void TestIgnoreElements ()
		{
			Assert.True (new []{ 1, 2, 3 }.IgnoreElements ().SequenceEqual (new int[]{ }));

			Assert.Throws<System.InvalidOperationException> (() => {
				foreach (int num in FailWithEnumerable().IgnoreElements()) {
					;
				}
			});
		}

		IEnumerable<int> FailWithEnumerable ()
		{
			throw new System.InvalidOperationException ("Invalid state.");
		}
	}
}

