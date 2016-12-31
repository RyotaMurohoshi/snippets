using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class CaseExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L96
		[Test ()]
		public void TestCase ()
		{
			var data = new Dictionary<string, IEnumerable<int>> {
				{ "a", new []{ 0 } },
				{ "b", new []{ 1, 2 } },
				{ "c", new []{ 3, 4, 5 } }
			};

			Assert.True (EnumerableEx
				.Case (() => "a", data)
				.SequenceEqual (new int[]{ 0 }));

			Assert.True (EnumerableEx
				.Case (() => "c", data)
				.SequenceEqual (new int[]{ 3, 4, 5 }));


			Assert.True (EnumerableEx
				.Case (() => "d", data)
				.SequenceEqual (new int[]{ }));
		}

		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Imperative.cs#L115
		[Test ()]
		public void TestCaseDefault ()
		{
			var data = new Dictionary<string, IEnumerable<int>> {
				{ "a", new []{ 0 } },
				{ "b", new []{ 1, 2 } },
				{ "c", new []{ 3, 4, 5 } }
			};

			Assert.True (EnumerableEx
				.Case (selector: () => "a", sources: data, defaultSource: new []{ 0, 0, 0 })
				.SequenceEqual (new int[]{ 0 }));

			Assert.True (EnumerableEx
				.Case (selector: () => "c", sources: data, defaultSource: new []{ 0, 0, 0 })
				.SequenceEqual (new int[]{ 3, 4, 5 }));

			Assert.True (EnumerableEx
				.Case (selector: () => "d", sources: data, defaultSource: new []{ 0, 0, 0 })
				.SequenceEqual (new int[]{ 0, 0, 0 }));
		}

	}
}
