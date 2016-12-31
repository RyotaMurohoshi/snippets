using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class UsingExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L141
		[Test ()]
		public void TestUsing ()
		{
			var usingTarget = new UsingTarget (new List<int>{ 1, 2, 3 });
			var sequence = EnumerableEx.Using (() => usingTarget, it => it.List);

			Assert.False (usingTarget.IsCalledDispose);
			Assert.True (sequence.SequenceEqual (new []{ 1, 2, 3 }));
			Assert.True (usingTarget.IsCalledDispose);
		}
	}

	class UsingTarget :  IDisposable
	{
		public bool IsCalledDispose { get; private set; }

		public IReadOnlyList<int> List { get; }

		public UsingTarget (IReadOnlyList<int> list)
		{
			List = list;
		}

		void IDisposable.Dispose ()
		{
			IsCalledDispose = true;
		}
	}
}

