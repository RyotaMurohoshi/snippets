using System;
using System.Linq;
using System.Collections.Generic;

namespace YieldExample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
		}

		static IEnumerator<int> Yield0 ()
		{
			yield return 0;
		}

		static IEnumerator<int> Yield1 ()
		{
			if (false) {
				yield return 0;
			}
		}

		static IEnumerator<int> Yield2 (bool isValiud)
		{
			if (isValiud) {
				yield return 0;
			}
		}


		static IEnumerator<int> Yield3 (bool isValiud)
		{
			if (isValiud) {
				yield return 0;
			} else {
				yield return 1;
			}
		}

		static IEnumerator<int> Yield4 ()
		{
			for (int i = 0; i < 10; i++) {
				yield return i;
			}
		}

		static IEnumerator<int> Yield5 ()
		{
			for (int i = 0; i < 10; i++) {
				for (int j = 0; j < 10; j++) {
					yield return i * j;
				}
			}
		}

		static IEnumerator<int> Yield6 (IEnumerable<int> nums)
		{
			foreach (int num in nums) {
				yield return num;
			}
		}


		static IEnumerator<int> Yield7 (IEnumerable<int> nums, Func<int, bool> predicate)
		{
			foreach (int num in nums) {
				if (predicate (num)) {
					yield return num;
				}
			}
		}

		static IEnumerator<int> Yield8 (IEnumerable<int> numsA, IEnumerable<int> numsB)
		{
			foreach (int numA in numsA) {
				foreach (int numB in numsB) {
					yield return numA * numB;
				}
			}
		}


		static IEnumerator<int> Yield9 (IEnumerable<int> numsA, IEnumerable<int> numsB, Func<int, bool> predicate)
		{
			foreach (int numA in numsA) {
				foreach (int numB in numsB) {
					var num = numA * numB;
					if (predicate (num)) {
						yield return num;
					}
				}
			}
		}

		static IEnumerator<int> Yield10 (IEnumerable<int> nums, Func<int, bool> predicate)
		{
			foreach (int num in nums) {
				if (predicate (num)) {
					yield return num;
				} else {
					break;
				}
			}
		}

		static IEnumerator<int> Yield11 (IEnumerable<int> nums, int count)
		{
			int currentCount = 0;
			foreach (int num in nums) {
				if(currentCount <= count) {
					yield return num;
				}
				currentCount++;
			}
		}
	}
}
