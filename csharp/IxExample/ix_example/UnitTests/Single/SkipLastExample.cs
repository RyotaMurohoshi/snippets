using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class SkipLastExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L610
		[Test ()]
		public void TestSkipLast ()
		{
			Assert.True (new []{ "a", "b", "c", "d", "e" }.SkipLast (3).SequenceEqual (new string[]{ "a", "b" }));
			Assert.True (new []{ "a", "b", "c", "d", "e" }.SkipLast (5).SequenceEqual (new string[]{ }));
			Assert.True (new []{ "a", "b", "c", "d", "e" }.SkipLast (6).SequenceEqual (new string[]{ }));
		}
	}
}
