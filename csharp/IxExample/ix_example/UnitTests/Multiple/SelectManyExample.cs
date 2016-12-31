using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class SelectManyExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Multiple.cs#L54		[Test ()]
		[Test ()]
		public void TestSelectMany ()
		{
			IEnumerable <string> stringEnumerable = new int[]{ 1, 2 }.SelectMany (new []{ "a", "b", "c" });
			Assert.True (stringEnumerable.SequenceEqual (new []{ "a", "b", "c", "a", "b", "c" }));
		}
	}
}
