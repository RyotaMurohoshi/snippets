using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class MinByTest
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Aggregates.cs#L108
		[Test ()]
		public void TestMinByFuncTSourceTKey ()
		{
			{
				IList<string> minLengthLanguagess = new string[]{ "Gosu", "Groovy", "Kotlin", "Scala", "Xtend", "Java" }.MinBy (it => it.Length);
				Assert.True (minLengthLanguagess.SequenceEqual (new []{ "Gosu", "Java" }));
			}

			{
				IList<int> minAbss = new int[]{ -3, -2, -1, 0, 1, 2, 3 }.MinBy (it => Math.Abs (it));
				Assert.True (minAbss.SequenceEqual (new []{ 0 }));
			}

			{
				IList<int> minAbss = new int[]{ -3, -2, -1, -0, 0, 1, 2, 3 }.MinBy (it => Math.Abs (it));
				Assert.True (minAbss.SequenceEqual (new []{ -0, 0 }));
			}

			{
				Assert.Catch<InvalidOperationException> (() => {
					new int[]{ }.MinBy (it => Math.Abs (it));
				});
			}
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Aggregates.cs#L127
		[Test ()]
		public void TestMinByFuncTSourceTKeyIComparableTKey ()
		{
			Person taro = new Person { Name = "Taro", Age = 28 };
			Person jiro = new Person { Name = "Jiro", Age = 27 };
			Person saburo = new Person { Name = "Saburo", Age = 26 };
			Person anotherSaburo = new Person { Name = "Saburo", Age = 26 };
			IComparer<string> comparer = AnonymousComparer.Create ((string lhs, string rhs) => lhs.Length - rhs.Length);

			{
				IList<Person> minNameLengthPersons = new []{ taro, jiro, saburo }.MinBy (it => it.Name, comparer);
				Assert.True (minNameLengthPersons.SequenceEqual (new []{ taro, jiro }));
			}

			{
				IList<Person> minNameLengthPersons = new []{ jiro, saburo, anotherSaburo }.MinBy (it => it.Name, comparer);
				Assert.True (minNameLengthPersons.SequenceEqual (new []{ jiro }));
			}

			{
				Assert.Catch<InvalidOperationException> (() => {
					new Person[]{ }.MinBy (it => it.Name, comparer);
				});
			}
		}
	}
}
