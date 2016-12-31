using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class MinTest
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Aggregates.cs#L34
		[Test ()]
		public void TestMin ()
		{
			{
				IComparer<int> comparer = AnonymousComparer.Create ((int lhs, int rhs) => (int)(Math.Abs (lhs) - Math.Abs (rhs)));
				int min = new int[]{ -3, -2, -1, 0, 1, 2, 3 }.Min (comparer);
				Assert.That (min, Is.EqualTo (0));
			}

			{
				IComparer<string> comparer = AnonymousComparer.Create ((string lhs, string rhs) => lhs.Length - rhs.Length);
				string min = new string[]{ "Gosu", "Groovy", "Kotlin", "Scala", "Xtend", "Java"}.Min (comparer);
				Assert.That (min, Is.EqualTo ("Gosu"));
			}

			{
				IComparer<int> comparer = AnonymousComparer.Create ((int lhs, int rhs) => (int)(Math.Abs (lhs) - Math.Abs (rhs)));
				Assert.Catch<InvalidOperationException> (() => {
					new int[]{ }.Min (comparer);					
				});
			}
		}
	}
}


