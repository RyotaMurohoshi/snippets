using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class IFExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L61
		[Test ()]
		public void TestIfTrue ()
		{
			var result = EnumerableEx.If(() => true, new []{ 1, 2, 3 }).SequenceEqual(new int[]{1, 2, 3});
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L61
		[Test ()]
		public void TestIfFalse ()
		{
			var result = EnumerableEx.If(() => false, new []{ 1, 2, 3 }).SequenceEqual(new int[]{});
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L42		[Test ()]
		public void TestIfThen ()
		{
			var result = EnumerableEx.If(
				condition:() => true,
				thenSource: new []{ 1, 2, 3 },
				elseSource: new []{ 4, 5, 6}).SequenceEqual(new int[]{1, 2, 3});
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L42		[Test ()]
		[Test ()]
		public void TestIfElse ()
		{
			var result = EnumerableEx.If(
				condition:() => false,
				thenSource: new []{ 1, 2, 3 },
				elseSource: new []{ 4, 5, 6}).SequenceEqual(new int[]{4, 5, 6});
			Assert.True (result);
		}
	}
}