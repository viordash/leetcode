using System.Collections.Generic;
using NUnit.Framework;

namespace _1414._Find_the_Minimum_Number_of_Fibonacci_Numbers_Whose_Sum_Is_K {
	public class Tests {
		[SetUp]
		public void Setup() {
		}
		//Fn = Fn-1 + Fn-2 for n > 2.
		//Explanation: The Fibonacci numbers are: 1, 1, 2, 3, 5, 8, 13, ...
		List<int> GetFibonacciNumbers(int max) {
			int n2 = 0;
			int n1 = 1;
			var res = new List<int>() { n1 };
			while(n1 < max) {
				int tn1 = n1;
				n1 += n2;
				n2 = tn1;

				res.Add(n1);
			}
			return res;
		}

		public int FindMinFibonacciNumbers(int k) {
			var fNumbers = GetFibonacciNumbers(k);
			int iter = 0;
			int i = fNumbers.Count - 1;
			while(k > 0 && i >= 0) {
				var fNumb = fNumbers[i--];
				if(k >= fNumb) {
					k -= fNumb;
					iter++;
				}
			}
			return iter;
		}

		[Test]
		public void Test1() {
			var numbers = GetFibonacciNumbers(999_999_999);
			Assert.That(new[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 }, Is.SubsetOf(numbers));
		}

		[Test]
		public void Test2() {
			var numbers = FindMinFibonacciNumbers(7);
			Assert.That(numbers, Is.EqualTo(2));
		}

		[Test]
		public void Test5() {
			var numbers = FindMinFibonacciNumbers(10);
			Assert.That(numbers, Is.EqualTo(2));
		}

		[Test]
		public void Test6() {
			var numbers = FindMinFibonacciNumbers(19);
			Assert.That(numbers, Is.EqualTo(3));
		}

		[Test]
		public void Test3() {
			var numbers = FindMinFibonacciNumbers(7999);
			Assert.That(numbers, Is.EqualTo(5));
		}

		[Test]
		public void Test4() {
			var numbers = FindMinFibonacciNumbers(13);
			Assert.That(numbers, Is.EqualTo(1));
		}
	}
}