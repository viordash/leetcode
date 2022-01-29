using NUnit.Framework;

namespace _4._Median_of_Two_Sorted_Arrays {
	public class Tests {
		[SetUp]
		public void Setup() {
		}

		public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
			var totalLength = nums1.Length + nums2.Length;
			var hasMiddle = (totalLength & 1) != 0;

			var arr = new int[totalLength];
			int ind1 = 0;
			int ind2 = 0;
			for(int i = 0; i < totalLength; i++) {
				var item1 = ind1 < nums1.Length ? nums1[ind1] : int.MaxValue;
				var item2 = ind2 < nums2.Length ? nums2[ind2] : int.MaxValue;
				if(item1 < item2) {
					arr[i] = item1;
					ind1++;
				} else {
					arr[i] = item2;
					ind2++;
				}
			}
			if(hasMiddle) {
				return arr[totalLength / 2];
			} else {
				return ((double)arr[totalLength / 2 - 1] + (double)arr[totalLength / 2]) / 2.0;
			}
		}

		[Test]
		public void Test1() {
			//Input: nums1 = [1, 3], nums2 = [2]
			//Output: 2.00000
			//Explanation: merged array = [1, 2, 3] and median is 2.

			var res = FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 });
			Assert.That(res, Is.EqualTo(2));
		}

		[Test]
		public void Test2() {
			//Input: nums1 = [1, 2], nums2 = [3, 4]
			//Output: 2.50000
			//Explanation: merged array = [1, 2, 3, 4] and median is (2 + 3) / 2 = 2.5.

			var res = FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 });
			Assert.That(res, Is.EqualTo(2.5));
		}
	}
}