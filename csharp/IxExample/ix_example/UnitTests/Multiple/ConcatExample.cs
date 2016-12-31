using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class ConcatExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Multiple.cs#L17
		[Test ()]
		public void Concat_IEnumerableIEnumerableT ()
		{
			{
				IEnumerable <int> intEnumerable = new int[][]{ new int[]{ 3, 1, 4 }, new int[]{ 1 }, new int[]{ 5, 9, 2 } }.Concat ();
				Assert.True (intEnumerable.SequenceEqual (new []{ 3, 1, 4, 1, 5, 9, 2 }));
			}

			{
				IEnumerable <int> intEnumerable = new List<List<int>> { new List<int>{ 3, 1, 4 }, new List<int>{ 1 }, new List<int> { 5, 9, 2 }}.Concat ();
				Assert.True (intEnumerable.SequenceEqual (new []{ 3, 1, 4, 1, 5, 9, 2 }));
			}

			{
				IEnumerable <int> intEnumerable = new List<IEnumerable<int>> { new int[]{ 3, 1, 4 }, new List<int>{ 1 },new int[] { 5, 9, 2 }}.Concat ();
				Assert.True (intEnumerable.SequenceEqual (new []{ 3, 1, 4, 1, 5, 9, 2 }));
			}
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Multiple.cs#L31
		[Test ()]
		public void Concat_ParamsIEnumerableT ()
		{
			{
				IEnumerable <int> intEnumerable = EnumerableEx.Concat<int> (new int[]{ 3, 1, 4, 1, 5, 9, 2 });
				Assert.True (intEnumerable.SequenceEqual (new []{ 3, 1, 4, 1, 5, 9, 2 }));
			}

			{
				IEnumerable <int> intEnumerable = EnumerableEx.Concat<int> (new List<int>{ 3, 1, 4, 1, 5, 9, 2 });
				Assert.True (intEnumerable.SequenceEqual (new []{ 3, 1, 4, 1, 5, 9, 2 }));
			}

			{
				IEnumerable <int> intEnumerable = EnumerableEx.Concat (new int[]{ 3, 1, 4 }, new int[]{ 1 }, new int[]{ 5, 9, 2 });
				Assert.True (intEnumerable.SequenceEqual (new []{ 3, 1, 4, 1, 5, 9, 2 }));
			}

			{
				IEnumerable <int> intEnumerable = EnumerableEx.Concat (new List<int>{ 3, 1, 4 }, new List<int>{ 1 }, new List<int>{ 5, 9, 2 });
				Assert.True (intEnumerable.SequenceEqual (new []{ 3, 1, 4, 1, 5, 9, 2 }));
			}
		}
	}
}
