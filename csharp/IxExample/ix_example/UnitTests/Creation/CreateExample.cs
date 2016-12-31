using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class CreateExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L15
		[Test ()]
		public void TestCreate ()
		{
			var sequence = EnumerableEx.Create (() => new List<int>{ 1, 2, 3 }.GetEnumerator ());
			var result = sequence.SequenceEqual (new int[]{ 1, 2, 3 });
			Assert.True (result);
		}
	}
}
