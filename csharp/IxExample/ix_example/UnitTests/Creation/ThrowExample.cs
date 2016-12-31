using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class ThrowExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L77
		[Test ()]
		public void TestThrow ()
		{
			var sequence = EnumerableEx.Throw<int>(new ExampleException());

			Assert.Catch<ExampleException> (() => {
				foreach (var num in sequence) {
					Assert.Fail();
				}
			});
		}
	}

	class ExampleException : Exception
	{

	}
}

