using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class MaxTest
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Aggregates.cs#L90
		[Test ()]
		public void TestMax ()
		{
			{
				IComparer<int> comparer = AnonymousComparer.Create ((int lhs, int rhs) => (int)(Math.Abs (lhs) - Math.Abs (rhs)));
				int max= new int[]{ -3, -2, -1, 0, 1, 2, 3 }.Max (comparer);
				Assert.That (max, Is.EqualTo (-3));
			}

			{
				IComparer<string> comparer = AnonymousComparer.Create ((string lhs, string rhs) => lhs.Length - rhs.Length);
				string max = new string[]{ "Gosu", "Groovy", "Kotlin", "Scala", "Xtend", "Java"}.Max (comparer);
				Assert.That (max, Is.EqualTo ("Groovy"));
			}

			{
				IComparer<int> comparer = AnonymousComparer.Create ((int lhs, int rhs) => (int)(Math.Abs (lhs) - Math.Abs (rhs)));
				Assert.Catch<InvalidOperationException> (() => {
					new int[]{ }.Max (comparer);					
				});
			}
		}
	}
}
