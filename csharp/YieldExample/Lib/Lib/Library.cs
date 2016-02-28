using System;
using System.Collections.Generic;

namespace Lib
{
	public class Library
	{
		public static IEnumerator<int> Yield0 ()
		{
			yield return 0;
		}

		public static IEnumerator<int> Yield1 ()
		{
			if (false) {
				yield return 0;
			}
		}

		public static IEnumerator<int> Yield2 (bool isValiud)
		{
			if (isValiud) {
				yield return 0;
			}
		}


		public static IEnumerator<int> Yield3 (bool isValiud)
		{
			if (isValiud) {
				yield return 0;
			} else {
				yield return 1;
			}
		}

		public static IEnumerator<int> Yield4 ()
		{
			for (int i = 0; i < 10; i++) {
				yield return i;
			}
		}

		public static IEnumerator<int> Yield5 ()
		{
			for (int i = 0; i < 10; i++) {
				for (int j = 0; j < 10; j++) {
					yield return i * j;
				}
			}
		}

		public static IEnumerator<int> Yield6 (IEnumerable<int> nums)
		{
			foreach (int num in nums) {
				yield return num;
			}
		}


		public static IEnumerator<int> Yield7 (IEnumerable<int> nums, Func<int, bool> predicate)
		{
			foreach (int num in nums) {
				if (predicate (num)) {
					yield return num;
				}
			}
		}

		public static IEnumerator<int> Yield8 (IEnumerable<int> numsA, IEnumerable<int> numsB)
		{
			foreach (int numA in numsA) {
				foreach (int numB in numsB) {
					yield return numA * numB;
				}
			}
		}


		public static IEnumerator<int> Yield9 (IEnumerable<int> numsA, IEnumerable<int> numsB, Func<int, bool> predicate)
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

		public static IEnumerator<int> Yield10 (IEnumerable<int> nums, Func<int, bool> predicate)
		{
			foreach (int num in nums) {
				if (predicate (num)) {
					yield return num;
				} else {
					break;
				}
			}
		}

		public static IEnumerator<int> Yield11 (IEnumerable<int> nums, int count)
		{
			int currentCount = 0;
			foreach (int num in nums) {
				if (currentCount <= count) {
					yield return num;
				}
				currentCount++;
			}
		}

		public static IEnumerator<int> Yield12 ()
		{
			yield return 0;
			yield return 1;		
			yield return 2;
		}

		public static IEnumerator<int> Yield13 ()
		{
			yield return 0;
			if (true) {
				yield return 1;		
			} else {
				yield return 2;
			}
		}
	}
}

