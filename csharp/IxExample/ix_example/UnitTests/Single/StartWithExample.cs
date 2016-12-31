using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class StartWithExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L610
		[Test ()]
		public void TestStartWith ()
		{
			Assert.True (new []{1, 2, 3}.StartWith (0).SequenceEqual (new []{0, 1, 2, 3}));
			Assert.True (new []{2, 3}.StartWith (0, 1).SequenceEqual (new []{0, 1, 2, 3}));
			Assert.True (new []{0, 1, 2, 3}.StartWith ().SequenceEqual (new []{0, 1, 2, 3}));
			Assert.True (new int[]{}.StartWith (0, 1, 2, 3).SequenceEqual (new []{0, 1, 2, 3}));
		}
	}
}
