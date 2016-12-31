using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class GenerateExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Creation.cs#L123
		[Test ()]
		public void TestGenerate ()
		{
			var initial = new {fst = 1, snd = 1};
			var sequence = EnumerableEx.Generate (
				               initialState: initial,
				               condition: state => state.fst < 100,
				               iterate: state => new { fst = state.snd, snd = state.fst + state.snd},
				               resultSelector: state => state.fst
			               );
			var result = sequence.SequenceEqual (new []{ 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 });
			Assert.True (result);
		}
	}
}