using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class OnErrorResumeNextExample
	{
		// see https://github.com/shiftkey/Rx.NET/blob/core-port/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L189
		[Test ()]
		public void TestOnErrorResumeNextWithoutException ()
		{
			var sequence = new List<int>{ 0, 1, 2 }.OnErrorResumeNext (second: new List<int>{ 3, 4, 5 });
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5 });
			Assert.True (result);
		}

		// see https://github.com/shiftkey/Rx.NET/blob/core-port/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L189
		[Test ()]
		public void TestOnErrorResumeNextWithException ()
		{
			var sequence = new List<int>{ 0, 1, 2 }
				.Concat (EnumerableEx.Throw<int> (new Exception ()))
				.Concat (EnumerableEx.Return (0))
				.OnErrorResumeNext (new List<int>{ 3, 4, 5 });
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5 });
			Assert.True (result);
		}

		// see https://github.com/shiftkey/Rx.NET/blob/core-port/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L205
		[Test ()]
		public void TestOnErrorResumeNextParamsWithException ()
		{
			var sequenceA = new List<int>{ 0, 1, 2 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequenceB = new List<int>{ 3, 4, 5 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequenceC = new List<int>{ 6, 7, 8 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequence = EnumerableEx.OnErrorResumeNext (sequenceA, sequenceB, sequenceC);
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5, 6, 7, 8 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L101
		[Test ()]
		public void TestOnErrorResumeNextParamsWithoutException ()
		{
			var sequenceA = new List<int>{ 0, 1, 2 };
			var sequenceB = new List<int>{ 3, 4, 5 };
			var sequenceC = new List<int>{ 6, 7, 8 };
			var sequence = EnumerableEx.OnErrorResumeNext (sequenceA, sequenceB, sequenceC);
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5, 6, 7, 8 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L72
		[Test ()]
		public void TestOnErrorResumeNextIEnumerableIEnumerableWithoutException ()
		{
			var sequenceA = new List<int>{ 0, 1, 2 };
			var sequenceB = new List<int>{ 3, 4, 5 };
			var sequenceC = new List<int>{ 6, 7, 8 };
			var sequence = new List<IEnumerable<int>> { sequenceA, sequenceB, sequenceC }.OnErrorResumeNext ();
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5, 6, 7, 8 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L72
		[Test ()]
		public void TestOnErrorResumeNextIEnumerableIEnumerableWithException ()
		{
			var sequenceA = new List<int>{ 0, 1, 2 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequenceB = new List<int>{ 3, 4, 5 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequenceC = new List<int>{ 6, 7, 8 }.Concat (EnumerableEx.Throw<int> (new Exception ()));
			var sequence = new List<IEnumerable<int>> { sequenceA, sequenceB, sequenceC }.OnErrorResumeNext ();
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5, 6, 7, 8 });
			Assert.True (result);
		}
	}
}
