using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class RetryExample
	{
		// see https://github.com/shiftkey/Rx.NET/blob/core-port/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L259
		[Test ()]
		public void TestRetryWithoutException ()
		{
			var sequence = new List<int>{ 0, 1, 2 }.Retry ();
			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
		}

		// see https://github.com/shiftkey/Rx.NET/blob/core-port/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L259
		[Test ()]
		public void TestRetryWithException ()
		{
			var called = false;
			var content = EnumerableEx.Defer (() => {
				var list = new List<int>{ 0, 1, 2 };
				if (called) {
					return list;
				} else {
					called = true;
					return list.Concat (EnumerableEx.Throw<int> (new Exception ()));
				}
			});
			var sequence = content.Retry ().ToList ();
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 0, 1, 2 });
			Assert.True (result);
		}

		// see https://github.com/shiftkey/Rx.NET/blob/core-port/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L259
		[Test ()]
		public void TestRetryCountWithoutException ()
		{
			var sequence = new List<int>{ 0, 1, 2 }.Retry (3);
			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
		}

		// see https://github.com/shiftkey/Rx.NET/blob/core-port/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L259
		[Test ()]
		public void TestRetryCountWithException0 ()
		{
			var count = 0;
			var content = EnumerableEx.Defer (() => {
				var list = new List<int>{ 0, 1, 2 };
				if (count < 3) {
					count++;
					return list.Concat (EnumerableEx.Throw<int> (new Exception ()));
				} else {
					return new int[0];
				}
			});
			var sequence = content.Retry (4);
			var result = sequence.SequenceEqual (new [] { 0, 1, 2, 0, 1, 2, 0, 1, 2 });
			Assert.True (result);
		}

		// see https://github.com/shiftkey/Rx.NET/blob/core-port/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L259
		[Test ()]
		public void TestRetryCountWithException1 ()
		{
			var count = 0;
			var content = EnumerableEx.Defer (() => {
				var list = new List<int>{ 0, 1, 2 };
				if (count < 3) {
					count++;
					return list.Concat (EnumerableEx.Throw<int> (new Exception ()));
				} else {
					return new int[0];
				}
			});
			var sequence = content.Retry (3);
			Assert.Throws<Exception> (() => {
				foreach (var num in sequence) {
					;
				}
			});
		}
	}
}
