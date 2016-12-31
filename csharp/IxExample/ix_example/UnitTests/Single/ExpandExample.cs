using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace IxExample
{
	[TestFixture ()]
	public class ExpandExample
	{
		// see https://github.com/Reactive-Extensions/Rx.NET/blob/master/Ix.NET/Source/System.Interactive/EnumerableEx.Single.cs#L449
		[Test ()]
		public void TestExpand ()
		{
			var tree =
				N (
					v: 0,
					left: N (
						v: 1,
						left: N (v: 3),
						right: N (
							v: 4,
							right: N (v: 6)
						)
					),
					right: N (
						v: 2,
						left: N (v: 5)
					)
				);

			var seed = EnumerableEx.Return (tree);
			var sequence = EnumerableEx.Expand (seed, it => it.GetChildren ()).Select (it => it.Value);
			var result = sequence.SequenceEqual (new []{ 0, 1, 2, 3, 4, 5, 6 });
			Assert.True (result);
		}

		static Node N (int v, Node left = null, Node right = null)
		{
			return new Node {
				Value = v,
				LeftChild = left,
				RightChild = right
			};
		}
	}

	class Node
	{
		public int Value { get; set; }

		public Node LeftChild { get; set; }

		public Node RightChild { get; set; }

		public IReadOnlyList<Node> GetChildren ()
		{
			if (LeftChild == null && RightChild == null) {
				return new Node [0];
			} else if (LeftChild != null && RightChild != null) {
				return new []{ LeftChild, RightChild };
			} else if (LeftChild != null && RightChild == null) {
				return new []{ LeftChild };
			} else {
				return new []{ RightChild };
			}
		}
	}

}
