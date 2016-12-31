using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class ForEachExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L38
		[Test ()]
		public void TestForEach ()
		{
			var index = 0;
			var list = new List<int>{ 0, 1, 2 };
			list.ForEach (it => {
				Assert.AreEqual (list [index++], it);
			});

			Assert.AreEqual (3, index);
		}
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L55
		[Test ()]
		public void TestForEachWithIndex ()
		{
			var index = 0;
			var list = new List<int>{ 0, 1, 2 };
			list.ForEach ((it, i) => {
				var expectedIndex = index++;
				Assert.AreEqual (list [expectedIndex], it);
				Assert.AreEqual (expectedIndex, i);
			});

			Assert.AreEqual (3, index);
		}
	}
}
