using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class TakeLastExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L573
		[Test ()]
		public void TestTakeLast ()
		{
			Assert.True (new []{ "a", "b", "c", "d", "e" }.TakeLast (3).SequenceEqual (new []{ "c", "d", "e" }));
			Assert.True (new []{ "a", "b", "c", "d", "e" }.TakeLast (5).SequenceEqual (new []{ "a", "b", "c", "d", "e" }));
			Assert.True (new []{ "a", "b", "c", "d", "e" }.TakeLast (6).SequenceEqual (new []{ "a", "b", "c", "d", "e" }));
		}
	}
}
