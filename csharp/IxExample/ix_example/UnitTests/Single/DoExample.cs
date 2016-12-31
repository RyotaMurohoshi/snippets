using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class DoExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L74
		[Test ()]
		public void TestDoOnNext ()
		{
			var array = new []{ 0, 1, 2 };
			var list = new List<int> ();
			var sequence = array.Do (it => {
				list.Add (it);
			});

			foreach (var num in sequence) {
				;
			}
			Assert.True (list.SequenceEqual (new []{ 0, 1, 2 }));

			foreach (var num in sequence) {
				;
			}
			Assert.True (list.SequenceEqual (new []{ 0, 1, 2, 0, 1, 2 }));

			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L92
		[Test ()]
		public void TestDoOnNextOnCompleted ()
		{
			var array = new []{ 0, 1, 2 };
			var list = new List<int> ();
			var isCompleted = false;
			var sequence = array.Do (
				               onNext: list.Add,
				               onCompleted: () => isCompleted = true
			               );


			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
			Assert.True (list.SequenceEqual (new []{ 0, 1, 2 }));
			Assert.True (isCompleted);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L112
		[Test ()]
		public void TestDoOnNextOnErrorWithoutError ()
		{
			var array = new []{ 0, 1, 2 };
			var list = new List<int> ();
			var isErrored = false;
			var sequence = array.Do (
				               onNext: list.Add,
				               onError: error => isErrored = true
			               );

			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
			Assert.True (list.SequenceEqual (new []{ 0, 1, 2 }));
			Assert.False (isErrored);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L112
		[Test ()]
		public void TestDoOnNextOnErrorWithError ()
		{
			var array = new []{ 0, 1, 2 }.Concat (EnumerableEx.Throw<int> (new ExampleException ()));
			var list = new List<int> ();
			var isErrored = false;

			Assert.Throws<ExampleException> (() => {
				var sequence = array.Do (
					               onNext: list.Add,
					               onError: error => isErrored = true
				               );
				foreach (var num in sequence) {
				}
			});

			Assert.True (list.SequenceEqual (new []{ 0, 1, 2 }));
			Assert.True (isErrored);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L133
		[Test ()]
		public void TestDoOnNextOnErrorOnCompletedWithoutError ()
		{
			var array = new []{ 0, 1, 2 };
			var list = new List<int> ();
			var isErrored = false;
			var isCompletd = false;
			var sequence = array.Do (
				               onNext: list.Add,
				               onError: error => isErrored = true,
				               onCompleted: () => isCompletd = true
			               );

			var result = sequence.SequenceEqual (new []{ 0, 1, 2 });
			Assert.True (result);
			Assert.True (list.SequenceEqual (new []{ 0, 1, 2 }));
			Assert.False (isErrored);
			Assert.True (isCompletd);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L133
		[Test ()]
		public void TestDoOnNextOnErrorOnCompletedWithError ()
		{
			var array = new []{ 0, 1, 2 }.Concat (EnumerableEx.Throw<int> (new ExampleException ()));
			var list = new List<int> ();
			var isErrored = false;
			var isCompleted = false;

			Assert.Throws<ExampleException> (() => {
				var sequence = array.Do (
					               onNext: list.Add,
					               onError: error => isErrored = true,
					               onCompleted: () => isCompleted = true
				               );
				foreach (var num in sequence) {
				}
			});

			Assert.True (list.SequenceEqual (new []{ 0, 1, 2 }));
			Assert.True (isErrored);
			Assert.False (isCompleted);
		}
	}
}
