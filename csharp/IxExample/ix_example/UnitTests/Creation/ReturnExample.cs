using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class ReturnExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L66
		[Test ()]
		public void TestReturn ()
		{
			Assert.True (EnumerableEx.Return (0).SequenceEqual (new []{ 0 }));
			Assert.True (EnumerableEx.Return ("test with return").SequenceEqual (new []{ "test with return" }));
		}
	}
}
