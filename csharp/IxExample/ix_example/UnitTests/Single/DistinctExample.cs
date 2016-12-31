using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class DistinctExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L284
		[Test ()]
		public void TestDistinctTKey ()
		{

			// Please call next form: new []{ -2, -1, 0, 1, 2 }.Distinct(it => it);
			// In this test, to avoid compile error caused confilict with AnnonymousComparer.
			Assert.True (EnumerableEx.Distinct (new []{ -2, -1, 0, 1, 2 }, it => it).SequenceEqual (new []{ -2, -1, 0, 1, 2 }));
			Assert.True (EnumerableEx.Distinct (new []{ -2, -1, 0, 1, 2 }, Math.Abs).SequenceEqual (new []{ -2, -1, 0 }));
			Assert.True (EnumerableEx.Distinct (new []{ 2, 1, 0, -1, -2 }, Math.Abs).SequenceEqual (new []{ 2, 1, 0 }));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L284
		[Test ()]
		public void TestDistinctKeyselectorComparer ()
		{

			// Please call distict like : new []{ taro, jiro, saburo, shiro }.Distinct(keySelector, comparer);
			// In this test, call next form to avoid compile error caused confilict with AnnonymousComparer.
			IEqualityComparer<int> comparer = AnonymousComparer.Create<int>((lhs, rhs) => lhs / 10 == rhs / 10, age => age / 10);
			Func<Person, int> keySelector = person => person.Age;
			Person taro = new Person { Name = "Taro", Age = 30 };
			Person jiro = new Person { Name = "Jiro", Age = 26 };
			Person saburo = new Person { Name = "Saburo",	Age = 22 };
			Person shiro = new Person { Name = "Shiro",	Age = 18 };
			Assert.True (EnumerableEx.Distinct (new []{ taro, jiro, saburo, shiro }, keySelector, comparer).SequenceEqual (new []{ taro, jiro, shiro }));
			Assert.True (EnumerableEx.Distinct (new []{ shiro, saburo, jiro, taro }, keySelector, comparer).SequenceEqual (new []{ shiro, saburo, taro }));
		}
	}
}

