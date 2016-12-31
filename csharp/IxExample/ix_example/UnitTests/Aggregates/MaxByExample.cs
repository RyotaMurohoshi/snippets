using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class MaxByTest
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Aggregates.cs#L108
		[Test ()]
		public void TestMaxByFuncTSourceTKey ()
		{
			{
				IList<string> maxLengthLanguagess = new string[]{ "Gosu", "Groovy", "Kotlin", "Scala", "Xtend", "Java" }.MaxBy (it => it.Length);
				Assert.True (maxLengthLanguagess.SequenceEqual (new []{ "Groovy", "Kotlin" }));
			}

			{
				IList<int> maxAbss = new int[]{ -3, -2, -1, 0, 1, 2, 3 }.MaxBy (it => Math.Abs (it));
				Assert.True (maxAbss.SequenceEqual (new []{ -3, 3 }));
			}

			{
				IList<int> maxAbss = new int[]{ -3, -2, -1, 0, 1, 2, 3, 4 }.MaxBy (it => Math.Abs (it));
				Assert.True (maxAbss.SequenceEqual (new []{ 4 }));
			}

			{
				Assert.Catch<InvalidOperationException> (() => {
					new int[]{ }.MaxBy (it => Math.Abs (it));
				});
			}
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Aggregates.cs#L127
		[Test ()]
		public void TestMaxByFuncTSourceTKeyIComparableTKey ()
		{
			Person taro = new Person { Name = "Taro", Age = 28 };
			Person jiro = new Person { Name = "Jiro", Age = 27 };
			Person saburo = new Person { Name = "Saburo", Age = 26 };
			Person anotherSaburo = new Person { Name = "Saburo", Age = 26 };
			IComparer<string> comparer = AnonymousComparer.Create ((string lhs, string rhs) => lhs.Length - rhs.Length);

			{
				IList<Person> maxNameLengthPersons = new []{ taro, jiro, saburo }.MaxBy (it => it.Name, comparer);
				Assert.True (maxNameLengthPersons.SequenceEqual (new []{ saburo }));
			}

			{
				IList<Person> maxNameLengthPersons = new []{ taro, jiro, saburo, anotherSaburo }.MaxBy (it => it.Name, comparer);
				Assert.True (maxNameLengthPersons.SequenceEqual (new []{ saburo, anotherSaburo }));
			}

			{
				Assert.Catch<InvalidOperationException> (() => {
					new Person[]{ }.MaxBy (it => it.Name, comparer);
				});
			}
		}
	}
}
