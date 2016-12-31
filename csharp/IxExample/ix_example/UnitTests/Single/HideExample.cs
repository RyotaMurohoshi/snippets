using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class HideExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L18
		[Test ()]
		public void TestHide ()
		{
			var hidedSequence = new List<int>{ 0, 1, 2 }.Hide ();
			Assert.True (hidedSequence.SequenceEqual (new []{ 0, 1, 2 }));
			Assert.True (hidedSequence is IEnumerable<int>);
			Assert.False (hidedSequence is List<int>);
		}
	}
}

