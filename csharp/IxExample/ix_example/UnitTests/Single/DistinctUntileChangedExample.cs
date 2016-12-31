using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class DistinctUntileChangedExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L354
		[Test ()]
		public void TestDistinctUntileChanged ()
		{
			Assert.True (new [] {
				new Point (0, 0),
				new Point (0, 1),
				new Point (1, 1),
				new Point (1, 2)
			}.DistinctUntilChanged ().SequenceEqual (new [] {
				new Point (0, 0),
				new Point (0, 1),
				new Point (1, 1),
				new Point (1, 2)
			}));

			Assert.True (new [] {
				new Point (0, 0),
				new Point (0, 1),
				new Point (1, 1),
				new Point (1, 1),
				new Point (1, 1),
				new Point (1, 2)
			}.DistinctUntilChanged ().SequenceEqual (new [] {
				new Point (0, 0),
				new Point (0, 1),
				new Point (1, 1),
				new Point (1, 2)
			}));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L369
		[Test ()]
		public void TestDistinctUntileChangedComparer ()
		{
			IEqualityComparer<int> comparer = AnonymousComparer.Create<int> ((lhs, rhs) => lhs / 10 == rhs / 10, it => it / 10);
			Assert.True (new []{ 10, 9, 12, 20, 17 }.DistinctUntilChanged (comparer).SequenceEqual (new []{ 10, 9, 12, 20, 17 }));
			Assert.True (new []{ 10, 9, 12, 20, 22, 21, 17 }.DistinctUntilChanged (comparer).SequenceEqual (new [] {
				10,
				9,
				12,
				20,
				17
			}));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L406
		[Test ()]
		public void TestDistinctUntileChangedKeySelector ()
		{
			Assert.True (new [] {
				new {value = 1, point = new Point (0, 0)},
				new {value = 2, point = new Point (0, 1)},
				new {value = 3, point = new Point (1, 1)},
				new {value = 4, point = new Point (1, 2)},
			}.DistinctUntilChanged (it => it.point).SequenceEqual (new [] {
				new {value = 1, point = new Point (0, 0)},
				new {value = 2, point = new Point (0, 1)},
				new {value = 3, point = new Point (1, 1)},
				new {value = 4, point = new Point (1, 2)},
			}));

			Assert.True (new [] {
				new {value = 1, point = new Point (0, 0)},
				new {value = 2, point = new Point (0, 1)},
				new {value = 3, point = new Point (1, 1)},
				new {value = 4, point = new Point (1, 1)},
				new {value = 5, point = new Point (1, 1)},
				new {value = 6, point = new Point (1, 2)},
			}.DistinctUntilChanged (it => it.point).SequenceEqual (new [] {
				new {value = 1, point = new Point (0, 0)},
				new {value = 2, point = new Point (0, 1)},
				new {value = 3, point = new Point (1, 1)},
				new {value = 6, point = new Point (1, 2)},
			}));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L387
		[Test ()]
		public void TestDistinctUntileChangedKeyselectorComparer ()
		{
			IEqualityComparer<Point> comparer = AnonymousComparer.Create<Point> ((lhs, rhs) => lhs == rhs, it => it.X ^ it.Y);

			Assert.True (new [] {
				new {value = 1, point = new Point (0, 0)},
				new {value = 2, point = new Point (0, 1)},
				new {value = 3, point = new Point (1, 1)},
				new {value = 4, point = new Point (1, 2)},
			}.DistinctUntilChanged (it => it.point, comparer).SequenceEqual (new [] {
				new {value = 1, point = new Point (0, 0)},
				new {value = 2, point = new Point (0, 1)},
				new {value = 3, point = new Point (1, 1)},
				new {value = 4, point = new Point (1, 2)},
			}));

			Assert.True (new [] {
				new {value = 1, point = new Point (0, 0)},
				new {value = 2, point = new Point (0, 1)},
				new {value = 3, point = new Point (1, 1)},
				new {value = 4, point = new Point (1, 1)},
				new {value = 5, point = new Point (1, 1)},
				new {value = 6, point = new Point (1, 2)},
			}.DistinctUntilChanged (it => it.point, comparer).SequenceEqual (new [] {
				new {value = 1, point = new Point (0, 0)},
				new {value = 2, point = new Point (0, 1)},
				new {value = 3, point = new Point (1, 1)},
				new {value = 6, point = new Point (1, 2)},
			}));
		}
	}
}

