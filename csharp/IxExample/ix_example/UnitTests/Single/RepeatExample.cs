using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public partial class RepeatExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L638
		[Test ()]
		public void TestRepeat_EnumerableT ()
		{
			IEnumerable <int> enumerable = new []{ 0, 1, 2 }.Repeat ();
			Assert.That (enumerable.ElementAt (0), Is.EqualTo (0));
			Assert.That (enumerable.ElementAt (1), Is.EqualTo (1));
			Assert.That (enumerable.ElementAt (2), Is.EqualTo (2));
			Assert.That (enumerable.ElementAt (3), Is.EqualTo (0));
			Assert.That (enumerable.ElementAt (4), Is.EqualTo (1));
			Assert.That (enumerable.ElementAt (5), Is.EqualTo (2));
			Assert.That (enumerable.ElementAt (6), Is.EqualTo (0));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L660
		[Test ()]
		public void TestRepeat_EnumerableT_Int ()
		{
			IEnumerable <int> enumerable = new []{ 0, 1, 2 }.Repeat (count: 3);
			Assert.True (enumerable.SequenceEqual (new []{ 0, 1, 2, 0, 1, 2, 0, 1, 2 }));
		}
	}
}


