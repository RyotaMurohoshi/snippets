using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public partial class RepeatExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L172
		[Test ()]
		public void TestRepeat_T ()
		{
			IEnumerable <int> enumerable = EnumerableEx.Repeat (0);
			Assert.That (enumerable.ElementAt (0), Is.EqualTo (0));
			Assert.That (enumerable.ElementAt (1), Is.EqualTo (0));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L185
		[Test ()]
		public void TestRepeat_T_Int ()
		{
			IEnumerable <int> enumerable = EnumerableEx.Repeat (1, 3);
			Assert.True (enumerable.SequenceEqual (new[]{ 1, 1, 1 }));
		}
	}
}


