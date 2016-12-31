using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class IsEmptyExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Aggregates.cs#L19
		[Test ()]
		public void TestIsEmpty ()
		{
			Assert.True (new int[]{ }.IsEmpty ());
			Assert.False (new int[]{ 1, 2, 3 }.IsEmpty ());
		}
	}
}


