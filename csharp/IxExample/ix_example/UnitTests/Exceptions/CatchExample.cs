using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class CatchExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L18
		[Test ()]
		public void TestCatchHandlerWithoutException ()
		{
			var sequence = new List<int>{ 0, 1, 2 }.Catch ((Exception ex) => new List<int>{ 3, 4, 5 });
			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L18
		[Test ()]
		public void TestCatchHandlerWithException ()
		{
			var sequence = new []{ 0, 1, 2 }
				.Concat (EnumerableEx.Throw<int> (new Exception ()))
				.Concat (new []{ 3, 4, 5 })
				.Catch ((Exception ex) => new List<int>{ 6, 7, 8 });
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 6, 7, 8 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L101
		[Test ()]
		public void TestCatchFirstSecondWithoutException ()
		{
			var sequence = new List<int>{ 0, 1, 2 }.Catch (second: new List<int>{ 3, 4, 5 });
			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L101
		[Test ()]
		public void TestCatchFirstSecondWithException ()
		{
			var sequence = new List<int>{ 0, 1, 2 }
				.Concat (EnumerableEx.Throw<int> (new Exception ()))
				.Concat (EnumerableEx.Return (0))
				.Catch (new List<int>{ 3, 4, 5 });
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L101
		[Test ()]
		public void TestCatchParamsWithException ()
		{
			var sequenceA = new List<int>{ 0, 1, 2 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequenceB = new List<int>{ 3, 4, 5 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequenceC = new List<int>{ 6, 7, 8 };
			var sequence = EnumerableEx.Catch (sequenceA, sequenceB, sequenceC);
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5, 6, 7, 8 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L101
		[Test ()]
		public void TestCatchParamsWithoutException ()
		{
			var sequenceA = new List<int>{ 0, 1, 2 };
			var sequenceB = new List<int>{ 3, 4, 5 };
			var sequenceC = new List<int>{ 6, 7, 8 };
			var sequence = EnumerableEx.Catch (sequenceA, sequenceB, sequenceC);
			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L72
		[Test ()]
		public void TestCatchIEnumerableIEnumerableWithoutException ()
		{
			var sequenceA = new List<int>{ 0, 1, 2 };
			var sequenceB = new List<int>{ 3, 4, 5 };
			var sequenceC = new List<int>{ 6, 7, 8 };
			var sequence = new List<IEnumerable<int>> { sequenceA, sequenceB, sequenceC }.Catch ();
			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L72
		[Test ()]
		public void TestCatchIEnumerableIEnumerableWithException ()
		{
			var sequenceA = new List<int>{ 0, 1, 2 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequenceB = new List<int>{ 3, 4, 5 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequenceC = new List<int>{ 6, 7, 8 };
			var sequence = new List<IEnumerable<int>> { sequenceA, sequenceB, sequenceC }.Catch ();
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5, 6, 7, 8 });
			Assert.True (result);
		}
	}
}
