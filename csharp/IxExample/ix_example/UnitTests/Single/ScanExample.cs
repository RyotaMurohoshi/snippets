using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class ScanExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L537
		[Test ()]
		public void TestScanFuncTSourceTSourceTSource ()
		{
			{
				IEnumerable<int> actual = Enumerable.Range (0, 10).Scan ((int acc, int elem) => acc + elem);
				IEnumerable<int> expected = new [] { 1, 3, 6, 10, 15, 21, 28, 36, 45 };

				Assert.True (expected.SequenceEqual (actual));
			}

			{
				IEnumerable<int> actual = new int[]{ 0 }.Scan ((int acc, int elem) => acc + elem);
				IEnumerable<int> expected = new int[0];

				Assert.True (expected.SequenceEqual (actual));
			}

			{
				IEnumerable<int> actual = new int[0].Scan ((int acc, int elem) => acc + elem);
				IEnumerable<int> expected = new int[0];

				Assert.True (expected.SequenceEqual (actual));
			}
		}



		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L509
		[Test ()]
		public void TestScanTAccumlateFuncTAccumlateTSourceTAccumlate ()
		{
			{
				Point seed = new Point (0, 0);
				Direction[] directions = new [] {
					Direction.Right,
					Direction.Down,
					Direction.Left,
					Direction.Left,
					Direction.Up,
					Direction.Up,
					Direction.Right,
					Direction.Right,
					Direction.Down,
					Direction.Left
				};
				IEnumerable<Point> actual = directions.Scan (seed, (Point accPoint, Direction elemDirection) => accPoint.Move (elemDirection));
				IEnumerable<Point> expected = new [] {
					new Point (1, 0),
					new Point (1, -1),
					new Point (0, -1),
					new Point (-1, -1),
					new Point (-1, 0),
					new Point (-1, 1),
					new Point (0, 1),
					new Point (1, 1),
					new Point (1, 0),
					new Point (0, 0),
				};

				Assert.True (expected.SequenceEqual (actual));
			}

			{
				Point seed = new Point (0, 0);
				Direction[] directions = new [] {
					Direction.Right
				};

				IEnumerable<Point> actual = directions.Scan (seed, (Point accPoint, Direction elemDirection) => accPoint.Move (elemDirection));
				IEnumerable<Point> expected = new [] {
					new Point (1, 0)
				};

				Assert.True (expected.SequenceEqual (actual));
			}

			{
				Point seed = new Point (0, 0);
				Direction[] directions = new Direction[0];

				IEnumerable<Point> actual = directions.Scan (seed, (Point accPoint, Direction elemDirection) => accPoint.Move (elemDirection));
				IEnumerable<Point> expected = new Point[0];

				Assert.True (expected.SequenceEqual (actual));
			}
		}
	}
}
