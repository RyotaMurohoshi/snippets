using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class FinallyExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L159
		[Test ()]
		public void TestFinallyWithouException ()
		{
			var called = false;
			var sequence = new List<int>{ 0, 1, 2 }.Finally (() => called = true);
			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
			Assert.True (called);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Exceptions.cs#L159
		[Test ()]
		public void TestFinallyWithException ()
		{
			var called = false;
			Assert.Throws<Exception> (() => {
				var sequence = new List<int>{ 0, 1, 2 }
					.Concat (EnumerableEx.Throw<int> (new Exception ()))
					.Finally (() => called = true);
				foreach(var num in sequence){
					;
				}
				Assert.Fail();
			});
			Assert.True (called);
		}
	}
}
