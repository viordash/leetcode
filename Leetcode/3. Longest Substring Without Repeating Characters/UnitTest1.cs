using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace _3._Longest_Substring_Without_Repeating_Characters {
	public class Tests {
		[SetUp]
		public void Setup() {
		}

		public int LengthOfLongestSubstring(string s) {
			var maxLen = 0;
			var chars = new List<char>();
			foreach(var ch in s) {
				var exist = chars.LastIndexOf(ch);
				if(exist >= 0) {
					if(maxLen < chars.Count) {
						maxLen = chars.Count;
					}
					chars.RemoveRange(0, exist + 1);
					//chars = new List<char>(chars.Skip(exist));
				}
				chars.Add(ch);
			}
			if(maxLen < chars.Count) {
				maxLen = chars.Count;
			}
			return maxLen;
		}


		[Test]
		public void Test1() {
			//Input: s = "abcabcbb"
			//Output: 3
			//Explanation: The answer is "abc", with the length of 3.

			var res = LengthOfLongestSubstring("abcabcbb");
			Assert.That(res, Is.EqualTo(3));
		}

		[Test]
		public void Test2() {
			//Input: s = "bbbbb"
			//Output: 1
			//Explanation: The answer is "b", with the length of 1.

			var res = LengthOfLongestSubstring("bbbbb");
			Assert.That(res, Is.EqualTo(1));
		}

		[Test]
		public void Test3() {
			//Input: s = "pwwkew"
			//Output: 3
			//Explanation: The answer is "wke", with the length of 3.
			//Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

			var res = LengthOfLongestSubstring("pwwkew");
			Assert.That(res, Is.EqualTo(3));
		}

		[Test]
		public void Test4() {
			var res = LengthOfLongestSubstring("qopubjguxhxdipfzwswybgfylqvjzhar");
			Assert.That(res, Is.EqualTo(12));
		}
	}
}