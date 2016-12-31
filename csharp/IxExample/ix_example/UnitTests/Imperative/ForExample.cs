using NUnit.Framework;
using System.Linq;

namespace IxExample
{
	[TestFixture ()]
	public class ForExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L141
		[Test ()]
		public void TestFor ()
		{
			var result = EnumerableEx
				.For(new []{ 1, 2, 3 }, num => EnumerableEx.Repeat(num, num))
				.SequenceEqual(new []{1, 2, 2, 3, 3, 3});
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L141
		[Test ()]
		public void TestForEmptySequence ()
		{
			var result = EnumerableEx
				.For(new int []{ }, num => EnumerableEx.Repeat(num, num))
				.SequenceEqual(new int[]{});
			Assert.True (result);
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L141
		[Test ()]
		public void TestForEmptySelector ()
		{
			var result = EnumerableEx
				.For(new []{ 1, 2, 3 }, num => new int[]{})
				.SequenceEqual(new int[]{});
			Assert.True (result);
		}
	}
}